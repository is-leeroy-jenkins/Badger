// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-18-2025
// ******************************************************************************************
// <copyright file="IGraphManager.cs" company="Terry D. Eppler">
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
//   IGraphManager.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public interface IGraphManager
    {
        /// <summary>
        /// Adds the scatter.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="values">The values.</param>
        /// <param name="label">The label.</param>
        void AddScatter( double[ ] category, double[ ] values, string label = null );

        /// <summary>
        /// Adds the signal.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="label">The label.</param>
        void AddSignal( double[ ] values, string label = null );

        /// <summary>
        /// Clears the plot.
        /// </summary>
        void ClearPlot( );

        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <param name="title">The title.</param>
        void SetTitle( string title );

        /// <summary>
        /// Sets the axis labels.
        /// </summary>
        /// <param name="xLabel">The x label.</param>
        /// <param name="yLabel">The y label.</param>
        void SetAxisLabels( string xLabel, string yLabel );

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        void Refresh( );
    }
}