// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-27-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-27-2025
// ******************************************************************************************
// <copyright file="SpeechEngine.cs" company="Terry D. Eppler">
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
//   SpeechEngine.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Speech.Synthesis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class SpeechEngine : IDisposable
    {
        /// <summary>
        /// The synthesizer
        /// </summary>
        private SpeechSynthesizer _synthesizer;

        /// <summary>
        /// Occurs when [speak completed].
        /// </summary>
        public event EventHandler<SpeakCompletedEventArgs> SpeakCompleted;

        /// <summary>
        /// Occurs when [speak progress].
        /// </summary>
        public event EventHandler<SpeakProgressEventArgs> SpeakProgress;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SpeechEngine"/> class.
        /// </summary>
        public SpeechEngine( )
        {
            _synthesizer = new SpeechSynthesizer( );
            _synthesizer.SpeakCompleted += OnSpeakCompleted;
            _synthesizer.SpeakProgress += OnSpeakProgress;
        }

        /// <summary>
        /// Speaks the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Speak( string text )
        {
            try
            {
                ThrowIf.Empty( text, nameof( text ) );
                _synthesizer.SpeakAsync( text );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Speaks from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="System.IO.FileNotFoundException">
        /// The specified file does not exist.</exception>
        public void SpeakFromFile( string filePath )
        {
            try
            {
                ThrowIf.Empty( filePath, nameof( filePath ) );
                if( !File.Exists( filePath ) )
                {
                    throw new FileNotFoundException( "The specified file does not exist." );
                }

                var _text = File.ReadAllText( filePath );
                _synthesizer.SpeakAsync( _text );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Saves to audio file.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="filePath">The output path.</param>
        public void SaveToAudioFile( string text, string filePath )
        {
            try
            {
                ThrowIf.Empty( text, nameof( text ) );
                ThrowIf.Empty( filePath, nameof( filePath ) );
                using var _fileStream =
                    new FileStream( filePath, FileMode.Create, FileAccess.Write );

                _synthesizer.SetOutputToWaveStream( _fileStream );
                _synthesizer.Speak( text );
                _synthesizer.SetOutputToDefaultAudioDevice( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Saves the file to audio.
        /// </summary>
        /// <param name="inputPath">The input file path.</param>
        /// <param name="outputPath">The output path.</param>
        /// <exception cref="System.IO.FileNotFoundException">
        /// The specified input file does not exist.</exception>
        public void SaveFileToAudio( string inputPath, string outputPath )
        {
            try
            {
                ThrowIf.Empty( inputPath, nameof( inputPath ) );
                ThrowIf.Empty( outputPath, nameof( outputPath ) );
                if( !File.Exists( inputPath ) )
                {
                    var _message = "The specified input file does not exist.";
                    throw new FileNotFoundException( _message );
                }

                var _text = File.ReadAllText( inputPath );
                SaveToAudioFile( _text, outputPath );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Pauses this instance.
        /// </summary>
        public void Pause( )
        {
            try
            {
                _synthesizer.Pause( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Resumes this instance.
        /// </summary>
        public void Resume( )
        {
            try
            {
                _synthesizer.Resume( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the voice.
        /// </summary>
        /// <param name="voiceName">Name of the voice.</param>
        public void SetVoice( string voiceName )
        {
            try
            {
                ThrowIf.Empty( voiceName, nameof( voiceName ) );
                _synthesizer.SelectVoice( voiceName );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the volume.
        /// </summary>
        /// <param name="volume">The volume.</param>
        public void SetVolume( int volume )
        {
            try
            {
                ThrowIf.Negative( volume, nameof( volume ) );
                _synthesizer.Volume = volume;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Sets the rate.
        /// </summary>
        /// <param name="rate">The rate.</param>
        public void SetRate( int rate )
        {
            try
            {
                ThrowIf.Negative( rate, nameof( rate ) );
                _synthesizer.Rate = rate;
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [speak completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SpeakCompletedEventArgs"/>
        /// instance containing the event data.</param>
        private void OnSpeakCompleted( object sender, SpeakCompletedEventArgs e )
        {
            try
            {
                SpeakCompleted?.Invoke( this, e );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [speak progress].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SpeakProgressEventArgs"/>
        /// instance containing the event data.</param>
        private void OnSpeakProgress( object sender, SpeakProgressEventArgs e )
        {
            try
            {
                SpeakProgress?.Invoke( this, e );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose( )
        {
            if( _synthesizer != null )
            {
                _synthesizer.Dispose( );
                _synthesizer = null;
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}