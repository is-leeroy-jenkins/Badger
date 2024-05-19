// ***********************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:              20-10-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        20-10-2023
// ***********************************************************************************************
// <copyright file="StatusOfBudgetExecution.cs.cs" company="Terry D. Eppler">
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
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class StatusOfBudgetExecution : BudgetUnit
    {
        /// <summary>
        /// The line number
        /// </summary>
        private string _lineNumber;

        /// <summary>
        /// The line name
        /// </summary>
        private string _lineName;

        /// <summary>
        /// The line caption
        /// </summary>
        private string _lineCaption;

        /// <summary>
        /// The amount
        /// </summary>
        private double _amount;

        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        /// <value>
        /// The line number.
        /// </value>
        public string LineNumber
        {
            get
            {
                return _lineNumber;
            }
            private protected set
            {
                _lineNumber = value;
            }
        }

        /// <summary>
        /// Gets the name of the line.
        /// </summary>
        /// <value>
        /// The name of the line.
        /// </value>
        public string LineName
        {
            get
            {
                return _lineName;
            }
            private protected set
            {
                _lineName = value;
            }
        }

        /// <summary>
        /// Gets or sets the line description.
        /// </summary>
        /// <value>
        /// The line description.
        /// </value>
        public string LineCaption
        {
            get
            {
                return _lineCaption;
            }
            private protected set
            {
                _lineCaption = value;
            }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public double Amount
        {
            get
            {
                return _amount;
            }
            private protected set
            {
                _amount = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetExecution" />
        /// class.
        /// </summary>
        public StatusOfBudgetExecution( ) 
            : base( )
        {
            _source = Source.StatusOfBudgetExecution;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetExecution" />
        /// class.
        /// </summary>
        /// <param name="query">The query.</param>
        public StatusOfBudgetExecution( IQuery query ) 
            : base( query )
        {
            _record = new DataBuilder( query ).Record;
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _lineName = _record[ "LineName" ]?.ToString( );
            _lineCaption = _record[ "LineCaption" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetExecution" />
        /// class.
        /// </summary>
        /// <param name="builder">The data builder.</param>
        public StatusOfBudgetExecution( IDataModel builder ) 
            : base( builder )
        {
            _record = builder.Record;
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _lineName = _record[ "LineName" ]?.ToString( );
            _lineCaption = _record[ "LineCaption" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StatusOfBudgetExecution" />
        /// class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public StatusOfBudgetExecution( DataRow dataRow ) 
            : base( dataRow )
        {
            _record = dataRow;
            _lineNumber = dataRow[ "LineNumber" ]?.ToString( );
            _lineName = dataRow[ "LineName" ]?.ToString( );
            _lineCaption = dataRow[ "LineCaption" ]?.ToString( );
        }
    }
}