// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-16-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-16-2025
// ******************************************************************************************
// <copyright file="LanguagePipeline.cs" company="Terry D. Eppler">
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
//   LanguagePipeline.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class LanguagePipeline
    {
        /// <summary>
        /// The processor
        /// </summary>
        private readonly ILanguageProcessor _processor;

        /// <summary>
        /// The sentiment analyzer
        /// </summary>
        private readonly ISentimentAnalyzer _sentimentAnalyzer;

        /// <summary>
        /// The classifier
        /// </summary>
        private readonly ITextClassifier _classifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguagePipeline"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <param name="sentimentAnalyzer">The sentiment analyzer.</param>
        /// <param name="classifier">The classifier.</param>
        public LanguagePipeline( ILanguageProcessor processor, ISentimentAnalyzer sentimentAnalyzer,
            ITextClassifier classifier )
        {
            _processor = processor;
            _sentimentAnalyzer = sentimentAnalyzer;
            _classifier = classifier;
        }

        /// <summary>
        /// Processes the text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void ProcessText( string text )
        {
            var _normalizedText = _processor.NormalizeText( text );
            var _tokens = _processor.TokenizeText( _normalizedText );
            var _cleanTokens = _processor.RemoveStopWords( _tokens );
            foreach( var Token in _cleanTokens )
            {
                Console.WriteLine( _processor.StemWord( Token ) );
            }

            var _sentiment = _sentimentAnalyzer.AnalyzeSentiment( _normalizedText );
            var _category = _classifier.ClassifyText( _normalizedText );
        }
    }
}