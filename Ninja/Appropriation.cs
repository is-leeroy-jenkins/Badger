// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="Appropriation.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application for the
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
//   Appropriation.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class Appropriation : DataUnit
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Appropriations" />
        /// class.
        /// </summary>
        public Appropriation( ) 
            : base( )
        {
            _source = Source.Appropriations;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Appropriation"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Appropriation( IQuery query ) 
            : base( query )
        {
            _record = new DataBuilder( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "AppropriationsId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Appropriation"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public Appropriation( IDataModel builder ) 
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "AppropriationsId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Appropriation"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public Appropriation( DataRow dataRow ) 
            : base( dataRow )
        { 
            _record = dataRow;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "AppropriationsId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Appropriation" />
        /// class.
        /// </summary>
        /// <param name="appropriation"> The appropriation. </param>
        public Appropriation( Appropriation appropriation )
            : this( )

        {
            _id = appropriation.ID;
            _code = appropriation.Code;
            _name = appropriation.Name;
        }
    }
}