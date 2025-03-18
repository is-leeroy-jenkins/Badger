// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-16-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-16-2025
// ******************************************************************************************
// <copyright file="PdfRenderer.cs" company="Terry D. Eppler">
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
//   PdfRenderer.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class PdfRenderer : IDisposable
    {
        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfRenderer"/> class.
        /// </summary>
        public PdfRenderer( )
        {
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="position">The position.</param>
        /// <param name="brush">The brush.</param>
        /// <exception cref="System.ArgumentNullException">page</exception>
        public void DrawText( PdfPage page, string text, XFont font,
            XPoint position, XBrush brush = null )
        {
            if( page == null )
            {
                throw new ArgumentNullException( nameof( page ) );
            }

            using var _gfx = XGraphics.FromPdfPage( page );
            brush ??= XBrushes.Black;
            _gfx.DrawString( text, font, brush, position );
        }

        /// <summary>
        /// Draws the image.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="rect">The rect.</param>
        /// <exception cref="System.ArgumentNullException">page</exception>
        public void DrawImage( PdfPage page, string imagePath, XRect rect )
        {
            if( page == null )
            {
                throw new ArgumentNullException( nameof( page ) );
            }

            using var _gfx = XGraphics.FromPdfPage( page );
            using var _image = XImage.FromFile( imagePath );
            _gfx.DrawImage( _image, rect );
        }

        /// <summary>
        /// Draws the rectangle.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <exception cref="System.ArgumentNullException">page</exception>
        public void DrawRectangle( PdfPage page, XRect rect, XPen pen,
            XBrush brush = null )
        {
            if( page == null )
            {
                throw new ArgumentNullException( nameof( page ) );
            }

            using var _gfx = XGraphics.FromPdfPage( page );
            brush ??= XBrushes.Transparent;
            _gfx.DrawRectangle( pen, brush, rect );
        }

        /// <summary>
        /// Draws the ellipse.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <exception cref="System.ArgumentNullException">page</exception>
        public void DrawEllipse( PdfPage page, XRect rect, XPen pen,
            XBrush brush = null )
        {
            if( page == null )
            {
                throw new ArgumentNullException( nameof( page ) );
            }

            using var _gfx = XGraphics.FromPdfPage( page );
            brush ??= XBrushes.Transparent;
            _gfx.DrawEllipse( pen, brush, rect );
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