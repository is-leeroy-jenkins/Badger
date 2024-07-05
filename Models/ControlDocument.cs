namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.BudgetUnit" />
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    public abstract class ControlDocument : BudgetUnit
    {
        /// <summary>
        /// The last activity date
        /// </summary>
        private protected DateTime _lastActivityDate;

        /// <summary>
        /// The fund
        /// </summary>
        private protected string _fund;

        /// <summary>
        /// The documnet type
        /// </summary>
        private protected string _documentType;

        /// <summary>
        /// The document number
        /// </summary>
        private protected string _documentNumber;

        /// <summary>
        /// The budget level
        /// </summary>
        private protected string _budgetLevel;

        /// <summary>
        /// The processed date
        /// </summary>
        private protected DateTime _processedDate;

        /// <summary>
        /// The budgeting controls
        /// </summary>
        private protected string _budgetingControls;

        /// <summary>
        /// The posting controls
        /// </summary>
        private protected string _postingControls;

        /// <summary>
        /// The pre commitment controls
        /// </summary>
        private protected string _preCommitmentControls;

        /// <summary>
        /// The commitment controls
        /// </summary>
        private protected string _commitmentControls;

        /// <summary>
        /// The obligation controls
        /// </summary>
        private protected string _obligationControls;

        /// <summary>
        /// The accrual controls
        /// </summary>
        private protected string _accrualControls;

        /// <summary>
        /// The expenditure controls
        /// </summary>
        private protected string _expenditureControls;

        /// <summary>
        /// The expense controls
        /// </summary>
        private protected string _expenseControls;

        /// <summary>
        /// The reimbursement controls
        /// </summary>
        private protected string _reimbursementControls;

        /// <summary>
        /// The reimbursable agreement controls
        /// </summary>
        private protected string _reimbursableAgreementControls;

        /// <summary>
        /// The budgeted
        /// </summary>
        private protected double _budgeted;

        /// <summary>
        /// The posted
        /// </summary>
        private protected double _posted;

        /// <summary>
        /// The carryover in
        /// </summary>
        private protected double _carryoverIn;

        /// <summary>
        /// The carryover out
        /// </summary>
        private protected double _carryoverOut;

        /// <summary>
        /// The reimbursements
        /// </summary>
        private protected double _reimbursements;

        /// <summary>
        /// The recoveries
        /// </summary>
        private protected double _recoveries;
        
        /// <summary>
        /// Gets or sets the document date.
        /// </summary>
        /// <value>
        /// The document date.
        /// </value>
        public DateTime ProcessedDate
        {
            get
            {
                return _lastActivityDate;
            }
            private protected set
            {
                _lastActivityDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the fund.
        /// </summary>
        /// <value>
        /// The fund.
        /// </value>
        public string Fund
        {
            get
            {
                return _fund;
            }
            private protected set
            {
                _fund = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        public string DocumentType
        {
            get
            {
                return _documentType;
            }
            private protected set
            {
                _documentType = value;
            }
        }

        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        /// <value>
        /// The document number.
        /// </value>
        public string DocumentNumber
        {
            get
            {
                return _documentNumber;
            }
            private protected set
            {
                _documentNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        public string BudgetLevel
        {
            get
            {
                return _budgetLevel;
            }
            private protected set
            {
                _budgetLevel = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ControlDocument"/> class.
        /// </summary>
        /// <inheritdoc />
        protected ControlDocument( )
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlDocument"/> class.
        /// </summary>
        /// <param name="builder"></param>
        /// <inheritdoc />
        protected ControlDocument( IDataModel builder )
            : base( builder )
        {
            _source = builder.Source;
            _record = builder.Record;
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _documentNumber = _record[ "DocumnetNumber" ].ToString( );
            _documentType = _record[ "DocumentType" ].ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ].ToString( ) );
            _budgetingControls = _record[ "BudgetingControls" ].ToString( );
            _postingControls = _record[ "PostingControls" ].ToString( );
            _preCommitmentControls = _record[ "PreCommitmentControls" ].ToString( );
            _commitmentControls = _record[ "CommitmentControls" ].ToString( );
            _obligationControls = _record[ "ObligationControls" ].ToString( );
            _accrualControls = _record[ "AccrualControls" ].ToString( );
            _expenditureControls = _record[ "ExpenditureControls" ].ToString( );
            _expenseControls = _record[ "ExpenseControls" ].ToString( );
            _reimbursementControls = _record[ "ReimbursementControls" ].ToString( );
            _reimbursableAgreementControls = 
                _record[ "ReimbursableAgreementControls" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ControlDocument"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        protected ControlDocument( IQuery query )
            : base( query )
        {
            _source = query.Source;
            _record = new DataGenerator( query ).Record;
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _documentNumber = _record[ "DocumnetNumber" ].ToString( );
            _documentType = _record[ "DocumentType" ].ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ].ToString( ) );
            _budgetingControls = _record[ "BudgetingControls" ].ToString( );
            _postingControls = _record[ "PostingControls" ].ToString( );
            _preCommitmentControls = _record[ "PreCommitmentControls" ].ToString( );
            _commitmentControls = _record[ "CommitmentControls" ].ToString( );
            _obligationControls = _record[ "ObligationControls" ].ToString( );
            _accrualControls = _record[ "AccrualControls" ].ToString( );
            _expenditureControls = _record[ "ExpenditureControls" ].ToString( );
            _expenseControls = _record[ "ExpenseControls" ].ToString( );
            _reimbursementControls = _record[ "ReimbursementControls" ].ToString( );
            _reimbursableAgreementControls =
                _record[ "ReimbursableAgreementControls" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ControlDocument"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <inheritdoc />
        protected ControlDocument( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _budgetLevel = dataRow[ "BudgetLevel" ].ToString( );
            _fund = dataRow[ "Fund" ].ToString( );
            _documentNumber = dataRow[ "DocumnetNumber" ].ToString( );
            _documentType = dataRow[ "DocumentType" ].ToString( );
            _processedDate = DateTime.Parse( dataRow[ "ProcessedDate" ].ToString( ) );
            _budgetingControls = dataRow[ "BudgetingControls" ].ToString( );
            _postingControls = dataRow[ "PostingControls" ].ToString( );
            _preCommitmentControls = dataRow[ "PreCommitmentControls" ].ToString( );
            _commitmentControls = dataRow[ "CommitmentControls" ].ToString( );
            _obligationControls = dataRow[ "ObligationControls" ].ToString( );
            _accrualControls = dataRow[ "AccrualControls" ].ToString( );
            _expenditureControls = dataRow[ "ExpenditureControls" ].ToString( );
            _expenseControls = dataRow[ "ExpenseControls" ].ToString( );
            _reimbursementControls = dataRow[ "ReimbursementControls" ].ToString( );
            _reimbursableAgreementControls =
                dataRow[ "ReimbursableAgreementControls" ].ToString( );
        }
    }
}
