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
    /// <seealso cref="T:Badger.DataUnit" />
    [SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" )]
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    public abstract class LedgerAccount : DataUnit
    {
        /// <summary>
        /// The bfy
        /// </summary>
        private protected string _bfy;

        /// <summary>
        /// The account classification
        /// </summary>
        private protected string _accountClassification;

        /// <summary>
        /// The short name
        /// </summary>
        private protected string _shortName;

        /// <summary>
        /// The number
        /// </summary>
        private protected string _number;

        /// <summary>
        /// The normal balance
        /// </summary>
        private protected string _normalBalance;

        /// <summary>
        /// The real or closing account
        /// </summary>
        private protected string _realOrClosingAccount;

        /// <summary>
        /// The summary account
        /// </summary>
        private protected string _summaryAccount;

        /// <summary>
        /// The cash account
        /// </summary>
        private protected string _cashAccount;

        /// <summary>
        /// The reportable account
        /// </summary>
        private protected string _reportableAccount;

        /// <summary>
        /// The cost allocation indicator
        /// </summary>
        private protected string _costAllocationIndicator;

        /// <summary>
        /// The federal non federal
        /// </summary>
        private protected string _federalNonFederal;

        /// <summary>
        /// The attribute value
        /// </summary>
        private protected string _attributeValue;

        /// <summary>
        /// The usage
        /// </summary>
        private protected string _usage;

        /// <summary>
        /// The deposit
        /// </summary>
        private protected string _deposit;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.LedgerAccount" /> class.
        /// </summary>
        protected LedgerAccount( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.LedgerAccount" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected LedgerAccount( IQuery query )
            : base( query )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.LedgerAccount" /> class.
        /// </summary>
        /// <param name="builder"></param>
        protected LedgerAccount( IDataModel builder )
            : base( builder )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.LedgerAccount" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected LedgerAccount( DataRow dataRow )
            : base( dataRow )
        {
        }
    }
}