// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="GeneralLedgerAccount.cs" company="Terry D. Eppler">
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
//   GeneralLedgerAccount.cs
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
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    public class GeneralLedgerAccount : LedgerAccount
    {
        /// <summary>
        /// Gets the bfy.
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

        /// <summary>
        /// Gets or sets the account classification.
        /// </summary>
        /// <value>
        /// The account classification.
        /// </value>
        public string AccountClassification
        {
            get
            {
                return _accountClassification;
            }
            private protected set
            {
                _accountClassification = value;
            }
        }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public string ShortName
        {
            get
            {
                return _shortName;
            }
            private protected set
            {
                _shortName = value;
            }
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number
        {
            get
            {
                return _number;
            }
            private protected set
            {
                _number = value;
            }
        }

        /// <summary>
        /// Gets or sets the normal balance.
        /// </summary>
        /// <value>
        /// The normal balance.
        /// </value>
        public string NormalBalance
        {
            get
            {
                return _normalBalance;
            }
            private protected set
            {
                _normalBalance = value;
            }
        }

        /// <summary>
        /// Gets or sets the real or closing account.
        /// </summary>
        /// <value>
        /// The real or closing account.
        /// </value>
        public string RealOrClosingAccount
        {
            get
            {
                return _realOrClosingAccount;
            }
            private protected set
            {
                _realOrClosingAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the summary account.
        /// </summary>
        /// <value>
        /// The summary account.
        /// </value>
        public string SummaryAccount
        {
            get
            {
                return _summaryAccount;
            }
            private protected set
            {
                _summaryAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the cash account.
        /// </summary>
        /// <value>
        /// The cash account.
        /// </value>
        public string CashAccount
        {
            get
            {
                return _cashAccount;
            }
            private protected set
            {
                _cashAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the reportable account.
        /// </summary>
        /// <value>
        /// The reportable account.
        /// </value>
        public string ReportableAccount
        {
            get
            {
                return _reportableAccount;
            }
            private protected set
            {
                _reportableAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the cost allocation indicator.
        /// </summary>
        /// <value>
        /// The cost allocation indicator.
        /// </value>
        public string CostAllocationIndicator
        {
            get
            {
                return _costAllocationIndicator;
            }
            private protected set
            {
                _costAllocationIndicator = value;
            }
        }

        /// <summary>
        /// Gets or sets the federal non federal.
        /// </summary>
        /// <value>
        /// The federal non federal.
        /// </value>
        public string FederalNonFederal
        {
            get
            {
                return _federalNonFederal;
            }
            private protected set
            {
                _federalNonFederal = value;
            }
        }

        /// <summary>
        /// Gets or sets the attribute value.
        /// </summary>
        /// <value>
        /// The attribute value.
        /// </value>
        public string AttributeValue
        {
            get
            {
                return _attributeValue;
            }
            private protected set
            {
                _attributeValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the usage.
        /// </summary>
        /// <value>
        /// The usage.
        /// </value>
        public string Usage
        {
            get
            {
                return _usage;
            }
            private protected set
            {
                _usage = value;
            }
        }

        /// <summary>
        /// Gets or sets the deposit.
        /// </summary>
        /// <value>
        /// The deposit.
        /// </value>
        public string Deposit
        {
            get
            {
                return _deposit;
            }
            private protected set
            {
                _deposit = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.GeneralLedgerAccount" /> class.
        /// </summary>
        public GeneralLedgerAccount( )
            : base( )
        {
            _source = Source.GeneralLedgerAccounts;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.GeneralLedgerAccount" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public GeneralLedgerAccount( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "GeneralLedgerAccountsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( ); 
            _number = _record[ "Number" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _shortName = _record[ "ShortName" ].ToString( );
            _normalBalance = _record[ "NormalBalance" ].ToString( );
            _reportableAccount = _record[ "ReportableAccount" ].ToString( );
            _summaryAccount = _record[ "SummaryAccount" ].ToString( );
            _accountClassification = _record[ "AccountClassification" ].ToString( );
            _cashAccount = _record[ "CashAccount" ].ToString( );
            _realOrClosingAccount = _record[ "RealOrClosingAccount" ].ToString( );
            _federalNonFederal = _record[ "FederalNonFederal" ].ToString( );
            _attributeValue = _record[ "AttributeValue" ].ToString( );
            _usage = _record[ "Usage" ].ToString( );
            _deposit = _record[ "Deposit" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.GeneralLedgerAccount" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public GeneralLedgerAccount( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( Record[ "GeneralLedgerAccountsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _number = _record[ "Number" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _shortName = _record[ "ShortName" ].ToString( );
            _normalBalance = _record[ "NormalBalance" ].ToString( );
            _reportableAccount = _record[ "ReportableAccount" ].ToString( );
            _summaryAccount = _record[ "SummaryAccount" ].ToString( );
            _accountClassification = _record[ "AccountClassification" ].ToString( );
            _cashAccount = _record[ "CashAccount" ].ToString( );
            _realOrClosingAccount = _record[ "RealOrClosingAccount" ].ToString( );
            _federalNonFederal = _record[ "FederalNonFederal" ].ToString( );
            _attributeValue = _record[ "AttributeValue" ].ToString( );
            _usage = _record[ "Usage" ].ToString( );
            _deposit = _record[ "Deposit" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.GeneralLedgerAccount" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public GeneralLedgerAccount( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow; 
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "GeneralLedgerAccountsId" ].ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ].ToString( );
            _number = dataRow[ "Number" ].ToString( );
            _name = dataRow[ "Name" ].ToString( );
            _shortName = dataRow[ "ShortName" ].ToString( );
            _normalBalance = dataRow[ "NormalBalance" ].ToString( );
            _reportableAccount = dataRow[ "ReportableAccount" ].ToString( );
            _summaryAccount = dataRow[ "SummaryAccount" ].ToString( );
            _accountClassification = dataRow[ "AccountClassification" ].ToString( );
            _cashAccount = dataRow[ "CashAccount" ].ToString( );
            _realOrClosingAccount = dataRow[ "RealOrClosingAccount" ].ToString( );
            _federalNonFederal = dataRow[ "FederalNonFederal" ].ToString( );
            _attributeValue = dataRow[ "AttributeValue" ].ToString( );
            _usage = dataRow[ "Usage" ].ToString( );
            _deposit = dataRow[ "Deposit" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.GeneralLedgerAccount" /> class.
        /// </summary>
        /// <param name="account">The account.</param>
        public GeneralLedgerAccount( GeneralLedgerAccount account )
            : this( )
        {
            _id = account.ID;
            _bfy = account.BFY;
            _number = account.Number;
            _name = account.Name;
            _shortName = account.ShortName;
            _normalBalance = account.NormalBalance;
            _reportableAccount = account.ReportableAccount;
            _summaryAccount = account.SummaryAccount;
            _accountClassification = account.AccountClassification;
            _cashAccount = account.CashAccount;
            _reportableAccount = account.ReportableAccount;
            _realOrClosingAccount = account.RealOrClosingAccount;
            _federalNonFederal = account.FederalNonFederal;
            _attributeValue = account.AttributeValue;
            _usage = account.Usage;
            _deposit = account.Deposit;
        }
    }
}