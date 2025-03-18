// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-06-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-06-2025
// ******************************************************************************************
// <copyright file="ImageOptions.cs" company="Terry D. Eppler">
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
//   ImageOptions.cs
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
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    public class ImageOptions : GptOptions
    {
        /// <summary>
        /// The image size
        /// </summary>
        private protected string _size;

        /// <summary>
        /// A text description of the desired image(s).
        /// The maximum length is 1000 characters for
        /// dall-e-2 and 4000 characters for dall-e-3
        /// </summary>
        private protected string _prompt;

        /// <summary>
        /// The quality
        /// </summary>
        private protected string _quality;

        /// <summary>
        /// The style of the generated images. Must be one of vivid or natural.
        /// Vivid causes the model to lean towards generating hyper-real and
        /// dramatic images. Natural causes the model to produce more natural,
        /// less hyper-real looking images. This param is only supported for dall-e-3.
        /// </summary>
        private protected string _style;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ImageParameter" /> class.
        /// </summary>
        public ImageOptions( )
            : base( )
        {
            _endPoint = GptEndPoint.ImageGeneration;
            _store = false;
            _stream = false;
            _number = 1;
            _temperature = 0.08;
            _topPercent = 0.09;
            _frequencyPenalty = 0.00;
            _presencePenalty = 0.00;
            _maximumTokens = 2048;
            _size = "1024x1024";
            _style = "natural";
            _stop = "['#', ';']";
            _responseFormat = "url";
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>
        /// The size of the image.
        /// </value>
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

        /// <summary>
        /// A text description of the desired image(s).
        /// The maximum length is 1000 characters for
        /// dall-e-2 and 4000 characters for dall-e-3
        /// </summary>
        /// <value>
        /// The prompt.
        /// </value>
        public string Input
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
                    OnPropertyChanged( nameof( Input ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        /// <value>
        /// The quality.
        /// </value>
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
        /// <returns></returns>
        public override IDictionary<string, object> GetData( )
        {
            try
            {
                _data.Add( "n", _number );
                _data.Add( "max_completion_tokens", _maximumTokens );
                _data.Add( "store", _store );
                _data.Add( "stream", _stream );
                _data.Add( "temperature", _temperature );
                _data.Add( "frequency_penalty", _frequencyPenalty );
                _data.Add( "presence_penalty", _presencePenalty );
                _data.Add( "top_p", _topPercent );
                _data.Add( "stop", _stop );
                _data.Add( "response_format", _responseFormat );
                _data.Add( "style", _style );
                _data.Add( "size", _size );
                _data.Add( "quality", _quality );
                _data.Add( "model", _model );
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
        /// Gets the formats.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetFormats( )
        {
            try
            {
                var _formats = new List<string>
                {
                    "url",
                    "b64_json"
                };

                return _formats;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Gets the size options.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetDalleTwoSizes( )
        {
            try
            {
                var _sizes = new List<string>
                {
                    "256X256",
                    "512X512",
                    "1024X1024"
                };

                return _sizes;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Gets the dalle three sizes.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetDalleThreeSizes( )
        {
            try
            {
                var _sizes = new List<string>
                {
                    "1792x1024",
                    "1024x1792"
                };

                return _sizes;
            }
            catch(Exception ex)
            {
                Fail(ex);
                return default(IList<string>);
            }
        }
    }
}