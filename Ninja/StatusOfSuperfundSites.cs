// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="StatusOfSuperfundSites.cs" company="Terry D. Eppler">
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
//   StatusOfSuperfundSites.cs
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    public class StatusOfSuperfundSites : StatusOfFunds
    {
        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// </value>
        private double _deobligations;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// </value>
        private string _stateCode;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// </value>
        private string _stateName;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// </value>
        private string _city;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// </value>
        private string _streetAddress;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// </value>
        private string _zipCode;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// </value>
        public string StateCode
        {
            get
            {
                return _stateCode;
            }
            private set
            {
                _stateCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the state name.
        /// </summary>
        /// <value> The state. </value>
        public string StateName
        {
            get
            {
                return _stateCode;
            }
            private set
            {
                _stateCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value> The city. </value>
        public string City
        {
            get
            {
                return _stateCode;
            }
            private set
            {
                _stateCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the congressional district.
        /// </summary>
        /// <value> The congressional district. </value>
        public string StreetAddress
        {
            get
            {
                return _stateCode;
            }
            private set
            {
                _stateCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the project.
        /// </summary>
        /// <value> The type of the project. </value>
        public string ZipCode
        {
            get
            {
                return _stateCode;
            }
            private set
            {
                _stateCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the Deobligations.
        /// </summary>
        /// <value> The Deobligations. </value>
        public double Deobligations
        {
            get
            {
                return _deobligations;
            }
            private set
            {
                _deobligations = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfSuperfundSites" />
        /// class.
        /// </summary>
        public StatusOfSuperfundSites( )
        {
            _source = Source.StatusOfSuperfundSites;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfSuperfundSites" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public StatusOfSuperfundSites( IQuery query ) : base( query )
        {
            _record = new DataBuilder( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "StatusOfSuperfundSitesId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _ahCode = _record[ "AhCode" ].ToString( );
            _ahName = _record[ "AhName" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _orgName = _record[ "OrgName" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _stateCode = _record[ "StateCode" ]?.ToString( );
            _stateName = _record[ "StateName" ]?.ToString( );
            _streetAddress = _record[ "StreetAddress" ]?.ToString( );
            _zipCode = _record[ "ZipCode" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0.0" );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0.0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) ?? "0.0" );
            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) ?? "0.0" );
            _expenditures = double.Parse( _record[ "Expenditures" ].ToString( ) ?? "0.0" );
            _used = double.Parse( _record[ "Used" ].ToString( ) ?? "0.0" );
            _available = double.Parse( _record[ "Available" ].ToString( ) ?? "0.0" );
            _programProjectCode = _record[ "ProgramProjectCode" ].ToString( );
            _programProjectName = _record[ "ProgramProjectName" ].ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ].ToString( );
            _programAreaName = _record[ "ProgramAreaName" ].ToString( );
            _npmCode = _record[ "NpmCode" ].ToString( );
            _npmName = _record[ "NpmName" ].ToString( );
            _goalCode = _record[ "GoalCode" ].ToString( );
            _goalName = _record[ "GoalName" ].ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ].ToString( );
            _objectiveName = _record[ "ObjectiveName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ].ToString( ) ?? "0.0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfSuperfundSites" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public StatusOfSuperfundSites( IDataModel builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "StatusOfSuperfundSitesId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _ahCode = _record[ "AhCode" ].ToString( );
            _ahName = _record[ "AhName" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _orgName = _record[ "OrgName" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _stateCode = _record[ "StateCode" ]?.ToString( );
            _stateName = _record[ "StateName" ]?.ToString( );
            _streetAddress = _record[ "StreetAddress" ]?.ToString( );
            _zipCode = _record[ "ZipCode" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0.0" );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0.0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) ?? "0.0" );
            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) ?? "0.0" );
            _expenditures = double.Parse( _record[ "Expenditures" ].ToString( ) ?? "0.0" );
            _used = double.Parse( _record[ "Used" ].ToString( ) ?? "0.0" );
            _available = double.Parse( _record[ "Available" ].ToString( ) ?? "0.0" );
            _programProjectCode = _record[ "ProgramProjectCode" ].ToString( );
            _programProjectName = _record[ "ProgramProjectName" ].ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ].ToString( );
            _programAreaName = _record[ "ProgramAreaName" ].ToString( );
            _npmCode = _record[ "NpmCode" ].ToString( );
            _npmName = _record[ "NpmName" ].ToString( );
            _goalCode = _record[ "GoalCode" ].ToString( );
            _goalName = _record[ "GoalName" ].ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ].ToString( );
            _objectiveName = _record[ "ObjectiveName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ].ToString( ) ?? "0.0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfSuperfundSites" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public StatusOfSuperfundSites( DataRow dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( _record[ "StatusOfSuperfundSitesId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _ahCode = _record[ "AhCode" ].ToString( );
            _ahName = _record[ "AhName" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _orgName = _record[ "OrgName" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _stateCode = _record[ "StateCode" ]?.ToString( );
            _stateName = _record[ "StateName" ]?.ToString( );
            _streetAddress = _record[ "StreetAddress" ]?.ToString( );
            _zipCode = _record[ "ZipCode" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0.0" );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0.0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) ?? "0.0" );
            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) ?? "0.0" );
            _expenditures = double.Parse( _record[ "Expenditures" ].ToString( ) ?? "0.0" );
            _used = double.Parse( _record[ "Used" ].ToString( ) ?? "0.0" );
            _available = double.Parse( _record[ "Available" ].ToString( ) ?? "0.0" );
            _programProjectCode = _record[ "ProgramProjectCode" ].ToString( );
            _programProjectName = _record[ "ProgramProjectName" ].ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ].ToString( );
            _programAreaName = _record[ "ProgramAreaName" ].ToString( );
            _npmCode = _record[ "NpmCode" ].ToString( );
            _npmName = _record[ "NpmName" ].ToString( );
            _goalCode = _record[ "GoalCode" ].ToString( );
            _goalName = _record[ "GoalName" ].ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ].ToString( );
            _objectiveName = _record[ "ObjectiveName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ].ToString( ) ?? "0.0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="status"> </param>
        public StatusOfSuperfundSites( StatusOfSuperfundSites status )
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
            _stateCode = status.StateCode;
            _stateName = status.StateName;
            _streetAddress = status.StreetAddress;
            _zipCode = status.ZipCode;
            _amount = status.Amount;
            _budgeted = status.Budgeted;
            _posted = status.Posted;
            _openCommitments = status.OpenCommitments;
            _unliquidatedObligations = status.UnliquidatedObligations;
            _obligations = status.Obligations;
            _expenditures = status.Expenditures;
            _used = status.Used;
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