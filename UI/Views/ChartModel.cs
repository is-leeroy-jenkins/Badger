// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-18-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-18-2024
// ******************************************************************************************
// <copyright file="ChartModel.cs" company="Terry D. Eppler">
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
//   ChartModel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

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
    public class ChartModel : ObservableCollection<DataRow>
    {
        /// <summary>
        /// The columns
        /// </summary>
        private readonly IList<string> _columns;

        /// <summary>
        /// The count
        /// </summary>
        private protected int _count;

        /// <summary>
        /// The current
        /// </summary>
        private protected DataRow _current;

        /// <summary>
        /// The data
        /// </summary>
        private protected ObservableCollection<DataRow> _data;

        /// <summary>
        /// The index
        /// </summary>
        private protected int _index;

        /// <summary>
        /// The data
        /// </summary>
        private protected IList<DataRow> _items;

        /// <summary>
        /// The table name
        /// </summary>
        private protected string _tableName;

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index
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
        /// Gets the number of elements actually contained in the
        /// <see cref="T:System.Collections.ObjectModel.Collection`1" />.
        /// </summary>
        public new int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public DataRow Current
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public new IList<DataRow> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public ObservableCollection<DataRow> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChartModel" /> class.
        /// </summary>
        public ChartModel( )
            : base( )
        {
            _index = 0;
            _count = 0;
            _data = new ObservableCollection<DataRow>( );
            _items = new List<DataRow>( );
            _columns = new List<string>( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChartModel" /> class.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public ChartModel( DataTable dataTable )
            : this( )
        {
            _data = dataTable?.ToObservable( );
            _items = _data?.ToList( );
            _current = _data?[ _index ];
            _count = dataTable?.Rows?.Count ?? 0;
            _tableName = _current?.Table?.TableName;
            _columns = _current?.Table?.GetColumnNames( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChartModel" /> class.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        public ChartModel( IEnumerable<DataRow> dataRows )
            : this( )
        {
            _data = dataRows?.ToObservable( );
            _items = dataRows?.ToList( );
            _current = _data?[ _index ];
            _count = dataRows?.Count( ) ?? 0;
            _tableName = _current?.Table?.TableName;
            _columns = _current?.Table?.GetColumnNames( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChartModel" /> class.
        /// </summary>
        /// <param name="record">The record.</param>
        public ChartModel( DataRow record ) 
            : this( )
        {
            _data[ _index ] = record;
            _items.Add( record );
            _current = record;
            _count = _data.Count;
            _tableName = record.Table?.TableName;
            _columns = record?.Table?.GetColumnNames( );
        }

        /// <summary>
        /// Iterates over the rows in the ObservableCollection.
        /// </summary>
        /// <returns>
        /// IEnumerator( DataRow )
        /// </returns>
        public IEnumerator<DataRow> IterRows( )
        {
            foreach( var _item in _data )
            {
                yield return _item;
            }
        }

        /// <summary>
        /// Moves the first.
        /// </summary>
        public void MoveFirst( )
        {
            try
            {
                _current = _data[ 0 ];
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Moves the previous.
        /// </summary>
        public void MovePrevious( )
        {
            try
            {
                if( _index > 0
                    && _count > 0 )
                {
                    _index -= 1;
                    _current = _data[ _index ];
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Moves the next.
        /// </summary>
        public void MoveNext( )
        {
            try
            {
                if( _index > 0
                    && _count > 0 )
                {
                    _index += 1;
                    _current = _data[ _index ];
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Moves the last.
        /// </summary>
        public void MoveLast( )
        {
            try
            {
                if( _count > 0 )
                {
                    _index = _count - 1;
                    _current = _data[ _index ];
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset( )
        {
            try
            {
                _index = 0;
                _current = _data[ _index ];
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Creates the view model.
        /// </summary>
        /// <returns></returns>
        public ViewModel CreateViewModel( IList<string> numerics )
        {
            try
            {
                if( _data != null
                    && _count > 0
                    && _columns?.Count > 0 )
                {
                    ThrowIf.Null( numerics, nameof( numerics ) );
                    var _viewModel = new ViewModel( );
                    var _category = _columns[ 0 ];
                    for( var _r = 0; _r < _data.Count; _r++ )
                    {
                        var _row = _data[ _r ];
                        for( var _c = 0; _c < numerics.Count; _c++ )
                        {
                            var _measure = numerics[ _c ];
                            if( _columns.Contains( _measure ) )
                            {
                                var _value = double.Parse( _row[ _measure ]?.ToString( ) );
                                var _view = new View( _r, _category, _measure, _value );
                                _viewModel.Add( _view );
                            }
                        }
                    }

                    return _viewModel;
                }

                return default( ViewModel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ViewModel );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}