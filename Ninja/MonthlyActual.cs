// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="MonthlyActual.cs" company="Terry D. Eppler">
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
//   MonthlyActual.cs
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
    /// <seealso cref="T:Badger.Actual" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class MonthlyActual : Actual
    {
        /// <summary>
        /// The net outlays
        /// </summary>
        private protected double _netOutlays;

        /// <summary>
        /// The gross outlays
        /// </summary>
        private protected double _grossOutlays;
        
        /// <summary>
        /// Gets or sets the net outlays.
        /// </summary>
        /// <value>
        /// The net outlays.
        /// </value>
        public double NetOutlays
        {
            get
            {
                return _netOutlays;
            }
            private protected set
            {
                _netOutlays = value;
            }
        }

        /// <summary>
        /// Gets or sets the gross outlays.
        /// </summary>
        /// <value>
        /// The gross outlays.
        /// </value>
        public double GrossOutlays
        {
            get
            {
                return _grossOutlays;
            }
            private protected set
            {
                _grossOutlays = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyActuals" /> class.
        /// </summary>
        public MonthlyActual( )
            : base( )
        {
            _source = Source.MonthlyActuals;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyActuals" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public MonthlyActual( IQuery query )
            : base( query )
        {
            _record = new DataBuilder( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "MonthlyActualsId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _appropriationCode = _record[ "AppropriationCode" ]?.ToString( );
            _appropriationName = _record[ "AppropriationName" ]?.ToString( );
            _subAppropriationCode = _record[ "SubAppropriationCode" ]?.ToString( );
            _subAppropriationName = _record[ "SubAppropriationName" ]?.ToString( );
            _ahCode = _record[ "AhCode" ]?.ToString( );
            _ahName = _record[ "AhName" ]?.ToString( );
            _orgCode = _record[ "OrgCode" ]?.ToString( );
            _orgName = _record[ "OrgName" ]?.ToString( );
            _accountCode = _record[ "AccountCode" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _obligations = double.Parse( _record[ "Obligations" ]?.ToString( ) ?? "0.0" );
            _grossOutlays = double.Parse( _record[ "GrossOutlays" ]?.ToString( ) ?? "0.0" );
            _netOutlays = double.Parse( _record[ "NetOutlays" ]?.ToString( ) ?? "0.0" );
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
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyActuals" /> class.
        /// </summary>
        /// <param name="builder"></param>
        public MonthlyActual( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "MonthlyActualsId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _appropriationCode = _record[ "AppropriationCode" ]?.ToString( );
            _appropriationName = _record[ "AppropriationName" ]?.ToString( );
            _subAppropriationCode = _record[ "SubAppropriationCode" ]?.ToString( );
            _subAppropriationName = _record[ "SubAppropriationName" ]?.ToString( );
            _ahCode = _record[ "AhCode" ]?.ToString( );
            _ahName = _record[ "AhName" ]?.ToString( );
            _orgCode = _record[ "OrgCode" ]?.ToString( );
            _orgName = _record[ "OrgName" ]?.ToString( );
            _accountCode = _record[ "AccountCode" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _obligations = double.Parse( _record[ "Obligations" ]?.ToString( ) ?? "0.0" );
            _grossOutlays = double.Parse( _record[ "GrossOutlays" ]?.ToString( ) ?? "0.0" );
            _netOutlays = double.Parse( _record[ "NetOutlays" ]?.ToString( ) ?? "0.0" );
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
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyActuals" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public MonthlyActual( DataRow dataRow )
            : base( dataRow )
        {
            _source = Source.MonthlyActuals;
            _record = dataRow;
            _map = _record.ToDictionary( );
            _id = int.Parse( dataRow[ "MonthlyActualsId" ]?.ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
            _rpioCode = dataRow[ "RpioCode" ]?.ToString( );
            _rpioName = dataRow[ "RpioName" ]?.ToString( );
            _appropriationCode = dataRow[ "AppropriationCode" ]?.ToString( );
            _appropriationName = dataRow[ "AppropriationName" ]?.ToString( );
            _subAppropriationCode = dataRow[ "SubAppropriationCode" ]?.ToString( );
            _subAppropriationName = dataRow[ "SubAppropriationName" ]?.ToString( );
            _ahCode = dataRow[ "AhCode" ]?.ToString( );
            _ahName = dataRow[ "AhName" ]?.ToString( );
            _orgCode = dataRow[ "OrgCode" ]?.ToString( );
            _orgName = dataRow[ "OrgName" ]?.ToString( );
            _accountCode = dataRow[ "AccountCode" ]?.ToString( );
            _bocCode = dataRow[ "BocCode" ]?.ToString( );
            _bocName = dataRow[ "BocName" ]?.ToString( );
            _obligations = double.Parse( dataRow[ "Obligations" ]?.ToString( ) ?? "0.0" );
            _grossOutlays = double.Parse( dataRow[ "GrossOutlays" ]?.ToString( ) ?? "0.0" );
            _netOutlays = double.Parse( dataRow[ "NetOutlays" ]?.ToString( ) ?? "0.0" );
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
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyActuals" /> class.
        /// </summary>
        /// <param name="actual">The actual.</param>
        public MonthlyActual( MonthlyActual actual )
            : this( )
        {
            _source = Source.MonthlyActuals;
            _id = actual.ID;
            _bfy = actual.BFY;
            _efy = actual.EFY;
            _fundCode = actual.FundCode;
            _fundName = actual.FundName;
            _rpioCode = actual.RpioCode;
            _rpioName = actual.RpioName;
            _ahCode = actual.AhCode;
            _ahName = actual.AhName;
            _appropriationCode = actual.AppropriationCode;
            _appropriationName = actual.AppropriationName;
            _subAppropriationCode = actual.SubAppropriationCode;
            _subAppropriationName = actual.SubAppropriationName;
            _orgCode = actual.OrgCode;
            _orgName = actual.OrgName;
            _accountCode = actual.AccountCode;
            _bocCode = actual.BocCode;
            _bocName = actual.BocName;
            _activityCode = actual.ActivityCode;
            _activityName = actual.ActivityName;
            _programProjectCode = actual.ProgramProjectCode;
            _programProjectName = actual.ProgramProjectName;
            _obligations = actual.Obligations;
            _grossOutlays = actual.GrossOutlays;
            _netOutlays = actual.NetOutlays;
            _programAreaCode = actual.ProgramAreaCode;
            _programAreaName = actual.ProgramAreaName;
            _goalCode = actual.GoalCode;
            _goalName = actual.GoalName;
            _objectiveCode = actual.ObjectiveCode;
            _objectiveName = actual.ObjectiveName;
            _treasuryAccountCode = actual.TreasuryAccountCode;
            _treasuryAccountName = actual.TreasuryAccountName;
            _budgetAccountCode = actual.BudgetAccountCode;
            _budgetAccountName = actual.BudgetAccountName;
        }
    }
}