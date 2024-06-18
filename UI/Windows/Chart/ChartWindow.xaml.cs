// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 06-16-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        06-16-2024
// ******************************************************************************************
// <copyright file="ChartWindow.xaml.cs" company="Terry D. Eppler">
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
//   ChartWindow.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Syncfusion.SfSkinManager;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Position;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public partial class ChartWindow : Window
    {
        /// <summary>
        /// The locked object
        /// </summary>
        private object _path;

        /// <summary>
        /// The busy
        /// </summary>
        private bool _busy;

        /// <summary>
        /// The status update
        /// </summary>
        private Action _statusUpdate;

        /// <summary>
        /// The count
        /// </summary>
        private protected int _count;

        /// <summary>
        /// The hover text
        /// </summary>
        private protected string _hoverText;

        /// <summary>
        /// The selected table
        /// </summary>
        private protected string _selectedTable;

        /// <summary>
        /// The first category
        /// </summary>
        private protected string _firstCategory;

        /// <summary>
        /// The first value
        /// </summary>
        private protected string _firstValue;

        /// <summary>
        /// The second category
        /// </summary>
        private protected string _secondCategory;

        /// <summary>
        /// The second value
        /// </summary>
        private protected string _secondValue;

        /// <summary>
        /// The third category
        /// </summary>
        private protected string _thirdCategory;

        /// <summary>
        /// The third value
        /// </summary>
        private protected string _thirdValue;

        /// <summary>
        /// The fourth category
        /// </summary>
        private protected string _fourthCategory;

        /// <summary>
        /// The fourth value
        /// </summary>
        private protected string _fourthValue;

        /// <summary>
        /// The SQL command
        /// </summary>
        private protected string _sqlQuery;

        /// <summary>
        /// The xaxis
        /// </summary>
        private protected string _xaxis;

        /// <summary>
        /// The yvalues
        /// </summary>
        private protected IList<string> _yvalues;

        /// <summary>
        /// The stat
        /// </summary>
        private protected STAT _metric;

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
        private protected IDictionary<string, object> _filter;

        /// <summary>
        /// The fields
        /// </summary>
        private protected IList<string> _fields;

        /// <summary>
        /// The columns
        /// </summary>
        private protected IList<string> _columns;

        /// <summary>
        /// The numerics
        /// </summary>
        private protected IList<string> _numerics;

        /// <summary>
        /// The selected columns
        /// </summary>
        private protected IList<string> _selectedColumns;

        /// <summary>
        /// The selected fields
        /// </summary>
        private protected IList<string> _selectedFields;

        /// <summary>
        /// The selected numerics
        /// </summary>
        private protected IList<string> _selectedNumerics;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The timer
        /// </summary>
        private protected TimerCallback _timerCallback;

        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

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
        /// The fore hover color
        /// </summary>
        private protected Color _foreHover = new Color( )
        {
            A = 255,
            R = 255,
            G = 255,
            B = 255
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
        /// The border hover color
        /// </summary>
        private protected Color _borderHover = new Color( )
        {
            A = 255,
            R = 106,
            G = 189,
            B = 252
        };

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
        /// <see cref="T:Badger.ChartWindow" /> class.
        /// </summary>
        public ChartWindow( )
            : base( )
        {
            // Theme Properties
            SfSkinManager.ApplyStylesOnApplication = true;
            SfSkinManager.SetTheme( this, new Theme( "FluentDark" ) );

            // Window Initialization
            InitializeComponent( );
            InitializeDelegates( );
            RegisterCallbacks( );

            // Window Properties
            Width = 1400;
            MinWidth = 1200;
            MaxWidth = 1500;
            Height = 800;
            MinHeight = 600;
            MaxHeight = 900;
            FontFamily = new FontFamily( "Segoe UI" );
            FontSize = 12d;
            Padding = new Thickness( 1 );
            BorderThickness = new Thickness( 1 );
            Margin = new Thickness( 3 );
            WindowStyle = WindowStyle.SingleBorderWindow;
            Title = "Chart Data";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Bottom;
            Background = new SolidColorBrush( _backColor );
            Foreground = new SolidColorBrush( _foreColor );
            BorderBrush = new SolidColorBrush( _borderColor );

            // Default Provider
            _provider = Provider.Access;
            _metric = STAT.Total;

            // Initialize Collections
            _filter = new Dictionary<string, object>( );
            _fields = new List<string>( );
            _columns = new List<string>( );
            _numerics = new List<string>( );
            _selectedColumns = new List<string>( );
            _selectedFields = new List<string>( );
            _selectedNumerics = new List<string>( );

            // Window Events
            Loaded += OnLoaded;
            Closing += OnClosing;
        }

        /// <summary>
        /// Initializes the callbacks.
        /// </summary>
        private void RegisterCallbacks( )
        {
            try
            {
                FirstButton.Click += OnFirstButtonClick;
                PreviousButton.Click += OnPreviousButtonClick;
                NextButton.Click += OnNextButtonClick;
                LastButton.Click += OnLastButtonClick;
                LookupButton.Click += OnLookupButtonClick;
                RefreshButton.Click += OnRefreshButtonClick;
                EditButton.Click += OnEditButtonClick;
                UndoButton.Click += OnUndoButtonClick;
                DeleteButton.Click += OnDeleteButtonClick;
                SaveButton.Click += OnSaveButtonClick;
                ExportButton.Click += OnExportButtonClick;
                BrowseButton.Click += OnBrowseButtonClick;
                MenuButton.Click += OnMenuButtonClick;
                ToggleButton.Click += OnToggleButtonClick;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the chart.
        /// </summary>
        private void InitializeChart( )
        {
            try
            {
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the labels.
        /// </summary>
        private void InitializeLabels( )
        {
            try
            {
                FieldsLabel.Foreground = new SolidColorBrush( _borderColor );
                NumericsLabel.Foreground = new SolidColorBrush( _borderColor );
                FirstDateLabel.Foreground = new SolidColorBrush( _borderColor );
                SecondDateLabel.Foreground = new SolidColorBrush( _borderColor );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the tab controls.
        /// </summary>
        private void InitializeTabControls( )
        {
            try
            {
                ColumnTab.IsSelected = true;
                SourceTab.IsSelected = true;
                SecondDateLabel.Visibility = Visibility.Hidden;
                SecondCalendar.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the toolbar.
        /// </summary>
        private void InitializeToolbar( )
        {
            try
            {
                FirstButton.Visibility = Visibility.Hidden;
                PreviousButton.Visibility = Visibility.Hidden;
                NextButton.Visibility = Visibility.Hidden;
                LastButton.Visibility = Visibility.Hidden;
                ToolStripTextBox.Visibility = Visibility.Hidden;
                LookupButton.Visibility = Visibility.Hidden;
                RefreshButton.Visibility = Visibility.Hidden;
                FilterButton.Visibility = Visibility.Hidden;
                EditButton.Visibility = Visibility.Hidden;
                SaveButton.Visibility = Visibility.Hidden;
                DeleteButton.Visibility = Visibility.Hidden;
                UndoButton.Visibility = Visibility.Hidden;
                ExportButton.Visibility = Visibility.Hidden;
                FirstButton.Visibility = Visibility.Hidden;
                BrowseButton.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private void Busy( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private void Chill( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Creates the SQL text.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>
        /// </returns>
        private string CreateSqlSelectQuery( IDictionary<string, object> where )
        {
            if( !string.IsNullOrEmpty( _selectedTable ) )
            {
                try
                {
                    ThrowIf.Null( where, nameof( where ) );
                    return $"SELECT * FROM {_selectedTable} "
                        + $"WHERE {where.ToCriteria( )};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Creates the SQL text.
        /// </summary>
        /// <param name="fields">The fields.</param>
        /// <param name="numerics">The numerics.</param>
        /// <param name="where">The where.</param>
        /// <returns>
        /// </returns>
        private string CreateSqlSelectQuery( IEnumerable<string> fields, IEnumerable<string> numerics,
            IDictionary<string, object> where )
        {
            if( !string.IsNullOrEmpty( _selectedTable ) )
            {
                try
                {
                    ThrowIf.Empty( where, nameof( where ) );
                    ThrowIf.Empty( fields, nameof( fields ) );
                    ThrowIf.Empty( numerics, nameof( numerics ) );
                    var _cols = string.Empty;
                    var _aggr = string.Empty;
                    foreach( var name in fields )
                    {
                        _cols += $"{name}, ";
                    }

                    foreach( var metric in numerics )
                    {
                        _aggr += $"SUM({metric}) AS {metric}, ";
                    }

                    var _groups = _cols.TrimEnd( ", ".ToCharArray( ) );
                    var _criteria = where.ToCriteria( );
                    var _values = _cols + _aggr.TrimEnd( ", ".ToCharArray( ) );
                    return $"SELECT {_values} FROM {_selectedTable} "
                        + $"WHERE {_criteria} "
                        + $"GROUP BY {_groups};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Creates the SQL text.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="where">The where.</param>
        /// <returns>
        /// </returns>
        private string CreateSqlSelectQuery( IEnumerable<string> columns,
            IDictionary<string, object> where )
        {
            if( !string.IsNullOrEmpty( _selectedTable ) )
            {
                try
                {
                    ThrowIf.Empty( where, nameof( where ) );
                    ThrowIf.Empty( columns, nameof( columns ) );
                    var _cols = string.Empty;
                    foreach( var name in columns )
                    {
                        _cols += $"{name}, ";
                    }

                    var _criteria = where.ToCriteria( );
                    var _names = _cols.TrimEnd( ", ".ToCharArray( ) );
                    return $"SELECT {_names} FROM {_selectedTable} "
                        + $"WHERE {_criteria} "
                        + $"GROUP BY {_names};";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Creates the excel report.
        /// </summary>
        private void CreateExcelReport( )
        {
            try
            {
                if( _dataTable == null )
                {
                    var _message = "    The Data Table is null!";
                    SendMessage( _message );
                }
                else if( _dataModel.Numerics == null )
                {
                    var _message = "    The data is not alpha-numeric";
                    SendMessage( _message );
                }
                else
                {
                    var _report = new ExcelReport( _dataTable );
                    _report.SaveDialog( );
                    var _message = "    The Excel File has been created!";
                    SendNotification( _message );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Creates the notifier.
        /// </summary>
        /// <returns></returns>
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
            catch( Exception _ex )
            {
                Fail( _ex );
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
                var _notify = new Notification( message )
                {
                    Owner = this
                };

                _notify.Show( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Shows the items.
        /// </summary>
        private void ShowToolbar( )
        {
            try
            {
                FirstButton.Visibility = Visibility.Visible;
                PreviousButton.Visibility = Visibility.Visible;
                NextButton.Visibility = Visibility.Visible;
                LastButton.Visibility = Visibility.Visible;
                ToolStripTextBox.Visibility = Visibility.Visible;
                LookupButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
                FilterButton.Visibility = Visibility.Visible;
                RefreshButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
                SaveButton.Visibility = Visibility.Visible;
                UndoButton.Visibility = Visibility.Visible;
                ExportButton.Visibility = Visibility.Visible;
                BrowseButton.Visibility = Visibility.Visible;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Hides the items.
        /// </summary>
        private void HideToolbar( )
        {
            try
            {
                FirstButton.Visibility = Visibility.Hidden;
                PreviousButton.Visibility = Visibility.Hidden;
                NextButton.Visibility = Visibility.Hidden;
                LastButton.Visibility = Visibility.Hidden;
                ToolStripTextBox.Visibility = Visibility.Hidden;
                LookupButton.Visibility = Visibility.Hidden;
                EditButton.Visibility = Visibility.Hidden;
                FilterButton.Visibility = Visibility.Hidden;
                RefreshButton.Visibility = Visibility.Hidden;
                DeleteButton.Visibility = Visibility.Hidden;
                SaveButton.Visibility = Visibility.Hidden;
                UndoButton.Visibility = Visibility.Hidden;
                ExportButton.Visibility = Visibility.Hidden;
                BrowseButton.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the main form.
        /// </summary>
        private void OpenMainWindow( )
        {
            try
            {
                var _form = (MainWindow)App.ActiveWindows[ "MainWindow" ];
                _form.Show( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Populates the first ComboBox items.
        /// </summary>
        public void PopulateFirstComboBoxItems( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    if( FirstCategoryComboBox.Items?.Count > 0 )
                    {
                        FirstCategoryComboBox.Items.Clear( );
                    }

                    if( FirstCategoryListBox.Items?.Count > 0 )
                    {
                        FirstCategoryListBox.Items?.Clear( );
                    }

                    foreach( var _item in _fields )
                    {
                        FirstCategoryComboBox.Items?.Add( _item );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Populates the second ComboBox items.
        /// </summary>
        public void PopulateSecondComboBoxItems( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    if( SecondCategoryComboBox.Items?.Count > 0 )
                    {
                        SecondCategoryComboBox.Items.Clear( );
                    }

                    if( SecondCategoryListBox.Items?.Count > 0 )
                    {
                        SecondCategoryListBox.Items?.Clear( );
                    }

                    if( !string.IsNullOrEmpty( _firstValue ) )
                    {
                        foreach( var item in _fields )
                        {
                            if( !item.Equals( _firstCategory ) )
                            {
                                SecondCategoryComboBox.Items?.Add( item );
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Populates the execution tables.
        /// </summary>
        private void PopulateExecutionTables( )
        {
            try
            {
                DataTableListBox.Items?.Clear( );
                var _model = new DataGenerator( Source.ApplicationTables, _provider );
                var _data = _model.GetData( );
                var _names = _data
                    ?.Where( r => r.Field<string>( "Model" ).Equals( "EXECUTION" ) )
                    ?.OrderBy( r => r.Field<string>( "Title" ) )
                    ?.Select( r => r.Field<string>( "Title" ) )
                    ?.ToList( );

                if( _names?.Any( ) == true )
                {
                    foreach( var _name in _names )
                    {
                        DataTableListBox.Items?.Add( _name );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the field ListBox.
        /// </summary>
        private void PopulateFieldListBox( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    if( FieldListBox.Items.Count > 0 )
                    {
                        FieldListBox.Items.Clear( );
                    }

                    foreach( var _item in _fields )
                    {
                        FieldListBox.Items.Add( _item );
                    }

                    FieldListBox.SelectionMode = SelectionMode.Multiple;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Populates the numeric ListBox.
        /// </summary>
        private void PopulateNumericListBox( )
        {
            if( _numerics?.Any( ) == true )
            {
                try
                {
                    if( NumericListBox.Items.Count > 0 )
                    {
                        NumericListBox.Items.Clear( );
                    }

                    for( var i = 0; i < _numerics.Count; i++ )
                    {
                        if( !string.IsNullOrEmpty( _numerics[ i ] ) )
                        {
                            NumericListBox.Items.Add( _numerics[ i ] );
                        }
                    }

                    NumericListBox.SelectionMode = SelectionMode.Multiple;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Activates the busy tab.
        /// </summary>
        private void ActivateColumnTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 0;
                ColumnTab.IsSelected = true;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                HeatTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        private void ActivatePieTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 1;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                HeatTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        private void ActivateSunTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 2;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                HeatTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        private void ActivateSmithTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 3;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                HeatTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        private void ActivateHeatTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 4;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                HeatTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Activates the busy tab.
        /// </summary>
        private void ActivateBusyTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 5;
                BusyTab.Visibility = Visibility.Visible;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                HeatTab.Visibility = Visibility.Hidden;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Activates the SQL tab.
        /// </summary>
        private void ActivateSourceTab( )
        {
            try
            {
                ClearListBoxes( );
                ClearComboBoxes( );
                SecondaryTabControl.SelectedIndex = 0;
                SourceTab.IsSelected = true;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                GroupTab.Visibility = Visibility.Hidden;
                PopulateExecutionTables( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Activates the lookup tab.
        /// </summary>
        private void ActivateFilterTab( )
        {
            try
            {
                ClearFilter( );
                ClearListBoxes( );
                ClearComboBoxes( );
                SecondaryTabControl.SelectedIndex = 1;
                FilterTab.IsSelected = true;
                FilterTab.Visibility = Visibility.Hidden;
                GroupTab.Visibility = Visibility.Hidden;
                PopulateFirstComboBoxItems( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Activates the schema tab.
        /// </summary>
        private void ActivateGroupTab( )
        {
            try
            {
                ClearCollections( );
                ClearListBoxes( );
                ClearComboBoxes( );
                SecondaryTabControl.SelectedIndex = 2;
                SourceTab.IsSelected = true;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                GroupTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                PopulateFieldListBox( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Clears the combo boxes.
        /// </summary>
        private void ClearComboBoxes( )
        {
            try
            {
                FirstCategoryComboBox.Items.Clear( );
                SecondCategoryComboBox.Items.Clear( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the list boxes.
        /// </summary>
        private void ClearListBoxes( )
        {
            try
            {
                FirstCategoryListBox.Items.Clear( );
                SecondCategoryListBox.Items.Clear( );
                FieldListBox.Items.Clear( );
                NumericListBox.Items.Clear( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the data.
        /// </summary>
        public void ClearData( )
        {
            try
            {
                ClearSelections( );
                ClearCollections( );
                ClearFilter( );
                _selectedTable = string.Empty;
                _dataModel = null;
                _dataTable = null;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Clears the filter.
        /// </summary>
        private void ClearFilter( )
        {
            try
            {
                if( _filter?.Any( ) == true )
                {
                    _filter.Clear( );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Clears the collections.
        /// </summary>
        private void ClearCollections( )
        {
            try
            {
                if( _selectedColumns?.Any( ) == true )
                {
                    _selectedColumns.Clear( );
                }

                if( _selectedFields?.Any( ) == true )
                {
                    _selectedFields.Clear( );
                }

                if( _selectedNumerics?.Any( ) == true )
                {
                    _selectedNumerics.Clear( );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Clears the selections.
        /// </summary>
        private void ClearSelections( )
        {
            try
            {
                _thirdCategory = string.Empty;
                _thirdValue = string.Empty;
                _secondCategory = string.Empty;
                _secondValue = string.Empty;
                _firstCategory = string.Empty;
                _firstValue = string.Empty;
                _selectedTable = string.Empty;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Clears the label text.
        /// </summary>
        private void ClearLabels( )
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
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( )
        {
            try
            {
                StatusLabel.Content = DateTime.Now.ToLongTimeString( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Sets the active data tab.
        /// </summary>
        private void SetPrimaryTabControl( )
        {
            try
            {
                switch( PrimaryTabControl.SelectedIndex )
                {
                    case 0:
                    {
                        ActivateColumnTab( );
                        break;
                    }
                    case 1:
                    {
                        ActivatePieTab( );
                        break;
                    }
                    case 3:
                    {
                        ActivateSunTab( );
                        break;
                    }
                    case 4:
                    {
                        ActivateSmithTab( );
                        break;
                    }
                    case 5:
                    {
                        ActivateHeatTab( );
                        break;
                    }
                    case 6:
                    {
                        ActivateBusyTab( );
                        break;
                    }
                    default:
                    {
                        ActivateColumnTab( );
                        break;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Sets the active tab.
        /// </summary>
        private void SetSecondaryTabControl( )
        {
            try
            {
                switch( SecondaryTabControl.SelectedIndex )
                {
                    case 0:
                    {
                        ActivateSourceTab( );
                        break;
                    }
                    case 1:
                    {
                        ActivateFilterTab( );
                        break;
                    }
                    case 2:
                    {
                        ActivateGroupTab( );
                        break;
                    }
                    default:
                    {
                        ActivateSourceTab( );
                        break;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnLoaded( object sender, EventArgs e )
        {
            try
            {
                InitializeTimer( );
                InitializeTabControls( );
                InitializeLabels( );
                InitializeToolbar( );
                PopulateExecutionTables( );
                Opacity = 0;
                FadeInAsync( this );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [first button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFirstButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [previous button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnPreviousButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [next button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnNextButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [last button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnLastButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [browse button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnBrowseButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _fileBrowser = new FileBrowser( );
                _fileBrowser.ShowDialog( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [edit button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnEditButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [refresh button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnRefreshButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [filter button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFilterButtonClick( object sender, EventArgs e )
        {
            try
            {
                //FilterTab.IsSelected = true;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [lookup button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnLookupButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [undo button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnUndoButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [delete button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnDeleteButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [export button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnExportButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [save button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnSaveButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [menu button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnMenuButtonClick( object sender, EventArgs e )
        {
            try
            {
                Close( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        private void OnClosing( object sender, EventArgs e )
        {
            try
            {
                if( App.ActiveWindows.ContainsKey( "MainWindow" ) )
                {
                    OpenMainWindow( );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [calculator menu option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnCalculatorMenuOptionClick( object sender, EventArgs e )
        {
            try
            {
                var _calculator = new CalculatorWindow( );
                _calculator.ShowDialog( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [file menu option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFileMenuOptionClick( object sender, EventArgs e )
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
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [folder menu option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFolderMenuOptionClick( object sender, EventArgs e )
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
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [control panel option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnControlPanelOptionClick( object sender, EventArgs e )
        {
            try
            {
                WinMinion.LaunchControlPanel( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [task manager option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnTaskManagerOptionClick( object sender, EventArgs e )
        {
            try
            {
                WinMinion.LaunchTaskManager( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [close option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnCloseOptionClick( object sender, EventArgs e )
        {
            try
            {
                Application.Current.Shutdown( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [chrome option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// containing the event data.</param>
        private void OnChromeOptionClick( object sender, EventArgs e )
        {
            try
            {
                WebMinion.RunChrome( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [edge option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnEdgeOptionClick( object sender, EventArgs e )
        {
            try
            {
                WebMinion.RunEdge( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [firefox option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// containing the event data.</param>
        private void OnFirefoxOptionClick( object sender, EventArgs e )
        {
            try
            {
                WebMinion.RunFirefox( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [toggle button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnToggleButtonClick( object sender, EventArgs e )
        {
            try
            {
                if( !FirstButton.IsVisible )
                {
                    ShowToolbar( );
                }
                else
                {
                    HideToolbar( );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [active tab changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnPrimaryActiveTabChanged( object sender, EventArgs e )
        {
            try
            {
                SetPrimaryTabControl( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [active tab changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnSecondaryActiveTabChanged( object sender, EventArgs e )
        {
            try
            {
                SetSecondaryTabControl( );
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
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnRadioButtonSelected( object sender, EventArgs e )
        {
            try
            {
                var _button = sender as MetroRadioButton;
                var _type = _button?.Tag.ToString( );
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