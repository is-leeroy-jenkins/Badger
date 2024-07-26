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
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" )]
    [SuppressMessage( "ReSharper", "UnusedType.Global" )]
    [SuppressMessage( "ReSharper", "ConvertToAutoProperty" )]
    [SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" )]
    [SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" )]
    [SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" )]
    public class ReimbursableAgreement : BudgetUnit
    {
        /// <summary>
        /// The rpio
        /// </summary>
        private string _rpio;

        /// <summary>
        /// The agreement number
        /// </summary>
        private string _agreementNumber;

        /// <summary>
        /// The start date
        /// </summary>
        private DateTime _startDate;

        /// <summary>
        /// The end date
        /// </summary>
        private DateTime _endDate;

        /// <summary>
        /// The rc code
        /// </summary>
        private string _rcCode;

        /// <summary>
        /// The org code
        /// </summary>
        private string _orgCode;

        /// <summary>
        /// The division name
        /// </summary>
        private string _divisionName;

        /// <summary>
        /// The site project code
        /// </summary>
        private string _siteProjectCode;

        /// <summary>
        /// The account code
        /// </summary>
        private string _accountCode;

        /// <summary>
        /// The vendor code
        /// </summary>
        private string _vendorCode;

        /// <summary>
        /// The vendor name
        /// </summary>
        private string _vendorName;

        /// <summary>
        /// The amount
        /// </summary>
        private double _amount;

        /// <summary>
        /// The unliquidated obligations
        /// </summary>
        private double _openCommitments;

        /// <summary>
        /// The obligations
        /// </summary>
        private double _obligations;

        /// <summary>
        /// The unliquidated obligations
        /// </summary>
        private double _unliquidatedObligations;

        /// <summary>
        /// The available
        /// </summary>
        private double _available;

        /// <summary>
        /// Gets or sets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        public string RPIO
        {
            get
            {
                return _rpio;
            }
            private set
            {
                _rpio = value;
            }
        }

        /// <summary>
        /// Gets or sets the agreement number.
        /// </summary>
        /// <value>
        /// The agreement number.
        /// </value>
        public string AgreementNumber
        {
            get
            {
                return _agreementNumber;
            }
            private set
            {
                _agreementNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            private set
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
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            private set
            {
                _endDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        public string RcCode
        {
            get
            {
                return _rcCode;
            }
            private set
            {
                _rcCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        public string OrgCode
        {
            get
            {
                return _orgCode;
            }
            private set
            {
                _orgCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the division.
        /// </summary>
        /// <value>
        /// The name of the division.
        /// </value>
        public string DivisionName
        {
            get
            {
                return _divisionName;
            }
            private set
            {
                _divisionName = value;
            }
        }

        /// <summary>
        /// Gets or sets the site project code.
        /// </summary>
        /// <value>
        /// The site project code.
        /// </value>
        public string SiteProjectCode
        {
            get
            {
                return _siteProjectCode;
            }
            private set
            {
                _siteProjectCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public string AccountCode
        {
            get
            {
                return _accountCode;
            }
            private set
            {
                _accountCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the vendor code.
        /// </summary>
        /// <value>
        /// The vendor code.
        /// </value>
        public string VendorCode
        {
            get
            {
                return _vendorCode;
            }
            private set
            {
                _vendorCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the vendor.
        /// </summary>
        /// <value>
        /// The name of the vendor.
        /// </value>
        public string VendorName
        {
            get
            {
                return _vendorName;
            }
            private set
            {
                _vendorName = value;
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
            private set
            {
                _amount = value;
            }
        }

        /// <summary>
        /// Gets or sets the open commitments.
        /// </summary>
        /// <value>
        /// The open commitments.
        /// </value>
        public double OpenCommitments
        {
            get
            {
                return _openCommitments;
            }
            private set
            {
                _openCommitments = value;
            }
        }

        /// <summary>
        /// Gets or sets the obligations.
        /// </summary>
        /// <value>
        /// The obligations.
        /// </value>
        public double Obligations
        {
            get
            {
                return _obligations;
            }
            private set
            {
                _obligations = value;
            }
        }

        /// <summary>
        /// Gets or sets the ulo.
        /// </summary>
        /// <value>
        /// The ulo.
        /// </value>
        public double UnliquidatedObligations
        {
            get
            {
                return _unliquidatedObligations;
            }
            private set
            {
                _unliquidatedObligations = value;
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
                return _amount;
            }
            private set
            {
                _amount = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ReimbursableAgreement" /> class.
        /// </summary>
        public ReimbursableAgreement( )
            : base( )
        {
            _source = Source.ReimbursableAgreements;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ReimbursableAgreement" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public ReimbursableAgreement( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _rpio = _record[ "RPIO" ].ToString( );
            _agreementNumber = _record[ "AgreementNumber" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _rcCode = _record[ "RcCode" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _divisionName = _record[ "DivisionName" ].ToString( );
            _siteProjectCode = _record[ "SiteProjectCode" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _vendorCode = _record[ "VendorCode" ].ToString( );
            _vendorName = _record[ "VendorName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) );
            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligatios" ].ToString( ) );

            _available = double.Parse( _record[ "Available" ].ToString( ) );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Badger.ReimbursableAgreement" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public ReimbursableAgreement( IDataModel builder )
        {
            _record = builder.Record;
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _rpio = _record[ "RPIO" ].ToString( );
            _agreementNumber = _record[ "AgreementNumber" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _rcCode = _record[ "RcCode" ].ToString( );
            _orgCode = _record[ "OrgCode" ].ToString( );
            _divisionName = _record[ "DivisionName" ].ToString( );
            _siteProjectCode = _record[ "SiteProjectCode" ].ToString( );
            _accountCode = _record[ "AccountCode" ].ToString( );
            _vendorCode = _record[ "VendorCode" ].ToString( );
            _vendorName = _record[ "VendorName" ].ToString( );
            _amount = double.Parse( _record[ "Amount" ].ToString( ) );
            _openCommitments = double.Parse( _record[ "OpenCommitments" ].ToString( ) );
            _obligations = double.Parse( _record[ "Obligations" ].ToString( ) );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligatios" ].ToString( ) );

            _available = double.Parse( _record[ "Available" ].ToString( ) );
            _mainAccount = _record[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Badger.ReimbursableAgreement" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public ReimbursableAgreement( DataRow dataRow )
        {
            _record = dataRow;
            _fiscalYear = dataRow[ "FiscalYear" ]?.ToString( );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
            _rpio = dataRow[ "RPIO" ].ToString( );
            _agreementNumber = dataRow[ "AgreementNumber" ].ToString( );
            _startDate = DateTime.Parse( dataRow[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( dataRow[ "EndDate" ].ToString( ) );
            _rcCode = dataRow[ "RcCode" ].ToString( );
            _orgCode = dataRow[ "OrgCode" ].ToString( );
            _divisionName = dataRow[ "DivisionName" ].ToString( );
            _siteProjectCode = dataRow[ "SiteProjectCode" ].ToString( );
            _accountCode = dataRow[ "AccountCode" ].ToString( );
            _vendorCode = dataRow[ "VendorCode" ].ToString( );
            _vendorName = dataRow[ "VendorName" ].ToString( );
            _amount = double.Parse( dataRow[ "Amount" ].ToString( ) );
            _openCommitments = double.Parse( dataRow[ "OpenCommitments" ].ToString( ) );
            _obligations = double.Parse( dataRow[ "Obligations" ].ToString( ) );
            _unliquidatedObligations =
                double.Parse( dataRow[ "UnliquidatedObligatios" ].ToString( ) );

            _available = double.Parse( dataRow[ "Available" ].ToString( ) );
            _mainAccount = dataRow[ "MainAccount" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
            _map = dataRow.ToDictionary( );
        }
    }
}