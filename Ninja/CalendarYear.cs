// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="CalendarYear.cs" company="Terry D. Eppler">
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
//   CalendarYear.cs
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
    /// <seealso cref="T:Badger.FederalHoliday" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public abstract class CalendarYear : FederalHoliday
    {
        /// <summary>
        /// The work days
        /// </summary>
        private protected double _workDays;

        /// <summary>
        /// The week days
        /// </summary>
        private protected double _weekDays;

        /// <summary>
        /// The week ends
        /// </summary>
        private protected double _weekEnds;

        /// <summary>
        /// The current date
        /// </summary>
        private protected DateOnly _currentDate;

        /// <summary>
        /// The current day
        /// </summary>
        private protected int _currentDay;

        /// <summary>
        /// The current month
        /// </summary>
        private protected int _currentMonth;

        /// <summary>
        /// The current year
        /// </summary>
        private protected int _currentYear;

        /// <summary>
        /// Gets or sets the work days.
        /// </summary>
        /// <value>
        /// The work days.
        /// </value>
        public double WorkDays
        {
            get
            {
                return _workDays;
            }
            private protected set
            {
                _workDays = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the week days.
        /// </summary>
        /// <value>
        /// The week days.
        /// </value>
        public double WeekDays
        {
            get
            {
                return _weekDays;
            }
            private protected set
            {
                _weekDays = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the week ends.
        /// </summary>
        /// <value>
        /// The week ends.
        /// </value>
        public double WeekEnds
        {
            get
            {
                return _weekEnds;
            }
            private protected set
            {
                _weekEnds = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the current date.
        /// </summary>
        /// <value>
        /// The current date.
        /// </value>
        public DateOnly CurrentDate
        {
            get
            {
                return _currentDate;
            }
            private protected set
            {
                _currentDate = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the current month.
        /// </summary>
        /// <value>
        /// The current month.
        /// </value>
        public int CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            private protected set
            {
                _currentMonth = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the current day.
        /// </summary>
        /// <value>
        /// The current day.
        /// </value>
        public int CurrentDay
        {
            get
            {
                return _currentDay;
            }
            private protected set
            {
                _currentDay = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the current year.
        /// </summary>
        /// <value>
        /// The current year.
        /// </value>
        public int CurrentYear
        {
            get
            {
                return _currentYear;
            }
            private protected set
            {
                _currentYear = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CalendarYear" /> class.
        /// </summary>
        protected CalendarYear( ) 
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CalendarYear"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        protected CalendarYear( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CalendarYear"/> class.
        /// </summary>
        /// <param name="builder"></param>
        /// <inheritdoc />
        protected CalendarYear( IDataModel builder )
            : base( builder )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CalendarYear"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <inheritdoc />
        protected CalendarYear( DataRow dataRow )
            : base( dataRow )
        {
        }
    }
}