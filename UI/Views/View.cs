// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="RowModel.cs" company="Terry D. Eppler">
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
//   RowModel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.View" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class View : Info, IView
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="View"/> class.
        /// </summary>
        public View( )
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="View"/> class.
        /// </summary>
        /// <param name="index">The identifier.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="measure">The measure.</param>
        /// <param name="value">The value.</param>
        public View( int index, string dimension,
            string measure, double value = 0 ) 
        {
            _index = index;
            _dimension = dimension;
            _measure = measure;
            _value = value;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="View"/> class.
        /// </summary>
        /// <param name="view">The row view.</param>
        public View( IView view )
        {
            _index = view.Index;
            _dimension = view.Dimension;
            _measure = view.Measure;
            _value = view.Value;
        }

        /// <inheritdoc />
        /// <summary>
        /// Deconstructs the specified identifier.
        /// </summary>
        /// <param name="index">The identifier.</param>
        /// <param name="dimension">The x.</param>
        /// <param name="measure"></param>
        /// <param name="value">The y.</param>
        public override void Deconstruct( out double index, out string dimension,
            out string measure, out double value )
        {
            index = _index;
            dimension = _dimension;
            measure = _measure;
            value = _value;
        }

        /// <inheritdoc />
        /// <summary>
        /// Tuples this instance.
        /// </summary>
        /// <returns></returns>
        public (int Index, string Dimension, string Measure, double Value) Tuple( )
        {
            return ( _index, _dimension, _measure, _value );
        }

        /// <inheritdoc />
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" />
        /// that represents this instance.
        /// </returns>
        public override string ToString( )
        {
            return _value.ToString( "N2" );
        }
    }
}