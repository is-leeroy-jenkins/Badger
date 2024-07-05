// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="UnliquidatedObligation.cs" company="Terry D. Eppler">
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
//   UnliquidatedObligation.cs
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
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameterInConstructor" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class UnliquidatedObligation : Obligation
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.UnliquidatedObligation" />
        /// class.
        /// </summary>
        public UnliquidatedObligation( ) 
            : base( )
        {
            _source = Source.UnliquidatedObligations;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.UnliquidatedObligation" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public UnliquidatedObligation( IQuery query )
            : base( query )
        {
            _source = Source.UnliquidatedObligations;
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "UnliquidatedObligationsId" ].ToString( ) ?? "0" );
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
            _amount = double.Parse( _record[ "UnliquidatedObligations" ]?.ToString( ) ?? "0.0" );
            _documentType = _record[ "DocumentType" ]?.ToString( );
            _documentNumber = _record[ "DocumentNumber" ]?.ToString( );
            _referenceDocumentNumber = _record[ "ReferenceDocumentNumber" ]?.ToString( );
            _vendorCode = _record[ "VendorCode" ]?.ToString( );
            _vendorName = _record[ "VendorName" ]?.ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ]?.ToString( ) );
            _lastActivityDate = DateTime.Parse( _record[ "LastActivityDate" ]?.ToString( ) );
            _age = int.Parse( _record[ "Age" ].ToString( ) ?? "0" );
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
        /// <see cref="T:Badger.UnliquidatedObligations" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public UnliquidatedObligation( IDataModel builder )
            : base( builder )
        {
            _source = Source.UnliquidatedObligations;
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "UnliquidatedObligationsId" ].ToString( ) ?? "0" );
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
            _amount = double.Parse( _record[ "UnliquidatedObligations" ]?.ToString( ) ?? "0.0" );
            _documentType = _record[ "DocumentType" ]?.ToString( );
            _documentNumber = _record[ "DocumentNumber" ]?.ToString( );
            _referenceDocumentNumber = _record[ "ReferenceDocumentNumber" ]?.ToString( );
            _vendorCode = _record[ "VendorCode" ].ToString( );
            _vendorName = _record[ "VendorName" ].ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ]?.ToString( ) );
            _lastActivityDate = DateTime.Parse( _record[ "LastActivityDate" ]?.ToString( ) );
            _age = int.Parse( _record[ "Age" ].ToString( ) ?? "0" );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _npmName = _record[ "NpmName" ]?.ToString( );
            _goalCode = _record[ "GoalCode" ]?.ToString( );
            _goalName = _record[ "GoalName" ]?.ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ]?.ToString( );
            _objectiveName = _record[ "ObjectiveName" ]?.ToString( );
            _mainAccount = _record[ "MainAccount" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.UnliquidatedObligation" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public UnliquidatedObligation( DataRow dataRow )
            : base( dataRow )
        {
            _source = Source.UnliquidatedObligations;
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "UnliquidatedObligationsId" ].ToString( ) ?? "0" );
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
            _amount = double.Parse( dataRow[ "UnliquidatedObligations" ]?.ToString( ) ?? "0.0" );
            _documentType = dataRow[ "DocumentType" ]?.ToString( );
            _documentNumber = dataRow[ "DocumentNumber" ]?.ToString( );
            _referenceDocumentNumber = dataRow[ "ReferenceDocumentNumber" ]?.ToString( );
            _vendorCode = dataRow[ "VendorCode" ]?.ToString( );
            _vendorName = dataRow[ "VendorName" ]?.ToString( );
            _processedDate = DateTime.Parse( dataRow[ "ProcessedDate" ]?.ToString( ) );
            _lastActivityDate = DateTime.Parse( dataRow[ "LastActivityDate" ]?.ToString( ) );
            _age = int.Parse( dataRow[ "Age" ].ToString( ) ?? "0" );
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
        /// <see cref="T:Badger.UnliquidatedObligation" /> class.
        /// </summary>
        /// <param name="obligation">The ulo.</param>
        public UnliquidatedObligation( UnliquidatedObligation obligation )
            : this( )
        {
            _id = obligation.ID;
            _fiscalYear = obligation.FiscalYear;
            _bfy = obligation.BFY;
            _efy = obligation.EFY;
            _fundCode = obligation.FundCode;
            _fundName = obligation.FundName;
            _rpioCode = obligation.RpioCode;
            _rpioName = obligation.RpioName;
            _ahCode = obligation.AhCode;
            _ahName = obligation.AhName;
            _orgCode = obligation.OrgCode;
            _orgName = obligation.OrgName;
            _accountCode = obligation.AccountCode;
            _bocCode = obligation.BocCode;
            _bocName = obligation.BocName;
            _focCode = obligation.FocCode;
            _focName = obligation.FocName;
            _amount = obligation.Amount;
            _documentType = obligation.DocumentType;
            _documentNumber = obligation.DocumentNumber;
            _referenceDocumentNumber = obligation.ReferenceDocumentNumber;
            _vendorCode = obligation.VendorCode;
            _vendorName = obligation.VendorName;
            _processedDate = obligation.ProcessedDate;
            _lastActivityDate = obligation.LastActivityDate;
            _age = obligation.Age;
            _programProjectCode = obligation.ProgramProjectCode;
            _programProjectName = obligation.ProgramProjectName;
            _programAreaCode = obligation.ProgramAreaCode;
            _programAreaName = obligation.ProgramAreaName;
            _npmCode = obligation.NpmCode;
            _npmName = obligation.NpmName;
            _goalCode = obligation.GoalCode;
            _goalName = obligation.GoalName;
            _objectiveCode = obligation.ObjectiveCode;
            _objectiveName = obligation.ObjectiveName;
            _treasuryAccountCode = obligation.TreasuryAccountCode;
            _treasuryAccountName = obligation.TreasuryAccountName;
            _budgetAccountCode = obligation.BudgetAccountCode;
            _budgetAccountName = obligation.BudgetAccountName;
        }
    }
}