// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="MonthlyLedgerAccountBalance.cs" company="Terry D. Eppler">
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
//   MonthlyLedgerAccountBalance.cs
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
    /// <seealso cref="T:Badger.BudgetUnit" />
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class MonthlyLedgerAccountBalance : BudgetUnit
    {
        /// <summary>
        /// The ledger account
        /// </summary>
        private string _ledgerAccount;

        /// <summary>
        /// The ledger name
        /// </summary>
        private string _ledgerName;

        /// <summary>
        /// The apportionment account code
        /// </summary>
        private string _apportionmentAccountCode;

        /// <summary>
        /// The fiscal month
        /// </summary>
        private string _fiscalMonth;

        /// <summary>
        /// The credit balance
        /// </summary>
        private double _creditBalance;

        /// <summary>
        /// The debit balance
        /// </summary>
        private double _debitBalance;

        /// <summary>
        /// The year to date amount
        /// </summary>
        private double _yearToDateAmount;

        /// <summary>
        /// Gets or sets the ledger account.
        /// </summary>
        /// <value>
        /// The ledger account.
        /// </value>
        public string LedgerAccount
        {
            get
            {
                return _ledgerAccount;
            }
            private set
            {
                _ledgerAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the ledger.
        /// </summary>
        /// <value>
        /// The name of the ledger.
        /// </value>
        public string LedgerName
        {
            get
            {
                return _ledgerName;
            }
            private set
            {
                _ledgerName = value;
            }
        }

        /// <summary>
        /// Gets or sets the apportionment account code.
        /// </summary>
        /// <value>
        /// The apportionment account code.
        /// </value>
        public string ApportionmentAccountCode
        {
            get
            {
                return _apportionmentAccountCode;
            }
            private set
            {
                _apportionmentAccountCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the fiscal month.
        /// </summary>
        /// <value>
        /// The fiscal month.
        /// </value>
        public string FiscalMonth
        {
            get
            {
                return _fiscalMonth;
            }
            private set
            {
                _fiscalMonth = value;
            }
        }

        /// <summary>
        /// Gets or sets the credit balance.
        /// </summary>
        /// <value>
        /// The credit balance.
        /// </value>
        public double CreditBalance
        {
            get
            {
                return _creditBalance;
            }
            private set
            {
                _creditBalance = value;
            }
        }

        /// <summary>
        /// Gets or sets the debit balance.
        /// </summary>
        /// <value>
        /// The debit balance.
        /// </value>
        public double DebitBalance
        {
            get
            {
                return _debitBalance;
            }
            private set
            {
                _debitBalance = value;
            }
        }

        /// <summary>
        /// Gets or sets the year to date amount.
        /// </summary>
        /// <value>
        /// The year to date amount.
        /// </value>
        public double YearToDateAmount
        {
            get
            {
                return _yearToDateAmount;
            }
            private set
            {
                _yearToDateAmount = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyLedgerAccountBalances" /> class.
        /// </summary>
        public MonthlyLedgerAccountBalance( )
            : base( )
        {
            _source = Source.MonthlyLedgerAccountBalances;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyLedgerAccountBalances" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public MonthlyLedgerAccountBalance( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "MonthlyLedgerAccountBalances" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _ledgerAccount = _record[ "LedgerAccount" ].ToString( );
            _ledgerName = _record[ "LedgerName" ].ToString( );
            _creditBalance = double.Parse( _record[ "CreditBalance" ].ToString( ) ?? "0" );
            _debitBalance = double.Parse( _record[ "DebitBalance" ].ToString( ) ?? "0" );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyLedgerAccountBalances" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public MonthlyLedgerAccountBalance( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "MonthlyLedgerAccountBalances" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _ledgerAccount = _record[ "LedgerAccount" ].ToString( );
            _ledgerName = _record[ "LedgerName" ].ToString( );
            _creditBalance = double.Parse( _record[ "CreditBalance" ].ToString( ) ?? "0" );
            _debitBalance = double.Parse( _record[ "DebitBalance" ].ToString( ) ?? "0" );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyLedgerAccountBalances" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public MonthlyLedgerAccountBalance( DataRow dataRow )
            : base( dataRow )
        {
            Record = dataRow;
            _map = _record.ToDictionary( );
            _id = int.Parse( dataRow[ "MonthlyLedgerAccountBalances" ].ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _fundCode = dataRow[ "FundCode" ].ToString( );
            _fundName = dataRow[ "FundName" ].ToString( );
            _ledgerAccount = dataRow[ "LedgerAccount" ].ToString( );
            _ledgerName = dataRow[ "LedgerName" ].ToString( );
            _creditBalance = double.Parse( dataRow[ "CreditBalance" ].ToString( ) ?? "0" );
            _debitBalance = double.Parse( dataRow[ "DebitBalance" ].ToString( ) ?? "0" );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyLedgerAccountBalances" /> class.
        /// </summary>
        /// <param name="account">The account.</param>
        public MonthlyLedgerAccountBalance( MonthlyLedgerAccountBalance account )
            : this( )
        {
            _id = account.ID;
            _bfy = account.BFY;
            _efy = account.EFY;
            _fundCode = account.FundCode;
            _fundName = account.FundName;
            _ledgerAccount = account.LedgerAccount;
            _ledgerName = account.LedgerName;
            _creditBalance = account.CreditBalance;
            _debitBalance = account.DebitBalance;
            _treasuryAccountCode = account.TreasuryAccountCode;
            _treasuryAccountName = account.TreasuryAccountName;
            _budgetAccountCode = account.BudgetAccountCode;
            _budgetAccountName = account.BudgetAccountName;
        }
    }
}