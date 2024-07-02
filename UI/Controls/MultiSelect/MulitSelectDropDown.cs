// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 06-21-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        06-21-2024
// ******************************************************************************************
// <copyright file="MetroMultiSelect.cs" company="Terry D. Eppler">
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
//   MetroMultiSelect.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Media;
    using Syncfusion.UI.Xaml.Grid;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.UI.Xaml.Grid.SfMultiColumnDropDownControl" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class MulitSelectDropDown : SfMultiColumnDropDownControl
    {
        /// <summary>
        /// The back color
        /// </summary>
        private protected Color _backColor = new Color( )
        {
            A = 255,
            R = 45,
            G = 45,
            B = 45
        };

        /// <summary>
        /// The item back color
        /// </summary>
        private protected Color _popupBackColor = new Color( )
        {
            A = 255,
            R = 75,
            G = 75,
            B = 75
        };

        /// <summary>
        /// The popup border
        /// </summary>
        private protected Color _popupBorder = new Color( )
        {
            A = 255,
            R = 160,
            G = 189,
            B = 252
        };

        /// <summary>
        /// The popup dropdown
        /// </summary>
        private protected Color _popupDropdown = new Color( )
        {
            A = 255,
            R = 10,
            G = 10,
            B = 10
        };

        /// <summary>
        /// The item fore color
        /// </summary>
        private protected Color _itemForeColor = new Color( )
        {
            A = 255,
            R = 222,
            G = 222,
            B = 222
        };

        /// <summary>
        /// The fore color
        /// </summary>
        private protected Color _foreColor = new Color( )
        {
            A = 255,
            R = 222,
            G = 222,
            B = 222
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

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MetroMultiSelect" /> class.
        /// </summary>
        public MulitSelectDropDown( )
        {
            // Control Properties
            SetResourceReference( StyleProperty, typeof( SfMultiColumnDropDownControl ) );
            Width = 175;
            Height = 30;
            FontFamily = new FontFamily( "Segoe UI" );
            FontSize = 12;
            Background = new SolidColorBrush( _backColor );
            Foreground = new SolidColorBrush( _foreColor );
            BorderBrush = new SolidColorBrush( _borderColor );
            PopupBorderThickness = new Thickness( 1 );
            PopupBackground = new SolidColorBrush( _popupBackColor );
            PopupBorderBrush = new SolidColorBrush( _popupBorder );
        }

        /// <summary>
        /// Fails the specified _ex.
        /// </summary>
        /// <param name="_ex">The _ex.</param>
        private protected void Fail( Exception _ex )
        {
            var _error = new ErrorWindow( _ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}