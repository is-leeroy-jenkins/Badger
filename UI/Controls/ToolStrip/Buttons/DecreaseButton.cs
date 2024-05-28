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
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Resources;
    using System.Windows.Media.Imaging;
    using Resources.Images;

    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class DecreaseButton : ToolStripButton
    {
        /// <summary>
        /// The first button
        /// </summary>
        private protected string _decreaseButton =
            @"\Resources\Assets\ToolStripImages\DecreaseButton.png";

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DecreaseButton"/> class.
        /// </summary>
        /// <inheritdoc />
        public DecreaseButton( )
            : base( )
        {
            SetImage( );
            ToolTip = "Delete";
        }

        /// <summary>
        /// Loads the image.
        /// </summary>
        private void SetImage( )
        {
            try
            {
                var _uri = new Uri( _decreaseButton, UriKind.Relative );
                ImageSource = new BitmapImage( _uri );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
    }
}
