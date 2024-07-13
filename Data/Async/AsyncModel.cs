﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="AsyncModel.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application
//    for the US Environmental Protection Agency (US EPA).
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
//   AsyncModel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.AsyncData" />
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    public class AsyncModel : AsyncData
    {
        /// <summary>
        /// The locked object
        /// </summary>
        private static object KEY;

        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// 
        /// </summary>
        private protected Task<IDictionary<string, IEnumerable<string>>> _dataElements;

        /// <inheritdoc/>
        /// <summary>
        /// Gets the data elements.
        /// </summary>
        /// <value>
        /// The data elements.
        /// </value>
        public Task<IDictionary<string, IEnumerable<string>>> DataElements
        {
            get
            {
                return _dataElements;
            }
            private set
            {
                _dataElements = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
        /// .
        /// </value>
        public bool IsBusy
        {
            get
            {
                return _busy;
            }
            set
            {
                _busy = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        public AsyncModel( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        public AsyncModel( Source source, Provider provider = Provider.Access )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, Command.SELECTALL );
            _query = new BudgetQuery( SqlStatement );
            _dataTable = GetDataTableAsync( );
            _dataElements = GetSeriesAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _keys = GetKeysAsnyc( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _dates = GetDatesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="where"> The where. </param>
        public AsyncModel( Source source, Provider provider, IDictionary<string, object> where )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, where );
            _query = new BudgetQuery( SqlStatement );
            _dataTable = GetDataTableAsync( );
            _dataElements = GetSeriesAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _keys = GetKeysAsnyc( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _dates = GetDatesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="updates"> The updates. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public AsyncModel( Source source, Provider provider, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, updates, where, commandType );
            _query = new BudgetQuery( SqlStatement );
            _dataTable = GetDataTableAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _keys = GetKeysAsnyc( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _dates = GetDatesAsync( );
            _dataElements = GetSeriesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public AsyncModel( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> where, Command commandType = Command.SELECT )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, columns, where, commandType );
            _query = new BudgetQuery( _sqlStatement );
            _dataTable = GetDataTableAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _keys = GetKeysAsnyc( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _dates = GetDatesAsync( );
            _dataElements = GetSeriesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="fields"> The fields. </param>
        /// <param name="numerics"> The numerics. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public AsyncModel( Source source, Provider provider, IEnumerable<string> fields,
            IEnumerable<string> numerics, IDictionary<string, object> where,
            Command commandType )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, fields, numerics, where,
                commandType );

            _query = new BudgetQuery( _sqlStatement );
            _dataTable = GetDataTableAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _keys = GetKeysAsnyc( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _dates = GetDatesAsync( );
            _dataElements = GetSeriesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="where"> The where. </param>
        public AsyncModel( Source source, IDictionary<string, object> where )
        {
            _source = source;
            _provider = Provider.Access;
            _connection = new BudgetConnection( source, _provider ).Create( );
            _sqlStatement = new SqlStatement( source, Provider.Access, where );
            _query = new BudgetQuery( _sqlStatement );
            _dataTable = GetDataTableAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _keys = GetKeysAsnyc( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _dates = GetDatesAsync( );
            _dataElements = GetSeriesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="sqlText"> The SQL text. </param>
        public AsyncModel( Source source, Provider provider, string sqlText )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, sqlText );
            _query = new BudgetQuery( _sqlStatement );
            _dataTable = GetDataTableAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _keys = GetKeysAsnyc( );
            _dates = GetDatesAsync( );
            _dataElements = GetSeriesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The full path. </param>
        /// <param name="sqlText"> The SQL text. </param>
        /// <param name="commandType"> Type of the command. </param>
        public AsyncModel( string fullPath, string sqlText, Command commandType = Command.SELECT )
        {
            _connection = new BudgetConnection( fullPath ).Create( );
            _source = Source.External;
            _provider = Provider.Access;
            _sqlStatement = new SqlStatement( _source, _provider, sqlText, commandType );
            _query = new BudgetQuery( _sqlStatement );
            _dataTable = GetDataTableAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _keys = GetKeysAsnyc( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _dates = GetDatesAsync( );
            _dataElements = GetSeriesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AsyncModel"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public AsyncModel( IQuery query )
        {
            _query = query;
            _source = query.Source;
            _provider = query.Provider;
            _sqlStatement = query.SqlStatement;
            _connection = new BudgetConnection( _source, _provider ).Create( );
            _dataTable = GetDataTableAsync( );
            _dataColumns = GetColumnsAsync( );
            _columnNames = GetNamesAsync( );
            _keys = GetKeysAsnyc( );
            _fields = GetFieldsAsync( );
            _numerics = GetNumericsAsync( );
            _dates = GetDatesAsync( );
            _dataElements = GetSeriesAsync( );
            _record = GetRecordAsync( );
            _map = GetMapAsync( );
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private protected void BeginInit( )
        {
            try
            {
                if( AsyncModel.KEY == null )
                {
                    AsyncModel.KEY = new object( );
                    lock( AsyncModel.KEY )
                    {
                        _busy = true;
                    }
                }
                else
                {
                    lock( AsyncModel.KEY )
                    {
                        _busy = true;
                    }
                }
            }
            catch( Exception ex )
            {
                AsyncModel.Fail( ex );
            }
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private protected void EndInit( )
        {
            try
            {
                if( AsyncModel.KEY == null )
                {
                    AsyncModel.KEY = new object( );
                    lock( AsyncModel.KEY )
                    {
                        _busy = false;
                    }
                }
                else
                {
                    lock( AsyncModel.KEY )
                    {
                        _busy = false;
                    }
                }
            }
            catch( Exception ex )
            {
                AsyncModel.Fail( ex );
            }
        }

        /// <summary> Gets the values asynchronous. </summary>
        /// <param name="dataRows"> The data rows. </param>
        /// <param name="name"> The name. </param>
        /// <param name="value"> The value. </param>
        /// <returns> </returns>
        public Task<IList<string>> GetValuesAsync( IEnumerable<DataRow> dataRows,
            string name, string value )
        {
            ThrowIf.Null( dataRows, nameof( dataRows ) );
            ThrowIf.Null( name, nameof( name ) );
            ThrowIf.Null( value, nameof( value ) );
            var _async = new TaskCompletionSource<IList<string>>( );
            try
            {
                var _select = dataRows
                    ?.Where( v => v.Field<string>( $"{name}" ).Equals( value ) )
                    ?.Select( v => v.Field<string>( $"{name}" ) )
                    ?.Distinct( )
                    ?.ToList( );

                _async.SetResult( _select );
                return _select?.Any( ) == true
                    ? _async.Task
                    : default( Task<IList<string>> );
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                AsyncModel.Fail( ex );
                return default( Task<IList<string>> );
            }
        }

        /// <summary> Gets the values. </summary>
        /// <param name="dataRows"> The data rows. </param>
        /// <param name="name"> The column. </param>
        /// <returns> </returns>
        public Task<IList<string>> GetValuesAsync( IEnumerable<DataRow> dataRows, string name )
        {
            var _async = new TaskCompletionSource<IList<string>>( );
            try
            {
                ThrowIf.Null( dataRows, nameof( dataRows ) );
                ThrowIf.Null( name, nameof( name ) );
                var _values = dataRows
                    ?.Select( v => v.Field<string>( name ) )
                    ?.Distinct( )
                    ?.ToList( );

                _async.SetResult( _values );
                return _values?.Any( ) == true
                    ? _async.Task
                    : default( Task<IList<string>> );
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                AsyncModel.Fail( ex );
                return default( Task<IList<string>> );
            }
        }

        /// <summary>
        /// Creates the series asynchronous.
        /// </summary>
        /// <returns>
        /// </returns>
        public Task<IDictionary<string, IEnumerable<string>>> GetSeriesAsync( )
        {
            var _async = new TaskCompletionSource<IDictionary<string, IEnumerable<string>>>( );
            try
            {
                var _table = GetDataTable( );
                var _columns = _table?.Columns;
                var _rows = _table?.AsEnumerable( );
                var _dict = new Dictionary<string, IEnumerable<string>>( );
                for( var _i = 0; _i < _columns?.Count; _i++ )
                {
                    var _colName = _columns[ _i ]?.ColumnName;
                    if( !string.IsNullOrEmpty( _colName )
                        && _columns[ _i ]?.DataType == typeof( string ) )
                    {
                        var _name = GetValuesAsync( _rows, _colName );
                        _dict?.Add( _columns[ _i ]?.ColumnName, _name.Result );
                    }
                }

                _async.SetResult( _dict );
                return _dict?.Any( ) == true
                    ? _async.Task
                    : default( Task<IDictionary<string, IEnumerable<string>>> );
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                AsyncModel.Fail( ex );
                return default( Task<IDictionary<string, IEnumerable<string>>> );
            }
        }
    }
}