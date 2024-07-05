// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="CarryoverRequest.cs" company="Terry D. Eppler">
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
//   CarryoverRequest.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.AdministrativeRequest"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class CarryoverRequest : AdministrativeRequest
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverRequest" />
        /// class.
        /// </summary>
        public CarryoverRequest( ) 
            : base( )
        {
            Source = Source.CarryoverRequests;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverRequest" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public CarryoverRequest( IQuery query ) 
            : base( query )
        {
            _id = int.Parse( _record[ "CarryoverRequestsId" ].ToString( ) ?? "0" );
            _analyst = _record[ "Analyst" ].ToString( );
            _documentTitle = _record[ "DocumentTitle" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0" );
            _fundCode = _record[ "FundCode" ].ToString( );
            _status = _record[ "Status" ].ToString( );
            _inSystem = bool.Parse( _record[ "InSystem" ].ToString( ) );
            _comments = Record[ "Comments" ].ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ].ToString( ) );
            _lastActivityDate = DateTime.Parse( Record[ "LastActivityDate" ].ToString( ) );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverRequest" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public CarryoverRequest( IDataModel builder ) 
            : base( builder )
        {
            _id = int.Parse( _record[ "CarryoverRequestsId" ].ToString( ) ?? "0" );
            _analyst = _record[ "Analyst" ].ToString( );
            _documentTitle = _record[ "DocumentTitle" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0" );
            _fundCode = _record[ "FundCode" ].ToString( );
            _status = _record[ "Status" ].ToString( );
            _inSystem = bool.Parse( _record[ "InSystem" ].ToString( ) );
            _comments = Record[ "Comments" ].ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ].ToString( ) );
            _lastActivityDate = DateTime.Parse( Record[ "LastActivityDate" ].ToString( ) );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverRequest" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public CarryoverRequest( DataRow dataRow ) 
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "CarryoverRequestsId" ].ToString( ) ?? "0" );
            _analyst = dataRow[ "Analyst" ].ToString( );
            _documentTitle = dataRow[ "DocumentTitle" ].ToString( );
            _amount = double.Parse( dataRow[ "Amount" ].ToString( ) ?? "0" );
            _fundCode = dataRow[ "FundCode" ].ToString( );
            _status = dataRow[ "Status" ].ToString( );
            _inSystem = bool.Parse( dataRow[ "InSystem" ].ToString( ) );
            _comments = Record[ "Comments" ].ToString( );
            _processedDate = DateTime.Parse( dataRow[ "ProcessedDate" ].ToString( ) );
            _lastActivityDate = DateTime.Parse( dataRow[ "LastActivityDate" ].ToString( ) );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverRequest" />
        /// class.
        /// </summary>
        /// <param name="request"> The request. </param>
        public CarryoverRequest( AdministrativeRequest request ) 
            : this( )
        {
            _id = request.ID;
            _analyst = request.Analyst;
            _documentTitle = request.DocumentTitle;
            _amount = request.Amount;
            _fundCode = request.FundCode;
            _status = request.Status;
            _inSystem = request.InSystem;
            _comments = request.Comments;
            _processedDate = request.ProcessedDate;
            _lastActivityDate = request.LastActivityDate;
        }
    }
}