// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 2-3-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        2-3-2024
// ******************************************************************************************
// <copyright file="DataMetric.cs" company="Terry D. Eppler">
//    Badger is a Federal Budget, Finance, and Accounting application
//    for analysts with the US Environmental Protection Agency (US EPA).
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
//    Contact at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   DataMetric.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc />
    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "PublicConstructorInAbstractClass" ) ]
    [ SuppressMessage( "ReSharper", "ReturnTypeCanBeEnumerable.Local" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "ReturnTypeCanBeEnumerable.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public class DataMetric : DataCalculation, IDataMetric
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets the dates.
        /// </summary>
        /// <value>
        /// The dates.
        /// </value>
        public IList<string> Dates
        {
            get
            {
                return _dates;
            }
            private protected set
            {
                _dates = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data table.
        /// </summary>
        /// <value>
        /// The data table.
        /// </value>
        public DataTable DataTable
        {
            get
            {
                return _dataTable;
            }
            private protected set
            {
                _dataTable = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the numerics.
        /// </summary>
        /// <value>
        /// The numerics.
        /// </value>
        public IList<string> Numerics
        {
            get
            {
                return _numerics;
            }
            private protected set
            {
                _numerics = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public IList<string> Fields
        {
            get
            {
                return _fields;
            }
            private protected set
            {
                _fields = value;
            }
        }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public IDictionary<string, double> Values
        {
            get
            {
                return _values;
            }
            private protected set
            {
                _values = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataMetric"/> class.
        /// </summary>
        /// <param name="dataTable">
        /// The data table.
        /// </param>
        public DataMetric( DataTable dataTable )
        {
            _dataTable = dataTable;
            _fields = GetTextColumnNames( );
            _numerics = GetNumericColumnNames( );
            _dates = GetDateColumns( );
        }

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected IList<string> GetTextColumnNames( )
        {
            try
            {
                var _list = new List<string>( );
                var _count = _dataTable?.Columns?.Count;
                for( var _index = 0; _index < _count; _index++ )
                {
                    var _dataColumn = _dataTable.Columns[ _index ];
                    if( _dataColumn != null
                       && _dataColumn.DataType == typeof( string ) )
                    {
                        _list.Add( _dataColumn.ColumnName );
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }
    }
}