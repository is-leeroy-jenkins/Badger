// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 09-05-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-05-2024
// ******************************************************************************************
// <copyright file="AppropriationDocument.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts
//    that is based on WPF, NET6.0, and written in C-Sharp.
// 
//     Copyright ©  2020, 2022, 2204 Terry D. Eppler
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
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   AppropriationDocument.cs
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
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class AppropriationDocument : ControlDocument
    {
        /// <summary>
        /// Gets or sets the last document date.
        /// </summary>
        /// <value>
        /// The last document date.
        /// </value>
        public DateTime LastActivityDate
        {
            get
            {
                return _lastActivityDate;
            }
            set
            {
                if( _lastActivityDate != value )
                {
                    _lastActivityDate = value;
                    OnPropertyChanged( nameof( LastActivityDate ) );
                }
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
            set
            {
                if( _budgeted != value )
                {
                    _budgeted = value;
                    OnPropertyChanged( nameof( Budgeted ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the posted.
        /// </summary>
        /// <value>
        /// The posted.
        /// </value>
        public double Posted
        {
            get
            {
                return _posted;
            }
            set
            {
                if( _posted != value )
                {
                    _posted = value;
                    OnPropertyChanged( nameof( Posted ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the carryover out.
        /// </summary>
        /// <value>
        /// The carryover out.
        /// </value>
        public double CarryoverOut
        {
            get
            {
                return _carryoverOut;
            }
            set
            {
                if( _carryoverOut != value )
                {
                    _carryoverOut = value;
                    OnPropertyChanged( nameof( CarryoverOut ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the carryover in.
        /// </summary>
        /// <value>
        /// The carryover in.
        /// </value>
        public double CarryoverIn
        {
            get
            {
                return _carryoverIn;
            }
            set
            {
                if( _carryoverIn != value )
                {
                    _carryoverIn = value;
                    OnPropertyChanged( nameof( CarryoverIn ) );
                }
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
            set
            {
                if( _reimbursements != value )
                {
                    _reimbursements = value;
                    OnPropertyChanged( nameof( Reimbursements ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the recoveries.
        /// </summary>
        /// <value>
        /// The recoveries.
        /// </value>
        public double Recoveries
        {
            get
            {
                return _recoveries;
            }
            set
            {
                if( _recoveries != value )
                {
                    _recoveries = value;
                    OnPropertyChanged( nameof( Recoveries ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the budgeting controls.
        /// </summary>
        /// <value>
        /// The budgeting controls.
        /// </value>
        public string BudgetingControls
        {
            get
            {
                return _budgetingControls;
            }
            set
            {
                if( _budgetingControls != value )
                {
                    _budgetingControls = value;
                    OnPropertyChanged( nameof( BudgetingControls ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the posting controls.
        /// </summary>
        /// <value>
        /// The posting controls.
        /// </value>
        public string PostingControls
        {
            get
            {
                return _postingControls;
            }
            set
            {
                if( _postingControls != value )
                {
                    _postingControls = value;
                    OnPropertyChanged( nameof( PostingControls ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the pre commitment controls.
        /// </summary>
        /// <value>
        /// The pre commitment controls.
        /// </value>
        public string PreCommitmentControls
        {
            get
            {
                return _preCommitmentControls;
            }
            set
            {
                if( _preCommitmentControls != value )
                {
                    _preCommitmentControls = value;
                    OnPropertyChanged( nameof( PreCommitmentControls ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the commitment controls.
        /// </summary>
        /// <value>
        /// The commitment controls.
        /// </value>
        public string CommitmentControls
        {
            get
            {
                return _commitmentControls;
            }
            set
            {
                _commitmentControls = value;
                OnPropertyChanged( nameof( CommitmentControls ) );
            }
        }

        /// <summary>
        /// Gets or sets the obligation controls.
        /// </summary>
        /// <value>
        /// The obligation controls.
        /// </value>
        public string ObligationControls
        {
            get
            {
                return _obligationControls;
            }
            set
            {
                _obligationControls = value;
                OnPropertyChanged( nameof( ObligationControls ) );
            }
        }

        /// <summary>
        /// Gets or sets the accrual controls.
        /// </summary>
        /// <value>
        /// The accrual controls.
        /// </value>
        public string AccrualControls
        {
            get
            {
                return _accrualControls;
            }
            set
            {
                _accrualControls = value;
                OnPropertyChanged( nameof( AccrualControls ) );
            }
        }

        /// <summary>
        /// Gets or sets the expenditure controls.
        /// </summary>
        /// <value>
        /// The expenditure controls.
        /// </value>
        public string ExpenditureControls
        {
            get
            {
                return _expenditureControls;
            }
            set
            {
                _expenditureControls = value;
                OnPropertyChanged( nameof( ExpenditureControls ) );
            }
        }

        /// <summary>
        /// Gets or sets the expense controls.
        /// </summary>
        /// <value>
        /// The expense controls.
        /// </value>
        public string ExpenseControls
        {
            get
            {
                return _expenseControls;
            }
            set
            {
                _expenseControls = value;
                OnPropertyChanged( nameof( ExpenseControls ) );
            }
        }

        /// <summary>
        /// Gets or sets the reimbursement controls.
        /// </summary>
        /// <value>
        /// The reimbursement controls.
        /// </value>
        public string ReimbursementControls
        {
            get
            {
                return _reimbursementControls;
            }
            set
            {
                _reimbursementControls = value;
                OnPropertyChanged( nameof( ReimbursementControls ) );
            }
        }

        /// <summary>
        /// Gets or sets the reimbursable agreement controls.
        /// </summary>
        /// <value>
        /// The reimbursable agreement controls.
        /// </value>
        public string ReimbursableAgreementControls
        {
            get
            {
                return _reimbursableAgreementControls;
            }
            set
            {
                _reimbursableAgreementControls = value;
                OnPropertyChanged( nameof( ReimbursableAgreementControls ) );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationDocument" /> class.
        /// </summary>
        public AppropriationDocument( )
            : base( )
        {
            _source = Source.AppropriationDocuments;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationDocument" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public AppropriationDocument( IQuery query )
            : base( query )
        {
            _id = int.Parse( _record[ "AppropriationDocumentsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _fundCode = _record[ "FundName" ].ToString( );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _carryoverOut = double.Parse( _record[ "CarryoverOut" ].ToString( ) ?? "0" );
            _carryoverIn = double.Parse( _record[ "CarryoverIn" ].ToString( ) ?? "0" );
            _recoveries = double.Parse( _record[ "Recoveries" ].ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationDocument" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public AppropriationDocument( IDataService builder )
            : base( builder )
        {
            _id = int.Parse( _record[ "AppropriationDocumentsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _fundCode = _record[ "FundName" ].ToString( );
            _budgeted = double.Parse( _record[ "Budgeted" ].ToString( ) ?? "0" );
            _posted = double.Parse( _record[ "Posted" ].ToString( ) ?? "0" );
            _carryoverOut = double.Parse( _record[ "CarryoverOut" ].ToString( ) ?? "0" );
            _carryoverIn = double.Parse( _record[ "CarryoverIn" ].ToString( ) ?? "0" );
            _recoveries = double.Parse( _record[ "Recoveries" ].ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationDocument" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public AppropriationDocument( DataRow dataRow )
            : base( dataRow )
        {
            _id = int.Parse( dataRow[ "AppropriationDocumentsId" ].ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _fund = dataRow[ "Fund" ].ToString( );
            _fundCode = dataRow[ "FundName" ].ToString( );
            _budgeted = double.Parse( dataRow[ "Budgeted" ].ToString( ) ?? "0" );
            _posted = double.Parse( dataRow[ "Posted" ].ToString( ) ?? "0" );
            _carryoverOut = double.Parse( dataRow[ "CarryoverOut" ].ToString( ) ?? "0" );
            _carryoverIn = double.Parse( dataRow[ "CarryoverIn" ].ToString( ) ?? "0" );
            _recoveries = double.Parse( dataRow[ "Recoveries" ].ToString( ) ?? "0" );
            _reimbursements = double.Parse( dataRow[ "Reimbursements" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AppropriationDocument" /> class.
        /// </summary>
        /// <param name="document">The document.</param>
        public AppropriationDocument( AppropriationDocument document )
            : base( )
        {
            _id = document.ID;
            _bfy = document.BFY;
            _efy = document.EFY;
            _fund = document.Fund;
            _fundCode = document.FundCode;
            _documentType = document.DocumentType;
            _documentNumber = document.DocumentNumber;
            _processedDate = document.ProcessedDate;
            _budgetingControls = document.BudgetingControls;
            _postingControls = document.PostingControls;
            _preCommitmentControls = document.PreCommitmentControls;
            _commitmentControls = document.CommitmentControls;
            _obligationControls = document.ObligationControls;
            _accrualControls = document.AccrualControls;
            _expenditureControls = document.ExpenditureControls;
            _budgeted = document.Budgeted;
            _posted = document.Posted;
            _carryoverOut = document.CarryoverOut;
            _carryoverIn = document.CarryoverIn;
            _recoveries = document.Recoveries;
            _reimbursements = document.Reimbursements;
            _treasuryAccountCode = document.TreasuryAccountCode;
            _treasuryAccountName = document.TreasuryAccountName;
            _budgetAccountCode = document.BudgetAccountCode;
            _budgetAccountName = document.BudgetAccountName;
        }
    }
}