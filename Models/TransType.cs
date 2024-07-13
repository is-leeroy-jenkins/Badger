// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="TransType.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application
//    for the US Environmental Protection Agency (US EPA).
//    Copyright ©  2024  Terry Eppler
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
//   TransType.cs
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    public class TransType : BudgetUnit
    {
        /// <summary>
        /// The document type
        /// </summary>
        private string _documentType;

        /// <summary>
        /// The appropriation bill
        /// </summary>
        private string _appropriationBill;

        /// <summary>
        /// The continuing resolution
        /// </summary>
        private string _continuingResolution;

        /// <summary>
        /// The recission current year
        /// </summary>
        private string _recissionCurrentYear;

        /// <summary>
        /// The recisssion prior year
        /// </summary>
        private string _rescissionPriorYear;

        /// <summary>
        /// The sequester reduction
        /// </summary>
        private string _sequesterReduction;

        /// <summary>
        /// The sequester return
        /// </summary>
        private string _sequesterReturn;

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
            private set
            {
                _documentType = value;
            }
        }

        /// <summary>
        /// Gets or sets the appropriation bill.
        /// </summary>
        /// <value>
        /// The appropriation bill.
        /// </value>
        public string AppropriationBill
        {
            get
            {
                return _appropriationBill;
            }
            private set
            {
                _appropriationBill = value;
            }
        }

        /// <summary>
        /// Gets or sets the continuing resolution.
        /// </summary>
        /// <value>
        /// The continuing resolution.
        /// </value>
        public string ContinuingResolution
        {
            get
            {
                return _continuingResolution;
            }
            private set
            {
                _continuingResolution = value;
            }
        }

        /// <summary>
        /// Gets or sets the rescission current year.
        /// </summary>
        /// <value>
        /// The rescission current year.
        /// </value>
        public string RescissionCurrentYear
        {
            get
            {
                return _recissionCurrentYear;
            }
            private set
            {
                _recissionCurrentYear = value;
            }
        }

        /// <summary>
        /// Gets or sets the rescission prior year.
        /// </summary>
        /// <value>
        /// The rescission prior year.
        /// </value>
        public string RescissionPriorYear
        {
            get
            {
                return _rescissionPriorYear;
            }
            private set
            {
                _rescissionPriorYear = value;
            }
        }

        /// <summary>
        /// Gets or sets the sequester reduction.
        /// </summary>
        /// <value>
        /// The sequester reduction.
        /// </value>
        public string SequesterReduction
        {
            get
            {
                return _sequesterReduction;
            }
            private set
            {
                _sequesterReduction = value;
            }
        }

        /// <summary>
        /// Gets or sets the sequester return.
        /// </summary>
        /// <value>
        /// The sequester return.
        /// </value>
        public string SequesterReturn
        {
            get
            {
                return _sequesterReturn;
            }
            private set
            {
                _sequesterReturn = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TransTypes" /> class.
        /// </summary>
        public TransType( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TransTypes" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public TransType( IQuery query )
            : base( query )
        {
            _source = query.Source;
            _provider = query.Provider;
            _record = new DataGenerator( query ).Record;
            _id = int.Parse( _record[ 0 ].ToString( ) ?? "0" );
            _code = _record[ "TreasuryAccountCode" ].ToString( );
            _name = _record[ "TreasuryAccountName" ].ToString( );
            _map = _record.ToDictionary( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _documentType = _record[ "DocumentType" ].ToString( );
            _appropriationBill = _record[ "AppropriationBill" ].ToString( );
            _continuingResolution = _record[ "ContinuingResolution" ].ToString( );
            _recissionCurrentYear = _record[ "RescissionCurrentYear" ].ToString( );
            _rescissionPriorYear = _record[ "RescissionPriorYear" ].ToString( );
            _sequesterReduction = _record[ "SequestrationReduction" ].ToString( );
            _sequesterReturn = _record[ "SequestrationReturn" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TransTypes" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public TransType( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ 0 ].ToString( ) ?? "0" );
            _code = _record[ "TreasuryAccountCode" ].ToString( );
            _name = _record[ "TreasuryAccountName" ].ToString( );
            _map = _record.ToDictionary( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _documentType = _record[ "DocumentType" ].ToString( );
            _appropriationBill = _record[ "AppropriationBill" ].ToString( );
            _continuingResolution = _record[ "ContinuingResolution" ].ToString( );
            _recissionCurrentYear = _record[ "RescissionCurrentYear" ].ToString( );
            _rescissionPriorYear = _record[ "RescissionPriorYear" ].ToString( );
            _sequesterReduction = _record[ "SequestrationReduction" ].ToString( );
            _sequesterReturn = _record[ "SequestrationReturn" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TransTypes" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public TransType( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ 0 ].ToString( ) ?? "0" );
            _code = dataRow[ "TreasuryAccountCode" ].ToString( );
            _name = dataRow[ "TreasuryAccountName" ].ToString( );
            _map = dataRow.ToDictionary( );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _fundCode = dataRow[ "FundCode" ].ToString( );
            _fundName = dataRow[ "FundName" ].ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ].ToString( );
            _documentType = dataRow[ "DocumentType" ].ToString( );
            _appropriationBill = dataRow[ "AppropriationBill" ].ToString( );
            _continuingResolution = dataRow[ "ContinuingResolution" ].ToString( );
            _recissionCurrentYear = dataRow[ "RescissionCurrentYear" ].ToString( );
            _rescissionPriorYear = dataRow[ "RescissionPriorYear" ].ToString( );
            _sequesterReduction = dataRow[ "SequestrationReduction" ].ToString( );
            _sequesterReturn = dataRow[ "SequestrationReturn" ].ToString( );
        }
    }
}