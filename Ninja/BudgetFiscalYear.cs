// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="BudgetFiscalYear.cs" company="Terry D. Eppler">
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
//   BudgetFiscalYear.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc />
    /// <summary> </summary>
    /// <seealso cref="T:Badger.FiscalYear" />
    /// <seealso cref="!:Badger.IBudgetFiscalYear" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "PossibleNullReferenceException" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class BudgetFiscalYear : FiscalYear
    {
        /// <summary>
        /// The availability
        /// </summary>
        private protected string _availability;

        /// <summary>
        /// The holidays
        /// </summary>
        private protected HolidayFactory _holidays;

        /// <summary>
        /// The federal holidays
        /// </summary>
        private protected IDictionary<Holiday, DateTime> _federalHolidays;
        
        /// <summary>
        /// Gets or sets the availability.
        /// </summary>
        /// <value>
        /// The availability.
        /// </value>
        public string Availability
        {
            get
            {
                return _availability;
            }
            private protected set
            {
                _availability = value;
            }
        }

        /// <summary>
        /// Gets or sets the holidays.
        /// </summary>
        /// <value>
        /// The holidays.
        /// </value>
        public HolidayFactory Holidays
        {
            get
            {
                return _holidays;
            }
            private protected set
            {
                _holidays = value;
            }
        }

        /// <summary>
        /// Gets or sets the federal holidays.
        /// </summary>
        /// <value>
        /// The federal holidays.
        /// </value>
        public IDictionary<Holiday, DateTime> FederalHolidays
        {
            get
            {
                return _federalHolidays;
            }
            private protected set
            {
                _federalHolidays = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetFiscalYear" />
        /// class.
        /// </summary>
        public BudgetFiscalYear( )
            : base( )
        {
            _source = Source.FiscalYears;
            _currentDate = DateTime.Today;
            _currentYear = DateTime.Now.Year;
            _currentMonth = DateTime.Now.Month;
            _currentDay = DateTime.Now.Day;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetFiscalYears" />
        /// class.
        /// </summary>
        /// <param name="bfy"> The bfy. </param>
        public BudgetFiscalYear( string bfy )
            : this( )
        {
            _inputYear = bfy;
            _record = new DataGenerator( _source, SetArgs( bfy ) )?.Record;
            _id = int.Parse( _record[ "FiscalYearsId" ].ToString( ) );
            _firstYear = _record[ "FirstYear" ].ToString( );
            _lastYear = _record[ "LastYEar" ].ToString( );
            _availability = _record[ "Availability" ].ToString( );
            _workDays = double.Parse( _record[ "WorkDays" ].ToString( ) );
            _weekDays = double.Parse( _record[ "WeekDays" ].ToString( ) );
            _weekEnds = double.Parse( _record[ "WeekEnds" ].ToString( ) );
            _expiringYear = _record[ "ExpiringYear" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _cancellationDate = DateTime.Parse( _record[ "CancellationDate" ].ToString( ) );
            _holidays = new HolidayFactory( _record );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetFiscalYears" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public BudgetFiscalYear( IQuery query )
            : base( query )
        {
            _source = query.Source;
            _currentDate = DateTime.Today;
            _currentYear = DateTime.Now.Year;
            _currentMonth = DateTime.Now.Month;
            _currentDay = DateTime.Now.Day;
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( _record[ "FiscalYearsId" ].ToString( ) );
            _firstYear = _record[ "FirstYear" ].ToString( );
            _lastYear = _record[ "LastYEar" ].ToString( );
            _availability = _record[ "Availability" ].ToString( );
            _workDays = double.Parse( _record[ "WorkDays" ].ToString( ) );
            _weekDays = double.Parse( _record[ "WeekDays" ].ToString( ) );
            _weekEnds = double.Parse( _record[ "WeekEnds" ].ToString( ) );
            _expiringYear = _record[ "ExpiringYear" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _cancellationDate = DateTime.Parse( _record[ "CancellationDate" ].ToString( ) );
            _holidays = new HolidayFactory( _record );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetFiscalYears" />
        /// class.
        /// </summary>
        /// <param name="dataBuilder"> The data builder. </param>
        public BudgetFiscalYear( IDataModel dataBuilder )
            : base( dataBuilder )
        {
            _source = dataBuilder.Source;
            _currentDate = DateTime.Today;
            _currentYear = DateTime.Now.Year;
            _currentMonth = DateTime.Now.Month;
            _currentDay = DateTime.Now.Day;
            _record = dataBuilder.Record;
            _id = int.Parse( dataBuilder.Record[ "FiscalYearsId" ].ToString( ) );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _firstYear = _record[ "FirstYear" ].ToString( );
            _lastYear = _record[ "LastYEar" ].ToString( );
            _availability = _record[ "Availability" ].ToString( );
            _workDays = double.Parse( _record[ "WorkDays" ].ToString( ) );
            _weekDays = double.Parse( _record[ "WeekDays" ].ToString( ) );
            _weekEnds = double.Parse( _record[ "WeekEnds" ].ToString( ) );
            _expiringYear = _record[ "ExpiringYear" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _cancellationDate = 
                DateTime.Parse( dataBuilder.Record[ "CancellationDate" ].ToString( ) );

            _holidays = new HolidayFactory( _record );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetFiscalYears" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public BudgetFiscalYear( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _inputYear = dataRow[ "BFY" ].ToString( );
            _id = int.Parse( dataRow[ "FiscalYearsId" ].ToString( ) );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _firstYear = dataRow[ "FirstYear" ].ToString( );
            _lastYear = dataRow[ "LastYEar" ].ToString( );
            _availability = dataRow[ "Availability" ].ToString( );
            _workDays = double.Parse( dataRow[ "WorkDays" ].ToString( ) );
            _weekDays = double.Parse( dataRow[ "WeekDays" ].ToString( ) );
            _weekEnds = double.Parse( dataRow[ "WeekEnds" ].ToString( ) );
            _expiringYear = dataRow[ "ExpiringYear" ].ToString( );
            _startDate = DateTime.Parse( dataRow[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( dataRow[ "EndDate" ].ToString( ) );
            _cancellationDate = DateTime.Parse( dataRow[ "CancellationDate" ].ToString( ) );
            _holidays = new HolidayFactory( dataRow );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetFiscalYears" />
        /// class.
        /// </summary>
        /// <param name="fiscalYear"> The fiscal year. </param>
        public BudgetFiscalYear( BudgetFiscalYear fiscalYear )
            : this( )
        {
            _id = fiscalYear.ID;
            _bfy = fiscalYear.BFY;
            _efy = fiscalYear.EFY;
            _firstYear = fiscalYear.FirstYear;
            _lastYear = fiscalYear.LastYear;
            _availability = fiscalYear.Availability;
            _workDays = fiscalYear.WorkDays;
            _weekDays = fiscalYear.WeekDays;
            _weekEnds = fiscalYear.WeekEnds;
            _expiringYear = fiscalYear.ExpiringYear;
            _startDate = fiscalYear.StartDate;
            _endDate = fiscalYear.EndDate;
            _cancellationDate = fiscalYear.CancellationDate;
            _holidays = fiscalYear.Holidays;
        }

        /// <summary>
        /// Gets the federal holidays.
        /// </summary>
        /// <returns> </returns>
        public IDictionary<Holiday, DateTime> GetFederalHolidays( )
        {
            try
            {
                var _data = new Dictionary<Holiday, DateTime>( );
                var _day = new HolidayFactory( _record );
                _data.Add( Holiday.NewYears, _day.ChristmasDay );
                _data.Add( Holiday.MartinLutherKing, _day.MartinLutherKingDay );
                _data.Add( Holiday.Memorial, _day.MemorialDay );
                _data.Add( Holiday.Washington, _day.PresidentsDay );
                _data.Add( Holiday.Veterans, _day.VeteransDay );
                _data.Add( Holiday.Labor, _day.LaborDay );
                _data.Add( Holiday.Juneteenth, _day.JuneteenthDay );
                _data.Add( Holiday.Independence, _day.IndependenceDay );
                _data.Add( Holiday.Columbus, _day.ColumbusDay );
                _data.Add( Holiday.Thanksgiving, _day.ThanksgivingDay );
                _data.Add( Holiday.Christmas, _day.ChristmasDay );
                return ( _data?.Any( ) == true )
                    ? _data
                    : default( IDictionary<Holiday, DateTime> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<Holiday, DateTime> );
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns> </returns>
        public IDictionary<string, object> ToDictionary( )
        {
            try
            {
                return _record?.ItemArray?.Length > 0
                    ? _record.ToDictionary( )
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A
        /// <see cref="System.String"/>
        /// that represents this instance.
        /// </returns>
        public override string ToString( )
        {
            try
            {
                return !string.IsNullOrEmpty( _firstYear )
                    ? _firstYear
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the budget fiscal year.
        /// </summary>
        /// <returns> </returns>
        public BudgetFiscalYear GetBudgetFiscalYear( )
        {
            try
            {
                return MemberwiseClone( ) as BudgetFiscalYear;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( BudgetFiscalYear );
            }
        }
    }
}