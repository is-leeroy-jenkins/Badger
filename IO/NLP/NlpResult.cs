
using System.Diagnostics.CodeAnalysis;

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    public class NlpResult
    {
        /// <summary>
        /// The tokens
        /// </summary>
        private string[ ] _tokens;

        /// <summary>
        /// The position tags
        /// </summary>
        private string[ ] _posTags;

        /// <summary>
        /// The named entities
        /// </summary>
        private string[ ] _namedEntities;

        /// <summary>
        /// The sentiment
        /// </summary>
        private float _sentiment;

        /// <summary>
        /// The inverse frequency scores
        /// </summary>
        private IDictionary<string, double> _inverseFrequencyScores;

        /// <summary>
        /// The word frequencies
        /// </summary>
        private IDictionary<string, int> _wordFrequencies;

        /// <summary>
        /// The topics
        /// </summary>
        private string[ ] _topics;

        /// <summary>
        /// The dependency parse
        /// </summary>
        private string[ ] _dependencyParse;

        /// <summary>
        /// The word embeddings
        /// </summary>
        private protected IDictionary<string, float[]> _wordEmbeddings;

        /// <summary>
        /// The data
        /// </summary>
        private protected IDictionary<string, object> _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="NlpResult"/> class.
        /// </summary>
        public NlpResult( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NlpResult"/> class.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="posTag">The position tag.</param>
        /// <param name="dependencyParse">The dependency parse.</param>
        /// <param name="wordEmbeddings">The word embeddings.</param>
        /// <param name="topics">The topics.</param>
        public NlpResult(string[] tokens, string[] posTag,string[] dependencyParse, 
            IDictionary<string, float[]> wordEmbeddings, string[] topics )
        {
            _topics = topics;
            _dependencyParse = dependencyParse;
            _wordEmbeddings = wordEmbeddings;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NlpResult"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public NlpResult( NlpResult result)
        {
            _tokens = result.Tokens;
            _topics = result.Topics;
        }

        /// <summary>
        /// Gets or sets the tokens.
        /// </summary>
        /// <value>
        /// The tokens.
        /// </value>
        public string[ ] Tokens
        {
            get
            {
                return _tokens;
            }
            set
            {
                _tokens = value;
            }
        }

        /// <summary>
        /// Gets or sets the position tags.
        /// </summary>
        /// <value>
        /// The position tags.
        /// </value>
        public string[ ] PosTags
        {
            get
            {
                return _posTags;
            }
            set
            {
                _posTags = value;
            }
        }

        /// <summary>
        /// Gets or sets the named entities.
        /// </summary>
        /// <value>
        /// The named entities.
        /// </value>
        public string[ ] NamedEntities
        {
            get
            {
                return _namedEntities;
            }
            set
            {
                _namedEntities = value;
            }
        }

        /// <summary>
        /// Gets or sets the sentiment.
        /// </summary>
        /// <value>
        /// The sentiment.
        /// </value>
        public float Sentiment
        {
            get
            {
                return _sentiment;
            }
            set
            {
                _sentiment = value;
            }
        }

        /// <summary>
        /// Gets or sets the word frequencies.
        /// </summary>
        /// <value>
        /// The word frequencies.
        /// </value>
        public IDictionary<string, int> WordFrequencies
        {
            get
            {
                return _wordFrequencies;
            }
            set
            {
                _wordFrequencies = value;
            }
        }

        /// <summary>
        /// Gets or sets the inverse frequency scores.
        /// </summary>
        /// <value>
        /// The inverse frequency scores.
        /// </value>
        public IDictionary<string, double> InverseFrequencyScores
        {
            get
            {
                return _inverseFrequencyScores;
            }
            set
            {
                _inverseFrequencyScores = value;
            }
        }

        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        /// <value>
        /// The topics.
        /// </value>
        public string[ ] Topics
        {
            get
            {
                return _topics;
            }
            set
            {
                _topics = value;
            }
        }

        /// <summary>
        /// Gets or sets the dependency parse.
        /// </summary>
        /// <value>
        /// The dependency parse.
        /// </value>
        public string[ ] DependencyParse
        {
            get
            {
                return _dependencyParse;
            }
            set
            {
                _dependencyParse = value;
            }
        }

        /// <summary>
        /// Gets or sets the word embeddings.
        /// </summary>
        /// <value>
        /// The word embeddings.
        /// </value>
        public IDictionary<string, float[ ]> WordEmbeddings
        {
            get
            {
                return _wordEmbeddings;
            }
            set
            {
                _wordEmbeddings = value;
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
