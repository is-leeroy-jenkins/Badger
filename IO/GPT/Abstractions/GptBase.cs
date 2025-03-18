// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-07-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-07-2025
// ******************************************************************************************
// <copyright file="GptBase.cs" company="Terry D. Eppler">
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
//   GptBase.cs
// </summary>

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.PropertyChangedBase" />
    /// <seealso cref="T:System.IDisposable" />
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "PossibleUnintendedReferenceComparison" ) ]
    [ SuppressMessage( "ReSharper", "ConvertIfStatementToReturnStatement" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    public abstract class GptBase : PropertyChangedBase
    {
        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The path
        /// </summary>
        private protected object _entry;

        /// <summary>
        /// A unique identifier representing your end-user
        /// </summary>
        private protected string _user;

        /// <summary>
        /// The user identifier
        /// </summary>
        private protected int _number;

        /// <summary>
        /// Whether or not to store the responses
        /// </summary>
        private protected bool _store;

        /// <summary>
        /// The stream
        /// </summary>
        private protected bool _stream;

        /// <summary>
        /// A number between -2.0 and 2.0.
        /// Positive values penalize new tokens
        /// based on whether they appear in the text so far,
        /// increasing the model's likelihood to talk about new topics.
        /// </summary>
        private protected double _presencePenalty;

        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens
        /// based on their existing frequency in the text so far,
        /// decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        private protected double _frequencyPenalty;

        /// <summary>
        /// The API key
        /// </summary>
        private protected string _apiKey;

        /// <summary>
        /// The base URL
        /// </summary>
        private protected string _endPoint;

        /// <summary>
        /// The chat model
        /// </summary>
        private protected string _model;

        /// <summary>
        /// The urls
        /// </summary>
        private protected IList<string> _endPoints;

        /// <summary>
        /// The models
        /// </summary>
        private protected IList<string> _models;

        /// <summary>
        /// A number between 0 and 2.
        /// Higher values like 0.8 will make the output more random,
        /// while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        private protected double _temperature;

        /// <summary>
        /// An alternative to sampling with temperature,
        /// called nucleus sampling, where the model considers
        /// the results of the tokens with top_p probability mass.
        /// So 0.1 means only the tokens comprising the top 10% probability
        /// mass are considered. We generally recommend altering this
        /// or temperature but not both.
        /// </summary>
        private protected double _topPercent;

        /// <summary>
        /// The maximum tokens
        /// </summary>
        private protected int _maximumTokens;

        /// <summary>
        /// The role
        /// </summary>
        private protected string _role;

        /// <summary>
        /// The prompt
        /// </summary>
        private protected string _prompt;

        /// <summary>
        /// The data
        /// </summary>
        private protected IDictionary<string, object> _data;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="GptBase"/> class.
        /// </summary>
        protected GptBase( )
        {
        }

        /// <summary>
        /// Gets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        public string ApiKey
        {
            get
            {
                return _apiKey;
            }
        }

        /// <summary>
        /// Gets or sets the prompt.
        /// </summary>
        /// <value>
        /// The prompt.
        /// </value>
        public virtual string Prompt
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
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
        /// </value>
        public bool IsBusy
        {
            get
            {
                lock( _entry )
                {
                    return _busy;
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public virtual IDictionary<string, object> Data
        {
            get
            {
                return _data;
            }
            set
            {
                if( _data != value )
                {
                    _data = value;
                    OnPropertyChanged( nameof( Data ) );
                }
            }
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private protected void Busy( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = true;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private protected void Chill( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = false;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Pads the quotes.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private protected virtual string ProcessQuotes( string input )
        {
            if( input.IndexOf( "\\" ) != -1 )
            {
                input = input.Replace( "\\", @"\\" );
            }

            if( input.IndexOf( "\n\r" ) != -1 )
            {
                input = input.Replace( "\n\r", @"\n" );
            }

            if( input.IndexOf( "\r" ) != -1 )
            {
                input = input.Replace( "\r", @"\r" );
            }

            if( input.IndexOf( "\n" ) != -1 )
            {
                input = input.Replace( "\n", @"\n" );
            }

            if( input.IndexOf( "\t" ) != -1 )
            {
                input = input.Replace( "\t", @"\t" );
            }

            if( input.IndexOf( "\"" ) != -1 )
            {
                return input.Replace( "\"", @"""" );
            }
            else
            {
                return input;
            }
        }

        /// <summary>
        /// Gets the available models.
        /// </summary>
        /// <returns>
        /// A list of strings representing OpenAI models
        /// </returns>
        private protected virtual IList<string> GetModels( )
        {
            try
            {
                _models?.Clear( );
                _models?.Add( "gpt-4-turbo" );
                _models?.Add( "gpt-4-turbo-2024-04-09" );
                _models?.Add( "gpt-4-turbo-preview" );
                _models?.Add( "gpt-4-0125-preview" );
                _models?.Add( "gpt-4-1106-preview" );
                _models?.Add( "gpt-4" );
                _models?.Add( "gpt-4-0613" );
                _models?.Add( "gpt-4-0314" );
                _models?.Add( "gpt-4-turbo" );
                _models?.Add( "gpt-4-turbo-2024-04-09" );
                _models?.Add( "gpt-4-turbo-preview" );
                _models?.Add( "gpt-4-0125-preview" );
                _models?.Add( "gpt-4-1106-preview" );
                _models?.Add( "gpt-4o" );
                _models?.Add( "gpt-4o-mini" );
                _models?.Add( "o1-preview" );
                _models?.Add( "o1-mini" );
                _models?.Add( "gpt-3.5-turbo" );
                _models?.Add( "dall-e-3" );
                _models?.Add( "dall-e-2" );
                _models?.Add( "whisper-1" );
                _models?.Add( "tts-1" );
                _models?.Add( "tts-1-hd" );
                _models?.Add( "text-embedding-3-small" );
                _models?.Add( "text-embedding-3-large" );
                _models?.Add( "text-embedding-ada-002" );
                return _models?.Any( ) == true
                    ? _models
                    : default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Gets the end points.
        /// </summary>
        /// <returns></returns>
        private protected virtual IList<string> GetEndPoints( )
        {
            try
            {
                _endPoints.Add( "https://api.openai.com/v1/chat/completions" );
                _endPoints.Add( "https://api.openai.com/v1/completions" );
                _endPoints.Add( "https://api.openai.com/v1/assistants" );
                _endPoints.Add( "https://api.openai.com/v1/audio/speech" );
                _endPoints.Add( "https://api.openai.com/v1/audio/translations" );
                _endPoints.Add( "https://api.openai.com/v1/fineTuning/jobs" );
                _endPoints.Add( "https://api.openai.com/v1/files" );
                _endPoints.Add( "https://api.openai.com/v1/uploads" );
                _endPoints.Add( "https://api.openai.com/v1/images/generations" );
                _endPoints.Add( "https://api.openai.com/v1/images/variations" );
                _endPoints.Add( "https://api.openai.com/v1/threads" );
                _endPoints.Add( "https://api.openai.com/v1/threads/runs" );
                _endPoints.Add( "https://api.openai.com/v1/vector_stores" );
                _endPoints.Add( "https://api.openai.com/v1/organization/invites" );
                _endPoints.Add( "https://api.openai.com/v1/organization/users" );
                _endPoints.Add( "https://api.openai.com/v1/organization/projects" );
                return _endPoints?.Any( ) == true
                    ? _endPoints
                    : default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Wraps error
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