﻿// ****************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 20-03-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        20-03-2024
// ****************************************************************************************
// <copyright file="AsyncFileBase.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application for analysts in the
//    US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
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
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND,
//     EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//     OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE
//     AND NON-INFRINGEMENT.  IN NO EVENT SHALL THE AUTHORS
//     OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//     DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//     TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//     DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//  AsyncFileBase.cs
// </summary>
// ****************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class AsyncFileBase : AsyncPath
    {
        /// <summary>
        /// The exists
        /// </summary>
        private protected bool _fileExists;

        /// <summary>
        /// Prevents a default instance of the
        /// <see cref="AsyncFileBase"/> class from being created.
        /// </summary>
        /// <inheritdoc />
        protected AsyncFileBase( )
        {
        }

        /// <summary>
        /// Prevents a default instance of the
        /// <see cref="AsyncFileBase"/> class from being created.
        /// </summary>
        /// <inheritdoc />
        protected AsyncFileBase( string input ) 
            : base( input )
        {
        }

        /// <summary>
        /// Moves the specified file path.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public void MoveAsync( string filePath )
        {
            try
            {
                ThrowIf.Null( filePath, nameof( filePath ) );
                var _source = new FileInfo( _fullPath );
                _source.MoveTo( filePath );
            }
            catch( IOException _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Copies the specified file path.
        /// </summary>
        /// <param name="destination">
        /// The file path.
        /// </param>
        public Task CopyToAsnyc( string destination )
        {
            var _async = new TaskCompletionSource( );
            try
            {
                ThrowIf.Null( destination, nameof( destination ) );
                var _source = new FileInfo( _fullPath );
                _source.CopyTo( destination );
                _async.SetResult( );
                return _async.Task;
            }
            catch( IOException _ex )
            {
                _async.SetException( _ex );
                Fail( _ex );
                return default( Task );
            }
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public Task DeleteAsync( )
        {
            var _async = new TaskCompletionSource( );
            try
            {
                if( File.Exists( _fullPath ) )
                {
                    File.Delete( _fullPath );
                    _async.SetResult( );
                    return _async.Task;
                }

                return _async.Task;
            }
            catch( IOException _ex )
            {
                _async.SetException( _ex );
                Fail( _ex );
                return default( Task );
            }
        }

        /// <summary>
        /// Gets the base stream aynchronously.
        /// </summary>
        /// <returns></returns>
        private protected Task<FileStream> GetBaseStreamAsync( )
        {
            var _async = new TaskCompletionSource<FileStream>( );
            try
            {
                using var _file = new FileInfo( _fullPath )?.Create( );
                _async.SetResult( _file );
                return File.Exists( _fullPath )
                    ? _async.Task
                    : default( Task<FileStream> );
            }
            catch( Exception _ex )
            {
                _async.SetException( _ex );
                Fail( _ex );
                return default( Task<FileStream> );
            }
        }

        /// <summary>
        /// Reads the lines.
        /// </summary>
        /// <returns></returns>
        private protected Task<IList<string>> ReadLinesAsync( )
        {
            if( _fileExists )
            {
                var _async = new TaskCompletionSource<IList<string>>( );
                try
                {
                    var _list = new List<string>( );
                    foreach( var _line in File.ReadAllLines( _input ) )
                    {
                        if( !string.IsNullOrEmpty( _line ) )
                        {
                            _list.Add( _line );
                        }
                    }

                    _async.SetResult( _list );
                    return _list?.Any( ) == true
                        ? _async.Task
                        : default( Task<IList<string>> );
                }
                catch( IOException _ex )
                {
                    Fail( _ex );
                    return default( Task<IList<string>> );
                }
            }

            return default( Task<IList<string>> );
        }

        /// <summary>
        /// Reads the bytes.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected Task<byte[ ]> ReadBytesAsync( )
        {
            if( _fileExists )
            {
                var _async = new TaskCompletionSource<byte[ ]>( );
                try
                {
                    var _data = File.ReadAllBytes( _input );
                    _async.SetResult( _data );
                    return _data.Length > 0
                        ? _async.Task
                        : default( Task<byte[ ]> );
                }
                catch( IOException _ex )
                {
                    _async.SetException( _ex );
                    Fail( _ex );
                    return default( Task<byte[ ]> );
                }
            }

            return default( Task<byte[ ]> );
        }

        /// <summary>
        /// Writes the lines.
        /// </summary>
        /// <returns></returns>
        private protected Task<string> WriteLinesAsync( )
        {
            if( _fileExists )
            {
                var _async = new TaskCompletionSource<string>( );
                try
                {
                    var _text = string.Empty;
                    var _list = File.ReadLines( _fullPath )
                        ?.ToList( );
                    
                    for( var _i = 0; _i < _list.Count; _i++ )
                    {
                        _text += _list[ _i ];
                    }
                    
                    _async.SetResult( _text );
                    return !string.IsNullOrEmpty( _text )
                        ? _async.Task 
                        : default( Task<string> );
                }
                catch( IOException _ex )
                {
                    _async.SetException( _ex );
                    Fail( _ex );
                    return default( Task<string> );
                }
            }

            return default( Task<string> );
        }
    }
}