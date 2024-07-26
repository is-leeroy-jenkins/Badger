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
    /// <seealso cref="T:Badger.PRC" />
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" )]
    [SuppressMessage( "ReSharper", "UnusedType.Global" )]
    [SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" )]
    [SuppressMessage( "ReSharper", "ConvertToAutoProperty" )]
    [SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" )]
    public class AppropriationLevelAuthority : PRC
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
        private double _carryover;

        /// <summary>
        /// The reimbursements
        /// </summary>
        private double _reimbursements;

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
        public double Carryover
        {
            get
            {
                return _carryover;
            }
            private set
            {
                _carryover = value;
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

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationLevelAuthority" /> class.
        /// </summary>
        public AppropriationLevelAuthority( )
            : base( )
        {
            _source = Source.AppropriationLevelAuthority;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationLevelAuthority" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public AppropriationLevelAuthority( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "AppropriationLevelAuthorityId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _authority = double.Parse( _record[ "Authority" ]?.ToString( ) ?? "0" );
            _budgeted = double.Parse( _record[ "Budgeted" ]?.ToString( ) ?? "0" );
            _carryover = double.Parse( _record[ "Carryover" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationLevelAuthority" /> class.
        /// </summary>
        /// <param name="builder"></param>
        public AppropriationLevelAuthority( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "AppropriationLevelAuthorityId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _authority = double.Parse( _record[ "Authority" ]?.ToString( ) ?? "0" );
            _budgeted = double.Parse( _record[ "Budgeted" ]?.ToString( ) ?? "0" );
            _carryover = double.Parse( _record[ "Carryover" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationLevelAuthority" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public AppropriationLevelAuthority( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "AppropriationLevelAuthorityId" ]?.ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
            _authority = double.Parse( dataRow[ "Authority" ]?.ToString( ) ?? "0" );
            _budgeted = double.Parse( dataRow[ "Budgeted" ]?.ToString( ) ?? "0" );
            _carryover = double.Parse( dataRow[ "Carryover" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( dataRow[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationLevelAuthority" /> class.
        /// </summary>
        /// <param name="authority">The authority.</param>
        public AppropriationLevelAuthority( AppropriationLevelAuthority authority )
            : base( )
        {
            _id = authority.ID;
            _bfy = authority.BFY;
            _efy = authority.EFY;
            _fundCode = authority.FundCode;
            _fundName = authority.FundName;
            _authority = authority.Authority;
            _budgeted = authority.Budgeted;
            _carryover = authority.Carryover;
            _reimbursements = authority.Reimbursements;
            _mainAccount = authority.MainAccount;
            _budgetAccountCode = authority.BudgetAccountCode;
            _budgetAccountName = authority.BudgetAccountName;
            _treasuryAccountCode = authority.TreasuryAccountCode;
            _treasuryAccountName = authority.TreasuryAccountName;
        }
    }
}