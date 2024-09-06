// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="Change.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  2024  Terry D. Eppler
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
//   Change.cs
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
    /// <seealso cref="T:Badger.DataUnit" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MissingLinebreak" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class Change : DataUnit
    {
        /// <summary>
        /// The table name
        /// </summary>
        private string _tableName;

        /// <summary>
        /// The field name
        /// </summary>
        private string _fieldName;

        /// <summary>
        /// The action type
        /// </summary>
        private string _actionType;

        /// <summary>
        /// The old value
        /// </summary>
        private string _oldValue;

        /// <summary>
        /// The new value
        /// </summary>
        private string _newValue;

        /// <summary>
        /// The change date
        /// </summary>
        private DateTime _changeDate;

        /// <summary>
        /// The message
        /// </summary>
        private string _message;

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName
        {
            get
            {
                return _tableName;
            }
            private protected set
            {
                _tableName = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        public string FieldName
        {
            get
            {
                return _fieldName;
            }
            private protected set
            {
                _fieldName = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public string ActionType
        {
            get
            {
                return _actionType;
            }
            private protected set
            {
                _actionType = value;
            }
        }

        /// <summary>
        /// Gets or sets the old value.
        /// </summary>
        /// <value>
        /// The old value.
        /// </value>
        public string OldValue
        {
            get
            {
                return _oldValue;
            }
            private protected set
            {
                _oldValue = value;
            }
        }

        /// <summary>
        /// Creates new value.
        /// </summary>
        /// <value>
        /// The new value.
        /// </value>
        public string NewValue
        {
            get
            {
                return _newValue;
            }
            private protected set
            {
                _newValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the change date.
        /// </summary>
        /// <value>
        /// The change date.
        /// </value>
        public DateTime ChangeDate
        {
            get
            {
                return _changeDate;
            }
            private protected set
            {
                _changeDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get
            {
                return _message;
            }
            private protected set
            {
                _message = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Change" />
        /// class.
        /// </summary>
        public Change( )
            : base( )
        {
            _source = Source.Changes;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Change" />
        /// class.
        /// </summary>
        /// <param name="query">The query.</param>
        public Change( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "ChangesId" ].ToString( ) ?? "0" );
            _tableName = _record[ "TableName" ]?.ToString( );
            _fieldName = _record[ "FieldName" ]?.ToString( );
            _actionType = _record[ "ActionType" ]?.ToString( );
            _oldValue = _record[ "OldValue" ]?.ToString( );
            _newValue = _record[ "NewValue" ]?.ToString( );
            _changeDate = DateTime.Parse( _record[ "ChangeDate" ]?.ToString( ) );
            _message = _record[ "Message" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Change" />
        /// class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public Change( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "ChangesId" ].ToString( ) ?? "0" );
            _tableName = _record[ "TableName" ]?.ToString( );
            _fieldName = _record[ "FieldName" ]?.ToString( );
            _actionType = _record[ "ActionType" ]?.ToString( );
            _oldValue = _record[ "OldValue" ]?.ToString( );
            _newValue = _record[ "NewValue" ]?.ToString( );
            _changeDate = DateTime.Parse( _record[ "ChangeDate" ]?.ToString( ) );
            _message = _record[ "Message" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Change" />
        /// class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public Change( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "ChangesId" ].ToString( ) ?? "0" );
            _tableName = dataRow[ "TableName" ]?.ToString( );
            _fieldName = dataRow[ "FieldName" ]?.ToString( );
            _actionType = dataRow[ "ActionType" ]?.ToString( );
            _oldValue = dataRow[ "OldValue" ]?.ToString( );
            _newValue = dataRow[ "NewValue" ]?.ToString( );
            _changeDate = DateTime.Parse( dataRow[ "ChangeDate" ]?.ToString( ) );
            _message = dataRow[ "Message" ]?.ToString( );
        }
    }
}