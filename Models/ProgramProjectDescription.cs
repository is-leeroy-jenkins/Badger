// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="ProgramProjectDescription.cs" company="Terry D. Eppler">
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
//   ProgramProjectDescription.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class ProgramProjectDescription : DescriptionBase
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjectDescriptions" />
        /// class.
        /// </summary>
        public ProgramProjectDescription( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjectDescriptions" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public ProgramProjectDescription( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _id = int.Parse( _record[ "ProgramProjectDescriptionsId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _title = _record[ "Title" ]?.ToString( );
            _definition = _record[ "Definition" ]?.ToString( );
            _laws = _record[ "Laws" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjectDescriptions" />
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public ProgramProjectDescription( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "ProgramProjectDescriptionsId" ]?.ToString( ) ?? "0" );
            _code = _record[ "Code" ]?.ToString( );
            _name = _record[ "Name" ]?.ToString( );
            _title = _record[ "Title" ]?.ToString( );
            _definition = _record[ "Definition" ]?.ToString( );
            _laws = _record[ "Laws" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.ProgramProjectDescriptions" />
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public ProgramProjectDescription( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "ProgramProjectDescriptionsId" ]?.ToString( ) ?? "0" );
            _code = dataRow[ "Code" ]?.ToString( );
            _name = dataRow[ "Name" ]?.ToString( );
            _title = dataRow[ "Title" ]?.ToString( );
            _definition = dataRow[ "Definition" ]?.ToString( );
            _laws = dataRow[ "Laws" ]?.ToString( );
            _programAreaCode = dataRow[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = dataRow[ "ProgramAreaName" ]?.ToString( );
            _map = dataRow?.ToDictionary( );
        }
    }
}