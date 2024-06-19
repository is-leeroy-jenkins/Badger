// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 05-31-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2024
// ******************************************************************************************
// <copyright file="MetroHyperlink.cs" company="Terry D. Eppler">
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
//   MetroHyperlink.cs
// </summary>
// ******************************************************************************************

// ReSharper disable All
namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Media;
    using ModernWpf.Controls;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Wpf.Ui.Controls.HyperlinkButton" />
    [SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class MetroHyperlink : HyperlinkButton
    {
        /// <summary>
        /// The back color
        /// </summary>
        private protected Color _backColor = new Color( )
        {
            A = 0,
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
            R = 1,
            G = 35,
            B = 54
        };

        /// <summary>
        /// The fore color
        /// </summary>
        private protected Color _foreColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 120,
            B = 212
        };

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
        private readonly Color _borderColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 120,
            B = 212
        };

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MetroHyperlink"/> class.
        /// </summary>
        public MetroHyperlink( )
            : base( )
        {
            // Basic Settings
            Height = 110;
            Width = 22;
            FontFamily = new FontFamily( "Roboto" );
            FontSize = 12;
            Background = new SolidColorBrush( Colors.Transparent );
            Foreground = new SolidColorBrush( _foreColor );
            BorderBrush = new SolidColorBrush( Colors.Transparent );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MetroHyperlink"/> class.
        /// </summary>
        /// <param name = "text" > </param>
        /// <param name="uri">The URI.</param>
        public MetroHyperlink( string text, string uri )
            : this( )
        {
            Content = text;
            NavigateUri = new Uri( uri );
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}