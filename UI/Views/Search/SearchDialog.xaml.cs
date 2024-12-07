// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="SearchDialog.xaml.cs" company="Terry D. Eppler">
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
//   SearchDialog.xaml.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System.Configuration;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using Syncfusion.SfSkinManager;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for SearchDialog.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    public partial class SearchDialog : Window, IDisposable
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
        /// The status update
        /// </summary>
        private protected Action _statusUpdate;

        /// <summary>
        /// The theme
        /// </summary>
        private protected readonly DarkMode _theme = new DarkMode( );

        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// The domain
        /// </summary>
        private string _queryPrefix;

        /// <summary>
        /// The results
        /// </summary>
        private string _results;

        /// <summary>
        /// The input
        /// </summary>
        private string _keywordInput;

        /// <summary>
        /// The keyword prefix
        /// </summary>
        private string _keywordLabelPrefix;

        /// <summary>
        /// The domain prefix
        /// </summary>
        private string _domainLabelPrefix;

        /// <summary>
        /// The stop watch
        /// </summary>
        private Stopwatch _stopWatch = new Stopwatch( );

        /// <summary>
        /// The selected domains
        /// </summary>
        private protected IList<string> _selectedDomains;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SearchDialog" /> class.
        /// </summary>
        public SearchDialog( )
        {
            // Theme Properties
            SfSkinManager.SetTheme( this, new Theme( "FluentDark", App.Controls ) );

            // Window Initialization
            InitializeComponent( );
            RegisterCallbacks( );

            // Form Properterties
            _keywordInput = string.Empty;
            _results = string.Empty;
            _domainLabelPrefix = "Domain:";
            _keywordLabelPrefix = "Key Words:";
            _queryPrefix = ConfigurationManager.AppSettings[ "GOOG" ];

            //Event Wiring
            Loaded += OnLoad;
        }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public string Results
        {
            get
            {
                return _results;
            }
            private protected set
            {
                _results = value;
            }
        }

        /// <summary>
        /// Gets the selected domains.
        /// </summary>
        /// <value>
        /// The selected domains.
        /// </value>
        public IList<string> SelectedDomains
        {
            get
            {
                return _selectedDomains;
            }
            private protected set
            {
                _selectedDomains = value;
            }
        }

        /// <summary>
        /// Registers the callbacks.
        /// </summary>
        private void RegisterCallbacks( )
        {
            try
            {
                SearchPanelLookupButton.Click += OnLookupButtonClick;
                SearchPanelCancelButton.Click += OnCloseButtonClick;
                SearchPanelRefreshButton.Click += OnClearButtonClick;
                SearchPanelTextBox.TextChanged += OnInputTextChanged;
                SearchPanelComboBox.SelectionChanged += OnSelectedDomainChanged;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the buttons.
        /// </summary>
        private void InitializeTextBox( )
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
        /// Initializes the labels.
        /// </summary>
        private void InitializeLabels( )
        {
            try
            {
                SearchPanelDomainLabel.Content = _domainLabelPrefix + " " + "Google";
                SearchPanelQueryLabel.Content = _keywordLabelPrefix + " " + "0";
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Initializes the buttons.
        /// </summary>
        private void InitializeButtons( )
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
        /// Initializes the ComboBox.
        /// </summary>
        private void InitializeComboBox( )
        {
            try
            {
                //ComboBox.ForeColor = Color.White;
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
        /// Sets the tool strip properties.
        /// </summary>
        private void PopulateDomainDropDowns( )
        {
            try
            {
                SearchPanelComboBox.Items?.Clear( );
                var _domains = Enum.GetNames( typeof( Domains ) );
                for( var _i = 0; _i < _domains.Length; _i++ )
                {
                    var _domain = _domains[ _i ];
                    if( !string.IsNullOrEmpty( _domain ) )
                    {
                        SearchPanelComboBox.Items.Add( _domain );
                    }
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
        private void ClearCallbacks( )
        {
            try
            {
                SearchPanelLookupButton.Click -= OnLookupButtonClick;
                SearchPanelCancelButton.Click -= OnCloseButtonClick;
                SearchPanelRefreshButton.Click -= OnClearButtonClick;
                SearchPanelTextBox.TextChanged -= OnInputTextChanged;
                SearchPanelComboBox.SelectionChanged -= OnSelectedDomainChanged;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// instance containing the event data.
        /// </param>
        private void OnLoad( object sender, RoutedEventArgs e )
        {
            try
            {
                InitializeTextBox( );
                InitializeButtons( );
                InitializeComboBox( );
                InitializeLabels( );
                PopulateDomainDropDowns( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [close button clicked].
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public virtual void OnCloseButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                SfSkinManager.Dispose( this );
                _results = string.Empty;
                _queryPrefix = string.Empty;
                _domainLabelPrefix = string.Empty;
                ClearCallbacks( );
                Close( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [okay button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        public virtual void OnLookupButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                if( !string.IsNullOrEmpty( _keywordInput )
                    && !string.IsNullOrEmpty( _queryPrefix ) )
                {
                    _results = _queryPrefix + _keywordInput;
                    Close( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [clear button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        public virtual void OnClearButtonClick( object sender, RoutedEventArgs e )
        {
            try
            {
                _keywordInput = string.Empty;
                _results = string.Empty;
                _queryPrefix = ConfigurationManager.AppSettings[ "Google" ];
                SearchPanelDomainLabel.Content = _domainLabelPrefix;
                SearchPanelQueryLabel.Content = _keywordLabelPrefix;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [input text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        public void OnInputTextChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                _keywordInput = SearchPanelTextBox.Name;
                if( _keywordInput.Contains( " " ) )
                {
                    var _split = _keywordInput.Split( " " );
                    SearchPanelQueryLabel.Content = _keywordLabelPrefix + " " + _split.Length;
                    _results = _queryPrefix + _keywordInput;
                }
                else
                {
                    SearchPanelQueryLabel.Content = _keywordLabelPrefix + " " + 0;
                    _results = _queryPrefix + _keywordInput;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [search engine selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnSelectedDomainChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( sender is MetroComboBox _comboBox )
                {
                }
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