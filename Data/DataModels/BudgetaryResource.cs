// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="BudgetaryResource.cs" company="Terry D. Eppler">
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
//   BudgetaryResource.cs
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
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class BudgetaryResource : BudgetUnit
    {
        /// <summary>
        /// The last update
        /// </summary>
        private protected DateTime _lastUpdate;

        /// <summary>
        /// The stat
        /// </summary>
        private protected string _stat;

        /// <summary>
        /// The credit indicator
        /// </summary>
        private protected string _creditIndicator;

        /// <summary>
        /// The line number
        /// </summary>
        private protected string _lineNumber;

        /// <summary>
        /// The line description
        /// </summary>
        private protected string _lineDescription;

        /// <summary>
        /// The section name
        /// </summary>
        private protected string _sectionName;

        /// <summary>
        /// The section number
        /// </summary>
        private protected string _sectionNumber;

        /// <summary>
        /// The line type
        /// </summary>
        private protected string _lineType;

        /// <summary>
        /// The financing account
        /// </summary>
        private protected string _financingAccount;

        /// <summary>
        /// The october
        /// </summary>
        private protected double _october;

        /// <summary>
        /// The november
        /// </summary>
        private protected double _november;

        /// <summary>
        /// The december
        /// </summary>
        private protected double _december;

        /// <summary>
        /// The january
        /// </summary>
        private protected double _january;

        /// <summary>
        /// The feburary
        /// </summary>
        private protected double _feburary;

        /// <summary>
        /// The march
        /// </summary>
        private protected double _march;

        /// <summary>
        /// The april
        /// </summary>
        private protected double _april;

        /// <summary>
        /// The may
        /// </summary>
        private protected double _may;

        /// <summary>
        /// The june
        /// </summary>
        private protected double _june;

        /// <summary>
        /// The july
        /// </summary>
        private protected double _july;

        /// <summary>
        /// The august
        /// </summary>
        private protected double _august;

        /// <summary>
        /// The september
        /// </summary>
        private protected double _september;

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        public DateTime LastUpdate
        {
            get
            {
                return _lastUpdate;
            }
            set
            {
                _lastUpdate = value;
            }
        }

        /// <summary>
        /// Gets or sets the stat.
        /// </summary>
        /// <value>
        /// The stat.
        /// </value>
        public string STAT
        {
            get
            {
                return _stat;
            }
            set
            {
                _stat = value;
            }
        }

        /// <summary>
        /// Gets or sets the credit indicator.
        /// </summary>
        /// <value>
        /// The credit indicator.
        /// </value>
        public string CreditIndicator
        {
            get
            {
                return _stat;
            }
            set
            {
                _stat = value;
            }
        }

        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        /// <value>
        /// The line number.
        /// </value>
        public string LineNumber
        {
            get
            {
                return _stat;
            }
            set
            {
                _stat = value;
            }
        }

        /// <summary>
        /// Gets or sets the line description.
        /// </summary>
        /// <value>
        /// The line description.
        /// </value>
        public string LineDescription
        {
            get
            {
                return _lineDescription;
            }
            set
            {
                _lineDescription = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the section.
        /// </summary>
        /// <value>
        /// The name of the section.
        /// </value>
        public string SectionName
        {
            get
            {
                return _sectionName;
            }
            set
            {
                _sectionName = value;
            }
        }

        /// <summary>
        /// Gets or sets the section number.
        /// </summary>
        /// <value>
        /// The section number.
        /// </value>
        public string SectionNumber
        {
            get
            {
                return _sectionNumber;
            }
            set
            {
                _sectionNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the line.
        /// </summary>
        /// <value>
        /// The type of the line.
        /// </value>
        public string LineType
        {
            get
            {
                return _lineType;
            }
            set
            {
                _lineType = value;
            }
        }

        /// <summary>
        /// Gets or sets the financing accounts.
        /// </summary>
        /// <value>
        /// The financing accounts.
        /// </value>
        public string FinancingAccounts
        {
            get
            {
                return _financingAccount;
            }
            set
            {
                _financingAccount = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetaryResource"/> class.
        /// </summary>
        /// <inheritdoc />
        protected BudgetaryResource( )
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetaryResource"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        protected BudgetaryResource( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
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
        /// <see cref="T:Badger.ResourceStatus" /> class.
        /// </summary>
        /// <param name="builder">The query.</param>
        protected BudgetaryResource( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
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

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetaryResource"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <inheritdoc />
        protected BudgetaryResource( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
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