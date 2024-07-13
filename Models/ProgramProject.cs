// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="ProgramProject.cs" company="Terry D. Eppler">
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
//   ProgramProject.cs
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
    /// <seealso cref="T:Badger.DescriptionBase" />
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "PossibleNullReferenceException" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class ProgramProject : DataUnit
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjects" />
        /// class.
        /// </summary>
        public ProgramProject( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjects" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public ProgramProject( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( _record[ "ProgramProjectsId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjects" />
        /// class.
        /// </summary>
        /// <param name="dataBuilder"> The dataBuilder. </param>
        public ProgramProject( IDataModel dataBuilder )
            : base( dataBuilder )
        {
            _record = dataBuilder?.Record;
            _id = int.Parse( _record[ "ProgramProjectsId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjects" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The dataRow. </param>
        public ProgramProject( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "ProgramProjectsId" ]?.ToString( ) ?? "0" );
            _code = dataRow[ "Code" ]?.ToString( );
            _name = dataRow[ "Name" ]?.ToString( );
            _map = dataRow?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjects" />
        /// class.
        /// </summary>
        /// <param name="code"> The code. </param>
        public ProgramProject( string code )
            : base( )
        {
            _record = new DataGenerator( _source, GetArgs( code ) )?.Record;
            _id = int.Parse( _record[ "ProgramProjectsId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjects" /> class.
        /// </summary>
        /// <param name="project">The project.</param>
        public ProgramProject( ProgramProject project )
            : base( )
        {
            _id = project.ID;
            _code = project.Code;
            _name = project.Name;
            _map = project.Map;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>
        /// Integer
        /// </returns>
        public override int GetId( )
        {
            try
            {
                return _id > 0
                    ? _id
                    : -1;
            }
            catch( Exception ex )
            {
                ProgramProject.Fail( ex );
                return default( int );
            }
        }

        /// <summary> Sets the arguments. </summary>
        /// <param name="code"> The code. </param>
        /// <returns> </returns>
        private IDictionary<string, object> GetArgs( string code )
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
                catch( Exception ex )
                {
                    ProgramProject.Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }
    }
}