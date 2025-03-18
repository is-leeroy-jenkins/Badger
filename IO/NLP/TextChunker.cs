// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-22-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-22-2025
// ******************************************************************************************
// <copyright file="TextChunker.cs" company="Terry D. Eppler">
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
//   TextChunker.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ParameterTypeCanBeEnumerable.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    public class TextChunker : IDisposable
    {
        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The entry
        /// </summary>
        private protected object _entry = new object( );

        /// <summary>
        /// The timer
        /// </summary>
        private protected Timer _timer;

        /// <summary>
        /// The timer callback
        /// </summary>
        private protected TimerCallback _timerCallback;

        /// <summary>
        /// The status update
        /// </summary>
        private protected Action _statusUpdate;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextChunker"/> class.
        /// </summary>
        public TextChunker( )
        {
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
        /// Chunks the text.
        /// </summary>
        /// <param name="texts">The texts.</param>
        /// <param name="maxSize">Maximum size of the chunk.</param>
        /// <returns></returns>
        public IList<string> ChunkText( IList<string> texts, int maxSize = 500 )
        {
            try
            {
                var _chunks = new List<string>( );
                foreach( var _text in texts )
                {
                    var _sentences = _text.Split( new[ ]
                    {
                        '.',
                        '!',
                        '?'
                    }, StringSplitOptions.RemoveEmptyEntries );

                    var _currentChunk = "";
                    foreach( var _sentence in _sentences )
                    {
                        if( ( _currentChunk + _sentence ).Length > maxSize )
                        {
                            _chunks.Add( _currentChunk );
                            _currentChunk = "";
                        }

                        _currentChunk += _sentence + ". ";
                    }

                    if( !string.IsNullOrEmpty( _currentChunk ) )
                    {
                        _chunks.Add( _currentChunk );
                    }
                }

                return _chunks;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Removes the stop words.
        /// </summary>
        /// <param name="chunks">The chunks.</param>
        /// <param name="stops">The stop words.</param>
        /// <returns></returns>
        public List<string> RemoveStopWords( IList<string> chunks, HashSet<string> stops )
        {
            return chunks.Select( s =>
            {
                var _words = s.Split( ' ', StringSplitOptions.RemoveEmptyEntries );
                var _values = _words.Where( w => !stops.Contains( w.ToLower( ) ) );
                return string.Join( " ", _values );
            } ).ToList( );
        }

        /// <summary>
        /// Gets the total token count.
        /// </summary>
        /// <param name="chunks">The chunks.</param>
        /// <returns></returns>
        public int GetTokenCount( IList<string> chunks )
        {
            try
            {
                var _tkn = chunks.Sum( s =>
                    s.Split( ' ', StringSplitOptions.RemoveEmptyEntries ).Length );

                return _tkn > 0
                    ? _tkn
                    : 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return 0;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c>
        /// to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                _timer?.Dispose( );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            using var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}