// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 05-25-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-25-2024
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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The tiles
        /// </summary>
        private IList<ButtonTile> _tiles;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MainWindow" /> class.
        /// </summary>
        public MainWindow( )
        {
            InitializeComponent( );
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
                Dispatcher.BeginInvoke( action );
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
        private void OpenExcelForm( )
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
        private void OpenSqlEditor( )
        {
            try
            {
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
        private void OpenGeoMapper( )
        {
            try
            {
                Hide( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Opens the SQL server editor.
        /// </summary>
        private void OpenSqlServerEditor( )
        {
            try
            {
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
        private void OpenProgramProjectWindow( )
        {
            try
            {
                var _programs = new ProgramProjectWindow
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
                var _pivotChart = new PivotWindow
                {
                    Owner = this
                };

                _pivotChart.Show( );
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
        /// Creates the excel report.
        /// </summary>
        private void CreateExcelReport( )
        {
            try
            {
                var _data = new DataBuilder( Source.StatusOfAppropriations, Provider.Access );
                var _dataTable = _data.DataTable;

                //var _report = new ExcelReport( _dataTable );
                //_report.SaveDialog( );
                var _message = "The Excel File has been created!";
                SendNotification( _message );
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
        private IEnumerable<ButtonTile> GetTiles( )
        {
            try
            {
                var _tiles = new List<ButtonTile>( );
                return _tiles?.Any( ) == true
                    ? _tiles
                    : Enumerable.Empty<ButtonTile>( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IEnumerable<ButtonTile> );
            }
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void OnLoaded( object sender, EventArgs e )
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

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            var _error = new ErrorDialog( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}