// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="Goal.cs" company="Terry D. Eppler">
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
//   Goal.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    /// <seealso cref="T:Badger.ISource" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class Goal : DataUnit
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Goal" />
        /// class.
        /// </summary>
        public Goal( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Goal" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Goal( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( Record[ "GoalsId" ].ToString( ) );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Goal" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public Goal( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "GoalsId" ].ToString( ) );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Goal" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The dataRow. </param>
        public Goal( DataRow dataRow )
            : base( dataRow )
        {
            Record = dataRow;
            _id = int.Parse( dataRow[ "GoalsId" ].ToString( ) );
            _code = dataRow[ "Code" ].ToString( );
            _name = dataRow[ "Name" ].ToString( );
            _map = dataRow?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Goal" />
        /// class.
        /// </summary>
        /// <param name="code"> The code. </param>
        public Goal( string code )
            : this( )
        {
            _record = new DataGenerator( _source, GetArgs( code ) )?.Record;
            _id = int.Parse( _record[ "GoalsId" ].ToString( ) );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Goal" />
        /// class.
        /// </summary>
        /// <param name="goal"> The goal. </param>
        public Goal( Goal goal )
            : this( )
        {
            _id = goal.ID;
            _code = goal.Code;
            _name = goal.Name;
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name="goal">The goal.</param>
        /// <returns></returns>
        public IDictionary<string, object> GetArgs( int goal )
        {
            if( ( goal > 0 )
               && ( goal < 5 ) )
            {
                try
                {
                    return new Dictionary<string, object> { [ "Code" ] = goal.ToString( ) };
                }
                catch( SystemException _ex )
                {
                    Fail( _ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns></returns>
        public Source GetSource( )
        {
            try
            {
                return Enum.IsDefined( typeof( Source ), Source )
                    ? Source
                    : default( Source );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( Source );
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        private IDictionary<string, object> GetArgs( string code )
        {
            try
            {
                ThrowIf.Null( code, nameof( code ) );
                return new Dictionary<string, object> { [ "Code" ] = code };
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}