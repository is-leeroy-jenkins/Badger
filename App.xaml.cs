// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-23-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-23-2024
// ******************************************************************************************
// <copyright file="App.xaml.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
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
//   App.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using CefSharp;
    using CefSharp.Wpf;
    using OfficeOpenXml;
    using RestoreWindowPlace;
    using Syncfusion.Licensing;
    using Syncfusion.SfSkinManager;
    using Syncfusion.Themes.FluentDark.WPF;
    using Properties;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "UseCollectionExpression" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public partial class App : Application
    {
        /// <summary>
        /// The window place
        /// </summary>
        private WindowPlace _windowPlace;

        /// <summary>
        /// The controls
        /// </summary>
        public static string[ ] Controls =
        {
            "ComboBoxAdv",
            "MetroComboBox",
            "MetroDatagrid",
            "SfDataGrid",
            "ToolBarAdv",
            "ToolStrip",
            "MetroCalendar",
            "CalendarEdit",
            "PivotGridControl",
            "MetroPivotGrid",
            "SfChart",
            "SfChart3D",
            "SfHeatMap",
            "SfMap",
            "MetroMap",
            "EditControl",
            "CheckListBox",
            "MetroEditor",
            "DropDownButtonAdv",
            "MetroDropDown",
            "TextBoxExt",
            "SfCircularProgressBar",
            "SfLinearProgressBar",
            "GridControl",
            "MetroGridControl",
            "TabControlExt",
            "MetroTabControl",
            "SfTextInputLayout",
            "MetroTextInput",
            "SfSpreadsheet",
            "SfSpreadsheetRibbon",
            "MenuItemAdv",
            "ButtonAdv",
            "Carousel",
            "ColorEdit",
            "SfCalculator",
            "SfMultiColumnDropDownControl"
        };

        /// <summary>
        /// Gets or sets the main window handle.
        /// </summary>
        /// <value>
        /// The main window handle.
        /// </value>
        public static IntPtr MainWindowHandle { get; set; }

        /// <summary>
        /// Gets or sets the windows.
        /// </summary>
        /// <value>
        /// The windows.
        /// </value>
        public static IDictionary<string, Window> ActiveWindows { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.App" /> class.
        /// </summary>
        public App( )
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            var _key = ConfigurationManager.AppSettings[ "UI" ];
            SyncfusionLicenseProvider.RegisterLicense( _key );
            OpenAiKey = Environment.GetEnvironmentVariable( "OPENAI_API_KEY" );
            GoogleKey = Environment.GetEnvironmentVariable( "GOOGLE_API_KEY" );
            Instructions = OpenAI.BubbaPrompt;
            SyncfusionLicenseProvider.RegisterLicense( _key );
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ActiveWindows = new Dictionary<string, Window>( );
            RegisterTheme( );
        }

        /// <summary>
        /// The system instructions
        /// </summary>
        public static string Instructions;

        /// <summary>
        /// The open ai API key
        /// </summary>
        public static string OpenAiKey;

        /// <summary>
        /// The google API key
        /// </summary>
        public static string GoogleKey;

        /// <summa
        /// <summary>
        /// Registers the theme.
        /// </summary>
        private void RegisterTheme( )
        {
            var _theme = new FluentDarkThemeSettings
            {
                PrimaryBackground = new SolidColorBrush( Color.FromRgb( 20, 20, 20 ) ),
                PrimaryColorForeground = new SolidColorBrush( Color.FromRgb( 0, 120, 212 ) ),
                PrimaryForeground = new SolidColorBrush( Color.FromRgb( 222, 222, 222 ) ),
                BodyFontSize = 12,
                HeaderFontSize = 16,
                SubHeaderFontSize = 14,
                TitleFontSize = 14,
                SubTitleFontSize = 16,
                BodyAltFontSize = 10,
                FontFamily = new FontFamily( "Roboto" )
            };

            SfSkinManager.RegisterThemeSettings( "FluentDark", _theme );
            SfSkinManager.ApplyStylesOnApplication = true;
        }

        /// <summary>
        /// Setups the restore window place.
        /// </summary>
        /// <param name="mainWindow">
        /// The main window.
        /// </param>
        private void SetupRestoreWindowPlace( MainWindow mainWindow )
        {
            var _config = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Badger.config" );
            _windowPlace = new WindowPlace( _config );
            _windowPlace.Register( mainWindow );

            // This logic works but I don't like the window being maximized
            //if (!File.Exists(windowPlaceConfigFilePath))
            //{
            //    // For the first time, maximize the window, so it won't go off the screen on laptop
            //    // WindowPlacement will take care of future runs
            //    mainWindow.WindowState = WindowState.Maximized;
            //}
        }

        /// <summary>
        /// Gets the application directory.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private protected static string GetApplicationDirectory( string name )
        {
            try
            {
                ThrowIf.Empty( name, nameof( name ) );
                var _winXpDir = @"C:\Documents and Settings\All Users\Application Data\";
                return Directory.Exists( _winXpDir )
                    ? _winXpDir + Locations.Branding + @"\" + name + @"\"
                    : @"C:\ProgramData\" + Locations.Branding + @"\" + name + @"\";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Raises the
        /// <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name = "sender" > </param>
        /// <param name="e">
        /// that contains the event data.
        /// </param>
        public void OnStartup( object sender, StartupEventArgs e )
        {
            try
            {
                DispatcherUnhandledException += ( s, args ) => HandleException( args.Exception );
                TaskScheduler.UnobservedTaskException += ( s, args ) =>
                    HandleException( args.Exception?.InnerException );

                AppDomain.CurrentDomain.UnhandledException += ( s, args ) =>
                    HandleException( args.ExceptionObject as Exception );

                var _cefSettings = new CefSettings( );
                _cefSettings.RegisterScheme( new CefCustomScheme
                {
                    SchemeName = Locations.Internal,
                    SchemeHandlerFactory = new SchemaCallbackFactory( )
                } );

                _cefSettings.UserAgent = Locations.UserAgent;
                _cefSettings.AcceptLanguageList = Locations.AcceptLanguage;
                _cefSettings.IgnoreCertificateErrors = true;
                _cefSettings.CachePath = GetApplicationDirectory( "Cache" );
                if( bool.Parse( Locations.Proxy ) )
                {
                    CefSharpSettings.Proxy = new ProxyOptions( Locations.ProxyIP,
                        Locations.ProxyPort, Locations.ProxyUsername, Locations.ProxyPassword,
                        Locations.ProxyBypassList );
                }

                Cef.Initialize( _cefSettings );
            }
            catch( Exception ex )
            {
                Cef.Shutdown( );
                Fail( ex );
                Environment.Exit( 1 );
            }
        }

        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">The
        /// <see cref="UnhandledExceptionEventArgs"/>
        /// instance containing the event data.</param>
        private static void OnUnhandledException( object sender, UnhandledExceptionEventArgs e )
        {
            var _ex = e.ExceptionObject as Exception;
            Fail( _ex );
            Environment.Exit( 1 );
        }

        /// <inheritdoc />
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Exit" /> event.
        /// </summary>
        /// <param name = "sender" > </param>
        /// <param name="e">An <see cref="T:System.Windows.ExitEventArgs" />
        /// that contains the event data.</param>
        private protected void OnExit( object sender, ExitEventArgs e )
        {
            try
            {
                _windowPlace?.Save( );
                Environment.Exit( 0 );
            }
            catch( Exception )
            {
                // Do Nothing
            }
        }

        /// <summary>
        /// Called when [un handled exception].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnobservedTaskExceptionEventArgs"/>
        /// instance containing the event data.</param>
        private void OnUnobservedTaskException( object sender, UnobservedTaskExceptionEventArgs e )
        {
            if( e == null )
            {
            }
            else
            {
                var _ex = new Exception( );
                Fail( _ex );
                Environment.Exit( 1 );
            }
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="e">The e.</param>
        private void HandleException( Exception e )
        {
            if( e == null )
            {
            }
            else
            {
                Fail( e );
                Environment.Exit( 1 );
            }
        }

        /// <summary>
        /// Fails the specified _ex.
        /// </summary>
        /// <param name="_ex">The _ex.</param>
        private static void Fail( Exception _ex )
        {
            var _error = new ErrorWindow( _ex ); 
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}