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
        /// The status label
        /// </summary>
        private protected StatusLabel _statusLabel;

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
        /// The text box
        /// </summary>
        private protected ToolStripTextBox _textBox;

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
        /// The increase button
        /// </summary>
        private protected IncreaseButton _increaseButton;

        /// <summary>
        /// The decrease button
        /// </summary>
        private protected DecreaseButton _decreaseButton;

        /// <summary>
        /// The save button
        /// </summary>
        private protected SaveButton _saveButton;

        /// <summary>
        /// The browse button
        /// </summary>
        private protected BrowseButton _browseButton;

        /// <summary>
        /// The export button
        /// </summary>
        private protected ExportButton _exportButton;

        /// <summary>
        /// The excel button
        /// </summary>
        private protected ExitButton _exitButton;

        /// <summary>
        /// The map button
        /// </summary>
        private protected PrintButton _printButton;

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
        public StatusLabel StatusLabel
        {
            get
            {
                return _statusLabel;
            }
            private protected set
            {
                _statusLabel = value;
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

        public IncreaseButton IncreaseButton
        {
            get
            {
                return _increaseButton;
            }
            private protected set
            {
                _increaseButton = value;
            }
        }

        public DecreaseButton DecreaseButton
        {
            get
            {
                return _decreaseButton;
            }
            private protected set
            {
                _decreaseButton = value;
            }
        }

        public PrintButton PrintButton
        {
            get
            {
                return _printButton;
            }
            private protected set
            {
                _printButton = value;
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
            Height = 42;
            Width = 1330;
            Background = new SolidColorBrush( _backColor );
            Foreground = new SolidColorBrush( _foreColor );
            BorderBrush = new SolidColorBrush( _borderColor );
        }
    }
}