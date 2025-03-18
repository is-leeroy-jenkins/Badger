// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-31-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-31-2025
// ******************************************************************************************
// <copyright file="EmbeddingRequest.cs" company="Terry D. Eppler">
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
//   EmbeddingRequest.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System.Diagnostics.CodeAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Properties;
    using JsonSerializer = Newtonsoft.Json.JsonSerializer;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.GptRequest" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    public class EmbeddingRequest : GptRequest
    {
        /// <summary>
        /// The file path
        /// </summary>
        private protected string _filePath;

        /// <summary>
        /// The input
        /// </summary>
        private protected string _input;

        /// <summary>
        /// The encoding format
        /// </summary>
        private protected string _encodingFormat;

        /// <summary>
        /// The dimensions
        /// </summary>
        private protected int _dimensions;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="EmbeddingRequest"/> class.
        /// </summary>
        /// <inheritdoc />
        public EmbeddingRequest( )
            : base( )
        {
            _entry = new object( );
            _header = new GptHeader( );
            _endPoint = GptEndPoint.Embeddings;
            _model = "text-embedding-3";
            _messages.Add( new SystemMessage( _systemPrompt ) );
            _encodingFormat = "float";
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="P:Badger.GptRequest.HttpClient" /> is store.
        /// </summary>
        /// <value>
        ///   <c>true</c> if store; otherwise, <c>false</c>.
        /// </value>
        public override HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
            set
            {
                if( _httpClient != value )
                {
                    _httpClient = value;
                    OnPropertyChanged( nameof( HttpClient ) );
                }
            }
        }

        /// <summary>
        /// The format to return the embeddings in. Can be either float or base64.
        /// </summary>
        /// <value>
        /// The encoding format.
        /// </value>
        [ JsonPropertyName( "encoding_format" ) ]
        public string EncodingFormat
        {
            get
            {
                return _encodingFormat;
            }
            set
            {
                if( _encodingFormat != value )
                {
                    _encodingFormat = value;
                    OnPropertyChanged( nameof( EncodingFormat ) );
                }
            }
        }

        /// <summary>
        /// Input text to embed, encoded as a string or array of tokens.
        /// To embed multiple inputs in a single request, pass an array
        /// of strings or array of token arrays. The input must not exceed
        /// the max input tokens for the model
        /// (8192 tokens for text-embedding-ada-002), cannot be an empty string,
        /// and any array must be 2048 dimensions or less.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        [ JsonPropertyName( "input" ) ]
        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                if( _input != value )
                {
                    _input = value;
                    OnPropertyChanged( nameof( Input ) );
                }
            }
        }

        /// <summary>
        /// The number of dimensions the resulting output embeddings should have.
        /// Only supported in text-embedding-3 and later models.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        [ JsonPropertyName( "dimensions" ) ]
        public int Dimensions
        {
            get
            {
                return _dimensions;
            }
            set
            {
                if( _dimensions != value )
                {
                    _dimensions = value;
                    OnPropertyChanged( nameof( Dimensions ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// THe number 'n' of responses generatred.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [ JsonPropertyName( "n" ) ]
        public override int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if( _number != value )
                {
                    _number = value;
                    OnPropertyChanged( nameof( Number ) );
                }
            }
        }

        /// <summary>
        /// Gets the chat model.
        /// </summary>
        /// <value>
        /// The chat model.
        /// </value>
        /// <inheritdoc />
        [ JsonPropertyName( "model" ) ]
        public override string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if( _model != value )
                {
                    _model = value;
                    OnPropertyChanged( nameof( Model ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                if( _filePath != value )
                {
                    _filePath = value;
                    OnPropertyChanged( nameof( FilePath ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="T:Badger.GptConfig" /> is store.
        /// </summary>
        /// <value>
        ///   <c>true</c> if store; otherwise, <c>false</c>.
        /// </value>
        [ JsonPropertyName( "store" ) ]
        public override bool Store
        {
            get
            {
                return _store;
            }
            set
            {
                if( _store != value )
                {
                    _store = value;
                    OnPropertyChanged( nameof( Store ) );
                }
            }
        }

        /// <summary>
        /// Generates the query embedding asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<float[ ]> GetQueryAsync( string query )
        {
            try
            {
                ThrowIf.Empty( query, nameof( query ) );
                _prompt = query;
                _httpClient = new HttpClient( );
                _httpClient.Timeout = new TimeSpan( 0, 0, 3 );
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue( "Bearer", _header.ApiKey );

                var _file = new EmbeddingPayload( )
                {
                    Model = "text-embedding-ada-002",
                    Input = _prompt
                };

                var _message = _file.Serialize( );
                var _payload = new StringContent( _message, Encoding.UTF8, "application/json" );
                var _request = await _httpClient.PostAsync( _endPoint, _payload );
                _request.EnsureSuccessStatusCode( );
                var _response = await _request.Content.ReadAsStringAsync( );
                return ExtractContent( _response );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( float[ ] );
            }
        }

        /// <summary>
        /// Extracts the embedding.
        /// </summary>
        /// <param name="response">The json response.</param>
        /// <returns></returns>
        private protected new float[ ] ExtractContent( string response )
        {
            using var _document = JsonDocument.Parse( response );
            var _embedding = _document.RootElement
                .GetProperty( "data" )[ 0 ]
                .GetProperty( "embedding" );

            var _embeddingList = new List<float>( );
            foreach( var _value in _embedding.EnumerateArray( ) )
            {
                _embeddingList.Add( _value.GetSingle( ) );
            }

            return _embeddingList.ToArray( );
        }
    }
}