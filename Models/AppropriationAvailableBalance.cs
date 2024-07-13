// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="AppropriationAvailableBalance.cs" company="Terry D. Eppler">
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
//   AppropriationAvailableBalance.cs
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
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    public class AppropriationAvailableBalance : PRC
    {
        /// <summary>
        /// The authority
        /// </summary>
        private double _authority;

        /// <summary>
        /// The budgeted
        /// </summary>
        private double _budgeted;

        /// <summary>
        /// The carryover in
        /// </summary>
        private double _carryoverIn;

        /// <summary>
        /// The carryover out
        /// </summary>
        private double _carryoverOut;

        /// <summary>
        /// The reimbursements
        /// </summary>
        private double _reimbursements;

        /// <summary>
        /// The recoveries
        /// </summary>
        private double _recoveries;

        /// <summary>
        /// The used
        /// </summary>
        private double _used;

        /// <summary>
        /// The available
        /// </summary>
        private double _available;

        /// <summary>
        /// Gets or sets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        public double Authority
        {
            get
            {
                return _authority;
            }
            private set
            {
                _authority = value;
            }
        }

        /// <summary>
        /// Gets or sets the budgeted.
        /// </summary>
        /// <value>
        /// The budgeted.
        /// </value>
        public double Budgeted
        {
            get
            {
                return _budgeted;
            }
            private set
            {
                _budgeted = value;
            }
        }

        /// <summary>
        /// Gets or sets the carryover.
        /// </summary>
        /// <value>
        /// The carryover.
        /// </value>
        public double CarryoverIn
        {
            get
            {
                return _carryoverIn;
            }
            private set
            {
                _carryoverIn = value;
            }
        }

        /// <summary>
        /// Gets or sets the carryover.
        /// </summary>
        /// <value>
        /// The carryover.
        /// </value>
        public double CarryoverOut
        {
            get
            {
                return _carryoverOut;
            }
            private set
            {
                _carryoverOut = value;
            }
        }

        /// <summary>
        /// Gets or sets the reimbursements.
        /// </summary>
        /// <value>
        /// The reimbursements.
        /// </value>
        public double Reimbursements
        {
            get
            {
                return _reimbursements;
            }
            private set
            {
                _reimbursements = value;
            }
        }

        /// <summary>
        /// Gets or sets the recoveries.
        /// </summary>
        /// <value>
        /// The recoveries.
        /// </value>
        public double Recoveries
        {
            get
            {
                return _recoveries;
            }
            private set
            {
                _recoveries = value;
            }
        }

        /// <summary>
        /// Gets or sets the used.
        /// </summary>
        /// <value>
        /// The used.
        /// </value>
        public double Used
        {
            get
            {
                return _used;
            }
            private set
            {
                _used = value;
            }
        }

        /// <summary>
        /// Gets or sets the available.
        /// </summary>
        /// <value>
        /// The available.
        /// </value>
        public double Available
        {
            get
            {
                return _available;
            }
            private set
            {
                _available = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationAvailableBalances" /> class.
        /// </summary>
        public AppropriationAvailableBalance( )
            : base( )
        {
            _source = Source.AppropriationAvailableBalances;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationAvailableBalances" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public AppropriationAvailableBalance( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "AppropriationAvailableBalancesId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _authority = double.Parse( _record[ "Authority" ]?.ToString( ) ?? "0" );
            _budgeted = double.Parse( _record[ "Budgeted" ]?.ToString( ) ?? "0" );
            _carryoverIn = double.Parse( _record[ "CarryoverIn" ]?.ToString( ) ?? "0" );
            _carryoverOut = double.Parse( _record[ "CarryoverOut" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _recoveries = double.Parse( _record[ "Recoveries" ]?.ToString( ) ?? "0" );
            _used = double.Parse( _record[ "Used" ]?.ToString( ) ?? "0" );
            _available = double.Parse( _record[ "Available" ]?.ToString( ) ?? "0" );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationAvailableBalances" /> class.
        /// </summary>
        /// <param name="builder"></param>
        public AppropriationAvailableBalance( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "AppropriationAvailableBalancesId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _authority = double.Parse( _record[ "Authority" ]?.ToString( ) ?? "0" );
            _budgeted = double.Parse( _record[ "Budgeted" ]?.ToString( ) ?? "0" );
            _carryoverIn = double.Parse( _record[ "CarryoverIn" ]?.ToString( ) ?? "0" );
            _carryoverOut = double.Parse( _record[ "CarryoverOut" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _recoveries = double.Parse( _record[ "Recoveries" ]?.ToString( ) ?? "0" );
            _used = double.Parse( _record[ "Used" ]?.ToString( ) ?? "0" );
            _available = double.Parse( _record[ "Available" ]?.ToString( ) ?? "0" );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationAvailableBalances" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public AppropriationAvailableBalance( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "AppropriationAvailableBalancesId" ]?.ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
            _authority = double.Parse( dataRow[ "Authority" ]?.ToString( ) ?? "0" );
            _budgeted = double.Parse( dataRow[ "Budgeted" ]?.ToString( ) ?? "0" );
            _carryoverIn = double.Parse( dataRow[ "CarryoverIn" ]?.ToString( ) ?? "0" );
            _carryoverOut = double.Parse( dataRow[ "CarryoverOut" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( dataRow[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _recoveries = double.Parse( dataRow[ "Recoveries" ]?.ToString( ) ?? "0" );
            _used = double.Parse( dataRow[ "Used" ]?.ToString( ) ?? "0" );
            _available = double.Parse( dataRow[ "Available" ]?.ToString( ) ?? "0" );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationAvailableBalances" /> class.
        /// </summary>
        /// <param name="balance">The balance.</param>
        public AppropriationAvailableBalance( AppropriationAvailableBalance balance )
            : base( )
        {
            _id = balance.ID;
            _bfy = balance.BFY;
            _efy = balance.EFY;
            _fundCode = balance.FundCode;
            _fundName = balance.FundName;
            _authority = balance.Authority;
            _budgeted = balance.Budgeted;
            _carryoverIn = balance.CarryoverIn;
            _carryoverOut = balance.CarryoverOut;
            _reimbursements = balance.Reimbursements;
            _recoveries = balance.Recoveries;
            _used = balance.Used;
            _available = balance.Available;
            _mainAccount = balance.MainAccount;
            _budgetAccountCode = balance.BudgetAccountCode;
            _budgetAccountName = balance.BudgetAccountName;
            _treasuryAccountCode = balance.TreasuryAccountCode;
            _treasuryAccountName = balance.TreasuryAccountName;
        }
    }
}