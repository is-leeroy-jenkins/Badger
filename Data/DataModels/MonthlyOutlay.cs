// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="MonthlyOutlay.cs" company="Terry D. Eppler">
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
//   MonthlyOutlay.cs
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
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class MonthlyOutlay : OutlayReport
    {
        /// <summary>
        /// Gets or sets the october.
        /// </summary>
        /// <value>
        /// The october.
        /// </value>
        public double October
        {
            get
            {
                return _october;
            }
            set
            {
                _october = value;
            }
        }

        /// <summary>
        /// Gets or sets the november.
        /// </summary>
        /// <value>
        /// The november.
        /// </value>
        public double November
        {
            get
            {
                return _november;
            }
            set
            {
                _november = value;
            }
        }

        /// <summary>
        /// Gets or sets the december.
        /// </summary>
        /// <value>
        /// The december.
        /// </value>
        public double December
        {
            get
            {
                return _december;
            }
            set
            {
                _december = value;
            }
        }

        /// <summary>
        /// Gets or sets the january.
        /// </summary>
        /// <value>
        /// The january.
        /// </value>
        public double January
        {
            get
            {
                return _january;
            }
            set
            {
                _january = value;
            }
        }

        /// <summary>
        /// Gets or sets the february.
        /// </summary>
        /// <value>
        /// The february.
        /// </value>
        public double February
        {
            get
            {
                return _february;
            }
            set
            {
                _february = value;
            }
        }

        /// <summary>
        /// Gets or sets the march.
        /// </summary>
        /// <value>
        /// The march.
        /// </value>
        public double March
        {
            get
            {
                return _march;
            }
            set
            {
                _march = value;
            }
        }

        /// <summary>
        /// Gets or sets the april.
        /// </summary>
        /// <value>
        /// The april.
        /// </value>
        public double April
        {
            get
            {
                return _april;
            }
            set
            {
                _april = value;
            }
        }

        /// <summary>
        /// Gets or sets the may.
        /// </summary>
        /// <value>
        /// The may.
        /// </value>
        public double May
        {
            get
            {
                return _may;
            }
            set
            {
                _may = value;
            }
        }

        /// <summary>
        /// Gets or sets the june.
        /// </summary>
        /// <value>
        /// The june.
        /// </value>
        public double June
        {
            get
            {
                return _june;
            }
            set
            {
                _june = value;
            }
        }

        /// <summary>
        /// Gets or sets the july.
        /// </summary>
        /// <value>
        /// The july.
        /// </value>
        public double July
        {
            get
            {
                return _july;
            }
            set
            {
                _july = value;
            }
        }

        /// <summary>
        /// Gets or sets the august.
        /// </summary>
        /// <value>
        /// The august.
        /// </value>
        public double August
        {
            get
            {
                return _august;
            }
            set
            {
                _august = value;
            }
        }

        /// <summary>
        /// Gets or sets the september.
        /// </summary>
        /// <value>
        /// The september.
        /// </value>
        public double September
        {
            get
            {
                return _september;
            }
            set
            {
                _september = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyOutlays" /> class.
        /// </summary>
        public MonthlyOutlay( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyOutlays" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public MonthlyOutlay( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "MonthlyOutlaysId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _lineTitle = _record[ "LineTitle" ]?.ToString( );
            _taxationCode = _record[ "TaxationCode" ]?.ToString( );
            _treasuryAgencyCode = _record[ "TreasuryAgency" ]?.ToString( );
            _treasuryBureauCode = _record[ "TreasuryBureauCode" ]?.ToString( );
            _budgetAgencyCode = _record[ "BudgetAgencyCode" ]?.ToString( );
            _treasuryAgencyCode = _record[ "TreasuryAgencyCode" ]?.ToString( );
            _subAccount = _record[ "SubAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _october = double.Parse( _record[ "October" ]?.ToString( ) ?? "0" );
            _november = double.Parse( _record[ "November" ]?.ToString( ) ?? "0" );
            _december = double.Parse( _record[ "December" ]?.ToString( ) ?? "0" );
            _january = double.Parse( _record[ "January" ]?.ToString( ) ?? "0" );
            _february = double.Parse( _record[ "February" ]?.ToString( ) ?? "0" );
            _march = double.Parse( _record[ "March" ]?.ToString( ) ?? "0" );
            _april = double.Parse( _record[ "April" ]?.ToString( ) ?? "0" );
            _may = double.Parse( _record[ "May" ]?.ToString( ) ?? "0" );
            _june = double.Parse( _record[ "June" ]?.ToString( ) ?? "0" );
            _july = double.Parse( _record[ "July" ]?.ToString( ) ?? "0" );
            _august = double.Parse( _record[ "August" ]?.ToString( ) ?? "0" );
            _september = double.Parse( _record[ "September" ]?.ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyOutlays" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public MonthlyOutlay( DataGenerator builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "MonthlyOutlaysId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _lineTitle = _record[ "LineTitle" ]?.ToString( );
            _taxationCode = _record[ "TaxationCode" ]?.ToString( );
            _treasuryAgencyCode = _record[ "TreasuryAgency" ]?.ToString( );
            _treasuryBureauCode = _record[ "TreasuryBureauCode" ]?.ToString( );
            _budgetAgencyCode = _record[ "BudgetAgencyCode" ]?.ToString( );
            _treasuryAgencyCode = _record[ "TreasuryAgencyCode" ]?.ToString( );
            _subAccount = _record[ "SubAccount" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _october = double.Parse( _record[ "October" ]?.ToString( ) ?? "0" );
            _november = double.Parse( _record[ "November" ]?.ToString( ) ?? "0" );
            _december = double.Parse( _record[ "December" ]?.ToString( ) ?? "0" );
            _january = double.Parse( _record[ "January" ]?.ToString( ) ?? "0" );
            _february = double.Parse( _record[ "February" ]?.ToString( ) ?? "0" );
            _march = double.Parse( _record[ "March" ]?.ToString( ) ?? "0" );
            _april = double.Parse( _record[ "April" ]?.ToString( ) ?? "0" );
            _may = double.Parse( _record[ "May" ]?.ToString( ) ?? "0" );
            _june = double.Parse( _record[ "June" ]?.ToString( ) ?? "0" );
            _july = double.Parse( _record[ "July" ]?.ToString( ) ?? "0" );
            _august = double.Parse( _record[ "August" ]?.ToString( ) ?? "0" );
            _september = double.Parse( _record[ "September" ]?.ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyOutlays" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public MonthlyOutlay( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "MonthlyOutlaysId" ]?.ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fiscalYear = dataRow[ "FiscalYear" ]?.ToString( );
            _lineNumber = dataRow[ "LineNumber" ]?.ToString( );
            _lineTitle = dataRow[ "LineTitle" ]?.ToString( );
            _taxationCode = dataRow[ "TaxationCode" ]?.ToString( );
            _treasuryAgencyCode = dataRow[ "TreasuryAgency" ]?.ToString( );
            _treasuryBureauCode = dataRow[ "TreasuryBureauCode" ]?.ToString( );
            _budgetAgencyCode = dataRow[ "BudgetAgencyCode" ]?.ToString( );
            _treasuryAgencyCode = dataRow[ "TreasuryAgencyCode" ]?.ToString( );
            _subAccount = dataRow[ "SubAccount" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
            _october = double.Parse( dataRow[ "October" ]?.ToString( ) ?? "0" );
            _november = double.Parse( dataRow[ "November" ]?.ToString( ) ?? "0" );
            _december = double.Parse( dataRow[ "December" ]?.ToString( ) ?? "0" );
            _january = double.Parse( dataRow[ "January" ]?.ToString( ) ?? "0" );
            _february = double.Parse( dataRow[ "February" ]?.ToString( ) ?? "0" );
            _march = double.Parse( dataRow[ "March" ]?.ToString( ) ?? "0" );
            _april = double.Parse( dataRow[ "April" ]?.ToString( ) ?? "0" );
            _may = double.Parse( dataRow[ "May" ]?.ToString( ) ?? "0" );
            _june = double.Parse( dataRow[ "June" ]?.ToString( ) ?? "0" );
            _july = double.Parse( dataRow[ "July" ]?.ToString( ) ?? "0" );
            _august = double.Parse( dataRow[ "August" ]?.ToString( ) ?? "0" );
            _september = double.Parse( dataRow[ "September" ]?.ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MonthlyOutlays" /> class.
        /// </summary>
        /// <param name="outlay">The outlays.</param>
        public MonthlyOutlay( MonthlyOutlay outlay )
            : this( )
        {
            _id = outlay.ID;
            _bfy = outlay.BFY;
            _efy = outlay.EFY;
            _fiscalYear = outlay.FiscalYear;
            _lineNumber = outlay.LineNumber;
            _lineTitle = outlay.LineTitle;
            _taxationCode = outlay.TaxationCode;
            _treasuryAgencyCode = outlay.TreasuryAgencyCode;
            _treasuryBureauCode = outlay.TreasuryBureauCode;
            _budgetAgencyCode = outlay.BudgetAgencyCode;
            _subAccount = outlay.SubAccount;
            _treasuryAccountCode = outlay.TreasuryAccountCode;
            _treasuryAccountName = outlay.TreasuryAccountName;
            _budgetAccountCode = outlay.BudgetAccountCode;
            _budgetAccountName = outlay.BudgetAccountName;
            _october = outlay.October;
            _november = outlay.November;
            _december = outlay.December;
            _january = outlay.January;
            _february = outlay.February;
            _march = outlay.March;
            _april = outlay.April;
            _may = outlay.May;
            _june = outlay.June;
            _july = outlay.July;
            _august = outlay.August;
            _september = outlay.September;
        }
    }
}