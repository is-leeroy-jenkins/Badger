// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="BudgetContact.cs" company="Terry D. Eppler">
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
//   BudgetContact.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="DataUnit" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InheritdocConsiderUsage" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class BudgetContact : DataUnit
    {
        /// <summary>
        /// The first name
        /// </summary>
        private string _firstName;

        /// <summary>
        /// The last name
        /// </summary>
        private string _lastName;

        /// <summary>
        /// The full name
        /// </summary>
        private string _fullName;

        /// <summary>
        /// The email address
        /// </summary>
        private string _emailAddress;

        /// <summary>
        /// The rpio
        /// </summary>
        private string _rpio;

        /// <summary>
        /// The section
        /// </summary>
        private string _section;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            private protected set
            {
                _firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            private protected set
            {
                _lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName
        {
            get
            {
                return _fullName;
            }
            private protected set
            {
                _fullName = value;
            }
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            private protected set
            {
                _emailAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the rpio.
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
            private protected set
            {
                _rpio = value;
            }
        }

        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public string Section
        {
            get
            {
                return _section;
            }
            private protected set
            {
                _section = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetContact"/> class.
        /// </summary>
        public BudgetContact( )
            : base( )
        {
            _source = Source.BudgetContacts;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetContact"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public BudgetContact( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "BudgetContactsId" ].ToString( ) ?? "0" );
            _firstName = _record[ "FirstName" ].ToString( );
            _lastName = _record[ "LastName" ].ToString( );
            _fullName = _record[ "FullName" ].ToString( );
            _rpio = _record[ "RPIO" ].ToString( );
            _emailAddress = _record[ "EmailAddress" ].ToString( );
            _section = _record[ "Section" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetContact"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public BudgetContact( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "BudgetContactsId" ].ToString( ) ?? "0" );
            _firstName = _record[ "FirstName" ].ToString( );
            _lastName = _record[ "LastName" ].ToString( );
            _fullName = _record[ "FullName" ].ToString( );
            _rpio = _record[ "RPIO" ].ToString( );
            _emailAddress = _record[ "EmailAddress" ].ToString( );
            _section = _record[ "Section" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetContact"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public BudgetContact( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "BudgetContactsId" ].ToString( ) ?? "0" );
            _firstName = dataRow[ "FirstName" ].ToString( );
            _lastName = dataRow[ "LastName" ].ToString( );
            _fullName = dataRow[ "FullName" ].ToString( );
            _rpio = dataRow[ "RPIO" ].ToString( );
            _emailAddress = dataRow[ "EmailAddress" ].ToString( );
            _section = dataRow[ "Section" ].ToString( );
        }
    }
}