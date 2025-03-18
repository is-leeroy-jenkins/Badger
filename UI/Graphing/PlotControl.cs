// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-18-2025
// ******************************************************************************************
// <copyright file="PlotControl.cs" company="Terry D. Eppler">
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
//   PlotControl.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using ScottPlot;
    using ScottPlot.WPF;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.Windows.Controls.UserControl" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public class PlotControl : UserControl
    {
        /// <summary>
        /// The WPF plot
        /// </summary>
        private protected WpfPlot _wpfPlot;

        /// <summary>
        /// The graphing
        /// </summary>
        private protected IGraphing _graphing;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.PlotControl" /> class.
        /// </summary>
        public PlotControl( )
        {
            //InitializeComponent( );
            _wpfPlot = new WpfPlot( );
            var _graphManager = new GraphManager( _wpfPlot );
            _graphing = new Graphing( _graphManager );
        }

        /// <summary>
        /// Graphes the sine wave.
        /// </summary>
        public void GraphSineWave( double[ ] category, double[ ] values )
        {
            var _scatterData = new ScatterData( category, values, "Sine Wave" );
            _graphing.CreateScatter( _scatterData );
            _graphing.SetTitle( "Sine Wave Example" );
            _graphing.SetLabels( "X-Axis", "Y-Axis" );
        }

        /// <summary>
        /// Graphes the cosine wave.
        /// </summary>
        public void GraphCosineWave( double[ ] category, double[ ] values )
        {
            var _scatterData = new ScatterData( category, values, "Cosine Wave" );
            _graphing.CreateScatter( _scatterData );
            _graphing.SetTitle( "Cosine Wave Example" );
            _graphing.SetLabels( "X-Axis", "Y-Axis" );
        }
    }
}