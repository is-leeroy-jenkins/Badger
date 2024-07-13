// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="Transfer.cs" company="Terry D. Eppler">
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
//   Transfer.cs
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
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public abstract class Transfer : BudgetUnit
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        private protected int _id;

        /// <summary>
        /// Gets or sets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        private protected string _budgetLevel;

        /// <summary>
        /// Gets or sets the document prefix.
        /// </summary>
        /// <value>
        /// The document prefix.
        /// </value>
        private protected string _docPrefix;

        /// <summary>
        /// Gets or sets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        private protected string _docType;

        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private protected string _bfy;

        /// <summary>
        /// Gets or sets the efy.
        /// </summary>
        /// <value>
        /// The efy.
        /// </value>
        private protected string _efy;

        /// <summary>
        /// Gets or sets the rpio code.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        private protected string _rpioCode;

        /// <summary>
        /// Gets or sets the name of the rpio.
        /// </summary>
        /// <value>
        /// The name of the rpio.
        /// </value>
        private protected string _rpioName;

        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        private protected string _fundCode;

        /// <summary>
        /// Gets or sets the name of the fund.
        /// </summary>
        /// <value>
        /// The name of the fund.
        /// </value>
        private protected string _fundName;

        /// <summary>
        /// Gets or sets the reprogramming number.
        /// </summary>
        /// <value>
        /// The reprogramming number.
        /// </value>
        private protected string _reprogrammingNumber;

        /// <summary>
        /// Gets or sets the control number.
        /// </summary>
        /// <value>
        /// The control number.
        /// </value>
        private protected string _controlNumber;

        /// <summary>
        /// Gets or sets the processed date.
        /// </summary>
        /// <value>
        /// The processed date.
        /// </value>
        private protected DateTime _processedDate;

        /// <summary>
        /// Gets or sets the quarter.
        /// </summary>
        /// <value>
        /// The quarter.
        /// </value>
        private protected string _quarter;

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        /// <value>
        /// The line.
        /// </value>
        private protected string _line;

        /// <summary>
        /// Gets or sets the subline.
        /// </summary>
        /// <value>
        /// The subline.
        /// </value>
        private protected string _subline;

        /// <summary>
        /// Gets or sets the ah code.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        private protected string _ahCode;

        /// <summary>
        /// Gets or sets the name of the ah.
        /// </summary>
        /// <value>
        /// The name of the ah.
        /// </value>
        private protected string _ahName;

        /// <summary>
        /// Gets or sets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        private protected string _orgCode;

        /// <summary>
        /// Gets or sets the name of the org.
        /// </summary>
        /// <value>
        /// The name of the org.
        /// </value>
        private protected string _orgName;

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private protected string _rcCode;

        /// <summary>
        /// Gets or sets the name of the rc.
        /// </summary>
        /// <value>
        /// The name of the rc.
        /// </value>
        private protected string _rcName;

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        private protected string _accountCode;

        /// <summary>
        /// Gets or sets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        private protected string _programAreaCode;

        /// <summary>
        /// Gets or sets the name of the program area.
        /// </summary>
        /// <value>
        /// The name of the program area.
        /// </value>
        private protected string _programAreaName;

        /// <summary>
        /// Gets or sets the name of the program project.
        /// </summary>
        /// <value>
        /// The name of the program project.
        /// </value>
        private protected string _programProjectName;

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        private protected string _programProjectCode;

        /// <summary>
        /// Gets or sets from to.
        /// </summary>
        /// <value>
        /// From to.
        /// </value>
        private protected string _fromTo;

        /// <summary>
        /// Gets or sets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        private protected string _bocCode;

        /// <summary>
        /// Gets or sets the name of the boc.
        /// </summary>
        /// <value>
        /// The name of the boc.
        /// </value>
        private protected string _bocName;

        /// <summary>
        /// Gets or sets the NPM code.
        /// </summary>
        /// <value>
        /// The NPM code.
        /// </value>
        private protected string _npmCode;

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected double _amount;

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        /// <value>
        /// The type of the resource.
        /// </value>
        private protected string _resourceType;

        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        /// <value>
        /// The purpose.
        /// </value>
        private protected string _purpose;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Transfer" /> class.
        /// </summary>
        protected Transfer( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Transfer" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected Transfer( IQuery query )
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
        /// <see cref="T:Badger.Transfer" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected Transfer( IDataModel builder )
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

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Transfer" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected Transfer( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _fiscalYear = dataRow[ "FiscalYear" ]?.ToString( );
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