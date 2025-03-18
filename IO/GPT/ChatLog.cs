// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-17-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-17-2025
// ******************************************************************************************
// <copyright file="ChatLog.cs" company="Terry D. Eppler">
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
//   ChatLog.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using Properties;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PossibleUnintendedReferenceComparison" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public class ChatLog : PropertyChangedBase
    {
        /// <summary>
        /// The user prompts
        /// </summary>
        private protected IList<string> _userPrompts;

        /// <summary>
        /// The system prompts
        /// </summary>
        private protected IList<string> _systemPrompts;

        /// <summary>
        /// The assistant prompts
        /// </summary>
        private protected IList<string> _assistantPrompts;

        /// <summary>
        /// The user messages
        /// </summary>
        private protected IList<IGptMessage> _userMessages;

        /// <summary>
        /// The system messages
        /// </summary>
        private protected IList<IGptMessage> _systemMessages;

        /// <summary>
        /// The assistant messages
        /// </summary>
        private protected IList<IGptMessage> _assistantMessages;

        /// <summary>
        /// The messages
        /// </summary>
        private protected IDictionary<DateTime, IGptMessage> _messages;

        /// <summary>
        /// The data
        /// </summary>
        private protected IDictionary<string, object> _data;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Object" /> class.
        /// </summary>
        /// <returns></returns>
        public ChatLog( )
        {
            _userPrompts = new List<string>( );
            _systemPrompts = new List<string>( );
            _assistantPrompts = new List<string>( );
            _userMessages = new List<IGptMessage>( );
            _systemMessages = new List<IGptMessage>( );
            _assistantMessages = new List<IGptMessage>( );
            _data = new Dictionary<string, object>( );
            _messages = new Dictionary<DateTime, IGptMessage>( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChatLog"/> class.
        /// </summary>
        /// <param name="userPrompt">The user prompt.</param>
        public ChatLog( string userPrompt )
        {
            _systemPrompts.Add( App.Instructions );
            _systemMessages.Add( new SystemMessage( App.Instructions ) );
            _userPrompts.Add( userPrompt );
            _userMessages.Add( new UserMessage( userPrompt ) );
            _messages.Add( DateTime.Now, new SystemMessage( App.Instructions ) );
            _messages.Add( DateTime.Now, new UserMessage( userPrompt ) );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatLog"/> class.
        /// </summary>
        /// <param name="systemPrompt">The system prompt.</param>
        /// <param name="userPrompt">The user prompt.</param>
        public ChatLog( string systemPrompt, string userPrompt )
        {
            _systemPrompts.Add( userPrompt );
            _systemMessages.Add( new SystemMessage( userPrompt ) );
            _userPrompts.Add( userPrompt );
            _userMessages.Add( new UserMessage( userPrompt ) );
            _messages.Add( DateTime.Now, new SystemMessage( systemPrompt ) );
            _messages.Add( DateTime.Now, new UserMessage( userPrompt ) );
        }

        /// <summary>
        /// Gets or sets the user prompts.
        /// </summary>
        /// <value>
        /// The user prompts.
        /// </value>
        public IList<string> UserPrompts
        {
            get
            {
                return _userPrompts;
            }
            set
            {
                if( _userPrompts != value )
                {
                    _userPrompts = value;
                    OnPropertyChanged( nameof( UserPrompts ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the user messages.
        /// </summary>
        /// <value>
        /// The user messages.
        /// </value>
        public IList<IGptMessage> UserMessages
        {
            get
            {
                return _userMessages;
            }
            set
            {
                if( _userMessages != value )
                {
                    _userMessages = value;
                    OnPropertyChanged( nameof( UserMessages ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the system messages.
        /// </summary>
        /// <value>
        /// The system messages.
        /// </value>
        public IList<IGptMessage> SystemMessages
        {
            get
            {
                return _systemMessages;
            }
            set
            {
                if( _systemMessages != value )
                {
                    _systemMessages = value;
                    OnPropertyChanged( nameof( SystemMessages ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the assistant messages.
        /// </summary>
        /// <value>
        /// The assistant messages.
        /// </value>
        public IList<IGptMessage> AssistantMessages
        {
            get
            {
                return _assistantMessages;
            }
            set
            {
                if( _assistantMessages != value )
                {
                    _assistantMessages = value;
                    OnPropertyChanged( nameof( AssistantMessages ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the system prompts.
        /// </summary>
        /// <value>
        /// The system prompts.
        /// </value>
        public IList<string> SystemPrompts
        {
            get
            {
                return _systemPrompts;
            }
            set
            {
                if( _systemPrompts != value )
                {
                    _systemPrompts = value;
                    OnPropertyChanged( nameof( SystemPrompts ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the assistant prompts.
        /// </summary>
        /// <value>
        /// The assistant prompts.
        /// </value>
        public IList<string> AssistantPrompts
        {
            get
            {
                return _assistantPrompts;
            }
            set
            {
                if( _assistantPrompts != value )
                {
                    _assistantPrompts = value;
                    OnPropertyChanged( nameof( AssistantPrompts ) );
                }
            }
        }

        /// <summary>
        /// Adds the user message.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        public void AddUserMessage( string prompt )
        {
            try
            {
                ThrowIf.Empty( prompt, nameof( prompt ) );
                _userMessages.Add( new UserMessage( prompt ) );
                _messages.Add( DateTime.Now, new UserMessage( prompt ) );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Adds the user message.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        public void AddSystemMessage( string prompt )
        {
            try
            {
                ThrowIf.Empty( prompt, nameof( prompt ) );
                _systemMessages.Add( new SystemMessage( prompt ) );
                _messages.Add( DateTime.Now, new SystemMessage( prompt ) );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Adds the user message.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        public void AddAssistantMessage( string prompt )
        {
            try
            {
                ThrowIf.Empty( prompt, nameof( prompt ) );
                _assistantMessages.Add( new AssistantMessage( prompt ) );
                _messages.Add( DateTime.Now, new AssistantMessage( prompt ) );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IDictionary<string, object> GetData( )
        {
            try
            {
                if( _systemMessages != null )
                {
                    _data.Add( "SystemMessages", _systemMessages );
                }

                if( _userMessages != null )
                {
                    _data.Add( "UserMessages", _userMessages );
                }

                if( _assistantMessages != null )
                {
                    _data.Add( "AssistantMessages", _assistantMessages );
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
        /// Serializes this instance.
        /// </summary>
        /// <returns></returns>
        private protected string Serialize( )
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

                var _text = JsonSerializer.Serialize(this, _options);
                return !string.IsNullOrEmpty(_text)
                    ? _text
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