// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="CostArea.cs" company="Terry D. Eppler">
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
//   CostArea.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class CostArea : DataUnit
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CostArea" />
        /// class.
        /// </summary>
        public CostArea( )
            : base( )
        {
            _source = Source.CostAreas;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CostArea" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public CostArea( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "CostAreasId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CostArea" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public CostArea( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "CostAreasId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CostArea" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public CostArea( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "CostAreasId" ]?.ToString( ) ?? "0" );
            _code = dataRow[ "Code" ]?.ToString( );
            _name = dataRow[ "Name" ]?.ToString( );
        }
    }
}