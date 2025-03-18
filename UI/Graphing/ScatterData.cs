// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-18-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-18-2025
// ******************************************************************************************
// <copyright file="ScatterData.cs" company="Terry D. Eppler">
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
//   ScatterData.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ScatterData : PropertyChangedBase
    {
        /// <summary>
        /// The category
        /// </summary>
        private protected double[ ] _category;

        /// <summary>
        /// The values
        /// </summary>
        private protected double[ ] _values;

        /// <summary>
        /// The label
        /// </summary>
        private protected string _label;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ScatterData" /> class.
        /// </summary>
        public ScatterData( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterData"/> class.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="values">The values.</param>
        /// <param name="label">The label.</param>
        public ScatterData( double[ ] category, double[ ] values, string label = null )
        {
            _category = category;
            _values = values;
            _label = label;
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public double[ ] Category
        {
            get
            {
                return _category;
            }
            set
            {
                if( _category != value )
                {
                    _category = value;
                    OnPropertyChanged( nameof( Category ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public double[ ] Values
        {
            get
            {
                return _values;
            }
            set
            {
                if( _values != value )
                {
                    _values = value;
                    OnPropertyChanged( nameof( Values ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                if( _label != value )
                {
                    _label = value;
                    OnPropertyChanged( nameof( Label ) );
                }
            }
        }
    }
}