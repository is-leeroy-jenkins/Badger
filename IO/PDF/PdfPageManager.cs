// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-16-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-16-2025
// ******************************************************************************************
// <copyright file="PdfPageManager.cs" company="Terry D. Eppler">
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
//   PdfPageManager.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using PdfSharp.Pdf;
    using System.Threading;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.IDisposable" />
    [SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class PdfPageManager : PropertyChangedBase, IDisposable
    {
        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// The document
        /// </summary>
        private readonly PdfDocument _document;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PdfPageManager"/> class.
        /// </summary>
        public PdfPageManager( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PdfPageManager"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <exception cref="System.ArgumentNullException">
        /// document
        /// </exception>
        public PdfPageManager( PdfDocument document )
        {
            _document = document ?? throw new ArgumentNullException( nameof( document ) );
        }

        /// <summary>
        /// Adds the page.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">
        /// Document not initialized.</exception>
        public PdfPage AddPage( )
        {
            if( _document == null )
            {
                throw new InvalidOperationException( "Document not initialized." );
            }

            return _document.AddPage( );
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Invalid page index.</exception>
        public PdfPage GetPage( int index )
        {
            if( _document == null
                || index < 0
                || index >= _document.PageCount )
            {
                var _message = "Invalid page index.";
                throw new ArgumentOutOfRangeException( _message );
            }

            return _document.Pages[ index ];
        }

        /// <summary>
        /// Removes the page.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Invalid page index.</exception>
        public void RemovePage( int index )
        {
            if( _document == null
                || index < 0
                || index >= _document.PageCount )
            {
                var _message = "Invalid page index.";
                throw new ArgumentOutOfRangeException( _message );
            }

            _document.Pages.RemoveAt( index );
        }

        // Duplicating a page
        /// <summary>
        /// Duplicates the page.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public PdfPage DuplicatePage( int index )
        {
            var _page = GetPage( index );
            var _newPage = _document.AddPage( _page );
            return _newPage;
        }

        // Reordering pages
        /// <summary>
        /// Moves the page.
        /// </summary>
        /// <param name="fromIndex">From index.</param>
        /// <param name="toIndex">To index.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Invalid page indices.</exception>
        public void MovePage( int fromIndex, int toIndex )
        {
            if( fromIndex < 0
                || fromIndex >= _document.PageCount
                || toIndex < 0
                || toIndex >= _document.PageCount )
            {
                var _message = "Invalid page indices.";
                throw new ArgumentOutOfRangeException( _message );
            }

            var _page = _document.Pages[ fromIndex ];
            _document.Pages.RemoveAt( fromIndex );
            _document.Pages.Insert( toIndex, _page );
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