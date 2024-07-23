// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-23-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-23-2024
// ******************************************************************************************
// <copyright file="RowView.cs" company="Terry D. Eppler">
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
//   RowView.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
    public class RowView : ViewBase, IView
    {
        /// <summary>
        /// The record
        /// </summary>
        private protected DataRow _record;

        /// <summary>
        /// The dimensions
        /// </summary>
        private protected IList<string> _dimensions;

        /// <summary>
        /// The measures
        /// </summary>
        private protected IList<string> _measures;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RowView"/> class.
        /// </summary>
        public RowView( )
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RowView"/> class.
        /// </summary>
        /// <param name="index">The identifier.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="measure">The measure.</param>
        /// <param name="value">The value.</param>
        public RowView( int index, string dimension,
            string measure, double value = 0 )
        {
            _index = index;
            _dimension = dimension;
            _measure = measure;
            _value = value;
            _dimensions = new[ ]
            {
                dimension
            };

            _measures = new[ ]
            {
                measure
            };
        }

        public RowView( int index, IList<string> dimensions,
            IList<string> measures, double value = 0 )
        {
            _index = index;
            _dimensions = dimensions;
            _dimension = dimensions[ 0 ];
            _measures = measures;
            _measure = measures[ 0 ];
            _value = value;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RowView"/> class.
        /// </summary>
        /// <param name="rowView">The row view.</param>
        public RowView( IView rowView )
        {
            _index = rowView.Index;
            _dimension = rowView.Dimension;
            _measure = rowView.Measure;
            _value = rowView.Value;
            _dimensions = new[ ]
            {
                rowView.Dimension
            };

            _measures = new[ ]
            {
                rowView.Measure
            };
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
    }
}