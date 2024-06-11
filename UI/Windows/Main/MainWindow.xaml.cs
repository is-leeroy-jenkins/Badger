// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 06-02-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        06-02-2024
// ******************************************************************************************
// <copyright file="MainWindow.xaml.cs" company="Terry D. Eppler">
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
//   MainWindow.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using Syncfusion.SfSkinManager;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Messages;
    using ToastNotifications.Position;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "LocalVariableHidesMember" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UseCollectionExpression" ) ]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The path
        /// </summary>
        private protected object _path;

        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The time
        /// </summary>
        private protected int _time;

        /// <summary>
        /// The seconds
        /// </summary>
        private protected int _seconds;

        /// <summary>
        /// The update status
        /// </summary>
        private protected Action _statusUpdate;

        /// <summary>
        /// The tiles
        /// </summary>
        private protected IList<MetroTile> _tiles;

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
        /// <see cref="T:Badger.MainWindow" /> class.
        /// </summary>
        public MainWindow( ) 
            : base( )
        {
            // Theme Properties
            SfSkinManager.ApplyStylesOnApplication = true;
            SfSkinManager.SetTheme( this, new Theme( "FluentDark", App.MetroControls ) );

            // Window Plumbing
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
            ResizeMode = ResizeMode.CanResize;
            FontFamily = new FontFamily( "Segoe UI" );
            FontSize = 12d;
            WindowStyle = WindowStyle.SingleBorderWindow;
            Padding = new Thickness( 1 );
            BorderThickness = new Thickness( 1 );
            Margin = new Thickness( 1 );
            Title = "Budget Execution";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Background = new SolidColorBrush( _backColor );
            Foreground = new SolidColorBrush( _foreColor );
            BorderBrush = new SolidColorBrush( _borderColor );

            // Event Wiring
            Loaded += OnLoaded;
        }

        /// <summary>
        /// Initializes the callbacks.
        /// </summary>
        private void RegisterCallbacks( )
        {
            try
            {
                DataTile.Click += OnDataTileClick;
                ChartTile.Click += OnChartTileClick;
                DocumentTile.Click += OnGuidanceTileClick;
                ExcelTile.Click += OnExcelTileClick;
                EditorTile.Click += OnEditorTileClick;
                MapTile.Click += OnMapTileClick;
                CalendarTile.Click += OnCalendarTileClick;
                EmailTile.Click += OnEmailTileClick;
                ProgramTile.Click += OnProgramTileClick;
                PivotTile.Click += OnPivotTileClick;
                BrowserTile.Click += OnBrowserTileClick;
                TestButton.Click += OnTestButtonClick;
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
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Initializes the text box.
        /// </summary>
        private void InitializeTiles( )
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
            catch( Exception _ex )
            {
                Fail( _ex );
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
        /// Opens the data window.
        /// </summary>
        private void OpenDataWindow( )
        {
            try
            {
                var _dataWindow = new DataWindow( )
                {
                    Owner = this
                };

                _dataWindow.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the chart data form.
        /// </summary>
        private void OpenChartWindow( )
        {
            try
            {
                var _chartWindow = new ChartWindow( )
                {
                    Owner = this
                };

                _chartWindow.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the document viewer.
        /// </summary>
        private void OpenDocumentViewer( )
        {
            try
            {
                var _docViewer = new DocumentWindow( )
                {
                    Owner = this
                };

                _docViewer.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the excel data form.
        /// </summary>
        private void OpenExcelWindow( )
        {
            try
            {
                var _excelWindow = new ExcelWindow( )
                {
                    Owner = this
                };

                _excelWindow.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the SQL editor.
        /// </summary>
        private void OpenSqlWindow( )
        {
            try
            {
                var _sqlWindow = new EditorWindow
                {
                    Owner = this
                };

                _sqlWindow.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the geo mapper.
        /// </summary>
        private void OpenMapWindow( )
        {
            try
            {
                var _form = new MapWindow( )
                {
                    Owner = this
                };

                _form.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the fiscal year form.
        /// </summary>
        private void OpenCalendarWindow( )
        {
            try
            {
                var _form = new CalendarWindow
                {
                    Owner = this
                };

                _form.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Shows the email dialog.
        /// </summary>
        private void OpenEmailWindow( )
        {
            try
            {
                var _form = new EmailWindow( )
                {
                    Owner = this
                };

                _form.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Shows the program project dialog.
        /// </summary>
        private void OpenProgramWindow( )
        {
            try
            {
                var _programs = new ProgramWindow
                {
                    Owner = this
                };

                _programs.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the pivot chart form.
        /// </summary>
        private void OpenPivotWindow( )
        {
            try
            {
                var _pivotWindow = new PivotWindow
                {
                    Owner = this
                };

                _pivotWindow.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the web window.
        /// </summary>
        private void OpenWebWindow( )
        {
            try
            {
                var _programs = new WebWindow( )
                {
                    Owner = this
                };

                _programs.Show( );
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the SQL client.
        /// </summary>
        private void LaunchSqlClient( )
        {
            try
            {
                DataMinion.RunSqlCe( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Creates the excel report.
        /// </summary>
        private void CreateExcelReport( )
        {
            try
            {
                var _data = new DataBuilder( Source.StatusOfAppropriations, Provider.Access );
                var _dataTable = _data.DataTable;
                var _report = new ExcelReport( _dataTable );
                _report.SaveDialog( );
                var _message = "The Excel File has been created!";
                SendNotification( _message );
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
                var _time = TimeSpan.FromSeconds( 3 );
                var _max = MaximumNotificationCount.FromCount( 5 );
                var _position = new PrimaryScreenPositionProvider( Corner.BottomRight, 10, 10 );
                var _lifeTime = new TimeAndCountBasedLifetimeSupervisor( _time, _max );
                return new Notifier( cfg =>
                {
                    cfg.LifetimeSupervisor = _lifeTime;
                    cfg.PositionProvider = _position;
                    cfg.Dispatcher = Application.Current.Dispatcher;
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
                var _notifier = CreateNotifier( );
                _notifier.ShowInformation( message );
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
        /// Gets the tiles.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<MetroTile> GetTiles( )
        {
            try
            {
                _tiles = new List<MetroTile>( );
                return _tiles?.Any( ) == true
                    ? _tiles
                    : Enumerable.Empty<MetroTile>( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IEnumerable<MetroTile> );
            }
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( )
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
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( object state )
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
        /// Called when [load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnLoaded( object sender, EventArgs e )
        {
            try
            {
                App.ActiveWindows.Add( "MainWindow", this );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [data tile click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnDataTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenDataWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        private void OnExcelTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenExcelWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        private void OnMapTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenMapWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [chart tile click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnChartTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenChartWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [program tile click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnProgramTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenProgramWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [editor tile click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnEditorTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenSqlWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [guidance tile click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnGuidanceTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenDocumentViewer( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [calendar tile click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnCalendarTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenCalendarWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [pivot tile click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnPivotTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenPivotWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [email tile click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnEmailTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenEmailWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        private void OnBrowserTileClick( object sender, EventArgs e )
        {
            try
            {
                OpenWebWindow( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [test button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnTestButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "THIS IS A TEST MESSAGE!";
                SendMessage( _message );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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