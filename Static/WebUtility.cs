// ******************************************************************************************
//     Assembly:                Baby
//     Author:                  Terry D. Eppler
//     Created:                 09-09-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-09-2024
// ******************************************************************************************
// <copyright file="WebUtility.cs" company="Terry D. Eppler">
//     Baby is a light-weight, full-featured, web-browser built with .NET 6 and is written
//     in C#.  The baby browser is designed for budget execution and data analysis.
//     A tool for EPA analysts and a component that can be used for general browsing.
// 
//     Copyright ©  2020 Terry D. Eppler
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
//   WebUtility.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertIfStatementToSwitchStatement" ) ]
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public static class WebUtility
    {
        /// <summary>
        /// Paths to URL.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="removeBaseDir">The remove base dir.</param>
        /// <returns></returns>
        public static string PathToUrl( this string filePath, string removeBaseDir = null )
        {
            try
            {
                if( !filePath.CheckIfValid( ) )
                {
                    return "";
                }

                return @"file:///" + filePath.Replace( @"\", "/" );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Determines whether [is file offline].
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// <c> true </c>
        /// if [is file offline] [the specified URL]; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsFileOffline( this string url )
        {
            try
            {
                return url.StartsWith( "file://", StringComparison.Ordinal );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// Determines whether this instance is localhost.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified URL is localhost; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public static bool IsLocalhost( this string url )
        {
            try
            {
                return url.BeginsWith( "http://localhost" ) || url.BeginsWith( "localhost" );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// URLs the decode.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static string UrlDecode( this string url )
        {
            try
            {
                if( url == null )
                {
                    return null;
                }

                var _length = url.Length;
                var _decoder = new UrlDecoder( _length, Encoding.UTF8 );
                for( var _i = 0; _i < _length; _i++ )
                {
                    var _char = url[ _i ];
                    if( _char == '+' )
                    {
                        _char = ' ';
                    }
                    else if( _char == '%'
                        && _i < _length - 2 )
                    {
                        if( url[ _i + 1 ] == 'u'
                            && _i < _length - 5 )
                        {
                            var _num3 = url[ _i + 2 ].HexToInt( );
                            var _num4 = url[ _i + 3 ].HexToInt( );
                            var _num5 = url[ _i + 4 ].HexToInt( );
                            var _num6 = url[ _i + 5 ].HexToInt( );
                            if( _num3 < 0
                                || _num4 < 0
                                || _num5 < 0
                                || _num6 < 0 )
                            {
                                goto Label_010B;
                            }

                            _char = ( char )( ( _num3 << 12 ) | ( _num4 << 8 ) | ( _num5 << 4 )
                                | _num6 );

                            _i += 5;
                            _decoder.AddChar( _char );
                            continue;
                        }

                        var _num7 = url[ _i + 1 ].HexToInt( );
                        var _num8 = url[ _i + 2 ].HexToInt( );
                        if( _num7 >= 0
                            && _num8 >= 0 )
                        {
                            var _b = ( byte )( ( _num7 << 4 ) | _num8 );
                            _i += 2;
                            _decoder.AddByte( _b );
                            continue;
                        }
                    }

                    Label_010B:
                    if( ( _char & 0xff80 ) == 0 )
                    {
                        _decoder.AddByte( ( byte )_char );
                    }
                    else
                    {
                        _decoder.AddChar( _char );
                    }
                }

                return _decoder.GetString( );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Hexadecimals to int.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns></returns>
        public static int HexToInt( this char hex )
        {
            try
            {
                return hex switch
                {
                    >= '0' and <= '9' => hex - '0',
                    >= 'a' and <= 'f' => hex - 'a' + 10,
                    >= 'A' and <= 'F' => hex - 'A' + 10,
                    var _ => -1
                };
            }
            catch( Exception ex )
            {
                Fail( ex );
                return -1;
            }
        }

        /// <summary>
        /// Decodes the URL for filepath.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static string DecodeUrlForFilePath( this string url )
        {
            try
            {
                if( url == null )
                {
                    return null;
                }

                var _length = url.Length;
                var _decoder = new UrlDecoder( _length * 10, Encoding.UTF8 )
                {
                    ForFilePaths = true
                };

                for( var _i = 0; _i < _length; _i++ )
                {
                    var _ch = url[ _i ];
                    if( _ch == '+' )
                    {
                        _ch = ' ';
                    }
                    else if( _ch == '%'
                        && _i < _length - 2 )
                    {
                        if( url[ _i + 1 ] == 'u'
                            && _i < _length - 5 )
                        {
                            var _num3 = url[ _i + 2 ].HexToInt( );
                            var _num4 = url[ _i + 3 ].HexToInt( );
                            var _num5 = url[ _i + 4 ].HexToInt( );
                            var _num6 = url[ _i + 5 ].HexToInt( );
                            if( _num3 < 0
                                || _num4 < 0
                                || _num5 < 0
                                || _num6 < 0 )
                            {
                                goto Label_010B;
                            }

                            _ch = ( char )( ( _num3 << 12 ) | ( _num4 << 8 ) | ( _num5 << 4 )
                                | _num6 );

                            _i += 5;
                            _decoder.FlushBytes( false );
                            _decoder.AddChar( _ch, true );
                            continue;
                        }

                        var _num7 = url[ _i + 1 ].HexToInt( );
                        var _num8 = url[ _i + 2 ].HexToInt( );
                        if( _num7 >= 0
                            && _num8 >= 0 )
                        {
                            var _b = ( byte )( ( _num7 << 4 ) | _num8 );
                            _i += 2;
                            _decoder.FlushBytes( false );
                            _decoder.AddByte( _b );
                            if( _i + 1 < _length - 2
                                && url[ _i + 1 ] == '%' )
                            {
                                _num7 = url[ _i + 1 ].HexToInt( );
                                _num8 = url[ _i + 2 ].HexToInt( );
                                if( _num7 >= 0
                                    && _num8 >= 0 )
                                {
                                    _b = ( byte )( ( _num7 << 4 ) | _num8 );
                                    _i += 2;
                                    _decoder.AddByte( _b );
                                    _decoder.FlushBytes( true );
                                }
                            }
                            else
                            {
                                _decoder.FlushBytes( true );
                            }

                            continue;
                        }
                    }

                    Label_010B:
                    if( ( _ch & 0xff80 ) == 0 )
                    {
                        _decoder.AddByte( ( byte )_ch );
                    }
                    else
                    {
                        _decoder.AddChar( _ch, false );
                    }
                }

                return _decoder.GetString( );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// URLs the encode.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string UrlEncode( this string text )
        {
            return Uri.EscapeDataString( text );
        }

        /// <summary>
        /// Get ErrorDialog Dialog.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        private static void Fail( Exception ex )
        {
            using var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}