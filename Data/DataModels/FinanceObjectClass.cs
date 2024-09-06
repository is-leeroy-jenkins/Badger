// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="FinanceObjectClass.cs" company="Terry D. Eppler">
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
//   FinanceObjectClass.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.DataUnit" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "UnassignedReadonlyField" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MissingSpace" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class FinanceObjectClass : DataUnit
    {
        /// <summary>
        /// The boc code
        /// </summary>
        private protected string _bocCode;

        /// <summary>
        /// The boc name
        /// </summary>
        private protected string _bocName;

        /// <summary>
        /// The category
        /// </summary>
        private protected BOC _category;

        /// <summary>
        /// Gets or sets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        public string BocCode
        {
            get
            {
                return _bocCode;
            }
            set
            {
                _bocCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the boc.
        /// </summary>
        /// <value>
        /// The name of the boc.
        /// </value>
        public string BocName
        {
            get
            {
                return _bocName;
            }
            set
            {
                _bocName = value;
            }
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public BOC Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FinanceObjectClass" /> class.
        /// </summary>
        public FinanceObjectClass( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FinanceObjectClass" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public FinanceObjectClass( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( _record[ "FinanceObjectClassesId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _category = ( BOC )Enum.Parse( typeof( BOC ), _record[ "Dimension" ].ToString( ) );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FinanceObjectClass" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public FinanceObjectClass( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "FinanceObjectClassesId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _category = ( BOC )Enum.Parse( typeof( BOC ), _record[ "Dimension" ].ToString( ) );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FinanceObjectClass" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public FinanceObjectClass( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "FinanceObjectClassesId" ].ToString( ) ?? "0" );
            _name = dataRow[ "Name" ].ToString( );
            _code = dataRow[ "Code" ].ToString( );
            _bocCode = dataRow[ "BocCode" ].ToString( );
            _bocName = dataRow[ "BocName" ].ToString( );
            _category = ( BOC )Enum.Parse( typeof( BOC ), dataRow[ "Dimension" ].ToString( ) );
            _map = dataRow?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FinanceObjectClass" /> class.
        /// </summary>
        /// <param name="focCode">The foc code.</param>
        public FinanceObjectClass( string focCode )
            : this( )
        {
            _record = new DataGenerator( _source, GetArgs( focCode ) )?.Record;
            _id = int.Parse( _record[ "FinanceObjectClassesId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _bocCode = _record[ "BocCode" ].ToString( );
            _bocName = _record[ "BocName" ].ToString( );
            _category = ( BOC )Enum.Parse( typeof( BOC ), _record[ "Dimension" ].ToString( ) );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.FinanceObjectClass" /> class.
        /// </summary>
        /// <param name="foc">The foc.</param>
        public FinanceObjectClass( FinanceObjectClass foc )
            : this( )
        {
            _id = foc.ID;
            _code = foc.Code;
            _name = foc.Name;
            _category = foc.Category;
            _bocCode = foc.BocCode;
            _bocName = foc.BocName;
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        private IDictionary<string, object> GetArgs( string code )
        {
            if( !string.IsNullOrEmpty( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ "Code" ] = code
                    };
                }
                catch( Exception ex )
                {
                    FinanceObjectClass.Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }
    }
}