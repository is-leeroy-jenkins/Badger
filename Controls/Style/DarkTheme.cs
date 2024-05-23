// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
//
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
// ******************************************************************************************
// <copyright file="${File.FileName}" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application 
//    for the US Environmental Protection Agency (US EPA).
//    Copyright ©  ${CurrentDate.Year}  Terry Eppler
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
//   ${File.FileName}
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Media;

    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class DarkTheme : ColorCache
    {
        /// <summary>
        /// The back color brush
        /// </summary>
        private protected SolidColorBrush _backColorBrush;

        /// <summary>
        /// The border color brush
        /// </summary>
        private protected SolidColorBrush _borderColorBrush;

        /// <summary>
        /// The fore color brush
        /// </summary>
        private protected SolidColorBrush _foreColorBrush;

        /// <summary>
        /// The back hover brush
        /// </summary>
        private protected SolidColorBrush _backHoverBrush;

        /// <summary>
        /// The border hover brush
        /// </summary>
        private protected SolidColorBrush _borderHoverBrush;

        /// <summary>
        /// The fore hover brush
        /// </summary>
        private protected SolidColorBrush _foreHoverBrush;

        /// <summary>
        /// The back color
        /// </summary>
        private protected Color _darkBackColor = new Color( )
        {
            A = 255,
            R = 40,
            G = 40,
            B = 40
        };

        /// <summary>
        /// The back hover color
        /// </summary>
        private protected Color _backHover = new Color( )
        {
            A = 255,
            R = 25,
            G = 76,
            B = 120
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
        private Color _blueBorderColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 120,
            B = 212
        };

        /// <summary>
        /// The border hover color
        /// </summary>
        private readonly Color _borderHoverColor = new Color( )
        {
            A = 255,
            R = 50,
            G = 93,
            B = 129
        };

        /// <summary>
        /// Gets or sets the background.
        /// </summary>
        /// <value>
        /// The background.
        /// </value>
        public SolidColorBrush Background
        {
            get
            {
                return _backColorBrush;
            }
            set
            {
                _backColorBrush = value;
            }
        }

        /// <summary>
        /// Gets or sets the foreground.
        /// </summary>
        /// <value>
        /// The foreground.
        /// </value>
        public SolidColorBrush Foreground
        {
            get
            {
                return _foreColorBrush;
            }
            set
            {
                _foreColorBrush = value;
            }
        }

        /// <summary>
        /// Gets or sets the border brush.
        /// </summary>
        /// <value>
        /// The border brush.
        /// </value>
        public SolidColorBrush BorderBrush
        {
            get
            {
                return _borderColorBrush;
            }
            set
            {
                _borderColorBrush = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DarkTheme"/> class.
        /// </summary>
        public DarkTheme( )
        {
            _backColorBrush = new SolidColorBrush( _darkBackColor );
            _borderColorBrush = new SolidColorBrush( _blueBorderColor );
            _foreColorBrush = new SolidColorBrush( _foreColor );
            _backHoverBrush = new SolidColorBrush( _backHover );
            _borderHoverBrush = new SolidColorBrush( _borderHoverColor );
            _foreHoverBrush = new SolidColorBrush( _foreHover );
            Background = _backColorBrush;
            Foreground = _foreColorBrush;
            BorderBrush = _borderColorBrush;
        }
    }
}
