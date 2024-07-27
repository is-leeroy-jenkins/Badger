// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="ProgramFinancingSchedule.cs" company="Terry D. Eppler">
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
//   ProgramFinancingSchedule.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class ProgramFinancingSchedule
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the report year.
        /// </summary>
        /// <value>
        /// The report year.
        /// </value>
        public string ReportYear { get; set; }

        /// <summary>
        /// Gets or sets the treasury agency code.
        /// </summary>
        /// <value>
        /// The treasury agency code.
        /// </value>
        public string TreasuryAgencyCode { get; set; }

        /// <summary>
        /// Gets or sets the treasury account code.
        /// </summary>
        /// <value>
        /// The treasury account code.
        /// </value>
        public string TreasuryAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the ledger account code.
        /// </summary>
        /// <value>
        /// The ledger account code.
        /// </value>
        public string LedgerAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the section number.
        /// </summary>
        /// <value>
        /// The section number.
        /// </value>
        public string SectionNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the section.
        /// </summary>
        /// <value>
        /// The name of the section.
        /// </value>
        public string SectionName { get; set; }

        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        /// <value>
        /// The line number.
        /// </value>
        public string LineNumber { get; set; }

        /// <summary>
        /// Gets or sets the line description.
        /// </summary>
        /// <value>
        /// The line description.
        /// </value>
        public string LineDescription { get; set; }

        /// <summary>
        /// Gets or sets the omb agency code.
        /// </summary>
        /// <value>
        /// The omb agency code.
        /// </value>
        public string OmbAgencyCode { get; set; }

        /// <summary>
        /// Gets or sets the omb fund code.
        /// </summary>
        /// <value>
        /// The omb fund code.
        /// </value>
        public string OmbFundCode { get; set; }

        /// <summary>
        /// Gets or sets the omb account title.
        /// </summary>
        /// <value>
        /// The omb account title.
        /// </value>
        public string OmbAccountTitle { get; set; }

        /// <summary>
        /// Gets or sets the agency sequence.
        /// </summary>
        /// <value>
        /// The agency sequence.
        /// </value>
        public string AgencySequence { get; set; }

        /// <summary>
        /// Gets or sets the account sequence.
        /// </summary>
        /// <value>
        /// The account sequence.
        /// </value>
        public string AccountSequence { get; set; }

        /// <summary>
        /// Gets or sets the name of the fund.
        /// </summary>
        /// <value>
        /// The name of the fund.
        /// </value>
        public string FundName { get; set; }

        /// <summary>
        /// Gets or sets the original amount.
        /// </summary>
        /// <value>
        /// The original amount.
        /// </value>
        public double OriginalAmount { get; set; }

        /// <summary>
        /// Gets or sets the budget amount.
        /// </summary>
        /// <value>
        /// The budget amount.
        /// </value>
        public double BudgetAmount { get; set; }

        /// <summary>
        /// Gets or sets the agency amount.
        /// </summary>
        /// <value>
        /// The agency amount.
        /// </value>
        public double AgencyAmount { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the name of the agency.
        /// </summary>
        /// <value>
        /// The name of the agency.
        /// </value>
        public string AgencyName { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source { get; set; }

        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ProgramFinancingSchedule"/> class.
        /// </summary>
        public ProgramFinancingSchedule( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ProgramFinancingSchedule"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public ProgramFinancingSchedule( IQuery query )
        {
            Record = new DataGenerator( query ).Record;
            Data = Record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ProgramFinancingSchedule"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public ProgramFinancingSchedule( IDataService builder )
        {
            Record = builder.Record;
            Data = Record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ProgramFinancingSchedule"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public ProgramFinancingSchedule( DataRow dataRow )
        {
            Record = dataRow;
            Data = dataRow.ToDictionary( );
        }
    }
}