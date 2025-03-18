// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-31-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-31-2025
// ******************************************************************************************
// <copyright file="VectorRequest.cs" company="Terry D. Eppler">
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
//   VectorRequest.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Properties;
    using JsonSerializer = System.Text.Json.JsonSerializer;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.GptRequest" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "PossibleUnintendedReferenceComparison" ) ]
    public class VectorRequest : GptRequest
    {
        /// <summary>
        /// The file path
        /// </summary>
        private protected string _filePath;

        /// <summary>
        /// The vector store identifier
        /// </summary>
        private protected string _vectorStoreId;

        /// <summary>
        /// The file ids
        /// </summary>
        private protected IList<string> _fileIds;

        /// <summary>
        /// The name
        /// </summary>
        private protected string _name;

        /// <summary>
        /// The limit
        /// </summary>
        private protected int _limit;

        /// <summary>
        /// The before
        /// </summary>
        private protected string _before;

        /// <summary>
        /// The after
        /// </summary>
        private protected string _after;

        /// <summary>
        /// The order
        /// </summary>
        private protected string _order;

        /// <summary>
        /// The meta data
        /// </summary>
        private protected IDictionary<string, object> _metaData;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="VectorRequest"/> class.
        /// </summary>
        /// <inheritdoc />
        public VectorRequest( )
            : base( )
        {
            _entry = new object( );
            _header = new GptHeader( );
            _model = "gpt-4o-mini";
            _endPoint = GptEndPoint.VectorStores;
            _messages.Add(new SystemMessage(_systemPrompt));
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
        /// Gets or sets the file ids.
        /// </summary>
        /// <value>
        /// The file ids.
        /// </value>
        [ JsonPropertyName( "file_ids" ) ]
        public IList<string> FileIds
        {
            get
            {
                return _fileIds;
            }
            set
            {
                if( _fileIds != value )
                {
                    _fileIds = value;
                    OnPropertyChanged( nameof( FileIds ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the vector store identifier.
        /// </summary>
        /// <value>
        /// The vector store identifier.
        /// </value>
        [ JsonPropertyName( "vector_store_id" ) ]
        public string VectorStoreId
        {
            get
            {
                return _vectorStoreId;
            }
            set
            {
                if( _vectorStoreId != value )
                {
                    _vectorStoreId = value;
                    OnPropertyChanged( nameof( VectorStoreId ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the before.
        /// </summary>
        /// <value>
        /// The before.
        /// </value>
        [ JsonPropertyName( "before" ) ]
        public string Before
        {
            get
            {
                return _before;
            }
            set
            {
                if( _before != value )
                {
                    _before = value;
                    OnPropertyChanged( nameof( Before ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the after.
        /// </summary>
        /// <value>
        /// The after.
        /// </value>
        [ JsonPropertyName( "after" ) ]
        public string After
        {
            get
            {
                return _after;
            }
            set
            {
                if( _after != value )
                {
                    _after = value;
                    OnPropertyChanged( nameof( After ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [ JsonPropertyName( "order" ) ]
        public string Order
        {
            get
            {
                return _order;
            }
            set
            {
                if( _order != value )
                {
                    _order = value;
                    OnPropertyChanged( nameof( Order ) );
                }
            }
        }

        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object.
        /// This can be useful for storing additional information about the
        /// object in a structured format. Keys can be a maximum of 64 characters
        /// long and values can be a maximum of 512 characters long
        /// </summary>
        /// <value>
        /// The meta data.
        /// </value>
        [ JsonPropertyName( "meta_data" ) ]
        public IDictionary<string, object> MetaData
        {
            get
            {
                return _metaData;
            }
            set
            {
                if( _metaData != value )
                {
                    _metaData = value;
                    OnPropertyChanged( nameof( MetaData ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IDictionary<string, object> GetData( )
        {
            try
            {
                _data.Add( "model", _model );
                _data.Add( "endpoint", _endPoint );
                _data.Add( "n", _number.ToString(  ) );
                _data.Add( "max_completionTokens", _maximumTokens.ToString() );
                _data.Add( "store", _store.ToString( ) );
                _data.Add( "stream", _stream.ToString() );
                _data.Add( "temperature", _temperature.ToString() );
                _data.Add( "frequency_penalty", _frequencyPenalty.ToString( ) );
                _data.Add( "presence_penalty", _presencePenalty.ToString() );
                _data.Add( "top_p", _topPercent.ToString() );
                _data.Add( "response_format", _responseFormat );
                _data.Add( "limit", _limit.ToString( ) );
                if( !string.IsNullOrEmpty( _filePath ) )
                {
                    _data.Add( "filepath", _filePath );
                }

                if( !string.IsNullOrEmpty( _name ) )
                {
                    _data.Add( "name", _name );
                }

                if( _fileIds?.Any( ) == true )
                {
                    _data.Add( "file_ids", _fileIds.ToString( ) );
                }

                if( _metaData?.Any( ) == true )
                {
                    _data.Add( "metadata", _metaData.ToString( ) );
                }

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

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
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
        /// Uploads the training file asynchronous.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public async Task<string> UploadFileByIdAsync( string filePath )
        {
            _httpClient = new HttpClient( );
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue( "Bearer", OpenAI.BubbaKey );

            var _fileContent = new ByteArrayContent( File.ReadAllBytes( filePath ) );
            var _formData = new MultipartFormDataContent
            {
                {
                    _fileContent, "file", Path.GetFileName( filePath )
                },
                {
                    new StringContent( "fine-tune" ), "purpose"
                }
            };

            var _response = await _httpClient.PostAsync( _endPoint, _formData );
            _response.EnsureSuccessStatusCode( );
            var _responseContent = await _response.Content.ReadAsStringAsync( );
            var _document = JsonDocument.Parse( _responseContent );
            return _document.RootElement.GetProperty( "id" ).GetString( );
        }

        /// <summary>
        /// Calculates the cosine similarity.
        /// </summary>
        /// <param name="vectorA">The vector a.</param>
        /// <param name="vectorB">The vector b.</param>
        /// <returns></returns>
        public float CalculateCosineSimilarity( float[ ] vectorA, float[ ] vectorB )
        {
            float _dotProduct = 0;
            float _magnitudeA = 0;
            float _magnitudeB = 0;
            for( var _i = 0; _i < vectorA.Length; _i++ )
            {
                _dotProduct += vectorA[ _i ] * vectorB[ _i ];
                _magnitudeA += vectorA[ _i ] * vectorA[ _i ];
                _magnitudeB += vectorB[ _i ] * vectorB[ _i ];
            }

            return _dotProduct / ( float )( Math.Sqrt( _magnitudeA ) * Math.Sqrt( _magnitudeB ) );
        }

        /// <summary>
        /// Loads the vector store.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        public List<(string Text, float[ ] Embedding)> LoadVectorStore( string connectionString )
        {
            var _results = new List<(string Text, float[ ] Embedding)>( );
            using var _connection = new SQLiteConnection( connectionString );
            _connection.Open( );
            var _command = new SQLiteCommand( "SELECT Text, Embedding FROM Appropriations",
                _connection );

            using var _reader = _command.ExecuteReader( );
            while( _reader.Read( ) )
            {
                var _text = _reader.GetString( 0 );
                var _embeddingString = _reader.GetString( 1 );
                var _embedding = JsonSerializer.Deserialize<float[ ]>( _embeddingString );
                _results.Add( ( _text, _embedding ) );
            }

            return _results;
        }
    }
}