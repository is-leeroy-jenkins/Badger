// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-16-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-16-2025
// ******************************************************************************************
// <copyright file="AudioRecorder.cs" company="Terry D. Eppler">
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
//   AudioRecorder.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using NAudio.Wave;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.IDisposable" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public class AudioRecorder : PropertyChangedBase, IDisposable
    {
        /// <summary>
        /// The wave in
        /// </summary>
        private protected WaveInEvent _waveIn;

        /// <summary>
        /// The writer
        /// </summary>
        private protected WaveFileWriter _writer;

        /// <summary>
        /// The is recording
        /// </summary>
        private protected bool _isRecording;

        /// <summary>
        /// Occurs when [on volume level changed].
        /// </summary>
        public event Action<float> OnVolumeLevelChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioRecorder"/> class.
        /// </summary>
        /// <param name="sampleRate">The sample rate.</param>
        /// <param name="channels">The channels.</param>
        public AudioRecorder( int sampleRate = 44100, int channels = 1 )
        {
            _waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat( sampleRate, channels )
            };
        }

        /// <summary>
        /// Gets a value indicating whether this instance is recording.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is recording; otherwise, <c>false</c>.
        /// </value>
        public bool IsRecording
        {
            get
            {
                return _isRecording;
            }
            private set
            {
                if( _isRecording != value )
                {
                    _isRecording = value;
                    OnPropertyChanged( nameof( IsRecording ) );
                }
            }
        }

        /// <summary>
        /// Starts the recording.
        /// </summary>
        /// <param name="outputFilePath">The output file path.</param>
        /// <exception cref="System.InvalidOperationException">
        /// Already recording.
        /// </exception>
        public void StartRecording( string outputFilePath )
        {
            if( _isRecording )
            {
                throw new InvalidOperationException( "Already recording." );
            }

            _writer = new WaveFileWriter( outputFilePath, _waveIn.WaveFormat );
            _waveIn.DataAvailable += OnDataAvailable;
            _waveIn.RecordingStopped += OnRecordingStopped;
            _waveIn.StartRecording( );
            _isRecording = true;
        }

        /// <summary>
        /// Stops the recording.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// Not currently recording.
        /// </exception>
        public void StopRecording( )
        {
            if( !_isRecording )
            {
                throw new InvalidOperationException( "Not currently recording." );
            }

            _waveIn.StopRecording( );
        }

        /// <summary>
        /// Called when [data available].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="WaveInEventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnDataAvailable( object sender, WaveInEventArgs e )
        {
            _writer.Write( e.Buffer, 0, e.BytesRecorded );
            float _maxVolume = 0;
            for( var _i = 0; _i < e.BytesRecorded; _i += 2 )
            {
                var _sample = BitConverter.ToInt16( e.Buffer, _i );
                _maxVolume = Math.Max( _maxVolume, Math.Abs( _sample / 32768f ) );
            }

            OnVolumeLevelChanged?.Invoke( _maxVolume );
        }

        /// <summary>
        /// Called when [recording stopped].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="StoppedEventArgs"/>
        /// instance containing the event data.
        /// </param>
        private void OnRecordingStopped( object sender, StoppedEventArgs e )
        {
            _writer?.Dispose( );
            _waveIn.DataAvailable -= OnDataAvailable;
            _waveIn.RecordingStopped -= OnRecordingStopped;
            _isRecording = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose( )
        {
            _waveIn?.Dispose( );
            _writer?.Dispose( );
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