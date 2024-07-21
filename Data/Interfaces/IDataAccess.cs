// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-20-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-20-2024
// ******************************************************************************************
// <copyright file="IDataAccess.cs" company="Terry D. Eppler">
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
//   IDataAccess.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public interface IDataAccess
    {
        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns></returns>
        IQuery GetQuery( );

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <param name="connection">The connection factory.</param>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns>
        /// </returns>
        IQuery GetQuery( IBudgetConnection connection, ISqlStatement sqlStatement );

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <returns></returns>
        DataRow GetRecord( );

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<DataRow> GetData( );

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns>
        /// </returns>
        DataTable GetDataTable( );

        /// <summary>
        /// Sets the column captions.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        void SetColumnCaptions( DataTable dataTable );

        /// <summary>
        /// Gets the column schema.
        /// </summary>
        /// <returns></returns>
        DataColumnCollection GetColumnSchema( );

        /// <summary>
        /// Gets the schema table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns>
        /// </returns>
        DataTable GetSchemaTable( DataTable dataTable );

        /// <summary>
        /// Gets the primary indexes.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>
        /// </returns>
        IEnumerable<int> GetPrimaryIndexes( IEnumerable<DataRow> data );

        /// <summary>
        /// Gets the column ordinals.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>
        /// </returns>
        IEnumerable<int> GetColumnOrdinals( IEnumerable<DataColumn> data );

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <returns>
        /// </returns>
        DataSet GetDataSet( );
    }
}