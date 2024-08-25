// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="BudgetUnit.cs" company="Terry D. Eppler">
//    Badger is budget execution and data analysis tool for EPA Analysts
//    based on WPF, NET6.0, and is written in C-Sharp.
// 
//     Copyright ©  2020, 2022, 2204 Terry D. Eppler
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
//   BudgetUnit.cs
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
    /// <seealso cref="T:Badger.DataUnit" />
    /// <seealso cref="T:Badger.IBudgetUnit" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    public abstract class BudgetUnit : DataUnit
    {
        /// <summary>
        /// The fiscal year
        /// </summary>
        private protected string _fiscalYear;

        /// <summary>
        /// The bfy
        /// </summary>
        private protected string _bfy;

        /// <summary>
        /// The efy
        /// </summary>
        private protected string _efy;

        /// <summary>
        /// The fund code
        /// </summary>
        private protected string _fundCode;

        /// <summary>
        /// The fund name
        /// </summary>
        private protected string _fundName;

        /// <summary>
        /// The main account
        /// </summary>
        private protected string _mainAccount;

        /// <summary>
        /// The treasury account code
        /// </summary>
        private protected string _treasuryAccountCode;

        /// <summary>
        /// The treasury account name
        /// </summary>
        private protected string _treasuryAccountName;

        /// <summary>
        /// The budget account code
        /// </summary>
        private protected string _budgetAccountCode;

        /// <summary>
        /// The budget account name
        /// </summary>
        private protected string _budgetAccountName;

        /// <summary>
        /// Gets the fiscal year.
        /// </summary>
        /// <value>
        /// The fiscal year.
        /// </value>
        public string FiscalYear
        {
            get
            {
                return _fiscalYear;
            }
            private protected set
            {
                _fiscalYear = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        public string BFY
        {
            get
            {
                return _bfy;
            }
            private protected set
            {
                _bfy = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the efy.
        /// </summary>
        /// <value>
        /// The efy.
        /// </value>
        public string EFY
        {
            get
            {
                return _efy;
            }
            private protected set
            {
                _efy = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        public string FundCode
        {
            get
            {
                return _fundCode;
            }
            private protected set
            {
                _fundCode = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the name of the fund.
        /// </summary>
        /// <value>
        /// The name of the fund.
        /// </value>
        public string FundName
        {
            get
            {
                return _fundName;
            }
            private protected set
            {
                _fundName = value;
            }
        }

        /// <summary>
        /// Gets the main account.
        /// </summary>
        /// <value>
        /// The main account.
        /// </value>
        public string MainAccount
        {
            get
            {
                return _mainAccount;
            }
            private protected set
            {
                _mainAccount = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the treasury account code.
        /// </summary>
        /// <value>
        /// The treasury account code.
        /// </value>
        public string TreasuryAccountCode
        {
            get
            {
                return _treasuryAccountCode;
            }
            private protected set
            {
                _treasuryAccountCode = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the name of the treasury account.
        /// </summary>
        /// <value>
        /// The name of the treasury account.
        /// </value>
        public string TreasuryAccountName
        {
            get
            {
                return _treasuryAccountName;
            }
            private protected set
            {
                _treasuryAccountName = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the budget account code.
        /// </summary>
        /// <value>
        /// The budget account code.
        /// </value>
        public string BudgetAccountCode
        {
            get
            {
                return _budgetAccountCode;
            }
            private protected set
            {
                _budgetAccountCode = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the name of the budget account.
        /// </summary>
        /// <value>
        /// The name of the budget account.
        /// </value>
        public string BudgetAccountName
        {
            get
            {
                return _budgetAccountName;
            }
            private protected set
            {
                _budgetAccountName = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetUnit" /> class.
        /// </summary>
        protected BudgetUnit( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetUnit" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected BudgetUnit( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetUnit" /> class.
        /// </summary>
        /// <param name="dataBuilder">The query.</param>
        protected BudgetUnit( IDataService dataBuilder )
            : base( dataBuilder )
        {
            _record = dataBuilder.Record;
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetUnit" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected BudgetUnit( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
            _mainAccount = dataRow[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
        }
    }
}