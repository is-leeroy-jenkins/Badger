// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-12-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-12-2025
// ******************************************************************************************
// <copyright file="SpeechConfiguration.cs" company="Terry D. Eppler">
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
//   SpeechConfiguration.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Speech.Synthesis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class SpeechConfiguration
    {
        /// <summary>
        /// The synthesizer
        /// </summary>
        private SpeechSynthesizer _synthesizer;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SpeechConfiguration"/> class.
        /// </summary>
        public SpeechConfiguration( )
        {
            _synthesizer = new SpeechSynthesizer( );
        }

        /// <summary>
        /// Gets the available voices.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAvailableVoices( )
        {
            var _voices = new List<string>( );
            foreach( var _voice in _synthesizer.GetInstalledVoices( ) )
            {
                _voices.Add( _voice.VoiceInfo.Name );
            }

            return _voices;
        }

        /// <summary>
        /// Gets or sets the default volume.
        /// </summary>
        /// <value>
        /// The default volume.
        /// </value>
        public int DefaultVolume
        {
            get
            {
                return _synthesizer.Volume;
            }
            set
            {
                _synthesizer.Volume = value;
            }
        }

        /// <summary>
        /// Gets or sets the default rate.
        /// </summary>
        /// <value>
        /// The default rate.
        /// </value>
        public int DefaultRate
        {
            get
            {
                return _synthesizer.Rate;
            }
            set
            {
                _synthesizer.Rate = value;
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