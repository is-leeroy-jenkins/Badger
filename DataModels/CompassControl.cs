// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="CompassControl.cs" company="Terry D. Eppler">
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
//   CompassControl.cs
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
    public abstract class CompassControl : SystemControl
    {
        /// <summary>
        /// Gets or sets the estimated reimbursable spending option.
        /// </summary>
        /// <value>
        /// The estimated reimbursable spending option.
        /// </value>
        public string EstimatedReimbursableSpendingOption
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the estimated reimbursable budgeting option.
        /// </summary>
        /// <value>
        /// The estimated reimbursable budgeting option.
        /// </value>
        public string EstimatedReimbursableBudgetingOption
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the track agreement lower level.
        /// </summary>
        /// <value>
        /// The track agreement lower level.
        /// </value>
        public string TrackAgreementLowerLevel
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the budget estimate lower level.
        /// </summary>
        /// <value>
        /// The budget estimate lower level.
        /// </value>
        public string BudgetEstimateLowerLevel
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the estimated recoveries spending option.
        /// </summary>
        /// <value>
        /// The estimated recoveries spending option.
        /// </value>
        public string EstimatedRecoveriesSpendingOption
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the estimated recoveries budgeting option.
        /// </summary>
        /// <value>
        /// The estimated recoveries budgeting option.
        /// </value>
        public string EstimatedRecoveriesBudgetingOption
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the budgeting control.
        /// </summary>
        /// <value>
        /// The budgeting control.
        /// </value>
        public string BudgetingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the posting control.
        /// </summary>
        /// <value>
        /// The posting control.
        /// </value>
        public string PostingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the pre commitment spending control.
        /// </summary>
        /// <value>
        /// The pre commitment spending control.
        /// </value>
        public string PreCommitmentSpendingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the commitment spending control.
        /// </summary>
        /// <value>
        /// The commitment spending control.
        /// </value>
        public string CommitmentSpendingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the obligation spending control.
        /// </summary>
        /// <value>
        /// The obligation spending control.
        /// </value>
        public string ObligationSpendingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the accrual spending control.
        /// </summary>
        /// <value>
        /// The accrual spending control.
        /// </value>
        public string AccrualSpendingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the expenditure spending control.
        /// </summary>
        /// <value>
        /// The expenditure spending control.
        /// </value>
        public string ExpenditureSpendingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the expense spending control.
        /// </summary>
        /// <value>
        /// The expense spending control.
        /// </value>
        public string ExpenseSpendingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the reimbursable spending control.
        /// </summary>
        /// <value>
        /// The reimbursable spending control.
        /// </value>
        public string ReimbursableSpendingControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the reimbursable agreement spending control.
        /// </summary>
        /// <value>
        /// The reimbursable agreement spending control.
        /// </value>
        public string ReimbursableAgreementSpendingControl
        {
            get
            {
                return _reimbursableAgreementSpendingControl;
            }
            private protected set
            {
                _reimbursableAgreementSpendingControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the fte budgeting control.
        /// </summary>
        /// <value>
        /// The fte budgeting control.
        /// </value>
        public string FteBudgetingControl
        {
            get
            {
                return _fteBudgetingControl;
            }
            private protected set
            {
                _fteBudgetingControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the fte spending control.
        /// </summary>
        /// <value>
        /// The fte spending control.
        /// </value>
        public string FteSpendingControl
        {
            get
            {
                return _fteSpendingControl;
            }
            private protected set
            {
                _fteSpendingControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the transaction type control.
        /// </summary>
        /// <value>
        /// The transaction type control.
        /// </value>
        public string TransactionTypeControl
        {
            get
            {
                return _transactionTypeControl;
            }
            private protected set
            {
                _transactionTypeControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the authority distribution control.
        /// </summary>
        /// <value>
        /// The authority distribution control.
        /// </value>
        public string AuthorityDistributionControl
        {
            get
            {
                return _authorityDistributionControl;
            }
            private protected set
            {
                _authorityDistributionControl = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SystemControl" /> class.
        /// </summary>
        protected CompassControl( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SystemControl" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected CompassControl( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SystemControl" /> class.
        /// </summary>
        /// <param name="builder"></param>
        protected CompassControl( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.SystemControl" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected CompassControl( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = _record.ToDictionary( );
        }
    }
}