// ************************************************************************************************
//     Assembly:                Badger
//     File:                    TextData.cs
//     Author:                  Terry D. Eppler
//     Created:                 02-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-28-2025
// ************************************************************************************************
// <copyright file="TextData.cs" company="Terry Eppler">
//    Badger is a Federal Budget, Finance, and Accounting application providing Machine Learning/AI functionality for
//    analysts with the US Environmental Protection Agency (US EPA).
//    Copyright �  2023  Terry Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the �Software�),
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
//    THE SOFTWARE IS PROVIDED �AS IS�, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
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
//   TextData.cs
// </summary>
// ************************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.ML.Data;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class TextData
    {
        /// <summary>
        /// The text
        /// </summary>
        private protected string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextData"/> class.
        /// </summary>
        public TextData( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextData"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public TextData( string text )
        {
            _text = text;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [ LoadColumn( 0 ) ]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
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