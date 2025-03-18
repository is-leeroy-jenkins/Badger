// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-10-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-10-2025
// ******************************************************************************************
// <copyright file="GptUsage.cs" company="Terry D. Eppler">
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
//   GptUsage.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    public class GptUsage : PropertyChangedBase
    {
        /// <summary>
        /// The prompt tokens
        /// </summary>
        private protected int _promptTokens;

        /// <summary>
        /// The completion tokens
        /// </summary>
        private protected int _completionTokens;

        /// <summary>
        /// The total tokens
        /// </summary>
        private protected int _totalTokens;

        /// <summary>
        /// The data
        /// </summary>
        private protected IDictionary<string, object> _data;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="GptUsage"/> class.
        /// </summary>
        public GptUsage( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GptUsage"/> class.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="completion">The completion.</param>
        /// <param name="total">The total.</param>
        public GptUsage( int prompt, int completion, int total )
        {
            _promptTokens = prompt;
            _completionTokens = completion;
            TotalTokens = total;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="GptUsage"/> class.
        /// </summary>
        /// <param name="usage">The usage.</param>
        public GptUsage( GptUsage usage )
        {
            _promptTokens = usage.PromptTokens;
            _completionTokens = usage.CompletionTokens;
            TotalTokens = usage.TotalTokens;
        }

        /// <summary>
        /// Deconstructs the specified prompt tokens.
        /// </summary>
        /// <param name="promptTokens">The prompt tokens.</param>
        /// <param name="completionTokens">The completion tokens.</param>
        /// <param name="totalTokens">The total tokens.</param>
        public void Deconstruct( out int promptTokens, out int completionTokens,
            out int totalTokens )
        {
            promptTokens = _promptTokens;
            completionTokens = _completionTokens;
            totalTokens = TotalTokens;
        }

        /// <summary>
        /// Gets or sets the prompt tokens.
        /// </summary>
        /// <value>
        /// The prompt tokens.
        /// </value>
        [ JsonPropertyName( "promptTokens" ) ]
        public int PromptTokens
        {
            get
            {
                return _promptTokens;
            }
            set
            {
                if( _promptTokens != value )
                {
                    _promptTokens = value;
                    OnPropertyChanged( nameof( PromptTokens ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the completion tokens.
        /// </summary>
        /// <value>
        /// The completion tokens.
        /// </value>
        [ JsonPropertyName( "completionTokens" ) ]
        public int CompletionTokens
        {
            get
            {
                return _completionTokens;
            }
            set
            {
                if( _completionTokens != value )
                {
                    _completionTokens = value;
                    OnPropertyChanged( nameof( CompletionTokens ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the total tokens.
        /// </summary>
        /// <value>
        /// The total tokens.
        /// </value>
        [ JsonPropertyName( "totalTokens" ) ]
        public int TotalTokens
        {
            get
            {
                return TotalTokens;
            }
            set
            {
                if( TotalTokens != value )
                {
                    TotalTokens = value;
                    OnPropertyChanged( nameof( TotalTokens ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetData( )
        {
            try
            {
                _data.Add( "promptTokens", _promptTokens );
                _data.Add( "completionTokens", _completionTokens );
                _data.Add( "totalTokens", TotalTokens );
                return _data?.Any( ) == true
                    ? _data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents this instance.
        /// </returns>
        public override string ToString( )
        {
            try
            {
                return _data?.Any( ) == true
                    ? _data.ToJson( )
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
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