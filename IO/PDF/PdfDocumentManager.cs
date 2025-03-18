// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-16-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-16-2025
// ******************************************************************************************
// <copyright file="PdfDocumentManager.cs" company="Terry D. Eppler">
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
//   PdfDocumentManager.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    using System.Threading;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class PdfDocumentManager : PropertyChangedBase, IDisposable
    {
        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// The page count
        /// </summary>
        private protected int _pageCount;

        /// <summary>
        /// The title
        /// </summary>
        private protected string _title;

        /// <summary>
        /// The author
        /// </summary>
        private protected string _author;

        /// <summary>
        /// The keywords
        /// </summary>
        private protected string _keywords;

        /// <summary>
        /// The version
        /// </summary>
        private protected string _version;

        /// <summary>
        /// The creation date
        /// </summary>
        private protected DateTime _creationDate;

        /// <summary>
        /// The document
        /// </summary>
        private PdfDocument _document;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PdfDocumentManager"/> class.
        /// </summary>
        public PdfDocumentManager( )
        {
        }

        /// <summary>
        /// Creates the new document.
        /// </summary>
        public void CreateNewDocument( )
        {
            _document = new PdfDocument( );
        }

        /// <summary>
        /// Loads the document.
        /// </summary>
        /// <param name="path">The path.</param>
        public void LoadDocument( string path )
        {
            _document = PdfReader.Open( path, PdfDocumentOpenMode.Modify );
        }

        /// <summary>
        /// Saves the document.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="System.InvalidOperationException">
        /// No document loaded.
        /// </exception>
        public void SaveDocument( string path )
        {
            if( _document == null )
            {
                var _message = "No document loaded.";
                throw new InvalidOperationException( _message );
            }

            _document.Save( path );
        }

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <returns></returns>
        public PdfDocument GetDocument( )
        {
            return _document;
        }

        /// <summary>
        /// Gets the page count.
        /// </summary>
        /// <value>
        /// The page count.
        /// </value>
        public int PageCount
        {
            get
            {
                return _document?.PageCount ?? 0;
            }
        }

        // Metadata editing
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return _document.Info.Title;
            }
            set
            {
                _document.Info.Title = value;
            }
        }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author
        {
            get
            {
                return _document.Info.Author;
            }
            set
            {
                _document.Info.Author = value;
            }
        }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject
        {
            get
            {
                return _document.Info.Subject;
            }
            set
            {
                _document.Info.Subject = value;
            }
        }

        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        /// <value>
        /// The keywords.
        /// </value>
        public string Keywords
        {
            get
            {
                return _document.Info.Keywords;
            }
            set
            {
                _document.Info.Keywords = value;
            }
        }

        // Other properties
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version
        {
            get
            {
                return _document.Version.ToString( );
            }
        }

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime? CreationDate
        {
            get
            {
                return _document.Info.CreationDate;
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