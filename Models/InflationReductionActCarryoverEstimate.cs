// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="InflationReductionActCarryoverEstimate.cs" company="Terry D. Eppler">
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
//   InflationReductionActCarryoverEstimate.cs
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
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameterInConstructor" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class InflationReductionActCarryoverEstimate : AnnualCarryoverEstimate
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.InflationReductionActCarryoverEstimates" />
        /// class.
        /// </summary>
        public InflationReductionActCarryoverEstimate( )
            : base( )
        {
            _source = Source.InflationReductionActCarryoverEstimates;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.InflationReductionActCarryoverEstimates" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public InflationReductionActCarryoverEstimate( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "InflationReductionActCarryoverEstimatesId" ].ToString( ) );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) ?? "0" );
            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) ?? "0" );
            _estimate = double.Parse( _record[ "Estimate" ].ToString( ) ?? "0" );
            _available = double.Parse( _record[ "Available" ].ToString( ) ?? "0" );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.InflationReductionActCarryoverEstimate" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public InflationReductionActCarryoverEstimate( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "InflationReductionActCarryoverEstimatesId" ].ToString( ) );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _rpioCode = _record[ "RpioCode" ].ToString( );
            _rpioName = _record[ "RpioName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) ?? "0" );
            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) ?? "0" );
            _estimate = double.Parse( _record[ "Estimate" ].ToString( ) ?? "0" );
            _available = double.Parse( _record[ "Available" ].ToString( ) ?? "0" );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.InflationReductionActCarryoverEstimate" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public InflationReductionActCarryoverEstimate( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( _record[ "InflationReductionActCarryoverEstimatesId" ].ToString( ) );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _fundCode = dataRow[ "FundCode" ].ToString( );
            _fundName = dataRow[ "FundName" ].ToString( );
            _rpioCode = dataRow[ "RpioCode" ].ToString( );
            _rpioName = dataRow[ "RpioName" ].ToString( );
            _amount = double.Parse( dataRow[ "Amount" ].ToString( ) ?? "0" );
            _openCommitments = double.Parse( dataRow[ "OpenCommitments" ].ToString( ) ?? "0" );
            _obligations = double.Parse( dataRow[ "Obligations" ].ToString( ) ?? "0" );
            _estimate = double.Parse( dataRow[ "Estimate" ].ToString( ) ?? "0" );
            _available = double.Parse( dataRow[ "Available" ].ToString( ) ?? "0" );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.InflationReductionActCarryoverEstimate" />
        /// class.
        /// </summary>
        /// <param name="carryover"> The carryover. </param>
        public InflationReductionActCarryoverEstimate(
            InflationReductionActCarryoverEstimate carryover )
            : this( )
        {
            _id = carryover.ID;
            _bfy = carryover.BFY;
            _efy = carryover.EFY;
            _fundCode = carryover.FundCode;
            _fundName = carryover.FundName;
            _rpioCode = carryover.RpioCode;
            _rpioName = carryover.RpioName;
            _amount = carryover.Amount;
            _openCommitments = carryover.OpenCommitments;
            _obligations = carryover.Obligations;
            _available = carryover.Available;
            _estimate = carryover.Estimate;
            _treasuryAccountCode = carryover.TreasuryAccountCode;
            _treasuryAccountName = carryover.TreasuryAccountName;
            _budgetAccountCode = carryover.BudgetAccountCode;
            _budgetAccountName = carryover.BudgetAccountName;
        }
    }
}