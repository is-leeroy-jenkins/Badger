// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-18-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-18-2024
// ******************************************************************************************
// <copyright file="View.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporitng application
//    for EPA Analysts.
//    Copyright ©  2024  Terry Eppler
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
//    You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   View.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantJumpStatement" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class View
    {
        /// <summary>
        /// The data row
        /// </summary>
        private protected double _index;

        /// <summary>
        /// The name
        /// </summary>
        private protected string _category;

        /// <summary>
        /// The measure
        /// </summary>
        private protected string _measure;

        /// <summary>
        /// The value
        /// </summary>
        private protected double _value;

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public double Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Measure
        {
            get
            {
                return _measure;
            }
            set
            {
                _measure = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="View"/> class.
        /// </summary>
        public View( )
        {
            _index = 0.0;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="View"/> class.
        /// </summary>
        /// <param name = "index" > </param>
        /// <param name="category">The name.</param>
        /// <param name = "measure" > </param>
        /// <param name="value">The value.</param>
        public View( int index, string category, string measure, double value = 0 ) 
            : this( )
        {
            _index = index;
            _category = category;
            _measure = measure;
            _value = value;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="View"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public View( View view )
        {
            _index = view.Index;
            _category = view.Category;
            _measure = view.Measure;
            _value = view.Value;
        }

        /// <summary>
        /// Deconstructs the specified name.
        /// </summary>
        /// <param name = "index" > </param>
        /// <param name="category">The name.</param>
        /// <param name = "measure" > </param>
        /// <param name="value">The value.</param>
        public void Deconstruct( out double index, out string category, out string measure, out double value )
        {
            index = _index;
            category = _category;
            measure = _measure;
            value = _value;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" />
        /// that represents this instance.
        /// </returns>
        public override string ToString( )
        {
            return _value != 0.0
                ? _value.ToString( "N0" )
                : "0.0";
        }

        /// <summary>
        /// Fails the specified _ex.
        /// </summary>
        /// <param name="_ex">The _ex.</param>
        private protected void Fail( Exception _ex )
        {
            var _error = new ErrorWindow( _ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}