// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="SchemaType.cs" company="Terry D. Eppler">
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
//   SchemaType.cs
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public class SchemaType : DataUnit
    {
        /// <summary>
        /// The type name
        /// </summary>
        private protected string _typeName;

        /// <summary>
        /// The database
        /// </summary>
        private protected string _database;

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string TypeName
        {
            get
            {
                return _typeName;
            }
            private protected set
            {
                _database = value;
            }
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public string Database
        {
            get
            {
                return _database;
            }
            private protected set
            {
                _database = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SchemaTypes" /> class.
        /// </summary>
        public SchemaType( )
        {
            _source = Source.SchemaTypes;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SchemaTypes" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public SchemaType( IQuery query )
        {
            _record = new DataGenerator( query ).Record;
            _id = int.Parse( _record[ "SchemaTypesId" ]?.ToString( ) ?? "0" );
            _typeName = _record[ "TypeName" ]?.ToString( );
            _database = _record[ "Database" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SchemaTypes" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public SchemaType( IDataModel builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "SchemaTypesId" ]?.ToString( ) ?? "0" );
            _typeName = _record[ "TypeName" ]?.ToString( );
            _database = _record[ "Database" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SchemaTypes" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public SchemaType( DataRow dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "SchemaTypesId" ]?.ToString( ) ?? "0" );
            _typeName = dataRow[ "TypeName" ]?.ToString( );
            _database = dataRow[ "Database" ]?.ToString( );
            _map = dataRow.ToDictionary( );
        }
    }
}