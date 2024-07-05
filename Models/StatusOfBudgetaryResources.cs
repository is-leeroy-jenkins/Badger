//  ******************************************************************************************
//      Assembly:                Badger
//      Filename:                StatusOfBudgetaryResources.cs
//      Author:                  Terry D. Eppler
//      Created:                 05-31-2023
// 
//      Last Modified By:        Terry D. Eppler
//      Last Modified On:        06-01-2023
//  ******************************************************************************************
//  <copyright file="StatusOfBudgetaryResources.cs" company="Terry D. Eppler">
// 
//     This is a Federal Budget, Finance, and Accounting application for the
//     US Environmental Protection Agency (US EPA).
//     Copyright ©  2023  Terry Eppler
// 
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the “Software”),
//     to deal in the Software without restriction,
//     including without limitation the rights to use,
//     copy, modify, merge, publish, distribute, sublicense,
//     and/or sell copies of the Software,
//     and to permit persons to whom the Software is furnished to do so,
//     subject to the following conditions:
// 
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
// 
//     THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//     INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//     IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//     DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//     ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//     DEALINGS IN THE SOFTWARE.
// 
//     You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// 
//  </copyright>
//  <summary>
//    StatusOfBudgetaryResources.cs
//  </summary>
//  ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.BudgetUnit" />
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class StatusOfBudgetaryResources : BudgetaryResource
    {
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
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
            {
                _november = value;
            }
        }

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
                return _november;
            }
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
            {
                _november = value;
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
                return _november;
            }
            private protected set
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
                return _november;
            }
            private protected set
            {
                _november = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetaryResources" /> class.
        /// </summary>
        public StatusOfBudgetaryResources( ) 
            : base( )
        {
            _source = Source.BudgetaryResourceExecution;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetaryResources" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public StatusOfBudgetaryResources( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = Record.ToDictionary( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _lastUpdate = DateTime.Parse( _record[ "LastUpdate" ]?.ToString( ) ?? "" );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _stat = _record[ "STAT" ]?.ToString( );
            _creditIndicator = _record[ "CreditIndicator" ]?.ToString( );
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _lineDescription = _record[ "LineDescription" ]?.ToString( );
            _sectionName = _record[ "SectionName" ]?.ToString( );
            _sectionNumber = _record[ "SectionNumber" ]?.ToString( );
            _lineType = _record[ "LineType" ]?.ToString( );
            _november = double.Parse( _record[ "November" ]?.ToString( ) ?? "0" );
            _january = double.Parse( _record[ "January" ]?.ToString( ) ?? "0" );
            _feburary = double.Parse( _record[ "February" ]?.ToString( ) ?? "0" );
            _april = double.Parse( _record[ "April" ]?.ToString( ) ?? "0" );
            _may = double.Parse( _record[ " May" ]?.ToString( ) ?? "0" );
            _june = double.Parse( _record[ "June" ]?.ToString( ) ?? "0" );
            _august = double.Parse( _record[ "August" ]?.ToString( ) ?? "0" );
            _october = double.Parse( _record[ "October" ]?.ToString( ) ?? "0" );
            _march = double.Parse( _record[ "March" ]?.ToString( ) ?? "0" );
            _july = double.Parse( _record[ "July" ]?.ToString( ) ?? "0" );
            _september = double.Parse( _record[ "September" ]?.ToString( ) ?? "0" );
            _december = double.Parse( _record[ "December" ]?.ToString( ) ?? "0" );
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetaryResources" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public StatusOfBudgetaryResources( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = Record.ToDictionary( );
            _fiscalYear = _record[ "FiscalYear" ]?.ToString( );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _lastUpdate = DateTime.Parse( _record[ "LastUpdate" ]?.ToString( ) ?? "" );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _stat = _record[ "STAT" ]?.ToString( );
            _creditIndicator = _record[ "CreditIndicator" ]?.ToString( );
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _lineDescription = _record[ "LineDescription" ]?.ToString( );
            _sectionName = _record[ "SectionName" ]?.ToString( );
            _sectionNumber = _record[ "SectionNumber" ]?.ToString( );
            _lineType = _record[ "LineType" ]?.ToString( );
            _november = double.Parse( _record[ "November" ]?.ToString( ) ?? "0" );
            _january = double.Parse( _record[ "January" ]?.ToString( ) ?? "0" );
            _feburary = double.Parse( _record[ "February" ]?.ToString( ) ?? "0" );
            _april = double.Parse( _record[ "April" ]?.ToString( ) ?? "0" );
            _may = double.Parse( _record[ " May" ]?.ToString( ) ?? "0" );
            _june = double.Parse( _record[ "June" ]?.ToString( ) ?? "0" );
            _august = double.Parse( _record[ "August" ]?.ToString( ) ?? "0" );
            _october = double.Parse( _record[ "October" ]?.ToString( ) ?? "0" );
            _march = double.Parse( _record[ "March" ]?.ToString( ) ?? "0" );
            _july = double.Parse( _record[ "July" ]?.ToString( ) ?? "0" );
            _september = double.Parse( _record[ "September" ]?.ToString( ) ?? "0" );
            _december = double.Parse( _record[ "December" ]?.ToString( ) ?? "0" );
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetaryResources" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public StatusOfBudgetaryResources( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _fiscalYear = dataRow[ "FiscalYear" ]?.ToString( );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _lastUpdate = DateTime.Parse( dataRow[ "LastUpdate" ]?.ToString( ) ?? "" );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _stat = dataRow[ "STAT" ]?.ToString( );
            _creditIndicator = dataRow[ "CreditIndicator" ]?.ToString( );
            _lineNumber = dataRow[ "LineNumber" ]?.ToString( );
            _lineDescription = dataRow[ "LineDescription" ]?.ToString( );
            _sectionName = dataRow[ "SectionName" ]?.ToString( );
            _sectionNumber = dataRow[ "SectionNumber" ]?.ToString( );
            _lineType = dataRow[ "LineType" ]?.ToString( );
            _november = double.Parse( dataRow[ "November" ]?.ToString( ) ?? "0" );
            _january = double.Parse( dataRow[ "January" ]?.ToString( ) ?? "0" );
            _feburary = double.Parse( _record[ "February" ]?.ToString( ) ?? "0" );
            _april = double.Parse( dataRow[ "April" ]?.ToString( ) ?? "0" );
            _may = double.Parse( dataRow[ " May" ]?.ToString( ) ?? "0" );
            _june = double.Parse( dataRow[ "June" ]?.ToString( ) ?? "0" );
            _august = double.Parse( dataRow[ "August" ]?.ToString( ) ?? "0" );
            _october = double.Parse( dataRow[ "October" ]?.ToString( ) ?? "0" );
            _march = double.Parse( dataRow[ "March" ]?.ToString( ) ?? "0" );
            _july = double.Parse( dataRow[ "July" ]?.ToString( ) ?? "0" );
            _september = double.Parse( dataRow[ "September" ]?.ToString( ) ?? "0" );
            _december = double.Parse( dataRow[ "December" ]?.ToString( ) ?? "0" );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetaryResources" /> class.
        /// </summary>
        /// <param name="budget">The budget.</param>
        public StatusOfBudgetaryResources( StatusOfBudgetaryResources budget )
            : this( )
        {
            _id = budget.ID;
            _fiscalYear = budget.FiscalYear;
            _bfy = budget.BFY;
            _efy = budget.EFY;
            _lastUpdate = budget.LastUpdate;
            _budgetAccountCode = budget.BudgetAccountCode;
            _budgetAccountName = budget.BudgetAccountName;
            _treasuryAccountCode = budget.TreasuryAccountCode;
            _treasuryAccountName = budget.TreasuryAccountName;
            _stat = budget.STAT;
            _creditIndicator = budget.CreditIndicator;
            _lineNumber = budget.LineNumber;
            _lineDescription = budget.LineDescription;
            _sectionName = budget.SectionName;
            _sectionNumber = budget.SectionNumber;
            _lineType = budget.LineType;
            _november = budget.November;
            _january = budget.January;
            _feburary = budget.February;
            _april = budget.April;
            _may = budget.May;
            _june = budget.June;
            _august = budget.August;
            _october = budget.October;
            _march = budget.March;
            _july = budget.July;
            _september = budget.September;
            _december = budget.December;
        }
    }
}