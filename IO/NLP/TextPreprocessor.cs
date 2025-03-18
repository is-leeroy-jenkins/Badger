// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-25-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-25-2025
// ******************************************************************************************
// <copyright file="TextPreprocessor.cs" company="Terry D. Eppler">
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
//   TextPreprocessor.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.ILanguageProcessor" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "UseCollectionExpression" ) ]
    [ SuppressMessage( "ReSharper", "ConvertIfStatementToReturnStatement" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    public class TextPreprocessor : ILanguageProcessor
    {
        /// <summary>
        /// The stop words
        /// </summary>
        private protected static HashSet<string> _stopWords = new HashSet<string>
        {
            "i",
            "me",
            "my",
            "myself",
            "we",
            "our",
            "ours",
            "ourselves",
            "you",
            "your",
            "yours",
            "yourself",
            "yourselves",
            "he",
            "him",
            "his",
            "himself",
            "she",
            "her",
            "hers",
            "herself",
            "it",
            "its",
            "itself",
            "they",
            "them",
            "their",
            "theirs",
            "themselves",
            "what",
            "which",
            "who",
            "whom",
            "this",
            "that",
            "these",
            "those",
            "am",
            "is",
            "are",
            "was",
            "were",
            "be",
            "been",
            "being",
            "have",
            "has",
            "had",
            "having",
            "do",
            "does",
            "did",
            "doing",
            "a",
            "an",
            "the",
            "and",
            "but",
            "if",
            "or",
            "because",
            "as",
            "until",
            "while",
            "of",
            "at",
            "by",
            "for",
            "with",
            "about",
            "against",
            "between",
            "into",
            "through",
            "during",
            "before",
            "after",
            "above",
            "below",
            "to",
            "from",
            "up",
            "down",
            "in",
            "out",
            "on",
            "off",
            "over",
            "under",
            "again",
            "further",
            "then",
            "once",
            "here",
            "there",
            "when",
            "where",
            "why",
            "how",
            "all",
            "any",
            "both",
            "each",
            "few",
            "more",
            "most",
            "other",
            "some",
            "such",
            "no",
            "nor",
            "not",
            "only",
            "own",
            "same",
            "so",
            "than",
            "too",
            "very",
            "s",
            "t",
            "can",
            "will",
            "just",
            "don",
            "should",
            "now"
        };

        /// <summary>
        /// Load stop words from an external JSON file.
        /// </summary>
        public void LoadStopWords( string filePath )
        {
            try
            {
                ThrowIf.Empty( filePath, nameof( filePath ) );

                if( !File.Exists( filePath ) )
                {
                    var _message = "Stop words file not found.";
                    throw new FileNotFoundException( _message );
                }

                var _content = File.ReadAllText( filePath );
                _stopWords.Clear( );
                _stopWords = JsonConvert.DeserializeObject<HashSet<string>>( _content );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Tokenizes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public string[ ] TokenizeText( string text )
        {
            try
            {
                ThrowIf.Empty( text, nameof( text ) );
                var _split = text.Split( new[ ]
                {
                    ' ',
                    '.',
                    ',',
                    '!',
                    '?'
                }, StringSplitOptions.RemoveEmptyEntries );

                return _split?.Any( ) == true
                    ? _split
                    : default( string[ ] );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( string[ ] );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Normalizes the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public string NormalizeText( string text )
        {
            try
            {
                ThrowIf.Empty( text, nameof( text ) );
                var _lower = text.ToLower( );
                var _depunc = Regex.Replace( _lower, @"[^\w\s]", "" );
                var _despace = Regex.Replace( _depunc, @"\s+", " " );
                var _trim = _despace.Trim( );
                return !string.IsNullOrEmpty( _trim )
                    ? _trim
                    : string.Empty;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return string.Empty;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes the stop words.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        public string[ ] RemoveStopWords( string[ ] tokens )
        {
            try
            {
                ThrowIf.Null( tokens, nameof( tokens ) );
                var _stops = tokens?.Where( token => !_stopWords.Contains( token ) )?.ToArray( );
                return _stops?.Any( ) == true
                    ? _stops
                    : default( string[ ] );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( string[ ] );
            }
        }

        /// <summary>
        /// Converts a text file to a JSONL (JSON Lines) file.
        /// Each line in the text file is treated as a separate JSON object.
        /// </summary>
        /// <param name="inpath">Path to the input text file.</param>
        /// <param name="outpath">Path to the output JSONL file.</param>
        /// <param name="key">The key to assign to each line in the JSON object.</param>
        public void ConvertToJsonl( string inpath, string outpath, string key = "text" )
        {
            try
            {
                if( !File.Exists( inpath ) )
                {
                    var _message = "Input file not found.";
                    throw new FileNotFoundException( _message );
                }

                using var _reader = new StreamReader( inpath );
                using var _writer = new StreamWriter( outpath );
                string _line;
                while( ( _line = _reader.ReadLine( ) ) != null )
                {
                    var _jsonObject = new Dictionary<string, string>
                    {
                        {
                            key, _line
                        }
                    };

                    var _jsonLine = JsonConvert.SerializeObject( _jsonObject );
                    _writer.WriteLine( _jsonLine );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Stems the word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public string StemWord( string word )
        {
            try
            {
                // Basic stemming logic;
                ThrowIf.Empty( word, nameof( word ) );
                if( word.EndsWith( "ing" ) )
                {
                    return word.Substring( 0, word.Length - 3 );
                }

                if( word.EndsWith( "ed" ) )
                {
                    return word.Substring( 0, word.Length - 2 );
                }

                return word;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Generate N-grams from text.
        /// </summary>
        public IList<string> GenerateNgrams( string text, int n )
        {
            try
            {
                ThrowIf.Empty( text, nameof( text ) );
                ThrowIf.Negative( n, nameof( n ) );
                var _tokens = TokenizeText( text ).ToList(  );
                var _ngrams = new List<string>( );
                for( var _i = 0; _i <= ( _tokens.Count - n ); _i++ )
                {
                    _ngrams.Add( string.Join( " ", _tokens.Skip( _i ).Take( n ) ) );
                }

                return _ngrams?.Any( ) == true
                    ? _ngrams
                    : default( IList<string> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Remove URLs, emails, hashtags, and special characters.
        /// </summary>
        public string CleanText( string text )
        {
            try
            {
                ThrowIf.Empty( text, nameof( text ) );
                var _deurl = Regex.Replace( text, @"http\S+|www\S+", "" );
                var _demail = Regex.Replace( _deurl, @"\S+@\S+\.\S+", "" );
                var _dehash = Regex.Replace( _demail, @"#\w+", "" );
                var _dementions = Regex.Replace( _dehash, @"@\w+", "" );
                var _dechars = Regex.Replace( _dementions, @"[^a-zA-Z0-9\s]", "" );
                var _trim = _dechars.Trim(  );
                return !string.IsNullOrEmpty( _trim )
                    ? _trim
                    : string.Empty;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return string.Empty;
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