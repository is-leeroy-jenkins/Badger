// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-04-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-04-2025
// ******************************************************************************************
// <copyright file="DocumentWindow.xaml.cs" company="Terry D. Eppler">
//    Badger is a small and simple windows (wpf) application for interacting with the OpenAI API
//    that's developed in C-Sharp under the MIT license.C#.
// 
//    Copyright ©  2020-2024 Terry D. Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the “Software”),
//    to deal in the Software without restriction,
//    including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense,
//    and/or sell copies of the Software,
//    and to permit persons to whom the Software is furnished to do so,
//    subject to the following conditions:
// 
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
// 
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//    DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   DocumentWindow.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using Syncfusion.SfSkinManager;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Win32;
    using Properties;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Messages;
    using ToastNotifications.Position;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for DocumentWindow.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "LoopCanBePartlyConvertedToQuery" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "CanSimplifyDictionaryLookupWithTryGetValue" ) ]
    public partial class DocumentWindow : Window, IDisposable
    {
        /// <summary>
        /// The data model
        /// </summary>
        private protected DataGenerator _dataModel;

        /// <summary>
        /// The data table
        /// </summary>
        private protected DataTable _dataTable;

        /// <summary>
        /// The filter
        /// </summary>
        private protected IDictionary<string, string> _documents;

        /// <summary>
        /// The filter
        /// </summary>
        private protected IDictionary<string, object> _filter;

        /// <summary>
        /// The prefix
        /// </summary>
        private protected string _prefix;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The selected path
        /// </summary>
        private protected string _selectedPath;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The SQL command
        /// </summary>
        private protected string _sqlQuery;

        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The path
        /// </summary>
        private protected object _entry = new object( );

        /// <summary>
        /// The seconds
        /// </summary>
        private protected int _seconds;

        /// <summary>
        /// The update status
        /// </summary>
        private protected Action _statusUpdate;

        /// <summary>
        /// The theme
        /// </summary>
        private protected readonly DarkMode _theme = new DarkMode( );

        /// <summary>
        /// The time
        /// </summary>
        private protected int _time;

        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// The timer
        /// </summary>
        private protected TimerCallback _timerCallback;

        /// <summary>
        /// The code editor path
        /// </summary>
        private protected string _codeEditor;

        /// <summary>
        /// The explanatory statements
        /// </summary>
        private protected IDictionary<string, string> _explanatoryStatements;

        /// <summary>
        /// The public laws
        /// </summary>
        private protected IDictionary<string, string> _publicLaws;

        /// <summary>
        /// The federal regulations
        /// </summary>
        private protected IDictionary<string, string> _federalRegulations;

        /// <summary>
        /// The document path
        /// </summary>
        private protected string _documentPath;

        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
        /// </value>
        public bool IsBusy
        {
            get
            {
                lock( _entry )
                {
                    return _busy;
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public string SelectedPath
        {
            get
            {
                return _selectedPath;
            }
            private protected set
            {
                _selectedPath = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DocumentWindow" /> class.
        /// </summary>
        public DocumentWindow( )
            : base( )
        {
            // Theme Properties
            SfSkinManager.SetTheme( this, new Theme( "FluentDark", App.Controls ) );

            // Window Initialization
            InitializeComponent( );
            InitializeDelegates( );
            RegisterCallbacks( );

            // Window Properties
            Title = "PDF Viewer";
            _codeEditor = Locations.CodeEditor;
            _explanatoryStatements = new Dictionary<string, string>( );
            _federalRegulations = new Dictionary<string, string>( );
            _publicLaws = new Dictionary<string, string>( );
            _prefix = Locations.PathPrefix;

            // Initialize Default Provider
            _source = Source.Resources;
            _provider = Provider.SQLite;

            // Initialize Collections
            _filter = new Dictionary<string, object>( );

            // Window Events
            Loaded += OnLoaded;
        }

        /// <summary>
        /// Initializes the callbacks.
        /// </summary>
        private void RegisterCallbacks( )
        {
            try
            {
                ToolStripFirstButton.Click += OnFirstButtonClick;
                ToolStripPreviousButton.Click += OnPreviousButtonClick;
                ToolStripNextButton.Click += OnNextButtonClick;
                ToolStripLastButton.Click += OnLastButtonClick;
                ToolStripGoButton.Click += OnLookupButtonClick;
                ToolStripRefreshButton.Click += OnRefreshButtonClick;
                ToolStripBrowseButton.Click += OnMenuButtonClick;
                ToolStripToggleButton.Click += OnToggleButtonClick;
                ToolStripExitButton.Click += OnExitButtonClick;
                DocumentListBox.SelectionChanged += OnListBoxItemSelected;
                ToolStripBrowseButton.Click += OnBrowseButtonClick;
                ExplanatoryStatementsRadioButton.Click += OnRadioButtonSelected;
                AppropriationsRadioButton.Click += OnRadioButtonSelected;
                RegulationsRadioButton.Click += OnRadioButtonSelected;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the delegates.
        /// </summary>
        private void InitializeDelegates( )
        {
            try
            {
                _statusUpdate += UpdateStatus;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the labels.
        /// </summary>
        private void InitializeLabels( )
        {
            try
            {
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the text box.
        /// </summary>
        private void InitializeTextBoxes( )
        {
            try
            {
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the combo boxes.
        /// </summary>
        private void InitializeComboBoxes( )
        {
            try
            {
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the list boxes.
        /// </summary>
        private void InitializeListBoxes( )
        {
            try
            {
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the timer.
        /// </summary>
        private void InitializeTimer( )
        {
            try
            {
                _timerCallback += UpdateStatus;
                _timer = new Timer( _timerCallback, null, 0, 260 );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the toolbar.
        /// </summary>
        private void InitializeToolbar( )
        {
            try
            {
                ToolStripFirstButton.Visibility = Visibility.Hidden;
                ToolStripPreviousButton.Visibility = Visibility.Hidden;
                ToolStripNextButton.Visibility = Visibility.Hidden;
                ToolStripLastButton.Visibility = Visibility.Hidden;
                ToolStripTextBox.Visibility = Visibility.Hidden;
                ToolStripGoButton.Visibility = Visibility.Hidden;
                ToolStripRefreshButton.Visibility = Visibility.Hidden;
                ToolStripFirstButton.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the viewer.
        /// </summary>
        private void InitializeViewer( )
        {
            try
            {
                PdfViewer.Zoom = 75;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData( )
        {
            try
            {
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Fades the in asynchronous.
        /// </summary>
        /// <param name="form">The o.</param>
        /// <param name="interval">The interval.</param>
        private async void FadeInAsync( Window form, int interval = 80 )
        {
            try
            {
                ThrowIf.Null( form, nameof( form ) );
                while( form.Opacity < 1.0 )
                {
                    await Task.Delay( interval );
                    form.Opacity += 0.05;
                }

                form.Opacity = 1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Fades the out asynchronous.
        /// </summary>
        /// <param name="form">The o.</param>
        /// <param name="interval">The interval.</param>
        private async void FadeOutAsync( Window form, int interval = 80 )
        {
            try
            {
                ThrowIf.Null( form, nameof( form ) );
                while( form.Opacity > 0.0 )
                {
                    await Task.Delay( interval );
                    form.Opacity -= 0.05;
                }

                form.Opacity = 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Creates the paths.
        /// </summary>
        /// <returns></returns>
        private void BuildPaths( )
        {
            try
            {
                _explanatoryStatements = GetExplanatoryStatementPaths( );
                _publicLaws = GetAppropriationPaths( );
                _federalRegulations = GetFederalRegulationPaths( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private void Busy( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = true;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private void Chill( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = false;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the callbacks.
        /// </summary>
        private void ClearCallbacks( )
        {
            try
            {
                ToolStripFirstButton.Click -= OnFirstButtonClick;
                ToolStripPreviousButton.Click -= OnPreviousButtonClick;
                ToolStripNextButton.Click -= OnNextButtonClick;
                ToolStripLastButton.Click -= OnLastButtonClick;
                ToolStripGoButton.Click -= OnLookupButtonClick;
                ToolStripRefreshButton.Click -= OnRefreshButtonClick;
                ToolStripBrowseButton.Click -= OnMenuButtonClick;
                ToolStripToggleButton.Click -= OnToggleButtonClick;
                DocumentListBox.SelectionChanged -= OnListBoxItemSelected;
                ToolStripBrowseButton.Click -= OnBrowseButtonClick;
                ExplanatoryStatementsRadioButton.Click -= OnRadioButtonSelected;
                AppropriationsRadioButton.Click -= OnRadioButtonSelected;
                RegulationsRadioButton.Click -= OnRadioButtonSelected;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the explanatory statement paths.
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetExplanatoryStatementPaths( )
        {
            try
            {
                var _folder = Locations.ExplanatoryStatements;
                var _documentPaths = new Dictionary<string, string>( );
                var _dirPath = _prefix + _folder;
                var _files = Directory.EnumerateFiles( _dirPath );
                foreach( var _path in _files )
                {
                    var _fileName = Path.GetFileNameWithoutExtension( _path );
                    _documentPaths.Add( _fileName, _path );
                }

                return _documentPaths?.Any( ) == true
                    ? _documentPaths
                    : default( IDictionary<string, string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, string> );
            }
        }

        /// <summary>
        /// Gets the appropriation paths.
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetAppropriationPaths( )
        {
            try
            {
                _prefix = Locations.PathPrefix;
                var _folder = Locations.Appropriations;
                var _documentPaths = new Dictionary<string, string>( );
                var _dirPath = _prefix + _folder;
                var _files = Directory.EnumerateFiles( _dirPath );
                foreach( var _filePath in _files )
                {
                    var _fileName = Path.GetFileNameWithoutExtension( _filePath );
                    _documentPaths.Add( _fileName, _filePath );
                }

                return _documentPaths?.Any( ) == true
                    ? _documentPaths
                    : default( IDictionary<string, string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, string> );
            }
        }

        /// <summary>
        /// Gets the federal regulation paths.
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetFederalRegulationPaths( )
        {
            try
            {
                _prefix = Locations.PathPrefix;
                var _folder = Locations.Regulations;
                var _documentPaths = new Dictionary<string, string>( );
                var _directory = _prefix + _folder;
                var _files = Directory.EnumerateFiles( _directory );
                foreach( var _filePath in _files )
                {
                    var _fileName = Path.GetFileNameWithoutExtension( _filePath );
                    _documentPaths.Add( _fileName, _filePath );
                }

                return _documentPaths?.Any( ) == true
                    ? _documentPaths
                    : default( IDictionary<string, string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, string> );
            }
        }

        /// <summary>
        /// Creates a notifier.
        /// </summary>
        /// <returns>
        /// Notifier
        /// </returns>
        private Notifier CreateNotifier( )
        {
            try
            {
                var _position = new PrimaryScreenPositionProvider( Corner.BottomRight, 10, 10 );
                var _lifeTime = new TimeAndCountBasedLifetimeSupervisor( TimeSpan.FromSeconds( 5 ),
                    MaximumNotificationCount.UnlimitedNotifications( ) );

                return new Notifier( _cfg =>
                {
                    _cfg.LifetimeSupervisor = _lifeTime;
                    _cfg.PositionProvider = _position;
                    _cfg.Dispatcher = Application.Current.Dispatcher;
                } );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Notifier );
            }
        }

        /// <summary>
        /// Sends the notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        private void SendNotification( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _notification = CreateNotifier( );
                _notification.ShowInformation( message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Shows the splash message.
        /// </summary>
        private void SendMessage( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _splash = new SplashMessage( message )
                {
                    Owner = this
                };

                _splash.Show( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Shows the items.
        /// </summary>
        private void SetToolbarVisible( )
        {
            try
            {
                ToolStripFirstButton.Visibility = Visibility.Visible;
                ToolStripPreviousButton.Visibility = Visibility.Visible;
                ToolStripNextButton.Visibility = Visibility.Visible;
                ToolStripLastButton.Visibility = Visibility.Visible;
                ToolStripTextBox.Visibility = Visibility.Visible;
                ToolStripGoButton.Visibility = Visibility.Visible;
                ToolStripRefreshButton.Visibility = Visibility.Visible;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Hides the items.
        /// </summary>
        private void SetToolbarHidden( )
        {
            try
            {
                ToolStripFirstButton.Visibility = Visibility.Hidden;
                ToolStripPreviousButton.Visibility = Visibility.Hidden;
                ToolStripNextButton.Visibility = Visibility.Hidden;
                ToolStripLastButton.Visibility = Visibility.Hidden;
                ToolStripTextBox.Visibility = Visibility.Hidden;
                ToolStripGoButton.Visibility = Visibility.Hidden;
                ToolStripRefreshButton.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the toolbar visibility.
        /// </summary>
        private void SetToolbarVisibility( )
        {
            try
            {
                if( !ToolStripFirstButton.IsVisible )
                {
                    SetToolbarVisible( );
                }
                else
                {
                    SetToolbarHidden( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( )
        {
            try
            {
                StatusLabel.Content = DateTime.Now.ToLongTimeString( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( object state )
        {
            try
            {
                Dispatcher.BeginInvoke( _statusUpdate );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the main form.
        /// </summary>
        private void OpenChatWindow( )
        {
            try
            {
                if( App.ActiveWindows?.ContainsKey( "ChatWindow" ) == true )
                {
                    var _form = ( ChatWindow )App.ActiveWindows[ "ChatWindow" ];
                    _form.Show( );
                }
                else
                {
                    var _chat = new ChatWindow
                    {
                        Topmost = true
                    };

                    _chat.Show( );
                }

                Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the chat window.
        /// </summary>
        private protected void OpenWebBrowser( )
        {
            try
            {
                if( App.ActiveWindows?.ContainsKey( "WebBrowser" ) == true )
                {
                    var _browser = ( WebBrowser )App.ActiveWindows[ "WebBrowser" ];
                    _browser.Show( );
                }
                else
                {
                    var _webBrowser = new WebBrowser( );
                    App.ActiveWindows?.Add( "WebBrowser", _webBrowser );
                    _webBrowser.Show( );
                }

                Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the explanatory statements.
        /// </summary>
        private void PopulateExplanatoryStatements( )
        {
            try
            {
                DocumentListBox.Items.Clear( );
                foreach( var _kvp in _explanatoryStatements )
                {
                    var _item = new ListBoxItem
                    {
                        Content = _kvp.Key,
                        Tag = _kvp.Value
                    };

                    DocumentListBox.Items.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the public laws.
        /// </summary>
        private void PopulatePublicLaws( )
        {
            try
            {
                DocumentListBox.Items.Clear( );
                foreach( var _kvp in _publicLaws )
                {
                    var _item = new ListBoxItem
                    {
                        Content = _kvp.Key,
                        Tag = _kvp.Value
                    };

                    DocumentListBox.Items.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the federal regulations.
        /// </summary>
        private void PopulateFederalRegulations( )
        {
            try
            {
                DocumentListBox.Items.Clear( );
                foreach( var _kvp in _federalRegulations )
                {
                    var _item = new ListBoxItem
                    {
                        Content = _kvp.Key,
                        Tag = _kvp.Value
                    };

                    DocumentListBox.Items.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnLoaded( object sender, RoutedEventArgs e )
        {
            try
            {
                InitializeTimer( );
                InitializeToolbar( );
                InitializeViewer( );
                BuildPaths( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [first button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFirstButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [previous button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnPreviousButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [next button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnNextButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [last button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnLastButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [browse button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnBrowseButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _dialog = new OpenFileDialog
                {
                    Filter = "PDF Files|*.pdf"
                };

                _dialog.ShowDialog( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [edit button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnEditButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [refresh button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnRefreshButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [lookup button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnLookupButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [undo button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnUndoButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [delete button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnDeleteButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [export button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnExportButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [save button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnSaveButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [menu button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnMenuButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [exit button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnExitButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [calculator menu option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnCalculatorMenuOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _calculator = new CalculatorWindow( );
                _calculator.ShowDialog( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [file menu option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFileMenuOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _fileBrowser = new FileBrowser
                {
                    Owner = this,
                    Topmost = true
                };

                _fileBrowser.Show( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [control panel option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnControlPanelOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                WinMinion.LaunchControlPanel( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [task manager option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnTaskManagerOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                WinMinion.LaunchTaskManager( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [close option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnCloseOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [chrome option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// containing the event data.</param>
        private void OnChromeOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                WebMinion.RunChrome( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [edge option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnEdgeOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                WebMinion.RunEdge( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [firefox option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// containing the event data.</param>
        private void OnFirefoxOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                WebMinion.RunFirefox( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [toggle button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnToggleButtonClick( object sender, RoutedEventArgs e )
        {
            SetToolbarVisibility( );
        }

        /// <summary>
        /// Called when [web option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnWebOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                OpenWebBrowser( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [chat option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnChatOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                OpenChatWindow( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [document selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnListBoxItemSelected( object sender, RoutedEventArgs e )
        {
            try
            {
                var _listBox = sender as ListBox;
                _selectedPath = ( ( ListBoxItem )_listBox.SelectedItem ).Tag.ToString( );
                PdfViewer.Load( _selectedPath );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [ComboBox item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" />
        /// instance containing the event data.</param>
        private void OnRadioButtonSelected( object sender, RoutedEventArgs e )
        {
            try
            {
                if( sender is RadioButton _radioButton
                    && _radioButton.IsChecked == true )
                {
                    var _item = _radioButton?.Tag?.ToString( );
                    switch( _item )
                    {
                        case "Appropriations":
                        {
                            PopulatePublicLaws( );
                            break;
                        }
                        case "ExplanatoryStatements":
                        {
                            PopulateExplanatoryStatements( );
                            break;
                        }
                        case "Regulations":
                        {
                            PopulateFederalRegulations( );
                            break;
                        }
                        default:
                        {
                            PopulateFederalRegulations( );
                            break;
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c>
        /// to release both managed
        /// and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                _timer?.Dispose( );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks
        /// associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}