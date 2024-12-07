// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="HolidayFactory.cs" company="Terry D. Eppler">
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
//   HolidayFactory.cs
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
    /// <seealso cref="T:Badger.FederalHoliday" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    public class HolidayFactory : FederalHoliday
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.HolidayFactory" />
        /// class.
        /// </summary>
        public HolidayFactory( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.HolidayFactory" />
        /// class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public HolidayFactory( DataRow dataRow )
        {
            _record = dataRow;
            _newYearsDay = DateTime.Parse( dataRow[ "NewYears" ].ToString( ) );
            _martinLutherKingDay = DateTime.Parse( dataRow[ "MartinLutherKing" ].ToString( ) );
            _presidentsDay = DateTime.Parse( dataRow[ "PresidentsDay" ].ToString( ) );
            _memorialDay = DateTime.Parse( dataRow[ "Memorial" ].ToString( ) );
            _veteransDay = DateTime.Parse( dataRow[ "Veterans" ].ToString( ) );
            _laborDay = DateTime.Parse( dataRow[ "Labor" ].ToString( ) );
            _independenceDay = DateTime.Parse( dataRow[ "Independence" ].ToString( ) );
            _columbusDay = DateTime.Parse( dataRow[ "Columbus" ].ToString( ) );
            _thanksgivingDay = DateTime.Parse( dataRow[ "Thanksgiving" ].ToString( ) );
            _christmasDay = DateTime.Parse( dataRow[ "Christmas" ].ToString( ) );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Gets the federal holidays.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns></returns>
        public IDictionary<string, DateTime> GetFederalHolidays( IDictionary<string, string> dict )
        {
            try
            {
                var _holiday = new Dictionary<string, DateTime>( );
                foreach( var _kvp in dict )
                {
                    _holiday.Add( _kvp.Key, DateTime.Parse( _kvp.Value ) );
                }

                return _holiday.Any( )
                    ? _holiday
                    : default( Dictionary<string, DateTime> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, DateTime> );
            }
        }

        /// <summary>
        /// Gets the national holidays.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns></returns>
        public IDictionary<string, DateTime> GetNationalHolidays( IDictionary<string, string> dict )
        {
            try
            {
                var _holiday = new Dictionary<string, DateTime>( );
                foreach( var _kvp in dict )
                {
                    _holiday.Add( _kvp.Key, DateTime.Parse( _kvp.Value ) );
                }

                return _holiday.Any( )
                    ? _holiday
                    : default( Dictionary<string, DateTime> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, DateTime> );
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToDictionary( )
        {
            try
            {
                return _map.Count > 0
                    ? _map
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}