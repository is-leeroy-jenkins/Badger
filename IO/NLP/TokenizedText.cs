// ************************************************************************************************
//     Assembly:                Badger
//     File:                    TokenizedText.cs
//     Author:                  Terry D. Eppler
//     Created:                 02-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-28-2025
// ************************************************************************************************
// <copyright file="TokenizedText.cs" company="Terry Eppler">
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
//   TokenizedText.cs
// </summary>
// ************************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    public class TokenizedText
    {
        /// <summary>
        /// The tokens
        /// </summary>
        private string[ ] _tokens;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenizedText"/> class.
        /// </summary>
        public TokenizedText( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenizedText"/> class.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        public TokenizedText( string[ ] tokens )
        {
            _tokens = tokens;
        }

        /// <summary>
        /// Gets or sets the tokens.
        /// </summary>
        /// <value>
        /// The tokens.
        /// </value>
        public string[ ] Tokens
        {
            get
            {
                return _tokens;
            }
            set
            {
                _tokens = value;
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