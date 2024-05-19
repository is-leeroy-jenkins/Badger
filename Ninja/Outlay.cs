// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="Outlay.cs" company="Terry D. Eppler">
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
//   Outlay.cs
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
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class Outlay : BudgetUnit
    {
        /// <summary>
        /// The appropriation code
        /// </summary>
        private string _appropriationCode;

        /// <summary>
        /// The appropriation name
        /// </summary>
        private string _appropriationName;

        /// <summary>
        /// The month processed
        /// </summary>
        private string _monthProcessed;

        /// <summary>
        /// The total obligations
        /// </summary>
        private double _totalObligations;

        /// <summary>
        /// The unliquidated obligations
        /// </summary>
        private double _unliquidatedObligations;

        /// <summary>
        /// The obligations paid
        /// </summary>
        private double _obligationsPaid;

        /// <summary>
        /// Gets or sets the appropriation code.
        /// </summary>
        /// <value>
        /// The appropriation code.
        /// </value>
        public string AppropriationCode
        {
            get
            {
                return _appropriationCode;
            }
            private set
            {
                _appropriationCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the appropriation.
        /// </summary>
        /// <value>
        /// The name of the appropriation.
        /// </value>
        public string AppropriationName
        {
            get
            {
                return _appropriationName;
            }
            private set
            {
                _appropriationName = value;
            }
        }

        /// <summary>
        /// Gets or sets the month processed.
        /// </summary>
        /// <value>
        /// The month processed.
        /// </value>
        public string MonthProcessed
        {
            get
            {
                return _monthProcessed;
            }
            private set
            {
                _monthProcessed = value;
            }
        }

        /// <summary>
        /// Gets or sets the total obligations.
        /// </summary>
        /// <value>
        /// The total obligations.
        /// </value>
        public double TotalObligations
        {
            get
            {
                return _totalObligations;
            }
            private set
            {
                _totalObligations = value;
            }
        }

        /// <summary>
        /// Gets or sets the unliquidated obligations.
        /// </summary>
        /// <value>
        /// The unliquidated obligations.
        /// </value>
        public double UnliquidatedObligations
        {
            get
            {
                return _unliquidatedObligations;
            }
            private set
            {
                _unliquidatedObligations = value;
            }
        }

        /// <summary>
        /// Gets or sets the obligations paid.
        /// </summary>
        /// <value>
        /// The obligations paid.
        /// </value>
        public double ObligationsPaid
        {
            get
            {
                return _obligationsPaid;
            }
            private set
            {
                _obligationsPaid = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Outlays" /> class.
        /// </summary>
        public Outlay( ) 
            : base( )
        {
            Source = Source.Outlays;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Outlays" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public Outlay( IQuery query )
            : base( query )
        {
            _record = new DataBuilder( query ).Record;
            _map = _record.ToDictionary( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _appropriationCode = _record[ "AppropriationCode" ].ToString( );
            _appropriationName = _record[ "AppropriationName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
            _monthProcessed = _record[ "MonthProcessed" ].ToString( );
            _totalObligations = double.Parse( _record[ "TotalObligations" ].ToString( ) ?? "0" ); 
            _obligationsPaid = double.Parse( _record[ "ObligationsPaid" ].ToString( ) ?? "0" );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Outlays" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public Outlay( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _fundCode = _record[ "FundCode" ].ToString( );
            _fundName = _record[ "FundName" ].ToString( );
            _appropriationCode = _record[ "AppropriationCode" ].ToString( );
            _appropriationName = _record[ "AppropriationName" ].ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ].ToString( );
            _monthProcessed = _record[ "MonthProcessed" ].ToString( );
            _totalObligations = double.Parse( _record[ "TotalObligations" ].ToString( ) ?? "0" );
            _obligationsPaid = double.Parse( _record[ "ObligationsPaid" ].ToString( ) ?? "0" );
            _unliquidatedObligations =
                double.Parse( _record[ "UnliquidatedObligations" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Outlays" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public Outlay( DataRow dataRow )
            : base( dataRow )
        {
            Record = dataRow;
            _map = _record.ToDictionary( );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _fundCode = dataRow[ "FundCode" ].ToString( );
            _fundName = dataRow[ "FundName" ].ToString( );
            _appropriationCode = dataRow[ "AppropriationCode" ].ToString( );
            _appropriationName = dataRow[ "AppropriationName" ].ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ].ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ].ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ].ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ].ToString( );
            _monthProcessed = dataRow[ "MonthProcessed" ].ToString( );
            _totalObligations = double.Parse( dataRow[ "TotalObligations" ].ToString( ) ?? "0" );
            _obligationsPaid = double.Parse( dataRow[ "ObligationsPaid" ].ToString( ) ?? "0" );
            _unliquidatedObligations =
                double.Parse( dataRow[ "UnliquidatedObligations" ].ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Outlays" /> class.
        /// </summary>
        /// <param name="outlay">The outlay.</param>
        public Outlay( Outlay outlay ) 
            : base( )
        {
            _id = outlay.ID;
            _bfy = outlay.BFY;
            _efy = outlay.EFY;
            _fundCode = outlay.FundCode;
            _fundName = outlay.FundName;
            _appropriationCode = outlay.AppropriationCode;
            _appropriationName = outlay.AppropriationName;
            _treasuryAccountCode = outlay.TreasuryAccountCode;
            _treasuryAccountName = outlay.TreasuryAccountName;
            _budgetAccountCode = outlay.BudgetAccountCode;
            _budgetAccountName = outlay.BudgetAccountName;
            _monthProcessed = outlay.MonthProcessed;
            _totalObligations = outlay.TotalObligations;
            _obligationsPaid = outlay.ObligationsPaid;
            _unliquidatedObligations = outlay.UnliquidatedObligations;
        }
    }
}