// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="DocumentControlNumber.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application
//    for the US Environmental Protection Agency (US EPA).
//    Copyright ©  2024  Terry Eppler
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
//   DocumentControlNumber.cs
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
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class DocumentControlNumber : DataUnit
    {
        /// <summary>
        /// The rpio code
        /// </summary>
        private protected string _rpioCode;

        /// <summary>
        /// The rpio name
        /// </summary>
        private protected string _rpioName;

        /// <summary>
        /// The document type
        /// </summary>
        private protected string _documentType;

        /// <summary>
        /// The document number
        /// </summary>
        private protected string _documentNumber;

        /// <summary>
        /// The doucment prefix
        /// </summary>
        private protected string _documentPrefix;

        /// <summary>
        /// Gets or sets the rpio code.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        public string RpioCode
        {
            get
            {
                return _rpioCode;
            }
            private protected set
            {
                _rpioCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the rpio.
        /// </summary>
        /// <value>
        /// The name of the rpio.
        /// </value>
        public string RpioName
        {
            get
            {
                return _rpioName;
            }
            private protected set
            {
                _rpioName = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        public string DocumentType
        {
            get
            {
                return _documentType;
            }
            private protected set
            {
                _documentType = value;
            }
        }

        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        /// <value>
        /// The document number.
        /// </value>
        public string DocumentNumber
        {
            get
            {
                return _documentNumber;
            }
            private protected set
            {
                _documentNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the document prefix.
        /// </summary>
        /// <value>
        /// The document prefix.
        /// </value>
        public string DocumentPrefix
        {
            get
            {
                return _documentPrefix;
            }
            private protected set
            {
                _documentPrefix = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DocumentControlNumbers" /> class.
        /// </summary>
        public DocumentControlNumber( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DocumentControlNumbers" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public DocumentControlNumber( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "DocumentControlNumbersId" ]?.ToString( ) ?? "0" );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _documentType = _record[ "DocumentType" ]?.ToString( );
            _documentPrefix = _record[ "DocumentPrefix" ]?.ToString( );
            _documentNumber = _record[ "DocumentNumber" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DocumentControlNumbers" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public DocumentControlNumber( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "DocumentControlNumbersId" ]?.ToString( ) ?? "0" );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _documentType = _record[ "DocumentType" ]?.ToString( );
            _documentPrefix = _record[ "DocumentPrefix" ]?.ToString( );
            _documentNumber = _record[ "DocumentNumber" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DocumentControlNumbers" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public DocumentControlNumber( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "DocumentControlNumbersId" ]?.ToString( ) ?? "0" );
            _rpioCode = dataRow[ "RpioCode" ]?.ToString( );
            _rpioName = dataRow[ "RpioName" ]?.ToString( );
            _documentType = dataRow[ "DocumentType" ]?.ToString( );
            _documentPrefix = dataRow[ "DocumentPrefix" ]?.ToString( );
            _documentNumber = dataRow[ "DocumentNumber" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DocumentControlNumbers" /> class.
        /// </summary>
        /// <param name="dcn">The DCN.</param>
        public DocumentControlNumber( DocumentControlNumber dcn )
        {
            _id = dcn.ID;
            _rpioCode = dcn.RpioCode;
            _rpioName = dcn.RpioName;
            _documentType = dcn.DocumentType;
            _documentPrefix = dcn.DocumentPrefix;
            _documentNumber = dcn.DocumentNumber;
        }
    }
}