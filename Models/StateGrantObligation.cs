// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="StateGrantObligation.cs" company="Terry D. Eppler">
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
//   StateGrantObligation.cs
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
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class StateGrantObligation : PRC
    {
        /// <summary>
        /// The state code
        /// </summary>
        private protected string _stateCode;

        /// <summary>
        /// The state name
        /// </summary>
        private protected string _stateName;

        /// <summary>
        /// The amount
        /// </summary>
        private protected double _amount;

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        /// <value>
        /// The state code.
        /// </value>
        public string StateCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        /// <value>
        /// The name of the state.
        /// </value>
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public double Amount { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StateGrantObligation" /> class.
        /// </summary>
        public StateGrantObligation( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StateGrantObligation" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public StateGrantObligation( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _ahCode = _record[ "AhCode" ]?.ToString( );
            _ahName = _record[ "AhName" ]?.ToString( );
            _orgCode = _record[ "OrgCode" ]?.ToString( );
            _orgName = _record[ "OrgName" ]?.ToString( );
            _accountCode = _record[ "AccountCode" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _rcCode = _record[ "RcCode" ]?.ToString( );
            _rcName = _record[ "RcName" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StateGrantObligation" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public StateGrantObligation( IDataService builder )
        {
            _record = builder.Record;
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _ahCode = _record[ "AhCode" ]?.ToString( );
            _ahName = _record[ "AhName" ]?.ToString( );
            _orgCode = _record[ "OrgCode" ]?.ToString( );
            _orgName = _record[ "OrgName" ]?.ToString( );
            _accountCode = _record[ "AccountCode" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _rcCode = _record[ "RcCode" ]?.ToString( );
            _rcName = _record[ "RcName" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.StateGrantObligation" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public StateGrantObligation( DataRow dataRow )
        {
            _record = dataRow;
            _budgetLevel = dataRow[ "BudgetLevel" ]?.ToString( );
            _rpioCode = dataRow[ "RpioCode" ]?.ToString( );
            _rpioName = dataRow[ "RpioName" ]?.ToString( );
            _ahCode = dataRow[ "AhCode" ]?.ToString( );
            _ahName = dataRow[ "AhName" ]?.ToString( );
            _orgCode = dataRow[ "OrgCode" ]?.ToString( );
            _orgName = dataRow[ "OrgName" ]?.ToString( );
            _accountCode = dataRow[ "AccountCode" ]?.ToString( );
            _bocCode = dataRow[ "BocCode" ]?.ToString( );
            _bocName = dataRow[ "BocName" ]?.ToString( );
            _rcCode = dataRow[ "RcCode" ]?.ToString( );
            _rcName = dataRow[ "RcName" ]?.ToString( );
            _bocCode = dataRow[ "BocCode" ]?.ToString( );
            _bocName = dataRow[ "BocName" ]?.ToString( );
            _programAreaCode = dataRow[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = dataRow[ "ProgramAreaName" ]?.ToString( );
        }
    }
}