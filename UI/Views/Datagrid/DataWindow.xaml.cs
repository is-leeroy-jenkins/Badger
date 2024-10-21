// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-02-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-02-2024
// ******************************************************************************************
// <copyright file="DataWindow.xaml.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts
//    based on WPF, NET6.0, and written in C-Sharp.
// 
//    Copyright ©  2024  Terry D. Eppler
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   DataWindow.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using Syncfusion.SfSkinManager;
    using Syncfusion.UI.Xaml.Grid;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Messages;
    using ToastNotifications.Position;
    using DataRow = System.Data.DataRow;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "UseCollectionExpression" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "LoopCanBePartlyConvertedToQuery" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "LocalVariableHidesMember" ) ]
    public partial class DataWindow : Window, IDisposable
    {
        /// <summary>
        /// The yvalues
        /// </summary>
        private IList<string> _columns;

        /// <summary>
        /// The commands
        /// </summary>
        private IList<string> _commands;

        /// <summary>
        /// The data types
        /// </summary>
        private IList<string> _dataTypes;

        /// <summary>
        /// The numerics
        /// </summary>
        private IList<string> _dates;

        /// <summary>
        /// The fields
        /// </summary>
        private IList<string> _fields;

        /// <summary>
        /// The filter
        /// </summary>
        private IDictionary<string, object> _filter;

        /// <summary>
        /// The first category
        /// </summary>
        private string _firstCategory;

        /// <summary>
        /// The first value
        /// </summary>
        private string _firstValue;

        /// <summary>
        /// The numerics
        /// </summary>
        private IList<string> _numerics;

        /// <summary>
        /// The second category
        /// </summary>
        private string _secondCategory;

        /// <summary>
        /// The second value
        /// </summary>
        private string _secondValue;

        /// <summary>
        /// The selected columns
        /// </summary>
        private protected IList<string> _selectedColumns;

        /// <summary>
        /// The SQL command
        /// </summary>
        protected string _selectedCommand;

        /// <summary>
        /// The selected fields
        /// 
        /// </summary>
        private protected IList<string> _selectedFields;

        /// <summary>
        /// The selected numerics
        /// </summary>
        private protected IList<string> _selectedNumerics;

        /// <summary>
        /// The selected command
        /// </summary>
        private protected string _selectedQuery;

        /// <summary>
        /// The selected table
        /// </summary>
        private protected string _selectedTable;

        /// <summary>
        /// The SQL command
        /// </summary>
        private protected string _sqlQuery;

        /// <summary>
        /// The statements
        /// </summary>
        private protected IDictionary<string, object> _statements;

        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The current
        /// </summary>
        private protected DataRow _current;

        /// <summary>
        /// The data model
        /// </summary>
        private protected DataGenerator _data;

        /// <summary>
        /// The binding source
        /// </summary>
        private protected ObservableCollection<DataRow> _dataSource;

        /// <summary>
        /// The data table
        /// </summary>
        private protected DataTable _dataTable;

        /// <summary>
        /// The frames
        /// </summary>
        private protected IList<MetroTextInput> _frames;

        /// <summary>
        /// The path
        /// </summary>
        private protected object _entry = new object( );

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The seconds
        /// </summary>
        private protected int _seconds;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

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
        /// The column picker
        /// </summary>
        private protected ColumnChooser _columnPicker;

        /// <summary>
        /// Gets the column picker.
        /// </summary>
        /// <value>
        /// The column picker.
        /// </value>
        public ColumnChooser ColumnPicker
        {
            get
            {
                return _columnPicker;
            }
            private protected set
            {
                _columnPicker = value;
            }
        }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public IDictionary<string, object> Filter
        {
            get
            {
                return _filter;
            }
            private set
            {
                _filter = value;
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
                lock( _entry )
                {
                    return _busy;
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DataWindow" /> class.
        /// </summary>
        public DataWindow( )
            : base( )
        {
            // Theme Properties
            SfSkinManager.SetTheme( this, new Theme( "FluentDark", App.Controls ) );

            // Window Initialization
            InitializeComponent( );
            InitializeDelegates( );
            RegisterCallbacks( );

            // Window Properties
            Title = "Data Management";

            // Initialize Default Provider
            _provider = Provider.Access;

            // Initialize Collections
            _filter = new Dictionary<string, object>( );
            _frames = new List<MetroTextInput>( );
            _columns = new List<string>( );
            _fields = new List<string>( );
            _numerics = new List<string>( );
            _dates = new List<string>( );
            _commands = new List<string>( );
            _dataTypes = new List<string>( );

            // Window Events
            Loaded += OnLoaded;
            Closing += OnClosing;
        }

        /// <summary>
        /// Invokes if needed.
        /// </summary>
        /// <param name="action">The action.</param>
        public void InvokeIf( Action action )
        {
            try
            {
                ThrowIf.Null( action, nameof( action ) );
                if( Dispatcher.CheckAccess( ) )
                {
                    action?.Invoke( );
                }
                else
                {
                    Dispatcher.BeginInvoke( action );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Invokes if.
        /// </summary>
        /// <param name="action">The action.</param>
        public void InvokeIf( Action<object> action )
        {
            try
            {
                ThrowIf.Null( action, nameof( action ) );
                if( Dispatcher.CheckAccess( ) )
                {
                    action?.Invoke( null );
                }
                else
                {
                    Dispatcher.BeginInvoke( action );
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
                FilterButton.Click += OnFilterButtonClick;
                SqlButton.Click += OnSqlButtonClick;
                GridButton.Click += OnGridButtonClick;
                DataSourceButton.Click += OnDataSourceButtonClick;
                CalendarButton.Click += OnCalendarButtonClick;
                DeleteButton.Click += OnDeleteButtonClick;
                SaveButton.Click += OnSaveButtonClick;
                ExportButton.Click += OnExportButtonClick;
                BrowseButton.Click += OnBrowseButtonClick;
                MenuButton.Click += OnMenuButtonClick;
                ToggleButton.Click += OnToggleButtonClick;
                DataSourceListBox.SelectionChanged += OnTableListBoxItemSelected;
                CommandComboBox.SelectionChanged += OnCommandComboBoxItemSelected;
                CommandListBox.SelectionChanged += OnCommandListBoxItemSelected;
                FirstComboBox.SelectionChanged += OnFirstComboBoxItemSelected;
                FirstListBox.SelectionChanged += OnFirstListBoxItemSelected;
                SecondComboBox.SelectionChanged += OnSecondComboBoxItemSelected;
                SecondListBox.SelectionChanged += OnSecondListBoxItemSelected;
                TableComboBox.SelectionChanged += OnTableComboBoxItemSelected;
                DataGrid.MouseLeftButtonDown += OnDataGridSelectedIndexChanged;
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
                StatusLabel.FontSize = 12;
                SchemaHeader.Foreground = _theme.Foreground;
                SchemaHeader.Visibility = Visibility.Hidden;
                DataColumnLabel.Foreground = _theme.Foreground;
                DataTypeLabel.Foreground = _theme.Foreground;
                ColumnNameLabel.Foreground = _theme.Foreground;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the radio buttons.
        /// </summary>
        private void InitializeRadioButtons( )
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
                FirstComboBox.Background = _theme.Background;
                SecondComboBox.Background = _theme.Background;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the tab controls.
        /// </summary>
        private void InitializeTabControls( )
        {
            try
            {
                DataTab.IsSelected = true;
                DataTab.Visibility = Visibility.Hidden;
                SourceTab.IsSelected = true;
                SourceTab.Visibility = Visibility.Hidden;
                EditTab.Visibility = Visibility.Hidden;
                SchemaTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                CommandTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
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
                ExportButton.Visibility = Visibility.Hidden;
                FirstButton.Visibility = Visibility.Hidden;
                BrowseButton.Visibility = Visibility.Hidden;
                GridButton.Visibility = Visibility.Hidden;
                CalendarButton.Visibility = Visibility.Hidden;
                DataSourceButton.Visibility = Visibility.Hidden;
                SqlButton.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the tab visiblity.
        /// </summary>
        private void InitializeTabVisiblity( )
        {
            try
            {
                DataTab.Visibility = Visibility.Visible;
                EditTab.Visibility = Visibility.Hidden;
                SchemaTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                SourceTab.Visibility = Visibility.Visible;
                FilterTab.Visibility = Visibility.Hidden;
                CommandTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
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
        /// Creates the SQL text.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        private string CreateSelectQuery( IDictionary<string, object> where )
        {
            try
            {
                ThrowIf.Null( where, nameof( where ) );
                return $"SELECT * FROM {_source} "
                    + $"WHERE {where.ToCriteria( )};";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Creates the SQL text.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        private string CreateSelectQuery( IEnumerable<string> columns,
            IDictionary<string, object> where )
        {
            if( !string.IsNullOrEmpty( _dataTable.TableName ) )
            {
                try
                {
                    ThrowIf.Null( where, nameof( where ) );
                    ThrowIf.Empty( columns, nameof( columns ) );
                    var _cols = string.Empty;
                    foreach( var _name in columns )
                    {
                        _cols += $"{_name}, ";
                    }

                    var _criteria = where.ToCriteria( );
                    var _names = _cols.TrimEnd( ", ".ToCharArray( ) );
                    return $"SELECT {_names}"
                        + $"FROM {_dataTable} "
                        + $"WHERE {_criteria} "
                        + $"GROUP BY {_names} ;";
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
        /// <returns></returns>
        private string CreateSelectQuery( IEnumerable<string> fields,
            IEnumerable<string> numerics, IDictionary<string, object> where )
        {
            try
            {
                ThrowIf.Null( where, nameof( where ) );
                ThrowIf.Empty( fields, nameof( fields ) );
                ThrowIf.Empty( numerics, nameof( numerics ) );
                var _cols = string.Empty;
                var _aggr = string.Empty;
                foreach( var _name in fields )
                {
                    _cols += $"{_name}, ";
                }

                foreach( var _metric in numerics )
                {
                    _aggr += $"SUM({_metric}) AS {_metric}, ";
                }

                var _groups = _cols.TrimEnd( ", ".ToCharArray( ) );
                var _criteria = where.ToCriteria( );
                var _names = _cols + _aggr.TrimEnd( ", ".ToCharArray( ) );
                return $"SELECT {_names} "
                    + "FROM {Source} "
                    + $"WHERE {_criteria} "
                    + $"GROUP BY {_groups};";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
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
                else if( _data.Numerics == null )
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
            catch( Exception ex )
            {
                Fail( ex );
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

                return new Notifier( _config =>
                {
                    _config.LifetimeSupervisor = _lifeTime;
                    _config.PositionProvider = _position;
                    _config.Dispatcher = Application.Current.Dispatcher;
                } );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Notifier );
            }
        }

        /// <summary>
        /// Creates the command list.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns> </returns>
        private IList<string> CreateCommandList( Provider provider )
        {
            try
            {
                var _prefix = ConfigurationManager.AppSettings[ "PathPrefix" ];
                var _dbpath = ConfigurationManager.AppSettings[ "DatabaseDirectory" ];
                var _filePath = _prefix + _dbpath + @$"\{provider}\DataModels\";
                var _names = Directory.GetDirectories( _filePath );
                var _list = new List<string>( );
                for( var _i = 0; _i < _names.Length; _i++ )
                {
                    var _folder = Directory.CreateDirectory( _names[ _i ] ).Name;
                    if( !string.IsNullOrEmpty( _folder ) )
                    {
                        _list.Add( _folder );
                    }
                }

                return _list?.Count > 0
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
        /// Creates the query list.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// </returns>
        private IList<string> CreateQueryList( Provider provider )
        {
            try
            {
                if( Enum.IsDefined( typeof( Provider ), provider ) )
                {
                    var _prefix = ConfigurationManager.AppSettings[ "PathPrefix" ];
                    var _dbpath = ConfigurationManager.AppSettings[ "DatabaseDirectory" ];
                    var _filePath = _prefix + _dbpath + @$"\{provider}\DataModels\";
                    var _names = Directory.GetDirectories( _filePath );
                    var _list = new List<string>( );
                    for( var _i = 0; _i < _names.Length; _i++ )
                    {
                        var _folder = Directory.CreateDirectory( _names[ _i ] ).Name;
                        if( !string.IsNullOrEmpty( _folder ) )
                        {
                            _list.Add( _folder );
                        }
                    }

                    return _list?.Count > 0
                        ? _list
                        : default( IList<string> );
                }

                return default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Populates the edit stack.
        /// </summary>
        private protected IList<MetroTextInput> CreateFrames( )
        {
            try
            {
                var _list = new List<MetroTextInput>( );
                for( var _index = 0; _index < _dataTable.Columns.Count; _index++ )
                {
                    var _column = _dataTable.Columns[ _index ].ColumnName;
                    var _name = _column?.SplitPascal( );
                    var _frame = new MetroTextInput
                    {
                        Ordinal = _dataTable.Columns[ _index ].Ordinal,
                        Caption = _name,
                        Input = _current.ItemArray[ _index ]?.ToString( )
                    };

                    _list.Add( _frame );
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<MetroTextInput> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<MetroTextInput> );
            }
        }

        /// <summary>
        /// Populates the data type ComboBox items.
        /// </summary>
        private protected void PopulateDataTypeListBoxItems( IEnumerable<string> dataTypes )
        {
            try
            {
                ThrowIf.Null( dataTypes, nameof( dataTypes ) );
                DataTypeListBox.Items?.Clear( );
                var _types = dataTypes.ToArray( );
                for( var _i = 0; _i < _types?.Length; _i++ )
                {
                    if( !string.IsNullOrEmpty( _types[ _i ] ) )
                    {
                        var _item = new MetroListBoxItem
                        {
                            Content = _types[ _i ]
                        };

                        DataTypeListBox.Items.Add( _item );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the data column ListBox.
        /// </summary>
        private protected void PopulateDataColumnListBox( )
        {
            try
            {
                DataColumnListBox.Items?.Clear( );
                for( var _i = 0; _i < _columns?.Count; _i++ )
                {
                    if( !string.IsNullOrEmpty( _columns[ _i ] ) )
                    {
                        var _item = new MetroListBoxItem
                        {
                            Content = _columns[ _i ]
                        };

                        DataColumnListBox.Items.Add( _item );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the data types.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// IEnumerable
        /// </returns>
        private protected IList<string> GetDataTypes( Provider provider )
        {
            if( Enum.IsDefined( typeof( Provider ), provider ) )
            {
                try
                {
                    var _database = provider.ToString( );
                    var _db = new DataGenerator( Source.SchemaTypes, Provider.Access );
                    var _data = _db.DataTable;
                    var _list = _data.AsEnumerable( )
                        ?.Where( c => c.Field<string>( "Database" ).Equals( _database ) )
                        ?.Select( c => c.Field<string>( "TypeName" ) )
                        ?.ToList( );

                    return _list.Count > 0
                        ? _list
                        : default( IList<string> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IList<string> );
                }
            }

            return default( IList<string> );
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
        /// Moves to first.
        /// </summary>
        private protected void MoveToFirst( )
        {
            try
            {
                if( _dataTable == null )
                {
                    var _message = "Verify Data Table!";
                    SendMessage( _message );
                    return;
                }
                
                DataGrid.SelectedIndex = 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Moves to previous.
        /// </summary>
        private protected void MoveToPrevious( )
        {
            try
            {
                if( _dataTable == null )
                {
                    var _message = "Verify Data Table!";
                    SendMessage( _message );
                    return;
                }
                
                DataGrid.SelectedIndex -= 1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Moves to next.
        /// </summary>
        private protected void MoveToNext( )
        {
            try
            {
                if( _dataTable == null )
                {
                    var _message = "Verify Data Table!";
                    SendMessage( _message );
                    return;
                }

                DataGrid.SelectedIndex += 1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Moves to last.
        /// </summary>
        private protected void MoveToLast( )
        {
            try
            {
                if( _dataTable == null )
                {
                    var _message = "Verify Data Table!";
                    SendMessage( _message );
                    return;
                }

                DataGrid.SelectedIndex = ( _dataTable.Rows.Count ) - 1;
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
                var _message = new SplashMessage( message )
                {
                    Owner = this
                };

                _message.Show( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the reference tables.
        /// </summary>
        private void PopulateReferenceTables( )
        {
            try
            {
                DataSourceListBox.Items?.Clear( );
                var _model = new DataGenerator( Source.ApplicationTables, _provider );
                var _data = _model.GetData( );
                var _names = _data
                    ?.Where( r => r.Field<string>( "Model" ).Equals( "REFERENCE" ) )
                    ?.OrderBy( r => r.Field<string>( "Title" ) )
                    ?.Select( r => r.Field<string>( "Title" ) )
                    ?.ToList( );

                if( _names?.Any( ) == true )
                {
                    foreach( var _name in _names )
                    {
                        var _item = new MetroListBoxItem
                        {
                            Content = _name,
                            ToolTip = _name
                        };

                        DataSourceListBox.Items?.Add( _item );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the maintenance tables.
        /// </summary>
        private void PopulateMaintenanceTables( )
        {
            try
            {
                DataSourceListBox.Items?.Clear( );
                var _model = new DataGenerator( Source.ApplicationTables, _provider );
                var _data = _model.GetData( );
                var _names = _data
                    ?.Where( r => r.Field<string>( "Model" ).Equals( "MAINTENANCE" ) )
                    ?.OrderBy( r => r.Field<string>( "Title" ) )
                    ?.Select( r => r.Field<string>( "Title" ) )
                    ?.ToList( );

                if( _names?.Any( ) == true )
                {
                    foreach( var _name in _names )
                    {
                        var _item = new MetroListBoxItem
                        {
                            Content = _name,
                            ToolTip = _name
                        };

                        DataSourceListBox.Items?.Add( _item );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the execution tables.
        /// </summary>
        private void PopulateExecutionTables( )
        {
            try
            {
                DataSourceListBox.Items?.Clear( );
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
                        var _item = new MetroListBoxItem
                        {
                            Content = _name,
                            ToolTip = _name
                        };

                        DataSourceListBox.Items?.Add( _item );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the first ComboBox items.
        /// </summary>
        private void PopulateFirstComboBoxItems( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    if( FirstComboBox.Items?.Count > 0 )
                    {
                        FirstComboBox.Items?.Clear( );
                    }

                    if( FirstListBox.Items?.Count > 0 )
                    {
                        FirstListBox.Items?.Clear( );
                    }

                    foreach( var _item in _fields )
                    {
                        FirstComboBox.Items?.Add( _item );
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
        private void PopulateSecondComboBoxItems( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    if( SecondComboBox.Items?.Count > 0 )
                    {
                        SecondComboBox.Items?.Clear( );
                    }

                    if( SecondListBox.Items?.Count > 0 )
                    {
                        SecondListBox.Items?.Clear( );
                    }

                    if( !string.IsNullOrEmpty( _firstValue ) )
                    {
                        for( var _index = 0; _index < _fields.Count; _index++ )
                        {
                            var _item = _fields[ _index ];
                            if( !_item.Equals( _firstCategory ) )
                            {
                                SecondComboBox.Items?.Add( _item );
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
        /// Populates the field ListBox.
        /// </summary>
        private void PopulateCommandComboBox( IList<string> list )
        {
            try
            {
                ThrowIf.Null( list, nameof( list ) );
                var _sql = Enum.GetNames( typeof( Command ) );
                CommandComboBox.Items?.Clear( );
                CommandListBox.Items?.Clear( );
                for( var _i = 0; _i < list.Count; _i++ )
                {
                    if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.CREATEDATABASE}" ) )
                    {
                        CommandComboBox.Items.Add( "CREATE DATABASE" );
                    }
                    else if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.CREATETABLE}" ) )
                    {
                        CommandComboBox.Items.Add( "CREATE TABLE" );
                    }
                    else if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.ALTERTABLE}" ) )
                    {
                        CommandComboBox.Items.Add( "ALTER TABLE" );
                    }
                    else if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.CREATEVIEW}" ) )
                    {
                        CommandComboBox.Items.Add( "CREATE VIEW" );
                    }
                    else if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.SELECTALL}" ) )
                    {
                        CommandComboBox.Items.Add( "SELECT ALL" );
                    }
                    else if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.DELETE}" ) )
                    {
                        CommandComboBox.Items.Add( "DELETE" );
                    }
                    else if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.INSERT}" ) )
                    {
                        CommandComboBox.Items.Add( "INSERT" );
                    }
                    else if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.UPDATE}" ) )
                    {
                        CommandComboBox.Items.Add( "UPDATE" );
                    }
                    else if( _sql.Contains( list[ _i ] )
                        && list[ _i ].Equals( $"{Command.SELECT}" ) )
                    {
                        CommandComboBox.Items.Add( "SELECT" );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the busy tab.
        /// </summary>
        private void ActivateDataTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 0;
                SecondaryTabControl.SelectedIndex = 1;
                DataTab.IsSelected = true;
                SourceTab.IsSelected = true;
                HideTabs( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the busy tab.
        /// </summary>
        private void ActivateEditTab( )
        {
            try
            {
                if( _current == null )
                {
                    var _message = "Select a data row!";
                    SendMessage( _message );
                }
                else
                {
                    EditTab.IsSelected = true;
                    FilterTab.IsSelected = true;
                    HideTabs( );
                    _frames = CreateFrames( );
                    foreach( var _frame in _frames )
                    {
                        EditPanel.Children.Add( _frame );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the busy tab.
        /// </summary>
        private void ActivateSchemaTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 2;
                SecondaryTabControl.SelectedIndex = 0;
                SchemaTab.IsSelected = true;
                SourceTab.IsSelected = true;
                DataTab.Visibility = Visibility.Hidden;
                EditTab.Visibility = Visibility.Hidden;
                SchemaTab.Visibility = Visibility.Hidden;
                SqlTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                CommandTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
                _dataTypes = GetDataTypes( _provider );
                PopulateDataTypeListBoxItems( _dataTypes );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the busy tab.
        /// </summary>
        private void ActivateBusyTab( )
        {
            try
            {
                PrimaryTabControl.SelectedIndex = 2;
                SecondaryTabControl.SelectedIndex = 1;
                BusyTab.IsSelected = true;
                FilterTab.IsSelected = true;
                DataTab.Visibility = Visibility.Hidden;
                EditTab.Visibility = Visibility.Hidden;
                SchemaTab.Visibility = Visibility.Hidden;
                SqlTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                CommandTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the SQL tab.
        /// </summary>
        private void ActivateSourceTab( )
        {
            try
            {
                ClearFilters( );
                ClearListBoxes( );
                ClearComboBoxes( );
                DataTab.IsSelected = true;
                SourceTab.IsSelected = true;
                DataTab.Visibility = Visibility.Hidden;
                EditTab.Visibility = Visibility.Hidden;
                SchemaTab.Visibility = Visibility.Hidden;
                SqlTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                SourceTab.Visibility = Visibility.Visible;
                FilterTab.Visibility = Visibility.Hidden;
                CommandTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the lookup tab.
        /// </summary>
        private void ActivateFilterTab( )
        {
            try
            {
                if( _dataTable == null )
                {
                    var _message = "Verify Data Source!";
                    SendNotification( _message );
                }
                else
                {
                    DataTab.IsSelected = true;
                    FilterTab.IsSelected = true;
                    DataTab.Visibility = Visibility.Hidden;
                    SchemaTab.Visibility = Visibility.Hidden;
                    SqlTab.Visibility = Visibility.Hidden;
                    BusyTab.Visibility = Visibility.Hidden;
                    SourceTab.Visibility = Visibility.Hidden;
                    FilterTab.Visibility = Visibility.Hidden;
                    CommandTab.Visibility = Visibility.Hidden;
                    CalendarTab.Visibility = Visibility.Hidden;
                    PopulateFirstComboBoxItems( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the command tab.
        /// </summary>
        private void ActivateCommandTab( )
        {
            try
            {
                CommandTab.IsSelected = true;
                DataTab.Visibility = Visibility.Hidden;
                EditTab.Visibility = Visibility.Hidden;
                SchemaTab.Visibility = Visibility.Hidden;
                SqlTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                CommandTab.Visibility = Visibility.Visible;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the SQL tab.
        /// </summary>
        private void ActivateSqlTab( )
        {
            try
            {
                SqlTab.IsSelected = true;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                CommandTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
                SqlTab.Visibility = Visibility.Visible;
                _commands = CreateCommandList( _provider );
                PopulateCommandComboBox( _commands );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the schema tab.
        /// </summary>
        private void ActivateCalendarTab( )
        {
            try
            {
                if( _dates == null )
                {
                    var _message = "Verify table contains date fields!";
                    SendNotification( _message );
                }
                else
                {
                    ClearCollections( );
                    ClearListBoxes( );
                    ClearComboBoxes( );
                    PrimaryTabControl.SelectedIndex = 0;
                    SecondaryTabControl.SelectedIndex = 3;
                    DataTab.IsSelected = true;
                    CalendarTab.IsSelected = true;
                    DataTab.Visibility = Visibility.Visible;
                    SchemaTab.Visibility = Visibility.Hidden;
                    SqlTab.Visibility = Visibility.Hidden;
                    BusyTab.Visibility = Visibility.Hidden;
                    SourceTab.Visibility = Visibility.Hidden;
                    FilterTab.Visibility = Visibility.Hidden;
                    CommandTab.Visibility = Visibility.Hidden;
                    CalendarTab.Visibility = Visibility.Hidden;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the filter.
        /// </summary>
        private void ClearFilters( )
        {
            try
            {
                if( !string.IsNullOrEmpty( _firstValue ) )
                {
                    _firstValue = string.Empty;
                }

                if( !string.IsNullOrEmpty( _firstCategory ) )
                {
                    _firstCategory = string.Empty;
                }

                if( !string.IsNullOrEmpty( _secondCategory ) )
                {
                    _secondCategory = string.Empty;
                }

                if( !string.IsNullOrEmpty( _secondValue ) )
                {
                    _secondValue = string.Empty;
                }

                if( _filter?.Any( ) == true )
                {
                    _filter.Clear();
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the selections.
        /// </summary>
        private void ClearSelections( )
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
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the collections.
        /// </summary>
        private void ClearCollections( )
        {
            try
            {
                if( _fields?.Any( ) == true )
                {
                    _fields.Clear( );
                }

                if( _columns?.Any( ) == true )
                {
                    _columns.Clear( );
                }

                if( _numerics?.Any( ) == true )
                {
                    _numerics.Clear( );
                }
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
                if( FirstListBox?.Items?.Count > 0 )
                {
                    FirstListBox.Items.Clear( );
                }

                if( SecondListBox?.Items?.Count > 0 )
                {
                    SecondListBox.Items.Clear( );
                }

                if( CommandListBox?.Items?.Count > 0 )
                {
                    CommandListBox.Items.Clear( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the combo boxes.
        /// </summary>
        private void ClearComboBoxes( )
        {
            try
            {
                if(FirstComboBox?.Items?.Count > 0)
                {
                    FirstComboBox.Items.Clear();
                }

                if(SecondComboBox?.Items?.Count > 0)
                {
                    SecondComboBox.Items.Clear();
                }

                if(CommandComboBox?.Items?.Count > 0)
                {
                    CommandComboBox.Items.Clear();
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the text boxes.
        /// </summary>
        private void ClearTextBoxes( )
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
                ExportButton.Visibility = Visibility.Visible;
                BrowseButton.Visibility = Visibility.Visible;
                GridButton.Visibility = Visibility.Visible;
                CalendarButton.Visibility = Visibility.Visible;
                DataSourceButton.Visibility = Visibility.Visible;
                SqlButton.Visibility = Visibility.Visible;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                ExportButton.Visibility = Visibility.Hidden;
                BrowseButton.Visibility = Visibility.Hidden;
                GridButton.Visibility = Visibility.Hidden;
                CalendarButton.Visibility = Visibility.Hidden;
                DataSourceButton.Visibility = Visibility.Hidden;
                SqlButton.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Hides the tabs.
        /// </summary>
        private void HideTabs( )
        {
            try
            {
                DataTab.Visibility = Visibility.Hidden;
                EditTab.Visibility = Visibility.Hidden;
                SchemaTab.Visibility = Visibility.Hidden;
                SqlTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                CommandTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Resets the ListBox visibility.
        /// </summary>
        private void ResetListBoxVisibility( )
        {
            try
            {
                if( string.IsNullOrEmpty( _firstCategory ) )
                {
                    FirstComboBox.Visibility = Visibility.Visible;
                    FirstListBox.Visibility = Visibility.Visible;
                    SecondComboBox.Visibility = Visibility.Hidden;
                    SecondListBox.Visibility = Visibility.Hidden;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Runs the client application.
        /// </summary>
        private void RunClient( )
        {
            try
            {
                switch( _provider )
                {
                    case Provider.Access:
                    {
                        DataMinion.RunAccess( );
                        break;
                    }
                    case Provider.SqlCe:
                    {
                        DataMinion.RunSqlCe( );
                        break;
                    }
                    case Provider.SQLite:
                    {
                        DataMinion.RunSQLite( );
                        break;
                    }
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
        /// Updates the label text.
        /// </summary>
        private void UpdateLabels( )
        {
            try
            {
                if( _dataTable != null )
                {
                    var _rows = _dataTable.Rows.Count.ToString( "#,###" ) ?? "0";
                    var _cols = _fields?.Count ?? 0;
                    var _vals = _numerics?.Count ?? 0;
                    FirstGridLabel.Content = $"Data Provider: {_provider}";
                    SecondGridLabel.Content = $"Records: {_rows}";
                    ThirdGridLabel.Content = $"Total Fields: {_cols}";
                    FourthGridLabel.Content = $"Total Measures: {_vals}";
                }
                else
                {
                    FirstGridLabel.Content = $"Provider:  {_provider}";
                    SecondGridLabel.Content = "Total Records: 0.0";
                    ThirdGridLabel.Content = "Total Fields: 0.0";
                    FourthGridLabel.Content = "Total Measures: 0.0";
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the main form.
        /// </summary>
        private void OpenMainWindow( )
        {
            try
            {
                var _form = ( MainWindow )App.ActiveWindows[ "MainWindow" ];
                _form.Show( );
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                        ActivateDataTab( );
                        break;
                    }
                    case 1:
                    {
                        ActivateEditTab( );
                        break;
                    }
                    case 3:
                    {
                        ActivateSchemaTab( );
                        break;
                    }
                    case 4:
                    {
                        ActivateBusyTab( );
                        break;
                    }
                    default:
                    {
                        ActivateDataTab( );
                        break;
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                        ActivateCommandTab( );
                        break;
                    }
                    default:
                    {
                        ActivateSourceTab( );
                        break;
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        private void SetProvider( string provider )
        {
            try
            {
                ThrowIf.Null( provider, nameof( provider ) );
                var _value = ( Provider )Enum.Parse( typeof( Provider ), provider );
                if( Enum.IsDefined( typeof( Provider ), _value ) )
                {
                    _provider = _value switch
                    {
                        Provider.Access => Provider.Access,
                        Provider.SQLite => Provider.SQLite,
                        Provider.SqlCe => Provider.SqlCe,
                        Provider.SqlServer => Provider.SqlServer,
                        _ => Provider.Access
                    };
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
                InitializeComboBoxes( );
                InitializeTabControls( );
                InitializeLabels( );
                InitializeToolbar( );
                UpdateLabels( );
                HideTabs( );
                FadeInAsync( this );
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
                MoveToFirst( );
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
                MoveToPrevious( );
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
                MoveToNext( );
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
                MoveToLast( );
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
                var _fileBrowser = new FileBrowser( );
                _fileBrowser.ShowDialog( );
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
                ActivateEditTab( );
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
                ClearFilters( );
                ClearSelections( );
                ClearCollections( );
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
        /// Called when [filter button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFilterButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ActivateFilterTab( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [grid button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnGridButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ActivateDataTab( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [group button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnSqlButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ActivateSqlTab( );
                ActivateCommandTab( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [calendar button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnCalendarButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ActivateCalendarTab( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [data source button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnDataSourceButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ActivateSourceTab( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [schema button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnSchemaButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ActivateSchemaTab( );
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
                Close( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [closing].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnClosing( object sender, CancelEventArgs e )
        {
            try
            {
                if( App.ActiveWindows.ContainsKey( "MainWindow" ) )
                {
                    OpenMainWindow( );
                }

                SfSkinManager.Dispose( this );
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
                var _calculator = new CalculatorWindow
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    Owner = this,
                    Topmost = true
                };

                _calculator.Show( );
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
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
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
        /// Called when [folder menu option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFolderMenuOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _fileBrowser = new FileBrowser
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
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
                Application.Current.Shutdown( );
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
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [provider RadioButton click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnProviderRadioButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                _commands = CreateCommandList( _provider );
                PopulateCommandComboBox( _commands );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [table ListBox item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name = "e" > </param>
        private void OnTableListBoxItemSelected( object sender, RoutedEventArgs e )
        {
            if( sender is MetroListBox _listBox )
            {
                try
                {
                    _filter.Clear( );
                    _dataTable?.Clear( );
                    ShowToolbar( );
                    var _item = _listBox.SelectedItem as MetroListBoxItem;
                    var _title = _item?.Content.ToString( );
                    _selectedTable = _title?.Replace( " ", "" );
                    if( !string.IsNullOrEmpty( _selectedTable ) )
                    {
                        _source = ( Source )Enum.Parse( typeof( Source ), _selectedTable );
                    }

                    _data = new DataGenerator( _source, _provider );
                    _dataTable = _data.DataTable;
                    _columns = _data.ColumnNames;
                    _fields = _data.Fields;
                    _numerics = _data.Numerics;
                    _current = _dataTable.Rows[ 0 ];
                    DataGrid.ItemsSource = _dataTable;
                    DataGrid.SelectedIndex = 0;
                    PopulateFirstComboBoxItems( );
                    PopulateDataColumnListBox( );
                    ResetListBoxVisibility( );
                    ActivateFilterTab( );
                    UpdateLabels( );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Called when [first ComboBox item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFirstComboBoxItemSelected( object sender, RoutedEventArgs e )
        {
            if( sender is MetroComboBox _comboBox )
            {
                try
                {
                    _firstCategory = string.Empty;
                    _firstValue = string.Empty;
                    _secondCategory = string.Empty;
                    _secondValue = string.Empty;
                    FirstListBox.Items?.Clear( );
                    _firstCategory = _comboBox.SelectedItem?.ToString( );
                    if( !string.IsNullOrEmpty( _firstCategory ) )
                    {
                        this._data = new DataGenerator( _source, _provider );
                        var _data = this._data.DataElements[ _firstCategory ];
                        foreach( var _value in _data )
                        {
                            var _item = new MetroListBoxItem
                            {
                                Content = _value
                            };

                            FirstListBox.Items?.Add( _item );
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
        /// Called when [first ListBox item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name = "e" > </param>
        private void OnFirstListBoxItemSelected( object sender, RoutedEventArgs e )
        {
            if( sender is MetroListBox _listBox )
            {
                try
                {
                    if( _filter.Count > 0 )
                    {
                        _filter.Clear( );
                    }

                    _dataTable?.Clear( );
                    var _item = _listBox.SelectedItem as MetroListBoxItem;
                    _firstValue = _item?.Content.ToString( );
                    _filter.Add( _firstCategory, _firstValue );
                    _data = new DataGenerator( _source, _provider, _filter );
                    _dataTable = _data.DataTable;
                    _current = _data.Record;
                    DataGrid.ItemsSource = _dataTable;
                    if( SecondComboBox.Visibility == Visibility.Hidden )
                    {
                        SecondComboBox.Visibility = Visibility.Visible;
                        SecondListBox.Visibility = Visibility.Visible;
                    }

                    PopulateSecondComboBoxItems( );
                    UpdateLabels( );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Called when [second ComboBox item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnSecondComboBoxItemSelected( object sender, RoutedEventArgs e )
        {
            if( sender is MetroComboBox _comboBox )
            {
                try
                {
                    _secondCategory = string.Empty;
                    _secondValue = string.Empty;
                    if( !string.IsNullOrEmpty( _secondCategory ) )
                    {
                        SecondListBox.Items?.Clear( );
                    }

                    _secondCategory = _comboBox.SelectedItem?.ToString( );
                    if( !string.IsNullOrEmpty( _secondCategory ) )
                    {
                        var _data = this._data.DataElements[ _secondCategory ];
                        foreach( var _element in _data )
                        {
                            var _item = new MetroListBoxItem
                            {
                                Content = _element
                            };

                            SecondListBox.Items?.Add( _item );
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
        /// Called when [second ListBox item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name = "e" > </param>
        private void OnSecondListBoxItemSelected( object sender, RoutedEventArgs e )
        {
            if( sender is MetroListBox _listBox )
            {
                try
                {
                    if( _filter.Keys?.Count > 0 )
                    {
                        _filter.Clear( );
                    }

                    _dataTable?.Clear( );
                    var _item = _listBox.SelectedItem as MetroListBoxItem;
                    _secondValue = _item?.Content?.ToString( );
                    _filter.Add( _firstCategory, _firstValue );
                    _filter.Add( _secondCategory, _secondValue );
                    _data = new DataGenerator( _source, _provider, _filter );
                    _dataTable = _data.DataTable;
                    _current = _data.Record;
                    DataGrid.ItemsSource = _dataTable;
                    UpdateLabels( );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Called when [first calendar date selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnStartDateSelected( object sender, RoutedEventArgs e )
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
        /// Called when [sedond calendar date selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnEndDateSelected( object sender, RoutedEventArgs e )
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
        /// Called when [RadioButton selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnTableComboBoxItemSelected( object sender, RoutedEventArgs e )
        {
            try
            {
                if( sender is MetroComboBox _button )
                {
                    var _model = _button?.Tag?.ToString( );
                    switch( _model )
                    {
                        case "EXECUTION":
                        {
                            PopulateExecutionTables( );
                            break;
                        }
                        case "REFERENCE":
                        {
                            PopulateReferenceTables( );
                            break;
                        }
                        case "MAINTENANCE":
                        {
                            PopulateMaintenanceTables( );
                            break;
                        }
                        default:
                        {
                            PopulateExecutionTables( );
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
        /// Called when [RadioButton checked].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name = "e" > </param>
        private void OnProviderRadioButtonChecked( object sender, RoutedEventArgs e )
        {
            if( sender is MetroRadioButton _button )
            {
                try
                {
                    var _tag = _button.Tag?.ToString( );
                    if( !string.IsNullOrEmpty( _tag ) )
                    {
                        SetProvider( _tag );
                        _dataTypes = GetDataTypes( _provider );
                        _commands = CreateCommandList( _provider );
                        PopulateDataTypeListBoxItems( _dataTypes );
                        PopulateCommandComboBox( _commands );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Called when [data row selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnDataGridSelectedIndexChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                var _index = DataGrid.SelectedIndex;
                _current = _dataTable.Rows[ _index ];
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [ComboBox item selected].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnCommandComboBoxItemSelected( object sender, RoutedEventArgs e )
        {
            if( sender is MetroComboBox _comboBox )
            {
                try
                {
                    var _prefix = ConfigurationManager.AppSettings[ "PathPrefix" ];
                    var _dbpath = ConfigurationManager.AppSettings[ "DatabaseDirectory" ];
                    _selectedCommand = string.Empty;
                    var _selection = _comboBox.SelectedItem?.ToString( );
                    CommandListBox.Items?.Clear( );
                    if( _selection?.Contains( " " ) == true )
                    {
                        _selectedCommand = _selection.Replace( " ", "" );
                        var _filePath = _prefix + _dbpath
                            + @$"\{_provider}\DataModels\{_selectedCommand}";

                        var _files = Directory.GetFiles( _filePath );
                        for( var _i = 0; _i < _files.Length; _i++ )
                        {
                            var _item = Path.GetFileNameWithoutExtension( _files[ _i ] );
                            var _caption = _item?.SplitPascal( );
                            CommandListBox.Items?.Add( _caption );
                        }
                    }
                    else
                    {
                        _selectedCommand = _comboBox.SelectedItem?.ToString( );
                        var _filePath = _prefix + _dbpath
                            + @$"\{_provider}\DataModels\{_selectedCommand}";

                        var _names = Directory.GetFiles( _filePath );
                        for( var _i = 0; _i < _names.Length; _i++ )
                        {
                            var _item = Path.GetFileNameWithoutExtension( _names[ _i ] );
                            var _caption = _item?.SplitPascal( );
                            CommandListBox.Items?.Add( _caption );
                        }
                    }

                    PrimaryTabControl.SelectedIndex = 3;
                    SqlTab.IsSelected = true;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Called when [ListBox item selected].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name = "e" > </param>
        private void OnCommandListBoxItemSelected( object sender, RoutedEventArgs e )
        {
            if( sender is MetroListBox _listBox
                && !string.IsNullOrEmpty( _listBox.SelectedItem.ToString( ) ) )
            {
                try
                {
                    var _prefix = ConfigurationManager.AppSettings[ "PathPrefix" ];
                    var _dbpath = ConfigurationManager.AppSettings[ "DatabaseDirectory" ];
                    Editor.Text = string.Empty;
                    _selectedQuery = _listBox.SelectedItem?.ToString( );
                    if( _selectedQuery?.Contains( " " ) == true
                        || _selectedCommand?.Contains( " " ) == true )
                    {
                        var _command = _selectedCommand?.Replace( " ", "" );
                        var _query = _selectedQuery?.Replace( " ", "" );
                        var _filePath = _prefix + _dbpath
                            + @$"\{_provider}\DataModels\{_command}\{_query}.sql";

                        using var _stream = File.OpenRead( _filePath );
                        using var _reader = new StreamReader( _stream );
                        var _text = _reader.ReadToEnd( );
                        Editor.Text = _text;
                    }
                    else
                    {
                        var _filePath = _prefix + _dbpath
                            + @$"\{_provider}\DataModels\{_selectedCommand}\{_selectedQuery}.sql";

                        using var _stream = File.OpenRead( _filePath );
                        using var _reader = new StreamReader( _stream );
                        var _text = _reader.ReadToEnd( );
                        Editor.Text = _text;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private protected void OnGridLoaded( object sender, RoutedEventArgs e )
        {
            try
            {
                _columnPicker = new ColumnChooser( DataGrid );
                _columnPicker.Resources.MergedDictionaries.Clear( );
                _columnPicker.ClearValue( StyleProperty );

                // Resources has been added to the Merged Dictionaries     
                _columnPicker.Resources.MergedDictionaries.Add( Resources.MergedDictionaries[ 0 ] );
                DataGrid.GridColumnDragDropController = new GridColumnChooserController( DataGrid, _columnPicker );

                // ColumnChooser Window will open
                _columnPicker.Show( );
                _columnPicker.Owner = this;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks
        /// associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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