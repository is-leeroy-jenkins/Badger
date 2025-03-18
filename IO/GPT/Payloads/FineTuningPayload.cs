// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-31-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-31-2025
// ******************************************************************************************
// <copyright file="FineTuningPayload.cs" company="Terry D. Eppler">
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
//   FineTuningPayload.cs
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
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionRecursiveOnAllPaths" ) ]
    [ SuppressMessage( "ReSharper", "PossibleUnintendedReferenceComparison" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public class FineTuningPayload : GptPayload
    {
        /// <summary>
        /// The log probs
        /// </summary>
        private protected bool _logProbs;

        /// <summary>
        /// The echo
        /// </summary>
        private protected bool _echo;

        /// <summary>
        /// The best of
        /// </summary>
        private protected int _bestOf;

        /// <summary>
        /// The logit bias
        /// </summary>
        private protected IDictionary<string, object> _logitBias;

        /// <summary>
        /// The file path
        /// </summary>
        private protected string _trainingFile;

        /// <summary>
        /// The suffix
        /// </summary>
        private protected string _suffix;

        /// <summary>
        /// The seed
        /// </summary>
        private protected int _seed;

        /// <summary>
        /// The validation file
        /// </summary>
        private protected string _validationFile;

        /// <summary>
        /// The method
        /// </summary>
        private protected IDictionary<string, object> _method;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FineTuningPayload"/> class.
        /// </summary>
        /// <inheritdoc />
        public FineTuningPayload( )
            : base( )
        {
            _model = "gpt-4o-mini";
            _endPoint = GptEndPoint.FineTuning;
            _store = false;
            _stream = true;
            _number = 1;
            _temperature = 0.08;
            _topPercent = 0.09;
            _frequencyPenalty = 0.00;
            _presencePenalty = 0.00;
            _maximumTokens = 2048;
            _method = new Dictionary<string, object>( );
            _logitBias = new Dictionary<string, object>( );
            _echo = true;
            _logProbs = true;
            _bestOf = 3;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Badger.FineTuningPayload" /> class.
        /// </summary>
        /// <param name="userPrompt"></param>
        /// <param name="frequency">The frequency penalty.</param>
        /// <param name="presence">The presence penalty.</param>
        /// <param name="temperature">The temperature.</param>
        /// <param name="topPercent">The top percent.</param>
        /// <param name="maxTokens">The maximum tokens.</param>
        /// <param name="store">if set to <c>true</c> [store].</param>
        /// <param name="stream">if set to <c>true</c> [stream].</param>
        public FineTuningPayload( string userPrompt, double frequency = 0.00,
            double presence = 0.00, double temperature = 0.08, double topPercent = 0.09,
            int maxTokens = 2048, bool store = false, bool stream = true )
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
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Badger.FineTuningPayload" /> class.
        /// </summary>
        /// <param name="userPrompt">The user prompt.</param>
        /// <param name="config">The configuration.</param>
        public FineTuningPayload( string userPrompt, GptOptions config )
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
            _stop = config.Stop;
        }

        /// <summary>
        /// Gets or sets the log probs.
        /// </summary>
        /// <value>
        /// The log probs.
        /// </value>
        [ JsonPropertyName( "logprobs" ) ]
        public bool LogProbs
        {
            get
            {
                return _logProbs;
            }
            set
            {
                if( _logProbs != value )
                {
                    _logProbs = value;
                    OnPropertyChanged( nameof( LogProbs ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="FineTuningOptions"/> is echo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if echo; otherwise, <c>false</c>.
        /// </value>
        [ JsonPropertyName( "echo" ) ]
        public bool Echo
        {
            get
            {
                return _echo;
            }
            set
            {
                if( _echo != value )
                {
                    _echo = value;
                    OnPropertyChanged( nameof( Echo ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the best of.
        /// </summary>
        /// <value>
        /// The best of.
        /// </value>
        [ JsonPropertyName( "best_of" ) ]
        public int BestOf
        {
            get
            {
                return _bestOf;
            }
            set
            {
                if( _bestOf != value )
                {
                    _bestOf = value;
                    OnPropertyChanged( nameof( BestOf ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the logit bias.
        /// </summary>
        /// <value>
        /// The logit bias.
        /// </value>
        [ JsonPropertyName( "logit_bias" ) ]
        public IDictionary<string, object> LogitBias
        {
            get
            {
                return _logitBias;
            }
            set
            {
                if( _logitBias != value )
                {
                    _logitBias = value;
                    OnPropertyChanged( nameof( LogitBias ) );
                }
            }
        }

        /// <summary>
        /// A string of up to 64 characters that will be added to your fine-tuned model name.
        /// </summary>
        /// <value>
        /// The suffix.
        /// </value>
        [ JsonPropertyName( "suffix" ) ]
        public string Suffix
        {
            get
            {
                return _suffix;
            }
            set
            {
                if( _suffix != value )
                {
                    _suffix = value;
                    OnPropertyChanged( nameof( Suffix ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the seed.
        /// </summary>
        /// <value>
        /// The seed.
        /// </value>
        [ JsonPropertyName( "seed" ) ]
        public int Seed
        {
            get
            {
                return _seed;
            }
            set
            {
                if( _seed != value )
                {
                    _seed = value;
                    OnPropertyChanged( nameof( Seed ) );
                }
            }
        }

        /// <summary>
        /// The ID of an uploaded file that contains training data.
        /// Your dataset must be formatted as a JSONL file.
        /// Additionally, you must upload your file with the purpose fine-tune.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        [ JsonPropertyName( "training_file" ) ]
        public string TrainingFile
        {
            get
            {
                return _trainingFile;
            }
            set
            {
                if( _trainingFile != value )
                {
                    _trainingFile = value;
                    OnPropertyChanged( nameof( TrainingFile ) );
                }
            }
        }

        /// <summary>
        /// The ID of an uploaded file that contains validation data.
        /// Your dataset must be formatted as a JSONL file.
        /// Additionally, you must upload your file with the purpose fine-tune.
        /// </summary>
        /// <value>
        /// The validation file.
        /// </value>
        [ JsonPropertyName( "validation_file" ) ]
        public string ValidationFile
        {
            get
            {
                return _validationFile;
            }
            set
            {
                if( _validationFile != value )
                {
                    _validationFile = value;
                    OnPropertyChanged( nameof( ValidationFile ) );
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