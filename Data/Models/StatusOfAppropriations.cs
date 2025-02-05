﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="StatusOfAppropriations.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
// 
//    Copyright ©  2020-2024 Terry D. Eppler
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
//   StatusOfAppropriations.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class StatusOfAppropriations
    {
        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int ID { get; private protected set; }

        /// <summary> Gets or sets the bfy. </summary>
        /// <value> The bfy. </value>
        public string BFY { get; private protected set; }

        /// <summary> Gets or sets the efy. </summary>
        /// <value> The efy. </value>
        public string Efy { get; private protected set; }

        /// <summary> Gets or sets the budget level. </summary>
        /// <value> The budget level. </value>
        public string BudgetLevel { get; private protected set; }

        /// <summary> Gets or sets the appropriation fund code. </summary>
        /// <value> The appropriation fund code. </value>
        public string AppropriationFundCode { get; private protected set; }

        /// <summary> Gets or sets the name of the appropriation fund. </summary>
        /// <value> The name of the appropriation fund. </value>
        public string AppropriationFundName { get; private protected set; }

        /// <summary> Gets or sets the availability. </summary>
        /// <value> The availability. </value>
        public string Availability { get; private protected set; }

        /// <summary> Gets or sets the treasury symbol. </summary>
        /// <value> The treasury symbol. </value>
        public string TreasurySymbol { get; private protected set; }

        /// <summary> Gets or sets the appropriation creation date. </summary>
        /// <value> The appropriation creation date. </value>
        public DateTime AppropriationCreationDate { get; private protected set; }

        /// <summary> Gets or sets the appropriation code. </summary>
        /// <value> The appropriation code. </value>
        public string AppropriationCode { get; private protected set; }

        /// <summary> Gets or sets the sub appropriation code. </summary>
        /// <value> The sub appropriation code. </value>
        public string SubAppropriationCode { get; private protected set; }

        /// <summary> Gets or sets the appropriation description. </summary>
        /// <value> The appropriation description. </value>
        public string AppropriationDescription { get; private protected set; }

        /// <summary> Gets or sets the fund group. </summary>
        /// <value> The fund group. </value>
        public string FundGroup { get; private protected set; }

        /// <summary> Gets or sets the name of the fund group. </summary>
        /// <value> The name of the fund group. </value>
        public string FundGroupName { get; private protected set; }

        /// <summary> Gets or sets the type of the document. </summary>
        /// <value> The type of the document. </value>
        public string DocumentType { get; private protected set; }

        /// <summary> Gets or sets the type of the trans. </summary>
        /// <value> The type of the trans. </value>
        public string TransType { get; private protected set; }

        /// <summary> Gets or sets the actual type of the recovery trans. </summary>
        /// <value> The actual type of the recovery trans. </value>
        public string ActualRecoveryTransType { get; private protected set; }

        /// <summary> Gets or sets the commitment spending control flag. </summary>
        /// <value> The commitment spending control flag. </value>
        public string CommitmentSpendingControlFlag { get; private protected set; }

        /// <summary> Gets or sets the agreement limit. </summary>
        /// <value> The agreement limit. </value>
        public string AgreementLimit { get; private protected set; }

        /// <summary> Gets or sets the type of the estimated recoveries trans. </summary>
        /// <value> The type of the estimated recoveries trans. </value>
        public string EstimatedRecoveriesTransType { get; private protected set; }

        /// <summary>
        /// Gets or sets the type of the estimated reimbursements trans.
        /// </summary>
        /// <value> The type of the estimated reimbursements trans. </value>
        public string EstimatedReimbursementsTransType { get; private protected set; }

        /// <summary> Gets or sets the expense spending control flag. </summary>
        /// <value> The expense spending control flag. </value>
        public string ExpenseSpendingControlFlag { get; private protected set; }

        /// <summary> Gets or sets the obligation spending control flag. </summary>
        /// <value> The obligation spending control flag. </value>
        public string ObligationSpendingControlFlag { get; private protected set; }

        /// <summary> Gets or sets the pre commitment spending control flag. </summary>
        /// <value> The pre commitment spending control flag. </value>
        public string PreCommitmentSpendingControlFlag { get; private protected set; }

        /// <summary> Gets or sets the posted control flag. </summary>
        /// <value> The posted control flag. </value>
        public string PostedControlFlag { get; private protected set; }

        /// <summary> Gets or sets the posted flag. </summary>
        /// <value> The posted flag. </value>
        public string PostedFlag { get; private protected set; }

        /// <summary> Gets or sets the record carryover at lower level. </summary>
        /// <value> The record carryover at lower level. </value>
        public string RecordCarryoverAtLowerLevel { get; private protected set; }

        /// <summary> Gets or sets the reimbursable spending option. </summary>
        /// <value> The reimbursable spending option. </value>
        public string ReimbursableSpendingOption { get; private protected set; }

        /// <summary> Gets or sets the recoveries option. </summary>
        /// <value> The recoveries option. </value>
        public string RecoveriesOption { get; private protected set; }

        /// <summary> Gets or sets the recoveries spending option. </summary>
        /// <value> The recoveries spending option. </value>
        public string RecoveriesSpendingOption { get; private protected set; }

        /// <summary> Gets or sets the original budgeted amount. </summary>
        /// <value> The original budgeted amount. </value>
        public string OriginalBudgetedAmount { get; private protected set; }

        /// <summary> Gets or sets the apportionments posted. </summary>
        /// <value> The apportionments posted. </value>
        public string ApportionmentsPosted { get; private protected set; }

        /// <summary> Gets or sets the total authority. </summary>
        /// <value> The total authority. </value>
        public double TotalAuthority { get; private protected set; }

        /// <summary> Gets or sets the total budgeted. </summary>
        /// <value> The total budgeted. </value>
        public double TotalBudgeted { get; private protected set; }

        /// <summary> Gets or sets the total posted amount. </summary>
        /// <value> The total posted amount. </value>
        public double TotalPostedAmount { get; private protected set; }

        /// <summary> Gets or sets the funds withdrawn prior years amount. </summary>
        /// <value> The funds withdrawn prior years amount. </value>
        public double FundsWithdrawnPriorYearsAmount { get; private protected set; }

        /// <summary> Gets or sets the funding in amount. </summary>
        /// <value> The funding in amount. </value>
        public double FundingInAmount { get; private protected set; }

        /// <summary> Gets or sets the funding out amount. </summary>
        /// <value> The funding out amount. </value>
        public double FundingOutAmount { get; private protected set; }

        /// <summary> Gets or sets the total accrual recoveries. </summary>
        /// <value> The total accrual recoveries. </value>
        public double TotalAccrualRecoveries { get; private protected set; }

        /// <summary> Gets or sets the total actual reimbursements. </summary>
        /// <value> The total actual reimbursements. </value>
        public double TotalActualReimbursements { get; private protected set; }

        /// <summary> Gets or sets the total agreement reimbursables. </summary>
        /// <value> The total agreement reimbursables. </value>
        public double TotalAgreementReimbursables { get; private protected set; }

        /// <summary> Gets or sets the total carried forward in. </summary>
        /// <value> The total carried forward in. </value>
        public double TotalCarriedForwardIn { get; private protected set; }

        /// <summary> Gets or sets the total carried forward out. </summary>
        /// <value> The total carried forward out. </value>
        public double TotalCarriedForwardOut { get; private protected set; }

        /// <summary> Gets or sets the total committed. </summary>
        /// <value> The total committed. </value>
        public double TotalCommitted { get; private protected set; }

        /// <summary> Gets or sets the total estimated recoveries. </summary>
        /// <value> The total estimated recoveries. </value>
        public double TotalEstimatedRecoveries { get; private protected set; }

        /// <summary> Gets or sets the total estimated reimbursements. </summary>
        /// <value> The total estimated reimbursements. </value>
        public double TotalEstimatedReimbursements { get; private protected set; }

        /// <summary> Gets or sets the total expenses. </summary>
        /// <value> The total expenses. </value>
        public double TotalExpenses { get; private protected set; }

        /// <summary> Gets or sets the total expenditure expenses. </summary>
        /// <value> The total expenditure expenses. </value>
        public double TotalExpenditureExpenses { get; private protected set; }

        /// <summary> Gets or sets the total expense accruals. </summary>
        /// <value> The total expense accruals. </value>
        public double TotalExpenseAccruals { get; private protected set; }

        /// <summary> Gets or sets the total pre commitments. </summary>
        /// <value> The total pre commitments. </value>
        public double TotalPreCommitments { get; private protected set; }

        /// <summary> Gets or sets the unliquidated pre commitments. </summary>
        /// <value> The unliquidated pre commitments. </value>
        public double UnliquidatedPreCommitments { get; private protected set; }

        /// <summary> Gets or sets the total obligations. </summary>
        /// <value> The total obligations. </value>
        public double TotalObligations { get; private protected set; }

        /// <summary> Gets or sets the ulo. </summary>
        /// <value> The ulo. </value>
        public double ULO { get; private protected set; }

        /// <summary> Gets or sets the voided amount. </summary>
        /// <value> The voided amount. </value>
        public double VoidedAmount { get; private protected set; }

        /// <summary> Gets or sets the total used amount. </summary>
        /// <value> The total used amount. </value>
        public double TotalUsedAmount { get; private protected set; }

        /// <summary> Gets or sets the available amount. </summary>
        /// <value> The available amount. </value>
        public double AvailableAmount { get; private protected set; }

        /// <summary> Gets or sets the source. </summary>
        /// <value> The source. </value>
        public Source Source { get; private protected set; }

        /// <summary> Gets or sets the Record property. </summary>
        /// <value> The data row. </value>
        public DataRow Record { get; private protected set; }

        /// <summary> Gets the arguments. </summary>
        /// <value> The arguments. </value>
        public IDictionary<string, object> Data { get; private protected set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="StatusOfAppropriations"/>
        /// class.
        /// </summary>
        public StatusOfAppropriations( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="StatusOfAppropriations"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public StatusOfAppropriations( IQuery query )
        {
            Record = new DataGenerator( query ).Record;
            Data = Record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="StatusOfAppropriations"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public StatusOfAppropriations( IDataService builder )
        {
            Record = builder.Record;
            Data = Record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="StatusOfAppropriations"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public StatusOfAppropriations( DataRow dataRow )
        {
            Record = dataRow;
            Data = dataRow.ToDictionary( );
        }
    }
}