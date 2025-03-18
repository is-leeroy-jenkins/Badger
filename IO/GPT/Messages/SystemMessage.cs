// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-23-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-23-2025
// ******************************************************************************************
// <copyright file="SystemMessage.cs" company="Terry D. Eppler">
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
//   SystemMessage.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Properties;
    using Exception = System.Exception;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.GptMessage" />
    /// <seealso cref="T:Badger.IGptMessage" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "CanSimplifyDictionaryLookupWithTryGetValue" ) ]
    public class SystemMessage : GptMessage, IGptMessage
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SystemMessage"/> class.
        /// </summary>
        public SystemMessage( )
        {
            _role = "system";
            _type = "text";
            _text = App.Instructions;
            _data = new Dictionary<string, object>( );
            _content = new GptContent( _type, _text );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SystemMessage" /> class.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        public SystemMessage( string prompt )
        {
            _role = "system";
            _type = "text";
            _text = prompt;
            _content = new GptContent( _type, prompt );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SystemMessage"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public SystemMessage( SystemMessage message )
        {
            _role = message.Role;
            _content = message.Content;
            _type = message.Type;
            _text = message.Text;
        }

        /// <summary>
        /// Deconstructs the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="content">The content.</param>
        public void Deconstruct( out string role, out GptContent content )
        {
            role = _role;
            content = _content;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        [ JsonPropertyName( "role" ) ]
        public override string Role
        {
            get
            {
                return _role;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        [ JsonPropertyName( "content" ) ]
        public override GptContent Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
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
                if( !string.IsNullOrEmpty( _role ) )
                {
                    _data.Add( "role", _role );
                }

                if( !string.IsNullOrEmpty( _type ) )
                {
                    _data.Add( "type", _type );
                }

                if( !string.IsNullOrEmpty( _text ) )
                {
                    _data.Add( "text", _text );
                }

                if( _content != null )
                {
                    _data.Add( "content", _content );
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
        /// Dumps this instance.
        /// </summary>
        /// <returns></returns>
        public string Dump( )
        {
            try
            {
                if( _data?.Any(  ) == false )
                {
                    var _message = "Data is null or has no items";
                    throw new Exception( _message );
                }
                else
                {
                    var _newln = Environment.NewLine;
                    var _payload = "Data Dump:" + _newln;
                    var _space = " ";
                    var _indent = "    ";
                    foreach( var _kvp in _data )
                    {
                        _payload += _indent + $"{_kvp.Key}: {_kvp.Value}" + _newln;
                    }

                    return _payload;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
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

                var _format = JsonSerializer.Serialize( this, _options );
                return !string.IsNullOrEmpty( _format )
                    ? _format
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