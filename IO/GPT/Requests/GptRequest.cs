// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-31-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-31-2025
// ******************************************************************************************
// <copyright file="GptRequest.cs" company="Terry D. Eppler">
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
//   GptRequest.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Properties;

    /// <inheritdoc />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "PossibleNullReferenceException" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "PossibleUnintendedReferenceComparison" ) ]
    public class GptRequest : GptRequestBase
    {
        /// <summary>
        /// The stop sequence
        /// </summary>
        private protected string _stop;

        /// <summary>
        /// The modalities
        /// </summary>
        private protected string _modalities;

        /// <summary>
        /// The response format
        /// </summary>
        private protected string _responseFormat;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.GptRequest" /> class.
        /// </summary>
        public GptRequest( )
        {
            _messages = new List<IGptMessage>( );
            _header = new GptHeader( );
            _apiKey = _header.ApiKey;
            _systemPrompt = App.Instructions;
            _store = false;
            _stream = true;
            _presencePenalty = 0.00;
            _frequencyPenalty = 0.00;
            _topPercent = 0.09;
            _temperature = 0.08;
            _maximumTokens = 2048;
            _number = 1;
            _stop = "['#', ';']";
            _modalities = "['text','audio']";
            _responseFormat = "text";
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.GptRequest" /> class.
        /// </summary>
        /// <param name = "user" > </param>
        /// <param name = "options" > </param>
        public GptRequest( string user, IGptParameter options )
            : this( )
        {
            _header = new GptHeader( );
            _userPrompt = user;
            _messages.Add( new SystemMessage( _systemPrompt ) );
            _messages.Add( new UserMessage( user ) );
            _apiKey = _header.ApiKey;
            _number = options.Number;
            _store = options.Store;
            _stream = options.Stream;
            _frequencyPenalty = options.FrequencyPenalty;
            _presencePenalty = options.PresencePenalty;
            _topPercent = options.TopPercent;
            _temperature = options.Temperature;
            _maximumTokens = options.MaximumTokens;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.GptRequest" /> class.
        /// </summary>
        /// <param name="request">The GPT request.</param>
        public GptRequest( GptRequest request )
            : this( )
        {
            _apiKey = request.ApiKey;
            _number = request.Number;
            _stream = request.Stream;
            _store = request.Store;
            _frequencyPenalty = request.FrequencyPenalty;
            _presencePenalty = request.PresencePenalty;
            _topPercent = request.TopPercent;
            _temperature = request.Temperature;
            _maximumTokens = request.MaximumTokens;
        }

        /// <summary>
        /// Deconstructs the specified user identifier.
        /// </summary>
        /// <param name = "header" > </param>
        /// <param name = "endPoint" > </param>
        /// <param name = "user" > </param>
        /// <param name = "system" > </param>
        /// <param name = "store" > </param>
        /// <param name = "stream" > </param>
        /// <param name = "model" > </param>
        /// <param name="number">The user identifier.</param>
        /// <param name="presence">The presence.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="temperature">The temperature.</param>
        /// <param name = "topPercent" > </param>
        /// <param name="tokens">The maximum tokens.</param>
        public void Deconstruct( out GptHeader header, out string endPoint, out string user,
            out string system, out bool store, out bool stream,
            out string model, out int number, out double presence,
            out double frequency, out double temperature, out double topPercent,
            out int tokens )
        {
            header = _header;
            endPoint = _endPoint;
            store = _store;
            stream = _stream;
            model = _model;
            number = _number;
            presence = _presencePenalty;
            frequency = _frequencyPenalty;
            temperature = _temperature;
            topPercent = _topPercent;
            tokens = _maximumTokens;
            user = _userPrompt;
            system = _systemPrompt;
        }

        /// <summary>
        /// Gets or sets the stop sequences.
        /// </summary>
        /// <value>
        /// The stop sequences.
        /// </value>
        [ JsonPropertyName( "stop" ) ]
        public virtual string Stop
        {
            get
            {
                return _stop;
            }
            set
            {
                if( _stop != value )
                {
                    _stop = value;
                    OnPropertyChanged( nameof( Stop ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the modalities.
        /// </summary>
        /// <value>
        /// The modalities.
        /// </value>
        [JsonPropertyName("response_format")]
        public virtual string ResponseFormat
        {
            get
            {
                return _responseFormat;
            }
            set
            {
                if(_responseFormat != value)
                {
                    _responseFormat = value;
                    OnPropertyChanged(nameof(ResponseFormat));
                }
            }
        }

        /// <summary>
        /// Gets or sets the modalities.
        /// </summary>
        /// <value>
        /// The modalities.
        /// </value>
        [JsonPropertyName( "modalities" ) ]
        public virtual string Modalities
        {
            get
            {
                return _modalities;
            }
            set
            {
                if( _modalities != value )
                {
                    _modalities = value;
                    OnPropertyChanged( nameof( Modalities ) );
                }
            }
        }

        /// <summary>
        /// Generates the asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Net.Http.HttpRequestException">
        /// Error: {_response.StatusCode}, {_error}
        /// </exception>
        public virtual async Task<string> GetResponseAsync( string prompt )
        {
            try
            {
                ThrowIf.Empty( prompt, nameof( prompt ) );
                _prompt = prompt;
                _httpClient = new HttpClient( );
                _httpClient.Timeout = new TimeSpan( 0, 0, 3 );
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue( "Bearer", _header.ApiKey );

                var _message = JsonConvert.SerializeObject( _prompt );
                var _payload = new StringContent( _message, Encoding.UTF8, _header.ContentType );
                var _request = await _httpClient.PostAsync( _endPoint, _payload );
                _request.EnsureSuccessStatusCode( );
                var _response = await _request.Content.ReadAsStringAsync( );
                var _content = ExtractContent( _response );
                return !string.IsNullOrEmpty( _content )
                    ? _content
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                _httpClient?.Dispose( );
                return string.Empty;
            }
        }

        /// <summary>
        /// Extracts the content of the response.
        /// </summary>
        /// <param name="response">
        /// The json response.
        /// </param>
        /// <returns></returns>
        private protected virtual string ExtractContent( string response )
        {
            try
            {
                ThrowIf.Empty( response, nameof( response ) );
                using var _document = JsonDocument.Parse( response );
                var _root = _document.RootElement;
                if( _model.Contains( "gpt-3.5-turbo" ) )
                {
                    var _choices = _root.GetProperty( "choices" );
                    if( _choices.ValueKind == JsonValueKind.Array
                        && _choices.GetArrayLength( ) > 0 )
                    {
                        var _msg = _choices[ 0 ].GetProperty( "message" );
                        var _cnt = _msg.GetProperty( "content" );
                        var _txt = _cnt.GetString( );
                        return !string.IsNullOrEmpty( _txt )
                            ? _txt
                            : string.Empty;
                    }
                    else
                    {
                        var _message = _choices[ 0 ].GetProperty( "message" );
                        var _text = _message.GetString( );
                        return !string.IsNullOrEmpty( _text )
                            ? _text
                            : string.Empty;
                    }
                }
                else
                {
                    var _choice = _root.GetProperty( "choices" )[ 0 ];
                    var _property = _choice.GetProperty( "text" );
                    var _text = _property.GetString( );
                    return !string.IsNullOrEmpty( _text )
                        ? _text
                        : string.Empty;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetData( )
        {
            try
            {
                _data.Add( "model", _model );
                _data.Add( "n", _number.ToString( ) );
                _data.Add( "max_completion_tokens", _maximumTokens.ToString( ) );
                _data.Add( "store", _store.ToString( ) );
                _data.Add( "stream", _stream.ToString( ) );
                _data.Add( "temperature", _temperature.ToString( ) );
                _data.Add( "frequency_penalty", _frequencyPenalty.ToString( ) );
                _data.Add( "presence_penalty", _presencePenalty.ToString( ) );
                _data.Add( "top_p", _topPercent.ToString( ) );
                _data.Add( "stop", _stop );
                _data.Add( "modalities", _modalities );
                return _data;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c>
        /// to release both managed
        /// and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        public virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                _httpClient?.Dispose( );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks
        /// associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
    }
}