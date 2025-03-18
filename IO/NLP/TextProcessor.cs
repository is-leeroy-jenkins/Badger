// // <copyright file = "TextProcessor.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.ML;
    using Microsoft.ML.Transforms.Text;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UseCollectionExpression" ) ]
    [ SuppressMessage( "ReSharper", "ParameterTypeCanBeEnumerable.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    public class TextProcessor
    {
        /// <summary>
        /// The ml context
        /// </summary>
        private readonly MLContext _context = new MLContext( );

        /// <summary>
        /// The stop words
        /// </summary>
        private readonly HashSet<string> _stopWords = new HashSet<string>( new[ ]
        {
            "the",
            "is",
            "in",
            "and",
            "or",
            "on",
            "at",
            "of",
            "a",
            "an",
            "to",
            "for",
            "with",
            "this",
            "that",
            "it",
            "was"
        }, StringComparer.OrdinalIgnoreCase );

        /// <summary>
        /// The word2 vec model
        /// </summary>
        private readonly ITransformer _wordVectorModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextProcessor"/> class.
        /// </summary>
        public TextProcessor( )
        {
            _wordVectorModel = TrainWordVectors( );
        }

        /// <summary>
        /// Processes the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public IEnumerable<NlpResult> ProcessFile( string filePath )
        {
            using var _reader = new StreamReader( filePath );
            var _content = _reader.ReadToEnd( );
            _content = CleanText( _content );
            var sentences = _content.Split( new[ ]
            {
                '.'
            }, StringSplitOptions.RemoveEmptyEntries );

            foreach( var sentence in sentences )
            {
                var tokens = Tokenize( sentence );
                var filteredTokens = RemoveStopWords( tokens );
                var stemmedTokens = ApplyStemming( filteredTokens );
                var posTags = PerformPosTagging( filteredTokens );
                var namedEntities = PerformNamedEntityRecognition( filteredTokens );
                var sentiment = PerformSentimentAnalysis( sentence );
                var wordFrequencies = CalculateFrequencies( filteredTokens );
                var tfIdfScores = CalculateFrequencies( filteredTokens, wordFrequencies );
                var topics = PerformTopicModeling( sentence );
                var dependencyParse = PerformDependencyParsing( tokens );
                var wordEmbeddings = GenerateWordEmbeddings( filteredTokens );
                yield return new NlpResult
                {
                    Tokens = stemmedTokens,
                    PosTags = posTags,
                    NamedEntities = namedEntities,
                    Sentiment = sentiment,
                    WordFrequencies = wordFrequencies,
                    InverseFrequencyScores = tfIdfScores,
                    Topics = topics,
                    DependencyParse = dependencyParse,
                    WordEmbeddings = wordEmbeddings
                };
            }
        }

        /// <summary>
        /// Cleans the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private string CleanText( string text )
        {
            try
            {
                ThrowIf.Empty( text, nameof( text ) );
                var _first = text.ToLower( ).Trim( );
                var _second = Regex.Replace( _first, @"[^a-zA-Z0-9.!?\s]", " " );
                var _third = Regex.Replace( _second, @"(?<=[.?!])(?=\S)", " " );
                var _fourth = Regex.Replace( _third, @"\s+", " " );
                var _retval = Regex.Replace( _fourth, @"(\r?\n)+", " " );
                return !string.IsNullOrEmpty( _retval )
                    ? _retval
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Computes the tf idf.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="frequencies">The word frequencies.</param>
        /// <returns>
        /// Dict
        /// </returns>
        private IDictionary<string, double> CalculateFrequencies( string[ ] tokens,
            IDictionary<string, int> frequencies )
        {
            try
            {
                ThrowIf.Null( tokens, nameof( tokens ) );
                ThrowIf.Null( frequencies, nameof( frequencies ) );
                var _words = tokens.ToList(  ).Count;
                if( _words > 0 )
                {
                    var _freq = frequencies.ToDictionary( k => k.Key, p => ( double )p.Value / _words );

                    return _freq?.Any(  ) == true
                        ? _freq
                        : default( IDictionary<string, double> );
                }
                else
                {
                    return default( IDictionary<string, double> );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, double> );
            }
        }

        /// <summary>
        /// Tokenizes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private string[ ] Tokenize( string text )
        {
            try
            {
                ThrowIf.Empty( text, nameof( text ) );
                var _text = new List<TextData>
                {
                    new TextData
                    {
                        Text = text
                    }
                };

                var _dataView = _context.Data.LoadFromEnumerable( _text );
                var _pipeline = _context.Transforms.Text.TokenizeIntoWords( "Tokens", "Text" );
                var _model = _pipeline.Fit( _dataView );
                var _data = _model.Transform( _dataView );
                var _columns = _context.Data.CreateEnumerable<TokenizedText>( _data, false );
                return _columns.FirstOrDefault( )?.Tokens ?? Array.Empty<string>( );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
        }

        /// <summary>
        /// Removes the stop words.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        private string[ ] RemoveStopWords( string[ ] tokens )
        {
            try
            {
                ThrowIf.Null( tokens, nameof( tokens ) );
                var _rawData = tokens.Where( token => !_stopWords.Contains( token ) ).ToArray( );

                return _rawData?.Any(  ) == true
                    ? _rawData
                    : default( string[ ] );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
        }

        /// <summary>
        /// Applies the stemming.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        private string[ ] ApplyStemming( string[ ] tokens )
        {
            try
            {
                ThrowIf.Null( tokens, nameof( tokens ) );
                return tokens.Select( StemWord ).ToArray( );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
        }

        /// <summary>
        /// Stems the word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        private string StemWord( string word )
        {
            try
            {
                if( word.EndsWith( "ing" ) )
                {
                    return word[ ..^3 ];
                }

                if( word.EndsWith( "ed" ) )
                {
                    return word[ ..^2 ];
                }

                if( word.EndsWith( "s" )
                    && word.Length > 3 )
                {
                    return word[ ..^1 ];
                }

                return word;
            }
            catch( Exception ex )
            {
                Fail( ex  );
                return default( string );
            }
        }

        /// <summary>
        /// Trains the word2 vec.
        /// </summary>
        /// <returns></returns>
        private ITransformer TrainWordVectors( )
        {
            try
            {
                var _estimator = WordEmbeddingEstimator.PretrainedModelKind.SentimentSpecificWordEmbedding;

                var _rawData = _context.Data?.LoadFromEnumerable( new List<TextData>( ) );

                var _pipeline =
                    _context.Transforms?.Text.ApplyWordEmbedding( "WordEmbedding", "Text", _estimator );

                var _model = _pipeline?.Fit( _rawData );
                return _model != null
                    ? _model
                    : default( ITransformer );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITransformer );
            }
        }

        /// <summary>
        /// Generates the word embeddings.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        private IDictionary<string, float[ ]> GenerateWordEmbeddings( string[ ] tokens )
        {
            try
            {
                var data = _context.Data.LoadFromEnumerable( tokens.Select( t => new TextData
                {
                    Text = t
                } ) );

                var transformedData = _wordVectorModel.Transform( data );
                var embeddings = _context.Data
                    .CreateEnumerable<WordEmbeddingData>( transformedData, false )
                    .ToDictionary( e => e.Text, e => e.WordEmbedding );

                return embeddings;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, float[ ]> );
            }
        }

        /// <summary>
        /// Performs the position tagging.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        private string[ ] PerformPosTagging( string[ ] tokens )
        {
            try
            {
                ThrowIf.Empty( tokens, nameof( tokens ) );
                return tokens.Select( token => token.EndsWith( "ing" )
                    ? "VERB"
                    : token.EndsWith( "ed" )
                        ? "VERB"
                        : char.IsUpper( token[ 0 ] )
                            ? "NOUN"
                            : "OTHER" ).ToArray( );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
        }

        /// <summary>
        /// Performs the named entity recognition.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        private string[ ] PerformNamedEntityRecognition( string[ ] tokens )
        {
            var _entity = tokens.Where( t => char.IsUpper( t[ 0 ] ) ).ToArray( );
            return _entity;
        }

        /// <summary>
        /// Performs the sentiment analysis.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <returns></returns>
        private float PerformSentimentAnalysis( string sentence )
        {
            return sentence.Contains( "good" ) || sentence.Contains( "excellent" )
                ? 1.0f
                : sentence.Contains( "bad" ) || sentence.Contains( "terrible" )
                    ? -1.0f
                    : 0.0f;
        }

        /// <summary>
        /// Gets the word frequencies.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        private IDictionary<string, int> CalculateFrequencies( string[ ] tokens )
        {
            try
            {
                ThrowIf.Null( tokens, nameof( tokens ) );
                var _retval = tokens.GroupBy( t => t )
                    .ToDictionary( g => g.Key, g => g.Count( ) );

                return _retval?.Any(  ) == true
                    ? _retval
                    : default( IDictionary<string, int> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, int> );
            }
        }

        /// <summary>
        /// Performs the topic modeling.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private string[ ] PerformTopicModeling( string text )
        {
            try
            {
                ThrowIf.Null( text, nameof( text ) );
                if( text.Contains( "technology" )
                    || text.Contains( "software" ) )
                {
                    return new[ ]
                    {
                        "Tech"
                    };
                }

                if( text.Contains( "finance" )
                    || text.Contains( "investment" ) )
                {
                    return new[ ]
                    {
                        "Finance"
                    };
                }

                if( text.Contains( "health" )
                    || text.Contains( "medicine" ) )
                {
                    return new[ ]
                    {
                        "Health"
                    };
                }

                return new[ ]
                {
                    "General"
                };
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
        }

        /// <summary>
        /// Performs the dependency parsing.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        private string[ ] PerformDependencyParsing( string[ ] tokens )
        {
            try
            {
                ThrowIf.Null( tokens, nameof( tokens ) );
                var _retval = tokens.Where( t => t.Length > 3 ).Select ( t => t ).ToArray( );
                return _retval?.Length > 0
                    ? _retval
                    : Array.Empty<string>( );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string[ ] );
            }
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