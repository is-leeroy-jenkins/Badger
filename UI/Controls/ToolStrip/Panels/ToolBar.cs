// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 05-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-28-2024
// ******************************************************************************************
// <copyright file="ToolBar.cs" company="Terry D. Eppler">
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
//   ToolBar.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Media;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Badger.BasicBar" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public class ToolBar : BasicBar
    {
        /// <summary>
        /// The first separator
        /// </summary>
        private protected MenuItemSeparator _firstSeparator;

        /// <summary>
        /// The status label
        /// </summary>
        private protected StatusLabel _label;

        /// <summary>
        /// The second separator
        /// </summary>
        private protected MenuItemSeparator _secondSeparator;

        /// <summary>
        /// The first button
        /// </summary>
        private protected FirstButton _firstButton;

        /// <summary>
        /// The previous button
        /// </summary>
        private protected PreviousButton _previousButton;

        /// <summary>
        /// The next button
        /// </summary>
        private protected NextButton _nextButton;

        /// <summary>
        /// The last button
        /// </summary>
        private protected LastButton _lastButton;

        /// <summary>
        /// The third separator
        /// </summary>
        private protected MenuItemSeparator _thirdSeparator;

        /// <summary>
        /// The text box
        /// </summary>
        private protected ToolStripTextBox _textBox;

        /// <summary>
        /// The fouth separator
        /// </summary>
        private protected MenuItemSeparator _fouthSeparator;

        /// <summary>
        /// The lookup button
        /// </summary>
        private protected LookupButton _lookupButton;

        /// <summary>
        /// The refresh button
        /// </summary>
        private protected RefreshButton _refreshButton;

        /// <summary>
        /// The edit button
        /// </summary>
        private protected EditButton _editButton;

        /// <summary>
        /// The delete button
        /// </summary>
        private protected DeleteButton _deleteButton;

        /// <summary>
        /// The save button
        /// </summary>
        private protected SaveButton _saveButton;

        /// <summary>
        /// The export button
        /// </summary>
        private protected ExportButton _exportButton;

        /// <summary>
        /// The excel button
        /// </summary>
        private protected ExitButton _exitButton;

        /// <summary>
        /// The browse button
        /// </summary>
        private protected BrowseButton _browseButton;

        /// <summary>
        /// The menu button
        /// </summary>
        private protected MenuButton _menuButton;

        /// <summary>
        /// The buttons
        /// </summary>
        private protected IList<object> _items;

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public StatusLabel Label
        {
            get
            {
                return _label;
            }
            private protected set
            {
                _label = value;
            }
        }

        /// <summary>
        /// Gets the first button.
        /// </summary>
        /// <value>
        /// The first button.
        /// </value>
        public FirstButton FirstButton
        {
            get
            {
                return _firstButton;
            }
            private protected set
            {
                _firstButton = value;
            }
        }

        /// <summary>
        /// Gets the next button.
        /// </summary>
        /// <value>
        /// The next button.
        /// </value>
        public PreviousButton PreviousButton
        {
            get
            {
                return _previousButton;
            }
            private protected set
            {
                _previousButton = value;
            }
        }

        /// <summary>
        /// Gets the next button.
        /// </summary>
        /// <value>
        /// The next button.
        /// </value>
        public NextButton NextButton
        {
            get
            {
                return _nextButton;
            }
            private protected set
            {
                _nextButton = value;
            }
        }

        /// <summary>
        /// Gets the last button.
        /// </summary>
        /// <value>
        /// The last button.
        /// </value>
        public LastButton LastButton
        {
            get
            {
                return _lastButton;
            }
            private protected set
            {
                _lastButton = value;
            }
        }

        /// <summary>
        /// Gets the lookup button.
        /// </summary>
        /// <value>
        /// The lookup button.
        /// </value>
        public LookupButton LookupButton
        {
            get
            {
                return _lookupButton;
            }
            private protected set
            {
                _lookupButton = value;
            }
        }

        /// <summary>
        /// Gets the refresh button.
        /// </summary>
        /// <value>
        /// The refresh button.
        /// </value>
        public RefreshButton RefreshButton
        {
            get
            {
                return _refreshButton;
            }
            private protected set
            {
                _refreshButton = value;
            }
        }

        /// <summary>
        /// Gets the delete button.
        /// </summary>
        /// <value>
        /// The delete button.
        /// </value>
        public DeleteButton DeleteButton
        {
            get
            {
                return _deleteButton;
            }
            private protected set
            {
                _deleteButton = value;
            }
        }

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        public SaveButton SaveButton
        {
            get
            {
                return _saveButton;
            }
            private protected set
            {
                _saveButton = value;
            }
        }

        /// <summary>
        /// Gets the browse button.
        /// </summary>
        /// <value>
        /// The browse button.
        /// </value>
        public BrowseButton BrowseButton
        {
            get
            {
                return _browseButton;
            }
            private protected set
            {
                _browseButton = value;
            }
        }

        /// <summary>
        /// Gets the edit button.
        /// </summary>
        /// <value>
        /// The edit button.
        /// </value>
        public EditButton EditButton
        {
            get
            {
                return _editButton;
            }
            private protected set
            {
                _editButton = value;
            }
        }

        /// <summary>
        /// Gets the export button.
        /// </summary>
        /// <value>
        /// The export button.
        /// </value>
        public ExportButton ExportButton
        {
            get
            {
                return _exportButton;
            }
            private protected set
            {
                _exportButton = value;
            }
        }

        public MenuButton MenuButton
        {
            get
            {
                return _menuButton;
            }
            private protected set
            {
                _menuButton = value;
            }
        }

        /// <summary>
        /// Gets the exit button.
        /// </summary>
        /// <value>
        /// The exit button.
        /// </value>
        public ExitButton ExitButton
        {
            get
            {
                return _exitButton;
            }
            private protected set
            {
                _exitButton = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ToolBar"/> class.
        /// </summary>
        /// <inheritdoc />
        public ToolBar( )
            : base( )
        {
            // Basic Properties
            Height = 40;
            Width = 1330;
            Background = new SolidColorBrush( _backColor );
            Foreground = new SolidColorBrush( _foreColor );
            BorderBrush = new SolidColorBrush( _borderColor );

            // Create Items
            Items.Clear( );
            _firstSeparator = new MenuItemSeparator( );
            Items.Add( _firstSeparator );
            _label = new StatusLabel( );
            Items.Add( _label );
            _secondSeparator = new MenuItemSeparator( );
            Items.Add( _secondSeparator );
            _firstButton = new FirstButton( );
            Items.Add( _firstButton );
            _previousButton = new PreviousButton( );
            Items.Add( _previousButton );
            _nextButton = new NextButton( );
            Items.Add( _nextButton );
            _lastButton = new LastButton( );
            Items.Add( _lastButton );
            _thirdSeparator = new MenuItemSeparator( );
            Items.Add( _thirdSeparator );
            _textBox = new ToolStripTextBox( );
            Items.Add( _textBox );
            _fouthSeparator = new MenuItemSeparator( );
            Items.Add( _fouthSeparator );
            _lookupButton = new LookupButton( );
            Items.Add( _lookupButton );
            _refreshButton = new RefreshButton( );
            Items.Add( _refreshButton );
            _editButton = new EditButton( );
            Items.Add( _editButton );
            _deleteButton = new DeleteButton( );
            Items.Add( _deleteButton );
            _saveButton = new SaveButton( );
            Items.Add( _saveButton );
            _exportButton = new ExportButton( );
            Items.Add( _exportButton );
            _browseButton = new BrowseButton( );
            Items.Add( _browseButton );
            _menuButton = new MenuButton( );
            Items.Add( _menuButton );
            _exitButton = new ExitButton( );
            Items.Add( _exitButton );
        }
    }
}