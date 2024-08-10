// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="FullTimeEquivalent.cs" company="Terry D. Eppler">
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
//   FullTimeEquivalent.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary>
    /// Full-time equivalent (FullTimeEquivalents) or whole time equivalent (WTE) is a unit that indicates
    /// the workload of an employed person (or student) in a way that makes workloads or class loads
    /// comparable across various contexts. FullTimeEquivalent is often used to measure a worker's or
    /// student's involvement in a project, or to track cost reductions in an organization. An
    /// FullTimeEquivalent of 1.0 is equivalent to a full-time worker or student, while an
    /// FullTimeEquivalent of 0.5 signals half of a full work or school load.
    /// </summary>
    /// <seealso cref="T:Badger.ProgramResultsCode"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class FullTimeEquivalent : OperatingPlan
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FullTimeEquivalent"/>
        /// class.
        /// </summary>
        public FullTimeEquivalent( )
        {
            _source = Source.FullTimeEquivalents;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FullTimeEquivalent"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public FullTimeEquivalent( IQuery query )
            : base( query )
        {
            _source = Source.FullTimeEquivalents;
            _record = new DataGenerator( query ).Record;
            _id = int.Parse( Record[ "FullTimeEquivalentsId" ].ToString( ) );
            _map = Record.ToDictionary( );
            _id = int.Parse( _record[ "AllocationsId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _ahCode = _record[ "AhCode" ].ToString( );
            _ahName = _record[ "AhName" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _orgName = _record[ "OrgName" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0.0" );
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
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FullTimeEquivalent"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The databuilder. </param>
        public FullTimeEquivalent( IDataService builder )
            : base( builder )
        {
            _source = Source.FullTimeEquivalents;
            _record = builder.Record;
            _id = int.Parse( Record[ "FullTimeEquivalentsId" ].ToString( ) );
            _map = Record.ToDictionary( );
            _id = int.Parse( _record[ "AllocationsId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _ahCode = _record[ "AhCode" ].ToString( );
            _ahName = _record[ "AhName" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _orgName = _record[ "OrgName" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0.0" );
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
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FullTimeEquivalent"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The dataRow. </param>
        public FullTimeEquivalent( DataRow dataRow )
            : base( dataRow )
        {
            _source = Source.FullTimeEquivalents;
            _record = dataRow;
            _id = int.Parse( dataRow[ "FullTimeEquivalentsId" ].ToString( ) );
            _budgetLevel = dataRow[ "BudgetLevel" ].ToString( );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _fundCode = dataRow[ "FundCode" ].ToString( );
            _fundName = dataRow[ "FundName" ].ToString( );
            _rpioCode = dataRow[ "RpioCode" ].ToString( );
            _rpioName = dataRow[ "RpioName" ].ToString( );
            _ahCode = dataRow[ "AhCode" ].ToString( );
            _ahName = dataRow[ "AhName" ].ToString( );
            _orgCode = dataRow[ "OrgCode" ].ToString( );
            _orgName = dataRow[ "OrgName" ].ToString( );
            _accountCode = dataRow[ "AccountCode" ].ToString( );
            _bocCode = dataRow[ "BocCode" ].ToString( );
            _bocName = dataRow[ "BocName" ].ToString( );
            _amount = double.Parse( dataRow[ "Amount" ].ToString( ) ?? "0.0" );
            _programProjectCode = dataRow[ "ProgramProjectCode" ].ToString( );
            _programProjectName = dataRow[ "ProgramProjectName" ].ToString( );
            _programAreaCode = dataRow[ "ProgramAreaCode" ].ToString( );
            _programAreaName = dataRow[ "ProgramAreaName" ].ToString( );
            _npmCode = dataRow[ "NpmCode" ].ToString( );
            _npmName = dataRow[ "NpmName" ].ToString( );
            _goalCode = dataRow[ "GoalCode" ].ToString( );
            _goalName = dataRow[ "GoalName" ].ToString( );
            _objectiveCode = dataRow[ "ObjectiveCode" ].ToString( );
            _objectiveName = dataRow[ "ObjectiveName" ].ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc/>
        /// <summary> </summary>
        /// <param name="allocations"> </param>
        public FullTimeEquivalent( Allocation allocations )
        {
            _id = allocations.ID;
            _budgetLevel = allocations.BudgetLevel;
            _bfy = allocations.BFY;
            _efy = allocations.EFY;
            _fundCode = allocations.FundCode;
            _fundName = allocations.FundName;
            _rpioCode = allocations.RpioCode;
            _rpioName = allocations.RpioName;
            _ahCode = allocations.AhCode;
            _ahName = allocations.AhName;
            _orgCode = allocations.OrgCode;
            _orgName = allocations.OrgName;
            _accountCode = allocations.AccountCode;
            _bocCode = allocations.BocCode;
            _bocName = allocations.BocName;
            _amount = allocations.Amount;
            _programProjectCode = allocations.ProgramProjectCode;
            _programProjectName = allocations.ProgramProjectName;
            _programAreaCode = allocations.ProgramAreaCode;
            _programAreaName = allocations.ProgramAreaName;
            _npmCode = allocations.NpmCode;
            _npmName = allocations.NpmName;
            _treasuryAccountCode = allocations.TreasuryAccountCode;
            _treasuryAccountName = allocations.TreasuryAccountName;
            _budgetAccountCode = allocations.BudgetAccountCode;
            _budgetAccountName = allocations.BudgetAccountName;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the ProgramResultCodes identifier.
        /// </summary>
        /// <returns>
        /// int
        /// </returns>
        public override int GetId( )
        {
            try
            {
                return _record != null
                    ? int.Parse( _record[ 0 ].ToString( ) )
                    : -1;
            }
            catch( Exception ex )
            {
                FullTimeEquivalent.Fail( ex );
                return default( int );
            }
        }
    }
}