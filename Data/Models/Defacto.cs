﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="Defacto.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
// 
//    Copyright ©  2020-2024 Terry D. Eppler
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
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   Defacto.cs
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
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class Defacto : StatusOfFunds
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Defacto"/>
        /// class.
        /// </summary>
        public Defacto( )
            : base( )
        {
            _source = Source.Defactos;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Defacto"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Defacto( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "DefactosId" ]?.ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
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
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0.0" );
            _budgeted = double.Parse( _record[ "Budgeted" ]?.ToString( ) ?? "0.0" );
            _posted = double.Parse( _record[ "Posted" ]?.ToString( ) ?? "0.0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ]?.ToString( ) ?? "0.0" );
            _unliquidatedObligations = double.Parse( _record[ "ULO" ]?.ToString( ) ?? "0.0" );
            _obligations = double.Parse( _record[ "Obligations" ]?.ToString( ) ?? "0.0" );
            _expenditures = double.Parse( _record[ "Expenditures" ]?.ToString( ) ?? "0.0" );
            _used = double.Parse( _record[ "Used" ]?.ToString( ) ?? "0.0" );
            _available = double.Parse( _record[ "Available" ]?.ToString( ) ?? "0.0" );
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

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Defacto"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public Defacto( DataGenerator builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "DefactosId" ]?.ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
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
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0.0" );
            _budgeted = double.Parse( _record[ "Budgeted" ]?.ToString( ) ?? "0.0" );
            _posted = double.Parse( _record[ "Posted" ]?.ToString( ) ?? "0.0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ]?.ToString( ) ?? "0.0" );
            _unliquidatedObligations = double.Parse( _record[ "ULO" ]?.ToString( ) ?? "0.0" );
            _obligations = double.Parse( _record[ "Obligations" ]?.ToString( ) ?? "0.0" );
            _expenditures = double.Parse( _record[ "Expenditures" ]?.ToString( ) ?? "0.0" );
            _used = double.Parse( _record[ "Used" ]?.ToString( ) ?? "0.0" );
            _available = double.Parse( _record[ "Available" ]?.ToString( ) ?? "0.0" );
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

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Defacto"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public Defacto( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "DefactosId" ]?.ToString( ) ?? "0" );
            _budgetLevel = dataRow[ "BudgetLevel" ]?.ToString( );
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
            _amount = double.Parse( dataRow[ "Amount" ]?.ToString( ) ?? "0.0" );
            _budgeted = double.Parse( dataRow[ "Budgeted" ]?.ToString( ) ?? "0.0" );
            _posted = double.Parse( dataRow[ "Posted" ]?.ToString( ) ?? "0.0" );
            _openCommitments = double.Parse( dataRow[ "OpenCommitments" ]?.ToString( ) ?? "0.0" );
            _unliquidatedObligations = double.Parse( dataRow[ "ULO" ]?.ToString( ) ?? "0.0" );
            _obligations = double.Parse( dataRow[ "Obligations" ]?.ToString( ) ?? "0.0" );
            _expenditures = double.Parse( dataRow[ "Expenditures" ]?.ToString( ) ?? "0.0" );
            _used = double.Parse( dataRow[ "Used" ]?.ToString( ) ?? "0.0" );
            _available = double.Parse( dataRow[ "Available" ]?.ToString( ) ?? "0.0" );
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

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Defacto"/>
        /// class.
        /// </summary>
        /// <param name="defacto"> The defacto. </param>
        public Defacto( Defacto defacto )
            : base( )
        {
            _id = defacto.ID;
            _budgetLevel = defacto.BudgetLevel;
            _bfy = defacto.BFY;
            _efy = defacto.EFY;
            _fundCode = defacto.FundCode;
            _fundName = defacto.FundName;
            _rpioCode = defacto.RpioCode;
            _rpioName = defacto.RpioName;
            _ahCode = defacto.AhCode;
            _ahName = defacto.AhName;
            _orgCode = defacto.OrgCode;
            _orgName = defacto.OrgName;
            _accountCode = defacto.AccountCode;
            _bocCode = defacto.BocCode;
            _bocName = defacto.BocName;
            _available = defacto.Available;
            _programProjectCode = defacto.ProgramProjectCode;
            _programProjectName = defacto.ProgramProjectName;
            _programAreaCode = defacto.ProgramAreaCode;
            _programAreaName = defacto.ProgramAreaName;
            _npmCode = defacto.NpmCode;
            _npmName = defacto.NpmName;
            _treasuryAccountCode = defacto.TreasuryAccountCode;
            _treasuryAccountName = defacto.TreasuryAccountName;
            _budgetAccountCode = defacto.BudgetAccountCode;
            _budgetAccountName = defacto.BudgetAccountName;
        }
    }
}