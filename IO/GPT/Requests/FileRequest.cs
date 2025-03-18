// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-21-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-21-2025
// ******************************************************************************************
// <copyright file="FileRequest.cs" company="Terry D. Eppler">
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
//   FileRequest.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
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
    /// <seealso cref="T:Badger.GptRequest" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "ParameterTypeCanBeEnumerable.Global" ) ]
    public class FileRequest : GptRequest
    {
        /// <summary>
        /// The file identifier, which can be referenced in the API endpoints.
        /// </summary>
        private protected int _id;

        /// <summary>
        /// The file identifier
        /// </summary>
        private protected string _fileId;

        /// <summary>
        /// The intended purpose of the file.
        /// </summary>
        private protected string _purpose;

        /// <summary>
        /// </summary>
        private protected int _limit;

        /// <summary>
        /// 
        /// </summary>
        private protected string _order;

        /// <summary>
        ///
        /// </summary>
        private protected string _after;

        /// <summary>
        /// The Unix timestamp (in seconds) for when the file was created.
        /// </summary>
        private protected int _createdAt;

        /// <summary>
        /// The size of the file, in bytes.
        /// </summary>
        private protected int _bytes;

        /// <summary>
        /// The file name
        /// </summary>
        private protected string _fileName;

        /// <summary>
        /// The MIME type
        /// </summary>
        private protected string _mimeType;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FileRequest"/> class.
        /// </summary>
        /// <inheritdoc />
        public FileRequest( )
            : base( )
        {
            _entry = new object( );
            _header = new GptHeader( );
            _endPoint = GptEndPoint.Files;
            _messages.Add( new SystemMessage( _systemPrompt ) );
            _model = "gpt-4o-mini";
            _limit = 10000;
            _order = "desc";
            _purpose = "assistants";
        }

        /// <summary>
        /// The file identifier, which can be referenced in the API endpoints.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [ JsonPropertyName( "id" ) ]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if( _id != value )
                {
                    _id = value;
                    OnPropertyChanged( nameof( Id ) );
                }
            }
        }

        /// <summary>
        /// The intended purpose of the file.
        /// Supported values are assistants, assistants_output,
        /// batch, batch_output, fine-tune, fine-tune-results and vision.
        /// </summary>
        /// <value>
        /// The purpose.
        /// </value>
        [ JsonPropertyName( "purpose" ) ]
        public string Purpose
        {
            get
            {
                return _purpose;
            }
            set
            {
                if( _purpose != value )
                {
                    _purpose = value;
                    OnPropertyChanged( nameof( Purpose ) );
                }
            }
        }

        /// <summary>
        /// A limit on the number of objects to be returned.
        /// Limit can range between 1 and 10,000,
        /// and the default is 10,000.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        [ JsonPropertyName( "limit" ) ]
        public int Limit
        {
            get
            {
                return _limit;
            }
            set
            {
                if( _limit != value )
                {
                    _limit = value;
                    OnPropertyChanged( nameof( Limit ) );
                }
            }
        }

        /// <summary>
        /// Sort order by the created_at timestamp of the objects.
        /// asc for ascending order and desc for descending order
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [ JsonPropertyName( "order" ) ]
        public string Order
        {
            get
            {
                return _order;
            }
            set
            {
                if( _order != value )
                {
                    _order = value;
                    OnPropertyChanged( nameof( Order ) );
                }
            }
        }

        /// <summary>
        /// A cursor for use in pagination. after is an object ID
        /// defines your place in the list. For instance, if you
        /// make a list request and receive 100 objects, ending with
        /// obj_foo, your subsequent call can include after=obj_foo
        /// in order to fetch the next page of the list
        /// </summary>
        /// <value>
        /// The after.
        /// </value>
        [ JsonPropertyName( "after" ) ]
        public string After
        {
            get
            {
                return _after;
            }
            set
            {
                if( _after != value )
                {
                    _after = value;
                    OnPropertyChanged( nameof( After ) );
                }
            }
        }

        /// <summary>
        /// The Unix timestamp (in seconds) for when the file was created.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [ JsonPropertyName( "created_at" ) ]
        public int CreatedAt
        {
            get
            {
                return _createdAt;
            }
            set
            {
                if( _createdAt != value )
                {
                    _createdAt = value;
                    OnPropertyChanged( nameof( CreatedAt ) );
                }
            }
        }

        /// <summary>
        /// The size of the file, in bytes.
        /// </summary>
        /// <value>
        /// The bytes.
        /// </value>
        [ JsonPropertyName( "bytes" ) ]
        public int Bytes
        {
            get
            {
                return _bytes;
            }
            set
            {
                if( _bytes != value )
                {
                    _bytes = value;
                    OnPropertyChanged( nameof( Bytes ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the file identifier.
        /// </summary>
        /// <value>
        /// The file identifier.
        /// </value>
        [ JsonPropertyName( "file_id" ) ]
        public string FileId
        {
            get
            {
                return _fileId;
            }
            set
            {
                if( _fileId != value )
                {
                    _fileId = value;
                    OnPropertyChanged( nameof( FileId ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [ JsonPropertyName( "filename" ) ]
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                if( _fileName != value )
                {
                    _fileName = value;
                    OnPropertyChanged( nameof( FileName ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        [ JsonPropertyName( "mimetype" ) ]
        public string MimeType
        {
            get
            {
                return _mimeType;
            }
            set
            {
                if( _mimeType != value )
                {
                    _mimeType = value;
                    OnPropertyChanged( nameof( MimeType ) );
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

        /// <summary>
        /// Uploads the file asynchronous.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public async Task<string> UploadAsync( string filePath )
        {
            try
            {
                _httpClient = new HttpClient( );
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", _header.ApiKey );
                await using var _fileStream = new FileStream( filePath, FileMode.Open, FileAccess.Read );
                var _fileContent = new StreamContent( _fileStream );
                _fileContent.Headers.ContentType = new MediaTypeHeaderValue( _header.ContentType );
                var _formData = new MultipartFormDataContent
                {
                    {
                        _fileContent, "file", Path.GetFileName( filePath )
                    },
                    {
                        new StringContent( _purpose ), "purpose"
                    }
                };

                var _response = await _httpClient.PostAsync( _endPoint, _formData );
                _response.EnsureSuccessStatusCode( );
                var _responseContent = await _response.Content.ReadAsStringAsync( );
                return _responseContent;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Lists the files asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetListAsync( )
        {
            try
            {
                _httpClient = new HttpClient( );
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", _header.ApiKey );
                var _response = await _httpClient.GetAsync( _endPoint );
                _response.EnsureSuccessStatusCode( );
                var _responseContent = await _response.Content.ReadAsStringAsync( );
                return !string.IsNullOrEmpty( _responseContent )
                    ? _responseContent
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Retrieves the file asynchronous.
        /// </summary>
        /// <param name="fileId">The file identifier.</param>
        /// <returns></returns>
        public async Task<string> RetrieveAsync( string fileId )
        {
            try
            {
                ThrowIf.Empty( fileId, nameof( fileId ) );
                _httpClient = new HttpClient( );
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", _apiKey );
                var _response = await _httpClient.GetAsync( $"{_endPoint}/{fileId}" );
                _response.EnsureSuccessStatusCode( );
                var _responseContent = await _response.Content.ReadAsStringAsync( );
                return !string.IsNullOrEmpty( _responseContent )
                    ? _responseContent
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Deletes the file asynchronous.
        /// </summary>
        /// <param name="fileId">The file identifier.</param>
        /// <returns></returns>
        public async Task<string> DeleteAsync( string fileId )
        {
            try
            {
                ThrowIf.Empty( fileId, nameof( fileId ) );
                _httpClient = new HttpClient( );
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", App.OpenAiKey );
                var _response = await _httpClient.DeleteAsync( $"{_endPoint}/{fileId}" );
                _response.EnsureSuccessStatusCode( );
                var _responseContent = await _response.Content.ReadAsStringAsync( );
                return !string.IsNullOrEmpty( _responseContent )
                    ? _responseContent
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