// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="IProgramResultsCode.cs" company="Terry D. Eppler">
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
//   IProgramResultsCode.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:BudgetExecution.ISource" />
    /// <seealso cref="T:BudgetExecution.ISource" />
    public interface IProgramResultsCode : ISource
    {
        /// <summary>
        /// Gets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        string BudgetLevel { get; set; }

        /// <summary>
        /// Gets the resource planning office.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        string RpioCode { get; set; }

        /// <summary>
        /// Gets the budget fiscal year.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        string BFY { get; set; }

        /// <summary>
        /// Gets the allowance holder.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        string AhCode { get; set; }

        /// <summary>
        /// Gets the fund.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        string FundCode { get; set; }

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        string OrgCode { get; set; }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the activity code.
        /// </summary>
        /// <value>
        /// The activity code.
        /// </value>
        string ActivityCode { get; set; }

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        string RcCode { get; set; }

        /// <summary>
        /// Gets the budget object class.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        string BocCode { get; set; }

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        string ProgramProjectCode { get; set; }

        /// <summary>
        /// Gets the program area.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        string ProgramAreaCode { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        double Amount { get; set; }
    }
}