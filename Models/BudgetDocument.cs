// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="AppropriationLevelAuthority.cs" company="Terry D. Eppler">
//    Badger is a federal budget, finance, and accounting application for EPA analysts.
//    Copyright ©  2023  Terry Eppler
// 
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
//   BudgetDocument.cs
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
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    public class BudgetDocument : ControlDocument
    {
        /// <summary>
        /// The document date
        /// </summary>
        private DateTime _documentDate;
        
        /// <summary>
        /// Gets or sets the document date.
        /// </summary>
        /// <value>
        /// The document date.
        /// </value>
        public DateTime DocumentDate
        {
            get
            {
                return _documentDate;
            }
            private protected set
            {
                _documentDate = value;
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
            private protected set
            {
                _budgeted = value;
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
            private protected set
            {
                _posted = value;
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
            private protected set
            {
                _carryoverOut = value;
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
            private protected set
            {
                _carryoverIn = value;
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
            private protected set
            {
                _reimbursements = value;
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
            private protected set
            {
                _recoveries = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetDocuments" /> class.
        /// </summary>
        public BudgetDocument( ) 
            : base( )
        {
            _source = Source.BudgetDocuments;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetDocuments" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public BudgetDocument( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "BudgetDocumentsId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _fundCode = _record[ "FundName" ].ToString( );
            _documentType = _record[ "DocumentType" ].ToString( );
            _documentNumber = _record[ "DocumentNumber" ].ToString( );
            _documentDate = DateTime.Parse( _record[ "DocumentDate" ].ToString( ) ?? "" );
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
        /// <see cref="T:Badger.BudgetDocuments" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public BudgetDocument( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "BudgetDocumentsId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _fundCode = _record[ "FundName" ].ToString( );
            _documentType = _record[ "DocumentType" ].ToString( );
            _documentNumber = _record[ "DocumentNumber" ].ToString( );
            _documentDate = DateTime.Parse( _record[ "DocumentDate" ].ToString( ) ?? "" );
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
        /// <see cref="T:Badger.BudgetDocuments" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public BudgetDocument( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "BudgetDocumentsId" ].ToString( ) ?? "0" );
            _budgetLevel = _record[ "BudgetLevel" ].ToString( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fund = _record[ "Fund" ].ToString( );
            _fundCode = _record[ "FundName" ].ToString( );
            _documentType = _record[ "DocumentType" ].ToString( );
            _documentNumber = _record[ "DocumentNumber" ].ToString( );
            _documentDate = DateTime.Parse( _record[ "DocumentDate" ].ToString( ) ?? "" );
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
        /// <see cref="T:Badger.BudgetDocuments" /> class.
        /// </summary>
        /// <param name="budgetDocument">The budget document.</param>
        public BudgetDocument( BudgetDocument budgetDocument ) 
            : this( )
        {
            _record = budgetDocument.Record;
            _map = budgetDocument.Map;
            _budgetLevel = budgetDocument.BudgetLevel;
            _bfy = budgetDocument.BFY;
            _efy = budgetDocument.EFY;
            _fundCode = budgetDocument.FundCode;
            _fundName = budgetDocument.FundName;
            _documentType = budgetDocument.DocumentType;
            _documentDate = budgetDocument.DocumentDate;
            _budgeted = budgetDocument.Budgeted;
            _posted = budgetDocument.Posted;
            _carryoverOut = budgetDocument.CarryoverOut;
            _carryoverIn = budgetDocument.CarryoverIn;
            _recoveries = budgetDocument.Recoveries;
            _reimbursements = budgetDocument.Reimbursements;
            _treasuryAccountCode = budgetDocument.TreasuryAccountCode;
            _treasuryAccountName = budgetDocument.TreasuryAccountName;
            _budgetAccountCode = budgetDocument.BudgetAccountCode;
            _budgetAccountName = budgetDocument.BudgetAccountName;
        }
    }
}