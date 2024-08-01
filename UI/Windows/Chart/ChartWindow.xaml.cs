// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-01-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-01-2024
// ******************************************************************************************
// <copyright file="ChartWindow.xaml.cs" company="Terry D. Eppler">
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
//   ChartWindow.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using Syncfusion.SfSkinManager;
    using Syncfusion.UI.Xaml.Charts;
    using Syncfusion.UI.Xaml.SmithChart;
    using Syncfusion.Windows.Tools.Controls;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using ScottPlot.Plottables;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Messages;
    using ToastNotifications.Position;
    using LabelPlacement = Syncfusion.UI.Xaml.Charts.LabelPlacement;
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
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MergeConditionalExpression" ) ]
    [ SuppressMessage( "ReSharper", "UnusedVariable" ) ]
    public partial class ChartWindow : Window, IDisposable
    {
        /// <summary>
        /// 
        /// The busy
        /// </summary>
        private bool _busy;

        /// <summary>
        /// The locked object
        /// </summary>
        private object _path;

        /// <summary>
        /// The status update
        /// </summary>
        private Action _statusUpdate;

        /// <summary>
        /// 
        /// </summary>
        private protected IList<string> _columns;

        /// <summary>
        /// The count
        /// </summary>
        private protected int _count;

        /// <summary>
        /// The current
        /// </summary>
        private protected int _current;

        /// <summary>
        /// The fields
        /// </summary>
        private protected IList<string> _fields;

        /// <summary>
        /// The filter
        /// </summary>
        private protected IDictionary<string, object> _filter;

        /// <summary>
        /// The first category
        /// </summary>
        private protected string _firstCategory;

        /// <summary>
        /// The first value
        /// </summary>
        private protected string _firstValue;

        /// <summary>
        /// The hover text
        /// </summary>
        private protected string _hoverText;

        /// <summary>
        /// The stat
        /// </summary>
        private protected STAT _metric;

        /// <summary>
        /// The numerics
        /// </summary>
        private protected IList<string> _numerics;

        /// <summary>
        /// The second category
        /// </summary>
        private protected string _secondCategory;

        /// <summary>
        /// The second value
        /// </summary>
        private protected string _secondValue;

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
        /// The selected table
        /// </summary>
        private protected string _selectedTable;

        /// <summary>
        /// The SQL command
        /// </summary>
        private protected string _sqlQuery;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The data model
        /// </summary>
        private protected DataGenerator _data;

        /// <summary>
        /// The data table
        /// </summary>
        private protected DataTable _dataTable;

        /// <summary>
        /// The current
        /// </summary>
        private protected DataRow _record;

        /// <summary>
        /// The data source
        /// </summary>
        private protected ChartModel _chartModel;

        /// <summary>
        /// The data metric
        /// </summary>
        private protected DataMeasure _dataMetric;

        /// <summary>
        /// The histogram
        /// </summary>
        private protected Histogram _histogram;

        /// <summary>
        /// The scatter chart
        /// </summary>
        private protected MetroScatterChart _scatterChart;

        /// <summary>
        /// The line chart
        /// </summary>
        private protected MetroLineChart _lineChart;

        /// <summary>
        /// The line chart
        /// </summary>
        private protected MetroColumnChart _columnChart;

        /// <summary>
        /// The area chart
        /// </summary>
        private protected MetroAreaChart _areaChart;

        /// <summary>
        /// The pie chart
        /// </summary>
        private protected MetroPieChart _pieChart;

        /// <summary>
        /// The sunburst chart
        /// </summary>
        private protected SunburstChart _sunburstChart;

        /// <summary>
        /// The surface chart
        /// </summary>
        private protected SurfaceChart _surfaceChart;

        /// <summary>
        /// The smith chart
        /// </summary>
        private protected SmithChart _smithChart;

        /// <summary>
        /// The theme
        /// </summary>
        private protected readonly DarkMode _theme = new DarkMode( );

        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// The timer
        /// </summary>
        private protected TimerCallback _timerCallback;

        /// <summary>
        /// Gets the data source.
        /// </summary>
        /// <value>
        /// The data source.
        /// </value>
        public ChartModel ChartModel
        {
            get
            {
                return _chartModel;
            }
            set
            {
                _chartModel = value;
            }
        }

        /// <summary>
        /// Gets a value indicating
        /// whether this instance is busy.
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
            Width = _theme.Width;
            MinWidth = _theme.MinWidth;
            MaxWidth = _theme.MaxWidth;
            Height = _theme.Height;
            MinHeight = _theme.MinHeight;
            MaxHeight = _theme.MaxHeight;
            ResizeMode = _theme.SizeMode;
            FontFamily = _theme.FontFamily;
            FontSize = _theme.FontSize;
            Padding = _theme.Padding;
            BorderThickness = _theme.BorderThickness;
            WindowStyle = _theme.WindowStyle;
            WindowStartupLocation = _theme.StartLocation;
            Background = _theme.BackColor;
            Foreground = _theme.ForeColor;
            BorderBrush = _theme.BorderColor;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Bottom;
            Title = "Visualization";

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
                ColumnChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Column Chart";

                ColumnChart.Height = 454;
                ColumnChart.Width = 800;
                ColumnChart.Visibility = Visibility.Visible;
                ColumnChart.IsEnabled = true;
                ColumnChart.Margin = new Thickness( 0 );
                ColumnChart.Background = _theme.BackColor;
                ColumnChart.RightWallBrush = _theme.WallColor;
                ColumnChart.LeftWallBrush = _theme.WallColor;
                ColumnChart.BackWallBrush = _theme.WallColor;
                ColumnChart.TopWallBrush = _theme.WallColor;
                ColumnChart.BottomWallBrush = _theme.BlackColor;
                ColumnChart.BorderBrush = _theme.BorderColor;
                ColumnChart.Foreground = _theme.ForeColor;
                ColumnChart.FontFamily = _theme.FontFamily;
                ColumnChart.FontSize = _theme.FontSize;
                ColumnChart.SideBySideSeriesPlacement = true;
                ColumnChart.EnableRotation = true;
                ColumnChart.Depth = 250;
                ColumnChart.EnableSegmentSelection = true;
                ColumnChart.EnableSeriesSelection = true;
                ColumnChart.EnableRotation = true;
                ColumnChart.PerspectiveAngle = 100;
                ColumnChart.Padding = _theme.Padding;
                ColumnChart.PrimaryAxis = CreateCategoricalAxis( );
                ColumnChart.SecondaryAxis = CreateNumericalAxis( );
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
                PieChart.Series?.Clear( );
                PieChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Pie Chart";

                PieChart.Height = 454;
                PieChart.Width = 800;
                PieChart.Visibility = Visibility.Visible;
                PieChart.IsEnabled = true;
                PieChart.Margin = new Thickness( 0 );
                PieChart.RightWallBrush = _theme.WallColor;
                PieChart.LeftWallBrush = _theme.WallColor;
                PieChart.BackWallBrush = _theme.WallColor;
                PieChart.TopWallBrush = _theme.WallColor;
                PieChart.BottomWallBrush = _theme.BlackColor;
                PieChart.BorderBrush = _theme.BorderColor;
                PieChart.Foreground = _theme.ForeColor;
                PieChart.Background = _theme.BackColor;
                PieChart.FontFamily = _theme.FontFamily;
                PieChart.FontSize = _theme.FontSize;
                PieChart.SideBySideSeriesPlacement = true;
                PieChart.EnableRotation = true;
                PieChart.Depth = 250;
                PieChart.EnableSegmentSelection = true;
                PieChart.EnableSeriesSelection = true;
                PieChart.EnableRotation = true;
                PieChart.PerspectiveAngle = 100;
                PieChart.Padding = _theme.Padding;
                PieChart.PrimaryAxis = CreateCategoricalAxis( );
                PieChart.SecondaryAxis = CreateNumericalAxis( );
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
                SunburstChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Sunburst Chart";

                SunburstChart.Height = 454;
                SunburstChart.Width = 800;
                SunburstChart.Visibility = Visibility.Visible;
                SunburstChart.IsEnabled = true;
                SunburstChart.Margin = new Thickness( 0 );
                SunburstChart.BorderBrush = _theme.BorderColor;
                SunburstChart.Foreground = _theme.ForeColor;
                SunburstChart.Background = _theme.BackColor;
                SunburstChart.FontFamily = _theme.FontFamily;
                SunburstChart.FontSize = _theme.FontSize;
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
                SmithChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Smith Chart";

                SmithChart.Height = 454;
                SmithChart.Width = 800;
                SmithChart.Background = _theme.BackColor;
                SmithChart.Foreground = _theme.ForeColor;
                SmithChart.BorderBrush = _theme.BorderColor;
                SmithChart.Visibility = Visibility.Visible;
                SmithChart.Margin = new Thickness( 0 );
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
                AreaChart.Series?.Clear( );
                AreaChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Area Chart";

                AreaChart.Height = 454;
                AreaChart.Width = 800;
                AreaChart.Visibility = Visibility.Visible;
                AreaChart.IsEnabled = true;
                AreaChart.Margin = new Thickness( 0 );
                AreaChart.RightWallBrush = _theme.WallColor;
                AreaChart.LeftWallBrush = _theme.WallColor;
                AreaChart.BackWallBrush = _theme.WallColor;
                AreaChart.TopWallBrush = _theme.WallColor;
                AreaChart.BottomWallBrush = _theme.BlackColor;
                AreaChart.BorderBrush = _theme.BorderColor;
                AreaChart.Foreground = _theme.ForeColor;
                AreaChart.Background = _theme.BackColor;
                AreaChart.FontFamily = _theme.FontFamily;
                AreaChart.FontSize = _theme.FontSize;
                AreaChart.SideBySideSeriesPlacement = true;
                AreaChart.EnableRotation = true;
                AreaChart.Depth = 250;
                AreaChart.EnableSegmentSelection = true;
                AreaChart.EnableSeriesSelection = true;
                AreaChart.EnableRotation = true;
                AreaChart.PerspectiveAngle = 100;
                AreaChart.Padding = _theme.Padding;
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
                Histogram.Height = 454;
                Histogram.Width = 800;
                Histogram.Visibility = Visibility.Visible;
                Histogram.IsEnabled = true;
                Histogram.Margin = new Thickness( 0 );
                Histogram.RightWallBrush = _theme.WallColor;
                Histogram.LeftWallBrush = _theme.WallColor;
                Histogram.BackWallBrush = _theme.WallColor;
                Histogram.TopWallBrush = _theme.WallColor;
                Histogram.BottomWallBrush = _theme.BlackColor;
                Histogram.BorderBrush = _theme.BorderColor;
                Histogram.Foreground = _theme.ForeColor;
                Histogram.Background = _theme.BackColor;
                Histogram.FontFamily = _theme.FontFamily;
                Histogram.FontSize = _theme.FontSize;
                Histogram.SideBySideSeriesPlacement = true;
                Histogram.EnableRotation = true;
                Histogram.Depth = 250;
                Histogram.EnableSegmentSelection = true;
                Histogram.EnableSeriesSelection = true;
                Histogram.EnableRotation = true;
                Histogram.PerspectiveAngle = 100;
                Histogram.Padding = _theme.Padding;
                Histogram.Series?.Clear( );
                Histogram.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Histogram Chart";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the line chart.
        /// </summary>
        private void InitializeLineChart( )
        {
            try
            {
                LineChart.Height = 454;
                LineChart.Width = 800;
                LineChart.Visibility = Visibility.Visible;
                LineChart.IsEnabled = true;
                LineChart.Margin = new Thickness( 0 );
                LineChart.RightWallBrush = _theme.WallColor;
                LineChart.LeftWallBrush = _theme.WallColor;
                LineChart.BackWallBrush = _theme.WallColor;
                LineChart.TopWallBrush = _theme.WallColor;
                LineChart.BottomWallBrush = _theme.BlackColor;
                LineChart.BorderBrush = _theme.BorderColor;
                LineChart.Foreground = _theme.ForeColor;
                LineChart.Background = _theme.BackColor;
                LineChart.FontFamily = _theme.FontFamily;
                LineChart.FontSize = _theme.FontSize;
                LineChart.SideBySideSeriesPlacement = true;
                LineChart.EnableRotation = true;
                LineChart.Depth = 250;
                LineChart.EnableSegmentSelection = true;
                LineChart.EnableSeriesSelection = true;
                LineChart.EnableRotation = true;
                LineChart.PerspectiveAngle = 100;
                LineChart.Padding = _theme.Padding;
                LineChart.Series?.Clear( );
                LineChart.Header = ( _dataTable != null )
                    ? _dataTable.TableName.SplitPascal( )
                    : "Line Chart";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the scatter chart.
        /// </summary>
        private void InitializeScatterChart( )
        {
            try
            {
                ScatterChart.Height = 454;
                ScatterChart.Width = 800;
                ScatterChart.Visibility = Visibility.Visible;
                ScatterChart.IsEnabled = true;
                ScatterChart.Margin = new Thickness( 0 );
                ScatterChart.RightWallBrush = _theme.WallColor;
                ScatterChart.LeftWallBrush = _theme.WallColor;
                ScatterChart.BackWallBrush = _theme.WallColor;
                ScatterChart.TopWallBrush = _theme.WallColor;
                ScatterChart.BottomWallBrush = _theme.BlackColor;
                ScatterChart.BorderBrush = _theme.BorderColor;
                ScatterChart.Foreground = _theme.ForeColor;
                ScatterChart.Background = _theme.BackColor;
                ScatterChart.FontFamily = _theme.FontFamily;
                ScatterChart.FontSize = _theme.FontSize;
                ScatterChart.SideBySideSeriesPlacement = true;
                ScatterChart.EnableRotation = true;
                ScatterChart.Depth = 250;
                ScatterChart.EnableSegmentSelection = true;
                ScatterChart.EnableSeriesSelection = true;
                ScatterChart.EnableRotation = true;
                ScatterChart.PerspectiveAngle = 100;
                ScatterChart.Padding = _theme.Padding;
                ScatterChart.Series?.Clear( );
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
                FieldsLabel.Foreground = _theme.BorderColor;
                NumericsLabel.Foreground = _theme.BorderColor;
                FirstDateLabel.Foreground = _theme.BorderColor;
                SecondDateLabel.Foreground = _theme.BorderColor;
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
        /// Initializes the tab controls.
        /// </summary>
        private void InitializeTabControls( )
        {
            try
            {
                ColumnTab.IsSelected = true;
                SourceTab.IsSelected = true;
                ColumnTab.Visibility = Visibility.Hidden;
                LineTab.Visibility = Visibility.Hidden;
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
        /// Binds the context.
        /// </summary>
        private protected void Requery( )
        {
            try
            {
                _data = ( _filter?.Count > 0 )
                    ? new DataGenerator( _source, _provider, _filter )
                    : new DataGenerator( _source, _provider );

                _dataTable = _data.DataTable;
                _columns = _data.ColumnNames;
                _fields = _data.Fields;
                _numerics = _data.Numerics;
                _dataMetric = new DataMeasure( _dataTable );
                _chartModel = new ChartModel( _dataTable );
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
                    return "SELECT *"
                        + $"FROM {_selectedTable} "
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
                    foreach( var _field in fields )
                    {
                        _cols += $"{_field}, ";
                    }

                    foreach( var _name in numerics )
                    {
                        _aggr += $"SUM({_name}) AS {_name}, ";
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
        /// Creates the adornment.
        /// </summary>
        /// <returns>
        /// ChartAdornmentInfo3D
        /// </returns>
        private ChartAdornmentInfo3D CreateAdornmentInfo( )
        {
            try
            {
                var _adornment = new ChartAdornmentInfo3D
                {
                    ShowLabel = true,
                    ShowMarker = true,
                    ShowConnectorLine = true,
                    FontSize = 10,
                    AdornmentsPosition = AdornmentsPosition.Top,
                    LabelPosition = AdornmentsLabelPosition.Outer,
                    LabelRotationAngle = 0,
                    UseSeriesPalette = false,
                    BorderThickness = _theme.BorderThickness,
                    HighlightOnSelection = true,
                    ConnectorRotationAngle = 45,
                    Symbol = ChartSymbol.Diamond,
                    SymbolInterior = _theme.LightBlueColor,
                    SymbolHeight = 8,
                    BorderBrush = _theme.BorderColor,
                    Foreground = _theme.ForeColor,
                    Background = _theme.ControlColor
                };

                return _adornment;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ChartAdornmentInfo3D );
            }
        }

        /// <summary>
        /// Creates the adornment.
        /// </summary>
        /// <returns></returns>
        private protected ChartAdornment3D CreateAdornment( )
        {
            try
            {
                var _adornment = new ChartAdornment3D
                {
                    FontSize = 10,
                    FontFamily = _theme.FontFamily,
                    BorderThickness = _theme.BorderThickness,
                    ConnectorRotationAngle = 45,
                    BorderBrush = _theme.BorderColor,
                    Foreground = _theme.LightBlueColor,
                    Background = _theme.ControlColor,
                    Stroke = _theme.SteelBlueColor
                };

                return _adornment;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ChartAdornment3D );
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
        /// Creates the view model.
        /// </summary>
        /// <returns></returns>
        private ViewModel CreateViewModel( )
        {
            try
            {
                if( _dataTable != null
                    && _numerics?.Count > 0 )
                {
                    var _viewModel = new ViewModel( );
                    var _rows = _dataTable.Rows.Count;
                    for( var _index = 0; _index < _rows; _index++ )
                    {
                        var _row = _dataTable.Rows[ _index ];
                        var _dimension = _fields[ 0 ];
                        for( var _i = 0; _i < _numerics.Count; _i++ )
                        {
                            var _measure = _numerics[ _i ];
                            var _value = double.Parse( _row[ _measure ]?.ToString( ) );
                            var _view = new View( _index, _dimension, _measure, _value );
                            _viewModel.Add( _view );
                        }
                    }

                    return _viewModel;
                }

                return default( ViewModel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ViewModel );
            }
        }

        /// <summary>
        /// Creates the categorical axis3 d.
        /// </summary>
        /// <returns>
        /// </returns>
        private CategoryAxis3D CreateCategoricalAxis( )
        {
            try
            {
                var _categoricalAxis = new CategoryAxis3D
                {
                    FontSize = 10,
                    ShowOrigin = true,
                    Header = "X-Axis",
                    Interval = 10,
                    IsIndexed = true,
                    IsEnabled = true,
                    LabelPlacement = LabelPlacement.OnTicks,
                    TickLinesPosition = AxisElementPosition.Outside,
                    Name = "Dimension",
                    Foreground = _theme.BorderColor,
                    ShowGridLines = true
                };

                return ( _categoricalAxis != null )
                    ? _categoricalAxis
                    : default( CategoryAxis3D );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( CategoryAxis3D );
            }
        }

        /// <summary>
        /// Creates the numerical axis.
        /// </summary>
        /// <returns>
        /// NumericalAxis3D 
        /// </returns>
        private NumericalAxis3D CreateNumericalAxis( )
        {
            try
            {
                var _numericalAxis = new NumericalAxis3D
                {
                    FontSize = 10,
                    ShowOrigin = true,
                    Header = "Y-Axis",
                    Interval = 1,
                    Name = "Measure",
                    IsEnabled = true,
                    TickLinesPosition = AxisElementPosition.Outside,
                    Foreground = _theme.BorderColor,
                    ShowGridLines = true
                };

                return _numericalAxis;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( NumericalAxis3D );
            }
        }

        /// <summary>
        /// Clears the combo boxes.
        /// </summary>
        private void ClearComboBoxes( )
        {
            try
            {
                FirstComboBox.SelectedIndex = -1;
                SecondComboBox.SelectedIndex = -1;
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
                FieldListBox.SelectedItems?.Clear( );
                NumericListBox.Items?.Clear( );
                NumericListBox.SelectedItems?.Clear( );
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
                if( _filter.Count > 0 )
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
                SecondLabel.Content = "Total Records: 0.0";
                ThirdLabel.Content = "Total Fields: 0.0";
                FourthLabel.Content = "Total Measures: 0.0";
                FifthLabel.Content = "Selected Filters: 0.0";
                SixthLabel.Content = "Selected Fields: 0.0";
                SeventhLabel.Content = "Selected Numerics: 0.0";
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
                _chartModel = null;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
        /// Hides the tab items.
        /// </summary>
        private void HideTabItems( )
        {
            try
            {
                HistogramTab.Visibility = Visibility.Hidden;
                ScatterTab.Visibility = Visibility.Hidden;
                ColumnTab.Visibility = Visibility.Hidden;
                PieTab.Visibility = Visibility.Hidden;
                SunTab.Visibility = Visibility.Hidden;
                SmithTab.Visibility = Visibility.Hidden;
                AreaTab.Visibility = Visibility.Hidden;
                BusyTab.Visibility = Visibility.Hidden;
                SourceTab.Visibility = Visibility.Hidden;
                FilterTab.Visibility = Visibility.Hidden;
                GroupTab.Visibility = Visibility.Hidden;
                CalendarTab.Visibility = Visibility.Hidden;
                MetricsTab.Visibility = Visibility.Hidden;
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
        private void PopulateFirstComboBoxItems( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    FirstComboBox.Items?.Clear( );
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
        private void PopulateSecondComboBoxItems( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    SecondComboBox.Items?.Clear( );
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

                    DataTableListBox.SelectionMode = SelectionMode.Single;
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
        private void PopulateFieldCheckListBox( )
        {
            if( _fields?.Any( ) == true )
            {
                try
                {
                    if( FieldListBox.Items.Count > 0 )
                    {
                        FieldListBox.Items.Clear( );
                    }

                    for( var _col = 0; _col < _fields.Count; _col++ )
                    {
                        var _name = _fields[ _col ];
                        var _item = new MetroCheckListItem
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
        private void PopulateNumericsCheckListBox( )
        {
            if( _numerics?.Any( ) == true )
            {
                try
                {
                    if( NumericListBox.Items.Count > 0 )
                    {
                        NumericListBox.Items.Clear( );
                    }

                    for( var _col = 0; _col < _numerics.Count; _col++ )
                    {
                        var _name = _numerics[ _col ];
                        if( !string.IsNullOrEmpty( _numerics[ _col ] ) )
                        {
                            var _item = new MetroCheckListItem
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
                InitializeColumnChart( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the line tab.
        /// </summary>
        private void ActivateLineTab( )
        {
            try
            {
                LineTab.IsSelected = true;
                InitializeLineChart( );
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
                InitializePieChart( );
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
                InitializeSunburstChart( );
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
                InitializeSmithChart( );
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
                InitializeSmithChart( );
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
                InitializeScatterChart( );
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
                InitializeHistogram( );
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
                FilterTab.IsSelected = true;
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
                PopulateFieldCheckListBox( );
                PopulateNumericsCheckListBox( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the calendar tab.
        /// </summary>
        private void ActivateCalendarTab( )
        {
            try
            {
                CalendarTab.IsSelected = true;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Activates the metrics tab.
        /// </summary>
        private void ActivateMetricsTab( )
        {
            try
            {
                MetricsTab.IsSelected = true;
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
        /// 
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
                    FifthLabel.Content = _filter?.Count > 0
                        ? $"Selected Filters: {_filter.Count}"
                        : "Selected Filters: 0.0";

                    SixthLabel.Content = _selectedFields?.Count > 0
                        ? $"Selected Fields: {_selectedFields?.Count}"
                        : "Selected Fields: 0.0";

                    SeventhLabel.Content = _selectedNumerics?.Count > 0
                        ? $"Selected Numerics: {_selectedNumerics?.Count}"
                        : "Selected Numerics: 0.0";
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
        /// Binds the column chart.
        /// </summary>
        private protected void SetColumnConfiguration( )
        {
            try
            {
                if( _dataTable != null )
                {
                    ColumnChart.Series?.Clear( );
                    for( var _row = 0; _row < _chartModel.Rows.Count; _row++ )
                    {
                        var _dimension = _columns[ 0 ];
                        for( var _col = 0; _col < _numerics.Count; _col++ )
                        {
                            var _measure = _numerics[ _col ];
                            var _series = new ColumnSeries3D
                            {
                                ItemsSource = _chartModel.Items,
                                XBindingPath = _dimension,
                                YBindingPath = _measure,
                                EnableAnimation = true,
                                FontSize = 10,
                                Label = _measure,
                                ShowEmptyPoints = true,
                                Interior = _theme.Color[ 0 ],
                                AdornmentsInfo = CreateAdornmentInfo( ),
                                ShowTooltip = true,
                                SegmentSpacing = .25,
                                IsSeriesVisible = true
                            };

                            ColumnChart.Series?.Add( _series );
                        }
                    }
                }
                else
                {
                    ColumnChart.Series?.Clear( );
                    var _series = new ColumnSeries3D
                    {
                        EnableAnimation = true,
                        FontSize = 10,
                        ShowEmptyPoints = true,
                        Interior = _theme.Color[ 0 ],
                        AdornmentsInfo = CreateAdornmentInfo( ),
                        ShowTooltip = true,
                        SegmentSpacing = .25,
                        IsSeriesVisible = true
                    };

                    ColumnChart.Series?.Add( _series );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the line configuration.
        /// </summary>
        private protected void SetLineConfiguration( )
        {
            try
            {
                if( _dataTable != null )
                {
                    var _series = new LineSeries3D
                    {
                        ItemsSource = _dataTable.ToBindingList( ),
                        XBindingPath = _columns[ 0 ],
                        YBindingPath = _numerics[ 0 ],
                        EnableAnimation = true,
                        Label = _numerics[ 0 ],
                        ShowEmptyPoints = true,
                        Interior = _theme.SteelBlueColor,
                        AdornmentsInfo = CreateAdornmentInfo( ),
                        ShowTooltip = true,
                        IsSeriesVisible = true
                    };

                    _lineChart.Series?.Add( _series );
                }
                else
                {
                    var _series = new LineSeries3D
                    {
                        EnableAnimation = true,
                        ShowEmptyPoints = true,
                        Interior = _theme.SteelBlueColor,
                        AdornmentsInfo = CreateAdornmentInfo( ),
                        ShowTooltip = true,
                        IsSeriesVisible = true
                    };

                    _lineChart.Series?.Add( _series );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the pie configuration.
        /// </summary>
        private protected void SetPieConfiguration( )
        {
            try
            {
                if( _dataTable != null )
                {
                    _pieChart.Series?.Clear( );
                    var _series = new PieSeries3D
                    {
                        ItemsSource = _dataTable,
                        XBindingPath = _columns[ 0 ],
                        YBindingPath = _numerics[ 0 ],
                        EnableAnimation = true,
                        Label = _numerics[ 0 ],
                        ShowEmptyPoints = true,
                        Interior = _theme.SteelBlueColor,
                        AdornmentsInfo = CreateAdornmentInfo( ),
                        ShowTooltip = true,
                        IsSeriesVisible = true
                    };

                    _pieChart.Series?.Add( _series );
                }
                else
                {
                    var _series = new PieSeries3D
                    {
                        EnableAnimation = true,
                        ShowEmptyPoints = true,
                        Interior = _theme.SteelBlueColor,
                        AdornmentsInfo = CreateAdornmentInfo( ),
                        ShowTooltip = true,
                        IsSeriesVisible = true
                    };

                    _pieChart.Series?.Add( _series );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the scatter configuration.
        /// </summary>
        private protected void SetScatterConfiguration( )
        {
            try
            {
                if( _dataTable != null )
                {
                    _scatterChart.Series?.Clear( );
                    foreach( DataRow _row in _dataTable.Rows )
                    {
                        var _series = new ScatterSeries3D
                        {
                            ItemsSource = _row,
                            XBindingPath = _columns[ 0 ],
                            YBindingPath = _numerics[ 0 ],
                            EnableAnimation = true,
                            Label = _numerics[ 0 ],
                            ShowEmptyPoints = true,
                            Interior = _theme.SteelBlueColor,
                            AdornmentsInfo = CreateAdornmentInfo( ),
                            ShowTooltip = true
                        };

                        _scatterChart.Series?.Add( _series );
                    }
                }
                else
                {
                    var _series = new ScatterSeries3D
                    {
                        EnableAnimation = true,
                        ShowEmptyPoints = true,
                        Interior = _theme.SteelBlueColor,
                        AdornmentsInfo = CreateAdornmentInfo( ),
                        ShowTooltip = true,
                        Visibility = Visibility.Visible
                    };

                    _scatterChart.Series?.Add( _series );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the area configuration.
        /// </summary>
        private protected void SetAreaConfiguration( )
        {
            try
            {
                if( _dataTable != null )
                {
                    _areaChart.Series?.Clear( );
                    var _series = new AreaSeries3D
                    {
                        ItemsSource = _chartModel.Items,
                        XBindingPath = _columns[ 0 ],
                        YBindingPath = _numerics[ 0 ],
                        EnableAnimation = true,
                        Label = _numerics[ 0 ],
                        ShowEmptyPoints = true,
                        Interior = _theme.SteelBlueColor,
                        Area =
                        {
                            BackWallBrush = _theme.WallColor,
                            BottomWallBrush = _theme.BlackColor,
                            Depth = _areaChart.Depth
                        },
                        AdornmentsInfo = CreateAdornmentInfo( ),
                        ShowTooltip = true
                    };

                    _areaChart.Series?.Add( _series );
                }
                else
                {
                    var _series = new AreaSeries3D
                    {
                        EnableAnimation = true,
                        ShowEmptyPoints = true,
                        Interior = _theme.SteelBlueColor,
                        AdornmentsInfo = CreateAdornmentInfo( ),
                        ShowTooltip = true,
                        Visibility = Visibility.Visible
                    };

                    _areaChart.Series?.Add( _series );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the surface configuration.
        /// </summary>
        private protected void SetSurfaceConfiguration( )
        {
            try
            {
                if( _dataTable != null )
                {
                    var _xAxis = new SurfaceAxis( );
                    _surfaceChart.XAxis = _xAxis;
                    var _yAxis = new SurfaceAxis( );
                    _surfaceChart.YAxis = _yAxis;
                }
                else
                {
                    var _xAxis = new SurfaceAxis( );
                    _surfaceChart.XAxis = _xAxis;
                    var _yAxis = new SurfaceAxis( );
                    _surfaceChart.YAxis = _yAxis;
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
                PopulateExecutionTables( );
                UpdateLabels( );
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
                if( _dataTable == null )
                {
                    var _message = "Verify data table!";
                    SendMessage( _message );
                }
                else
                {
                    _record = _dataTable.Rows[ Index.Start ];
                    _current = _dataTable.Rows.IndexOf( _record );
                }
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
                if( _dataTable == null )
                {
                    var _message = "Verify data table!";
                    SendMessage( _message );
                }
                else
                {
                    _current -= 1;
                    _record = _dataTable.Rows[ _current ];
                }
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
                if( _dataTable == null )
                {
                    var _message = "Verify data table!";
                    SendMessage( _message );
                }
                else
                {
                    _current += 1;
                    _record = _dataTable.Rows[ _current ];
                }
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
                if( _dataTable == null )
                {
                    var _message = "Verify data table!";
                    SendMessage( _message );
                }
                else
                {
                    _record = _dataTable.Rows[ Index.End ];
                    _current = _dataTable.Rows.IndexOf( _record );
                }
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
                var _fileBrowser = new FileBrowser
                {
                    Owner = this
                };

                _fileBrowser.Show( );
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
                FilterTab.IsSelected = true;
                _filter?.Clear( );
                _selectedNumerics?.Clear( );
                _selectedFields?.Clear( );
                _selectedColumns?.Clear( );
                Requery( );
                UpdateLabels( );
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
                if( _dataTable == null )
                {
                    var _message = "Verify data table!";
                    SendMessage( _message );
                }
                else
                {
                    FilterTab.IsSelected = true;
                }
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnDataSourceButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                SourceTab.IsSelected = true;
                ClearData( );
                ClearFilters( );
                ClearSelections( );
                ClearCollections( );
                UpdateLabels( );
                Requery( );
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
                if( _dataTable == null )
                {
                    var _message = "Verify a data table!";
                    SendMessage( _message );
                }
                else
                {
                    GroupTab.IsSelected = true;
                }
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
                        _columnChart.Header = _title;
                    }

                    Requery( );
                    SetColumnConfiguration( );
                    ActivateFilterTab( );
                    UpdateLabels( );
                    ShowToolbar( );
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
                        case "Line":
                        {
                            ActivateLineTab( );
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

                    PopulateSecondComboBoxItems( );
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

                    Requery( );
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
                    Requery( );
                    SetColumnConfiguration( );
                    ActivateGroupTab( );
                    UpdateLabels( );
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
        /// <param name = "e" > </param>
        private void OnFieldCheckListItemChecked( object sender, ItemCheckedEventArgs e )
        {
            try
            {
                _selectedFields?.Clear( );
                var _listBox = sender as MetroCheckList;
                if( _listBox?.SelectedItems.Count > 0 )
                {
                    foreach( var _listItem in _listBox.SelectedItems )
                    {
                        var _item = _listItem as MetroCheckListItem;
                        var _name = _item?.Content?.ToString( );
                        _selectedFields?.Add( _name );
                    }

                    SixthLabel.Visibility = Visibility.Visible;
                    SixthLabel.Content = $"Selected Fields: {_selectedFields?.Count}";
                }
                else
                {
                    SixthLabel.Visibility = Visibility.Hidden;
                }

                NumericsLabel.Visibility = Visibility.Visible;
                NumericListBox.Visibility = Visibility.Visible;
                Requery( );
                UpdateLabels( );
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
        /// <param name = "e" > </param>
        private void OnNumericCheckListItemChecked( object sender, ItemCheckedEventArgs e )
        {
            try
            {
                _selectedNumerics?.Clear( );
                var _listBox = sender as MetroCheckList;
                if( _listBox?.SelectedItems.Count > 0 )
                {
                    foreach( MetroCheckListItem _listItem in _listBox.SelectedItems )
                    {
                        var _name = _listItem?.Content?.ToString( );
                        _selectedNumerics?.Add( _name );
                    }

                    SeventhLabel.Visibility = Visibility.Visible;
                    SeventhLabel.Content =
                        $"Selected Measures: {_selectedNumerics?.Count}";
                }
                else
                {
                    SeventhLabel.Visibility = Visibility.Hidden;
                }

                Requery( );
                UpdateLabels( );
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
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
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
                _columnChart?.Dispose( );
                _lineChart?.Dispose( );
                _scatterChart?.Dispose( );
                _pieChart?.Dispose( );
                _sunburstChart?.Dispose( );
                _smithChart?.Dispose( );
                _histogram?.Dispose( );
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