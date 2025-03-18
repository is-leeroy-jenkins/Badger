// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-18-2025
// ******************************************************************************************
// <copyright file="AudioManager.cs" company="Terry D. Eppler">
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
//   AudioManager.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using NAudio.Wave;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    public static class AudioManager
    {
        /// <summary>
        /// Gets the duration of the audio.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static TimeSpan GetDuration( string filePath )
        {
            try
            {
                ThrowIf.Empty( filePath, nameof( filePath ) );
                using var _reader = new AudioFileReader( filePath );
                return _reader.TotalTime;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( TimeSpan );
            }
        }

        /// <summary>
        /// Determines whether [is audio file valid] [the specified file path].
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        ///   <c>true</c> if [is audio file valid]
        /// [the specified file path]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFileValid( string filePath )
        {
            try
            {
                ThrowIf.Empty( filePath, nameof( filePath ) );
                using var _reader = new AudioFileReader( filePath );
                return true;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// Gets the size of the audio file in bytes.
        /// </summary>
        /// <param name="filePath">Path to the audio file.</param>
        /// <returns>Size of the file in bytes.</returns>
        public static long GetFileSize( string filePath )
        {
            try
            {
                ThrowIf.Empty( filePath, nameof( filePath ) );
                if( !File.Exists( filePath ) )
                {
                    throw new FileNotFoundException( "File not found", filePath );
                }

                return new FileInfo( filePath ).Length;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return 0;
            }
        }

        /// <summary>
        /// Normalizes the audio file by adjusting its volume.
        /// </summary>
        /// <param name="inputFile">Path to the input audio file.</param>
        /// <param name="outputFile">Path to save the normalized audio file.</param>
        public static void Normalize( string inputFile, string outputFile )
        {
            try
            {
                ThrowIf.Empty( inputFile, nameof( inputFile ) );
                ThrowIf.Empty( outputFile, nameof( outputFile ) );
                using var _reader = new AudioFileReader( inputFile );
                using var _writer = new WaveFileWriter( outputFile, _reader.WaveFormat );
                float _maxSample = 0;
                var _buffer = new float[ _reader.WaveFormat.SampleRate ];
                int _samplesRead;

                // Find max sample value
                do
                {
                    _samplesRead = _reader.Read( _buffer, 0, _buffer.Length );
                    for( var _i = 0; _i < _samplesRead; _i++ )
                    {
                        _maxSample = Math.Max( _maxSample, Math.Abs( _buffer[ _i ] ) );
                    }
                }
                while( _samplesRead > 0 );

                if( _maxSample == 0 )
                {
                    throw new InvalidOperationException( "Cannot normalize a silent file." );
                }

                // Normalize and write
                _reader.Position = 0;
                do
                {
                    _samplesRead = _reader.Read( _buffer, 0, _buffer.Length );
                    for( var _i = 0; _i < _samplesRead; _i++ )
                    {
                        _buffer[ _i ] /= _maxSample;
                    }

                    _writer.WriteSamples( _buffer, 0, _samplesRead );
                }
                while( _samplesRead > 0 );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Extracts a segment of an audio file and saves it as a new file.
        /// </summary>
        /// <param name="inputFile">Path to the input audio file.</param>
        /// <param name="outputFile">Path to save the extracted segment.</param>
        /// <param name="start">Start time of the segment.</param>
        /// <param name="duration">Duration of the segment.</param>
        public static void ExtractSegment( string inputFile, string outputFile, TimeSpan start,
            TimeSpan duration )
        {
            try
            {
                ThrowIf.Empty( inputFile, nameof( inputFile ) );
                ThrowIf.Empty( outputFile, nameof( outputFile ) );
                using var _reader = new AudioFileReader( inputFile );
                using var _writer = new WaveFileWriter( outputFile, _reader.WaveFormat );
                _reader.CurrentTime = start;
                var _end = start + duration;
                var _buffer = new byte[ _reader.WaveFormat.AverageBytesPerSecond ];
                while( _reader.CurrentTime < _end )
                {
                    var _time = ( _end - _reader.CurrentTime ).TotalSeconds;
                    var _average = _reader.WaveFormat.AverageBytesPerSecond;
                    var _bytesRequired = ( int )Math.Min( _buffer.Length, _time * _average );
                    var _bytesRead = _reader.Read( _buffer, 0, _bytesRequired );
                    if( _bytesRead == 0 )
                    {
                        break;
                    }

                    _writer.Write( _buffer, 0, _bytesRead );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private static void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}