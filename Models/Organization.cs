// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="Organization.cs" company="Terry D. Eppler">
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
//   Organization.cs
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
    /// <seealso cref="T:Badger.DataUnit" />
    /// <seealso cref="T:Badger.ISource" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class Organization : DataUnit
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Organizations" />
        /// class.
        /// </summary>
        public Organization( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Organizations" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Organization( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( _record[ "OrganizationsId" ]?.ToString( ) ?? "0" );
            _name = Record[ "Name" ].ToString( );
            _code = Record[ "Code" ].ToString( );
            _map = Record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Organizations" />
        /// class.
        /// </summary>
        /// <param name="org"> The org. </param>
        public Organization( string org )
            : this( )
        {
            _record = new DataGenerator( _source, GetArgs( org ) )?.Record;
            _id = int.Parse( _record[ "OrganizationsId" ]?.ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Organizations" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public Organization( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "OrganizationsId" ]?.ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Organizations" />
        /// class.
        /// </summary>
        /// <param name="org"> The org. </param>
        public Organization( Organization org )
            : this( )
        {
            _id = org.ID;
            _code = org.Code;
            _name = org.Name;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Organizations" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The dataRow. </param>
        public Organization( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "OrganizationsId" ].ToString( ) ?? "0" );
            _name = dataRow[ "Name" ].ToString( );
            _code = dataRow[ "Code" ].ToString( );
            _map = dataRow?.ToDictionary( );
        }

        /// <summary> Converts to dictionary. </summary>
        /// <returns> </returns>
        public IDictionary<string, object> ToDictionary( )
        {
            try
            {
                return _map?.Any( ) == true
                    ? _map
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Organization.Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary> Sets the arguments. </summary>
        /// <param name="code"> The code. </param>
        /// <returns> </returns>
        private IDictionary<string, object> GetArgs( string code )
        {
            try
            {
                ThrowIf.Null( code, nameof( code ) );
                return new Dictionary<string, object>
                {
                    [ "Code" ] = code
                };
            }
            catch( Exception ex )
            {
                Organization.Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}