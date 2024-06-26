﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 06-03-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        06-03-2024
// ******************************************************************************************
// <copyright file="FileBrowser.xaml.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application
//    for the US Environmental Protection Agency (US EPA).
//    Copyright ©  2024  Terry Eppler
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
//    You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   FileBrowser.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Timers;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for FileBrowser.xaml
    /// </summary>
    /// <seealso cref="T:System.Windows.Window" />
    /// <seealso cref="T:System.Windows.Markup.IComponentConnector" />
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public partial class FileBrowser : Window
    {
        /// <summary>
        /// The back color
        /// </summary>
        private protected Color _backColor = new Color( )
        {
            A = 255,
            R = 20,
            G = 20,
            B = 20
        };

        /// <summary>
        /// The back hover color
        /// </summary>
        private protected Color _backHover = new Color( )
        {
            A = 255,
            R = 17,
            G = 53,
            B = 84
        };

        /// <summary>
        /// The fore color
        /// </summary>
        private protected Color _foreColor = new Color( )
        {
            A = 255,
            R = 106,
            G = 189,
            B = 252
        };

        /// <summary>
        /// The border color
        /// </summary>
        private protected Color _borderColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 120,
            B = 212
        };

        /// <summary>
        /// The locked object
        /// </summary>
        private protected object _path;

        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The status update
        /// </summary>
        private protected Action _statusUpdate;

        /// <summary>
        /// The timer
        /// </summary>
        private protected TimerCallback _timerCallback;

        /// <summary>
        /// The timer
        /// </summary>
        private protected System.Threading.Timer _timer;

        /// <summary>
        /// The time
        /// </summary>
        private protected int _time;

        /// <summary>
        /// The count
        /// </summary>
        private protected int _count;

        /// <summary>
        /// The seconds
        /// </summary>
        private protected int _seconds;

        /// <summary>
        /// The duration
        /// </summary>
        private protected double _duration;

        /// <summary>
        /// The data
        /// </summary>
        private protected string _data;

        /// <summary>
        /// The radio buttons
        /// </summary>
        private protected IList<MetroRadioButton> _radioButtons;

        /// <summary>
        /// The selected path
        /// </summary>
        private protected string _selectedPath;

        /// <summary>
        /// The selected file
        /// </summary>
        private protected string _selectedFile;

        /// <summary>
        /// The initial directory
        /// </summary>
        private protected string _initialDirectory;

        /// <summary>
        /// The file extension
        /// </summary>
        private protected string _fileExtension;

        /// <summary>
        /// The extension
        /// </summary>
        private protected EXT _extension;

        /// <summary>
        /// The file paths
        /// </summary>
        private protected IList<string> _filePaths;

        /// <summary>
        /// The initial dir paths
        /// </summary>
        private protected IList<string> _initialPaths;

        /// <summary>
        /// The image
        /// </summary>
        private protected BitmapImage _image;

        /// <summary>
        /// Gets or sets the selected path.
        /// </summary>
        /// <value>
        /// The selected path.
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

        /// <summary>
        /// Gets or sets the selected file.
        /// </summary>
        /// <value>
        /// The selected file.
        /// </value>
        public string SelectedFile
        {
            get
            {
                return _selectedFile;
            }
            private protected set
            {
                _selectedFile = value;
            }
        }

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
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        return _busy;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        return _busy;
                    }
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FileBrowser" /> class.
        /// </summary>
        public FileBrowser( )
        {
            InitializeComponent( );
            InitializeDelegates( );
            RegisterCallbacks( );

            // Basic Properties
            Width = 700;
            Height = 480;
            ResizeMode = ResizeMode.CanResize;
            FontFamily = new FontFamily( "Segoe UI" );
            FontSize = 12d;
            WindowStyle = WindowStyle.SingleBorderWindow;
            Padding = new Thickness( 1 );
            Margin = new Thickness( 3 );
            BorderThickness = new Thickness( 1 );
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Background = new SolidColorBrush( _backColor );
            Foreground = new SolidColorBrush( _foreColor );
            BorderBrush = new SolidColorBrush( _borderColor );

            // Timer Properties
            _time = 0;
            _seconds = 5;

            // Budget Properties
            _extension = EXT.XLSX;
            _fileExtension = _extension.ToString( ).ToLower( );
            _radioButtons = GetRadioButtons( );
            _initialPaths = CreateInitialDirectoryPaths( );

            // Wire Events
            IsVisibleChanged += OnVisibleChanged;
        }

        /// <summary>
        /// Initializes the callbacks.
        /// </summary>
        private void RegisterCallbacks( )
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
        /// Initializes the timer.
        /// </summary>
        private void InitializeTimer( )
        {
            try
            {
                _timerCallback += UpdateStatus;
                _timer = new System.Threading.Timer( _timerCallback, null, 0, 260 );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the buttons.
        /// </summary>
        private void InitializeButtons( )
        {
            try
            {
                BrowseButton.Content = "Browse";
                ClearButton.Content = "Clear";
                SelectButton.Content = "Select";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the RadioButton events.
        /// </summary>
        private protected void RegisterRadioButtonEvents( )
        {
            try
            {
                foreach( var _radioButton in _radioButtons )
                {
                    _radioButton.Click += OnRadioButtonSelected;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the radio buttons.
        /// </summary>
        /// <returns>
        /// List( MetroRadioButton )
        /// </returns>
        private protected virtual IList<MetroRadioButton> GetRadioButtons( )
        {
            try
            {
                var _list = new List<MetroRadioButton>
                {
                    PdfRadioButton,
                    AccessRadioButton,
                    SQLiteRadioButton,
                    SqlServerRadioButton,
                    ExcelRadioButton,
                    CsvRadioButton,
                    TextRadioButton,
                    PowerPointRadioButton,
                    WordRadioButton,
                    ExecutableRadioButton,
                    LibraryRadioButton
                };

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<MetroRadioButton> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<MetroRadioButton> );
            }
        }

        /// <summary>
        /// Populates the ListBox.
        /// </summary>
        private protected void PopulateListBox( )
        {
            try
            {
                ListBox.Items?.Clear( );
                if( _filePaths?.Any( ) == true )
                {
                    foreach( var _item in _filePaths )
                    {
                        ListBox.Items.Add( _item );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the ListBox.
        /// </summary>
        /// <param name="filePaths">The file paths.</param>
        private protected void PopulateListBox( IEnumerable<string> filePaths )
        {
            try
            {
                ThrowIf.Null( filePaths, nameof( filePaths ) );
                ListBox.Items?.Clear( );
                var _paths = filePaths.ToArray( );
                for( var _i = 0; _i < _paths.Length; _i++ )
                {
                    var _item = _paths[ _i ];
                    if( !string.IsNullOrEmpty( _item ) )
                    {
                        ListBox?.Items?.Add( _item );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the ListView paths.
        /// </summary>
        /// <returns></returns>
        private protected void CreateListViewFilePaths( )
        {
            try
            {
                _filePaths?.Clear( );
                var _pattern = "*." + _fileExtension;
                for( var _i = 0; _i < _initialPaths.Count; _i++ )
                {
                    var _dirPath = _initialPaths[ _i ];
                    var _parent = Directory.CreateDirectory( _dirPath );
                    var _folders = _parent.GetDirectories( )
                        ?.Where( s => s.Name.Contains( "My" ) == false )
                        ?.Select( s => s.FullName )
                        ?.ToList( );

                    var _topLevelFiles = _parent.GetFiles( _pattern, SearchOption.TopDirectoryOnly )
                        ?.Select( f => f.FullName )
                        ?.ToArray( );

                    _filePaths.AddRange( _topLevelFiles );
                    for( var _k = 0; _k < _folders.Count; _k++ )
                    {
                        var _folder = Directory.CreateDirectory( _folders[ _k ] );
                        var _lowerLevelFiles = _folder
                            .GetFiles( _pattern, SearchOption.AllDirectories )
                            ?.Select( s => s.FullName )
                            ?.ToArray( );

                        _filePaths.AddRange( _lowerLevelFiles );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the file paths.
        /// </summary>
        /// <returns></returns>
        private protected IList<string> GetFilePaths( )
        {
            try
            {
                BeginInit( );
                var _watch = new Stopwatch( );
                _watch.Start( );
                var _list = new List<string>( );
                var _pattern = "*" + _fileExtension;
                for( var _i = 0; _i < _initialPaths.Count; _i++ )
                {
                    var _dirPath = _initialPaths[ _i ];
                    var _parent = Directory.CreateDirectory( _dirPath );
                    var _folders = _parent.GetDirectories( )
                        ?.Where( s => s.Name.StartsWith( "My" ) == false )
                        ?.Select( s => s.FullName )
                        ?.ToList( );

                    var _topLevelFiles = _parent.GetFiles( _pattern, SearchOption.TopDirectoryOnly )
                        ?.Select( f => f.FullName )
                        ?.ToArray( );

                    _list.AddRange( _topLevelFiles );
                    for( var _k = 0; _k < _folders.Count; _k++ )
                    {
                        var _folder = Directory.CreateDirectory( _folders[ _k ] );
                        var _lowerLevelFiles = _folder
                            .GetFiles( _pattern, SearchOption.AllDirectories )
                            ?.Select( s => s.FullName )
                            ?.ToArray( );

                        _list.AddRange( _lowerLevelFiles );
                    }
                }

                EndInit( );
                _watch.Stop( );
                _duration = _watch.Elapsed.TotalMilliseconds;
                return _list;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Gets the initial dir paths.
        /// </summary>
        /// <returns>
        /// IList(string)
        /// </returns>
        private protected IList<string> CreateInitialDirectoryPaths( )
        {
            try
            {
                var _current = Environment.CurrentDirectory;
                var _list = new List<string>
                {
                    Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory ),
                    Environment.GetFolderPath( Environment.SpecialFolder.Personal ),
                    Environment.GetFolderPath( Environment.SpecialFolder.Recent ),
                    Environment.CurrentDirectory,
                    @"C:\Users\terry\source\repos\Badger\Resources\Documents",
                    _current
                };

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
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
                var _notify = new Notification( message )
                {
                    Owner = this
                };

                _notify.Show( );
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
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( )
        {
            try
            {
                TimeLabel.Content = DateTime.Now.ToLongTimeString( );
                DateLabel.Content = DateTime.Now.ToLongDateString( );
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
        /// Sets the extension.
        /// </summary>
        private void SetImage( )
        {
            try
            {
                var _file = $@"/UI/Windows/File/{_fileExtension.ToUpper( )}.png";
                var _uri = new Uri( _file, UriKind.Relative );
                _image = new BitmapImage( _uri );
                PictureBox.Source = _image;
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
        private void OnVisibleChanged( object sender, DependencyPropertyChangedEventArgs e )
        {
            try
            {
                ExcelRadioButton.IsChecked = true;
                _filePaths = GetFilePaths( );
                _count = _filePaths.Count;
                InitializeTimer( );
                PopulateListBox( );
                InitializeLabels( );
                InitializeButtons( );
                RegisterRadioButtonEvents( );
                SetImage( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [RadioButton selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name = "e" > </param>
        private protected void OnRadioButtonSelected( object sender, EventArgs e )
        {
            try
            {
                var _radioButton = sender as MetroRadioButton;
                _fileExtension = _radioButton?.Tag?.ToString( );
                if( !string.IsNullOrEmpty( _fileExtension ) )
                {
                    _extension = (EXT)Enum.Parse( typeof( EXT ), _fileExtension.ToUpper( ) );
                }

                _filePaths = GetFilePaths( );
                _count = _filePaths.Count;
                PopulateListBox( _filePaths );
                SetImage( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
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