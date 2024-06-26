// ****************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 15-03-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        19-03-2024
// ****************************************************************************************
// <copyright file="SqlBase.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application for analysts in the
//    US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
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
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND,
//     EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//     OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE
//     AND NON-INFRINGEMENT.  IN NO EVENT SHALL THE AUTHORS
//     OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//     DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//     TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//     DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//  SqlBase.cs
// </summary>
// ****************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertIfStatementToSwitchStatement" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "ConvertSwitchStatementToSwitchExpression" ) ]
    public abstract class SqlBase
    {
        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The command type
        /// </summary>
        private protected Command _commandType;

        /// <summary>
        /// The extension
        /// </summary>
        private protected EXT _extension;

        /// <summary>
        /// The criteria
        /// </summary>
        private protected IDictionary<string, object> _criteria;

        /// <summary>
        /// The updates
        /// </summary>
        private protected IDictionary<string, object> _updates;

        /// <summary>
        /// The fields
        /// </summary>
        private protected IList<string> _fields;

        /// <summary>
        /// The numerics
        /// </summary>
        private protected IList<string> _numerics;

        /// <summary>
        /// The groups
        /// </summary>
        private protected IList<string> _groups;

        /// <summary>
        /// The table name
        /// </summary>
        private protected string _tableName;

        /// <summary>
        /// The file name
        /// </summary>
        private protected string _fileName;

        /// <summary>
        /// The database path
        /// </summary>
        private protected string _dbPath;

        /// <summary>
        /// The command text
        /// </summary>
        private protected string _commandText;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SqlBase"/>
        /// class.
        /// </summary>
        protected SqlBase( )
        {
            _criteria = new Dictionary<string, object>( );
            _fields = new List<string>( );
            _numerics = new List<string>( );
            _groups = new List<string>( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SqlBase"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="commandType"> Type of the command. </param>
        protected SqlBase( Source source, Provider provider, Command commandType = Command.SELECTALL )
            : this( )
        {
            _dbPath = new BudgetConnection( source, provider ).DataPath;
            _commandType = commandType;
            _source = source;
            _provider = provider;
            _tableName = source.ToString( );
            _commandText = $"SELECT * FROM {source}";
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SqlBase"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="sqlText"> The SQL text. </param>
        /// <param name="commandType"> Type of the command. </param>
        protected SqlBase( Source source, Provider provider, string sqlText,
            Command commandType = Command.SELECTALL )
            : this( )
        {
            _dbPath = new BudgetConnection( source, provider ).DataPath;
            _commandType = commandType;
            _source = source;
            _provider = provider;
            _tableName = source.ToString( );
            _commandText = sqlText;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SqlBase"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        protected SqlBase( Source source, Provider provider, IDictionary<string, object> where,
            Command commandType = Command.SELECTALL )
            : this( )
        {
            _dbPath = new BudgetConnection( source, provider ).DataPath;
            _commandType = commandType;
            _source = source;
            _provider = provider;
            _tableName = source.ToString( );
            _criteria = where;
            _commandText = $@"SELECT * FROM {source} WHERE {where.ToCriteria( )}";
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SqlBase"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="updates"> The updates. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        protected SqlBase( Source source, Provider provider, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
            : this( )
        {
            _dbPath = new BudgetConnection( source, provider ).DataPath;
            _commandType = commandType;
            _source = source;
            _provider = provider;
            _tableName = source.ToString( );
            _updates = updates;
            _criteria = where;
            _fields = updates.Keys.ToList( );
            _commandText = GetCommandText( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SqlBase"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        protected SqlBase( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> where, Command commandType = Command.SELECT )
            : this( )
        {
            _dbPath = new BudgetConnection( source, provider ).DataPath;
            _commandType = commandType;
            _source = source;
            _provider = provider;
            _tableName = source.ToString( );
            _criteria = where;
            _fields = columns.ToList( );
            _commandText = GetCommandText( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SqlBase"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="fields"> The fields. </param>
        /// <param name="numerics"> The numerics. </param>
        /// <param name="having"> The having. </param>
        /// <param name="commandType"> Type of the command. </param>
        protected SqlBase( Source source, Provider provider, IEnumerable<string> fields,
            IEnumerable<string> numerics, IDictionary<string, object> having,
            Command commandType = Command.SELECT )
            : this( )
        {
            _dbPath = new BudgetConnection( source, provider ).DataPath;
            _commandType = commandType;
            _source = source;
            _provider = provider;
            _tableName = source.ToString( );
            _criteria = having;
            _fields = fields.ToList( );
            _numerics = numerics.ToList( );
            _commandText = GetCommandText( );
        }

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected string GetCommandText( )
        {
            try
            {
                switch( _commandType )
                {
                    case Command.SELECT:
                    case Command.SELECTALL:
                    {
                        return CreateSelectStatement( );
                    }
                    case Command.INSERT:
                    {
                        return CreateInsertStatement( );
                    }
                    case Command.UPDATE:
                    {
                        return CreateUpdateStatement( );
                    }
                    case Command.DELETE:
                    {
                        return GetDeleteStatement( );
                    }
                    default:
                    {
                        return CreateSelectStatement( );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the select statement.
        /// </summary>
        /// <returns></returns>
        private protected string CreateSelectStatement( )
        {
            if( ( _fields?.Any( ) == true )
               && ( _criteria?.Any( ) == true )
               && ( _numerics?.Any( ) == true ) )
            {
                var _cols = string.Empty;
                var _aggr = string.Empty;
                foreach( var _name in _fields )
                {
                    _cols += @$"{_name}, ";
                }

                foreach( var _metric in _numerics )
                {
                    _aggr += @$"SUM({_metric}) AS {_metric}, ";
                }

                var _where = _criteria.ToCriteria( );
                var _names = _cols + _aggr.TrimEnd( ", ".ToCharArray( ) );
                var _group = _cols.TrimEnd( ", ".ToCharArray( ) );
                return $"SELECT {_names} FROM {_source} "
                    + $"WHERE {_where} "
                    + $"GROUP BY {_group};";
            }
            else if( ( _fields?.Any( ) == true )
                    && ( _criteria?.Any( ) == true )
                    && ( _numerics?.Any( ) == false ) )
            {
                var _cols = string.Empty;
                foreach( var _name in _fields )
                {
                    _cols += $"{_name}, ";
                }

                var _where = _criteria.ToCriteria( );
                var _columns = _cols.TrimEnd( ", ".ToCharArray( ) );
                return $"SELECT {_columns} FROM {_source} "
                    + $"WHERE {_where} "
                    + $"GROUP BY {_columns};";
            }
            else if( ( _fields?.Any( ) == false )
                    && ( _criteria?.Any( ) == true )
                    && ( _numerics?.Any( ) == false ) )
            {
                var _where = _criteria.ToCriteria( );
                return $"SELECT * FROM {_source} WHERE {_where};";
            }
            else if( ( _fields?.Any( ) == false )
                    && ( _criteria?.Any( ) == false )
                    && ( _numerics?.Any( ) == false ) )
            {
                return $"SELECT * FROM {_source};";
            }

            return default( string );
        }

        /// <summary>
        /// Gets the update statement.
        /// </summary>
        /// <returns></returns>
        private protected string CreateUpdateStatement( )
        {
            try
            {
                var _update = string.Empty;
                if( _updates.Count == 1 )
                {
                    foreach( var _kvp in _updates )
                    {
                        _update += $"{_kvp.Key} = '{_kvp.Value}'";
                    }
                }
                else if( _updates.Count > 1 )
                {
                    foreach( var _kvp in _updates )
                    {
                        _update += $"{_kvp.Key} = '{_kvp.Value}', ";
                    }
                }

                var _where = _criteria.ToCriteria( );
                var _values = _update.TrimEnd( ", ".ToCharArray( ) );
                return $"UPDATE {_source} SET {_values} WHERE {_where};";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the insert statement.
        /// </summary>
        /// <returns></returns>
        private protected string CreateInsertStatement( )
        {
            try
            {
                var _columns = string.Empty;
                var _values = string.Empty;
                if( _updates.Count == 1 )
                {
                    foreach( var _kvp in _updates )
                    {
                        _columns += $"{_kvp.Key}";
                        _values += $"{_kvp.Value}";
                    }
                }
                else if( _updates.Count > 1 )
                {
                    foreach( var _kvp in _updates )
                    {
                        _columns += $"{_kvp.Key}, ";
                        _values += $"{_kvp.Value}, ";
                    }
                }

                var _columnValues = $"({_columns.TrimEnd( ", ".ToCharArray( ) )})"
                    + $" VALUES ({_values.TrimEnd( ", ".ToCharArray( ) )})";

                return $"INSERT INTO {_source} {_columnValues};";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary> Gets the delete statement. </summary>
        /// <returns> </returns>
        private protected string GetDeleteStatement( )
        {
            try
            {
                var _where = _criteria.ToCriteria( );
                return !string.IsNullOrEmpty( _where )
                    ? $"DELETE * FROM {_source} WHERE {_where};"
                    : $"DELETE * FROM {_source};";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex"> The ex. </param>
        private protected void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}