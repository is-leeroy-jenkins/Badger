// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="UrlDecoder.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
// 
//    Copyright ©  2020-2024 Terry D. Eppler
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
//   UrlDecoder.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class UrlDecoder : PropertyChangedBase
    {
        /// <summary>
        /// The buffer size
        /// </summary>
        private int _bufferSize;

        /// <summary>
        /// The byte buffer
        /// </summary>
        private byte[ ] _byteBuffer;

        /// <summary>
        /// The character buffer
        /// </summary>
        private char[ ] _charBuffer;

        /// <summary>
        /// The encoding
        /// </summary>
        private Encoding _encoding;

        /// <summary>
        /// The number bytes
        /// </summary>
        private int _byteCount;

        /// <summary>
        /// The number chars
        /// </summary>
        private int _charCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlDecoder"/> class.
        /// </summary>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="encoding">The encoding.</param>
        public UrlDecoder( int bufferSize, Encoding encoding )
        {
            _bufferSize = bufferSize;
            _encoding = encoding;
            _charBuffer = new char[ bufferSize ];
            _byteBuffer = new byte[ bufferSize ];
        }

        /// <summary>
        /// Gets or sets a value indicating whether [for file paths].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [for file paths]; otherwise, <c>false</c>.
        /// </value>
        public bool ForFilePaths { get; set; }

        /// <summary>
        /// Flushes the bytes.
        /// </summary>
        /// <param name="checkChar">if set to
        /// <c>true</c> [check character].</param>
        public void FlushBytes( bool checkChar = false )
        {
            if( _byteCount > 0 )
            {
                if( checkChar && ForFilePaths )
                {
                    var _newChars = _encoding.GetChars( _byteBuffer, 0, _byteCount );
                    _byteCount = 0;
                    foreach( var _ch in _newChars )
                    {
                        AddChar( _ch );
                    }
                }
                else
                {
                    _charCount += _encoding.GetChars( _byteBuffer, 0, _byteCount, _charBuffer,
                        _charCount );

                    _byteCount = 0;
                }
            }
        }

        /// <summary>
        /// Adds the byte.
        /// </summary>
        /// <param name="b">The b.</param>
        public void AddByte( byte b )
        {
            if( _byteBuffer == null )
            {
                _byteBuffer = new byte[ _bufferSize ];
            }

            _byteBuffer[ _byteCount++ ] = b;
        }

        /// <summary>
        /// Adds the character.
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <param name="checkChar">if set to <c>true</c> [check character].</param>
        public void AddChar( char ch, bool checkChar = false )
        {
            if( _byteCount > 0 )
            {
                FlushBytes( );
            }

            if( checkChar && ForFilePaths )
            {
                if( !ch.SupportedInFilePath( ) )
                {
                    AddChar( '_' );
                    AddString( "0x" + ( ( int )ch ).ToString( "X" ) );
                    AddChar( '_' );
                    return;
                }
            }

            _charBuffer[ _charCount++ ] = ch;
        }

        /// <summary>
        /// Adds the string.
        /// </summary>
        /// <param name="str">The string.</param>
        public void AddString( string str )
        {
            if( _byteCount > 0 )
            {
                FlushBytes( );
            }

            foreach( var _ch in str )
            {
                _charBuffer[ _charCount++ ] = _ch;
            }
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns></returns>
        public string GetString( )
        {
            if( _byteCount > 0 )
            {
                FlushBytes( );
            }

            return _charCount > 0
                ? new string( _charBuffer, 0, _charCount )
                : string.Empty;
        }
    }
}