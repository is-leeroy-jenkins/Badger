// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="ChartViewModel.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
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
//   ChartViewModel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
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
    public class ChartViewModel
    {
        /// <summary>
        /// The columns
        /// </summary>
        private readonly IList<string> _fields;

        /// <summary>
        /// The columns
        /// </summary>
        private readonly IList<string> _numerics;

        /// <summary>
        /// The columns
        /// </summary>
        private readonly IList<string> _columns;

        /// <summary>
        /// The views
        /// </summary>
        private protected ViewModel _seriesData;

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
        private protected ObservableCollection<DataRow> _rows;

        /// <summary>
        /// The index
        /// </summary>
        private protected int _index;

        /// <summary>
        /// The data
        /// </summary>
        private protected BindingList<DataRow> _items;

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
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
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
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public BindingList<DataRow> Items
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
        /// Gets or sets the views.
        /// </summary>
        /// <value>
        /// The views.
        /// </value>
        public ViewModel SeriesData
        {
            get
            {
                return _seriesData;
            }
            set
            {
                _seriesData = value;
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public ObservableCollection<DataRow> Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChartViewModel" /> class.
        /// </summary>
        public ChartViewModel( )
            : base( )
        {
            _index = 0;
            _count = 0;
            _rows = new ObservableCollection<DataRow>( );
            _items = new BindingList<DataRow>( );
            _columns = new List<string>( );
            _fields = new List<string>( );
            _numerics = new List<string>( );
            _seriesData = CreateViewModel( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChartViewModel" /> class.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public ChartViewModel( DataTable dataTable )
            : this( )
        {
            _rows = dataTable?.ToObservable( );
            _items = dataTable.ToBindingList( );
            _current = _rows?[ _index ];
            _count = dataTable?.Rows?.Count ?? 0;
            _tableName = _current?.Table?.TableName;
            _columns = dataTable.GetColumnNames( );
            _numerics = GetNumericFields( dataTable );
            _fields = GetTextFields( dataTable );
            _seriesData = CreateViewModel( );
        }

        /// <summary>
        /// Iterates over the rows in the ObservableCollection.
        /// </summary>
        /// <returns>
        /// IEnumerator( DataRow )
        /// </returns>
        public IEnumerator<DataRow> IterRows( )
        {
            foreach( var _item in _rows )
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
                _current = _rows[ 0 ];
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
                    _current = _rows[ _index ];
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
                    _current = _rows[ _index ];
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
                    _current = _rows[ _index ];
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
                _current = _rows[ _index ];
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        private protected IList<string> GetNumericFields( DataTable dataTable )
        {
            try
            {
                var _nums = dataTable?.GetNumericColumns( )?.Select( n => n.ColumnName )?.ToList( );
                return _nums?.Count > 0
                    ? _nums
                    : default( IList<string> );
            }
            catch( Exception e )
            {
                Fail( e );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Gets the text fields.
        /// </summary>
        /// <returns></returns>
        private protected IList<string> GetTextFields( DataTable dataTable )
        {
            try
            {
                var _nums = dataTable?.GetTextColumns( )?.Select( n => n.ColumnName )?.ToList( );
                return _nums?.Count > 0
                    ? _nums
                    : default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Creates the view model.
        /// </summary>
        /// <returns></returns>
        public ViewModel CreateViewModel( )
        {
            try
            {
                if( _rows != null )
                {
                    var _viewModel = new ViewModel( );
                    for( var _row = 0; _row < _rows.Count; _row++ )
                    {
                        var _dataRow = _rows[ _row ];
                        var _name = _columns[ 0 ];
                        for( var _c = 0; _c < _numerics.Count; _c++ )
                        {
                            var _numeric = _numerics[ _c ];
                            var _value = double.Parse( _dataRow[ _numeric ].ToString( ) );
                            var _view = new View( _row, _name, _value );
                            _viewModel.Add( _view );
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