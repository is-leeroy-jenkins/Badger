// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 05-12-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="BudgetControl.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application for the
//    US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
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
//   BudgetControl.cs
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
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "PublicConstructorInAbstractClass" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public abstract class BudgetControl : CompassControl
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetControls" /> class.
        /// </summary>
        public BudgetControl( ) 
            : base( )
        
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetControls" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public BudgetControl( IQuery query )
            : base( query )
        
        {
            _id = int.Parse( _record[ "BudgetControlsId" ].ToString( ) );
            _expenditureSpendingControl = _record[ "ExpenditureSpendingControl" ].ToString( );
            _fteBudgetingControl = _record[ "FteBudgetingControl" ].ToString( );
            _accrualSpendingControl = _record[ "AccrualSpendingControl" ].ToString( );
            _commitmentSpendingControl = _record[ "CommitmentSpendingControl" ].ToString( );
            _expenseSpendingControl = _record[ "ExpenseSpendingControl" ].ToString( );
            _obligationSpendingControl = _record[ "ObligationSpendingControl" ].ToString( );
            _postingControl = _record[ "PostingControl" ].ToString( );
            _preCommitmentSpendingControl = _record[ "PreCommitmentSpendingControl" ].ToString( );
            _reimbursableSpendingControl = _record[ "ReimbursableSpendingControl" ].ToString( );
            _transactionTypeControl = _record[ "TransactionTypeControl" ].ToString( );
            _trackAgreementLowerLevel = _record[ "TrackAgreementLowerLevel" ].ToString( );
            _budgetEstimateLowerLevel = _record[ "BudgetEstimateLowerLevel" ].ToString( );
            _reimbursableAgreementSpendingControl = 
                _record[ "ReimbursableSpendingControl" ].ToString( );

            _estimatedReimbursableBudgetingOption = 
                _record[ "EstimatedReimbursableBudgetingOption" ].ToString( );

            _estimatedReimbursableSpendingOption = 
                _record[ "EstimatedReimbursableSpendingOption" ].ToString( );

            _estimatedRecoveriesSpendingOption = 
                _record[ "EstimatedRecoveriesSpendingOption" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetControls" /> class.
        /// </summary>
        /// <param name="builder"></param>
        public BudgetControl( IDataModel builder )
            : base( builder )

        {
            _id = int.Parse( _record[ "BudgetControlsId" ].ToString( ) );
            _expenditureSpendingControl = _record[ "ExpenditureSpendingControl" ].ToString( );
            _fteBudgetingControl = _record[ "FteBudgetingControl" ].ToString( );
            _accrualSpendingControl = _record[ "AccrualSpendingControl" ].ToString( );
            _commitmentSpendingControl = _record[ "CommitmentSpendingControl" ].ToString( );
            _expenseSpendingControl = _record[ "ExpenseSpendingControl" ].ToString( );
            _obligationSpendingControl = _record[ "ObligationSpendingControl" ].ToString( );
            _postingControl = _record[ "PostingControl" ].ToString( );
            _preCommitmentSpendingControl = _record[ "PreCommitmentSpendingControl" ].ToString( );
            _reimbursableSpendingControl = _record[ "ReimbursableSpendingControl" ].ToString( );
            _transactionTypeControl = _record[ "TransactionTypeControl" ].ToString( );
            _trackAgreementLowerLevel = _record[ "TrackAgreementLowerLevel" ].ToString( );
            _budgetEstimateLowerLevel = _record[ "BudgetEstimateLowerLevel" ].ToString( );
            _reimbursableAgreementSpendingControl =
                _record[ "ReimbursableSpendingControl" ].ToString( );

            _estimatedReimbursableBudgetingOption =
                _record[ "EstimatedReimbursableBudgetingOption" ].ToString( );

            _estimatedReimbursableSpendingOption =
                _record[ "EstimatedReimbursableSpendingOption" ].ToString( );

            _estimatedRecoveriesSpendingOption =
                _record[ "EstimatedRecoveriesSpendingOption" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetControls" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public BudgetControl( DataRow dataRow )
            : base( dataRow )

        {
            _id = int.Parse( dataRow[ "BudgetControlsId" ].ToString( ) );
            _expenditureSpendingControl = dataRow[ "ExpenditureSpendingControl" ].ToString( );
            _fteBudgetingControl = dataRow[ "FteBudgetingControl" ].ToString( );
            _accrualSpendingControl = dataRow[ "AccrualSpendingControl" ].ToString( );
            _commitmentSpendingControl = dataRow[ "CommitmentSpendingControl" ].ToString( );
            _expenseSpendingControl = dataRow[ "ExpenseSpendingControl" ].ToString( );
            _obligationSpendingControl = dataRow[ "ObligationSpendingControl" ].ToString( );
            _postingControl = dataRow[ "PostingControl" ].ToString( );
            _preCommitmentSpendingControl = dataRow[ "PreCommitmentSpendingControl" ].ToString( );
            _reimbursableSpendingControl = dataRow[ "ReimbursableSpendingControl" ].ToString( );
            _transactionTypeControl = dataRow[ "TransactionTypeControl" ].ToString( );
            _trackAgreementLowerLevel = dataRow[ "TrackAgreementLowerLevel" ].ToString( );
            _budgetEstimateLowerLevel = dataRow[ "BudgetEstimateLowerLevel" ].ToString( );
            _reimbursableAgreementSpendingControl =
                dataRow[ "ReimbursableSpendingControl" ].ToString( );

            _estimatedReimbursableBudgetingOption =
                dataRow[ "EstimatedReimbursableBudgetingOption" ].ToString( );

            _estimatedReimbursableSpendingOption =
                dataRow[ "EstimatedReimbursableSpendingOption" ].ToString( );

            _estimatedRecoveriesSpendingOption =
                dataRow[ "EstimatedRecoveriesSpendingOption" ].ToString( );
        }
    }
}