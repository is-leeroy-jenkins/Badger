// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="WebBrowser.xaml.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
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
//   WebBrowser.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Web;
    using System.Reflection;
    using System.Windows;
    using CefSharp;
    using CefSharp.Wpf;
    using System.Threading.Tasks;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Input;
    using Syncfusion.SfSkinManager;
    using Syncfusion.Windows.Controls.Input;
    using Syncfusion.Windows.Tools.Controls;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Messages;
    using ToastNotifications.Position;
    using static System.Configuration.ConfigurationManager;
    using Application = System.Windows.Forms.Application;
    using Button = System.Windows.Controls.Button;
    using Cef = CefSharp.Core.Cef;
    using Clipboard = System.Windows.Clipboard;
    using KeyEventArgs = System.Windows.Input.KeyEventArgs;
    using MessageBox = System.Windows.MessageBox;
    using MouseEventArgs = System.Windows.Input.MouseEventArgs;
    using PrintDialog = System.Windows.Controls.PrintDialog;
    using TextDataFormat = System.Windows.TextDataFormat;
    using Timer = System.Threading.Timer;
    using Keys = System.Windows.Forms.Keys;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWithPrivateSetter" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "CanSimplifyDictionaryLookupWithTryGetValue" ) ]
    public partial class WebBrowser : Window, IDisposable
    {
        /// <summary>
        /// The browser action
        /// </summary>
        private protected Func<ChromiumWebBrowser> _browserCallback;

        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The download cancel requests
        /// </summary>
        private protected List<int> _cancelRequests;

        /// <summary>
        /// The context menu handler
        /// </summary>
        private protected ContextMenuCallback _contextMenuCallback;

        /// <summary>
        /// The current title
        /// </summary>
        private string _currentTitle;

        /// <summary>
        /// The path
        /// </summary>
        private protected object _entry = new object( );

        /// <summary>
        /// The current clean URL
        /// </summary>
        private protected string _finalUrl;

        /// <summary>
        /// The is full screen
        /// </summary>
        private protected bool _fullScreen;

        /// <summary>
        /// The last search
        /// </summary>
        private string _lastSearch = "";

        /// <summary>
        /// The old window state
        /// </summary>
        private protected WindowState _oldWindowState;

        /// <summary>
        /// The current full URL
        /// </summary>
        private protected string _originalUrl;

        /// <summary>
        /// The application path
        /// </summary>
        private string _path = Path.GetDirectoryName( Application.ExecutablePath ) + @"\";

        /// <summary>
        /// The search engine URL
        /// </summary>
        private protected string _searchEngineUrl;

        /// <summary>
        /// The search open
        /// </summary>
        private protected bool _isSearchOpen;

        /// <summary>
        /// The time
        /// </summary>
        private protected int _time;

        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// The life span handler
        /// </summary>
        private protected LifeSpanCallback _lifeSpanCallback;

        /// <summary>
        /// The keyboard handler
        /// </summary>
        private protected KeyboardCallback _keyboardCallback;

        /// <summary>
        /// The download handler
        /// </summary>
        private protected DownloadCallback _downloadCallback;

        /// <summary>
        /// The request handler
        /// </summary>
        private protected RequestCallback _requestCallback;

        /// <summary>
        /// The timer
        /// </summary>
        private protected TimerCallback _timerCallback;

        /// <summary>
        /// The status update
        /// </summary>
        private protected Action _statusUpdate;

        /// <summary>
        /// The host
        /// </summary>
        private protected HostCallback _hostCallback;

        /// <summary>
        /// The download names
        /// </summary>
        private protected Dictionary<int, string> _downloadNames;

        /// <summary>
        /// The downloads
        /// </summary>
        private protected Dictionary<int, DownloadItem> _downloadItems;

        /// <summary>
        /// The tab pages
        /// </summary>
        private protected BrowserTabCollection _tabPages;

        /// <summary>
        /// The download strip
        /// </summary>
        private protected BrowserTabItem _downloadStrip;

        /// <summary>
        /// The add tab item
        /// </summary>
        private protected BrowserTabItem _addTabItem;

        /// <summary>
        /// The new tab strip
        /// </summary>
        private protected BrowserTabItem _newTabItem;

        /// <summary>
        /// The new tab strip
        /// </summary>
        private protected BrowserTabItem _currentTab;

        /// <summary>
        /// The current browser
        /// </summary>
        private protected ChromiumWebBrowser _currentBrowser;

        /// <summary>
        /// The time label
        /// </summary>
        public MetroLabel TimeLabel;

        /// <summary>
        /// The forward button
        /// </summary>
        public ToolStripButton ToolStripForwardButton;

        /// <summary>
        /// The instance
        /// </summary>
        public static WebBrowser Instance;

        /// <summary>
        /// The assembly
        /// </summary>
        public static Assembly Assembly;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Baby.WebBrowser" /> class.
        /// </summary>
        public WebBrowser( )
        {
            // Theme Properties
            SfSkinManager.SetTheme( this, new Theme( "FluentDark", App.Controls ) );

            // Window Properties
            Instance = this;
            InitializeComponent( );
            RegisterCallbacks( );
            InitializeBrowser( );
            InitializeDelegates( );
            InitializeToolStrip( );
            InitializeTabControl( );

            // Event Wiring
            Loaded += OnLoad;
            Closing += OnClosing;
        }

        /// <summary>
        /// Gets the last index.
        /// </summary>
        /// <value>
        /// The last index.
        /// </value>
        private int LastIndex
        {
            get
            {
                return TabControl.Items.Count - 2;
            }
        }

        /// <summary>
        /// The host
        /// </summary>
        public HostCallback HostCallback
        {
            get
            {
                return _hostCallback;
            }
            set
            {
                _hostCallback = value;
            }
        }

        /// <summary>
        /// The download names
        /// </summary>
        public Dictionary<int, string> DownloadNames
        {
            get
            {
                return _downloadNames;
            }
            set
            {
                _downloadNames = value;
            }
        }

        /// <summary>
        /// Gets or sets the add tab item.
        /// </summary>
        /// <value>
        /// The add tab item.
        /// </value>
        public BrowserTabItem AddTabItem
        {
            get
            {
                return _addTabItem;
            }
            set
            {
                _addTabItem = value;
            }
        }

        /// <summary>
        /// Creates new tabitem.
        /// </summary>
        /// <value>
        /// The new tab item.
        /// </value>
        public BrowserTabItem NewTabItem
        {
            get
            {
                return _newTabItem;
            }
            set
            {
                _newTabItem = value;
            }
        }

        /// <summary>
        /// Gets the cancel requests.
        /// </summary>
        /// <value>
        /// The cancel requests.
        /// </value>
        public List<int> CancelRequests
        {
            get
            {
                return _cancelRequests;
            }
            set
            {
                _cancelRequests = value;
            }
        }

        /// <summary>
        /// Gets the downloads.
        /// </summary>
        /// <value>
        /// The downloads.
        /// </value>
        public Dictionary<int, DownloadItem> DownloadItems
        {
            get
            {
                return _downloadItems;
            }
            set
            {
                _downloadItems = value;
            }
        }

        /// <summary>
        /// Gets the duration of the current tab loading.
        /// </summary>
        /// <value>
        /// The duration of the current tab loading.
        /// </value>
        public int LoadingDuration
        {
            get
            {
                if( TabControl.SelectedItem != null
                    && ( ( BrowserTabItem )TabControl.SelectedItem ).Tag != null )
                {
                    var _loadTime =
                        ( int )( DateTime.Now - _currentTab.DateCreated ).TotalMilliseconds;

                    return _loadTime;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Adds the blank window.
        /// </summary>
        public void AddBlankWindow( )
        {
            // open a new instance of the browser
            var _info = new ProcessStartInfo( Application.ExecutablePath, "" )
            {
                LoadUserProfile = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

            Process.Start( _info );
        }

        /// <summary>
        /// Adds the blank tab.
        /// </summary>
        public void AddBlankTab( )
        {
            AddNewBrowserTab( "" );
            Dispatcher.BeginInvoke( ( ) =>
            {
                //UrlTextBox.Focus( );
            } );
        }

        /// <summary>
        /// Adds the new browser tab.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="focus">if set to
        /// <c>true</c> [focus new tab].</param>
        /// <param name="referringUrl">The referring URL.</param>
        /// <returns></returns>
        public ChromiumWebBrowser AddNewBrowserTab( string url, bool focus = true,
            string referringUrl = null )
        {
            return Dispatcher.Invoke( delegate
            {
                // check if already exists
                foreach( BrowserTabItem _item in TabControl.Items )
                {
                    var _tab2 = ( BrowserTabItem )_item.Tag;
                    if( _tab2 != null
                        && _tab2.CurrentUrl == url )
                    {
                        TabControl.SelectedItem = _item;
                        return _tab2.Browser;
                    }
                }

                var _tab = new BrowserTabItem( );
                _tab.Title = "New Tab";
                TabControl.Items.Insert( TabControl.Items.Count - 1, _tab );
                _newTabItem = _tab;
                var _newTab = AddNewBrowser( _newTabItem, url );
                _newTab.ReferringUrl = referringUrl;
                if( focus )
                {
                    _newTab.BringIntoView( );
                }

                return _newTab.Browser;
            } );
        }

        /// <summary>
        /// Adds the new browser.
        /// </summary>
        /// <param name="tabItem">The tab strip.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private BrowserTabItem AddNewBrowser( BrowserTabItem tabItem, string url )
        {
            if( url == "" )
            {
                url = AppSettings[ "NewTab" ];
            }

            var _newBrowser = new ChromiumWebBrowser( url );
            ConfigureBrowser( _newBrowser );
            TabControl.Items.Add( _newBrowser );
            _newBrowser.BringIntoView( );
            tabItem.Content = _newBrowser;
            _newBrowser.StatusMessage += OnStatusUpdated;
            _newBrowser.LoadingStateChanged += OnLoadingStateChanged;
            _newBrowser.TitleChanged += OnTitleChanged;
            _newBrowser.LoadError += OnLoadError;
            _newBrowser.AddressChanged += OnAddressChanged;
            _newBrowser.DownloadHandler = _downloadCallback;
            _newBrowser.MenuHandler = _contextMenuCallback;
            _newBrowser.LifeSpanHandler = _lifeSpanCallback;
            _newBrowser.KeyboardHandler = _keyboardCallback;
            _newBrowser.RequestHandler = _requestCallback;
            var _tab = new BrowserTabItem
            {
                IsOpen = true,
                Browser = _newBrowser,
                Tab = tabItem,
                OriginalUrl = url,
                CurrentUrl = url,
                Title = "New Tab",
                DateCreated = DateTime.Now
            };

            tabItem.Tag = _tab;
            if( url.StartsWith( AppSettings[ "Internal" ] + ":" ) )
            {
                _newBrowser.JavascriptObjectRepository.Register( "host", HostCallback,
                    BindingOptions.DefaultBinder );
            }

            return _tab;
        }

        /// <summary>
        /// this is done just once,
        /// to globally initialize CefSharp/CEF
        /// </summary>
        private void InitializeBrowser( )
        {
            _hostCallback = new HostCallback( this );
            ConfigureBrowser( Browser );
            _currentTab = BrowserTab;
            _currentBrowser = Browser;
            _searchEngineUrl = Browser.Address;
            var _settings = new CefSettings( );
            _settings.RegisterScheme( new CefCustomScheme
            {
                SchemeName = AppSettings[ "Internal" ],
                SchemeHandlerFactory = new SchemaCallbackFactory( )
            } );

            _settings.UserAgent = BrowserConfig.UserAgent;
            _settings.AcceptLanguageList = BrowserConfig.AcceptLanguage;
            _settings.IgnoreCertificateErrors = true;
            var _cache = AppSettings[ "Downloads" ];
            _settings.CachePath = GetApplicationDirectory( _cache );
            if( BrowserConfig.Proxy )
            {
                var _proxy = AppSettings[ "ProxyIP" ];
                var _port = AppSettings[ "ProxyPort" ];
                CefSharpSettings.Proxy = new ProxyOptions( _proxy, _port );
            }

            _downloadCallback = new DownloadCallback( this );
            _lifeSpanCallback = new LifeSpanCallback( this );
            _contextMenuCallback = new ContextMenuCallback( this );
            _keyboardCallback = new KeyboardCallback( this );
            _requestCallback = new RequestCallback( this );
            InitializeDownloads( );
        }

        /// <summary>
        /// we must store download metadata in a list,
        /// since CefSharp does not
        /// </summary>
        private void InitializeDownloads( )
        {
            _downloadItems = new Dictionary<int, DownloadItem>( );
            _downloadNames = new Dictionary<int, string>( );
            _cancelRequests = new List<int>( );
        }

        /// <summary>
        /// Initializes the tab control.
        /// </summary>
        private void InitializeTabControl( )
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
        /// Initializes the PictureBox.
        /// </summary>
        private void InitializePictureBox( )
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
        /// Sets the status label properties.
        /// </summary>
        private void InitializeButtons( )
        {
            try
            {
                ToolStripForwardButton.Visibility = Visibility.Hidden;
                ToolStripPreviousButton.Visibility = Visibility.Hidden;
                ToolStripCancelButton.Visibility = Visibility.Hidden;
                ToolStripCancelButton.Visibility = Visibility.Hidden;
                ToolStripNextButton.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the title label properties.
        /// </summary>
        private void InitializeTitle( )
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
        /// Initializes the delegate.
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
        /// these hot keys work when the user
        /// is focused on the .NET form and its controls,
        /// AND when the user is focused on the browser
        /// (CefSharp portion)
        /// </summary>
        private void InitializeHotkeys( )
        {
            try
            {
                // browser hot keys
                KeyboardCallback.AddHotKey( this, CloseActiveTab, Keys.W, true );
                KeyboardCallback.AddHotKey( this, CloseActiveTab, Keys.Escape, true );
                KeyboardCallback.AddHotKey( this, AddBlankWindow, Keys.N, true );
                KeyboardCallback.AddHotKey( this, AddBlankTab, Keys.T, true );
                KeyboardCallback.AddHotKey( this, RefreshActiveTab, Keys.F5 );
                KeyboardCallback.AddHotKey( this, OpenDeveloperTools, Keys.F12 );
                KeyboardCallback.AddHotKey( this, NextTab, Keys.Tab, true );
                KeyboardCallback.AddHotKey( this, PreviousTab, Keys.Tab, true,
                    true );

                // search hot keys
                KeyboardCallback.AddHotKey( this, OpenSearch, Keys.F, true );
                KeyboardCallback.AddHotKey( this, CloseSearch, Keys.Escape );
                KeyboardCallback.AddHotKey( this, StopActiveTab, Keys.Escape );
                KeyboardCallback.AddHotKey( this, ToggleFullscreen, Keys.F11 );
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
        /// Initializes the tool strip.
        /// </summary>
        private void InitializeToolStrip( )
        {
            try
            {
                HideToolbar( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Determines whether the specified URL is blank.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// <c>true</c>
        /// if the specified URL is blank;
        /// otherwise,
        /// <c>false</c>.
        /// </returns>
        private bool IsBlank( string url )
        {
            try
            {
                ThrowIf.Null( url, nameof( url ) );
                return url == "" || url == "about:blank";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// Determines whether [is blank or system] [the specified URL].
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// <c>true</c> if [is blank or system] [the specified URL];
        /// otherwise,
        /// <c>false</c>.
        /// </returns>
        private bool IsBlankOrSystem( string url )
        {
            try
            {
                ThrowIf.Null( url, nameof( url ) );
                return url == "" || url.BeginsWith( "about:" ) || url.BeginsWith( "chrome:" )
                    || url.BeginsWith( AppSettings[ "Internal" ] + ":" );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// Determines whether [is on first tab].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is on first tab]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsFirstTab( )
        {
            return TabControl.SelectedItem == TabControl.Items[ 0 ];
        }

        /// <summary>
        /// Determines whether [is on last tab].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is on last tab]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsLastTab( )
        {
            return TabControl.SelectedItem == TabControl.Items[ ^2 ];
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
        /// Initializes the callbacks.
        /// </summary>
        private protected void RegisterCallbacks( )
        {
            try
            {
                ToolStripPreviousButton.Click += OnPreviousButtonClick;
                ToolStripNextButton.Click += OnNextButtonClick;
                ToolStripLookupButton.Click += OnLookupButtonClick;
                ToolStripRefreshButton.Click += OnRefreshButtonClick;
                ToolStripMenuButton.Click += OnToggleButtonClick;
                ToolStripCancelButton.MouseLeftButtonDown += OnCloseButtonClick;

                // UrlTextBox.GotMouseCapture += OnUrlTextBoxClick;
                ToolStripTextBox.GotMouseCapture += OnToolStripTextBoxClick;

                // ChatButton.Click += OnChatButtonClick;
                //HomeButton.Click += OnHomeButtonClick;
                ToolStripComboBox.SelectionChanged += OnSelectedDomainChanged;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the callbacks.
        /// </summary>
        private protected virtual void ClearCallbacks( )
        {
            try
            {
                _lifeSpanCallback = null;
                _keyboardCallback = null;
                _downloadCallback = null;
                _requestCallback = null;
                _timerCallback = null;
                _hostCallback = null;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets or sets the current tab.
        /// </summary>
        /// <value>
        /// The current tab.
        /// </value>
        public BrowserTabItem CurrentTab
        {
            get
            {
                return TabControl.SelectedItem != null
                    && ( ( BrowserTabItem )TabControl.SelectedItem ).Tag != null
                        ? ( BrowserTabItem )TabControl.SelectedItem
                        : default( BrowserTabItem );
            }
            set
            {
                _currentTab = value;
            }
        }

        /// <summary>
        /// Gets the current browser.
        /// </summary>
        /// <value>
        /// The current browser.
        /// </value>
        public ChromiumWebBrowser CurrentBrowser
        {
            get
            {
                return TabControl.SelectedItem != null
                    && ( ( BrowserTabItem )TabControl.SelectedItem ).Tag != null
                        ? ( ( BrowserTabItem )TabControl.SelectedItem ).Browser
                        : default( ChromiumWebBrowser );
            }
            set
            {
                _currentBrowser = value;
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

                return new Notifier( cfg =>
                {
                    cfg.LifetimeSupervisor = _lifeTime;
                    cfg.PositionProvider = _position;
                    cfg.Dispatcher = CurrentBrowser.Dispatcher;
                } );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Notifier );
            }
        }

        /// <summary>
        /// this is done every time a new tab is opened
        /// </summary>
        /// <param name="browser">The browser.</param>
        private void ConfigureBrowser( ChromiumWebBrowser browser )
        {
            try
            {
                ThrowIf.Null( browser, nameof( browser ) );
                var _config = new BrowserSettings( );
                var _flag = AppSettings[ "WebGL" ];
                if( !string.IsNullOrEmpty( _flag ) )
                {
                    _config.WebGl = bool.Parse( _flag ).ToCefState( );
                    browser.BrowserSettings = _config;
                }
                else
                {
                    _config.WebGl = bool.Parse( "false" ).ToCefState( );
                    browser.BrowserSettings = _config;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Closes the other tabs.
        /// </summary>
        private void CloseOtherTabs( )
        {
            try
            {
                var _listToClose = new List<BrowserTabItem>( );
                foreach( BrowserTabItem _tab in TabControl.Items )
                {
                    if( _tab != _currentTab
                        && _tab != TabControl.SelectedItem )
                    {
                        _listToClose.Add( _tab );
                    }
                }

                foreach( var _tab in _listToClose )
                {
                    TabControl.Items.Remove( _tab );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called by SetURL to clean up the URL
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private string CleanUrl( string url )
        {
            try
            {
                ThrowIf.Null( url, nameof( url ) );
                if( url.BeginsWith( "about:" ) )
                {
                    return "";
                }

                url = url.RemovePrefix( "http://" );
                url = url.RemovePrefix( "https://" );
                url = url.RemovePrefix( "file://" );
                url = url.RemovePrefix( "/" );
                return url.DecodeUrlForFilePath( );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Closes the active tab.
        /// </summary>
        public void CloseActiveTab( )
        {
            if( _currentTab != null/* && TabPages.Items.Count > 2*/ )
            {
                var _index = TabControl.Items.IndexOf( TabControl.SelectedItem );
                TabControl.Items.RemoveAt( _index );
                if( TabControl.Items.Count - 1 > _index )
                {
                    TabControl.SelectedItem = TabControl.Items[ _index ];
                }
            }
        }

        /// <summary>
        /// Closes the search.
        /// </summary>
        private void CloseSearch( )
        {
            if( _isSearchOpen )
            {
                _isSearchOpen = false;
                InvokeIf( ( ) =>
                {
                    //SearchPanel.Visible = false;
                    _currentBrowser.GetBrowser( )?.StopFinding( true );
                } );
            }
        }

        /// <summary>
        /// Enables the back button.
        /// </summary>
        /// <param name="canGoBack">if set to
        /// <c>true</c> [can go back].</param>
        private void EnableBackButton( bool canGoBack )
        {
            InvokeIf( ( ) =>
            {
                if( canGoBack )
                {
                    ToolStripPreviousButton.Visibility = Visibility.Visible;

                    //SearchPanelBButton.Visibility = Visibility.Visible;
                }
                else
                {
                    ToolStripPreviousButton.Visibility = Visibility.Hidden;

                    //SearchPanelBackButton.Visibility = Visibility.Hidden;
                }
            } );
        }

        /// <summary>
        /// Enables the forward button.
        /// </summary>
        /// <param name="canGoForward">
        /// if set to <c>true</c> [can go forward].
        /// </param>
        private void EnableForwardButton( bool canGoForward )
        {
            InvokeIf( ( ) =>
            {
                if( canGoForward )
                {
                    ToolStripNextButton.Visibility = Visibility.Visible;

                    //SearchPanelForwardButton.Visibility = Visibility.Visible;
                }
                else
                {
                    ToolStripNextButton.Visibility = Visibility.Hidden;

                    //SearchPanelForwardButton.Visibility = Visibility.Hidden;
                }
            } );
        }

        /// <summary>
        /// Fades the in asynchronously.
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
        /// Fades the out asynchronously.
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
        /// Finds the text on page.
        /// </summary>
        /// <param name="next">if set to
        /// <c>true</c> [next].</param>
        private void FindTextOnPage( bool next = true )
        {
            // var _first = _lastSearch != UrlTextBox.Text;
            // _lastSearch = UrlTextBox.Text;
            if( _lastSearch.CheckIfValid( ) )
            {
                //_currentBrowser.GetBrowser( )?.Find( _lastSearch, true, false, !_first );
            }
            else
            {
                //_currentBrowser.GetBrowser( )?.StopFinding( true );
            }

            //UrlTextBox.Focus( );
        }

        /// <summary>
        /// Calculates the download path.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public string GetDownloadPath( DownloadItem item )
        {
            return item.SuggestedFileName;
        }

        /// <summary>
        /// Gets all tabs.
        /// </summary>
        /// <returns></returns>
        public List<BrowserTabItem> GetTabs( )
        {
            var _tabs = new List<BrowserTabItem>( );
            foreach( BrowserTabItem _tabPage in TabControl.Items )
            {
                if( _tabPage.Tag != null )
                {
                    _tabs.Add( ( BrowserTabItem )_tabPage.Tag );
                }
            }

            return _tabs;
        }

        /// <summary>
        /// Gets the tab by browser.
        /// </summary>
        /// <param name="browser">The browser.</param>
        /// <returns></returns>
        public BrowserTabItem GetTabByBrowser( IWebBrowser browser )
        {
            foreach( BrowserTabItem _item in TabControl.Items )
            {
                var _tab = ( BrowserTabItem )_item.Tag;
                if( _tab != null
                    && _tab.Browser == browser )
                {
                    return _tab;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the application directory.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private static string GetApplicationDirectory( string name )
        {
            try
            {
                ThrowIf.Null( name, nameof( name ) );
                var _winXpDir = @"C:\Documents and Settings\All Users\Application Data\";
                var _app = AppSettings[ "Branding" ];
                return Directory.Exists( _winXpDir )
                    ? _winXpDir + AppSettings[ "Branding" ] + @"\" + name + @"\"
                    : @"C:\ProgramData\" + _app + @"\" + name + @"\";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the resource stream.
        /// </summary>
        /// <param name="fileName">The fileName.</param>
        /// <param name="nameSpace">if set to
        /// <c>true</c> [with nameSpace].</param>
        /// <returns></returns>
        public Stream GetResourceStream( string fileName, bool nameSpace = true )
        {
            try
            {
                ThrowIf.Null( fileName, nameof( fileName ) );
                var _prefix = "Properties.Resources.";
                return Assembly.GetManifestResourceStream( fileName );
            }
            catch( Exception )
            {
                //ignore exception
            }

            return null;
        }

        /// <summary>
        /// Gets the browser asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="focused">if set to <c>true</c> [focused].</param>
        /// <returns></returns>
        private Task<ChromiumWebBrowser> GetBrowserAsync( string url, bool focused )
        {
            var _tcs = new TaskCompletionSource<ChromiumWebBrowser>( );
            try
            {
                ThrowIf.Null( url, nameof( url ) );
                var _browser = AddNewBrowserTab( url, focused );
                _tcs.SetResult( _browser );
                return _tcs.Task;
            }
            catch( Exception ex )
            {
                _tcs.SetException( ex );
                Fail( ex );
                return default( Task<ChromiumWebBrowser> );
            }
        }

        /// <summary>
        /// Loads the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        private void LoadUrl( string url )
        {
            try
            {
                ThrowIf.Null( url, nameof( url ) );
                var _newUrl = url;
                var _urlLower = url.Trim( ).ToLower( );
                SetTabText( _currentBrowser, "Loading..." );
                if( _urlLower == "localhost" )
                {
                    _newUrl = "http://localhost/";
                }
                else if( url.CheckIfFilePath( )
                    || url.CheckIfFilePath2( ) )
                {
                    _newUrl = url.PathToUrl( );
                }
                else
                {
                    Uri.TryCreate( url, UriKind.Absolute, out var _outUri );
                    if( !( _urlLower.StartsWith( "http" )
                        || _urlLower.StartsWith( AppSettings[ "Internal" ] ) ) )
                    {
                        if( _outUri == null
                            || _outUri.Scheme != Uri.UriSchemeFile )
                        {
                            _newUrl = "https://" + url;
                        }
                    }

                    if( _urlLower.StartsWith( AppSettings[ "Internal" ] + ":" )
                        || ( Uri.TryCreate( _newUrl, UriKind.Absolute, out _outUri )
                            && ( ( ( _outUri.Scheme == Uri.UriSchemeHttp
                                        || _outUri.Scheme == Uri.UriSchemeHttps )
                                    && _newUrl.Contains( "." ) )
                                || _outUri.Scheme == Uri.UriSchemeFile ) ) )
                    {
                    }
                    else
                    {
                        _newUrl = AppSettings[ "Google" ] + HttpUtility.UrlEncode( url );
                    }
                }

                _currentBrowser.Load( _newUrl );
                SetUrl( _newUrl );
                EnableBackButton( true );
                EnableForwardButton( false );
            }
            catch( Exception e )
            {
                Fail( e );
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
        /// Nexts the tab.
        /// </summary>
        private void NextTab( )
        {
            if( IsLastTab( ) )
            {
                var _msg = "At The End";
                SendMessage( _msg );
            }
            else
            {
                var _next = TabControl.SelectedIndex + 1;
                TabControl.SelectedItem = TabControl.Items[ _next ];
            }
        }

        /// <summary>
        /// Previous tab.
        /// </summary>
        private void PreviousTab( )
        {
            if( IsFirstTab( ) )
            {
                var _msg = "At The Beginning!";
                SendMessage( _msg );
            }
            else
            {
                var _next = TabControl.SelectedIndex - 1;
                TabControl.SelectedItem = TabControl.Items[ _next ];
            }
        }

        /// <summary>
        /// Sets the tool strip properties.
        /// </summary>
        private void PopulateDomainDropDowns( )
        {
            try
            {
                //ToolStripComboBox.Items?.Clear( );
                var _domains = Enum.GetNames( typeof( Domains ) );
                for( var _i = 0; _i < _domains.Length; _i++ )
                {
                    var _dom = _domains[ _i ];
                    if( !string.IsNullOrEmpty( _dom ) )
                    {
                        //ToolStripComboBox.Items.Add( _dom );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// DownloadItems the in progress.
        /// </summary>
        /// <returns></returns>
        public bool DownloadsInProgress( )
        {
            if( _downloadItems?.Values?.Count > 0 )
            {
                foreach( var _item in _downloadItems.Values )
                {
                    if( _item.IsInProgress )
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Refreshes the active tab.
        /// </summary>
        public void RefreshActiveTab( )
        {
            var _address = _currentBrowser.Address;
            _currentBrowser.Load( _address );
        }

        /// <summary>
        /// Opens the downloads tab.
        /// </summary>
        public void OpenDownloadsTab( )
        {
            if( _downloadStrip != null )
            {
                TabControl.SelectedItem = _downloadStrip;
            }
            else
            {
                var _brw = AddNewBrowserTab( AppSettings[ "Downloads" ] );
                _downloadStrip = ( BrowserTabItem )_brw.Parent;
            }
        }

        /// <summary>
        /// Opens the developer tools.
        /// </summary>
        private void OpenDeveloperTools( )
        {
            if( _currentBrowser == null )
            {
                var _message = "CurrentBrowser is null!";
                SendMessage( _message );
            }
            else
            {
                _currentBrowser.ShowDevTools( );
            }
        }

        /// <summary>
        /// Opens the chrome browser.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private void OpenChromeBrowser( string args )
        {
            try
            {
                var _url = AppSettings[ "Google" ] + args;
                var _info = new ProcessStartInfo
                {
                    FileName = AppSettings[ "Chrome" ],
                    LoadUserProfile = true,
                    UseShellExecute = true
                };

                _info.ArgumentList.Add( _url );
                Process.Start( _info );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the chrome browser.
        /// </summary>
        private void OpenChromeBrowser( )
        {
            try
            {
                var _url = AppSettings[ "HomePage" ];
                var _info = new ProcessStartInfo
                {
                    FileName = AppSettings[ "Chrome" ],
                    LoadUserProfile = true,
                    UseShellExecute = true
                };

                _info.ArgumentList.Add( _url );
                Process.Start( _info );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the edge browser.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private void OpenEdgeBrowser( string args )
        {
            try
            {
                var _url = AppSettings[ "Google" ] + args;
                var _info = new ProcessStartInfo
                {
                    FileName = AppSettings[ "Edge" ],
                    LoadUserProfile = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                _info.ArgumentList.Add( _url );
                Process.Start( _info );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the edge browser.
        /// </summary>
        private void OpenEdgeBrowser( )
        {
            try
            {
                var _url = AppSettings[ "HomePage" ];
                var _info = new ProcessStartInfo
                {
                    FileName = AppSettings[ "Edge" ],
                    LoadUserProfile = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                _info.ArgumentList.Add( _url );
                Process.Start( _info );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the fire fox browser.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private void OpenFireFoxBrowser( string args )
        {
            try
            {
                var _url = AppSettings[ "Google" ] + args;
                var _info = new ProcessStartInfo
                {
                    FileName = AppSettings[ "FireFox" ],
                    LoadUserProfile = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                _info.ArgumentList.Add( _url );
                Process.Start( _info );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the fire fox browser.
        /// </summary>
        private void OpenFireFoxBrowser( )
        {
            try
            {
                var _url = AppSettings[ "HomePage" ];
                var _info = new ProcessStartInfo
                {
                    FileName = AppSettings[ "FireFox" ],
                    LoadUserProfile = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                _info.ArgumentList.Add( _url );
                Process.Start( _info );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the search.
        /// </summary>
        private void OpenSearch( )
        {
            if( !_isSearchOpen )
            {
                _isSearchOpen = true;
                InvokeIf( ( ) =>
                {
                    //UrlTextBox.Text = _lastSearch;
                    //UrlTextBox.Focus( );
                    //UrlTextBox.SelectAll( );
                } );
            }
            else
            {
                InvokeIf( ( ) =>
                {
                    //UrlTextBox.Focus( );
                    //UrlTextBox.SelectAll( );
                } );
            }
        }

        /// <summary>
        /// Shows the search dialog.
        /// </summary>
        private protected virtual void OpenSearchDialog( double x, double y )
        {
            try
            {
                ThrowIf.Negative( x, nameof( x ) );
                ThrowIf.Negative( y, nameof( y ) );
                var _searchDialog = new SearchDialog( );
                _searchDialog.Owner = this;
                _searchDialog.Left = x;
                _searchDialog.Top = y;
                _searchDialog.Show( );
                _searchDialog.SearchPanelTextBox.Focus( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the chat window.
        /// </summary>
        private void OpenMainWindow( )
        {
            try
            {
                if( App.ActiveWindows?.ContainsKey( "MainWindow" ) == true )
                {
                    var _form = ( MainWindow )App.ActiveWindows[ "MainWindow" ];
                    _form.Show( );
                }
                else
                {
                    var _chat = new MainWindow
                    {
                        Owner = this,
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
        /// Sets the tab title.
        /// </summary>
        /// <param name="browser">The browser.</param>
        /// <param name="text">The text.</param>
        private void SetTabText( ChromiumWebBrowser browser, string text )
        {
            try
            {
                ThrowIf.Null( browser, nameof( browser ) );
                ThrowIf.Null( text, nameof( text ) );
                text = text.Trim( );
                if( IsBlank( text ) )
                {
                    text = "New Tab";
                }

                browser.Tag = text;
                if( text.Length > 20 )
                {
                    var _title = text.Substring( 0, 20 ) + "...";
                    var _tab = ( BrowserTabItem )browser.Parent;
                    _tab.Title = _title;
                }
                else
                {
                    var _tab = ( BrowserTabItem )browser.Parent;
                    _tab.Title = text;
                }

                // if current tab
                if( browser == _currentBrowser )
                {
                    SetTitleText( text );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the form title.
        /// </summary>
        /// <param name="title">
        /// Name of the tab.
        /// </param>
        private void SetTitleText( string title )
        {
            InvokeIf( ( ) =>
            {
                if( title.CheckIfValid( ) )
                {
                    Title = AppSettings[ "Branding" ] + " - " + title;
                    _currentTitle = title;
                }
                else
                {
                    Title = AppSettings[ "Branding" ];
                    _currentTitle = "New Tab";
                }
            } );
        }

        /// <summary>
        /// Gets the search engine URL.
        /// </summary>
        /// <value>
        /// The search engine URL.
        /// </value>
        public string SearchEngineUrl
        {
            get
            {
                return _searchEngineUrl;
            }
            set
            {
                _searchEngineUrl = value;
            }
        }

        /// <summary>
        /// Called by LoadURL to set the form URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        private void SetUrl( string url )
        {
            try
            {
                ThrowIf.Null( url, nameof( url ) );
                _originalUrl = url;
                _finalUrl = CleanUrl( url );

                //UrlTextBox.Text = _finalUrl;
                _currentTab.CurrentUrl = _originalUrl;
                CloseSearch( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void SendMessage( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _splashMessage = new SplashMessage( message );
                _splashMessage.Show( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        private void SendNotification( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _notifier = CreateNotifier( );
                _notifier.ShowInformation( message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Stops the active tab.
        /// </summary>
        private void StopActiveTab( )
        {
            _currentBrowser.Stop( );
        }

        /// <summary>
        /// Executes the multi search.
        /// </summary>
        /// <param name="keyWords">The key words.</param>
        private void SearchGovernmentDomains( string keyWords )
        {
            if( !string.IsNullOrEmpty( keyWords ) )
            {
                try
                {
                    var _google = AppSettings[ "Google" ] + keyWords;
                    _currentBrowser.LoadUrl( _google );
                    var _epa = AppSettings[ "EPA" ] + keyWords;
                    AddNewBrowserTab( _epa, false );
                    var _data = AppSettings[ "DATA" ] + keyWords;
                    AddNewBrowserTab( _data, false );
                    var _crs = AppSettings[ "CRS" ] + keyWords;
                    AddNewBrowserTab( _crs, false );
                    var _loc = AppSettings[ "LOC" ] + keyWords;
                    AddNewBrowserTab( _loc, false );
                    var _gpo = AppSettings[ "GPO" ] + keyWords;
                    AddNewBrowserTab( _gpo, false );
                    var _usgi = AppSettings[ "USGI" ] + keyWords;
                    AddNewBrowserTab( _usgi, false );
                    var _omb = AppSettings[ "OMB" ] + keyWords;
                    AddNewBrowserTab( _omb, false );
                    var _ust = AppSettings[ "UST" ] + keyWords;
                    AddNewBrowserTab( _ust, false );
                    var _nara = AppSettings[ "NARA" ] + keyWords;
                    AddNewBrowserTab( _nara, false );
                    var _nasa = AppSettings[ "NASA" ] + keyWords;
                    AddNewBrowserTab( _nasa, false );
                    var _noaa = AppSettings[ "NOAA" ] + keyWords;
                    AddNewBrowserTab( _noaa, false );
                    var _doi = AppSettings[ "DOI" ] + keyWords;
                    AddNewBrowserTab( _doi, false );
                    var _nps = AppSettings[ "NPS" ] + keyWords;
                    AddNewBrowserTab( _nps, false );
                    var _gsa = AppSettings[ "GSA" ] + keyWords;
                    AddNewBrowserTab( _gsa, false );
                    var _doc = AppSettings[ "DOC" ] + keyWords;
                    AddNewBrowserTab( _doc, false );
                    var _hhs = AppSettings[ "HHS" ] + keyWords;
                    AddNewBrowserTab( _hhs, false );
                    var _nrc = AppSettings[ "NRC" ] + keyWords;
                    AddNewBrowserTab( _nrc, false );
                    var _doe = AppSettings[ "DOE" ] + keyWords;
                    AddNewBrowserTab( _doe, false );
                    var _nsf = AppSettings[ "NSF" ] + keyWords;
                    AddNewBrowserTab( _nsf, false );
                    var _usda = AppSettings[ "USDA" ] + keyWords;
                    AddNewBrowserTab( _usda, false );
                    var _csb = AppSettings[ "CSB" ] + keyWords;
                    AddNewBrowserTab( _csb, false );
                    var _irs = AppSettings[ "IRS" ] + keyWords;
                    AddNewBrowserTab( _irs, false );
                    var _fda = AppSettings[ "FDA" ] + keyWords;
                    AddNewBrowserTab( _fda, false );
                    var _cdc = AppSettings[ "CDC" ] + keyWords;
                    AddNewBrowserTab( _cdc, false );
                    var _ace = AppSettings[ "ACE" ] + keyWords;
                    AddNewBrowserTab( _ace, false );
                    var _dhs = AppSettings[ "DHS" ] + keyWords;
                    AddNewBrowserTab( _dhs, false );
                    var _dod = AppSettings[ "DOD" ] + keyWords;
                    AddNewBrowserTab( _dod, false );
                    var _usno = AppSettings[ "USNO" ] + keyWords;
                    AddNewBrowserTab( _usno, false );
                    var _nws = AppSettings[ "NWS" ] + keyWords;
                    AddNewBrowserTab( _nws, false );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Shows the items.
        /// </summary>
        private void ShowToolbar( )
        {
            try
            {
                ToolStripFirstButton.Visibility = Visibility.Visible;
                ToolStripPreviousButton.Visibility = Visibility.Visible;
                ToolStripNextButton.Visibility = Visibility.Visible;
                ToolStripLastButton.Visibility = Visibility.Visible;
                ToolStripTextBox.Visibility = Visibility.Visible;

                //ToolStripComboBox.Visibility = Visibility.Visible;
                ToolStripLookupButton.Visibility = Visibility.Visible;
                ToolStripRefreshButton.Visibility = Visibility.Visible;

                //CancelButton.Visibility = Visibility.Visible;
                //ChatButton.Visibility = Visibility.Visible;
                //ToolButton.Visibility = Visibility.Visible;
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
                ToolStripFirstButton.Visibility = Visibility.Hidden;
                ToolStripPreviousButton.Visibility = Visibility.Hidden;
                ToolStripNextButton.Visibility = Visibility.Hidden;
                ToolStripLastButton.Visibility = Visibility.Hidden;
                ToolStripTextBox.Visibility = Visibility.Hidden;
                ToolStripComboBox.Visibility = Visibility.Hidden;
                ToolStripLookupButton.Visibility = Visibility.Hidden;
                ToolStripRefreshButton.Visibility = Visibility.Hidden;
                ToolStripCancelButton.Visibility = Visibility.Hidden;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Toggles the fullscreen.
        /// </summary>
        private void ToggleFullscreen( )
        {
            if( !_fullScreen )
            {
                _oldWindowState = WindowState;
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Maximized;
                _fullScreen = true;
            }
            else
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = _oldWindowState;
                _fullScreen = false;
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

                //DateLabel.Content = DateTime.Now.ToShortDateString( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Updates the download item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateDownloadItem( DownloadItem item )
        {
            lock( _downloadItems )
            {
                // SuggestedFileName comes full only
                // in the first attempt so keep it somewhere
                if( item.SuggestedFileName != "" )
                {
                    _downloadNames[ item.Id ] = item.SuggestedFileName;
                }

                // Set it back if it is empty
                if( item.SuggestedFileName == ""
                    && _downloadNames.TryGetValue( item.Id, out var _name ) )
                {
                    item.SuggestedFileName = _name;
                }

                _downloadItems[ item.Id ] = item;

                //UpdateSnipProgress();
            }
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( object state )
        {
            try
            {
                InvokeIf( _statusUpdate );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Waits for browser to initialize.
        /// </summary>
        /// <param name="browser">The browser.</param>
        public void WaitForBrowserToInitialize( ChromiumWebBrowser browser )
        {
            while( !browser.IsBrowserInitialized )
            {
                Thread.Sleep( 100 );
            }
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnLoad( object sender, RoutedEventArgs e )
        {
            try
            {
                InitializeTimer( );
                InitializePictureBox( );
                PopulateDomainDropDowns( );
                InitializeHotkeys( );
                InitializeButtons( );
                InitializeTitle( );
                InitializeToolStrip( );
                _searchEngineUrl = AppSettings[ "Google" ];
                App.ActiveWindows.Add( "WebBrowser", this );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [frame loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FrameLoadEndEventArgs"/>
        /// instance containing the event data.</param>
        private void OnFrameLoaded( object sender, FrameLoadEndEventArgs e )
        {
            // Do something after the page loads
        }

        /// <summary>
        /// Called when [URL changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AddressChangedEventArgs" />
        /// instance containing the event data.</param>
        private void OnAddressChanged( object sender, DependencyPropertyChangedEventArgs e )
        {
            InvokeIf( ( ) =>
            {
                // if current tab
                if( sender == _currentBrowser
                    && e.Property.Name.Equals( "Address" ) )
                {
                    // if( !NetUtility.IsFocused( UrlTextBox ) )
                    {
                        var _url = e.NewValue.ToString( );
                        SetUrl( _url );
                    }

                    EnableBackButton( _currentBrowser.CanGoBack );
                    EnableForwardButton( _currentBrowser.CanGoForward );
                    SetTabText( ( ChromiumWebBrowser )sender, "Loading..." );
                    ToolStripRefreshButton.Visibility = Visibility.Hidden;

                    // SearchPanelCancelButton.Visibility = Visibility.Visible;
                    _currentTab.DateCreated = DateTime.Now;
                }
            } );
        }

        /// <summary>
        /// Called when [load error].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LoadErrorEventArgs" />
        /// instance containing the event data.</param>
        private void OnLoadError( object sender, LoadErrorEventArgs e )
        {
            // ("Load Error:" + e.ErrorCode + ";" + e.ErrorText);
        }

        /// <summary>
        /// Called when [title changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TitleChangedEventArgs" />
        /// instance containing the event data.</param>
        private void OnTitleChanged( object sender, DependencyPropertyChangedEventArgs e )
        {
            InvokeIf( ( ) =>
            {
                var _browser = ( ChromiumWebBrowser )sender;
                SetTabText( _browser, _browser.Title );
            } );
        }

        /// <summary>
        /// Called when [develop tools button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnDeveloperToolsButtonClick( object sender, RoutedEventArgs e )
        {
            OpenDeveloperTools( );
        }

        /// <summary>
        /// Called when [loading state changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LoadingStateChangedEventArgs" />
        /// instance containing the event data.</param>
        private void OnLoadingStateChanged( object sender, LoadingStateChangedEventArgs e )
        {
            if( sender == _currentBrowser )
            {
                EnableBackButton( e.CanGoBack );
                EnableForwardButton( e.CanGoForward );
                if( e.IsLoading )
                {
                    // set title
                    SetTitleText( "Loading..." );
                }
                else
                {
                    // after loaded / stopped
                    InvokeIf( ( ) =>
                    {
                        ToolStripRefreshButton.Visibility = Visibility.Visible;

                        //SearchPanelCancelButton.Visibility = Visibility.Hidden;
                    } );
                }
            }
        }

        /// <summary>
        /// Called when [tab closed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnTabClosed( object sender, RoutedEventArgs e )
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
        /// Called when [status updated].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="StatusMessageEventArgs" />
        /// instance containing the event data.</param>
        private void OnStatusUpdated( object sender, StatusMessageEventArgs e )
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
        /// Raises the <see cref="E:TabClosing" /> event.
        /// </summary>
        /// <param name="e">The <see cref="TabClosingEventArgs" />
        /// instance containing the event data.</param>
        private void OnTabClosing( object sender, TabClosingEventArgs e )
        {
            // exit if invalid tab
            if( _currentTab == null )
            {
                e.Cancel = true;
                return;
            }

            // add a blank tab if the very last tab is closed!
            if( TabControl.Items.Count <= 2 )
            {
                AddBlankTab( );

                //e.Cancel = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:TabsChanged" /> event.
        /// </summary>
        /// <param name = "sender" > </param>
        /// <param name="e">The <see cref="BrowserTabChangedEventArgs" />
        /// instance containing the event data.</param>
        private void OnTabsChanged( object sender, BrowserTabChangedEventArgs e )
        {
            ChromiumWebBrowser _browser = null;
            try
            {
                _browser = e.Item.Browser;
            }
            catch( Exception )
            {
                // ignore 
            }

            if( e.ChangeType == ChangeType.SelectionChanged )
            {
                if( TabControl.SelectedItem == _currentBrowser )
                {
                    AddBlankTab( );
                }
                else
                {
                    _browser = _currentBrowser;
                    SetUrl( _browser.Address );
                    SetTitleText( _browser.Tag.ConvertToString( ) ?? "New Tab" );
                    EnableBackButton( _browser.CanGoBack );
                    EnableForwardButton( _browser.CanGoForward );
                }
            }

            if( e.ChangeType == ChangeType.Removed )
            {
                if( e.Item == _downloadStrip )
                {
                    _downloadStrip = null;
                }

                _browser?.Dispose( );
            }

            if( e.ChangeType == ChangeType.Changed )
            {
                if( _browser != null )
                {
                    if( _originalUrl != "about:blank" )
                    {
                        _browser.Focus( );
                    }
                }
            }
        }

        /// <summary>
        /// Called when [search engine selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" />
        /// instance containing the event data.</param>
        private void OnSelectedDomainChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( sender is ToolStripComboBox _comboBox )
                {
                    var _index = _comboBox.SelectedIndex;
                    _searchEngineUrl = _index switch
                    {
                        0 => AppSettings[ "EPA" ],
                        1 => AppSettings[ "DATA" ],
                        2 => AppSettings[ "GPO" ],
                        3 => AppSettings[ "USGI" ],
                        4 => AppSettings[ "CRS" ],
                        5 => AppSettings[ "LOC" ],
                        6 => AppSettings[ "OMB" ],
                        7 => AppSettings[ "UST" ],
                        8 => AppSettings[ "NASA" ],
                        9 => AppSettings[ "NOAA" ],
                        10 => AppSettings[ "DOI" ],
                        11 => AppSettings[ "NPS" ],
                        12 => AppSettings[ "GSA" ],
                        13 => AppSettings[ "NARA" ],
                        14 => AppSettings[ "DOC" ],
                        15 => AppSettings[ "HHS" ],
                        16 => AppSettings[ "NRC" ],
                        17 => AppSettings[ "DOE" ],
                        18 => AppSettings[ "NSF" ],
                        19 => AppSettings[ "USDA" ],
                        20 => AppSettings[ "CSB" ],
                        21 => AppSettings[ "IRS" ],
                        22 => AppSettings[ "FDA" ],
                        23 => AppSettings[ "CDC" ],
                        24 => AppSettings[ "ACE" ],
                        25 => AppSettings[ "DHS" ],
                        26 => AppSettings[ "DOD" ],
                        27 => AppSettings[ "USNO" ],
                        28 => AppSettings[ "NWS" ],
                        var _ => AppSettings[ "Google" ]
                    };
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [menu close clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnMenuCloseClick( object sender, RoutedEventArgs e )
        {
            CloseActiveTab( );
        }

        /// <summary>
        /// Called when [close other tabs clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnCloseOtherTabsClick( object sender, RoutedEventArgs e )
        {
            CloseOtherTabs( );
        }

        /// <summary>
        /// Called when [back button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnBackButtonClick( object sender, RoutedEventArgs e )
        {
            _currentBrowser.Back( );
        }

        /// <summary>
        /// Called when [forward button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnForwardButtonClick( object sender, RoutedEventArgs e )
        {
            _currentBrowser.Forward( );
        }

        /// <summary>
        /// Called when [downloads button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnDownloadsButtonClick( object sender, RoutedEventArgs e )
        {
            AddNewBrowserTab( AppSettings[ "Downloads" ] );
        }

        /// <summary>
        /// Called when [refresh button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnRefreshButtonClick( object sender, RoutedEventArgs e )
        {
            RefreshActiveTab( );
        }

        /// <summary>
        /// Called when [stop button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnStopButtonClick( object sender, RoutedEventArgs e )
        {
            StopActiveTab( );
        }

        /// <summary>
        /// Called when [menu lable mouse hover].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchButtonClick( object sender, MouseButtonEventArgs e )
        {
            try
            {
                var _search = new SearchDialog( );
                var _width = Width / 3 + ( int )( _search.Width * .66 );
                var _heigth = Height / 15;
                _search.Owner = this;
                var _pos = e.GetPosition( this );
                _search.PointToScreen( new Point( _pos.X, _pos.Y ) );
                _search.Show( );
                _search.SearchPanelTextBox.Focus( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [URL text box text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchDialogClosing( object sender, EventArgs e )
        {
            if( sender is SearchDialog _dialog )
            {
                try
                {
                    var _search = _dialog.Results;
                    _currentBrowser.Load( _search );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
                finally
                {
                    _dialog.SearchPanelTextBox.Name = string.Empty;
                }
            }
        }

        /// <summary>
        /// Called when [source button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSourceButtonClick( object sender, EventArgs e )
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
        /// Called when [URL text box clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs" />
        /// instance containing the event data.</param>
        private protected void OnUrlTextBoxClick( object sender, MouseEventArgs e )
        {
            try
            {
                var _psn = e.GetPosition( this );
                var _searchDialog = new SearchDialog( );
                _searchDialog.Owner = this;
                _searchDialog.Left = _psn.X - 100;
                _searchDialog.Top = _psn.Y + 100;
                _searchDialog.Show( );
                _searchDialog.SearchPanelTextBox.Focus( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [tool strip text box click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private protected void OnToolStripTextBoxClick( object sender, MouseEventArgs e )
        {
            try
            {
                var _psn = e.GetPosition( this );
                var _searchDialog = new SearchDialog( );
                _searchDialog.Owner = this;
                _searchDialog.Left = _psn.X;
                _searchDialog.Top = _psn.Y - 100;
                _searchDialog.Show( );
                _searchDialog.SearchPanelTextBox.Focus( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [tab pages clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs" />
        /// instance containing the event data.</param>
        private void OnTabPagesClick( object sender, MouseButtonEventArgs e )
        {
            if( e.LeftButton == MouseButtonState.Pressed )
            {
            }
        }

        /// <summary>
        /// Called when [closing].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" />
        /// instance containing the event data.</param>
        private void OnClosing( object sender, CancelEventArgs e )
        {
            // ask user if they are sure
            if( DownloadsInProgress( ) )
            {
                var _msg = "DownloadItems are in progress.";
                SendMessage( _msg );
            }

            try
            {
                SfSkinManager.Dispose( this );
                foreach( BrowserTabItem _tab in TabControl.Items )
                {
                    _tab.Dispose( );
                }

                _timer?.Dispose( );
                App.ActiveWindows.Clear( );
                Environment.Exit( 0 );
            }
            catch( Exception )
            {
                // ignore exception
            }
        }

        /// <summary>
        /// Called when [close search button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchPanelClearButtonClick( object sender, EventArgs e )
        {
            CloseSearch( );
        }

        /// <summary>
        /// Called when [previous search button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchPreviousButtonClick( object sender, EventArgs e )
        {
            FindTextOnPage( false );
        }

        /// <summary>
        /// Called when [next search button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchForwardButtonClick( object sender, EventArgs e )
        {
            FindTextOnPage( true );
        }

        /// <summary>
        /// Called when [search text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchPanelTextChanged( object sender, EventArgs e )
        {
            FindTextOnPage( true );
        }

        /// <summary>
        /// Called when [search key down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchKeyDown( object sender, KeyEventArgs e )
        {
            if( e.IsDown
                && sender is MetroTextBox )
            {
                FindTextOnPage( true );
            }
        }

        /// <summary>
        /// Called when [home button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnHomeButtonClick( object sender, EventArgs e )
        {
            _currentBrowser.Load( AppSettings[ "HomePage" ] );
        }

        /// <summary>
        /// Called when [go button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnGoButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _keywords = ToolStripTextBox.Text;

                //if( !string.IsNullOrEmpty( _keywords )
                // && ToolStripComboBox.SelectedIndex == -1 )
                {
                    SearchGovernmentDomains( _keywords );
                }

                //else if( !string.IsNullOrEmpty( _keywords )
                //&& ToolStripComboBox.SelectedIndex > -1 )
                {
                    var _search = SearchEngineUrl + _keywords;
                    _currentBrowser.Load( _search );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
            finally
            {
                ToolStripTextBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Called when [close button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnCloseButtonClick( object sender, EventArgs e )
        {
            try
            {
                Environment.Exit( 1 );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [fire fox button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnFireFoxButtonClick( object sender, EventArgs e )
        {
            ToolStripTextBox.SelectAll( );
            var _args = ToolStripTextBox.Text;
            if( !string.IsNullOrEmpty( _args ) )
            {
                OpenFireFoxBrowser( _args );
                ToolStripTextBox.Clear( );

                //ToolStripComboBox.SelectedIndex = -1;
            }
            else
            {
                OpenFireFoxBrowser( );
            }
        }

        /// <summary>
        /// Called when [close button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnEdgeButtonClick( object sender, EventArgs e )
        {
            ToolStripTextBox.SelectAll( );
            var _args = ToolStripTextBox.Text;
            if( !string.IsNullOrEmpty( _args ) )
            {
                OpenEdgeBrowser( _args );
                ToolStripTextBox.Clear( );

                //ToolStripComboBox.SelectedIndex = -1;
            }
            else
            {
                OpenEdgeBrowser( );
            }
        }

        /// <summary>
        /// Called when [close button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnChromeButtonClick( object sender, EventArgs e )
        {
            ToolStripTextBox.SelectAll( );
            var _args = ToolStripTextBox.Text;
            if( !string.IsNullOrEmpty( _args ) )
            {
                OpenChromeBrowser( _args );
                ToolStripTextBox.Clear( );

                //ToolStripComboBox.SelectedIndex = -1;
            }
            else
            {
                OpenChromeBrowser( );
            }
        }

        /// <summary>
        /// Called when [refresh button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSharepointButtonClicked( object sender, EventArgs e )
        {
            try
            {
                var _message = "THIS HAS NOT BEEN IMPLEMENTED";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [form closing].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnFormClosing( object sender, EventArgs e )
        {
            try
            {
                _timer?.Dispose( );
                Opacity = 1;
                FadeOutAsync( this );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [shown].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnActivated( object sender, EventArgs e )
        {
            try
            {
                Opacity = 0;
                FadeInAsync( this );
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnCloseOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Application.Exit( );
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// Called when [first button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// Called when [edit button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnRefreshButtonClick( object sender, EventArgs e )
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
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
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnMenuButtonClick( object sender, RoutedEventArgs e )
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
        /// Called when [toggle button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnToggleButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                if( !ToolStripPreviousButton.IsVisible )
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
        /// Called when [chat button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnChatButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                OpenMainWindow( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [tool strip text box mouse enter].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnToolStripTextBoxMouseEnter( object sender, RoutedEventArgs e )
        {
            try
            {
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
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}