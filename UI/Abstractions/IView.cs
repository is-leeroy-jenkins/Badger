// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-01-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-01-2024
// ******************************************************************************************
// <copyright file="IView.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts
//    based on WPF, NET6.0, and written in C-Sharp.
// 
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
//   IView.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    /// <summary>
    /// 
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Tuples this instance.
        /// </summary>
        /// <returns></returns>
        ( int Index, string Name, object Value ) Tuple( );

        /// <inheritdoc />
        /// <summary>
        /// Deconstructs the specified identifier.
        /// </summary>
        /// <param name="index">The identifier.</param>
        /// <param name="name">The x.</param>
        /// <param name="value">The y.</param>
        void Deconstruct( out double index, out string name, out object value );

        /// <inheritdoc />
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" />
        /// that represents this instance.
        /// </returns>
        string ToString( );

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        int Index { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        object Value { get; set; }
    }
}