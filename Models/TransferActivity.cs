// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="TransferActivity.cs" company="Terry D. Eppler">
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
//   TransferActivity.cs
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
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class TransferActivity : Transfer
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TransferActivity" />
        /// class.
        /// </summary>
        public TransferActivity( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TransferActivity" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public TransferActivity( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _id = int.Parse( _record[ "TransferActivityId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _ahCode = _record[ "AhCode" ]?.ToString( );
            _ahName = _record[ "AhName" ]?.ToString( );
            _orgCode = _record[ "OrgCode" ]?.ToString( );
            _orgName = _record[ "OrgName" ]?.ToString( );
            _accountCode = _record[ "AccountCode" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _rcCode = _record[ "RcCode" ]?.ToString( );
            _rcName = _record[ "RcName" ]?.ToString( );
            _programProjectCode = _record[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = _record[ "ProgramProjectName" ]?.ToString( );
            _fromTo = _record[ "FromTo" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0" );
            _resourceType = _record[ "ResourceType" ]?.ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ]?.ToString( ) );
            _quarter = _record[ "Quarter" ]?.ToString( );
            _reprogrammingNumber = _record[ "ReprogrammingNumber" ]?.ToString( );
            _controlNumber = _record[ "ControlNumber" ]?.ToString( );
            _line = _record[ "Line" ]?.ToString( );
            _subline = _record[ "Subline" ]?.ToString( );
            _purpose = _record[ "Purpose" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TransferActivity" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public TransferActivity( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "TransferActivityId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _ahCode = _record[ "AhCode" ]?.ToString( );
            _ahName = _record[ "AhName" ]?.ToString( );
            _orgCode = _record[ "OrgCode" ]?.ToString( );
            _orgName = _record[ "OrgName" ]?.ToString( );
            _accountCode = _record[ "AccountCode" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _rcCode = _record[ "RcCode" ]?.ToString( );
            _rcName = _record[ "RcName" ]?.ToString( );
            _programProjectCode = _record[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = _record[ "ProgramProjectName" ]?.ToString( );
            _fromTo = _record[ "FromTo" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0" );
            _resourceType = _record[ "ResourceType" ]?.ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ]?.ToString( ) );
            _quarter = _record[ "Quarter" ]?.ToString( );
            _reprogrammingNumber = _record[ "ReprogrammingNumber" ]?.ToString( );
            _controlNumber = _record[ "ControlNumber" ]?.ToString( );
            _line = _record[ "Line" ]?.ToString( );
            _subline = _record[ "Subline" ]?.ToString( );
            _purpose = _record[ "Purpose" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TransferActivity" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public TransferActivity( DataRow dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "TransferActivityId" ]?.ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
            _budgetLevel = dataRow[ "BudgetLevel" ]?.ToString( );
            _rpioCode = dataRow[ "RpioCode" ]?.ToString( );
            _rpioName = dataRow[ "RpioName" ]?.ToString( );
            _ahCode = dataRow[ "AhCode" ]?.ToString( );
            _ahName = dataRow[ "AhName" ]?.ToString( );
            _orgCode = dataRow[ "OrgCode" ]?.ToString( );
            _orgName = dataRow[ "OrgName" ]?.ToString( );
            _accountCode = dataRow[ "AccountCode" ]?.ToString( );
            _bocCode = dataRow[ "BocCode" ]?.ToString( );
            _bocName = dataRow[ "BocName" ]?.ToString( );
            _rcCode = dataRow[ "RcCode" ]?.ToString( );
            _rcName = dataRow[ "RcName" ]?.ToString( );
            _programProjectCode = dataRow[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = dataRow[ "ProgramProjectName" ]?.ToString( );
            _fromTo = dataRow[ "FromTo" ]?.ToString( );
            _amount = double.Parse( dataRow[ "Amount" ]?.ToString( ) ?? "0" );
            _resourceType = dataRow[ "ResourceType" ]?.ToString( );
            _processedDate = DateTime.Parse( dataRow[ "ProcessedDate" ]?.ToString( ) );
            _quarter = dataRow[ "Quarter" ]?.ToString( );
            _reprogrammingNumber = dataRow[ "ReprogrammingNumber" ]?.ToString( );
            _controlNumber = dataRow[ "ControlNumber" ]?.ToString( );
            _line = dataRow[ "Line" ]?.ToString( );
            _subline = dataRow[ "Subline" ]?.ToString( );
            _purpose = dataRow[ "Purpose" ]?.ToString( );
            _bocCode = dataRow[ "BocCode" ]?.ToString( );
            _bocName = dataRow[ "BocName" ]?.ToString( );
            _programAreaCode = dataRow[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = dataRow[ "ProgramAreaName" ]?.ToString( );
            _npmCode = dataRow[ "NpmCode" ]?.ToString( );
            _map = dataRow.ToDictionary( );
        }
    }
}