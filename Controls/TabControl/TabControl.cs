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
    using Syncfusion.Windows.Tools.Controls;

    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class TabControl : TabControlExt
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
        private protected Color _backColor = new Color( )
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
            R = 17,
            G = 53,
            B = 84
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
        private Color _borderColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 120,
            B = 212
        };

        /// <summary>
        /// The border hover color
        /// </summary>
        private readonly Color _borderHover = new Color( )
        {
            A = 255,
            R = 50,
            G = 93,
            B = 129
        };

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TabControl" /> class.
        /// </summary>
        public TabControl( )
            : base( )
        {
            // Basic Properties
            FontFamily = new FontFamily( "Segoe UI" );
            FontSize = 12;
            Background = new SolidColorBrush( Colors.Transparent );
            BorderBrush = new SolidColorBrush( Colors.Transparent );
            TabPanelBackground = new SolidColorBrush( Colors.Transparent );
            Foreground = new SolidColorBrush( _foreColor );
            NewButtonBackground = new SolidColorBrush( Colors.Transparent );
            TabItemHoverBackground = new SolidColorBrush( _backHover );
            TabItemHoverBorderBrush = new SolidColorBrush( _backHover );
            TabItemHoverForeground = new SolidColorBrush( Colors.White );
            TabItemSelectedForeground = new SolidColorBrush( Colors.White );
            TabItemSelectedBackground = new SolidColorBrush( Colors.SteelBlue );
            TabItemSelectedBorderBrush = new SolidColorBrush( _borderHover );
            CloseButtonType = CloseButtonType.Hide;
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
