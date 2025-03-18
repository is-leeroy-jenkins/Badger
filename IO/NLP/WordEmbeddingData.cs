
namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class WordEmbeddingData
    {
        /// <summary>
        /// The text
        /// </summary>
        private protected string _text;

        /// <summary>
        /// The word embedding
        /// </summary>
        private protected float[ ] _wordEmbedding;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="WordEmbeddingData"/> class.
        /// </summary>
        public WordEmbeddingData( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="WordEmbeddingData"/> class.
        /// </summary>
        /// <param name="wordEmbedding">The word embedding.</param>
        public WordEmbeddingData( float[ ] wordEmbedding )
        {
            _wordEmbedding = wordEmbedding;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        /// <summary>
        /// Gets or sets the word embedding.
        /// </summary>
        /// <value>
        /// The word embedding.
        /// </value>
        public float[ ] WordEmbedding
        {
            get
            {
                return _wordEmbedding;
            }
            set
            {
                _wordEmbedding = value;
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
