// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-31-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-31-2025
// ******************************************************************************************
// <copyright file="FineTuningOptions.cs" company="Terry D. Eppler">
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
//   FineTuningOptions.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Properties;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "InternalOrPrivateMemberNotDocumented" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public class FineTuningOptions : GptOptions
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

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FineTuningParameter" /> class.
        /// </summary>
        public FineTuningOptions( )
            : base( )
        {
            _endPoint = GptEndPoint.FineTuning;
            _store = false;
            _stream = true;
            _number = 1;
            _temperature = 0.08;
            _topPercent = 0.09;
            _frequencyPenalty = 0.00;
            _presencePenalty = 0.00;
            _maximumTokens = 2048;
            _stop = "['#', ';']";
            _method = new Dictionary<string, object>( );
            _logitBias = new Dictionary<string, object>( );
            _echo = true;
            _logProbs = true;
            _bestOf = 3;
        }

        /// <summary>
        /// Gets or sets the log probs.
        /// </summary>
        /// <value>
        /// The log probs.
        /// </value>
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
                _data.Add( "number", _number );
                _data.Add( "max_completion_tokens", _maximumTokens );
                _data.Add( "stop", _stop );
                _data.Add( "store", _store );
                _data.Add( "stream", _stream );
                _data.Add( "temperature", _temperature );
                _data.Add( "frequency_penalty", _frequencyPenalty );
                _data.Add( "presence_penalty", _presencePenalty );
                _data.Add( "top_p", _topPercent );
                _method.Add( "type", "supervised" );
                _data.Add( "method", _method );
                _data.Add( "logprobs", _logProbs );
                _data.Add( "echo", _echo );
                _data.Add( "best_of", _bestOf );
                _data.Add( "stop", _stop );
                if( !string.IsNullOrEmpty( _trainingFile ) )
                {
                    _data.Add( "filepath", _trainingFile );
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
    }
}