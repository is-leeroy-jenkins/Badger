// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-20-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-20-2024
// ******************************************************************************************
// <copyright file="DataArgs.cs" company="Terry D. Eppler">
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
//   DataArgs.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.StateData" />
    /// <seealso cref="T:Badger.IStateTransfer" />
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    [ SuppressMessage( " ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class DataArgs : StateData, IStateTransfer
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the selected table.
        /// </summary>
        /// <value>
        /// The selected table.
        /// </value>
        public string SelectedTable
        {
            get
            {
                return _selectedTable;
            }
            set
            {
                _selectedTable = value;
            }
        }

        /// <summary>
        /// Gets or sets the SQL query.
        /// </summary>
        /// <value>
        /// The SQL query.
        /// </value>
        public string SqlQuery
        {
            get
            {
                return _sqlQuery;
            }
            set
            {
                _sqlQuery = value;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        public Provider Provider
        {
            get
            {
                return _provider;
            }
            set
            {
                _provider = value;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
            }
        }

        /// <summary>
        /// Gets or sets the data filter.
        /// </summary>
        /// <value>
        /// The data filter.
        /// </value>
        public IDictionary<string, object> Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected columns.
        /// </summary>
        /// <value>
        /// The selected columns.
        /// </value>
        public IList<string> SelectedColumns
        {
            get
            {
                return _selectedColumns;
            }
            set
            {
                _selectedColumns = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the selected fields.
        /// </summary>
        /// <value>
        /// The selected fields.
        /// </value>
        public IList<string> SelectedFields
        {
            get
            {
                return _selectedFields;
            }
            set
            {
                _selectedFields = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the selected numerics.
        /// </summary>
        /// <value>
        /// The selected numerics.
        /// </value>
        public IList<string> SelectedNumerics
        {
            get
            {
                return _selectedNumerics;
            }
            set
            {
                _selectedNumerics = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the selected dates.
        /// </summary>
        /// <value>
        /// The selected dates.
        /// </value>
        public IList<DateTime> SelectedDates
        {
            get
            {
                return _selectedDates;
            }
            set
            {
                _selectedDates = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataArgs"/> class.
        /// </summary>
        public DataArgs( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataArgs"/> class.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public DataArgs( DataArgs args )
        {
            _source = args.Source;
            _provider = args.Provider;
            _filter = args.Filter;
            _selectedTable = args.SelectedTable;
            _sqlQuery = args.SqlQuery;
            _selectedColumns = args.SelectedColumns;
            _selectedFields = args.SelectedFields;
            _selectedNumerics = args.SelectedNumerics;
            _selectedDates = args.SelectedDates;
        }

        /// <summary>
        /// Deconstructs the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="table"> </param>
        /// <param name="filter">The filter.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="numerics">The numerics.</param>
        /// <param name="dates">The dates.</param>
        public void Deconstruct( out Source source, out Provider provider, out string table,
            out IDictionary<string, object> filter, out IList<string> columns,
            out IList<string> fields, out IList<string> numerics, out IList<DateTime> dates )
        {
            source = _source;
            provider = _provider;
            table = _selectedTable;
            filter = _filter;
            columns = _selectedColumns;
            fields = _selectedFields;
            numerics = _selectedNumerics;
            dates = _selectedDates;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear( )
        {
            try
            {
                _source = default( Source );
                _provider = default( Provider );
                _selectedTable = string.Empty;
                _filter = default( IDictionary<string, object> );
                _sqlQuery = string.Empty;
                _selectedColumns = default( IList<string> );
                _selectedFields = default( IList<string> );
                _selectedNumerics = default( IList<string> );
                _selectedDates = default( IList<DateTime> );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}