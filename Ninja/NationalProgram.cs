// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="NationalProgram.cs" company="Terry D. Eppler">
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
//   NationalProgram.cs
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "Performance", "CA1822:Mark members as static" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MissingSpace" ) ]
    public class NationalProgram : DataUnit
    {
        /// <summary>
        /// The title
        /// </summary>
        private protected string _title;

        /// <summary>
        /// The rpio code
        /// </summary>
        private protected string _rpioCode;

        /// <summary>
        /// The NPM
        /// </summary>
        private protected NPM _npm;
        
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return _title;
            }
            private protected set
            {
                _title = value;
            }
        }

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
        /// Gets or sets the NPM.
        /// </summary>
        /// <value>
        /// The NPM.
        /// </value>
        public NPM NPM
        {
            get
            {
                return _npm;
            }
            private protected set
            {
                _npm = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.NationalProgram" /> class.
        /// </summary>
        public NationalProgram( ) 
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.NationalProgram" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public NationalProgram( IQuery query ) 
            : base( query )
        {
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( _record[ "NationalProgramsId" ]?.ToString( ) );
            _name = _record[ "Name" ]?.ToString( );
            _code = _record[ "Code" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _title = _record[ "Title" ]?.ToString( );
            _map = _record?.ToDictionary( );
            _npm = (NPM)Enum.Parse( typeof( NPM ), _code );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.NationalProgram" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public NationalProgram( IDataModel builder ) 
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "NationalProgramsId" ]?.ToString( ) );
            _name = _record[ "Name" ]?.ToString( );
            _code = _record[ "Code" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _title = _record[ "Title" ]?.ToString( );
            _map = _record?.ToDictionary( );
            _npm = (NPM)Enum.Parse( typeof( NPM ), _code );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.NationalProgram" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public NationalProgram( DataRow dataRow ) 
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "NationalProgramsId" ]?.ToString( ) );
            _name = dataRow[ "Name" ]?.ToString( );
            _code = dataRow[ "Code" ]?.ToString( );
            _rpioCode = dataRow[ "RpioCode" ]?.ToString( );
            _title = dataRow[ "Title" ]?.ToString( );
            _map = dataRow?.ToDictionary( );
            _npm = (NPM)Enum.Parse( typeof( NPM ), _code );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.NationalProgram" /> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public NationalProgram( string code ) 
            : base( )
        {
            _record = new DataGenerator( _source, GetArgs( code ) )?.Record;
            _id = int.Parse( _record[ "NationalProgramsId" ]?.ToString( ) );
            _name = _record[ "Name" ]?.ToString( );
            _code = _record[ "Code" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _title = _record[ "Title" ]?.ToString( );
            _map = _record?.ToDictionary( );
            _npm = (NPM)Enum.Parse( typeof( NPM ), _code );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.NationalProgram" /> class.
        /// </summary>
        /// <param name="npm">The NPM.</param>
        public NationalProgram( NationalProgram npm ) 
            : base( )
        {
            ID = npm.ID;
            Code = npm.Code;
            Name = npm.Name;
            NPM = npm.NPM;
            Title = npm.Title;
            RpioCode = npm.RpioCode;
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
                    return new Dictionary<string, object> { [ "Code" ] = code };
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }
    }
}