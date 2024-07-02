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
    using System.Windows.Media;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class DarkTheme
        : Palette
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DarkTheme"/> class.
        /// </summary>
        public DarkTheme( ) 
            : base( )
        {
            ForeColor = new SolidColorBrush( _foreColor );
            BackColor = new SolidColorBrush( _backColor );
            BorderColor = new SolidColorBrush( _borderColor );
            WallColor = new SolidColorBrush( _wallColor );
            ControlColor = new SolidColorBrush( _controlColor );
            LightBlue = new SolidColorBrush( _lightBlue );
            HoverColor = new SolidColorBrush( _hoverColor );
            GrayColor = new SolidColorBrush( Colors.DarkGray );
            YellowColor = new SolidColorBrush( _yellowColor );
            RedColor = new SolidColorBrush( _redColor );
            KhakiColor = new SolidColorBrush( _khakiColor );
            GreenColor = new SolidColorBrush( _greenColor );
            _colorModel = CreateColorModel( );
            _colorMap = CreateColorMap( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the color model.
        /// </summary>
        /// <returns>
        /// List( Brush )
        /// </returns>
        public override IList<Brush> CreateColorModel( )
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
        /// <returns>
        /// Dictionary(string, Brush )
        /// </returns>
        public override IDictionary<string, Brush> CreateColorMap( )
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
    }
}
