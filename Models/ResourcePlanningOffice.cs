// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="ResourcePlanningOffice.cs" company="Terry D. Eppler">
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
//   ResourcePlanningOffice.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.DataUnit" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class ResourcePlanningOffice : DataUnit
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ResourcePlanningOffices" /> class.
        /// </summary>
        public ResourcePlanningOffice( )
        {
            _source = Source.ResourcePlanningOffices;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ResourcePlanningOffices" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public ResourcePlanningOffice( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( _record[ "ResourcePlanningOfficesId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ResourcePlanningOffices" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public ResourcePlanningOffice( IDataService builder )
            : base( builder )
        {
            _record = builder?.Record;
            _id = int.Parse( _record?[ "ResourcePlanningOfficesId" ].ToString( ) ?? "0" );
            _name = _record?[ "Name" ].ToString( );
            _code = _record?[ "Code" ].ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ResourcePlanningOffices" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public ResourcePlanningOffice( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "ResourcePlanningOfficesId" ].ToString( ) ?? "0" );
            _name = dataRow[ "Name" ].ToString( );
            _code = dataRow[ "Code" ].ToString( );
            _map = dataRow.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <
        /// see cref="T:Badger.ResourcePlanningOffices" /> class.
        /// </summary>
        /// <param name="rpioCode">The rpio code.</param>
        public ResourcePlanningOffice( string rpioCode )
            : this( )
        {
            _record = new DataGenerator( _source, SetArgs( rpioCode ) )?.Record;
            _id = int.Parse( _record?[ "ResourcePlanningOfficesId" ].ToString( ) ?? "0" );
            _name = _record?[ "Name" ].ToString( );
            _code = _record?[ "Code" ].ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ResourcePlanningOffices" /> class.
        /// </summary>
        /// <param name="rpio">The rpio.</param>
        public ResourcePlanningOffice( ResourcePlanningOffice rpio )
        {
            _id = rpio.ID;
            _code = rpio.Code;
            _name = rpio.Name;
        }

        /// <summary>
        /// Gets the resource planning office.
        /// </summary>
        /// <returns></returns>
        public ResourcePlanningOffice Copy( )
        {
            return MemberwiseClone( ) as ResourcePlanningOffice;
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> SetArgs( string code )
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
                ResourcePlanningOffice.Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}