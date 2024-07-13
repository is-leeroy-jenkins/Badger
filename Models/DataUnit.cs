// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="DataUnit.cs" company="Terry D. Eppler">
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
//   DataUnit.cs
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
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.IDataUnit" />
    /// <seealso cref="T:Badger.ISource" />
    /// <seealso cref="T:Badger.IProvider" />
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "ConvertIfStatementToReturnStatement" ) ]
    public abstract class DataUnit : IDataUnit
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private protected int _id;

        /// <summary>
        /// The name
        /// </summary>
        private protected string _name;

        /// <summary>
        /// The code
        /// </summary>
        private protected string _code;

        /// <summary>
        /// The record
        /// </summary>
        private protected DataRow _record;

        /// <summary>
        /// The data
        /// </summary>
        private protected IDictionary<string, object> _map;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The value
        /// </summary>
        private protected object _value;

        /// <summary>
        /// </summary>
        /// <inheritdoc />
        public int ID
        {
            get
            {
                return _id;
            }
            private protected set
            {
                _id = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the field.
        /// </summary>
        public string Code
        {
            get
            {
                return _code;
            }
            private protected set
            {
                _code = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            private protected set
            {
                _name = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value
        {
            get
            {
                return _value;
            }
            private protected set
            {
                _value = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public DataRow Record
        {
            get
            {
                return _record;
            }
            private protected set
            {
                _record = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public Provider Provider
        {
            get
            {
                return _provider;
            }
            private protected set
            {
                _provider = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the source.
        /// </summary>
        public Source Source
        {
            get
            {
                return _source;
            }
            private protected set
            {
                _source = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IDictionary<string, object> Map
        {
            get
            {
                return _map;
            }
            private protected set
            {
                _map = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataUnit"/> class.
        /// </summary>
        protected DataUnit( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataUnit"/> class.
        /// </summary>
        /// <param name="builder">The query.</param>
        protected DataUnit( IDataModel builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataUnit"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected DataUnit( IQuery query )
        {
            _record = new DataGenerator( query ).Record;
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataUnit"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected DataUnit( DataRow dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _code = dataRow[ "Code" ]?.ToString( );
            _name = dataRow[ "Name" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified element is match.
        /// </summary>
        /// <param name="unit">The element.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified element is match; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public virtual bool IsMatch( IDataUnit unit )
        {
            try
            {
                ThrowIf.Null( unit, nameof( unit ) );
                if( unit.Code?.Equals( _code ) == true
                    && unit.Name.Equals( _name ) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch( Exception ex )
            {
                DataUnit.Fail( ex );
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified dictionary is match.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified dictionary is match; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public virtual bool IsMatch( IDictionary<string, object> dict )
        {
            try
            {
                ThrowIf.Null( dict, nameof( dict ) );
                var _keys = dict.Keys?.First( );
                var _vals = dict[ _keys ];
                return _vals.Equals( Code ) && _keys.Equals( Name );
            }
            catch( Exception ex )
            {
                DataUnit.Fail( ex );
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified primary is match.
        /// </summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>
        ///   <c>true</c> if the specified primary is match;
        /// otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsMatch( IDataUnit primary, IDataUnit secondary )
        {
            try
            {
                ThrowIf.Null( primary, nameof( primary ) );
                ThrowIf.Null( secondary, nameof( secondary ) );
                if( primary.Code.Equals( secondary.Code )
                    && primary.Name.Equals( secondary.Name ) )
                {
                    return true;
                }
            }
            catch( Exception ex )
            {
                DataUnit.Fail( ex );
                return false;
            }

            return false;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns></returns>
        public virtual int GetId( )
        {
            try
            {
                return _record != null
                    ? int.Parse( _record[ 0 ]?.ToString( ) ?? "0" )
                    : -1;
            }
            catch( Exception ex )
            {
                DataUnit.Fail( ex );
                return default( int );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        public virtual int GetId( DataRow dataRow )
        {
            try
            {
                ThrowIf.Null( dataRow, nameof( dataRow ) );
                return int.Parse( dataRow[ 0 ]?.ToString( ) ?? "0" );
            }
            catch( Exception ex )
            {
                DataUnit.Fail( ex );
                return default( int );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        protected static void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}