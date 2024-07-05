// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-02-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-02-2024
// ******************************************************************************************
// <copyright file="PaletteB.cs" company="Terry D. Eppler">
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
//   PaletteB.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Media;

    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "UseObjectOrCollectionInitializer" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExplicitArrayCreation" ) ]
    public abstract class Palette
        : IPalette
    {
        /// <summary>
        /// The model palette
        /// </summary>
        private protected IList<Brush> _colorModel;

        /// <summary>
        /// The color map
        /// </summary>
        private protected IDictionary<string, Brush> _colorMap;

        /// <summary>
        /// The colors
        /// </summary>
        private protected SolidColorBrush[ ] _color;

        /// <inheritdoc />
        /// <summary>
        /// The steel blue
        /// </summary>
        private protected Color _hoverColor = Colors.SteelBlue;

        /// <inheritdoc />
        /// <summary>
        /// The maroon
        /// </summary>
        private protected Color _redColor = Colors.Maroon;

        /// <inheritdoc />
        /// <summary>
        /// The green
        /// </summary>
        private protected Color _greenColor = Colors.DarkOliveGreen;

        /// <inheritdoc />
        /// <summary>
        /// The yellow
        /// </summary>
        private protected Color _khakiColor = Colors.DarkKhaki;

        /// <inheritdoc />
        /// <summary>
        /// The orange
        /// </summary>
        private protected Color _yellowColor = Colors.Yellow;

        /// <inheritdoc />
        /// <summary>
        /// The back color
        /// </summary>
        private protected Color _backColor = new Color( )
        {
            A = 255,
            R = 20,
            G = 20,
            B = 20
        };

        /// <summary>
        /// The control color
        /// </summary>
        private protected Color _controlColor = new Color( )
        {
            A = 255,
            R = 45,
            G = 45,
            B = 45
        };

        /// <summary>
        /// The wall color
        /// </summary>
        private protected Color _wallColor = new Color( )
        {
            A = 255,
            R = 55,
            G = 55,
            B = 55
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
        private protected Color _borderColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 120,
            B = 212
        };

        /// <summary>
        /// The light blue
        /// </summary>
        private protected Color _lightBlue = new Color( )
        {
            A = 255,
            R = 160,
            G = 189,
            B = 252
        };

        /// <summary>
        /// The black color
        /// </summary>
        private protected Color _blackColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 0,
            B = 0
        };

        /// <summary>
        /// The transparent color
        /// </summary>
        private protected Color _transparentColor = new Color( )
        {
            A = 0,
            R = 0,
            G = 0,
            B = 0
        };

        protected Palette( )
        {
        }

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>
        /// The colors.
        /// </value>
        public SolidColorBrush[ ] Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color map.
        /// </summary>
        /// <value>
        /// The color map.
        /// </value>
        public IDictionary<string, Brush> ColorMap
        {
            get
            {
                return _colorMap;
            }
            private protected set
            {
                _colorMap = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color model.
        /// </summary>
        /// <value>
        /// The color model.
        /// </value>
        public IList<Brush> ColorModel
        {
            get
            {
                return _colorModel;
            }
            private protected set
            {
                _colorModel = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the fore.
        /// </summary>
        /// <value>
        /// The color of the fore.
        /// </value>
        public SolidColorBrush Transparent { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the black.
        /// </summary>
        /// <value>
        /// The color of the black.
        /// </value>
        public SolidColorBrush BlackColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the fore.
        /// </summary>
        /// <value>
        /// The color of the fore.
        /// </value>
        public SolidColorBrush ForeColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the back.
        /// </summary>
        /// <value>
        /// The color of the back.
        /// </value>
        public SolidColorBrush BackColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the border.
        /// </summary>
        /// <value>
        /// The color of the border.
        /// </value>
        public SolidColorBrush BorderColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the color of the control.
        /// </summary>
        /// <value>
        /// The color of the control.
        /// </value>
        public SolidColorBrush ControlColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the color of the wall.
        /// </summary>
        /// <value>
        /// The color of the wall.
        /// </value>
        public SolidColorBrush WallColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the light blue.
        /// </summary>
        /// <value>
        /// The light blue.
        /// </value>
        public SolidColorBrush LightBlue { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the hover.
        /// </summary>
        /// <value>
        /// The color of the hover.
        /// </value>
        public SolidColorBrush HoverColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the red.
        /// </summary>
        /// <value>
        /// The color of the red.
        /// </value>
        public SolidColorBrush RedColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the khaki.
        /// </summary>
        /// <value>
        /// The color of the khaki.
        /// </value>
        public SolidColorBrush KhakiColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the green.
        /// </summary>
        /// <value>
        /// The color of the green.
        /// </value>
        public SolidColorBrush GreenColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the yellow.
        /// </summary>
        /// <value>
        /// The color of the yellow.
        /// </value>
        public SolidColorBrush YellowColor { get; private protected init; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the color of the gray.
        /// </summary>
        /// <value>
        /// The color of the gray.
        /// </value>
        public SolidColorBrush GrayColor { get; private protected init; }

        /// <summary>
        /// Creates the colors.
        /// </summary>
        /// <returns></returns>
        private protected virtual SolidColorBrush[ ] CreateColors( )
        {
            try
            {
                var _array = new SolidColorBrush[ ]
                {
                    HoverColor,
                    GrayColor,
                    YellowColor,
                    RedColor,
                    KhakiColor,
                    GreenColor
                };

                return _array?.Length > 0
                    ? _array
                    : default( SolidColorBrush[ ] );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( SolidColorBrush[ ] );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the color model.
        /// </summary>
        /// <returns></returns>
        private protected virtual IList<Brush> CreateColorModel( )
        {
            try
            {
                var _list = new List<Brush>
                {
                    HoverColor,
                    GrayColor,
                    YellowColor,
                    RedColor,
                    KhakiColor,
                    GreenColor
                };

                return _list?.Count > 0
                    ? _list
                    : default( IList<Brush> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<Brush> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the color map.
        /// </summary>
        /// <returns></returns>
        private protected virtual IDictionary<string, Brush> CreateColorMap( )
        {
            try
            {
                var _map = new Dictionary<string, Brush>( );
                _map.Add( "HoverColor", HoverColor );
                _map.Add( "GrayColor", GrayColor );
                _map.Add( "YellowColor", YellowColor );
                _map.Add( "RedColor", RedColor );
                _map.Add( "KhakiColor", KhakiColor );
                _map.Add( "GreenColor", GreenColor );
                return _map?.Count > 0
                    ? _map
                    : default( IDictionary<string, Brush> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, Brush> );
            }
        }

        /// <inheritdoc />
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