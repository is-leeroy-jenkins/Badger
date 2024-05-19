//  ******************************************************************************************
//      Assembly:                Badger
//      Filename:                Objectives.cs
//      Author:                  Terry D. Eppler
//      Created:                 05-31-2023
// 
//      Last Modified By:        Terry D. Eppler
//      Last Modified On:        06-01-2023
//  ******************************************************************************************
//  <copyright file="Objectives.cs" company="Terry D. Eppler">
// 
//     This is a Federal Budget, Finance, and Accounting application for the
//     US Environmental Protection Agency (US EPA).
//     Copyright ©  2023  Terry Eppler
// 
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the “Software”),
//     to deal in the Software without restriction,
//     including without limitation the rights to use,
//     copy, modify, merge, publish, distribute, sublicense,
//     and/or sell copies of the Software,
//     and to permit persons to whom the Software is furnished to do so,
//     subject to the following conditions:
// 
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
// 
//     THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//     INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//     IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//     DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//     ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//     DEALINGS IN THE SOFTWARE.
// 
//     You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// 
//  </copyright>
//  <summary>
//    Objectives.cs
//  </summary>
//  ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameterInConstructor" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class Objective : DataUnit
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Objective" />
        /// class.
        /// </summary>
        public Objective( )
            : base( )
        {
            _source = Source.Objectives;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Objective" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Objective( IQuery query )
            : base( query )
        {
            _record = new DataBuilder( query )?.Record;
            _id = int.Parse( _record[ "ObjectivesId" ]?.ToString( ) ?? "0" );
            _name = _record[ "Name" ]?.ToString( );
            _code = _record[ "Code" ]?.ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Objective" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public Objective( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "ObjectivesId" ]?.ToString( ) ?? "0" );
            _name = _record[ "Name" ]?.ToString( );
            _code = _record[ "Code" ]?.ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Objectives" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The dataRow. </param>
        public Objective( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "ObjectivesId" ]?.ToString( ) ?? "0" );
            _name = dataRow[ "Name" ]?.ToString( );
            _code = dataRow[ "Code" ]?.ToString( );
            _map = dataRow?.ToDictionary( );
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Objective" />
        /// class.
        /// </summary>
        /// <param name="code"> The code. </param>
        public Objective( string code )
            : this( )
        {
            _record = new DataBuilder( _source, SetArgs( code ) )?.Record;
            _id = int.Parse( _record[ "ObjectivesId" ]?.ToString( ) ?? "0" );
            _name = _record[ "Name" ]?.ToString( );
            _code = _record[ "Code" ]?.ToString( );
            _map = _record?.ToDictionary( );
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Objective" />
        /// class.
        /// </summary>
        /// <param name="objective"> The objective. </param>
        public Objective( Objective objective )
            : this( )
        {
            _id = objective.ID;
            _code = objective.Code;
            _name = objective.Name;
            _map = objective.Map;
        }

        /// <summary> Sets the arguments. </summary>
        /// <param name="code"> The code. </param>
        /// <returns> </returns>
        private IDictionary<string, object> SetArgs( string code )
        {
            if( !string.IsNullOrEmpty( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = code
                    };
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