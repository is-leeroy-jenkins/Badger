// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-18-2025
// ******************************************************************************************
// <copyright file="Grapher.cs" company="Terry D. Eppler">
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
//   Grapher.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using ScottPlot.WPF;
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class GraphManager : IGraphManager
    {
        /// <summary>
        /// The WPF plot
        /// </summary>
        private readonly WpfPlot _wpfPlot;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="GraphManager" /> class.
        /// </summary>
        public GraphManager( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphManager"/> class.
        /// </summary>
        /// <param name="wpfPlot">The WPF plot.</param>
        public GraphManager( WpfPlot wpfPlot )
        {
            _wpfPlot = wpfPlot;
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds the scatter.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="values">The values.</param>
        /// <param name="label">The label.</param>
        public void AddScatter( double[ ] category, double[ ] values, string label )
        {
            try
            {
                ThrowIf.Negative( category, nameof( category ) );
                _wpfPlot.Plot.Add.Scatter( category, values );
                _wpfPlot.Plot.Title( label );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds the signal.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="label">The label.</param>
        public void AddSignal( double[ ] values, string label )
        {
            try
            {
                _wpfPlot.Plot.Add.Signal( values );
                _wpfPlot.Plot.Title( label );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Clears the plot.
        /// </summary>
        public void ClearPlot( )
        {
            _wpfPlot.Plot.Clear( );
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
                ThrowIf.Empty( title, nameof( title ) );
                _wpfPlot.Plot.Title( title );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the axis labels.
        /// </summary>
        /// <param name="xLabel">The x label.</param>
        /// <param name="yLabel">The y label.</param>
        public void SetAxisLabels( string xLabel, string yLabel )
        {
            try
            {
                ThrowIf.Empty( yLabel, nameof( yLabel ) );
                ThrowIf.Empty( xLabel, nameof( xLabel ) );
                _wpfPlot.Plot.XLabel( xLabel );
                _wpfPlot.Plot.YLabel( yLabel );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh( )
        {
            _wpfPlot.Refresh( );
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