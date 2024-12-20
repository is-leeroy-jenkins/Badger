﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="FederalHoliday.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
// 
//    Copyright ©  2020-2024 Terry D. Eppler
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
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   FederalHoliday.cs
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public abstract class FederalHoliday : DataUnit
    {
        /// <summary>
        /// The columbus day
        /// </summary>
        private protected DateTime _columbusDay;

        /// <summary>
        /// The veterans day
        /// </summary>
        private protected DateTime _veteransDay;

        /// <summary>
        /// The thanksgiving day
        /// </summary>
        private protected DateTime _thanksgivingDay;

        /// <summary>
        /// The christmas day
        /// </summary>
        private protected DateTime _christmasDay;

        /// <summary>
        /// The new years day
        /// </summary>
        private protected DateTime _newYearsDay;

        /// <summary>
        /// The martin luther king day
        /// </summary>
        private protected DateTime _martinLutherKingDay;

        /// <summary>
        /// The presidents day
        /// </summary>
        private protected DateTime _presidentsDay;

        /// <summary>
        /// The memorial day
        /// </summary>
        private protected DateTime _memorialDay;

        /// <summary>
        /// The juneteenth day
        /// </summary>
        private protected DateTime _juneteenthDay;

        /// <summary>
        /// The independence day
        /// </summary>
        private protected DateTime _independenceDay;

        /// <summary>
        /// The labor day
        /// </summary>
        private protected DateTime _laborDay;

        /// <summary>
        /// Gets or sets the columbus day.
        /// </summary>
        /// <value>
        /// The columbus day.
        /// </value>
        public DateTime ColumbusDay
        {
            get
            {
                return _columbusDay;
            }
            private protected set
            {
                if( _columbusDay != value )
                {
                    _columbusDay = value;
                    OnPropertyChanged( nameof( ColumbusDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the veterans day.
        /// </summary>
        /// <value>
        /// The veterans day.
        /// </value>
        public DateTime VeteransDay
        {
            get
            {
                return _veteransDay;
            }
            private protected set
            {
                if( _veteransDay != value )
                {
                    _veteransDay = value;
                    OnPropertyChanged( nameof( ColumbusDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the thanksgiving day.
        /// </summary>
        /// <value>
        /// The thanksgiving day.
        /// </value>
        public DateTime ThanksgivingDay
        {
            get
            {
                return _thanksgivingDay;
            }
            private protected set
            {
                if( _thanksgivingDay != value )
                {
                    _thanksgivingDay = value;
                    OnPropertyChanged( nameof( ColumbusDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the christmas day.
        /// </summary>
        /// <value>
        /// The christmas day.
        /// </value>
        public DateTime ChristmasDay
        {
            get
            {
                return _christmasDay;
            }
            private protected set
            {
                if( _christmasDay != value )
                {
                    _christmasDay = value;
                    OnPropertyChanged( nameof( ChristmasDay ) );
                }
            }
        }

        /// <summary>
        /// Creates new yearsday.
        /// </summary>
        /// <value>
        /// The new years day.
        /// </value>
        public DateTime NewYearsDay
        {
            get
            {
                return _newYearsDay;
            }
            private protected set
            {
                if( _newYearsDay != value )
                {
                    _newYearsDay = value;
                    OnPropertyChanged( nameof( NewYearsDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the martin luther king day.
        /// </summary>
        /// <value>
        /// The martin luther king day.
        /// </value>
        public DateTime MartinLutherKingDay
        {
            get
            {
                return _martinLutherKingDay;
            }
            private protected set
            {
                if( _martinLutherKingDay != value )
                {
                    _martinLutherKingDay = value;
                    OnPropertyChanged( nameof( MartinLutherKingDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the presidents day.
        /// </summary>
        /// <value>
        /// The presidents day.
        /// </value>
        public DateTime PresidentsDay
        {
            get
            {
                return _presidentsDay;
            }
            private protected set
            {
                if( _presidentsDay != value )
                {
                    _presidentsDay = value;
                    OnPropertyChanged( nameof( PresidentsDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the memorial day.
        /// </summary>
        /// <value>
        /// The memorial day.
        /// </value>
        public DateTime MemorialDay
        {
            get
            {
                return _memorialDay;
            }
            private protected set
            {
                if( _memorialDay != value )
                {
                    _memorialDay = value;
                    OnPropertyChanged( nameof( MemorialDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the juneteenth day.
        /// </summary>
        /// <value>
        /// The juneteenth day.
        /// </value>
        public DateTime JuneteenthDay
        {
            get
            {
                return _juneteenthDay;
            }
            private protected set
            {
                if( _juneteenthDay != value )
                {
                    _juneteenthDay = value;
                    OnPropertyChanged( nameof( JuneteenthDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the independence day.
        /// </summary>
        /// <value>
        /// The independence day.
        /// </value>
        public DateTime IndependenceDay
        {
            get
            {
                return _independenceDay;
            }
            private protected set
            {
                if( _independenceDay != value )
                {
                    _newYearsDay = value;
                    OnPropertyChanged( nameof( IndependenceDay ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the labor day.
        /// </summary>
        /// <value>
        /// The labor day.
        /// </value>
        public DateTime LaborDay
        {
            get
            {
                return _laborDay;
            }
            private protected set
            {
                if( _laborDay != value )
                {
                    _laborDay = value;
                    OnPropertyChanged( nameof( LaborDay ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FederalHoliday" /> class.
        /// </summary>
        protected FederalHoliday( )
            : base( )
        {
            _source = Source.FederalHolidays;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FederalHoliday" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected FederalHoliday( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FederalHoliday" /> class.
        /// </summary>
        /// <param name="builder"></param>
        protected FederalHoliday( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FederalHoliday" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected FederalHoliday( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
        }
    }
}