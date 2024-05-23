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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public abstract class ColorCache
    {
        /// <summary>
        /// The dark green
        /// </summary>
        private protected Color _darkGreen = Colors.ForestGreen;

        /// <summary>
        /// The light green
        /// </summary>
        private protected Color _lightGreen = Colors.LimeGreen;

        /// <summary>
        /// The red
        /// </summary>
        private protected Color _red = Colors.Red;

        /// <summary>
        /// The white
        /// </summary>
        private protected Color _white = Colors.White;

        /// <summary>
        /// The black
        /// </summary>
        private protected Color _black = Colors.Black;

        /// <summary>
        /// The transparent
        /// </summary>
        private protected Color _transparent = Colors.Transparent;

        /// <summary>
        /// The hover gray
        /// </summary>
        private protected Color _hoverGray = new Color( )
        {
            A = 255,
            R = 70,
            G = 70,
            B = 70
        };

        /// <summary>
        /// The maroon
        /// </summary>
        private protected Color _maroon = Colors.Maroon;

        /// <summary>
        /// The dark interior
        /// </summary>
        private protected Color _darkInterior = new Color( )
        {
            A = 255,
            R = 70,
            G = 70,
            B = 70
        };

        /// <summary>
        /// The dark border
        /// </summary>
        private protected Color _darkBorderColor = new Color( )
        {
            A = 255,
            R = 65,
            G = 65,
            B = 65
        };

        private protected Color _blueBorderColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 120,
            B = 212
        };

        /// <summary>
        /// The dark background
        /// </summary>
        private protected Color _darkBackColor = new Color( )
        {
            A = 255,
            R = 40,
            G = 40,
            B = 40
        };

        /// <summary>
        /// The hover dark blue
        /// </summary>
        private protected Color _hoverBlue = new Color( )
        {
            A = 255,
            R = 50,
            G = 93,
            B = 129
        };

        /// <summary>
        /// The metro blue
        /// </summary>
        private protected Color _steelBlue = Colors.SteelBlue;

        /// <summary>
        /// The blue highlight
        /// </summary>
        private protected Color _blueForeColor = new Color( )
        {
            A = 255,
            R = 106,
            G = 189,
            B = 252
        };

        /// <summary>
        /// The notification color
        /// </summary>
        private protected Color _notificationBackColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 73,
            B = 112
        };

        /// <summary>
        /// The palette
        /// </summary>
        private protected Color[ ] _palette;

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
        /// Initializes a new instance of the <see cref="ColorCache"/> class.
        /// </summary>
        protected ColorCache( )
        {
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
