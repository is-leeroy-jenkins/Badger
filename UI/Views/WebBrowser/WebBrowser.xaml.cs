// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-25-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-25-2025
// ******************************************************************************************
// <copyright file="WebBrowser.xaml.cs" company="Terry D. Eppler">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using Syncfusion.SfSkinManager;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Messages;
    using ToastNotifications.Position;
    using Application = System.Windows.Forms.Application;
    using KeyEventArgs = System.Windows.Input.KeyEventArgs;
    using MouseEventArgs = System.Windows.Input.MouseEventArgs;
    using Timer = System.Threading.Timer;
    using Properties;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWithPrivateSetter" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "CanSimplifyDictionaryLookupWithTryGetValue" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "PossibleUnintendedReferenceComparison" ) ]
    [ SuppressMessage( "ReSharper", "MergeSequentialChecks" ) ]
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
        /// The search engine identifier
        /// </summary>
        private protected string _searchEngineId;

        /// <summary>
        /// The search engine project identifier
        /// </summary>
        private protected string _searchEngineProjectId;

        /// <summary>
        /// The search engine name
        /// </summary>
        private protected string _searchEngineName;

        /// <summary>
        /// The search engine project number
        /// </summary>
        private protected string _searchEngineProjectNumber;

        /// <summary>
        /// The search engine key
        /// </summary>
        private protected string _searchEngineKey;

        /// <summary>
        /// The search engine URL
        /// </summary>
        private protected string _searchEngineUrl;

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
        private protected BrowserTabCollection TabPages;

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
            SfSkinManager.SetTheme(this, new Theme("FluentDark", App.Controls) );

            // Window Properties
            InitializeComponent( );
            InitializeBrowser( );
            RegisterCallbacks( );
            InitializeDelegates( );
            InitializeToolStrip( );
            InitializeTabControl( );
            WindowStyle = WindowStyle.None;

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
                    && TabControl.SelectedItem != null )
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
        /// Adds the blank window.
        /// </summary>
        public void AddBlankWindow( )
        {
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
                UrlTextBox.Focus( );
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

                var _tab = new BrowserTabItem
                {
                    Title = "New Tab"
                };

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
                url = Locations.NewTab;
            }

            var _newBrowser = new ChromiumWebBrowser( url );
            ConfigureBrowser( _newBrowser );
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
            var _tabItem = new BrowserTabItem
            {
                IsOpen = true,
                Browser = _newBrowser,
                Tab = tabItem,
                OriginalUrl = url,
                CurrentUrl = url,
                Title = "New Tab",
                DateCreated = DateTime.Now
            };

            tabItem.Tag = _tabItem;
            if( !string.IsNullOrEmpty( url )
                && url.StartsWith( Locations.Internal + ":" ) )
            {
                _newBrowser.JavascriptObjectRepository.Register( "host", _hostCallback,
                    BindingOptions.DefaultBinder );
            }

            return _tabItem;
        }

        /// <summary>
        /// this is done just once,
        /// to globally initialize CefSharp/CEF
        /// </summary>
        private void InitializeBrowser( )
        {
            ConfigureBrowser( Browser );
            _currentBrowser = Browser;
            _searchEngineUrl = Browser.Address;
            var _bool = bool.Parse( Locations.Proxy );
            if( _bool )
            {
                var _proxy = Locations.PingIP;
                var _port = Locations.ProxyPort;
                CefSharpSettings.Proxy = new ProxyOptions( _proxy, _port );
            }

            _hostCallback = new HostCallback( this );
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
                TabControl.SelectedItem = BrowserTab;
                Browser.Address = Locations.Google;
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
                SearchPanelForwardButton.Visibility = Visibility.Hidden;
                SearchPanelBackButton.Visibility = Visibility.Hidden;
                SearchPanelCancelButton.Visibility = Visibility.Hidden;
                ToolStripCancelButton.Visibility = Visibility.Hidden;
                ToolStripPreviousButton.Visibility = Visibility.Hidden;
                ToolStripNextButton.Visibility = Visibility.Hidden;
                SearchPanelHomeButton.Visibility = Visibility.Hidden;
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
                    || url.BeginsWith( Locations.Internal + ":" );
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
                ToolStripToolButton.Click += OnDeveloperToolsButtonClick;
                SearchPanelCancelButton.MouseLeftButtonDown += OnCloseButtonClick;
                ToolStripChatButton.Click += OnChatButtonClick;
                SearchPanelHomeButton.Click += OnSearchPanelHomeButtonClick;
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
                    ? TabControl.SelectedItem as BrowserTabItem
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
                return _currentBrowser;
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
                var _flag = Locations.WebGL;
                if( !string.IsNullOrEmpty( _flag ) )
                {
                    _config.WebGl = bool.Parse( _flag ).ToCefState( );
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
            if( _currentTab != null
                && TabPages.Count > 2 )
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
                    SearchPanelBackButton.Visibility = Visibility.Visible;
                }
                else
                {
                    ToolStripPreviousButton.Visibility = Visibility.Hidden;
                    SearchPanelBackButton.Visibility = Visibility.Hidden;
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
                    SearchPanelForwardButton.Visibility = Visibility.Visible;
                }
                else
                {
                    ToolStripNextButton.Visibility = Visibility.Hidden;
                    SearchPanelForwardButton.Visibility = Visibility.Hidden;
                }
            } );
        }

        /// <summary>
        /// Fades the in asynchronously.
        /// </summary>
        /// <param name="window">The o.</param>
        /// <param name="interval">The interval.</param>
        private async void FadeInAsync( Window window, int interval = 80 )
        {
            try
            {
                ThrowIf.Null( window, nameof( window ) );
                while( window.Opacity < 1.0 )
                {
                    await Task.Delay( interval );
                    window.Opacity += 0.05;
                }

                window.Opacity = 1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Fades the out asynchronously.
        /// </summary>
        /// <param name="window">The o.</param>
        /// <param name="interval">The interval.</param>
        private async void FadeOutAsync( Window window, int interval = 80 )
        {
            try
            {
                ThrowIf.Null( window, nameof( window ) );
                while( window.Opacity > 0.0 )
                {
                    await Task.Delay( interval );
                    window.Opacity -= 0.05;
                }

                window.Opacity = 0;
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
            Busy( );
            var _first = _lastSearch != UrlTextBox.Text;
            _lastSearch = UrlTextBox.Text;
            if( _lastSearch.IsNull( ) )
            {
                _currentBrowser.GetBrowser( )?.Find( _lastSearch, true, false, !_first );
            }
            else
            {
                _currentBrowser.GetBrowser( )?.StopFinding( true );
            }

            UrlTextBox.Focus( );
            Chill( );
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
                var _app = Locations.Branding;
                return Directory.Exists( _winXpDir )
                    ? _winXpDir + Locations.Branding + @"\" + name + @"\"
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
        private protected Task<ChromiumWebBrowser> GetBrowserAsync( string url, bool focused )
        {
            var _tcs = new TaskCompletionSource<ChromiumWebBrowser>( );
            try
            {
                ThrowIf.Null( url, nameof( url ) );
                ThrowIf.Null( focused, nameof( focused ) );
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
                Busy( );
                var _newUrl = url;
                var _urlLower = url.Trim( ).ToLower( );
                SetTabText( _currentBrowser, "Loading..." );
                if( _urlLower == "localhost" )
                {
                    _newUrl = "http://localhost/";
                }
                else if( url.IsFilePath( ) )
                {
                    _newUrl = url.PathToUrl( );
                }
                else
                {
                    Uri.TryCreate( url, UriKind.Absolute, out var _outUri );
                    if( !( _urlLower.StartsWith( "http" )
                        || _urlLower.StartsWith( Locations.Internal ) ) )
                    {
                        if( _outUri == null
                            || _outUri.Scheme != Uri.UriSchemeFile )
                        {
                            _newUrl = "https://" + url;
                        }
                    }

                    if( _urlLower.StartsWith( Locations.Internal + ":" )
                        || ( Uri.TryCreate( _newUrl, UriKind.Absolute, out _outUri )
                            && ( ( ( _outUri.Scheme == Uri.UriSchemeHttp
                                        || _outUri.Scheme == Uri.UriSchemeHttps )
                                    && _newUrl?.Contains( "." ) == true )
                                || _outUri.Scheme == Uri.UriSchemeFile ) ) )
                    {
                    }
                    else
                    {
                        _newUrl = Locations.Google + HttpUtility.UrlEncode( url );
                    }
                }

                _currentBrowser.Load( _newUrl );
                SetUrl( _newUrl );
                EnableBackButton( true );
                EnableForwardButton( false );
                Chill( );
            }
            catch( Exception e )
            {
                Fail( e );
            }
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private protected void Busy( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = true;
                }

                ToolStripProgressBar.Visibility = Visibility.Visible;
                ToolStripProgressBar.IsIndeterminate = true;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private protected void Chill( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = false;
                }

                ToolStripProgressBar.Visibility = Visibility.Hidden;
                ToolStripProgressBar.IsIndeterminate = false;
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
        /// DownloadItems the in progress.
        /// </summary>
        /// <returns></returns>
        public bool DownloadsInProgress( )
        {
            if( _downloadItems?.Values?.Count > 0 )
            {
                Busy( );
                foreach( var _item in _downloadItems.Values )
                {
                    if( _item.IsInProgress )
                    {
                        return true;
                    }
                }

                Chill( );
            }

            return false;
        }

        /// <summary>
        /// Refreshes the active tab.
        /// </summary>
        public void RefreshActiveTab( )
        {
            Busy( );
            var _address = _currentBrowser.Address;
            _currentBrowser.Load( _address );
            Chill( );
        }

        /// <summary>
        /// Opens the downloads tab.
        /// </summary>
        public void OpenDownloadsTab( )
        {
            Busy( );
            if( _downloadStrip != null )
            {
                TabControl.SelectedItem = _downloadStrip;
            }
            else
            {
                var _brw = AddNewBrowserTab( Locations.Downloads );
                _downloadStrip = ( BrowserTabItem )_brw.Parent;
            }

            Chill( );
        }

        /// <summary>
        /// Opens the developer tools.
        /// </summary>
        private void OpenDeveloperTools( )
        {
            Busy( );
            if( _currentBrowser == null )
            {
                var _message = "CurrentBrowser is null!";
                SendMessage( _message );
            }
            else
            {
                _currentBrowser.ShowDevTools( );
            }

            Chill( );
        }

        /// <summary>
        /// Opens the chrome browser.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private void OpenChromeBrowser( string args )
        {
            try
            {
                var _url = Locations.Google + args;
                var _info = new ProcessStartInfo
                {
                    FileName = Locations.Chrome,
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
                var _url = Locations.HomePage;
                var _info = new ProcessStartInfo
                {
                    FileName = Locations.Chrome,
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
                var _url = Locations.Google + args;
                var _info = new ProcessStartInfo
                {
                    FileName = Locations.FireFox,
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
                var _url = Locations.HomePage;
                var _info = new ProcessStartInfo
                {
                    FileName = Locations.Edge,
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
                var _url = Locations.Google + args;
                var _info = new ProcessStartInfo
                {
                    FileName = Locations.FireFox,
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
                var _url = Locations.HomePage;
                var _info = new ProcessStartInfo
                {
                    FileName = Locations.FireFox,
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
        /// Opens the chat window.
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
        /// Opens the search.
        /// </summary>
        private void OpenSearch( )
        {
            if( !_isSearchOpen )
            {
                _isSearchOpen = true;
                InvokeIf( ( ) =>
                {
                    UrlTextBox.Text = _lastSearch;
                    UrlTextBox.Focus( );
                    UrlTextBox.SelectAll( );
                } );
            }
            else
            {
                InvokeIf( ( ) =>
                {
                    UrlTextBox.Focus( );
                    UrlTextBox.SelectAll( );
                } );
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
                if( title.IsNull( ) )
                {
                    Title = Locations.Branding + " - " + title;
                    _currentTitle = title;
                }
                else
                {
                    Title = Locations.Branding;
                    _currentTitle = "New Tab";
                }
            } );
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
                UrlTextBox.Text = _finalUrl;
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
                ToolStripLookupButton.Visibility = Visibility.Visible;
                ToolStripRefreshButton.Visibility = Visibility.Visible;
                ToolStripCancelButton.Visibility = Visibility.Visible;
                ToolStripChatButton.Visibility = Visibility.Visible;
                ToolStripToolButton.Visibility = Visibility.Visible;
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
                ToolStripLookupButton.Visibility = Visibility.Hidden;
                ToolStripRefreshButton.Visibility = Visibility.Hidden;
                ToolStripCancelButton.Visibility = Visibility.Hidden;
                ToolStripChatButton.Visibility = Visibility.Hidden;
                ToolStripToolButton.Visibility = Visibility.Hidden;
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
                DateLabel.Content = DateTime.Now.ToShortDateString( );
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
                InitializeHotkeys( );
                InitializeButtons( );
                InitializeTitle( );
                InitializeToolStrip( );
                InitializeTabControl( );
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
                    if( !NetUtility.IsFocused( UrlTextBox ) )
                    {
                        var _url = e.NewValue.ToString( );
                        SetUrl( _url );
                    }

                    EnableBackButton( _currentBrowser.CanGoBack );
                    EnableForwardButton( _currentBrowser.CanGoForward );
                    SetTabText( ( ChromiumWebBrowser )sender, "Loading..." );
                    ToolStripRefreshButton.Visibility = Visibility.Hidden;
                    SearchPanelCancelButton.Visibility = Visibility.Visible;
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
                        SearchPanelCancelButton.Visibility = Visibility.Hidden;
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
        /// <param name = "sender" > </param>
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
            AddNewBrowserTab( Locations.Downloads );
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
        private void OnSearchDialogClosing( object sender, RoutedEventArgs e )
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
        private void OnSourceButtonClick( object sender, RoutedEventArgs e )
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
        private void OnSearchPanelClearButtonClick( object sender, RoutedEventArgs e )
        {
            CloseSearch( );
        }

        /// <summary>
        /// Called when [previous search button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchPreviousButtonClick( object sender, RoutedEventArgs e )
        {
            FindTextOnPage( false );
        }

        /// <summary>
        /// Called when [next search button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchForwardButtonClick( object sender, RoutedEventArgs e )
        {
            FindTextOnPage( true );
        }

        /// <summary>
        /// Called when [search text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnSearchPanelTextChanged( object sender, RoutedEventArgs e )
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
        private void OnSearchPanelHomeButtonClick( object sender, RoutedEventArgs e )
        {
            _currentBrowser.Load( Locations.HomePage );
        }

        /// <summary>
        /// Called when [go button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnGoButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                var _keywords = ToolStripTextBox.Text;
                if( !string.IsNullOrEmpty( _keywords ) )
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
        private void OnCloseButtonClick( object sender, RoutedEventArgs e )
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
        /// Called when [fire fox button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" />
        /// instance containing the event data.</param>
        private void OnFireFoxButtonClick( object sender, RoutedEventArgs e )
        {
            ToolStripTextBox.SelectAll( );
            var _args = ToolStripTextBox.Text;
            if( !string.IsNullOrEmpty( _args ) )
            {
                OpenFireFoxBrowser( _args );
                ToolStripTextBox.Clear( );
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
        private void OnEdgeButtonClick( object sender, RoutedEventArgs e )
        {
            ToolStripTextBox.SelectAll( );
            var _args = ToolStripTextBox.Text;
            if( !string.IsNullOrEmpty( _args ) )
            {
                OpenEdgeBrowser( _args );
                ToolStripTextBox.Clear( );
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
        private void OnChromeButtonClick( object sender, RoutedEventArgs e )
        {
            ToolStripTextBox.SelectAll( );
            var _args = ToolStripTextBox.Text;
            if( !string.IsNullOrEmpty( _args ) )
            {
                OpenChromeBrowser( _args );
                ToolStripTextBox.Clear( );
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
        private void OnSharepointButtonClicked( object sender, RoutedEventArgs e )
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
        private void OnClosing( object sender, RoutedEventArgs e )
        {
            try
            {
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
        private void OnActivated( object sender, RoutedEventArgs e )
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
        private void OnChatMenuOptionClick( object sender, RoutedEventArgs e )
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
        private void OnRefreshButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                RefreshActiveTab( );
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
                OpenChatWindow( );
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