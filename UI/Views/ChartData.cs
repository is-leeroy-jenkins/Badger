// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
//
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
// ******************************************************************************************
// <copyright file="${File.FileName}" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  ${CurrentDate.Year}  Terry D. Eppler
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
//   ${File.FileName}
// </summary>
// ******************************************************************************************

namespace Badger
{
    using Syncfusion.Data.Extensions;
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
    [SuppressMessage( "ReSharper", "UnusedType.Global" )]
    [SuppressMessage( "ReSharper", "RedundantJumpStatement" )]
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" )]
    [SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" )]
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    [SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" )]
    [SuppressMessage( "ReSharper", "MemberCanBeInternal" )]
    [SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" )]
    public class ChartData
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
        private protected BindingList<IModel> _views;

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
        public BindingList<IModel> Views
        {
            get
            {
                return _views;
            }
            set
            {
                _views = value;
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
        /// <see cref="ChartData" /> class.
        /// </summary>
        public ChartData( )
            : base( )
        {
            _index = 0;
            _count = 0;
            _data = new ObservableCollection<DataRow>( );
            _items = new BindingList<DataRow>( );
            _columns = new List<string>( );
            _numerics = new List<string>( );
            _fields = new List<string>( );
            _views = new BindingList<IModel>( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChartData" /> class.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public ChartData( DataTable dataTable )
            : this( )
        {
            _data = dataTable?.ToObservable( );
            _items = dataTable.ToBindingList( );
            _current = _data?[ _index ];
            _count = dataTable?.Rows?.Count ?? 0;
            _tableName = _current?.Table?.TableName;
            _columns = dataTable.GetColumnNames( );
            _numerics = dataTable?.GetNumericColumns( )
                ?.Select( n => n.ColumnName )
                ?.ToList( );

            _fields = dataTable.GetTextColumns( )
                ?.Select( n => n.ColumnName )
                ?.ToList( );

            _views = CreateViewList( );
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
        /// Gets the text fields.
        /// </summary>
        /// <returns></returns>
        private protected IList<string> GetTextFields( )
        {
            try
            {
                if( _data != null )
                {
                    var _cols = new List<string>( );
                    foreach( var _col in _fields )
                    {
                        if( !_numerics.Contains( _col ) )
                        {
                            _cols.Add( _col );
                        }
                    }

                    return ( _cols?.Any( ) == true )
                        ? _cols
                        : default( IList<string> );
                }

                return default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Creates the views.
        /// </summary>
        /// <returns></returns>
        public BindingList<IModel> CreateViewList( )
        {
            try
            {
                if( _data != null )
                {
                    _views = new BindingList<IModel>( );
                    for( var _index = 0; _index < _data.Count; _index++ )
                    {
                        var _dataRow = _data[ _index ];
                        var _dimension = _columns[ 0 ];
                        for( var _c = 0; _c < _numerics.Count; _c++ )
                        {
                            var _measure = _numerics[ _c ];
                            var _value = double.Parse( _dataRow[ _measure ].ToString( ) );
                            var _view = new RowModel( _index, _dimension, _measure, _value );
                            _views.Add( _view );
                        }
                    }

                    return ( _views?.Any( ) == true )
                        ? _views
                        : default( BindingList<IModel> );
                }

                return default( BindingList<IModel> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( BindingList<IModel> );
            }
        }

        /// <summary>
        /// Creates the view model.
        /// </summary>
        /// <returns></returns>
        public IViewModel CreateViewModel( )
        {
            try
            {
                if( _data != null )
                {
                    var _viewModel = new RowView( );
                    for( var _index = 0; _index < _data.Count; _index++ )
                    {
                        var _dataRow = _data[ _index ];
                        var _dimension = _columns[ 0 ];
                        for( var _c = 0; _c < _numerics.Count; _c++ )
                        {
                            var _numeric = _numerics[ _c ];
                            var _value = double.Parse( _dataRow[ _numeric ].ToString( ) );
                            var _view = new RowModel( _index, _dimension, _numeric, _value );
                            _viewModel.Add( _view );
                        }
                    }

                    return _viewModel;
                }

                return default( IViewModel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IViewModel );
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