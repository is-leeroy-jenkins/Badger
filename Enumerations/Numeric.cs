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

    /// <summary>
    /// 
    /// </summary>
    public enum Numeric
    {
        /// <summary>
        /// The accepted
        /// </summary>
        Accepted,

        /// <summary>
        /// The agency amount
        /// </summary>
        AgencyAmount,

        /// <summary>
        /// The allocation percentage
        /// </summary>
        AllocationPercentage,

        /// <summary>
        /// The amount
        /// </summary>
        Amount,

        /// <summary>
        /// The amount1
        /// </summary>
        Amount1,

        /// <summary>
        /// The amount2
        /// </summary>
        Amount2,

        /// <summary>
        /// The amount3
        /// </summary>
        Amount3,

        /// <summary>
        /// The amount4
        /// </summary>
        Amount4,

        /// <summary>
        /// The annual base hours
        /// </summary>
        AnnualBaseHours,

        /// <summary>
        /// The annual other paid
        /// </summary>
        AnnualOtherPaid,

        /// <summary>
        /// The annual overtime hours
        /// </summary>
        AnnualOvertimeHours,

        /// <summary>
        /// The april
        /// </summary>
        April,

        /// <summary>
        /// The august
        /// </summary>
        August,

        /// <summary>
        /// The authority
        /// </summary>
        Authority,

        /// <summary>
        /// The available
        /// </summary>
        Available,

        /// <summary>
        /// The available balance
        /// </summary>
        AvailableBalance,

        /// <summary>
        /// The available hours
        /// </summary>
        AvailableHours,

        /// <summary>
        /// The balance
        /// </summary>
        Balance,

        /// <summary>
        /// The base hours
        /// </summary>
        BaseHours,

        /// <summary>
        /// The base paid
        /// </summary>
        BasePaid,

        /// <summary>
        /// The beginning balance
        /// </summary>
        BeginningBalance,

        /// <summary>
        /// The benefits
        /// </summary>
        Benefits,

        /// <summary>
        /// The budget amount
        /// </summary>
        BudgetAmount,

        /// <summary>
        /// The budget authority
        /// </summary>
        BudgetAuthority,

        /// <summary>
        /// The budget year
        /// </summary>
        BudgetYear,

        /// <summary>
        /// The budget year adjustment
        /// </summary>
        BudgetYearAdjustment,

        /// <summary>
        /// The budget year rate
        /// </summary>
        BudgetYearRate,

        /// <summary>
        /// The budgeted
        /// </summary>
        Budgeted,

        /// <summary>
        /// The carry in
        /// </summary>
        CarryIn,

        /// <summary>
        /// The carry out
        /// </summary>
        CarryOut,

        /// <summary>
        /// The carryover
        /// </summary>
        Carryover,

        /// <summary>
        /// The carryover outlays
        /// </summary>
        CarryoverOutlays,

        /// <summary>
        /// The carryover availability percentage
        /// </summary>
        CarryoverAvailabilityPercentage,

        /// <summary>
        /// The closed
        /// </summary>
        Closed,

        /// <summary>
        /// The closing amount
        /// </summary>
        ClosingAmount,

        /// <summary>
        /// The collections
        /// </summary>
        Collections,

        /// <summary>
        /// The commitments
        /// </summary>
        Commitments,

        /// <summary>
        /// The credit balance
        /// </summary>
        CreditBalance,

        /// <summary>
        /// The cumulative benefits
        /// </summary>
        CumulativeBenefits,

        /// <summary>
        /// The cumulative reciepts
        /// </summary>
        CumulativeReciepts,

        /// <summary>
        /// The current year
        /// </summary>
        CurrentYear,

        /// <summary>
        /// The current year adjustment
        /// </summary>
        CurrentYearAdjustment,

        /// <summary>
        /// The debit balance
        /// </summary>
        DebitBalance,

        /// <summary>
        /// The delta
        /// </summary>
        Delta,

        /// <summary>
        /// The deobligations
        /// </summary>
        Deobligations,

        /// <summary>
        /// The disbursements
        /// </summary>
        Disbursements,

        /// <summary>
        /// The duration
        /// </summary>
        Duration,

        /// <summary>
        /// The estimate
        /// </summary>
        Estimate,

        /// <summary>
        /// The estimated recoveries
        /// </summary>
        EstimatedRecoveries,

        /// <summary>
        /// The estimated reimbursements
        /// </summary>
        EstimatedReimbursements,

        /// <summary>
        /// The expended
        /// </summary>
        Expended,

        /// <summary>
        /// The expenditures
        /// </summary>
        Expenditures,

        /// <summary>
        /// The february
        /// </summary>
        February,

        /// <summary>
        /// The funds in
        /// </summary>
        FundsIn,

        /// <summary>
        /// The funding in amount
        /// </summary>
        FundingInAmount,

        /// <summary>
        /// The funds out
        /// </summary>
        FundsOut,

        /// <summary>
        /// The funding out amount
        /// </summary>
        FundingOutAmount,

        /// <summary>
        /// The growth rate
        /// </summary>
        GrowthRate,

        /// <summary>
        /// The hours
        /// </summary>
        Hours,

        /// <summary>
        /// The january
        /// </summary>
        January,

        /// <summary>
        /// The june
        /// </summary>
        June,

        /// <summary>
        /// The maximum carryover excess
        /// </summary>
        MaxCarryoverExcess,

        /// <summary>
        /// The maximum leave carryover
        /// </summary>
        MaxLeaveCarryover,

        /// <summary>
        /// The may
        /// </summary>
        May,

        /// <summary>
        /// The november
        /// </summary>
        November,

        /// <summary>
        /// The obligation rate
        /// </summary>
        ObligationRate,

        /// <summary>
        /// The obligations
        /// </summary>
        Obligations,

        /// <summary>
        /// The obligations paid
        /// </summary>
        ObligationsPaid,

        /// <summary>
        /// The october
        /// </summary>
        October,

        /// <summary>
        /// The open commitments
        /// </summary>
        OpenCommitments,

        /// <summary>
        /// The ordered
        /// </summary>
        Ordered,

        /// <summary>
        /// The original amount
        /// </summary>
        OriginalAmount,

        /// <summary>
        /// The out year1
        /// </summary>
        OutYear1,

        /// <summary>
        /// The out year10
        /// </summary>
        OutYear10,

        /// <summary>
        /// The out year11
        /// </summary>
        OutYear11,

        /// <summary>
        /// The out year2
        /// </summary>
        OutYear2,

        /// <summary>
        /// The out year3
        /// </summary>
        OutYear3,

        /// <summary>
        /// The out year4
        /// </summary>
        OutYear4,

        /// <summary>
        /// The out year5
        /// </summary>
        OutYear5,

        /// <summary>
        /// The out year6
        /// </summary>
        OutYear6,

        /// <summary>
        /// The out year7
        /// </summary>
        OutYear7,

        /// <summary>
        /// The out year8
        /// </summary>
        OutYear8,

        /// <summary>
        /// The out year9
        /// </summary>
        OutYear9,

        /// <summary>
        /// The outstanding
        /// </summary>
        Outstanding,

        /// <summary>
        /// The overtime hours
        /// </summary>
        OvertimeHours,

        /// <summary>
        /// The overtime paid
        /// </summary>
        OvertimePaid,

        /// <summary>
        /// The posted
        /// </summary>
        Posted,

        /// <summary>
        /// The prior year
        /// </summary>
        PriorYear,

        /// <summary>
        /// The projected annual
        /// </summary>
        ProjectedAnnual,

        /// <summary>
        /// The projected pay period
        /// </summary>
        ProjectedPayPeriod,

        /// <summary>
        /// The rate
        /// </summary>
        Rate,

        /// <summary>
        /// The refunded
        /// </summary>
        Refunded,

        /// <summary>
        /// The request
        /// </summary>
        Request,

        /// <summary>
        /// The reversal
        /// </summary>
        Reversal,

        /// <summary>
        /// The reversed
        /// </summary>
        Reversed,

        /// <summary>
        /// The spending rate
        /// </summary>
        SpendingRate,

        /// <summary>
        /// The total spendout
        /// </summary>
        TotalSpendout,

        /// <summary>
        /// The total authority
        /// </summary>
        TotalAuthority,

        /// <summary>
        /// The total used
        /// </summary>
        TotalUsed,

        /// <summary>
        /// The ulo
        /// </summary>
        ULO,

        /// <summary>
        /// The unpaid balances
        /// </summary>
        UnpaidBalances,

        /// <summary>
        /// The use or lose
        /// </summary>
        UseOrLose,

        /// <summary>
        /// The year to date amount
        /// </summary>
        YearToDateAmount,

        /// <summary>
        /// The year to date earned
        /// </summary>
        YearToDateEarned,

        /// <summary>
        /// The year to date used
        /// </summary>
        YearToDateUsed
    }
}