// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-04-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-04-2025
// ******************************************************************************************
// <copyright file="AssistantRequest.cs" company="Terry D. Eppler">
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
//   AssistantRequest.cs
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

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "PossibleUnintendedReferenceComparison" ) ]
    public class AssistantRequest : TextRequest
    {
        /// <summary>
        /// The tools
        /// </summary>
        private protected IList<string> _tools;

        /// <summary>
        /// Developer-defined tags and values used for filtering completions
        /// </summary>
        private protected IDictionary<string, object> _metaData;

        /// <summary>
        /// The reasoning effort
        /// </summary>
        private protected string _reasoningEffort;

        /// <summary>
        /// The system prompt
        /// </summary>
        private protected string _instructions;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CompletionRequest" /> class.
        /// </summary>
        public AssistantRequest( )
            : base( )
        {
            _entry = new object( );
            _header = new GptHeader( );
            _endPoint = GptEndPoint.Assistants;
            _model = "gpt-4o";
            _stop = "['#', ';']";
            _tools = new List<string>( );
            _seed = 1;
            _modalities = "['text', 'audio']";
            _responseFormat = "auto";
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CompletionRequest" /> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="system">The system.</param>
        /// <param name = "config" > </param>
        public AssistantRequest( string user, string system, GptOptions config )
            : base( )
        {
            _entry = new object( );
            _header = new GptHeader( );
            _endPoint = GptEndPoint.Assistants;
            _model = config.Model;
            _store = config.Store;
            _stream = config.Stream;
            _number = config.Number;
            _presencePenalty = config.PresencePenalty;
            _frequencyPenalty = config.FrequencyPenalty;
            _temperature = config.Temperature;
            _topPercent = config.TopPercent;
            _maximumTokens = config.MaximumTokens;
            _stop = config.Stop;
            _modalities = config.Modalities;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CompletionRequest" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public AssistantRequest( AssistantRequest request )
            : base( )
        {
            _entry = new object( );
            _header = request.Header;
            _endPoint = request.EndPoint;
            _model = request.Model;
            _store = request.Store;
            _stream = request.Stream;
            _number = request.Number;
            _presencePenalty = request.PresencePenalty;
            _frequencyPenalty = request.FrequencyPenalty;
            _temperature = request.Temperature;
            _topPercent = request.TopPercent;
            _maximumTokens = request.MaximumTokens;
            _stop = request.Stop;
            _modalities = request.Modalities;
        }

        /// <summary>
        /// Decontructs the specified header.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="store">if set to <c>true</c> [store].</param>
        /// <param name="stream">if set to <c>true</c> [stream].</param>
        /// <param name="model">The model.</param>
        /// <param name="number">The number.</param>
        /// <param name="presence">The presence.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="temperature">The temperature.</param>
        /// <param name="topPercent">The top percent.</param>
        /// <param name="tokens">The tokens.</param>
        public void Decontruct( out GptHeader header, out string endPoint, out bool store,
            out bool stream, out string model, out int number,
            out double presence, out double frequency, out double temperature,
            out double topPercent, out int tokens )
        {
            header = _header;
            endPoint = _endPoint;
            store = _store;
            stream = _stream;
            model = _model;
            number = _number;
            presence = _presencePenalty;
            frequency = _frequencyPenalty;
            temperature = Temperature;
            topPercent = TopPercent;
            tokens = _maximumTokens;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>
        /// The end point.
        /// </value>
        [ JsonPropertyName( "endpoint" ) ]
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
        /// Gets or sets the modalities.
        /// </summary>
        /// <value>
        /// The modalities.
        /// </value>
        [ JsonPropertyName( "modalities" ) ]
        public override string Modalities
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
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>
        /// The instructions.
        /// </value>
        [ JsonPropertyName( "instructions" ) ]
        public string Instructions
        {
            get
            {
                return _instructions;
            }
            set
            {
                if( _instructions != value )
                {
                    _instructions = value;
                    OnPropertyChanged( nameof( Instructions ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the user prompt.
        /// </summary>
        /// <value>
        /// The user prompt.
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
        /// Gets or sets the reasoning effort.
        /// </summary>
        /// <value>
        /// The reasoning effort.
        /// </value>
        [ JsonPropertyName( "reasoning_effort" ) ]
        public string ReasoningEffort
        {
            get
            {
                return _reasoningEffort;
            }
            set
            {
                if( _reasoningEffort != value )
                {
                    _reasoningEffort = value;
                    OnPropertyChanged( nameof( ReasoningEffort ) );
                }
            }
        }

        /// <summary>
        /// A list of tool enabled on the assistant.
        /// There can be a maximum of 128 tools per assistant.
        /// Tools can be of types code_interpreter, file_search, or function.
        /// </summary>
        /// <value>
        /// The tools.
        /// </value>
        [ JsonPropertyName( "tools" ) ]
        public IList<string> Tools
        {
            get
            {
                return _tools;
            }
            set
            {
                if( _tools != value )
                {
                    _tools = value;
                    OnPropertyChanged( nameof( Tools ) );
                }
            }
        }

        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object.
        /// This can be useful for storing additional information about the
        /// object in a structured format. Keys can be a maximum of 64 characters
        /// long and values can be a maximum of 512 characters long.
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
        /// <returns></returns>
        public override IDictionary<string, object> GetData( )
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
                _data.Add( "response_format", _responseFormat );
                _data.Add( "stop", _stop );
                _data.Add( "modalities", _modalities );
                return _data?.Any( ) == true
                    ? _data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string,object> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the chat response asynchronous.
        /// </summary>
        /// <returns></returns>
        public override async Task<string> GetResponseAsync( string prompt )
        {
            try
            {
                ThrowIf.Empty( prompt, nameof( prompt ) );
                _prompt = prompt;
                _httpClient = new HttpClient( );
                _httpClient.DefaultRequestHeaders.Add( "Authorization",
                    $"Bearer {_header.ApiKey}" );

                var _package = new AssistantPayload( )
                {
                    Model = _model,
                    Temperature = _temperature,
                    Store = _store,
                    Stream = _stream,
                    Stop = _stop,
                    TopPercent = _topPercent,
                    FrequencyPenalty = _frequencyPenalty,
                    PresencePenalty = _presencePenalty,
                    Prompt = _prompt
                };

                var _serial = _package.Serialize( );
                var _payload = new StringContent( _serial, Encoding.UTF8, _header.ContentType );
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

        /// <inheritdoc />
        /// <summary>
        /// Extracts the message from response.
        /// </summary>
        /// <param name="response">The json response.</param>
        /// <returns></returns>
        private protected override string ExtractContent( string response )
        {
            try
            {
                using var _document = JsonDocument.Parse( response );
                var _root = _document.RootElement;
                if( _model.Contains( "gpt-3.5-turbo" ) )
                {
                    var _choices = _root.GetProperty( "choices" );
                    if( _choices.ValueKind == JsonValueKind.Array
                        && _choices.GetArrayLength( ) > 0 )
                    {
                        var _message = _choices[ 0 ].GetProperty( "message" );
                        var _count = _message.GetProperty( "content" );
                        var _text = _count.GetString( );
                        return !string.IsNullOrEmpty( _text )
                            ? _text
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
                _httpClient?.Dispose( );
                return string.Empty;
            }
        }
    }
}