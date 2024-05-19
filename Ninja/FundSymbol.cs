// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="FundSymbol.cs" company="Terry D. Eppler">
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
//   FundSymbol.cs
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public abstract class FundSymbol : BudgetUnit
    {
        /// <summary>
        /// The short name
        /// </summary>
        private protected string _shortName;

        /// <summary>
        /// The status
        /// </summary>
        private protected string _status;

        /// <summary>
        /// The start date
        /// </summary>
        private protected DateOnly _startDate;

        /// <summary>
        /// The end date
        /// </summary>
        private protected DateOnly _endDate;

        /// <summary>
        /// The sub level prefix
        /// </summary>
        private protected string _subLevelPrefix;

        /// <summary>
        /// The allocation trasnfer agency
        /// </summary>
        private protected string _allocationTransferAgency;

        /// <summary>
        /// The agency identifier
        /// </summary>
        private protected string _agencyIdentifier;

        /// <summary>
        /// The beginning period of availablity
        /// </summary>
        private protected string _beginningPeriodOfAvailability;

        /// <summary>
        /// The ending period of availability
        /// </summary>
        private protected string _endingPeriodOfAvailability;

        /// <summary>
        /// The multi year inidicator
        /// </summary>
        private protected string _multiYearIndicator;

        /// <summary>
        /// The sub account
        /// </summary>
        private protected string _subAccount;

        /// <summary>
        /// The fund category
        /// </summary>
        private protected string _fundCategory;

        /// <summary>
        /// The appropriation code
        /// </summary>
        private protected string _appropriationCode;

        /// <summary>
        /// The sub appropriation code
        /// </summary>
        private protected string _subAppropriationCode;

        /// <summary>
        /// The fund group
        /// </summary>
        private protected string _fundGroup;

        /// <summary>
        /// The no year
        /// </summary>
        private protected string _noYear;

        /// <summary>
        /// The carryover
        /// </summary>
        private protected string _carryover;
        
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
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status
        {
            get
            {
                return _status;
            }
            private protected set
            {
                _status = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateOnly StartDate
        {
            get
            {
                return _startDate;
            }
            private protected set
            {
                _startDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateOnly EndDate
        {
            get
            {
                return _endDate;
            }
            private protected set
            {
                _endDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the sub level prefix.
        /// </summary>
        /// <value>
        /// The sub level prefix.
        /// </value>
        public string SubLevelPrefix
        {
            get
            {
                return _subLevelPrefix;
            }
            private protected set
            {
                _subLevelPrefix = value;
            }
        }

        /// <summary>
        /// Gets or sets the allocation transfer agency.
        /// </summary>
        /// <value>
        /// The allocation transfer agency.
        /// </value>
        public string AllocationTransferAgency
        {
            get
            {
                return _allocationTransferAgency;
            }
            private protected set
            {
                _allocationTransferAgency = value;
            }
        }

        /// <summary>
        /// Gets or sets the agency identifier.
        /// </summary>
        /// <value>
        /// The agency identifier.
        /// </value>
        public string AgencyIdentifier
        {
            get
            {
                return _agencyIdentifier;
            }
            private protected set
            {
                _agencyIdentifier = value;
            }
        }

        /// <summary>
        /// Gets or sets the sub account.
        /// </summary>
        /// <value>
        /// The sub account.
        /// </value>
        public string SubAccount
        {
            get
            {
                return _subAccount;
            }
            private protected set
            {
                _subAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the fund category.
        /// </summary>
        /// <value>
        /// The fund category.
        /// </value>
        public string FundCategory
        {
            get
            {
                return _fundCategory;
            }
            private protected set
            {
                _fundCategory = value;
            }
        }

        /// <summary>
        /// Gets or sets the appropriation code.
        /// </summary>
        /// <value>
        /// The appropriation code.
        /// </value>
        public string AppropriationCode
        {
            get
            {
                return _appropriationCode;
            }
            private protected set
            {
                _appropriationCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the sub appropriation code.
        /// </summary>
        /// <value>
        /// The sub appropriation code.
        /// </value>
        public string SubAppropriationCode
        {
            get
            {
                return _subAppropriationCode;
            }
            private protected set
            {
                _subAppropriationCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the fund group.
        /// </summary>
        /// <value>
        /// The fund group.
        /// </value>
        public string FundGroup
        {
            get
            {
                return _fundGroup;
            }
            private protected set
            {
                _fundGroup = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FundSymbol"/> class.
        /// </summary>
        /// <inheritdoc />
        protected FundSymbol( ) 
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FundSymbol"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        protected FundSymbol( IQuery query )
            : base( query )
        {
            _record = new DataBuilder( query )?.Record;
            _map = Record.ToDictionary( );
            _id = int.Parse( _record[ "FundsId" ].ToString( ) ?? "0" );
            _mainAccount = _record[ "MainAccount" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FundSymbol"/> class.
        /// </summary>
        /// <param name="builder"></param>
        /// <inheritdoc />
        protected FundSymbol( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "FundsId" ].ToString( ) ?? "0" );
            _mainAccount = _record[ "MainAccount" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FundSymbol"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <inheritdoc />
        protected FundSymbol( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "FundsId" ].ToString( ) ?? "0" );
            _mainAccount = dataRow[ "MainAccount" ].ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ].ToString( );
        }
    }
}