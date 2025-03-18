// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-22-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-22-2025
// ******************************************************************************************
// <copyright file="TextRetriever.cs" company="Terry D. Eppler">
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
//   TextRetriever.cs
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
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "ReturnTypeCanBeEnumerable.Global" ) ]
    [ SuppressMessage( "ReSharper", "ParameterTypeCanBeEnumerable.Global" ) ]
    public class TextRetriever : IDisposable
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
        /// Initializes a new instance of the
        /// <see cref="TextRetriever"/> class.
        /// </summary>
        public TextRetriever( )
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
            catch( Exception _ex )
            {
                Fail( _ex );
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
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Gets the chunks.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="chunks">The document chunks.</param>
        /// <param name="topN">The top n.</param>
        /// <returns></returns>
        public IList<string> GetChunks( string prompt, IList<string> chunks, int topN = 3 )
        {
            try
            {
                ThrowIf.Empty( prompt, nameof( prompt ) );
                ThrowIf.Null(chunks, nameof(chunks));
                var _query = prompt.Split( ' ', StringSplitOptions.RemoveEmptyEntries );
                var _scoredChunks = new List<(string Chunk, double Score)>( );
                for( var _index = 0; _index < chunks.Count; _index++ )
                {
                    var _chunk = chunks[ _index ];
                    var _tokens = _chunk.Split( ' ', StringSplitOptions.RemoveEmptyEntries );
                    var _score = CalculateCosineSimilarity( _query, _tokens );
                    _scoredChunks.Add( ( _chunk, _score ) );
                }

                return _scoredChunks.OrderByDescending( c => c.Score )
                    .Take( topN )
                    .Select( c => c.Chunk )
                    .ToList( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Calculates the cosine similarity.
        /// </summary>
        /// <param name="tokensA">The tokens a.</param>
        /// <param name="tokensB">The tokens b.</param>
        /// <returns></returns>
        private double CalculateCosineSimilarity( string[ ] tokensA, string[ ] tokensB )
        {
            try
            {
                ThrowIf.Null( tokensA, nameof( tokensA ) );
                ThrowIf.Null( tokensB, nameof( tokensB ) );
                var _setA = tokensA.Distinct( ).ToArray( );
                var _setB = tokensB.Distinct( ).ToArray( );
                var _intersection = _setA.Intersect( _setB ).Count( );
                var _magnitudeA = Math.Sqrt( _setA.Length );
                var _magnitudeB = Math.Sqrt( _setB.Length );
                return _intersection / ( _magnitudeA * _magnitudeB );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return 0.00;
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