﻿// ***********************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:              20-10-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        20-10-2023
// ***********************************************************************************************
// <copyright file="ReportingLines.cs.cs" company="Terry D. Eppler">
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   Eppler, Terry.cs
// </summary>
// ***********************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class ReportingLine : DataUnit
    {
        /// <summary>
        /// The number
        /// </summary>
        private protected string _number;

        /// <summary>
        /// The caption
        /// </summary>
        private protected string _caption;

        /// <summary>
        /// The category
        /// </summary>
        private protected string _category;

        /// <summary>
        /// The range
        /// </summary>
        private protected string _range;

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number
        {
            get
            {
                return _number;
            }
            private protected set
            {
                _number = value;
            }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        public string Caption
        {
            get
            {
                return _caption;
            }
            private protected set
            {
                _caption = value;
            }
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category
        {
            get
            {
                return _category;
            }
            private protected set
            {
                _category = value;
            }
        }

        /// <summary>
        /// Gets or sets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public string Range
        {
            get
            {
                return _range;
            }
            private protected set
            {
                _range = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ReportingLines" />
        /// class.
        /// </summary>
        public ReportingLine( ) 
            : base( )
        {
            _source = Source.ReconciliationLines;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ReportingLines"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public ReportingLine( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "ReportingLinesId" ]?.ToString( ) ?? "0" );
            _number = _record[ "Number" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _caption = _record[ "Caption" ]?.ToString( );
            _category = _record[ "Category" ]?.ToString( );
            _range = _record[ "Range" ]?.ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ReportingLines"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The data builder. </param>
        public ReportingLine( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "ReportingLinesId" ]?.ToString( ) ?? "0" );
            _number = _record[ "Number" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _caption = _record[ "Caption" ]?.ToString( );
            _category = _record[ "Category" ]?.ToString( );
            _range = _record[ "Range" ]?.ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ReportingLines"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public ReportingLine( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "ReportingLinesId" ]?.ToString( ) ?? "0" );
            _number = dataRow[ "Number" ]?.ToString( );
            _name = dataRow[ "Name" ]?.ToString( );
            _caption = dataRow[ "Caption" ]?.ToString( );
            _category = dataRow[ "Category" ]?.ToString( );
            _range = dataRow[ "Range" ]?.ToString( );
        }
    }
}