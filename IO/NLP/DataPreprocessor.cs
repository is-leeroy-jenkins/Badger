// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-16-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-16-2025
// ******************************************************************************************
// <copyright file="DataPreprocessor.cs" company="Terry D. Eppler">
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
//   DataPreprocessor.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Microsoft.ML;
    using Microsoft.ML.Transforms.Text;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public class DataPreprocessor
    {
        /// <summary>
        /// The ml context
        /// </summary>
        private protected readonly MLContext _context;

        /// <summary>
        /// The pipeline
        /// </summary>
        private protected IEstimator<ITransformer> _pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPreprocessor"/> class.
        /// </summary>
        public DataPreprocessor( )
        {
            _context = new MLContext( );
            _pipeline = _context.Transforms.CopyColumns( "Features", "RawFeatures" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Badger.DataPreprocessor" /> class.
        /// </summary>
        /// <param name="inputColumnName">Name of the input column.</param>
        /// <param name="outputColumnName">Name of the output column.</param>
        public DataPreprocessor( string inputColumnName, string outputColumnName )
            : this( )
        {
            _pipeline = _context.Transforms.CopyColumns( "Features", "RawFeatures" );
        }

        /// <summary>
        /// Handles missing values by replacing them
        /// with the mean (for numerical) or mode (for categorical).
        /// </summary>
        public DataPreprocessor HandleMissingValues( string columnName )
        {
            try
            {
                ThrowIf.Empty( columnName, nameof( columnName ) );
                var _transforms = _context.Transforms;
                var _missingValues = _transforms.ReplaceMissingValues( columnName );
                _pipeline.Append( _missingValues );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Applies Z-score normalization to numerical features.
        /// </summary>
        public DataPreprocessor Standardize( string columnName )
        {
            try
            {
                ThrowIf.Empty( columnName, nameof( columnName ) );
                var _transforms = _context.Transforms;
                var _name = _transforms.NormalizeMeanVariance( columnName );
                _pipeline.Append( _name );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Applies Min-Max Normalization to numerical features.
        /// </summary>
        public DataPreprocessor Normalize( string columnName )
        {
            try
            {
                ThrowIf.Empty( columnName, nameof( columnName ) );
                var _transforms = _context.Transforms;
                var _minMax = _transforms.NormalizeMinMax( columnName );
                _pipeline.Append( _minMax );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Tokenizes text into words.
        /// </summary>
        public DataPreprocessor TokenizeWords( string columnName )
        {
            try
            {
                ThrowIf.Empty( columnName, nameof( columnName ) );
                var _transforms = _context.Transforms;
                var _text = _transforms.Text;
                var _words = _text.TokenizeIntoWords( columnName );
                _pipeline.Append( _words );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Removes stop words from tokenized text.
        /// </summary>
        public DataPreprocessor RemoveStopWords( string columnName )
        {
            try
            {
                ThrowIf.Empty( columnName, nameof( columnName ) );
                var _transforms = _context.Transforms;
                var _words = _transforms.Text;
                var _estimator = _words.RemoveStopWords( columnName );
                _pipeline.Append(  _estimator );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Generates n-grams from tokenized text.
        /// </summary>
        public DataPreprocessor ApplyNGrams( string  outputColumn, string inputColumn, int length = 2 )
        {
            try
            {
                ThrowIf.Empty( outputColumn, nameof( outputColumn ) );
                ThrowIf.Empty( inputColumn, nameof( inputColumn ) );
                var _transforms = _context.Transforms;
                var _words = _transforms.Text;
                var _ngrams = _words.ProduceNgrams( outputColumn, inputColumn, length );
                _pipeline.Append( _ngrams );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Applies Word Embeddings (e.g., GloVe, FastText).
        /// </summary>
        public DataPreprocessor ApplyWordEmbeddings( string outputColumn, string inputColumn )
        {
            try
            {
                ThrowIf.Empty( outputColumn, nameof( outputColumn ) );
                ThrowIf.Empty( inputColumn, nameof( inputColumn ) );
                var _estimator = WordEmbeddingEstimator.PretrainedModelKind.SentimentSpecificWordEmbedding;
                var _text = _context.Transforms.Text;
                var _embedding = _text.ApplyWordEmbedding( outputColumn, inputColumn, _estimator );
                _pipeline.Append( _embedding );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Converts categorical variables into one-hot encoded vectors.
        /// </summary>
        public DataPreprocessor OneHotEncode( string columnName )
        {
            try
            {
                ThrowIf.Empty( columnName, nameof( columnName ) );
                var _transforms = _context.Transforms;
                var _category = _transforms.Categorical;
                var _encoding = _category.OneHotEncoding( columnName );
                _pipeline.Append( _encoding );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Featurizes text using TF-IDF (useful for NLP tasks).
        /// </summary>
        public DataPreprocessor FeaturizeTextInverseFrequency( string columnName, string prefix = "f_" )
        {
            try
            {
                ThrowIf.Empty( columnName, nameof( columnName ) );
                var _transforms = _context.Transforms;
                var _features = _transforms.Text.FeaturizeText( prefix, columnName );
                _pipeline.Append( _features );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Applies Principal Component Analysis (PCA) for dimensionality reduction.
        /// </summary>
        public DataPreprocessor ApplyComponentAnalysis( string outputColumn, string inputColumn, string label,
            int rank = 5 )
        {
            try
            {
                ThrowIf.Empty( outputColumn, nameof( outputColumn ) );
                ThrowIf.Empty( inputColumn, nameof( inputColumn ) );
                ThrowIf.Empty( label, nameof( label ) );
                var _transforms =  _context.Transforms;
                var _components = _transforms.ProjectToPrincipalComponents( outputColumn, inputColumn, label, rank );
                _pipeline.Append( _components );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Selects top N most relevant features using mutual information.
        /// </summary>
        public DataPreprocessor SelectTopFeatures( string outputColumn, string inputColumn, string label,
            int topN = 10 )
        {
            try
            {
                ThrowIf.Empty( outputColumn, nameof( outputColumn ) );
                ThrowIf.Empty( inputColumn, nameof( inputColumn ) );
                ThrowIf.Empty( label, nameof( label ) );
                var _transforms = _context.Transforms;
                var _feature = _transforms.FeatureSelection;
                var _retval = _feature.SelectFeaturesBasedOnMutualInformation( outputColumn, inputColumn, label, topN );
                _pipeline.Append( _retval );
                return this;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataPreprocessor );
            }
        }

        /// <summary>
        /// Builds and fits the transformation pipeline.
        /// </summary>
        public ITransformer Build( IDataView dataView )
        {
            try
            {
                return _pipeline.Fit( dataView );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITransformer );
            }
        }

        /// <summary>
        /// Transforms new data using the built pipeline.
        /// </summary>
        public IDataView Transform( ITransformer model, IDataView dataView )
        {
            try
            {
                ThrowIf.Null( model, nameof( model ) );
                ThrowIf.Null( dataView, nameof( dataView )  );
                return model.Transform( dataView );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDataView );
            }
        }

        /// <summary>
        /// Saves the trained transformer to a file.
        /// </summary>
        public void SaveTransformer( ITransformer model, string filePath )
        {
            try
            {
                ThrowIf.Null( model, nameof( model ) );
                ThrowIf.Empty( filePath, nameof( filePath ) );
                using var fileStream = new FileStream( filePath, FileMode.Create );
                _context.Model.Save( model, null, fileStream );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Loads a pre-trained transformer from a file.
        /// </summary>
        public ITransformer LoadTransformer( string filePath )
        {
            try
            {
                ThrowIf.Empty( filePath, nameof( filePath ) );
                using var fileStream = new FileStream( filePath, FileMode.Open, FileAccess.Read );
                return _context.Model.Load( fileStream, out var _ );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITransformer );
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