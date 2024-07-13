// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="CarryoverApportionment.cs" company="Terry D. Eppler">
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
//   CarryoverApportionment.cs
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
    /// <seealso cref="T:Badger.BudgetUnit" />
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class CarryoverApportionment : BudgetUnit
    {
        /// <summary>
        /// The budget account
        /// </summary>
        private string _budgetAccount;

        /// <summary>
        /// The treasury account
        /// </summary>
        private string _treasuryAccount;

        /// <summary>
        /// The group
        /// </summary>
        private string _group;

        /// <summary>
        /// The description
        /// </summary>
        private string _description;

        /// <summary>
        /// The line name
        /// </summary>
        private string _lineName;

        /// <summary>
        /// The authority type
        /// </summary>
        private string _authorityType;

        /// <summary>
        /// The request
        /// </summary>
        private double _request;

        /// <summary>
        /// The balance
        /// </summary>
        private double _balance;

        /// <summary>
        /// The deobligations
        /// </summary>
        private double _deobligations;

        /// <summary>
        /// The amount
        /// </summary>
        private double _amount;

        /// <summary>
        /// The line number
        /// </summary>
        private string _lineNumber;

        /// <summary>
        /// The line split
        /// </summary>
        private string _lineSplit;

        /// <summary>
        /// The apportionment account code
        /// </summary>
        private string _apportionmentAccountCode;

        /// <summary>
        /// Gets or sets the budget account.
        /// </summary>
        /// <value>
        /// The budget account.
        /// </value>
        public string BudgetAccount
        {
            get
            {
                return _budgetAccount;
            }
            private set
            {
                _budgetAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the treasury account.
        /// </summary>
        /// <value>
        /// The treasury account.
        /// </value>
        public string TreasuryAccount
        {
            get
            {
                return _treasuryAccount;
            }
            private set
            {
                _treasuryAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        public string Group
        {
            get
            {
                return _group;
            }
            private set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the line.
        /// </summary>
        /// <value>
        /// The name of the line.
        /// </value>
        public string LineName
        {
            get
            {
                return _lineName;
            }
            private set
            {
                _lineName = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the authority.
        /// </summary>
        /// <value>
        /// The type of the authority.
        /// </value>
        public string AuthorityType
        {
            get
            {
                return _authorityType;
            }
            private set
            {
                _authorityType = value;
            }
        }

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        public double Request
        {
            get
            {
                return _request;
            }
            private set
            {
                _request = value;
            }
        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public double Balance
        {
            get
            {
                return _balance;
            }
            private set
            {
                _balance = value;
            }
        }

        /// <summary>
        /// Gets or sets the deobligations.
        /// </summary>
        /// <value>
        /// The deobligations.
        /// </value>
        public double Deobligations
        {
            get
            {
                return _deobligations;
            }
            private set
            {
                _deobligations = value;
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public double Amount
        {
            get
            {
                return _amount;
            }
            private set
            {
                _amount = value;
            }
        }

        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        /// <value>
        /// The line number.
        /// </value>
        public string LineNumber
        {
            get
            {
                return _apportionmentAccountCode;
            }
            private set
            {
                _apportionmentAccountCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the line split.
        /// </summary>
        /// <value>
        /// The line split.
        /// </value>
        public string LineSplit
        {
            get
            {
                return _apportionmentAccountCode;
            }
            private set
            {
                _apportionmentAccountCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the apportionment account code.
        /// </summary>
        /// <value>
        /// The apportionment account code.
        /// </value>
        public string ApportionmentAccountCode
        {
            get
            {
                return _apportionmentAccountCode;
            }
            private set
            {
                _apportionmentAccountCode = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverApportionment" /> class.
        /// </summary>
        public CarryoverApportionment( )
            : base( )
        {
            _source = Source.CarryoverApportionments;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverApportionments" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public CarryoverApportionment( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "CarryoverApportionmentsId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _group = _record[ "Group" ]?.ToString( );
            _description = _record[ "Description" ]?.ToString( );
            _lineName = _record[ "LineName" ]?.ToString( );
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _authorityType = _record[ "AuthorityType" ]?.ToString( );
            _request = double.Parse( _record[ "Request" ]?.ToString( ) ?? "0" );
            _balance = double.Parse( _record[ "Balance" ]?.ToString( ) ?? "0" );
            _deobligations = double.Parse( _record[ "Deobligations" ]?.ToString( ) ?? "0" );
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0" );
            _lineSplit = _record[ "LineSplit" ]?.ToString( );
            _apportionmentAccountCode = _record[ "ApportionmentAccountCode" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverApportionments" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public CarryoverApportionment( IDataModel builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "CarryoverApportionmentsId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _group = _record[ "Group" ]?.ToString( );
            _description = _record[ "Description" ]?.ToString( );
            _lineName = _record[ "LineName" ]?.ToString( );
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _authorityType = _record[ "AuthorityType" ]?.ToString( );
            _request = double.Parse( _record[ "Request" ]?.ToString( ) ?? "0" );
            _balance = double.Parse( _record[ "Balance" ]?.ToString( ) ?? "0" );
            _deobligations = double.Parse( _record[ "Deobligations" ]?.ToString( ) ?? "0" );
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0" );
            _lineSplit = _record[ "LineSplit" ]?.ToString( );
            _apportionmentAccountCode = _record[ "ApportionmentAccountCode" ]?.ToString( );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverApportionments" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public CarryoverApportionment( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "CarryoverApportionmentsId" ]?.ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _group = dataRow[ "Group" ]?.ToString( );
            _description = dataRow[ "Description" ]?.ToString( );
            _lineName = dataRow[ "LineName" ]?.ToString( );
            _lineNumber = dataRow[ "LineNumber" ]?.ToString( );
            _authorityType = dataRow[ "AuthorityType" ]?.ToString( );
            _request = double.Parse( dataRow[ "Request" ]?.ToString( ) ?? "0" );
            _balance = double.Parse( dataRow[ "Balance" ]?.ToString( ) ?? "0" );
            _deobligations = double.Parse( dataRow[ "Deobligations" ]?.ToString( ) ?? "0" );
            _amount = double.Parse( dataRow[ "Amount" ]?.ToString( ) ?? "0" );
            _lineSplit = dataRow[ "LineSplit" ]?.ToString( );
            _apportionmentAccountCode = dataRow[ "ApportionmentAccountCode" ]?.ToString( );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CarryoverApportionments" /> class.
        /// </summary>
        /// <param name="carryover">The carryover.</param>
        public CarryoverApportionment( CarryoverApportionment carryover )
            : this( )
        {
            _id = carryover.ID;
            _bfy = carryover.BFY;
            _efy = carryover.EFY;
            _group = carryover.Group;
            _description = carryover.Description;
            _lineName = carryover.LineName;
            _lineNumber = carryover.LineNumber;
            _authorityType = carryover.AuthorityType;
            _request = carryover.Request;
            _balance = carryover.Balance;
            _deobligations = carryover.Deobligations;
            _amount = carryover.Amount;
            _lineSplit = carryover.LineSplit;
            _apportionmentAccountCode = carryover.ApportionmentAccountCode;
            _treasuryAccountCode = carryover.TreasuryAccountCode;
            _treasuryAccountName = carryover.TreasuryAccountName;
            _budgetAccountCode = carryover.BudgetAccountCode;
            _budgetAccountName = carryover.BudgetAccountName;
        }
    }
}