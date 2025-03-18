// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-18-2025
// ******************************************************************************************
// <copyright file="ImageRequest.cs" company="Terry D. Eppler">
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
//   ImageRequest.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Properties;
    using JsonSerializer = System.Text.Json.JsonSerializer;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    public class ImageRequest : GptRequest
    {
        /// <summary>
        /// The image size
        /// </summary>
        private protected string _size;

        /// <summary>
        /// The quality
        /// </summary>
        private protected string _quality;

        /// <summary>
        /// The style
        /// </summary>
        private protected string _style;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ImageRequest" /> class.
        /// </summary>
        public ImageRequest( )
            : base( )
        {
            _entry = new object( );
            _header = new GptHeader( );
            _endPoint = GptEndPoint.ImageGeneration;
            _messages.Add( new SystemMessage( _systemPrompt ) );
            _model = "dall-e-3";
            _style = "natural";
            _quality = "hd";
            _size = "1024X1024";
            _number = 1;
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
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>
        /// The size of the image.
        /// </value>
        [ JsonPropertyName( "size" ) ]
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                if( _size != value )
                {
                    _size = value;
                    OnPropertyChanged( nameof( Size ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the prompt.
        /// </summary>
        /// <value>
        /// The prompt.
        /// </value>
        [ JsonPropertyName( "prompt" ) ]
        public override string Prompt
        {
            get
            {
                return _prompt;
            }
            set
            {
                if( _prompt != value )
                {
                    _prompt = value;
                    OnPropertyChanged( nameof( Prompt ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        /// <value>
        /// The quality.
        /// </value>
        [ JsonPropertyName( "quality" ) ]
        public string Quality
        {
            get
            {
                return _quality;
            }
            set
            {
                if( _quality != value )
                {
                    _quality = value;
                    OnPropertyChanged( nameof( Quality ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>
        /// The style.
        /// </value>
        [ JsonPropertyName( "style" ) ]
        public string Style
        {
            get
            {
                return _style;
            }
            set
            {
                if( _style != value )
                {
                    _style = value;
                    OnPropertyChanged( nameof( Style ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        [ JsonPropertyName( "messages" ) ]
        public override IList<IGptMessage> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                if( _messages != value )
                {
                    _messages = value;
                    OnPropertyChanged( nameof( Messages ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>
        /// The end point.
        /// </value>
        public override string EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                if( _endPoint != value )
                {
                    _endPoint = value;
                    OnPropertyChanged( nameof( EndPoint ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// THe number 'n' of responses returned by the API.
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

        /// <inheritdoc />
        /// <summary>
        /// Gets the maximum tokens.
        /// </summary>
        /// <value>
        /// The maximum tokens.
        /// </value>
        [ JsonPropertyName( "max_completion_tokens" ) ]
        public override int MaximumTokens
        {
            get
            {
                return _maximumTokens;
            }
            set
            {
                if( _maximumTokens != value )
                {
                    _maximumTokens = value;
                    OnPropertyChanged( nameof( MaximumTokens ) );
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
                _data.Add( "n", _number.ToString( ) );
                _data.Add( "max_completion_tokens", _maximumTokens.ToString( ) );
                _data.Add( "store", _store.ToString( ) );
                _data.Add( "stream", _stream.ToString( ) );
                _data.Add( "temperature", _temperature.ToString( ) );
                _data.Add( "frequency_penalty", _frequencyPenalty.ToString( ) );
                _data.Add( "presence_penalty", _presencePenalty.ToString( ) );
                _data.Add( "top_p", _topPercent.ToString( ) );
                _data.Add( "style", _style );
                _data.Add( "size", _size );
                _data.Add( "quality", _quality );
                return _data;
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
        /// Generates the images asynchronous.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns></returns>
        public async new Task<string[ ]> GetResponseAsync( string prompt )
        {
            try
            {
                ThrowIf.Empty( prompt, nameof( prompt ) );
                _prompt = prompt;
                _httpClient = new HttpClient( );
                _httpClient.Timeout = new TimeSpan( 0, 0, 3 );
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", _header.ApiKey );
                var _payload = new ImagePayload( )
                {
                    Prompt = prompt,
                    Number = _number,
                    Size = _size
                };

                var _image = JsonSerializer.Serialize( _payload );
                var _content = new StringContent( _image, Encoding.UTF8, _header.ContentType );
                var _response = await _httpClient.PostAsync( _endPoint, _content );
                _response.EnsureSuccessStatusCode( );
                var _responseData = await _response.Content.ReadAsStringAsync( );
                var _imageData = ExtractContent( _responseData );
                return _imageData?.Any( ) == true
                    ? _imageData
                    : default( string[ ] );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
        }

        /// <summary>
        /// Extracts the image urls.
        /// </summary>
        /// <param name="jsonResponse">The json response.</param>
        /// <returns></returns>
        private new string[ ] ExtractContent( string jsonResponse )
        {
            try
            {
                ThrowIf.Empty( jsonResponse, nameof( jsonResponse ) );
                using var _document = JsonDocument.Parse( jsonResponse );
                var _root = _document.RootElement.GetProperty( "data" );
                var _urls = new List<string>( );
                foreach( var _item in _root.EnumerateArray( ) )
                {
                    var _image = _item.GetProperty( "url" ).GetString( );
                    _urls.Add( _image );
                }

                var _list = _urls.ToArray( );
                return _list?.Any( ) == true
                    ? _list
                    : default( string[ ] );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
        }
    }
}