// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="UnobligatedBalance.cs" company="Terry D. Eppler">
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
//   UnobligatedBalance.cs
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
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class UnobligatedBalance : BudgetUnit
    {
        /// <summary>
        /// The budget year
        /// </summary>
        private protected string _budgetYear;

        /// <summary>
        /// The budget account
        /// </summary>
        private protected string _budgetAccount;

        /// <summary>
        /// The account number
        /// </summary>
        private protected string _accountNumber;

        /// <summary>
        /// The account name
        /// </summary>
        private protected string _accountName;

        /// <summary>
        /// The amount
        /// </summary>
        private protected double _amount;

        /// <summary>
        /// Gets or sets the budget year.
        /// </summary>
        /// <value>
        /// The budget year.
        /// </value>
        public string BudgetYear
        {
            get
            {
                return _budgetYear;
            }
            private protected set
            {
                _budgetYear = value;
            }
        }

        /// <summary>
        /// Gets or sets the budget account.
        /// </summary>
        /// <value>
        /// The budget account.
        /// </value>
        public string BudgetAccount
        {
            get
            {
                return _budgetAccount;
            }
            private protected set
            {
                _budgetAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            private protected set
            {
                _accountNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName
        {
            get
            {
                return _accountName;
            }
            private protected set
            {
                _accountName = value;
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public double Amount
        {
            get
            {
                return _amount;
            }
            private protected set
            {
                _amount = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.UnobligatedBalance" /> class.
        /// </summary>
        public UnobligatedBalance( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.UnobligatedBalance" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public UnobligatedBalance( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _budgetYear = _record[ "BudgetYear" ]?.ToString( );
            _budgetAccount = _record[ "BudgetAccount" ]?.ToString( );
            _accountNumber = _record[ "AccountNumber" ]?.ToString( );
            _accountName = _record[ "AccountName" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0.0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.UnobligatedBalance" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public UnobligatedBalance( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _budgetYear = _record[ "BudgetYear" ]?.ToString( );
            _budgetAccount = _record[ "BudgetAccount" ]?.ToString( );
            _accountNumber = _record[ "AccountNumber" ]?.ToString( );
            _accountName = _record[ "AccountName" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0.0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.UnobligatedBalance" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public UnobligatedBalance( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _budgetYear = dataRow[ "BudgetYear" ]?.ToString( );
            _budgetAccount = dataRow[ "BudgetAccount" ]?.ToString( );
            _accountNumber = dataRow[ "AccountNumber" ]?.ToString( );
            _accountName = dataRow[ "AccountName" ]?.ToString( );
            _amount = double.Parse( dataRow[ "Amount" ]?.ToString( ) ?? "0.0" );
        }
    }
}