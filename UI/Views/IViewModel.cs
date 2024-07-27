// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="IViewModel.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  2024  Terry D. Eppler
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   IViewModel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface IViewModel
    {
        /// <inheritdoc />
        /// <summary>
        /// Adds the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="dimension">The category.</param>
        /// <param name="measure"> </param>
        /// <param name="value">The value.</param>
        void Add( int index, string dimension, string measure, double value = 0 );

        /// <inheritdoc />
        /// <summary>
        /// Adds the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        new void Add( IView view );

        /// <inheritdoc />
        /// <summary>
        /// Removes the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        new void Remove( IView view );

        /// <inheritdoc />
        /// <summary>
        /// Cycles this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerator<IView> IterItems( );
    }
}