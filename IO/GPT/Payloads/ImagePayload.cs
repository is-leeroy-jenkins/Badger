// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-31-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-31-2025
// ******************************************************************************************
// <copyright file="ImagePayload.cs" company="Terry D. Eppler">
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
//   ImagePayload.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Properties;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public class ImagePayload : GptPayload
    {
        /// <summary>
        /// The style
        /// </summary>
        private protected string _style;

        /// <summary>
        /// The quality
        /// </summary>
        private protected string _quality;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagePayload"/> class.
        /// </summary>
        /// <inheritdoc />
        public ImagePayload( )
            : base( )
        {
            _model = "dall-e-3";
            _endPoint = GptEndPoint.ImageGeneration;
            _store = false;
            _stream = true;
            _number = 1;
            _temperature = 0.08;
            _topPercent = 0.09;
            _frequencyPenalty = 0.00;
            _presencePenalty = 0.00;
            _maximumTokens = 2048;
            _size = "1024X1024";
            _style = "standard";
            _quality = "hd";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagePayload"/> class.
        /// </summary>
        /// <param name="userPrompt"></param>
        /// <param name="frequency">The frequency penalty.</param>
        /// <param name="presence">The presence penalty.</param>
        /// <param name="temperature">The temperature.</param>
        /// <param name="topPercent">The top percent.</param>
        /// <param name="maxTokens">The maximum tokens.</param>
        /// <param name="store">if set to <c>true</c> [store].</param>
        /// <param name="stream">if set to <c>true</c> [stream].</param>
        /// <inheritdoc />
        public ImagePayload( string userPrompt, double frequency = 0.00, double presence = 0.00,
            double temperature = 0.08, double topPercent = 0.09, int maxTokens = 2048,
            bool store = false, bool stream = true )
            : this( )
        {
            _prompt = userPrompt;
            _temperature = temperature;
            _maximumTokens = maxTokens;
            _frequencyPenalty = frequency;
            _presencePenalty = presence;
            _store = store;
            _stream = stream;
            _topPercent = topPercent;
            _stop = "['#', ';']";
            _messages = new List<IGptMessage>( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Badger.ImagePayload" /> class.
        /// </summary>
        /// <param name="userPrompt">The user prompt.</param>
        /// <param name="config">The configuration.</param>
        public ImagePayload( string userPrompt, GptOptions config )
            : this( )
        {
            _prompt = userPrompt;
            _temperature = config.Temperature;
            _maximumTokens = config.MaximumTokens;
            _frequencyPenalty = config.FrequencyPenalty;
            _presencePenalty = config.PresencePenalty;
            _store = config.Store;
            _stream = config.Stream;
            _topPercent = config.TopPercent;
            _stop = "['#', ';']";
            _messages = new List<IGptMessage>( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>
        /// The size of the image.
        /// </value>
        [ JsonPropertyName( "size" ) ]
        public override string Size
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
        /// The style of the generated images. Must be one of vivid or natural.
        /// Vivid causes the model to lean towards generating hyper-real and
        /// dramatic images. Natural causes the model to produce more natural,
        /// less hyper-real looking images. This param is only supported for dall-e-3.
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

        /// <inheritdoc />
        /// <summary>
        /// Serializes the specified prompt.
        /// </summary>
        /// <returns>
        /// </returns>
        public override string Serialize( )
        {
            try
            {
                var _options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = false,
                    WriteIndented = true,
                    AllowTrailingCommas = false,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower,
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                    DefaultIgnoreCondition = JsonIgnoreCondition.Always,
                    IncludeFields = false
                };

                var _text = JsonSerializer.Serialize( this, _options );
                return !string.IsNullOrEmpty( _text )
                    ? _text
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }
    }
}