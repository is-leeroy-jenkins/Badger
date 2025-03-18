// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-17-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        03-17-2025
// ******************************************************************************************
// <copyright file="ChatWindow.xaml.cs" company="Terry D. Eppler">
//     Badger is a budget execution & data analysis tool for EPA analysts
//     based on WPF, Net 6, and written in C Sharp.
// 
//     Copyright �  2022 Terry D. Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the �Software�),
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
//    THE SOFTWARE IS PROVIDED �AS IS�, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
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
//   ChatWindow.xaml.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using CefSharp;
    using CefSharp.Wpf;
    using Properties;
    using Syncfusion.SfSkinManager;
    using Syncfusion.Windows.Edit;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Messages;
    using ToastNotifications.Position;
    using MessageBox = System.Windows.MessageBox;
    using MouseEventArgs = System.Windows.Input.MouseEventArgs;
    using Timer = System.Threading.Timer;

    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    public partial class ChatWindow : Window, INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The entry
        /// </summary>
        private protected object _entry = new object( );

        /// <summary>
        /// The current clean URL
        /// </summary>
        private protected string _finalUrl;

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
        /// The search open
        /// </summary>
        private protected bool _isSearchOpen;

        /// <summary>
        /// The system prompt fro the GPT
        /// </summary>
        private protected string _systemPrompt;

        /// <summary>
        /// The user prompt for the GPT
        /// </summary>
        private protected string _userPrompt;

        /// <summary>
        /// The messages
        /// </summary>
        private protected ChatLog _messages;

        /// <summary>
        /// The key words for the custome search engine
        /// </summary>
        private protected string _keyWords;

        /// <summary>
        /// The role
        /// </summary>
        private protected string _role;

        /// <summary>
        /// The role
        /// </summary>
        private protected GptRequests _requestType;

        /// <summary>
        /// The role
        /// </summary>
        private protected string _voice;

        /// <summary>
        /// The endpoint
        /// </summary>
        private protected string _endpoint;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The language
        /// </summary>
        private protected string _language;

        /// <summary>
        /// The selected document
        /// </summary>
        private protected string _selectedDocument;

        /// <summary>
        /// The selected request
        /// </summary>
        private protected string _selectedRequest;

        /// <summary>
        /// The theme
        /// </summary>
        private protected readonly DarkMode _theme = new DarkMode( );

        /// <summary>
        /// The HTTP client
        /// </summary>
        private protected HttpClient _httpClient;

        /// <summary>
        /// The options
        /// </summary>
        private protected GptOptions _options;

        /// <summary>
        /// A number between 0.0 and 1.0   between 0 and 2.
        /// Higher values like 0.8 will make the output more random,
        /// while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        private protected double _temperature;

        /// <summary>
        /// An alternative to sampling with temperature,
        /// called nucleus sampling, where the model considers
        /// the results of the tokens with top_p probability mass.
        /// So 0.1 means only the tokens comprising the top 10% probability
        /// mass are considered. We generally recommend altering this
        /// or temperature but not both.
        /// </summary>
        private protected double _topPercent;

        /// <summary>
        /// The store
        /// </summary>
        private protected bool _store;

        /// <summary>
        /// The stream
        /// </summary>
        private protected bool _stream;

        /// <summary>
        /// The image size
        /// </summary>
        private protected string _size;

        /// <summary>
        /// An upper bound for the number of tokens
        /// that can be generated for a completion
        /// </summary>
        private protected int _maximumTokens;

        /// <summary>
        /// A number between -2.0 and 2.0. Positive values penalize new
        /// tokens based on their existing frequency in the text so far,
        /// decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        private protected double _frequency;

        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens
        /// based on whether they appear in the text so far,
        /// increasing the model's likelihood to talk about new topics.
        /// </summary>
        private protected double _presence;

        /// <summary>
        /// The models
        /// </summary>
        private protected IList<string> _models;

        /// <summary>
        /// The image sizes
        /// </summary>
        private protected IList<string> _imageSizes;

        /// <summary>
        /// The image sizes
        /// </summary>
        private protected IDictionary<string, string> _voices;

        /// <summary>
        /// The chat model
        /// </summary>
        private protected string _model;

        /// <summary>
        /// The speech recognition engine
        /// </summary>
        private protected SpeechRecognitionEngine _engine;

        /// <summary>
        /// The speech synthesizer
        /// </summary>
        private protected SpeechSynthesizer _synthesizer;

        /// <summary>
        /// The current browser
        /// </summary>
        private protected ChromiumWebBrowser _currentBrowser;

        /// <summary>
        /// The download names
        /// </summary>
        private protected Dictionary<int, string> _downloadNames;

        /// <summary>
        /// The downloads
        /// </summary>
        private protected Dictionary<int, DownloadItem> _downloadItems;

        /// <summary>
        /// The full screen
        /// </summary>
        private protected bool _fullScreen;

        /// <summary>
        /// The time
        /// </summary>
        private protected int _time;

        /// <summary>
        /// The number
        /// </summary>
        private protected int _number;

        /// <summary>
        /// The download cancel requests
        /// </summary>
        private protected List<int> _cancelRequests;

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
        /// The host
        /// </summary>
        private protected HostCallback _hostCallback;

        /// <summary>
        /// The timer callback
        /// </summary>
        private protected TimerCallback _timerCallback;

        /// <summary>
        /// The browser action
        /// </summary>
        private protected Func<ChromiumWebBrowser> _browserCallback;

        /// <summary>
        /// The status update
        /// </summary>
        private protected Action _statusUpdate;

        /// <summary>
        /// The x
        /// </summary>
        private protected double[ ] _x =
        {
            1,
            2,
            3,
            4,
            5
        };

        /// <summary>
        /// The y
        /// </summary>
        private protected double[ ] _y =
        {
            1,
            4,
            9,
            16,
            25
        };

        /// <inheritdoc />
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChatWindow"/> class.
        /// </summary>
        public ChatWindow( )
        {
            // Theme Properties
            SfSkinManager.SetTheme( this, new Theme( "FluentDark", App.Controls ) );

            // Window Initialization
            InitializeComponent( );
            RegisterCallbacks( );
            InitializeDelegates( );
            InitializeToolStrip( );

            // Control Properties
            TemperatureSlider.Value = 0.08;
            TopPercentSlider.Value = 0.09;
            PresenceSlider.Value = 0.00;
            FrequencySlider.Value = 0.00;
            MaxTokenSlider.Value = 2048;

            // GPT Parameters
            _store = false;
            _stream = true;
            _temperature = TemperatureSlider.Value;
            _topPercent = TopPercentSlider.Value;
            _presence = PresenceSlider.Value;
            _frequency = FrequencySlider.Value;
            _maximumTokens = ( int )MaxTokenSlider.Value;
            _imageSizes = new List<string>( );
            _voices = new Dictionary<string, string>( );
            _systemPrompt = App.Instructions;

            // Event Wiring
            Loaded += OnLoad;
            Closing += OnClosing;
        }

        /// <summary>
        /// Initializes the plotter.
        /// </summary>
        private protected void InitializePlotter( )
        {
            try
            {
                Plotter.Plot.Add.Scatter( _x, _y );
                Plotter.Refresh( );
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
                SetToolbarVisibility( false );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the user system text box.
        /// </summary>
        private void InitializeChatEditor( )
        {
            try
            {
                ChatEditor.EnableOutlining = true;
                ChatEditor.EnableIntellisense = false;
                ChatEditor.DocumentLanguage = Languages.Text;
                ChatEditor.IsMultiLine = true;
                ChatEditor.IsUndoEnabled = true;
                ChatEditor.IsRedoEnabled = true;
                ChatEditor.LineNumberAreaBackground = _theme.BlackBrush;
                ChatEditor.LineNumberTextForeground = _theme.GreenBrush;
                ChatEditor.SelectionBackground = _theme.SteelBlueBrush;
                ChatEditor.SelectionForeground = _theme.WhiteForeground;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the interface asynchronous.
        /// </summary>
        public void InitializeInterface( )
        {
            try
            {
                LoadWebBrowser( );
                LoadFileBrowser( );
                LoadGptFileDialog( );
                LoadCalculator( );
                LoadSystemDialog( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Speeches to text.
        /// </summary>
        private void InitializeSpeechEngine( )
        {
            try
            {
                if( _engine != null )
                {
                    _engine.RecognizeAsync( RecognizeMode.Multiple );
                }

                _engine = new SpeechRecognitionEngine( new CultureInfo( "en-US" ) );
                _engine.LoadGrammar( new DictationGrammar( ) );
                _engine.SpeechRecognized += OnSpeechRecognized;
                _engine.SpeechHypothesized += OnSpeechHypothesized;
                _engine.SetInputToDefaultAudioDevice( );
                _engine.RecognizeAsync( RecognizeMode.Multiple );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
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
                KeyboardCallback.AddHotKey( this, RefreshActiveTab, Keys.F5 );
                KeyboardCallback.AddHotKey( this, OpenDeveloperTools, Keys.F12 );

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
        /// Registers the callbacks.
        /// </summary>
        private protected void RegisterCallbacks( )
        {
            try
            {
                ToolStripTextBox.TextChanged += OnToolStripTextBoxTextChanged;
                ToolStripMenuButton.Click += OnToggleButtonClick;
                TemperatureTextBox.TextChanged += OnParameterTextBoxChanged;
                PresenseTextBox.TextChanged += OnParameterTextBoxChanged;
                FrequencyTextBox.TextChanged += OnParameterTextBoxChanged;
                TopPercentTextBox.TextChanged += OnParameterTextBoxChanged;
                ClearButton.Click += OnClearButtonClick;
                ToolStripSendButton.Click += OnSendButtonClick;
                ListenCheckBox.Checked += OnListenCheckedChanged;
                MuteCheckBox.Checked += OnMuteCheckedBoxChanged;
                StoreCheckBox.Checked += OnStoreCheckBoxChecked;
                GenerationListBox.SelectionChanged += OnRequestListBoxSelectionChanged;
                ImageSizeDropDown.SelectionChanged += OnImageSizeListBoxSelectionChanged;
                ToolStripRefreshButton.Click += OnRefreshButtonClick;
                ToolStripSendButton.Click += OnGoButtonClicked;
                GptFileButton.Click += OnFileApiButtonClick;
                LanguageListBox.SelectionChanged += OnLanguageListBoxSelectionChanged;
                DocumentListBox.SelectionChanged += OnDocumentListBoxSelectionChanged;
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
        /// Begins the initialize.
        /// </summary>
        private protected void Busy( )
        {
            try
            {
                ProgressBar.IsIndeterminate = true;
                ProgressBar.Visibility = Visibility.Visible;
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
        /// Shows the progress.
        /// </summary>
        private protected void CheckProgress( )
        {
            try
            {
                lock( _entry )
                {
                    if( _busy )
                    {
                        ProgressBar.IsIndeterminate = true;
                        ProgressBar.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ProgressBar.IsIndeterminate = false;
                        ProgressBar.Visibility = Visibility.Hidden;
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
        private protected void Chill( )
        {
            try
            {
                ProgressBar.Visibility = Visibility.Hidden;
                ProgressBar.IsIndeterminate = false;
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
        /// Clears the callbacks.
        /// </summary>
        private protected virtual void ClearDelegates( )
        {
            try
            {
                _timerCallback = null;
                _statusUpdate = null;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the controls.
        /// </summary>
        private void ClearChatControls( )
        {
            try
            {
                ClearTextBoxes( );
                ClearSliders( );
                ClearComboBoxes( );
                ClearCheckBoxes( );
                ClearListBoxes( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the parameters.
        /// </summary>
        private void ClearParameters( )
        {
            try
            {
                _store = false;
                _stream = true;
                _model = "";
                _size = "";
                _endpoint = "";
                _number = 1;
                _maximumTokens = 2048;
                _temperature = 0.08;
                _topPercent = 0.09;
                _frequency = 0.00;
                _presence = 0.00;
                _language = "";
                _voice = "";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Cleans the URL.
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
        /// Clears the filter.
        /// </summary>
        private void ClearCheckBoxes( )
        {
            try
            {
                MuteCheckBox.IsChecked = false;
                ListenCheckBox.IsChecked = false;
                StoreCheckBox.IsChecked = false;
                StreamCheckBox.IsChecked = true;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the list boxes.
        /// </summary>
        private void ClearSliders( )
        {
            try
            {
                PresenceSlider.Value = 0.00;
                FrequencySlider.Value = 0.00;
                TemperatureSlider.Value = 0.08;
                TopPercentSlider.Value = 0.09;
                MaxTokenSlider.Value = 2048;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Clears the labels.
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
        /// Clears the combo boxes.
        /// </summary>
        private void ClearComboBoxes( )
        {
            try
            {
                GenerationListBox.SelectedIndex = -1;
                ModelListBox.SelectedIndex = -1;
                VoiceListBox.SelectedIndex = -1;
                ImageSizeDropDown.SelectedIndex = -1;
                LanguageListBox.SelectedIndex = -1;
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
                PopulateDocumentListBox( );
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
                ChatEditor.Text = "";
                ChatTextBox.Text = "";
                ToolStripTextBox.Text = "";
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
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Creates the notifier.
        /// </summary>
        /// <returns>
        /// </returns>
        private Notifier CreateNotifier( )
        {
            try
            {
                var _position = new PrimaryScreenPositionProvider( Corner.BottomRight, 10, 10 );
                var _count = MaximumNotificationCount.UnlimitedNotifications( );
                var _lifeTime =
                    new TimeAndCountBasedLifetimeSupervisor( TimeSpan.FromSeconds( 5 ), _count );

                return new Notifier( cfg =>
                {
                    cfg.LifetimeSupervisor = _lifeTime;
                    cfg.PositionProvider = _position;
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
        /// Closes the active tab.
        /// </summary>
        public void CloseActiveTab( )
        {
            var _index = TabControl.Items.IndexOf( TabControl.SelectedItem );
            TabControl.Items.RemoveAt( _index );
            if( ( TabControl.Items.Count - 1 ) > _index )
            {
                TabControl.SelectedItem = TabControl.Items[ _index ];
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
                    SearchPanelBackButton.Visibility = Visibility.Visible;
                }
                else
                {
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
                    SearchPanelForwardButton.Visibility = Visibility.Visible;
                }
                else
                {
                    SearchPanelForwardButton.Visibility = Visibility.Hidden;
                }
            } );
        }

        /// <summary>
        /// Fades the in asynchronous.
        /// </summary>
        /// <param name="form">The form.</param>
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
        /// <param name="form">The form.</param>
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
        /// 
        /// Shows the items.
        /// </summary>
        private void SetToolbarVisibility( bool visible = true )
        {
            try
            {
                if( visible )
                {
                    ToolStripTextBox.Visibility = Visibility.Visible;
                    ToolStripSendButton.Visibility = Visibility.Visible;
                    ToolStripRefreshButton.Visibility = Visibility.Visible;
                    ToolStripTextBox.Visibility = Visibility.Visible;
                    ToolStripCancelButton.Visibility = Visibility.Visible;
                }
                else
                {
                    ToolStripTextBox.Visibility = Visibility.Hidden;
                    ToolStripSendButton.Visibility = Visibility.Hidden;
                    ToolStripRefreshButton.Visibility = Visibility.Hidden;
                    ToolStripCancelButton.Visibility = Visibility.Hidden;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sends the HTTP message.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <returns></returns>
        public string SendHttpMessage( string question )
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Tls;

            // text-davinci-002, text-davinci-003
            var _model = ModelListBox.SelectedItem.ToString( );
            var _url = "https://api.openai.com/v1/completions";
            if( _model?.IndexOf( "gpt-3.5-turbo" ) != -1 )
            {
                //Chat GTP 4 https://openai.com/research/gpt-4
                _url = "https://api.openai.com/v1/chat/completions";
            }

            var _request = WebRequest.Create( _url );
            _request.Method = "POST";
            _request.ContentType = "application/json";
            _request.Headers.Add( "Authorization", "Bearer " + App.OpenAiKey );
            var _maxTokens = int.Parse( MaxTokenTextBox.Text );// 2048

            // 0.5
            var _temp = double.Parse( TemperatureTextBox.Text );
            if( ( _temp < 0d ) | ( _temp > 1d ) )
            {
                var _msg = "Randomness has to be between 0 and 2"
                    + "with higher values resulting in more random text; Default 1 ";

                SendMessage( _msg );
                return "";
            }

            var _data = "";
            if( _model?.IndexOf( "gpt-3.5-turbo" ) != -1 )
            {
                _data = "{";
                _data += " \"model\":\"" + _model + "\",";
                _data += " \"messages\": [{\"role\": \"user\", \"content\": \""
                    + PadQuotes( question ) + "\"}]";

                _data += "}";
            }
            else
            {
                _data = "{";
                _data += " \"model\":\"" + _model + "\",";
                _data += " \"prompt\": \"" + PadQuotes( question ) + "\",";
                _data += " \"max_completion_tokens\": " + _maxTokens + ",";
                _data += " \"temperature\": " + _temp + ", ";
                _data += " \"frequency_penalty\": 0.0" + ", ";
                _data += " \"presence_penalty\": 0.0" + ", ";
                _data += " \"stop\": [\"#\", \";\"]";
                _data += "}";
            }

            using var _streamWriter = new StreamWriter( _request.GetRequestStream( ) );
            _streamWriter.Write( _data );
            _streamWriter.Flush( );
            _streamWriter.Close( );
            var _json = "";
            using( var _response = _request.GetResponse( ) )
            {
                using var _responseStream = _response.GetResponseStream( );
                using var _reader = new StreamReader( _responseStream );
                _json = _reader.ReadToEnd( );
            }

            var _objects = new Dictionary<string, object>( );
            var _choices = _objects.Keys.ToList( );
            var _choice = _choices[ 0 ];
            var _message = "";
            if( _model?.IndexOf( "gpt-3.5-turbo" ) != -1 )
            {
                var _key = _objects[ "message" ];
                var _kvp = new Dictionary<string, object>( );
            }
            else
            {
                _message = ( string )_objects[ "text" ];
            }

            return _message;
        }

        /// <summary>
        /// Opens the GPT file dialog.
        /// </summary>
        private protected void LoadGptFileDialog( )
        {
            try
            {
                var _gptFileDialog = new GptFileDialog
                {
                    Topmost = true,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                App.ActiveWindows.Add( "GptFileDialog", _gptFileDialog );
                _gptFileDialog.Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the file browser.
        /// </summary>
        private protected void LoadFileBrowser( )
        {
            try
            {
                var _fileBrowser = new FileBrowser( )
                {
                    Topmost = true,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                App.ActiveWindows.Add( "FileBrowser", _fileBrowser );
                _fileBrowser.Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the search dialog.
        /// </summary>
        private protected void LoadSearchDialog( )
        {
            try
            {
                var _searchDialog = new SearchDialog
                {
                    Topmost = true,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                App.ActiveWindows.Add( "SearchDialog", _searchDialog );
                _searchDialog.Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the image dialog asynchronous.
        /// </summary>
        /// <returns></returns>
        private protected void LoadImageDialog( )
        {
            try
            {
                var _gptImageDialog = new GptImageDialog
                {
                    Topmost = true,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                App.ActiveWindows.Add( "GptImageDialog", _gptImageDialog );
                _gptImageDialog.Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the WebBrowser.
        /// </summary>
        private protected void LoadWebBrowser( )
        {
            try
            {
                var _web = new WebBrowser( )
                {
                    Topmost = true,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                App.ActiveWindows.Add( "WebBrowser", _web );
                _web.Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the prompt dialog.
        /// </summary>
        private protected void LoadSystemDialog( )
        {
            try
            {
                var _default = App.Instructions;
                var _systemDialog = new SystemDialog( )
                {
                    Topmost = true,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                _systemDialog.SystemDialogTextBox.Text = _default;
                App.ActiveWindows.Add( "SystemDialog", _systemDialog );
                _systemDialog.Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the calculator window.
        /// </summary>
        private protected void LoadCalculator( )
        {
            try
            {
                var _calculator = new CalculatorWindow( )
                {
                    Topmost = true,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                App.ActiveWindows.Add( "CalculatorWindow", _calculator );
                _calculator.Hide( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the file browser.
        /// </summary>
        private protected void OpenFileBrowser( )
        {
            try
            {
                Busy( );
                if( App.ActiveWindows.Keys.Contains( "FileBrowser" ) )
                {
                    var _window = ( FileBrowser )App.ActiveWindows[ "FileBrowser" ];
                    _window.Owner = this;
                    _window.Show( );
                }
                else
                {
                    var _fileBrowser = new FileBrowser( )
                    {
                        Topmost = true,
                        Owner = this,
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };

                    _fileBrowser.Show( );
                }

                Chill( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the prompt dialog.
        /// </summary>
        private protected void OpenSystemDialog( )
        {
            try
            {
                Busy( );
                if( App.ActiveWindows.Keys.Contains( "SystemDialog" ) )
                {
                    var _window = ( SystemDialog )App.ActiveWindows[ "SystemDialog" ];
                    _window.Owner = this;
                    _window.Show( );
                }
                else
                {
                    var _systemDialog = new SystemDialog
                    {
                        Topmost = true,
                        Owner = this,
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };

                    _systemDialog.Show( );
                }

                Chill( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the calculator.
        /// </summary>
        private protected void OpenCalculator( )
        {
            try
            {
                Busy( );
                if( App.ActiveWindows.Keys.Contains( "CalculatorWindow" ) )
                {
                    var _window = ( CalculatorWindow )App.ActiveWindows[ "CalculatorWindow" ];
                    _window.Topmost = true;
                    _window.Show( );
                }
                else
                {
                    var _calculator = new CalculatorWindow
                    {
                        Topmost = true,
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };

                    _calculator.Show( );
                }

                Chill( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Opens the file browser.
        /// </summary>
        private protected void OpenGptFileDialog( )
        {
            try
            {
                Busy( );
                if( App.ActiveWindows.Keys.Contains( "GptFileDialog" ) )
                {
                    var _window = ( GptFileDialog )App.ActiveWindows[ "GptFileDialog" ];
                    _window.Owner = this;
                    _window.Show( );
                }
                else
                {
                    var _fileDialog = new GptFileDialog( )
                    {
                        Topmost = true,
                        Owner = this,
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };

                    _fileDialog.Show( );
                }

                Chill( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the image dialog asynchronous.
        /// </summary>
        /// <returns></returns>
        private protected void OpenImageDialog( )
        {
            try
            {
                Busy( );
                if( App.ActiveWindows.Keys.Contains( "GptImageDialog" ) )
                {
                    var _window = ( GptImageDialog )App.ActiveWindows[ "GptImageDialog" ];
                    _window.Owner = this;
                    _window.Show( );
                }
                else
                {
                    var _gptImageDialog = new GptImageDialog
                    {
                        Topmost = true,
                        Owner = this,
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };

                    _gptImageDialog.Show( );
                }

                Chill( );
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
        /// Pads the quotes.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// string
        /// </returns>
        private string PadQuotes( string input )
        {
            try
            {
                ThrowIf.Empty( input, nameof( input ) );
                if( input.IndexOf( "\\" ) != -1 )
                {
                    input = input.Replace( "\\", @"\\" );
                }

                if( input.IndexOf( "\n\r" ) != -1 )
                {
                    input = input.Replace( "\n\r", @"\n" );
                }

                if( input.IndexOf( "\r" ) != -1 )
                {
                    input = input.Replace( "\r", @"\r" );
                }

                if( input.IndexOf( "\n" ) != -1 )
                {
                    input = input.Replace( "\n", @"\n" );
                }

                if( input.IndexOf( "\t" ) != -1 )
                {
                    input = input.Replace( "\t", @"\t" );
                }

                if( input.IndexOf( "\"" ) != -1 )
                {
                    return input.Replace( "\"", @"""" );
                }
                else
                {
                    return input;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Sets the models.
        /// </summary>
        private async void PopulateModelsAsync( )
        {
            try
            {
                Busy( );
                var _url = "https://api.openai.com/v1/models";
                _httpClient = new HttpClient( );
                _httpClient.Timeout = new TimeSpan( 0, 0, 3 );
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue( "Bearer", App.OpenAiKey );

                var _async = await _httpClient.GetAsync( _url );
                _async.EnsureSuccessStatusCode( );
                var _content = await _async.Content.ReadAsStringAsync( );
                var _models = new List<string>( );
                using var _document = JsonDocument.Parse( _content );
                var _root = _document.RootElement;
                if( _root.TryGetProperty( "data", out var _data )
                    && _data.ValueKind == JsonValueKind.Array )
                {
                    foreach( var _item in _data.EnumerateArray( ) )
                    {
                        if( _item.TryGetProperty( "id", out var _element ) )
                        {
                            _models.Add( _element.GetString( ) );
                        }
                    }
                }

                _models.Sort( );
                ModelListBox.Items.Clear( );
                Dispatcher.BeginInvoke( ( ) =>
                {
                    foreach( var _lm in _models )
                    {
                        if( !_lm.StartsWith( "ft" ) )
                        {
                            ModelListBox.Items.Add( _lm );
                        }
                    }
                } );

                Chill( );
                ModelListBox.SelectedIndex = -1;
            }
            catch( HttpRequestException ex )
            {
                Fail( ex );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the image sizes.
        /// </summary>
        private void PopulateImageSizes( )
        {
            try
            {
                ImageSizeDropDown.Items?.Clear( );
                if( string.IsNullOrEmpty( _model ) )
                {
                    ImageSizeDropDown.Items.Add( "256 X 256" );
                    ImageSizeDropDown.Items.Add( "512 X 512" );
                    ImageSizeDropDown.Items.Add( "1024 X 1024" );
                    ImageSizeDropDown.Items.Add( "1792 X 1024" );
                    ImageSizeDropDown.Items.Add( "1024 X 1792" );
                    ImageSizeDropDown.SelectedIndex = -1;
                }
                else if( !string.IsNullOrEmpty( _model ) )
                {
                    switch( _model )
                    {
                        case "dall-e-2":
                        {
                            ImageSizeDropDown.Items.Add( "256 X 256" );
                            ImageSizeDropDown.Items.Add( "512 X 512" );
                            ImageSizeDropDown.Items.Add( "1024 X 1024" );
                            ImageSizeDropDown.SelectedIndex = -1;
                            break;
                        }
                        case "dall-e-3":
                        {
                            ImageSizeDropDown.Items.Add( "1024 X 1024" );
                            ImageSizeDropDown.Items.Add( "1792 X 1024" );
                            ImageSizeDropDown.Items.Add( "1024 X 1792" );
                            ImageSizeDropDown.SelectedIndex = -1;
                            break;
                        }
                        default:
                        {
                            ImageSizeDropDown.Items.Add( "256 X 256" );
                            ImageSizeDropDown.Items.Add( "512 X 512" );
                            ImageSizeDropDown.Items.Add( "1024 X 1024" );
                            ImageSizeDropDown.Items.Add( "1792 X 1024" );
                            ImageSizeDropDown.Items.Add( "1024 X 1792" );
                            ImageSizeDropDown.SelectedIndex = -1;
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
        /// Populates the text generation models.
        /// </summary>
        private void PopulateTextModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "gpt-4-0613" );
                ModelListBox.Items.Add( "gpt-4-0314" );
                ModelListBox.Items.Add( "gpt-4-turbo-2024-04-09" );
                ModelListBox.Items.Add( "gpt-4o-2024-08-06" );
                ModelListBox.Items.Add( "gpt-4o-2024-11-20" );
                ModelListBox.Items.Add( "gpt-4o-2024-05-13" );
                ModelListBox.Items.Add( "gpt-4o-mini-2024-07-18" );
                ModelListBox.Items.Add( "o1-2024-12-17" );
                ModelListBox.Items.Add( "o1-mini-2024-09-12" );
                ModelListBox.Items.Add( "text-davinci-003" );
                ModelListBox.Items.Add( "text-curie-001" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the completion models.
        /// </summary>
        private void PopulateCompletionModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "gpt-4-0613" );
                ModelListBox.Items.Add( "gpt-4-0314" );
                ModelListBox.Items.Add( "gpt-4-turbo-2024-04-09" );
                ModelListBox.Items.Add( "gpt-4o-2024-08-06" );
                ModelListBox.Items.Add( "gpt-4o-2024-11-20" );
                ModelListBox.Items.Add( "gpt-4o-2024-05-13" );
                ModelListBox.Items.Add( "gpt-4o-mini-2024-07-18" );
                ModelListBox.Items.Add( "o1-2024-12-17" );
                ModelListBox.Items.Add( "o1-mini-2024-09-12" );
                ModelListBox.Items.Add( "o3-mini-2025-01-31" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the image generation models.
        /// </summary>
        private void PopulateImageModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "dall-e-2" );
                ModelListBox.Items.Add( "dall-e-3" );
                ModelListBox.Items.Add( "gpt-4-0613" );
                ModelListBox.Items.Add( "gpt-4-0314" );
                ModelListBox.Items.Add( "gpt-4o-mini-2024-07-18" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the translation models.
        /// </summary>
        private void PopulateTranslationModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "whisper-1" );
                ModelListBox.Items.Add( "gpt-4-0613" );
                ModelListBox.Items.Add( "gpt-4-0314" );
                ModelListBox.Items.Add( "gpt-4-turbo-2024-04-09" );
                ModelListBox.Items.Add( "text-davinci-003" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the transcription models.
        /// </summary>
        private void PopulateTranscriptionModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "whisper-1" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the embedding models.
        /// </summary>
        private void PopulateEmbeddingModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "text-embedding-3-small" );
                ModelListBox.Items.Add( "text-embedding-3-large" );
                ModelListBox.Items.Add( "text-embedding-ada-002" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the fine tuning models.
        /// </summary>
        private void PopulateFineTuningModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "gpt-4o-2024-08-06" );
                ModelListBox.Items.Add( "gpt-4o-mini-2024-07-18" );
                ModelListBox.Items.Add( "gpt-4-0613" );
                ModelListBox.Items.Add( "gpt-3.5-turbo-0125" );
                ModelListBox.Items.Add( "gpt-3.5-turbo-1106" );
                ModelListBox.Items.Add( "gpt-3.5-turbo-0613" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the speech models.
        /// </summary>
        private void PopulateSpeechModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "tts-1" );
                ModelListBox.Items.Add( "tts-1-hd" );
                ModelListBox.Items.Add( "gpt-4o-audio-preview-2024-12-17" );
                ModelListBox.Items.Add( "gpt-4o-audio-preview-2024-10-01" );
                ModelListBox.Items.Add( "gpt-4o-mini-audio-preview-2024-12-17" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the upload API models.
        /// </summary>
        private void PopulateUploadApiModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "gpt-4-0613" );
                ModelListBox.Items.Add( "gpt-4-0314" );
                ModelListBox.Items.Add( "gpt-4-turbo-2024-04-09" );
                ModelListBox.Items.Add( "gpt-4o-mini-2024-07-18" );
                ModelListBox.Items.Add( "gpt-4o-2024-08-06" );
                ModelListBox.Items.Add( "gpt-4o-2024-11-20" );
                ModelListBox.Items.Add( "gpt-4o-2024-05-13" );
                ModelListBox.Items.Add( "o1-2024-12-17" );
                ModelListBox.Items.Add( "o1-mini-2024-09-12" );
                ModelListBox.Items.Add( "o3-mini-2025-01-31" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the vector store models.
        /// </summary>
        private void PopulateVectorStoreModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "gpt-4-0613" );
                ModelListBox.Items.Add( "gpt-4-0314" );
                ModelListBox.Items.Add( "gpt-4-turbo-2024-04-09" );
                ModelListBox.Items.Add( "gpt-4o-mini-2024-07-18" );
                ModelListBox.Items.Add( "gpt-4o-2024-08-06" );
                ModelListBox.Items.Add( "gpt-4o-2024-11-20" );
                ModelListBox.Items.Add( "gpt-4o-2024-05-13" );
                ModelListBox.Items.Add( "o1-2024-12-17" );
                ModelListBox.Items.Add( "o1-mini-2024-09-12" );
                ModelListBox.Items.Add( "o3-mini-2025-01-31" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the file API models.
        /// </summary>
        private void PopulateFileApiModels( )
        {
            try
            {
                ModelListBox.Items?.Clear( );
                ModelListBox.Items.Add( "gpt-4-0613" );
                ModelListBox.Items.Add( "gpt-4-0314" );
                ModelListBox.Items.Add( "gpt-4-turbo-2024-04-09" );
                ModelListBox.Items.Add( "gpt-4o-mini-2024-07-18" );
                ModelListBox.Items.Add( "gpt-4o-2024-08-06" );
                ModelListBox.Items.Add( "gpt-4o-2024-11-20" );
                ModelListBox.Items.Add( "gpt-4o-2024-05-13" );
                ModelListBox.Items.Add( "o1-2024-12-17" );
                ModelListBox.Items.Add( "o1-mini-2024-09-12" );
                ModelListBox.Items.Add( "o3-mini-2025-01-31" );
                ModelListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the language ListBox.
        /// </summary>
        private void PopulateDocumentListBox( )
        {
            try
            {
                if( !string.IsNullOrEmpty( _language ) )
                {
                    switch( _language )
                    {
                        case "TXT":
                        {
                            PopulateTextDocuments( );
                            break;
                        }
                        case "CS":
                        {
                            PopulateCSharpDocuments( );
                            break;
                        }
                        case "PY":
                        {
                            PopulatePythonDocuments( );
                            break;
                        }
                        case "SQL":
                        {
                            PopulateSqlDocuments( );
                            break;
                        }
                        case "JS":
                        {
                            PopulateJavaScriptDocuments( );
                            break;
                        }
                        case "CPP":
                        {
                            PopulateCPlusDocuments( );
                            break;
                        }
                        case "VBA":
                        {
                            PopulateVisualBasicDocuments( );
                            break;
                        }
                        default:
                        {
                            PopulateTextDocuments( );
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
        /// Populates the visual basic documents.
        /// </summary>
        private void PopulateVisualBasicDocuments( )
        {
            var _path = Locations.PathPrefix + @"Resources\Documents\Editor\VBA\";
            TabControl.SelectedIndex = 0;
            ChatEditor.DocumentLanguage = Languages.VisualBasic;
            DocumentListBox.Items?.Clear( );
            var _documents = Directory.GetFiles( _path );
            foreach( var _file in _documents )
            {
                var _item = new ListBoxItem
                {
                    Tag = _file,
                    Content = Path.GetFileNameWithoutExtension( _file )
                };

                DocumentListBox.Items?.Add( _item );
            }
        }

        /// <summary>
        /// Populates the c plus documents.
        /// </summary>
        private void PopulateCPlusDocuments( )
        {
            try
            {
                var _path = Locations.PathPrefix + @"Resources\Documents\Editor\CPP\";
                TabControl.SelectedIndex = 0;
                ChatEditor.DocumentLanguage = Languages.C;
                ChatEditor.DocumentSource = _path;
                DocumentListBox.Items?.Clear( );
                var _documents = Directory.GetFiles( _path );
                foreach( var _file in _documents )
                {
                    var _item = new ListBoxItem
                    {
                        Tag = _file,
                        Content = Path.GetFileNameWithoutExtension( _file )
                    };

                    DocumentListBox.Items?.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the java script documents.
        /// </summary>
        private void PopulateJavaScriptDocuments( )
        {
            try
            {
                var _path = Locations.PathPrefix + @"Resources\Documents\Editor\JS\";
                TabControl.SelectedIndex = 0;
                ChatEditor.DocumentLanguage = Languages.JScript;
                DocumentListBox.Items?.Clear( );
                var _documents = Directory.GetFiles( _path );
                foreach( var _file in _documents )
                {
                    var _item = new ListBoxItem
                    {
                        Tag = _file,
                        Content = Path.GetFileNameWithoutExtension( _file )
                    };

                    DocumentListBox.Items?.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the SQL documents.
        /// </summary>
        private void PopulateSqlDocuments( )
        {
            try
            {
                var _path = @"C:\Users\terry\source\repos\Badger\Resources\Documents\Editor\SQL\";
                TabControl.SelectedIndex = 0;
                ChatEditor.DocumentLanguage = Languages.SQL;
                DocumentListBox.Items?.Clear( );
                var _documents = Directory.GetFiles( _path );
                foreach( var _file in _documents )
                {
                    var _item = new ListBoxItem
                    {
                        Tag = _file,
                        Content = Path.GetFileNameWithoutExtension( _file )
                    };

                    DocumentListBox.Items?.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the python documents.
        /// </summary>
        private void PopulatePythonDocuments( )
        {
            try
            {
                var _path = Locations.PathPrefix + @"Resources\Documents\Editor\PY\";
                TabControl.SelectedIndex = 0;
                ChatEditor.DocumentLanguage = Languages.Text;
                DocumentListBox.Items?.Clear( );
                var _documents = Directory.GetFiles( _path );
                foreach( var _file in _documents )
                {
                    var _item = new ListBoxItem
                    {
                        Tag = _file,
                        Content = Path.GetFileNameWithoutExtension( _file )
                    };

                    DocumentListBox.Items?.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the c sharp documents.
        /// </summary>
        private void PopulateCSharpDocuments( )
        {
            try
            {
                var _path = Locations.PathPrefix + @"Resources\Documents\Editor\CS\";
                TabControl.SelectedIndex = 0;
                ChatEditor.DocumentLanguage = Languages.CSharp;
                DocumentListBox.Items?.Clear( );
                var _documents = Directory.GetFiles( _path );
                foreach( var _file in _documents )
                {
                    var _item = new ListBoxItem
                    {
                        Tag = _file,
                        Content = Path.GetFileNameWithoutExtension( _file )
                    };

                    DocumentListBox.Items?.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the text documents.
        /// </summary>
        private void PopulateTextDocuments( )
        {
            try
            {
                var _path = Locations.PathPrefix + @"Resources\Documents\Appropriations\";
                TabControl.SelectedIndex = 0;
                ChatEditor.DocumentLanguage = Languages.Text;
                DocumentListBox.Items?.Clear( );
                var _documents = Directory.GetFiles( _path );
                foreach( var _file in _documents )
                {
                    var _item = new ListBoxItem
                    {
                        Tag = _file,
                        Content = Path.GetFileNameWithoutExtension( _file )
                    };

                    DocumentListBox.Items?.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the voices.
        /// </summary>
        private void PopulateInstalledVoices( )
        {
            try
            {
                var _synth = new SpeechSynthesizer( );
                VoiceListBox.Items?.Clear( );
                _voices.Clear(  );
                foreach( var _voice in _synth.GetInstalledVoices( ) )
                {
                    var _info = _voice.VoiceInfo;
                    var _start = "Microsoft".ToCharArray(  );
                    var _end = "Desktop".ToCharArray( );
                    var _first = _info.Name.TrimStart( _start );
                    var _last = _first.TrimEnd( _end );
                    var _lower = _last.ToLower(  );
                    _voices.Add( _info.Name, _lower );
                    var _item = new ListBoxItem
                    {
                        Tag = _info.Name,
                        Content = _lower
                    };

                    VoiceListBox.Items.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the open ai voices.
        /// </summary>
        private void PopulateOpenAiVoices( )
        {
            try
            {
                var _aiVoices = new Dictionary<string, string>( );
                _aiVoices.Add( "alloy", "alloy" );
                _aiVoices.Add( "ash", "ash" );
                _aiVoices.Add( "coral", "coral" );
                _aiVoices.Add( "echo", "echo" );
                _aiVoices.Add( "onyx", "onyx" );
                _aiVoices.Add( "fable", "fable" );
                _aiVoices.Add( "nova", "nova" );
                _aiVoices.Add( "sage", "sage" );
                _aiVoices.Add( "shimmer", "shimer" );
                VoiceListBox.Items.Clear(  );
                foreach( var _voice in _aiVoices )
                {
                    var _item = new ListBoxItem
                    {
                        Tag = _voice.Key,
                        Content = _voice.Value
                    };

                    VoiceListBox.Items.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the voices.
        /// </summary>
        private void PopulateVoices( )
        {
            try
            {
                PopulateInstalledVoices(  );
                var _aiVoices = new Dictionary<string, string>( );
                _aiVoices.Add( "alloy", "alloy" );
                _aiVoices.Add( "ash", "ash" );
                _aiVoices.Add( "coral", "coral" );
                _aiVoices.Add( "echo", "echo" );
                _aiVoices.Add( "onyx", "onyx" );
                _aiVoices.Add( "fable", "fable" );
                _aiVoices.Add( "nova", "nova" );
                _aiVoices.Add( "sage", "sage" );
                _aiVoices.Add( "shimmer", "shimer" );
                foreach( var _voice in _aiVoices )
                {
                    var _item = new MetroDropDownItem
                    {
                        Tag = _voice.Key,
                        Content = _voice.Value
                    };

                    VoiceListBox.Items.Add( _item );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the request types.
        /// </summary>
        private void PopulateRequestTypes( )
        {
            try
            {
                GenerationListBox.Items?.Clear( );
                var _names = Enum.GetNames( typeof( GptRequests ) );
                foreach( var _request in _names )
                {
                    var _item = new ListBoxItem
                    {
                        Height = 22,
                        Tag = _request,
                        Content = _request.SplitPascal( )
                    };

                    GenerationListBox.Items.Add( _item );
                }

                GenerationListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Populates the language ListBox.
        /// </summary>
        private void PopulateLanguageListBox( )
        {
            try
            {
                LanguageListBox.Items?.Clear( );
                var _names = Enum.GetNames( typeof( GptLanguages ) );
                foreach( var _request in _names )
                {
                    LanguageListBox.Items.Add( _request );
                }

                LanguageListBox.SelectedIndex = -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the user document language.
        /// </summary>
        private protected void PopulateDocuments( )
        {
            try
            {
                var _prefix = @"C:\Users\terry\source\repos\Badger\Resources\Documents\Editor\";
                if( !string.IsNullOrEmpty( _language ) )
                {
                    ChatEditor.Text = "";
                    switch( _language )
                    {
                        case "TXT":
                        {
                            var _pre = @"C:\Users\terry\source\repos\Badger\Resources\Document\";
                            var _path = _pre + @"Appropriations\";
                            TabControl.SelectedIndex = 0;
                            ChatEditor.DocumentLanguage = Languages.Text;
                            DocumentListBox.Items?.Clear( );
                            var _documents = Directory.GetFiles( _path );
                            foreach( var _file in _documents )
                            {
                                var _item = new ListBoxItem
                                {
                                    Tag = _file,
                                    Content = Path.GetFileNameWithoutExtension( _file )
                                };

                                DocumentListBox.Items?.Add( _item );
                            }

                            break;
                        }
                        case "CS":
                        {
                            var _path = _prefix + @"CS\";
                            TabControl.SelectedIndex = 0;
                            ChatEditor.DocumentLanguage = Languages.CSharp;
                            DocumentListBox.Items?.Clear( );
                            var _documents = Directory.GetFiles( _path );
                            foreach( var _file in _documents )
                            {
                                var _item = new ListBoxItem
                                {
                                    Tag = _file,
                                    Content = Path.GetFileNameWithoutExtension( _file )
                                };

                                DocumentListBox.Items?.Add( _item );
                            }

                            break;
                        }
                        case "PY":
                        {
                            var _path = _prefix + @"PY\";
                            TabControl.SelectedIndex = 0;
                            ChatEditor.DocumentLanguage = Languages.Text;
                            DocumentListBox.Items?.Clear( );
                            var _documents = Directory.GetFiles( _path );
                            foreach( var _file in _documents )
                            {
                                var _item = new ListBoxItem
                                {
                                    Tag = _file,
                                    Content = Path.GetFileNameWithoutExtension( _file )
                                };

                                DocumentListBox.Items?.Add( _item );
                            }

                            break;
                        }
                        case "SQL":
                        {
                            var _path = _prefix + @"SQL\";
                            TabControl.SelectedIndex = 0;
                            ChatEditor.DocumentLanguage = Languages.SQL;
                            DocumentListBox.Items?.Clear( );
                            var _documents = Directory.GetFiles( _path );
                            foreach( var _file in _documents )
                            {
                                var _item = new ListBoxItem
                                {
                                    Tag = _file,
                                    Content = Path.GetFileNameWithoutExtension( _file )
                                };

                                DocumentListBox.Items?.Add( _item );
                            }

                            break;
                        }
                        case "JS":
                        {
                            var _path = _prefix + @"JS\";
                            TabControl.SelectedIndex = 0;
                            ChatEditor.DocumentLanguage = Languages.JScript;
                            DocumentListBox.Items?.Clear( );
                            var _documents = Directory.GetFiles( _path );
                            foreach( var _file in _documents )
                            {
                                var _item = new ListBoxItem
                                {
                                    Tag = _file,
                                    Content = Path.GetFileNameWithoutExtension( _file )
                                };

                                DocumentListBox.Items?.Add( _item );
                            }

                            break;
                        }
                        case "CPP":
                        {
                            var _path = _prefix + @"CPP\";
                            TabControl.SelectedIndex = 0;
                            ChatEditor.DocumentLanguage = Languages.C;
                            ChatEditor.DocumentSource = _path;
                            DocumentListBox.Items?.Clear( );
                            var _documents = Directory.GetFiles( _path );
                            foreach( var _file in _documents )
                            {
                                var _item = new ListBoxItem
                                {
                                    Tag = _file,
                                    Content = Path.GetFileNameWithoutExtension( _file )
                                };

                                DocumentListBox.Items?.Add( _item );
                            }

                            break;
                        }
                        case "VBA":
                        {
                            var _path = _prefix + @"VBA\";
                            TabControl.SelectedIndex = 0;
                            ChatEditor.DocumentLanguage = Languages.VisualBasic;
                            DocumentListBox.Items?.Clear( );
                            var _documents = Directory.GetFiles( _path );
                            foreach( var _file in _documents )
                            {
                                var _item = new ListBoxItem
                                {
                                    Tag = _file,
                                    Content = Path.GetFileNameWithoutExtension( _file )
                                };

                                DocumentListBox.Items?.Add( _item );
                            }

                            break;
                        }
                        default:
                        {
                            var _pre = @"C:\Users\terry\source\repos\Badger\Resources\Document\";
                            var _path = _pre + @"Appropriations\";
                            TabControl.SelectedIndex = 0;
                            ChatEditor.DocumentLanguage = Languages.Text;
                            DocumentListBox.Items?.Clear( );
                            var _documents = Directory.GetFiles( _path );
                            foreach( var _file in _documents )
                            {
                                var _item = new ListBoxItem
                                {
                                    Tag = _file,
                                    Content = Path.GetFileNameWithoutExtension( _file )
                                };

                                DocumentListBox.Items?.Add( _item );
                            }

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
                InvokeIf( _statusUpdate );
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
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void SendMessage( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _splashMessage = new SplashMessage( message )
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                _splashMessage.Show( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sends the notification.
        /// </summary>
        private void SendNotification( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _notify = CreateNotifier( );
                _notify.ShowInformation( message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sends the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void SendErrorMessage( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _notify = CreateNotifier( );
                _notify.ShowError( message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the end point.
        /// </summary>
        private void SetRequestType( )
        {
            try
            {
                switch( _requestType )
                {
                    case GptRequests.Assistants:
                    {
                        PopulateCompletionModels( );
                        _endpoint = GptEndPoint.Assistants;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.ChatCompletion:
                    {
                        PopulateCompletionModels( );
                        _endpoint = GptEndPoint.Completions;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.TextGeneration:
                    {
                        PopulateTextModels( );
                        _endpoint = GptEndPoint.TextGeneration;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.ImageGeneration:
                    {
                        PopulateImageModels( );
                        _endpoint = GptEndPoint.ImageGeneration;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.Translations:
                    {
                        PopulateTranslationModels( );
                        PopulateOpenAiVoices( );
                        _endpoint = GptEndPoint.Translations;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.Embeddings:
                    {
                        PopulateEmbeddingModels( );
                        _endpoint = GptEndPoint.Embeddings;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.Transcriptions:
                    {
                        PopulateTranscriptionModels( );
                        PopulateOpenAiVoices( );
                        _endpoint = GptEndPoint.Transcriptions;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.VectorStores:
                    {
                        PopulateVectorStoreModels( );
                        _endpoint = GptEndPoint.VectorStores;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.SpeechGeneration:
                    {
                        PopulateSpeechModels( );
                        PopulateOpenAiVoices( );
                        _endpoint = GptEndPoint.SpeechGeneration;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.FineTuning:
                    {
                        PopulateFineTuningModels( );
                        _endpoint = GptEndPoint.FineTuning;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.Files:
                    {
                        PopulateFileApiModels( );
                        _endpoint = GptEndPoint.Files;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.Uploads:
                    {
                        PopulateUploadApiModels( );
                        _endpoint = GptEndPoint.Uploads;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    case GptRequests.Projects:
                    {
                        PopulateTextModels( );
                        _endpoint = GptEndPoint.Projects;
                        TabControl.SelectedIndex = 1;
                        break;
                    }
                    default:
                    {
                        PopulateModelsAsync( );
                        _endpoint = GptEndPoint.Completions;
                        TabControl.SelectedIndex = 1;
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
        /// Sets the user mode.
        /// </summary>
        private protected void SetTabControl( )
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
        /// Sets the hyper parameters.
        /// </summary>
        private protected void SetGptParameters( )
        {
            try
            {
                _store = StoreCheckBox.IsChecked ?? false;
                _stream = StreamCheckBox.IsChecked ?? true;
                _presence = double.Parse( PresenceSlider.Value.ToString( "N2" ) );
                _temperature = double.Parse( TemperatureSlider.Value.ToString( "N2" ) );
                _topPercent = double.Parse( TopPercentSlider.Value.ToString( "N2" ) );
                _frequency = double.Parse( FrequencySlider.Value.ToString( "N2" ) );
                _number = int.Parse( NumberTextBox.Text );
                _maximumTokens = Convert.ToInt32( MaxTokenTextBox.Text );
                _model = ModelListBox.SelectedItem.ToString( ) ?? "gpt-4o";
                _userPrompt = _language == "Text"
                    ? ChatEditor.Text
                    : "";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the GPT options.
        /// </summary>
        private protected void SetGptOptions( )
        {
            try
            {
                _options = _requestType switch
                {
                    GptRequests.ChatCompletion => new ChatOptions( ),
                    GptRequests.Assistants => new AssistantOptions(  ),
                    GptRequests.TextGeneration => new TextOptions(  ),
                    GptRequests.ImageGeneration => new ImageOptions(  ),
                    GptRequests.Transcriptions => new TranscriptionOptions(  ),
                    GptRequests.Files => new FileOptions( ),
                    GptRequests.Embeddings => new EmbeddingOptions(  ),
                    GptRequests.FineTuning => new FineTuningOptions(  ),
                    GptRequests.VectorStores => new VectorOptions( ),
                    GptRequests.Translations => new TranslationOptions( ),
                    GptRequests.SpeechGeneration => new SpeechOptions( ),
                    var _ => new TextOptions( )
                };
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
                _currentBrowser.LoadUrl( _finalUrl );
                CloseSearch( );
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
        /// Speeches to text.
        /// </summary>
        /// <param name="input">The input.</param>
        public void TextToSpeech( string input )
        {
            try
            {
                ThrowIf.Null( input, nameof( input ) );
                if( MuteCheckBox.IsChecked == true )
                {
                    return;
                }

                if( _synthesizer == null )
                {
                    _synthesizer = new SpeechSynthesizer( );
                    _synthesizer.SetOutputToDefaultAudioDevice( );
                }

                if( VoiceListBox.SelectedItem.ToString( ) != "" )
                {
                    _synthesizer.SelectVoice( VoiceListBox.SelectedItem.ToString( ) );
                }

                _synthesizer.Speak( input );
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.
        /// </param>
        private protected void OnLoad( object sender, RoutedEventArgs e )
        {
            InitializePlotter( );
            InitializeHotkeys( );
            InitializeChatEditor(  );
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged( [ CallerMemberName ] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }

        /// <summary>
        /// Called when [tab closed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnTabClosed( object sender, RoutedEventArgs e )
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
        /// Called when [tab changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnTabChanged( object sender, RoutedEventArgs e )
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
        /// Called when [status updated].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="StatusMessageEventArgs"/>
        /// instance containing the event data.</param>
        private void OnStatusUpdated( object sender, StatusMessageEventArgs e )
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
        /// Called when [source button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnSourceButtonClick( object sender, EventArgs e )
        {
            try
            {
                var _message = "NOT YET IMPLEMENTED!";
                var _notifier = CreateNotifier( );
                _notifier.ShowInformation( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [store box checked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnStoreCheckBoxChecked( object sender, EventArgs e )
        {
            try
            {
                _store = StoreCheckBox.IsChecked == true;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [stream box checked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnStreamCheckBoxChecked( object sender, EventArgs e )
        {
            try
            {
                _stream = StreamCheckBox.IsChecked == true;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [URL text box click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/>
        /// instance containing the event data.</param>
        private protected void OnMouseMove( object sender, MouseEventArgs e )
        {
            try
            {
                var _psn = e.GetPosition( this );
                var _searchDialog = new SearchDialog
                {
                    Owner = this,
                    Left = _psn.X - 100,
                    Top = _psn.Y + 50
                };
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
        /// <param name="e">The <see cref="MouseEventArgs"/>
        /// instance containing the event data.</param>
        private protected void OnToolStripTextBoxTextChanged(
            object sender, TextChangedEventArgs e )
        {
            try
            {
                var _textBox = sender as ToolStripTextBox;
                var _text = _textBox?.Text;
                if( !string.IsNullOrEmpty( _text ) )
                {
                    ChatEditor.Text = _text;
                    ChatTextBox.Text = _text;
                }
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
        /// <param name="e">The <see cref="CancelEventArgs"/>
        /// instance containing the event data.</param>
        private void OnClosing( object sender, CancelEventArgs e )
        {
            try
            {
                _timer?.Dispose( );
                _statusUpdate += null;
                SfSkinManager.Dispose( this );
                App.ActiveWindows.Clear( );
                Environment.Exit( 0 );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [close button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnCloseButtonClick( object sender, RoutedEventArgs e )
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
        /// Called when [calculator menu option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnCalculatorMenuOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Busy( );
                var _calculator = new CalculatorWindow
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    Owner = this,
                    Topmost = true
                };

                Chill( );
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnFileMenuOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                OpenGptFileDialog( );
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// Called when [file upload button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnFileApiButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                OpenGptFileDialog( );
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnCloseOptionClick( object sender, RoutedEventArgs e )
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
        /// Called when [chrome option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnChromeOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Busy( );
                WebMinion.RunChrome( );
                Chill( );
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnEdgeOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Busy( );
                WebMinion.RunEdge( );
                Chill( );
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnFirefoxOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Busy( );
                WebMinion.RunFirefox( );
                Chill( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [system prompt button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnPromptOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Busy( );
                OpenSystemDialog( );
                Chill( );
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        private void OnRefreshButtonClick( object sender, EventArgs e )
        {
            try
            {
                ClearChatControls( );
                ClearParameters( );
                ClearLabels( );
                PopulateModelsAsync( );
                PopulateInstalledVoices( );
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// Called when [delete button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// Called when [save button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
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
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnToggleButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                SetToolbarVisibility( !ToolStripTextBox.IsVisible );
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
                var _message = "NOT YET IMPLEMENTED!";
                SendMessage( _message );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [tool strip refresh button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnToolStripRefreshButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ClearChatControls( );
                ClearParameters( );
                ClearLabels( );
                PopulateModelsAsync( );
                PopulateInstalledVoices( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [listen checked changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnListenCheckedChanged( object sender, RoutedEventArgs e )
        {
            if( ListenCheckBox.IsChecked == true )
            {
                InitializeSpeechEngine( );
            }
            else
            {
                _engine.RecognizeAsyncStop( );
            }
        }

        /// <summary>
        /// Called when [mute checked box changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnMuteCheckedBoxChanged( object sender, RoutedEventArgs e )
        {
            if( MuteCheckBox.IsChecked == true )
            {
                VoiceLabel.Visibility = Visibility.Visible;
                VoiceListBox.Visibility = Visibility.Visible;
                var _msg = "The GPT Audio Client has been activated!";
                SendNotification( _msg );
            }
            else
            {
                VoiceLabel.Visibility = Visibility.Hidden;
                VoiceListBox.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [speech recognized].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SpeechRecognizedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnSpeechRecognized( object sender, SpeechRecognizedEventArgs e )
        {
            // Reset Hypothesized text
            if( ChatEditor.Text != "" )
            {
                ChatEditor.Text += "\n";
            }

            var _text = e.Result.Text;
            ChatEditor.Text += _text;
        }

        /// <summary>
        /// Called when [speech hypothesized].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SpeechHypothesizedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnSpeechHypothesized( object sender, SpeechHypothesizedEventArgs e )
        {
            var _text = e.Result.Text;
        }

        /// <summary>
        /// Called when [send button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnSendButtonClick( object sender, RoutedEventArgs e )
        {
            {
                var _userInput = ChatEditor.Text;
                if( string.IsNullOrEmpty( _userInput ) )
                {
                    MessageBox.Show( "Type in your question!" );
                    ChatEditor.Focus( );
                    return;
                }

                if( ChatEditor.Text != "" )
                {
                    ChatEditor.AppendText( "\r\n" );
                }

                ChatEditor.AppendText( "User: " + _userInput + "\r\n" );
                ChatEditor.Text = "";
                try
                {
                    var _answer = SendHttpMessage( _userInput ) + "";
                    ChatEditor.AppendText( "Badger: " + _answer.Replace( "\n", "\r\n" ).Trim( ) );
                    TextToSpeech( _answer );
                }
                catch( Exception ex )
                {
                    ChatEditor.AppendText( "Error: " + ex.Message );
                }
            }
        }

        /// <summary>
        /// Called when [clear button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnClearButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                ClearChatControls( );
                ClearParameters( );
                ClearLabels( );
                PopulateModelsAsync( );
                PopulateInstalledVoices( );
                PopulateImageSizes( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [model ComboBox selection changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnModelListBoxSelectionChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( ModelListBox.SelectedIndex != -1 )
                {
                    _model = ModelListBox.SelectedValue.ToString( );
                    PopulateImageSizes( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [selected document changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnDocumentListBoxSelectionChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( DocumentListBox.SelectedIndex != -1 )
                {
                    ChatEditor.ClearAllText( );
                    _selectedDocument =
                        ( ( ListBoxItem )DocumentListBox.SelectedItem )?.Tag?.ToString( );

                    ChatEditor.LoadFile( _selectedDocument );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [document selection changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnLanguageListBoxSelectionChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( LanguageListBox.SelectedIndex != -1 )
                {
                    _language = LanguageListBox.SelectedItem.ToString( );
                    PopulateDocuments( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [task selection changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnRequestListBoxSelectionChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( GenerationListBox.SelectedIndex != -1 )
                {
                    var _item = ( ListBoxItem )GenerationListBox.SelectedItem;
                    _selectedRequest = _item.Tag?.ToString( );
                    _requestType =
                        ( GptRequests )Enum.Parse( typeof( GptRequests ), _selectedRequest );

                    SetRequestType( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [text box input changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private protected void OnParameterTextBoxChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( sender is MetroTextBox _textBox )
                {
                    var _tag = _textBox?.Tag.ToString( );
                    if( !string.IsNullOrEmpty( _tag ) )
                    {
                        switch( _tag )
                        {
                            case "FrequencyPenalty":
                            case "PresencePenalty":
                            case "Temperature":
                            {
                                var _temp = _textBox.Text;
                                var _value = double.Parse( _temp );
                                _textBox.Text = _value.ToString( "N2" );
                                break;
                            }
                            case "TopPercent":
                            {
                                var _temp = _textBox.Text;
                                var _top = double.TryParse( _temp, out var _value );
                                if( _top )
                                {
                                    _textBox.Text = _value.ToString( "P2" );
                                }

                                break;
                            }
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
        /// Called when [selected image size changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnImageSizeListBoxSelectionChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( ImageSizeDropDown.SelectedIndex != -1 )
                {
                    var _image = ImageSizeDropDown.SelectedValue.ToString( );
                    _size = _image?.Replace( " ", "" );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [go button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnGoButtonClicked( object sender, RoutedEventArgs e )
        {
            try
            {
                var _item = "";
                _keyWords = ToolStripTextBox.InputText;
                if( !string.IsNullOrEmpty( _keyWords ) )
                {
                    var _message = "The search keywords are empty!";
                    SendMessage( _message );
                }
                else
                {
                    Busy( );
                    var _googleSearch = new GoogleSearch( _keyWords );
                    var _results = _googleSearch.GetResults( );
                    foreach( var _result in _results )
                    {
                        _item += _result;
                    }

                    ChatEditor.Text = _item;
                    Chill( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [guidance option click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnGuidanceOptionClick( object sender, RoutedEventArgs e )
        {
            try
            {
                Busy( );
                Chill( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c>
        /// to release both managed and unmanaged resources;
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
        /// 
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            using var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}