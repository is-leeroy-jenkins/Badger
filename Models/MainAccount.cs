// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
//
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
// ******************************************************************************************
// <copyright file="${File.FileName}" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  ${CurrentDate.Year}  Terry D. Eppler
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
//   ${File.FileName}
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
    [SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" )]
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "UnusedType.Global" )]
    [SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" )]
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    [SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" )]
    public class MainAccount : DataUnit
    {
        /// <summary>
        /// The sub function code
        /// </summary>
        private protected string _subFunctionCode;

        /// <summary>
        /// The sub function name
        /// </summary>
        private protected string _subFunctionName;

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
        /// The budget enforement act category
        /// </summary>
        private protected string _budgetEnforcementActCategory;

        /// <summary>
        /// Gets or sets the sub function code.
        /// </summary>
        /// <value>
        /// The sub function code.
        /// </value>
        public string SubFunctionCode
        {
            get
            {
                return _subFunctionCode;
            }
            set
            {
                _subFunctionCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the sub function.
        /// </summary>
        /// <value>
        /// The name of the sub function.
        /// </value>
        public string SubFunctionName
        {
            get
            {
                return _subFunctionName;
            }
            set
            {
                _subFunctionName = value;
            }
        }

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
            set
            {
                _budgetAccountCode = value;
            }
        }

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
            set
            {
                _budgetAccountName = value;
            }
        }

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
            set
            {
                _treasuryAccountCode = value;
            }
        }

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
            set
            {
                _treasuryAccountName = value;
            }
        }

        /// <summary>
        /// Gets or sets the budget enforcement act category.
        /// </summary>
        /// <value>
        /// The budget enforcement act category.
        /// </value>
        public string BudgetEnforcementActCategory
        {
            get
            {
                return _budgetEnforcementActCategory;
            }
            set
            {
                _budgetAccountName = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MainAccount" />
        /// class.
        /// </summary>
        public MainAccount( )
            : base( )
        {
            _source = Source.MainAccounts;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MainAccounts"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public MainAccount( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "MainAccountsId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _subFunctionCode = _record[ "SubFunctionCode" ]?.ToString( );
            _subFunctionName = _record[ "SubFunctionName" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _budgetEnforcementActCategory = _record[ "BudgetEnforcementActCategory" ]?.ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MainAccounts"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public MainAccount( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "MainAccountsId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _subFunctionCode = _record[ "SubFunctionCode" ]?.ToString( );
            _subFunctionName = _record[ "SubFunctionName" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _budgetEnforcementActCategory = _record[ "BudgetEnforcementActCategory" ]?.ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MainAccounts"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public MainAccount( DataRow dataRow )
            : this( )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "MainAccountsId" ]?.ToString( ) ?? "0" );
            _code = dataRow[ "Code" ]?.ToString( );
            _name = dataRow[ "Name" ]?.ToString( );
            _subFunctionCode = dataRow[ "SubFunctionCode" ]?.ToString( );
            _subFunctionName = dataRow[ "SubFunctionName" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
            _budgetEnforcementActCategory = dataRow[ "BudgetEnforcementActCategory" ]?.ToString( );
        }
    }
}