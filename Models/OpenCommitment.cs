// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
//
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
// ******************************************************************************************
// <copyright file="${File.FileName}" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  ${CurrentDate.Year}  Terry D. Eppler
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
//   ${File.FileName}
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    [SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" )]
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "FunctionComplexityOverflow" )]
    [SuppressMessage( "ReSharper", "UnusedType.Global" )]
    [SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" )]
    public class OpenCommitment : Obligation
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.OpenCommitments" />
        /// class.
        /// </summary>
        public OpenCommitment( )
        {
            _source = Source.OpenCommitments;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.OpenCommitments" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public OpenCommitment( IQuery query )
            : base( query )
        {
            _source = Source.OpenCommitments;
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "OpenCommitmentsId" ]?.ToString( ) ?? "0" );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
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
            _focCode = _record[ "FocCode" ]?.ToString( );
            _focName = _record[ "FocName" ]?.ToString( );
            _amount = double.Parse( _record[ "OpenCommitments" ]?.ToString( ) ?? "0.0" );
            _documentType = _record[ "DocumentType" ]?.ToString( );
            _documentNumber = _record[ "DocumentNumber" ]?.ToString( );
            _referenceDocumentNumber = _record[ "ReferenceDocumentNumber" ]?.ToString( );
            _vendorCode = _record[ "VendorCode" ]?.ToString( );
            _vendorName = _record[ "VendorName" ]?.ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ]?.ToString( ) );
            _lastActivityDate = DateTime.Parse( _record[ "LastActivityDate" ]?.ToString( ) );
            _age = int.Parse( _record[ "Age" ]?.ToString( ) ?? "0" );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _npmName = _record[ "NpmName" ]?.ToString( );
            _goalCode = _record[ "GoalCode" ]?.ToString( );
            _goalName = _record[ "GoalName" ]?.ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ]?.ToString( );
            _objectiveName = _record[ "ObjectiveName" ]?.ToString( );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.OpenCommitments" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public OpenCommitment( IDataModel builder )
            : base( builder )
        {
            _source = Source.OpenCommitments;
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "OpenCommitmentsId" ]?.ToString( ) ?? "0" );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
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
            _focCode = _record[ "FocCode" ]?.ToString( );
            _focName = _record[ "FocName" ]?.ToString( );
            _amount = double.Parse( _record[ "OpenCommitments" ]?.ToString( ) ?? "0.0" );
            _documentType = _record[ "DocumentType" ]?.ToString( );
            _documentNumber = _record[ "DocumentNumber" ]?.ToString( );
            _referenceDocumentNumber = _record[ "ReferenceDocumentNumber" ]?.ToString( );
            _vendorCode = _record[ "VendorCode" ]?.ToString( );
            _vendorName = _record[ "VendorName" ]?.ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ]?.ToString( ) );
            _lastActivityDate = DateTime.Parse( _record[ "LastActivityDate" ]?.ToString( ) );
            _age = int.Parse( _record[ "Age" ]?.ToString( ) ?? "0" );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _npmName = _record[ "NpmName" ]?.ToString( );
            _goalCode = _record[ "GoalCode" ]?.ToString( );
            _goalName = _record[ "GoalName" ]?.ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ]?.ToString( );
            _objectiveName = _record[ "ObjectiveName" ]?.ToString( );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.OpenCommitments" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public OpenCommitment( DataRow dataRow )
            : base( dataRow )
        {
            _source = Source.OpenCommitments;
            _record = dataRow;
            _map = _record.ToDictionary( );
            _id = int.Parse( dataRow[ "OpenCommitmentsId" ]?.ToString( ) ?? "0" );
            _fiscalYear = dataRow[ "FiscalYear" ]?.ToString( );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
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
            _focCode = dataRow[ "FocCode" ]?.ToString( );
            _focName = dataRow[ "FocName" ]?.ToString( );
            _amount = double.Parse( dataRow[ "OpenCommitments" ]?.ToString( ) ?? "0.0" );
            _documentType = dataRow[ "DocumentType" ]?.ToString( );
            _documentNumber = dataRow[ "DocumentNumber" ]?.ToString( );
            _referenceDocumentNumber = dataRow[ "ReferenceDocumentNumber" ]?.ToString( );
            _vendorCode = dataRow[ "VendorCode" ]?.ToString( );
            _vendorName = dataRow[ "VendorName" ]?.ToString( );
            _processedDate = DateTime.Parse( dataRow[ "ProcessedDate" ]?.ToString( ) );
            _lastActivityDate = DateTime.Parse( dataRow[ "LastActivityDate" ]?.ToString( ) );
            _age = int.Parse( dataRow[ "Age" ]?.ToString( ) ?? "0" );
            _programAreaCode = dataRow[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = dataRow[ "ProgramAreaName" ]?.ToString( );
            _npmCode = dataRow[ "NpmCode" ]?.ToString( );
            _npmName = dataRow[ "NpmName" ]?.ToString( );
            _goalCode = dataRow[ "GoalCode" ]?.ToString( );
            _goalName = dataRow[ "GoalName" ]?.ToString( );
            _objectiveCode = dataRow[ "ObjectiveCode" ]?.ToString( );
            _objectiveName = dataRow[ "ObjectiveName" ]?.ToString( );
            _mainAccount = dataRow[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.OpenCommitments" /> class.
        /// </summary>
        /// <param name="commitment">The commitment.</param>
        public OpenCommitment( OpenCommitment commitment )
        {
            _id = commitment.ID;
            _fiscalYear = commitment.FiscalYear;
            _bfy = commitment.BFY;
            _efy = commitment.EFY;
            _fundCode = commitment.FundCode;
            _fundName = commitment.FundName;
            _rpioCode = commitment.RpioCode;
            _rpioName = commitment.RpioName;
            _ahCode = commitment.AhCode;
            _ahName = commitment.AhName;
            _orgCode = commitment.OrgCode;
            _orgName = commitment.OrgName;
            _accountCode = commitment.AccountCode;
            _bocCode = commitment.BocCode;
            _bocName = commitment.BocName;
            _focCode = commitment.FocCode;
            _focName = commitment.FocName;
            _amount = commitment.Amount;
            _documentType = commitment.DocumentType;
            _documentNumber = commitment.DocumentNumber;
            _referenceDocumentNumber = commitment.ReferenceDocumentNumber;
            _vendorCode = commitment.VendorCode;
            _vendorName = commitment.VendorName;
            _processedDate = commitment.ProcessedDate;
            _lastActivityDate = commitment.LastActivityDate;
            _age = commitment.Age;
            _programProjectCode = commitment.ProgramProjectCode;
            _programProjectName = commitment.ProgramProjectName;
            _programAreaCode = commitment.ProgramAreaCode;
            _programAreaName = commitment.ProgramAreaName;
            _npmCode = commitment.NpmCode;
            _npmName = commitment.NpmName;
            _goalCode = commitment.GoalCode;
            _goalName = commitment.GoalName;
            _objectiveCode = commitment.ObjectiveCode;
            _objectiveName = commitment.ObjectiveName;
            _treasuryAccountCode = commitment.TreasuryAccountCode;
            _treasuryAccountName = commitment.TreasuryAccountName;
            _budgetAccountCode = commitment.BudgetAccountCode;
            _budgetAccountName = commitment.BudgetAccountName;
        }
    }
}