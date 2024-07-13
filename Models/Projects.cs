// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="Projects.cs" company="Terry D. Eppler">
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
//   Projects.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    /// <seealso cref="T:Badger.DataUnit" />
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class Projects : DataUnit
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Projects"/>
        /// class.
        /// </summary>
        public Projects( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Projects"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Projects( IQuery query )
        {
            Record = new DataGenerator( query ).Record;
            Map = Record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Projects"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public Projects( IDataModel builder )
        {
            Record = builder.Record;
            Map = Record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Projects"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public Projects( DataRow dataRow )
        {
            Record = dataRow;
            Map = dataRow.ToDictionary( );
        }
    }
}