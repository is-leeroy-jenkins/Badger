// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="OutlayReport.cs" company="Terry D. Eppler">
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
//   OutlayReport.cs
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
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    public abstract class OutlayReport : BudgetUnit
    {
        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        /// <value>
        /// The line number.
        /// </value>
        private protected string _lineNumber;

        /// <summary>
        /// Gets or sets the line title.
        /// </summary>
        /// <value>
        /// The line title.
        /// </value>
        private protected string _lineTitle;

        /// <summary>
        /// Gets or sets the taxation code.
        /// </summary>
        /// <value>
        /// The taxation code.
        /// </value>
        private protected string _taxationCode;

        /// <summary>
        /// Gets or sets the treasury agency code.
        /// </summary>
        /// <value>
        /// The treasury agency code.
        /// </value>
        private protected string _treasuryAgencyCode;

        /// <summary>
        /// Gets or sets the treasury bureau code.
        /// </summary>
        /// <value>
        /// The treasury bureau code.
        /// </value>
        private protected string _treasuryBureauCode;

        /// <summary>
        /// Gets or sets the budget agency code.
        /// </summary>
        /// <value>
        /// The budget agency code.
        /// </value>
        private protected string _budgetAgencyCode;

        /// <summary>
        /// Gets or sets the budget bureau code.
        /// </summary>
        /// <value>
        /// The budget bureau code.
        /// </value>
        private protected string _budgetBureauCode;

        /// <summary>
        /// Gets or sets the sub account.
        /// </summary>
        /// <value>
        /// The sub account.
        /// </value>
        private protected string _subAccount;

        /// <summary>
        /// Gets or sets the agency sequence.
        /// </summary>
        /// <value>
        /// The agency sequence.
        /// </value>
        private protected string _agencySequence;

        /// <summary>
        /// Gets or sets the bureau sequence.
        /// </summary>
        /// <value>
        /// The bureau sequence.
        /// </value>
        private protected string _bureauSequence;

        /// <summary>
        /// Gets or sets the account sequence.
        /// </summary>
        /// <value>
        /// The account sequence.
        /// </value>
        private protected string _accountSequence;

        /// <summary>
        /// Gets or sets the agency title.
        /// </summary>
        /// <value>
        /// The agency title.
        /// </value>
        private protected string _agencyTitle;

        /// <summary>
        /// Gets or sets the bureau title.
        /// </summary>
        /// <value>
        /// The bureau title.
        /// </value>
        private protected string _bureauTitle;

        /// <summary>
        /// Gets or sets the october.
        /// </summary>
        /// <value>
        /// The october.
        /// </value>
        private protected double _october;

        /// <summary>
        /// Gets or sets the november.
        /// </summary>
        /// <value>
        /// The november.
        /// </value>
        private protected double _november;

        /// <summary>
        /// Gets or sets the december.
        /// </summary>
        /// <value>
        /// The december.
        /// </value>
        private protected double _december;

        /// <summary>
        /// Gets or sets the january.
        /// </summary>
        /// <value>
        /// The january.
        /// </value>
        private protected double _january;

        /// <summary>
        /// Gets or sets the february.
        /// </summary>
        /// <value>
        /// The february.
        /// </value>
        private protected double _february;

        /// <summary>
        /// Gets or sets the march.
        /// </summary>
        /// <value>
        /// The march.
        /// </value>
        private protected double _march;

        /// <summary>
        /// Gets or sets the april.
        /// </summary>
        /// <value>
        /// The april.
        /// </value>
        private protected double _april;

        /// <summary>
        /// Gets or sets the may.
        /// </summary>
        /// <value>
        /// The may.
        /// </value>
        private protected double _may;

        /// <summary>
        /// Gets or sets the june.
        /// </summary>
        /// <value>
        /// The june.
        /// </value>
        private protected double _june;

        /// <summary>
        /// Gets or sets the july.
        /// </summary>
        /// <value>
        /// The july.
        /// </value>
        private protected double _july;

        /// <summary>
        /// Gets or sets the august.
        /// </summary>
        /// <value>
        /// The august.
        /// </value>
        private protected double _august;

        /// <summary>
        /// Gets or sets the september.
        /// </summary>
        /// <value>
        /// The september.
        /// </value>
        private protected double _september;

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
                return _lineNumber;
            }
            private protected set
            {
                _lineNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the line title.
        /// </summary>
        /// <value>
        /// The line title.
        /// </value>
        public string LineTitle
        {
            get
            {
                return _lineTitle;
            }
            private protected set
            {
                _lineNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the taxation code.
        /// </summary>
        /// <value>
        /// The taxation code.
        /// </value>
        public string TaxationCode
        {
            get
            {
                return _taxationCode;
            }
            private protected set
            {
                _taxationCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the treasury agency code.
        /// </summary>
        /// <value>
        /// The treasury agency code.
        /// </value>
        public string TreasuryAgencyCode
        {
            get
            {
                return _treasuryAgencyCode;
            }
            private protected set
            {
                _treasuryAgencyCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the treasury bureau code.
        /// </summary>
        /// <value>
        /// The treasury bureau code.
        /// </value>
        public string TreasuryBureauCode
        {
            get
            {
                return _treasuryBureauCode;
            }
            private protected set
            {
                _treasuryBureauCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the budget agency code.
        /// </summary>
        /// <value>
        /// The budget agency code.
        /// </value>
        public string BudgetAgencyCode
        {
            get
            {
                return _budgetAgencyCode;
            }
            private protected set
            {
                _budgetAgencyCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the budget bureau code.
        /// </summary>
        /// <value>
        /// The budget bureau code.
        /// </value>
        public string BudgetBureauCode
        {
            get
            {
                return _budgetBureauCode;
            }
            private protected set
            {
                _budgetBureauCode = value;
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
        /// Gets or sets the agency sequence.
        /// </summary>
        /// <value>
        /// The agency sequence.
        /// </value>
        public string AgencySequence
        {
            get
            {
                return _agencySequence;
            }
            private protected set
            {
                _agencySequence = value;
            }
        }

        /// <summary>
        /// Gets or sets the bureau sequence.
        /// </summary>
        /// <value>
        /// The bureau sequence.
        /// </value>
        public string BureauSequence
        {
            get
            {
                return _bureauSequence;
            }
            private protected set
            {
                _bureauSequence = value;
            }
        }

        /// <summary>
        /// Gets or sets the account sequence.
        /// </summary>
        /// <value>
        /// The account sequence.
        /// </value>
        public string AccountSequence
        {
            get
            {
                return _accountSequence;
            }
            private protected set
            {
                _accountSequence = value;
            }
        }

        /// <summary>
        /// Gets or sets the agency title.
        /// </summary>
        /// <value>
        /// The agency title.
        /// </value>
        public string AgencyTitle
        {
            get
            {
                return _agencyTitle;
            }
            private protected set
            {
                _agencyTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets the bureau title.
        /// </summary>
        /// <value>
        /// The bureau title.
        /// </value>
        public string BureauTitle
        {
            get
            {
                return _bureauTitle;
            }
            private protected set
            {
                _bureauTitle = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.OutlayReport" /> class.
        /// </summary>
        protected OutlayReport( )
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="OutlayReport"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        protected OutlayReport( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="OutlayReport"/> class.
        /// </summary>
        /// <param name="builder"></param>
        /// <inheritdoc />
        protected OutlayReport( IDataService builder )
            : base( builder )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="OutlayReport"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <inheritdoc />
        protected OutlayReport( DataRow dataRow )
            : base( dataRow )
        {
        }
    }
}