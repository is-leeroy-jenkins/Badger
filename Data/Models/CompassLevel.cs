// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="CompassLevel.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
// 
//    Copyright ©  2020-2024 Terry D. Eppler
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
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   CompassLevel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    /// <seealso cref="T:Badger.PRC" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class CompassLevel : PRC
    {
        /// <summary>
        /// The document type
        /// </summary>
        private string _documentType;

        /// <summary>
        /// The document date
        /// </summary>
        private DateTime _documentDate;

        /// <summary>
        /// The appropriation code
        /// </summary>
        private string _appropriationCode;

        /// <summary>
        /// The sub appropriation code
        /// </summary>
        private string _subAppropriationCode;

        /// <summary>
        /// The appropriation nmae
        /// </summary>
        private string _appropriationName;

        /// <summary>
        /// The treasury symbol
        /// </summary>
        private string _treasurySymbol;

        /// <summary>
        /// The authority
        /// </summary>
        private double _authority;

        /// <summary>
        /// The carryover in
        /// </summary>
        private double _carryoverIn;

        /// <summary>
        /// The carryover out
        /// </summary>
        private double _carryoverOut;

        /// <summary>
        /// The recoveries
        /// </summary>
        private double _recoveries;

        /// <summary>
        /// The reimbursements
        /// </summary>
        private double _reimbursements;

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        public string DocumentType
        {
            get
            {
                return _documentType;
            }
            private protected set
            {
                if( _documentType != value )
                {
                    _documentType = value;
                    OnPropertyChanged( nameof( DocumentType ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the document date.
        /// </summary>
        /// <value>
        /// The document date.
        /// </value>
        public DateTime DocumentDate
        {
            get
            {
                return _documentDate;
            }
            private protected set
            {
                if( _documentDate != value )
                {
                    _documentDate = value;
                    OnPropertyChanged( nameof( DocumentDate ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the appropriation code.
        /// </summary>
        /// <value>
        /// The appropriation code.
        /// </value>
        public string AppropriationCode
        {
            get
            {
                return _appropriationCode;
            }
            private protected set
            {
                if( _appropriationCode != value )
                {
                    _appropriationCode = value;
                    OnPropertyChanged( nameof( AppropriationCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the sub appropriation code.
        /// </summary>
        /// <value>
        /// The sub appropriation code.
        /// </value>
        public string SubAppropriationCode
        {
            get
            {
                return _subAppropriationCode;
            }
            private protected set
            {
                if( _subAppropriationCode != value )
                {
                    _subAppropriationCode = value;
                    OnPropertyChanged( nameof( SubAppropriationCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the appropriation.
        /// </summary>
        /// <value>
        /// The name of the appropriation.
        /// </value>
        public string AppropriationName
        {
            get
            {
                return _appropriationName;
            }
            private protected set
            {
                if( _appropriationName != value )
                {
                    _appropriationName = value;
                    OnPropertyChanged( nameof( AppropriationName ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the treasury symbol.
        /// </summary>
        /// <value>
        /// The treasury symbol.
        /// </value>
        public string TreasurySymbol
        {
            get
            {
                return _treasurySymbol;
            }
            private protected set
            {
                if( _treasurySymbol != value )
                {
                    _treasurySymbol = value;
                    OnPropertyChanged( nameof( TreasurySymbol ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        public double Authority
        {
            get
            {
                return _authority;
            }
            private protected set
            {
                if( _authority != value )
                {
                    _authority = value;
                    OnPropertyChanged( nameof( Authority ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the carryover in.
        /// </summary>
        /// <value>
        /// The carryover in.
        /// </value>
        public double CarryoverIn
        {
            get
            {
                return _carryoverIn;
            }
            private protected set
            {
                if( _carryoverIn != value )
                {
                    _carryoverIn = value;
                    OnPropertyChanged( nameof( CarryoverIn ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the carryover out.
        /// </summary>
        /// <value>
        /// The carryover out.
        /// </value>
        public double CarryoverOut
        {
            get
            {
                return _carryoverOut;
            }
            private protected set
            {
                if( _carryoverOut != value )
                {
                    _carryoverOut = value;
                    OnPropertyChanged( nameof( CarryoverOut ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the recoveries.
        /// </summary>
        /// <value>
        /// The recoveries.
        /// </value>
        public double Recoveries
        {
            get
            {
                return _recoveries;
            }
            private protected set
            {
                if( _recoveries != value )
                {
                    _recoveries = value;
                    OnPropertyChanged( nameof( Recoveries ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the reimbursements.
        /// </summary>
        /// <value>
        /// The reimbursements.
        /// </value>
        public double Reimbursements
        {
            get
            {
                return _reimbursements;
            }
            private protected set
            {
                if( _reimbursements != value )
                {
                    _reimbursements = value;
                    OnPropertyChanged( nameof( Reimbursements ) );
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CompassLevel" />
        /// class.
        /// </summary>
        /// <inheritdoc />
        public CompassLevel( )
            : base( )
        {
            _source = Source.CompassLevels;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CompassLevel" />
        /// class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        public CompassLevel( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = Record.ToDictionary( );
            _id = int.Parse( _record[ "CompassLevelsId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _treasurySymbol = _record[ "TreasurySymbol" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _appropriationCode = _record[ "AppropriationCode" ]?.ToString( );
            _subAppropriationCode = _record[ "SubAppropriationCode" ]?.ToString( );
            _appropriationName = _record[ "AppropriationName" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
            _authority = double.Parse( _record[ "Authority" ]?.ToString( ) ?? "0" );
            _carryoverOut = double.Parse( _record[ "CarryoverOut" ]?.ToString( ) ?? "0" );
            _carryoverIn = double.Parse( _record[ "CarryoverIn" ]?.ToString( ) ?? "0" );
            _recoveries = double.Parse( _record[ "Recoveries" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CompassLevel" />
        /// class.
        /// </summary>
        /// <param name="builder"></param>
        /// <inheritdoc />
        public CompassLevel( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "CompassLevelsId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _treasurySymbol = _record[ "TreasurySymbol" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
            _appropriationCode = _record[ "AppropriationCode" ]?.ToString( );
            _subAppropriationCode = _record[ "SubAppropriationCode" ]?.ToString( );
            _appropriationName = _record[ "AppropriationName" ]?.ToString( );
            _rpioCode = _record[ "RpioCode" ]?.ToString( );
            _rpioName = _record[ "RpioName" ]?.ToString( );
            _budgetLevel = _record[ "BudgetLevel" ]?.ToString( );
            _authority = double.Parse( _record[ "Authority" ]?.ToString( ) ?? "0" );
            _carryoverOut = double.Parse( _record[ "CarryoverOut" ]?.ToString( ) ?? "0" );
            _carryoverIn = double.Parse( _record[ "CarryoverIn" ]?.ToString( ) ?? "0" );
            _recoveries = double.Parse( _record[ "Recoveries" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( _record[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _treasuryAccountCode = _record[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = _record[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = _record[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = _record[ "BudgetAccountName" ]?.ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CompassLevel" />
        /// class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <inheritdoc />
        public CompassLevel( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _id = int.Parse( dataRow[ "CompassLevelsId" ]?.ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _treasurySymbol = dataRow[ "TreasurySymbol" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
            _appropriationCode = dataRow[ "AppropriationCode" ]?.ToString( );
            _subAppropriationCode = dataRow[ "SubAppropriationCode" ]?.ToString( );
            _appropriationName = dataRow[ "AppropriationName" ]?.ToString( );
            _rpioCode = dataRow[ "RpioCode" ]?.ToString( );
            _rpioName = dataRow[ "RpioName" ]?.ToString( );
            _budgetLevel = dataRow[ "BudgetLevel" ]?.ToString( );
            _authority = double.Parse( dataRow[ "Authority" ]?.ToString( ) ?? "0" );
            _carryoverOut = double.Parse( dataRow[ "CarryoverOut" ]?.ToString( ) ?? "0" );
            _carryoverIn = double.Parse( dataRow[ "CarryoverIn" ]?.ToString( ) ?? "0" );
            _recoveries = double.Parse( dataRow[ "Recoveries" ]?.ToString( ) ?? "0" );
            _reimbursements = double.Parse( dataRow[ "Reimbursements" ]?.ToString( ) ?? "0" );
            _treasuryAccountCode = dataRow[ "TreasuryAccountCode" ]?.ToString( );
            _treasuryAccountName = dataRow[ "TreasuryAccountName" ]?.ToString( );
            _budgetAccountCode = dataRow[ "BudgetAccountCode" ]?.ToString( );
            _budgetAccountName = dataRow[ "BudgetAccountName" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.CompassLevel" />
        /// class.
        /// </summary>
        /// <param name="level">The compass level.</param>
        public CompassLevel( CompassLevel level )
            : this( )
        {
            _id = level.ID;
            _bfy = level.BFY;
            _efy = level.EFY;
            _appropriationCode = level.AppropriationCode;
            _subAppropriationCode = level.SubAppropriationCode;
            _appropriationName = level.AppropriationName;
            _fundCode = level.FundCode;
            _fundName = level.FundName;
            _rpioCode = level.RpioCode;
            _rpioName = level.RpioName;
            _accountCode = level.AccountCode;
            _programProjectCode = level.ProgramProjectCode;
            _programAreaCode = level.ProgramAreaCode;
            _programAreaName = level.ProgramAreaName;
            _budgetLevel = level.BudgetLevel;
            _authority = level.Authority;
            _carryoverOut = level.CarryoverOut;
            _carryoverIn = level.CarryoverIn;
            _recoveries = level.Recoveries;
            _reimbursements = level.Reimbursements;
            _treasuryAccountCode = level.TreasuryAccountCode;
            _treasuryAccountName = level.TreasuryAccountName;
            _budgetAccountCode = level.BudgetAccountName;
            _budgetAccountName = level.BudgetAccountName;
        }
    }
}