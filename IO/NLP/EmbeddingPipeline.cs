// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 02-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        02-18-2025
// ******************************************************************************************
// <copyright file="EmbeddingPipeline.cs" company="Terry D. Eppler">
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
//   EmbeddingPipeline.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.ML;

    /// <summary>
    /// Encapsulates the logic for:
    /// 1) Loading text into ML.NET
    /// 2) Building and applying three transformations:
    ///    - FeaturizeText      => Embeddings
    ///    - ProduceWordBags    => Bag-of-Words
    ///    - TokenizeIntoWords  => Tokens
    /// </summary>
    [ SuppressMessage( "ReSharper", "PreferConcreteValueOverDefault" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class EmbeddingPipeline
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly MLContext _context;

        /// <summary>
        /// The file path
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Constructor requires an MLContext and the path to the text file.
        /// </summary>
        public EmbeddingPipeline( MLContext context, string filePath )
        {
            _context = context;
            _filePath = filePath;
        }

        /// <summary>
        /// Loads text data into an IDataView from the specified file.
        /// </summary>
        private IDataView LoadData( )
        {
            try
            {
                var _data = _context.Data;
                var _view = _data.LoadFromTextFile<TextData>( _filePath, '\t', false );
                return _view;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDataView );
            }
        }

        /// <summary>
        /// Fits the pipeline to the data, transforming it into
        /// EmbeddingFeatures, BagOfWordsFeatures, and Tokens columns.
        /// </summary>
        public IDataView TransformData( IDataView dataView )
        {
            try
            {
                ThrowIf.Null( dataView, nameof( dataView ) );
                var pipeline = BuildPipeline( );
                var model = pipeline.Fit( dataView );
                return model.Transform( dataView );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDataView );
            }
        }

        /// <summary>
        /// Builds an ML pipeline that converts text into embedding vectors.
        /// </summary>
        private IEstimator<ITransformer> BuildPipeline( )
        {
            try
            {
                var _transforms = _context.Transforms;
                var _text = _transforms.Text;
                var _features = _text.FeaturizeText( "EmbeddingFeatures", nameof( TextData.Text ) );
                var _words = _text.ProduceWordBags( "WordFeatures", nameof( TextData.Text )  );
                var _tokens = _text.TokenizeIntoWords( "Tokens", nameof( TextData.Text )  );
                _features.Append( _words );
                _features.Append( _tokens );
                return _features;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEstimator<ITransformer> );
            }
        }

        /// <summary>
        /// Converts the transformed IDataView into PipelineOutput objects.
        /// </summary>
        public TokenizedVector[ ] GetPipelineOutputs( IDataView transformedData )
        {
            try
            {
                ThrowIf.Null( transformedData, nameof( transformedData ) );
                return _context.Data.CreateEnumerable<TokenizedVector>( transformedData, false ).ToArray( );
            }
            catch( Exception ex )
            {
                Fail( ex  );
                return default( TokenizedVector[ ] );
            }
        }

        /// <summary>
        /// Trains the pipeline and returns the transformed data (embedding vectors).
        /// </summary>
        public IDataView GenerateEmbeddings( )
        {
            try
            {
                var dataView = LoadData( );
                var pipeline = BuildPipeline( );
                var model = pipeline.Fit( dataView );
                return model.Transform( dataView );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDataView );
            }
        }

        /// <summary>
        /// Converts the transformed IDataView into an array of TokenizedVector objects.
        /// </summary>
        public TokenizedVector[ ] GetEmbeddingVectors( IDataView data )
        {
            try
            {
                ThrowIf.Null( data, nameof( data ) );
                var _data = _context.Data;
                var _tokens = _data.CreateEnumerable<TokenizedVector>( data, false );
                var _vectors = _tokens.ToArray( );
                return _vectors;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( TokenizedVector[ ] );
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