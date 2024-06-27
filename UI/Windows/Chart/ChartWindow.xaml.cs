// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler


// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 06-26-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        06-26-2024
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   ChartWindow.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using Syncfusion.SfSkinManager;
    using Syncfusion.UI.Xaml.Charts;
    using Syncfusion.UI.Xaml.SmithChart;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Messages;
    using ToastNotifications.Position;
    using Action = System.Action;
    using Application = System.Windows.Application;
    using Exception = System.Exception;
    using SelectionMode = System.Windows.Controls.SelectionMode;

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
    [ SuppressMessage( "ReSharper", "LoopCanBePartlyConvertedToQuery" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    public partial class ChartWindow : Window, IDisposable
    {
        /// <summary>
        /// The locked object
        /// </summary>
        private object _path;

        /// <summary>
        /// 
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
        /// The current
        /// </summary>
        private protected DataRow _current;

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
        /// The SQL command
        /// </summary>
        private protected string _sqlQuery;

        /// <summary>
        /// The stat
        /// </summary>
        private protected STAT _metric;

        /// <summary>
        /// The data model
        /// </summary>
        private protected DataGenerator _data;

        /// <summary>
        /// The data table
        /// </summary>
        private protected DataTable _dataTable;

        /// <summary>
        /// The data source
        /// </summary>
        private protected ObservableCollection<DataRow> _dataSource;

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
        /// The steel blue
        /// </summary>
        private protected Color _steelBlue = Colors.SteelBlue;

        /// <summary>
        /// The maroon
        /// </summary>
        private protected Color _maroon = Colors.Maroon;

        /// <summary>
        /// The green
        /// </summary>
        private protected Color _green = Colors.DarkOliveGreen;

        /// <summary>
        /// The yellow
        /// </summary>
        private protected Color _khaki = Colors.DarkKhaki;

        /// <summary>
        /// The orange
        /// </summary>
        private protected Color _yellow = Colors.Yellow;

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
            SfSkinManager.SetTheme( this, new Theme( "FluentDark", App.Controls ) );

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
            WindowStyle = WindowStyle.SingleBorderWindow;
            Title = "Visualization";
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
                FilterButton.Click += OnFilterButtonClick;
                GroupButton.Click += OnGroupButtonClick;
                RefreshButton.Click += OnRefreshButtonClick;
                LookupButton.Click += OnLookupButtonClick;
                BrowseButton.Click += OnBrowseButtonClick;
                MenuButton.Click += OnMenuButtonClick;
                ToggleButton.Click += OnToggleButtonClick;
                DataTableListBox.SelectionChanged += OnTableListBoxItemSelected;
                ToolStripComboBox.SelectionChanged += OnChartTypeSelected;
                DataSourceButton.Click += OnDataSourceButtonClick;
                FirstComboBox.SelectionChanged += OnFirstComboBoxItemSelected;
                FirstListBox.SelectionChanged += OnFirstListBoxItemSelected;
                SecondComboBox.SelectionChanged += OnSecondComboBoxItemSelected;
                SecondListBox.SelectionChanged += OnSecondListBoxItemSelected;
                FieldListBox.SelectionChanged += OnFieldListBoxSelectionChanged;
                NumericListBox.SelectionChanged += OnNumericListBoxSelectionChanged;
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
        /// Initializes the chart.
        /// </summary>
        private void InitializeColumnChart( )
        {
            try
            {
                var _wallColor = new Color( )
                {
                    A = 255,
                    R = 55,
                    G = 55,
                    B = 55
                };

                var _chartColorModel = new ChartColorModel( );
                _chartColorModel.CustomBrushes.Add( new SolidColorBrush( _steelBlue ) );
                _chartColorModel.CustomBrushes.Add( new SolidColorBrush( _green ) );
                _chartColorModel.CustomBrushes.Add( new SolidColorBrush( _maroon ) );
                _chartColorModel.CustomBrushes.Add( new SolidColorBrush( _khaki ) );
                _chartColorModel.CustomBrushes.Add( new SolidColorBrush( _yellow ) );
                ColumnChart.Palette = ChartColorPalette.Custom;
                var _yAxis = new NumericalAxis3D
                {
                    FontSize = 10,
                    ShowOrigin = true,
                    Foreground = new SolidColorBrush( _foreColor ),
                    ShowGridLines = true
                };

                var _xAxis = new CategoryAxis3D
                {
                    FontSize = 10,
                    ShowOrigin = true,
                    Foreground = new SolidColorBrush( _foreColor ),
                    ShowGridLines = true
                };

                ColumnChart.BackWallBrush = new SolidColorBrush( _wallColor );
                ColumnChart.BottomWallBrush = new SolidColorBrush( _wallColor );
                ColumnChart.LeftWallBrush = new SolidColorBrush( _wallColor );
                ColumnChart.RightWallBrush = new SolidColorBrush( _wallColor );
                ColumnChart.SecondaryAxis = _yAxis;
                ColumnChart.PrimaryAxis = _xAxis;
                ColumnChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Column Chart";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the pie chart.
        /// </summary>
        private void InitializePieChart( )
        {
            try
            {
                PieChart.FontSize = 10;
                PieChart.Series?.Clear( );
                PieChart.Background = new SolidColorBrush( _backColor );
                PieChart.Foreground = new SolidColorBrush( _foreColor );
                PieChart.BorderBrush = new SolidColorBrush( _borderColor );
                PieChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Pie Chart";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the sunburst chart.
        /// </summary>
        private void InitializeSunburstChart( )
        {
            try
            {
                SunburstChart.FontSize = 10;
                SunburstChart.Background = new SolidColorBrush( _backColor );
                SunburstChart.Foreground = new SolidColorBrush( _foreColor );
                SunburstChart.BorderBrush = new SolidColorBrush( _borderColor );
                SunburstChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Sunburst Chart";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the smith chart.
        /// </summary>
        private void InitializeSmithChart( )
        {
            try
            {
                var _radial = new RadialAxis( )
                {
                    FontSize = 10
                };

                var _horizontal = new HorizontalAxis( )
                {
                    FontSize = 10
                };

                SmithChart.RadialAxis = _radial;
                SmithChart.HorizontalAxis = _horizontal;
                SmithChart.Background = new SolidColorBrush( _backColor );
                SmithChart.Foreground = new SolidColorBrush( _foreColor );
                SmithChart.BorderBrush = new SolidColorBrush( _borderColor );
                SmithChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Smith Chart";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the area chart.
        /// </summary>
        private void InitializeAreaChart( )
        {
            try
            {
                AreaChart.FontSize = 10;
                AreaChart.Series?.Clear( );
                AreaChart.Background = new SolidColorBrush( _backColor );
                AreaChart.Foreground = new SolidColorBrush( _foreColor );
                AreaChart.BorderBrush = new SolidColorBrush( _borderColor );
                AreaChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Area Chart";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the histogram.
        /// </summary>
        private void InitializeHistogram( )
        {
            try
            {
                HistogramChart.FontSize = 10;
                HistogramChart.Series?.Clear( );
                HistogramChart.Background = new SolidColorBrush( _backColor );
                HistogramChart.Foreground = new SolidColorBrush( _foreColor );
                HistogramChart.BorderBrush = new SolidColorBrush( _borderColor );
                HistogramChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Histogram";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        private void InitializeScatterChart( )
        {
            try
            {
                ScatterChart.FontSize = 10;
                ScatterChart.Background = new SolidColorBrush( _backColor );
                ScatterChart.Foreground = new SolidColorBrush( _foreColor );
                ScatterChart.BorderBrush = new SolidColorBrush( _borderColor );
                ScatterChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Area Chart";
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
                FieldsLabel.Foreground = new SolidColorBrush( _borderColor );
                NumericsLabel.Foreground = new SolidColorBrush( _borderColor );
                FirstDateLabel.Foreground = new SolidColorBrush( _borderColor );
                SecondDateLabel.Foreground = new SolidColorBrush( _borderColor );
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
                FieldListBox.SelectionMode = SelectionMode.Multiple;
                NumericListBox.SelectionMode = SelectionMode.Multiple;
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
        /// Initializes the tab controls.
        /// </summary>
        private void InitializeTabControls( )
        {
            try
            {
                ColumnTab.IsSelected = true;
                SourceTab.IsSelected = true;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                GroupTab.Visibility = Visibility.Hidden;
                HistogramTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                MetricsTab.Visibility = Visibility.Hidden;
                SecondDateLabel.Visibility = Visibility.Hidden;
                SecondCalendar.Visibility = Visibility.Hidden;
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
                FilterButton.Visibility = Visibility.Hidden;
                DataSourceButton.Visibility = Visibility.Hidden;
                GroupButton.Visibility = Visibility.Hidden;
                RefreshButton.Visibility = Visibility.Hidden;
                LookupButton.Visibility = Visibility.Hidden;
                ExportButton.Visibility = Visibility.Hidden;
                FirstButton.Visibility = Visibility.Hidden;
                BrowseButton.Visibility = Visibility.Hidden;
                ToolStripComboBox.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Binds the context.
        /// </summary>
        private protected void GetData( )
        {
            try
            {
                if( _filter?.Keys?.Count > 0 )
                {
                    _data = new DataGenerator( _source, _provider, _filter );
                }
                else
                {
                    _data = new DataGenerator( _source, _provider );
                }

                _dataTable = _data.DataTable;
                _dataSource = _dataTable?.ToObservable( );
                _current = _data.Record;
                _columns = _data.ColumnNames;
                _fields = _data.Fields;
                _numerics = _data.Numerics;
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
        /// <returns>
        /// </returns>
        private string CreateSelectQuery( IDictionary<string, object> where )
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
        private string CreateSelectQuery( IEnumerable<string> fields, IEnumerable<string> numerics,
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
                    foreach( var _name in fields )
                    {
                        _cols += $"{_name}, ";
                    }

                    foreach( var _colname in numerics )
                    {
                        _aggr += $"SUM({_colname}) AS {_colname}, ";
                    }

                    var _groups = _cols.TrimEnd( ", ".ToCharArray( ) );
                    var _criteria = where.ToCriteria( );
                    var _values = _cols + _aggr.TrimEnd( ", ".ToCharArray( ) );

                    return $"SELECT {_values} "
                        + $"FROM {_selectedTable} "
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
        private string CreateSelectQuery( IEnumerable<string> columns,
            IDictionary<string, object> where )
        {
            if( !string.IsNullOrEmpty( _selectedTable ) )
            {
                try
                {
                    ThrowIf.Empty( where, nameof( where ) );
                    ThrowIf.Empty( columns, nameof( columns ) );
                    var _cols = string.Empty;
                    foreach( var _name in columns )
                    {
                        _cols += $"{_name}, ";
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
                    var _message = "  The Data Table is null!";
                    SendMessage( _message );
                }
                else if( _data.Numerics == null )
                {
                    var _message = "  The data is not alpha-numeric";
                    SendMessage( _message );
                }
                else
                {
                    var _report = new ExcelReport( _dataTable );
                    _report.SaveDialog( );
                    var _message = "  The Excel File has been created!";
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
        private void ShowToolbar( )
        {
            try
            {
                FirstButton.Visibility = Visibility.Visible;
                PreviousButton.Visibility = Visibility.Visible;
                NextButton.Visibility = Visibility.Visible;
                LastButton.Visibility = Visibility.Visible;
                ToolStripTextBox.Visibility = Visibility.Visible;
                ToolStripComboBox.Visibility = Visibility.Visible;
                DataSourceButton.Visibility = Visibility.Visible;
                FilterButton.Visibility = Visibility.Visible;
                GroupButton.Visibility = Visibility.Visible;
                LookupButton.Visibility = Visibility.Visible;
                RefreshButton.Visibility = Visibility.Visible;
                ExportButton.Visibility = Visibility.Visible;
                BrowseButton.Visibility = Visibility.Visible;
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
                ToolStripComboBox.Visibility = Visibility.Hidden;
                FilterButton.Visibility = Visibility.Hidden;
                DataSourceButton.Visibility = Visibility.Hidden;
                ExportButton.Visibility = Visibility.Hidden;
                GroupButton.Visibility = Visibility.Hidden;
                RefreshButton.Visibility = Visibility.Hidden;
                LookupButton.Visibility = Visibility.Hidden;
                BrowseButton.Visibility = Visibility.Hidden;
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
                var _form = (MainWindow)App.ActiveWindows[ "MainWindow" ];
                _form.Show( );
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                    FirstComboBox.Items?.Clear( );
                    FirstListBox.Items?.Clear( );
                    for( var _index = 0; _index < _fields.Count; _index++ )
                    {
                        var _name = _fields[ _index ];
                        var _item = new MetroComboBoxItem
                        {
                            Content = _name,
                            ToolTip = _name.SplitPascal( ),
                            Tag = _name
                        };

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
        public void PopulateSecondComboBoxItems( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    SecondComboBox.Items?.Clear( );
                    SecondListBox.Items?.Clear( );
                    if( !string.IsNullOrEmpty( _firstValue ) )
                    {
                        for( var _index = 0; _index < _fields.Count; _index++ )
                        {
                            var _name = _fields[ _index ];
                            if( !_name.Equals( _firstCategory ) )
                            {
                                var _item = new MetroComboBoxItem
                                {
                                    Content = _name,
                                    ToolTip = _name?.SplitPascal( ),
                                    Tag = _name
                                };

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
        /// Populates the execution tables.
        /// </summary>
        private void PopulateExecutionTables( )
        {
            try
            {
                DataTableListBox.Items?.Clear( );
                var _tables = new DataGenerator( Source.ApplicationTables, _provider );
                var _rows = _tables.GetData( );
                var _names = _rows
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
                            ToolTip = _name.SplitPascal( ),
                            Tag = _name
                        };

                        DataTableListBox.Items?.Add( _item );
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

                    for( var _index = 0; _index < _fields.Count; _index++ )
                    {
                        var _name = _fields[ _index ];
                        var _item = new MetroListBoxItem
                        {
                            Content = _name,
                            ToolTip = _name.SplitPascal( ),
                            Tag = _name
                        };

                        FieldListBox.Items.Add( _item );
                    }
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

                    for( var _index = 0; _index < _numerics.Count; _index++ )
                    {
                        var _name = _numerics[ _index ];
                        if( !string.IsNullOrEmpty( _numerics[ _index ] ) )
                        {
                            var _item = new MetroListBoxItem
                            {
                                Content = _name,
                                ToolTip = _name.SplitPascal( ),
                                Tag = _name
                            };

                            NumericListBox.Items.Add( _item );
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
        /// Activates the busy tab.
        /// </summary>
        private void ActivateColumnTab( )
        {
            try
            {
                ColumnTab.IsSelected = true;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                HistogramTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the pie tab.
        /// </summary>
        private void ActivatePieTab( )
        {
            try
            {
                PieTab.IsSelected = true;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                HistogramTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the sun tab.
        /// </summary>
        private void ActivateSunTab( )
        {
            try
            {
                SunTab.IsSelected = true;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                HistogramTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the smith tab.
        /// </summary>
        private void ActivateSmithTab( )
        {
            try
            {
                SmithTab.IsSelected = true;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                HistogramTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the heat tab.
        /// </summary>
        private void ActivateAreaTab( )
        {
            try
            {
                AreaTab.IsSelected = true;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                HistogramTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the gantt tab.
        /// </summary>
        private void ActivateScatterTab( )
        {
            try
            {
                ScatterTab.IsSelected = true;
                ScatterTab.Visibility = Visibility.Hidden;
                ColumnTab.Visibility = Visibility.Hidden;
                HistogramTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the histogram tab.
        /// </summary>
        private void ActivateHistogramTab( )
        {
            try
            {
                HistogramTab.IsSelected = true;
                HistogramTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
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
                BusyTab.IsSelected = true;
                BusyTab.Visibility = Visibility.Visible;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                HistogramTab.Visibility = Visibility.Hidden;
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
                SourceTab.IsSelected = true;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                GroupTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
                PopulateExecutionTables( );
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
                _filter?.Clear( );
                FilterTab.IsSelected = true;
                FilterTab.Visibility = Visibility.Hidden;
                GroupTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
                SourceTab.Visibility = Visibility.Hidden;
                SecondComboBox.Visibility = Visibility.Hidden;
                SecondListBox.Visibility = Visibility.Hidden;
                PopulateFirstComboBoxItems( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the schema tab.
        /// </summary>
        private void ActivateGroupTab( )
        {
            try
            {
                GroupTab.IsSelected = true;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                GroupTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
                PopulateFieldListBox( );
                PopulateNumericListBox( );
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
                FirstComboBox.Items?.Clear( );
                SecondComboBox.Items?.Clear( );
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
                FirstListBox.Items?.Clear( );
                SecondListBox.Items?.Clear( );
                FieldListBox.Items?.Clear( );
                NumericListBox.Items?.Clear( );
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
                _data = null;
                _dataTable = null;
                _dataSource = null;
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
                if( _filter?.Keys?.Count > 0 )
                {
                    _filter.Clear( );
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
                if( _columns?.Count > 0 ) 
                {
                    _columns.Clear( );
                }

                if( _fields?.Count > 0 ) 
                {
                    _fields.Clear( );
                }

                if( _numerics?.Count > 0 ) 
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
        /// Clears the selections.
        /// </summary>
        private void ClearSelections( )
        {
            try
            {
                if( _selectedColumns?.Count > 0 )
                {
                    _selectedColumns.Clear( );
                }

                if( _selectedFields?.Count > 0 )
                {
                    _selectedFields.Clear( );
                }

                if( _selectedNumerics?.Count > 0 )
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
                    SecondLabel.Content = $"Total Records: {_rows}";
                    ThirdLabel.Content = $"Total Fields: {_cols}";
                    FourthLabel.Content = $"Total Measures: {_vals}";
                    if( _filter?.Count > 0 )
                    {
                        FifthLabel.Content = $"Selected Filters: {_filter.Count}";
                    }
                    else
                    {
                        FifthLabel.Content = $"Selected Filters: 0.0";
                    }

                    if( _selectedFields?.Count > 0 )
                    {
                        SixthLabel.Content = $"Selected Fields: {FieldListBox.SelectedItems?.Count}";
                    }
                    else
                    {
                        SixthLabel.Content = "Selected Fields: 0.0";
                    }

                    if( _selectedFields?.Count > 0 )
                    {
                        SeventhLabel.Content = $"Selected Numerics: {NumericListBox.SelectedItems?.Count}";
                    }
                    else
                    {
                        SeventhLabel.Content = "Selected Numerics: 0.0";
                    }
                }
                else
                {
                    SecondLabel.Content = "Total Records: 0.0";
                    ThirdLabel.Content = "Total Fields: 0.0";
                    FourthLabel.Content = "Total Measures: 0.0";
                    FifthLabel.Content = "Selected Filters: 0.0";
                    SixthLabel.Content = "Selected Fields: 0.0";
                    SeventhLabel.Content = "Selected Numerics: 0.0";
                }
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
                        ActivateColumnTab( );

                        break;
                    }
                    case 1:
                    {
                        ActivatePieTab( );

                        break;
                    }
                    case 2:
                    {
                        ActivateSunTab( );

                        break;
                    }
                    case 3:
                    {
                        ActivateHistogramTab( );

                        break;
                    }
                    case 4:
                    {
                        ActivateSmithTab( );

                        break;
                    }
                    case 5:
                    {
                        ActivateAreaTab( );

                        break;
                    }
                    case 6:
                    {
                        ActivateScatterTab( );

                        break;
                    }
                    case 7:
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
                InitializeTabControls( );
                InitializeLabels( );
                InitializeToolbar( );
                InitializeListBoxes( );
                PopulateExecutionTables( );
                UpdateLabels( );
                Opacity = 0;
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
                GetData( );
                UpdateLabels( );
                ActivateFilterTab( );
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
        /// Called when [group button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnGroupButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ActivateGroupTab( );
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
        /// Called when [active tab changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnPrimaryActiveTabChanged( object sender, RoutedEventArgs e )
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
        private void OnSecondaryActiveTabChanged( object sender, RoutedEventArgs e )
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
        private void OnRadioButtonSelected( object sender, RoutedEventArgs e )
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
        /// Called when [table ListBox item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnTableListBoxItemSelected( object sender, RoutedEventArgs e )
        {
            if( sender is MetroListBox _listBox )
            {
                try
                {
                    if( _filter.Count > 0 )
                    {
                        _filter.Clear( );
                    }

                    var _item = _listBox.SelectedItem as MetroListBoxItem;
                    var _title = _item?.Content?.ToString( );
                    _selectedTable = _title?.Replace( " ", "" );
                    if( !string.IsNullOrEmpty( _selectedTable ) )
                    {
                        _source = (Source)Enum.Parse( typeof( Source ), _selectedTable );
                        ColumnChart.Header = _title;
                        PieChart.Header = _title;
                        AreaChart.Header = _title;
                        SunburstChart.Header = _title;
                        SmithChart.Header = _title;
                        HistogramChart.Header = _title;
                    }

                    GetData( );
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
        /// Called when [chart type selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnChartTypeSelected( object sender, RoutedEventArgs e )
        {
            try
            {
                var _comboBox = sender as MetroComboBox;
                var _item = _comboBox?.SelectedItem as MetroComboBoxItem;
                if( _item?.Content != null )
                {
                    switch( _item.Content )
                    {
                        case "Column":
                        {
                            ActivateColumnTab( );

                            break;
                        }
                        case "Pie":
                        {
                            ActivatePieTab( );

                            break;
                        }
                        case "Sunburst":
                        {
                            ActivateSunTab( );

                            break;
                        }
                        case "Histogram":
                        {
                            ActivateHistogramTab( );

                            break;
                        }
                        case "Smith":
                        {
                            ActivateSmithTab( );

                            break;
                        }
                        case "Area":
                        {
                            ActivateAreaTab( );

                            break;
                        }
                        case "Scatter":
                        {
                            ActivateScatterTab( );

                            break;
                        }
                        default:
                        {
                            ActivateColumnTab( );

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
        /// Called when [first ComboBox item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnFirstComboBoxItemSelected( object sender, RoutedEventArgs e )
        {
            try
            {
                var _comboBox = sender as MetroComboBox;
                var _selection = _comboBox?.SelectedItem as MetroComboBoxItem;
                _firstCategory = _selection?.Content.ToString( );
                FirstListBox.Items?.Clear( );
                if( !string.IsNullOrEmpty( _firstCategory ) )
                {
                    var _elements = _data.DataElements[ _firstCategory ];
                    foreach( var _name in _elements )
                    {
                        var _item = new MetroListBoxItem
                        {
                            Content = _name,
                            ToolTip = _name.SplitPascal( ),
                            Tag = _name
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

        /// <summary>
        /// Called when [first ListBox item selected].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
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

                    var _selection = _listBox.SelectedItem as MetroListBoxItem;
                    _firstValue = _selection?.Content?.ToString( );
                    _filter.Add( _firstCategory, _firstValue );
                    if( SecondComboBox.Visibility == Visibility.Hidden )
                    {
                        SecondComboBox.Visibility = Visibility.Visible;
                    }

                    if( SecondListBox.Visibility == Visibility.Hidden )
                    {
                        SecondListBox.Visibility = Visibility.Visible;
                    }

                    GetData( );
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
                    _sqlQuery = string.Empty;
                    _secondCategory = string.Empty;
                    _secondValue = string.Empty;
                    var _selection = _comboBox.SelectedItem as MetroComboBoxItem;
                    _secondCategory = _selection?.Content?.ToString( );
                    if( !string.IsNullOrEmpty( _secondCategory ) )
                    {
                        SecondListBox.Items?.Clear( );
                        var _names = _data.DataElements[ _secondCategory ];
                        foreach( var _name in _names )
                        {
                            var _item = new MetroListBoxItem
                            {
                                Content = _name,
                                ToolTip = _name.SplitPascal( ),
                                Tag = _name
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
                    if( _filter.Count > 0 )
                    {
                        _filter.Clear( );
                    }

                    var _item = _listBox.SelectedItem as MetroListBoxItem;
                    _secondValue = _item?.Content?.ToString( );
                    _filter.Add( _firstCategory, _firstValue );
                    _filter.Add( _secondCategory, _secondValue );
                    GetData( );
                    UpdateLabels( );
                    ActivateGroupTab( );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Called when [field ListBox selected value changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnFieldListBoxSelectionChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                _sqlQuery = string.Empty;
                var _listBox = sender as MetroListBox;
                var _item = _listBox?.SelectedItem as MetroListBoxItem;
                var _selectedItem = _item?.Content.ToString( );
                if( !string.IsNullOrEmpty( _selectedItem )
                    && !_selectedFields.Contains( _selectedItem ) )
                {
                    _selectedFields.Add( _selectedItem );
                    _selectedColumns.Add( _selectedItem );
                }

                if( NumericListBox.Visibility == Visibility.Hidden )
                {
                    NumericsLabel.Visibility = Visibility.Visible;
                    NumericListBox.Visibility = Visibility.Visible;
                }

                if( _selectedFields?.Count > 0 )
                {
                    SixthLabel.Visibility = Visibility.Visible;
                    SixthLabel.Content = $"Selected Fields: {_listBox?.SelectedItems?.Count}";
                }
                else
                {
                    SixthLabel.Visibility = Visibility.Hidden;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [numeric ListBox selected value changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnNumericListBoxSelectionChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                _selectedNumerics?.Clear( );
                var _listBox = sender as MetroListBox;
                var _item = _listBox?.SelectedItem as MetroListBoxItem;
                var _selectedItem = _item?.Content.ToString( );
                if( !string.IsNullOrEmpty( _selectedItem ) )
                {
                    _selectedNumerics?.Add( _selectedItem );
                    _selectedColumns.Add( _selectedItem );
                }

                if( _selectedNumerics?.Count > 0 )
                {
                    SeventhLabel.Visibility = Visibility.Visible;
                    SeventhLabel.Content = $"Selected Measures: {_listBox?.SelectedItems?.Count}";
                }
                else
                {
                    SeventhLabel.Visibility = Visibility.Hidden;
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