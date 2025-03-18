// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-22-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-22-2025
// ******************************************************************************************
// <copyright file="TextExtractor.cs" company="Terry D. Eppler">
//    Badger is a small and simple windows (wpf) application for interacting with the OpenAI API
//    that's developed in C-Sharp under the MIT license.C#.
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
//   TextExtractor.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using PdfSharp.Pdf.IO;
    using System.Text;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.TextExtractor" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    public class TextExtractor : IDisposable
    {
        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The entry
        /// </summary>
        private protected object _entry = new object( );

        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// The timer callback
        /// </summary>
        private protected TimerCallback _timerCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextExtractor"/> class.
        /// </summary>
        public TextExtractor( )
        {
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private protected void Busy( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = true;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private protected void Chill( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = false;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Extract text from all pages in all PDFs in a directory
        /// </summary>
        /// <param name="dirPath">The directory dirPath.</param>
        /// <returns></returns>
        public IList<string> GetFromFolder( string dirPath )
        {
            try
            {
                ThrowIf.Empty( dirPath, nameof( dirPath ) );
                var _chunks = new List<string>( );
                var _files = Directory.GetFiles( dirPath, "*.pdf" );
                foreach( var _file in _files )
                {
                    using var _document = PdfReader.Open( _file, PdfDocumentOpenMode.Import );
                    var _text = new StringBuilder( );
                    foreach( var _page in _document.Pages )
                    {
                        var _content = _page.Contents.Elements;
                        foreach( var _element in _content )
                        {
                            _text.Append( _element );
                        }
                    }

                    _chunks.Add( _text.ToString( ) );
                }

                return _chunks;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Extract text from a specific PDF file, page by page
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public IList<string> GetFromFile( string filePath )
        {
            try
            {
                ThrowIf.Empty(filePath, nameof(filePath));
                var _chunks = new List<string>( );
                using var _document = PdfReader.Open( filePath, PdfDocumentOpenMode.Import );
                foreach( var _page in _document.Pages )
                {
                    var _text = new StringBuilder( );
                    foreach( var _element in _page.Contents.Elements )
                    {
                        _text.Append( _element );
                    }

                    _chunks.Add( _text.ToString( ) );
                }

                return _chunks;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Extract metadata (e.g., title, author) from a PDF file
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public IDictionary<string, string> GetMetadata( string filePath )
        {
            try
            {
                ThrowIf.Empty( filePath, nameof( filePath ) );
                var _metadata = new Dictionary<string, string>( );
                using var _document = PdfReader.Open( filePath, PdfDocumentOpenMode.Import );
                _metadata[ "Title" ] = _document.Info.Title ?? "Unknown";
                _metadata[ "Author" ] = _document.Info.Author ?? "Unknown";
                _metadata[ "Subject" ] = _document.Info.Subject ?? "Unknown";
                _metadata[ "Keywords" ] = _document.Info.Keywords ?? "None";
                return _metadata;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, string> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c>
        /// to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                _timer?.Dispose( );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            using var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}