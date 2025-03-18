// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-18-2025
// ******************************************************************************************
// <copyright file="FeatureVector.cs" company="Terry D. Eppler">
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
//   FeatureVector.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.ML.Data;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class FeatureVectors : PropertyChangedBase
    {
        /// <summary>
        /// The embedding
        /// </summary>
        private protected float[ ] _embeddings;

        /// <summary>
        /// The bag of words
        /// </summary>
        private protected float[ ] _bagOfWords;

        /// <summary>
        /// The tokens
        /// </summary>
        private protected string[ ] _tokens;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FeatureVectors"/> class.
        /// </summary>
        public FeatureVectors( )
        {
        }

        /// <summary>
        /// Gets or sets the embedding.
        /// </summary>
        /// <value>
        /// The embedding.
        /// </value>
        [ ColumnName( "Features" ) ]
        public float[ ] Embeddings
        {
            get
            {
                return _embeddings;
            }
            set
            {
                if( _embeddings != value )
                {
                    _embeddings = value;
                    OnPropertyChanged( nameof( Embeddings ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the bag of words.
        /// </summary>
        /// <value>
        /// The bag of words.
        /// </value>
        [ ColumnName( "BagOfWords" ) ]
        public float[ ] BagOfWords
        {
            get
            {
                return _bagOfWords;
            }
            set
            {
                if( _bagOfWords != value )
                {
                    _bagOfWords = value;
                    OnPropertyChanged( nameof( BagOfWords ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the tokens.
        /// </summary>
        /// <value>
        /// The tokens.
        /// </value>
        [ ColumnName( "Tokens" ) ]
        public string[ ] Tokens
        {
            get
            {
                return _tokens;
            }
            set
            {
                if( _tokens != value )
                {
                    _tokens = value;
                    OnPropertyChanged( nameof( Tokens ) );
                }
            }
        }
    }
}