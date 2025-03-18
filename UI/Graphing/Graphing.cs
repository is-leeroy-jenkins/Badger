// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-18-2025
// ******************************************************************************************
// <copyright file="Graphing.cs" company="Terry D. Eppler">
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
//   Graphing.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.IGraphing" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class Graphing : IGraphing
    {
        /// <summary>
        /// The graph manager
        /// </summary>
        private protected IGraphManager _graphManager;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Graphing"/> class.
        /// </summary>
        public Graphing( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Graphing"/> class.
        /// </summary>
        /// <param name="graphManager">
        /// The graph manager.
        /// </param>
        public Graphing( IGraphManager graphManager )
        {
            _graphManager = graphManager;
        }

        /// <inheritdoc />
        /// <summary>
        /// Plots the scatter.
        /// </summary>
        /// <param name="pt">
        /// The scatter pt.
        /// </param>
        public void CreateScatter( ScatterData pt )
        {
            try
            {
                _graphManager.ClearPlot( );
                _graphManager.AddScatter( pt.Category, pt.Values, pt.Label );
                _graphManager.Refresh( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Plots the signal.
        /// </summary>
        /// <param name="pt">The signal pt.</param>
        public void CreateSignal( SignalData pt )
        {
            try
            {
                _graphManager.ClearPlot( );
                _graphManager.AddSignal( pt.Values, pt.Label );
                _graphManager.Refresh( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear( )
        {
            try
            {
                _graphManager.ClearPlot( );
                _graphManager.Refresh( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <param name="title">The title.</param>
        public void SetTitle( string title )
        {
            try
            {
                _graphManager.SetTitle( title );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the labels.
        /// </summary>
        /// <param name="xLabel">The x label.</param>
        /// <param name="yLabel">The y label.</param>
        public void SetLabels( string xLabel, string yLabel )
        {
            try
            {
                _graphManager.SetAxisLabels( xLabel, yLabel );
            }
            catch( Exception ex )
            {
                Fail( ex );
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