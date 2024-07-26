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
    /// <summary> </summary>
    /// <seealso cref="T:Badger.DataUnit" />
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "UnusedType.Global" )]
    [SuppressMessage( "ReSharper", "ConvertToAutoProperty" )]
    [SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" )]
    public class HeadquartersOffice : DataUnit
    {
        /// <summary>
        /// The rpio
        /// </summary>
        private string _rpio;

        /// <summary>
        /// Gets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        public string RPIO
        {
            get
            {
                return _rpio;
            }
            private set
            {
                _rpio = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.HeadquartersOffice" />
        /// class.
        /// </summary>
        public HeadquartersOffice( )
            : base( )
        {
            _source = Source.HeadquartersOffices;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.HeadquartersOffice" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public HeadquartersOffice( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "ResourcePlanningOfficesId" ].ToString( ) ?? "0" );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.HeadquartersOffice" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public HeadquartersOffice( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "ResourcePlanningOfficesId" ].ToString( ) ?? "0" );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.HeadquartersOffice" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public HeadquartersOffice( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "ResourcePlanningOfficesId" ].ToString( ) ?? "0" );
            _code = dataRow[ "Code" ].ToString( );
            _name = dataRow[ "Name" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.HeadquartersOffice" />
        /// class.
        /// </summary>
        /// <param name="npm"> The NPM. </param>
        public HeadquartersOffice( HeadquartersOffice npm )
            : this( )
        {
            _id = npm.ID;
            _rpio = npm.RPIO;
            _code = npm.Code;
            _name = npm.Name;
        }
    }
}