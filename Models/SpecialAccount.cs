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
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    public abstract class SpecialAccount : StatusOfFunds
    {
        /// <summary>
        /// Gets or sets the SA number
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        private protected string _specialAccountNumber;

        /// <summary>
        /// Gets or sets the name of the special account.
        /// </summary>
        /// <value>
        /// The name of the special account.
        /// </value>
        private protected string _specialAccountName;

        /// <summary>
        /// Gets or sets the account status.
        /// </summary>
        /// <value>
        /// The account status.
        /// </value>
        private protected string _accountStatus;

        /// <summary>
        /// Gets or sets the NPL status code.
        /// </summary>
        /// <value>
        /// The NPL status code. </value>
        ///
        private protected string _nplStatusCode;

        /// <summary>
        /// Gets or sets the name of the NPL status.
        /// </summary>
        /// <value>
        /// The name of the NPL status.
        /// </value>
        private protected string _nplStatusName;

        /// <summary>
        /// Gets or sets the site identifier.
        /// </summary>
        /// <value>
        /// The site identifier.
        /// </value>
        private protected string _siteId;

        /// <summary>
        /// Gets or sets the cerclis identifier.
        /// </summary>
        /// <value>
        /// The cerclis identifier.
        /// </value>
        private protected string _cerclisSiteId;

        /// <summary>
        /// Gets or sets the site code.
        /// </summary>
        /// <value>
        /// The site code.
        /// </value>
        private protected string _siteCode;

        /// <summary>
        /// Gets or sets the name of the site.
        /// </summary>
        /// <value>
        /// The name of the site.
        /// </value>
        private protected string _siteName;

        /// <summary>
        /// Gets or sets the operable unit.
        /// </summary>
        /// <value>
        /// The operable unit.
        /// </value>
        private protected string _operableUnit;

        /// <summary>
        /// Gets or sets the pipeline code.
        /// </summary>
        /// <value>
        /// The pipeline code.
        /// </value>
        private protected string _pipelineCode;

        /// <summary>
        /// Gets or sets the pipeline description.
        /// </summary>
        /// <value>
        /// The pipeline description.
        /// </value>
        private protected string _pipelineDescription;

        /// <summary>
        /// Gets or sets the program code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private protected string _programCode;

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>
        /// The type of the transaction.
        /// </value>
        private protected string _transactionType;

        /// <summary>
        /// Gets or sets the name of the transaction type.
        /// </summary>
        /// <value>
        /// The name of the transaction type.
        /// </value>
        private protected string _transactionDescription;

        /// <summary>
        /// Gets or sets the name of the foc.
        /// </summary>
        /// <value>
        /// The name of the foc.
        /// </value>
        private protected string _specialAccountStatus;

        /// <summary>
        /// Gets or sets Status Description
        /// </summary>
        /// <value>
        /// The string.
        /// </value>
        private protected string _statusDescription;

        /// <summary>
        /// Gets or sets the site ID
        /// </summary>
        /// <value>
        /// The string.
        /// </value>
        private protected string _epaSiteId;

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>
        /// The transaction date.
        /// </value>
        private protected DateTime _interestDate;

        /// <summary>
        /// Gets or sets the disbursements.
        /// </summary>
        /// <value>
        /// The disbursements.
        /// </value>
        private protected double _disbursements;

        /// <summary>
        /// Gets or sets the unpaid balances.
        /// </summary>
        /// <value>
        /// he unpaid balances.
        /// </value>
        private protected double _unpaidBalances;

        /// <summary>
        /// Gets or sets the collections.
        /// </summary>
        /// <value>
        /// The collections.
        /// </value>
        private protected double _trustfundTransfers;

        /// <summary>
        /// Gets or sets the interest
        /// </summary>
        /// <value>
        /// The interest.
        /// </value>
        private protected double _interest;

        /// <summary>
        /// Gets or sets the cumulative receipts.
        /// </summary>
        /// <value>
        /// The cumulative receipts.
        /// </value>
        private protected double _cumulativeReceipts;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// The net receipts.
        /// </value>
        private protected double _netReceipts;

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// The collections and interest.
        /// </value>
        private protected double _collectionsAndInterest;

        /// <summary>
        /// Gets or sets the SA number
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string SpecialAccountNumber
        {
            get
            {
                return _specialAccountNumber;
            }
            private protected set
            {
                _specialAccountNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the special account.
        /// </summary>
        /// <value>
        /// The name of the special account.
        /// </value>
        public string SpecialAccountName
        {
            get
            {
                return _specialAccountName;
            }
            private protected set
            {
                _specialAccountName = value;
            }
        }

        /// <summary>
        /// Gets or sets the account status.
        /// </summary>
        /// <value>
        /// The account status.
        /// </value>
        public string AccountStatus
        {
            get
            {
                return _accountStatus;
            }
            private protected set
            {
                _accountStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets the NPL status code.
        /// </summary>
        /// <value>
        /// The NPL status code. </value>
        ///
        public string NplStatusCode
        {
            get
            {
                return _nplStatusCode;
            }
            private protected set
            {
                _nplStatusCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the NPL status.
        /// </summary>
        /// <value>
        /// The name of the NPL status.
        /// </value>
        public string NplStatusName
        {
            get
            {
                return _nplStatusName;
            }
            private protected set
            {
                _nplStatusName = value;
            }
        }

        /// <summary>
        /// Gets or sets the site identifier.
        /// </summary>
        /// <value>
        /// The site identifier.
        /// </value>
        public string SiteId
        {
            get
            {
                return _siteId;
            }
            private protected set
            {
                _siteId = value;
            }
        }

        /// <summary>
        /// Gets or sets the cerclis identifier.
        /// </summary>
        /// <value>
        /// The cerclis identifier.
        /// </value>
        public string CerclisSiteId
        {
            get
            {
                return _cerclisSiteId;
            }
            private protected set
            {
                _cerclisSiteId = value;
            }
        }

        /// <summary>
        /// Gets or sets the site code.
        /// </summary>
        /// <value>
        /// The site code.
        /// </value>
        public string SiteCode
        {
            get
            {
                return _siteCode;
            }
            private protected set
            {
                _siteCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the site.
        /// </summary>
        /// <value>
        /// The name of the site.
        /// </value>
        public string SiteName
        {
            get
            {
                return _siteName;
            }
            private protected set
            {
                _siteName = value;
            }
        }

        /// <summary>
        /// Gets or sets the operable unit.
        /// </summary>
        /// <value>
        /// The operable unit.
        /// </value>
        public string OperableUnit
        {
            get
            {
                return _operableUnit;
            }
            private protected set
            {
                _operableUnit = value;
            }
        }

        /// <summary>
        /// Gets or sets the pipeline code.
        /// </summary>
        /// <value>
        /// The pipeline code.
        /// </value>
        public string PipelineCode
        {
            get
            {
                return _pipelineCode;
            }
            private protected set
            {
                _pipelineCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the pipeline description.
        /// </summary>
        /// <value>
        /// The pipeline description.
        /// </value>
        public string PipelineDescription
        {
            get
            {
                return _pipelineDescription;
            }
            private protected set
            {
                _pipelineDescription = value;
            }
        }

        /// <summary>
        /// Gets or sets the program code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string ProgramCode
        {
            get
            {
                return _programCode;
            }
            private protected set
            {
                _programCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>
        /// The type of the transaction.
        /// </value>
        public string TransactionType
        {
            get
            {
                return _transactionType;
            }
            private protected set
            {
                _transactionType = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the transaction type.
        /// </summary>
        /// <value>
        /// The name of the transaction type.
        /// </value>
        public string TransactionDescription
        {
            get
            {
                return _transactionDescription;
            }
            private protected set
            {
                _transactionDescription = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the foc.
        /// </summary>
        /// <value>
        /// The name of the foc.
        /// </value>
        public string SpecialAccountStatus
        {
            get
            {
                return _specialAccountStatus;
            }
            private protected set
            {
                _specialAccountStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets Status Description
        /// </summary>
        /// <value>
        /// The string.
        /// </value>
        public string StatusDescription
        {
            get
            {
                return _statusDescription;
            }
            private protected set
            {
                _statusDescription = value;
            }
        }

        /// <summary>
        /// Gets or sets the site ID
        /// </summary>
        /// <value>
        /// The string.
        /// </value>
        public string EpaSiteId
        {
            get
            {
                return _epaSiteId;
            }
            private protected set
            {
                _epaSiteId = value;
            }
        }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>
        /// The transaction date.
        /// </value>
        public DateTime InterestDate
        {
            get
            {
                return _interestDate;
            }
            private protected set
            {
                _interestDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the disbursements.
        /// </summary>
        /// <value>
        /// The disbursements.
        /// </value>
        public double Disbursements
        {
            get
            {
                return _disbursements;
            }
            private protected set
            {
                _disbursements = value;
            }
        }

        /// <summary>
        /// Gets or sets the unpaid balances.
        /// </summary>
        /// <value>
        /// he unpaid balances.
        /// </value>
        public double UnpaidBalances
        {
            get
            {
                return _unpaidBalances;
            }
            private protected set
            {
                _unpaidBalances = value;
            }
        }

        /// <summary>
        /// Gets or sets the collections.
        /// </summary>
        /// <value>
        /// The collections.
        /// </value>
        public double TrustfundTransfers
        {
            get
            {
                return _trustfundTransfers;
            }
            private protected set
            {
                _trustfundTransfers = value;
            }
        }

        /// <summary>
        /// Gets or sets the interest
        /// </summary>
        /// <value>
        /// The interest.
        /// </value>
        public double Interest
        {
            get
            {
                return _interest;
            }
            private protected set
            {
                _interest = value;
            }
        }

        /// <summary>
        /// Gets or sets the cumulative receipts.
        /// </summary>
        /// <value>
        /// The cumulative receipts.
        /// </value>
        public double CumulativeReceipts
        {
            get
            {
                return _cumulativeReceipts;
            }
            private protected set
            {
                _cumulativeReceipts = value;
            }
        }

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// The net receipts.
        /// </value>
        public double NetReceipts
        {
            get
            {
                return _netReceipts;
            }
            private protected set
            {
                _netReceipts = value;
            }
        }

        /// <summary>
        /// Gets or sets the
        /// </summary>
        /// <value>
        /// The collections and interest.
        /// </value>
        public double CollectionsAndInterest
        {
            get
            {
                return _collectionsAndInterest;
            }
            private protected set
            {
                _collectionsAndInterest = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected SpecialAccount( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="query"></param>
        protected SpecialAccount( IQuery query )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        protected SpecialAccount( IDataModel builder )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="dataRow"></param>
        protected SpecialAccount( DataRow dataRow )
        {
        }
    }
}