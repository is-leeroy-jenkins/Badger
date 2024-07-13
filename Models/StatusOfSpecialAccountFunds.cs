// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="StatusOfSpecialAccountFunds.cs" company="Terry D. Eppler">
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
//   StatusOfSpecialAccountFunds.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.PRC"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    public class StatusOfSpecialAccountFunds : SpecialAccount
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfSpecialAccountFunds"/>
        /// class.
        /// </summary>
        public StatusOfSpecialAccountFunds( )
            : base( )
        {
            _source = Source.StatusOfSpecialAccountFunds;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfSpecialAccountFunds" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public StatusOfSpecialAccountFunds( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "StatusOfSpecialAccountFundsId" ]?.ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
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
            _programCode = _record[ "ProgramCode" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _rcCode = _record[ "RcCode" ]?.ToString( );
            _rcName = _record[ "RcName" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _siteCode = _record[ "SiteCode" ]?.ToString( );
            _siteName = _record[ "SiteName" ]?.ToString( );
            _epaSiteId = _record[ "EpaSiteId" ]?.ToString( );
            _specialAccountNumber = _record[ "SpecialAccountNumber" ]?.ToString( );
            _specialAccountName = _record[ "SpecialAccountName" ]?.ToString( );
            _operableUnit = _record[ "OperableUnit" ]?.ToString( );
            _pipelineCode = _record[ "PipelineCode" ]?.ToString( );
            _pipelineDescription = _record[ "PipelineDescription" ]?.ToString( );
            _accountStatus = _record[ "AccountStatus" ]?.ToString( );
            _nplStatusCode = _record[ "NplStatusCode" ]?.ToString( );
            _nplStatusName = _record[ "NplStatusName" ]?.ToString( );
            _transactionType = _record[ "TransactionType" ]?.ToString( );
            _transactionDescription = _record[ "TrasnactionDescription" ]?.ToString( );
            _interestDate = DateTime.Parse( _record[ "InterestDate" ]?.ToString( ) );
            _interest = double.Parse( _record[ "Interest" ]?.ToString( ) ?? "0" );
            _unpaidBalances = double.Parse( _record[ "UnpaidBalances" ]?.ToString( ) );
            _disbursements = double.Parse( _record[ "Disbursements" ]?.ToString( ) );
            _netReceipts = double.Parse( _record[ "NetReceipts" ]?.ToString( ) );
            _trustfundTransfers = double.Parse( _record[ "TrustFundTransfers" ]?.ToString( ) );
            _cumulativeReceipts = double.Parse( _record[ "CumulativeReciepts" ]?.ToString( ) );
            _available = double.Parse( _record[ "Available" ]?.ToString( ) ?? "0" );
            _programProjectCode = _record[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = _record[ "ProgramProjectName" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _npmName = _record[ "NpmName" ]?.ToString( );
            _goalCode = _record[ "GoalCode" ]?.ToString( );
            _goalName = _record[ "GoalName" ]?.ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ]?.ToString( );
            _objectiveName = _record[ "ObjectiveName" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _collectionsAndInterest =
                double.Parse( _record[ "CollectionsAndInterest" ]?.ToString( ) ?? "0" );

            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ]?.ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfSpecialAccountFunds" />
        /// class.
        /// </summary>
        /// <param name="builder"> </param>
        public StatusOfSpecialAccountFunds( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "StatusOfSpecialAccountFundsId" ]?.ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
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
            _programCode = _record[ "ProgramCode" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _rcCode = _record[ "RcCode" ]?.ToString( );
            _rcName = _record[ "RcName" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _siteCode = _record[ "SiteCode" ]?.ToString( );
            _siteName = _record[ "SiteName" ]?.ToString( );
            _epaSiteId = _record[ "EpaSiteId" ]?.ToString( );
            _specialAccountNumber = _record[ "SpecialAccountNumber" ]?.ToString( );
            _specialAccountName = _record[ "SpecialAccountName" ]?.ToString( );
            _operableUnit = _record[ "OperableUnit" ]?.ToString( );
            _pipelineCode = _record[ "PipelineCode" ]?.ToString( );
            _pipelineDescription = _record[ "PipelineDescription" ]?.ToString( );
            _accountStatus = _record[ "AccountStatus" ]?.ToString( );
            _nplStatusCode = _record[ "NplStatusCode" ]?.ToString( );
            _nplStatusName = _record[ "NplStatusName" ]?.ToString( );
            _transactionType = _record[ "TransactionType" ]?.ToString( );
            _transactionDescription = _record[ "TrasnactionDescription" ]?.ToString( );
            _interestDate = DateTime.Parse( _record[ "InterestDate" ]?.ToString( ) );
            _interest = double.Parse( _record[ "Interest" ]?.ToString( ) ?? "0" );
            _unpaidBalances = double.Parse( _record[ "UnpaidBalances" ]?.ToString( ) );
            _disbursements = double.Parse( _record[ "Disbursements" ]?.ToString( ) );
            _netReceipts = double.Parse( _record[ "NetReceipts" ]?.ToString( ) );
            _trustfundTransfers = double.Parse( _record[ "TrustFundTransfers" ]?.ToString( ) );
            _cumulativeReceipts = double.Parse( _record[ "CumulativeReciepts" ]?.ToString( ) );
            _available = double.Parse( _record[ "Available" ]?.ToString( ) ?? "0" );
            _programProjectCode = _record[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = _record[ "ProgramProjectName" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _npmName = _record[ "NpmName" ]?.ToString( );
            _goalCode = _record[ "GoalCode" ]?.ToString( );
            _goalName = _record[ "GoalName" ]?.ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ]?.ToString( );
            _objectiveName = _record[ "ObjectiveName" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _collectionsAndInterest =
                double.Parse( _record[ "CollectionsAndInterest" ]?.ToString( ) ?? "0" );

            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ]?.ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfSpecialAccountFunds" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public StatusOfSpecialAccountFunds( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "StatusOfSpecialAccountFundsId" ]?.ToString( ) ?? "0" );
            _budgetLevel = dataRow[ "BudgetLevel" ]?.ToString( );
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
            _programCode = dataRow[ "ProgramCode" ]?.ToString( );
            _bocCode = dataRow[ "BocCode" ]?.ToString( );
            _bocName = dataRow[ "BocName" ]?.ToString( );
            _rcCode = dataRow[ "RcCode" ]?.ToString( );
            _rcName = dataRow[ "RcName" ]?.ToString( );
            _bocCode = dataRow[ "BocCode" ]?.ToString( );
            _bocName = dataRow[ "BocName" ]?.ToString( );
            _siteCode = dataRow[ "SiteCode" ]?.ToString( );
            _siteName = dataRow[ "SiteName" ]?.ToString( );
            _epaSiteId = dataRow[ "EpaSiteId" ]?.ToString( );
            _specialAccountNumber = dataRow[ "SpecialAccountNumber" ]?.ToString( );
            _specialAccountName = dataRow[ "SpecialAccountName" ]?.ToString( );
            _operableUnit = dataRow[ "OperableUnit" ]?.ToString( );
            _pipelineCode = dataRow[ "PipelineCode" ]?.ToString( );
            _pipelineDescription = dataRow[ "PipelineDescription" ]?.ToString( );
            _accountStatus = dataRow[ "AccountStatus" ]?.ToString( );
            _nplStatusCode = dataRow[ "NplStatusCode" ]?.ToString( );
            _nplStatusName = dataRow[ "NplStatusName" ]?.ToString( );
            _transactionType = dataRow[ "TransactionType" ]?.ToString( );
            _transactionDescription = dataRow[ "TrasnactionDescription" ]?.ToString( );
            _interestDate = DateTime.Parse( dataRow[ "InterestDate" ]?.ToString( ) );
            _interest = double.Parse( dataRow[ "Interest" ]?.ToString( ) ?? "0" );
            _unpaidBalances = double.Parse( dataRow[ "UnpaidBalances" ]?.ToString( ) );
            _disbursements = double.Parse( dataRow[ "Disbursements" ]?.ToString( ) );
            _netReceipts = double.Parse( dataRow[ "NetReceipts" ]?.ToString( ) );
            _trustfundTransfers = double.Parse( dataRow[ "TrustFundTransfers" ]?.ToString( ) );
            _cumulativeReceipts = double.Parse( dataRow[ "CumulativeReciepts" ]?.ToString( ) );
            _available = double.Parse( dataRow[ "Available" ]?.ToString( ) ?? "0" );
            _programProjectCode = dataRow[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = dataRow[ "ProgramProjectName" ]?.ToString( );
            _programAreaCode = dataRow[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = dataRow[ "ProgramAreaName" ]?.ToString( );
            _npmCode = dataRow[ "NpmCode" ]?.ToString( );
            _npmName = dataRow[ "NpmName" ]?.ToString( );
            _goalCode = dataRow[ "GoalCode" ]?.ToString( );
            _goalName = dataRow[ "GoalName" ]?.ToString( );
            _objectiveCode = dataRow[ "ObjectiveCode" ]?.ToString( );
            _objectiveName = dataRow[ "ObjectiveName" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
            _collectionsAndInterest =
                double.Parse( dataRow[ "CollectionsAndInterest" ]?.ToString( ) ?? "0" );

            _unliquidatedObligations =
                double.Parse( dataRow[ "UnliquidatedObligations" ]?.ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="status">
        /// </param>
        public StatusOfSpecialAccountFunds( StatusOfSpecialAccountFunds status )
            : this( )
        {
            _id = status.ID;
            _budgetLevel = status.BudgetLevel;
            _fiscalYear = status.FiscalYear;
            _bfy = status.BFY;
            _efy = status.EFY;
            _fundCode = status.FundCode;
            _fundName = status.FundName;
            _rpioCode = status.RpioCode;
            _rpioName = status.RpioName;
            _ahCode = status.AhCode;
            _ahName = status.AhName;
            _orgCode = status.OrgCode;
            _orgName = status.OrgName;
            _accountCode = status.AccountCode;
            _bocCode = status.BocCode;
            _bocName = status.BocName;
            _interestDate = status.InterestDate;
            _siteCode = status.SiteCode;
            _siteId = status.SiteId;
            _siteName = status.SiteName;
            _cerclisSiteId = status.CerclisSiteId;
            _pipelineCode = status.PipelineCode;
            _pipelineDescription = status.PipelineDescription;
            _nplStatusCode = status.NplStatusCode;
            _nplStatusName = status.NplStatusName;
            _unpaidBalances = status.UnpaidBalances;
            _disbursements = status.Disbursements;
            _interest = status.Interest;
            _trustfundTransfers = status.TrustfundTransfers;
            _cumulativeReceipts = status.CumulativeReceipts;
            _collectionsAndInterest = status.CollectionsAndInterest;
            _expenditures = status.Expenditures;
            _netReceipts = status.NetReceipts;
            _available = status.Available;
            _programProjectCode = status.ProgramProjectCode;
            _programProjectName = status.ProgramProjectName;
            _programAreaCode = status.ProgramAreaCode;
            _programAreaName = status.ProgramAreaName;
            _npmCode = status.NpmCode;
            _npmName = status.NpmName;
            _treasuryAccountCode = status.TreasuryAccountCode;
            _treasuryAccountName = status.TreasuryAccountName;
            _budgetAccountCode = status.BudgetAccountCode;
            _budgetAccountName = status.BudgetAccountName;
        }
    }
}