// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-10-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-10-2025
// ******************************************************************************************
// <copyright file="GptChoice.cs" company="Terry D. Eppler">
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
//   GptChoice.cs
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
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class GptChoice : PropertyChangedBase
    {
        /// <summary>
        /// The index
        /// </summary>
        private protected int _index;

        /// <summary>
        /// The logprobs
        /// </summary>
        private protected string _logprobs;

        /// <summary>
        /// The finish reason
        /// </summary>
        private protected string _finishReason;

        /// <summary>
        /// The message
        /// </summary>
        private protected string _message;

        /// <summary>
        /// The data
        /// </summary>
        private protected IDictionary<string, object> _data;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="GptChoice"/> class.
        /// </summary>
        public GptChoice( ) 
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GptChoice"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="index">The index.</param>
        /// <param name="logprobs">The logprobs.</param>
        /// <param name="finishReason">The finish reason.</param>
        public GptChoice( int index, string text, string logprobs,
            string finishReason ) 
            : this( )
        {
            _index = index;
            _message = text;
            _logprobs = logprobs;
            _finishReason = finishReason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GptChoice"/> class.
        /// </summary>
        /// <param name="choice">The choice.</param>
        public GptChoice( GptChoice choice )
        {
            _index = choice.Index;
            _message = choice.Message;
            _logprobs = choice.Logprobs;
            _finishReason = choice.FinishReason;
        }

        /// <summary>
        /// Deconstructs the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="text">The text.</param>
        /// <param name="logprobs">The logprobs.</param>
        /// <param name="finishReason">The finish reason.</param>
        public void Deconstruct( out int index, out string text, out string logprobs, 
                                 out string finishReason )
        {
            index = _index;
            text = _message;
            logprobs = _logprobs;
            finishReason = _finishReason;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [ JsonPropertyName( "message" ) ]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if( _message != value )
                {
                    _message = value;
                    OnPropertyChanged( nameof( Message ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        [ JsonPropertyName( "index" ) ]
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                if( _index != value )
                {
                    _index = value;
                    OnPropertyChanged( nameof( Index ) );
                }
            }
        }

        /// <summary>
        /// Log probability information for the choice.
        /// </summary>
        /// <value>
        /// The logprobs.
        /// </value>
        [ JsonPropertyName( "logprobs" ) ]
        public string Logprobs
        {
            get
            {
                return _logprobs;
            }
            set
            {
                if( _logprobs != value )
                {
                    _logprobs = value;
                    OnPropertyChanged( nameof( Logprobs ) );
                }
            }
        }

        /// <summary>
        /// The reason the model stopped generating tokens.
        /// This will be stop if the model hit a natural stop point or a
        /// provided stop sequence, length if the maximum number of tokens
        /// specified in the request was reached, content_filter if
        /// content was omitted due to a flag from our content filters,
        /// tool_calls if the model called a tool, or function_call
        /// (deprecated) if the model called a function.
        /// </summary>
        /// <value>
        /// The finish reason.
        /// </value>
        [ JsonPropertyName( "finish_reason" ) ]
        public string FinishReason
        {
            get
            {
                return _finishReason;
            }
            set
            {
                if( _finishReason != value )
                {
                    _finishReason = value;
                    OnPropertyChanged( nameof( FinishReason ) );
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
                _data.Add( "index", _index );
                _data.Add( "message", _message );
                _data.Add( "logprobs", _logprobs );
                _data.Add( "finish_reason", _finishReason );
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