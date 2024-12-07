// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="Fund.cs" company="Terry D. Eppler">
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
//   Fund.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class Fund : FundSymbol
    {
        /// <summary>
        /// Gets or sets the no year.
        /// </summary>
        /// <value>
        /// The no year.
        /// </value>
        public string NoYear
        {
            get
            {
                return _noYear;
            }
            private protected set
            {
                _noYear = value;
            }
        }

        /// <summary>
        /// Gets or sets the carryover.
        /// </summary>
        /// <value>
        /// The carryover.
        /// </value>
        public string Carryover
        {
            get
            {
                return _carryover;
            }
            private protected set
            {
                _carryover = value;
            }
        }

        /// <summary>
        /// Gets or sets the beginning period of availability.
        /// </summary>
        /// <value>
        /// The beginning period of availability.
        /// </value>
        public string BeginningPeriodOfAvailability
        {
            get
            {
                return _beginningPeriodOfAvailability;
            }
            private protected set
            {
                _beginningPeriodOfAvailability = value;
            }
        }

        /// <summary>
        /// Gets or sets the ending period of availability.
        /// </summary>
        /// <value>
        /// The ending period of availability.
        /// </value>
        public string EndingPeriodOfAvailability
        {
            get
            {
                return _endingPeriodOfAvailability;
            }
            private protected set
            {
                _endingPeriodOfAvailability = value;
            }
        }

        /// <summary>
        /// Gets or sets the multi year indicator.
        /// </summary>
        /// <value>
        /// The multi year indicator.
        /// </value>
        public string MultiYearIndicator
        {
            get
            {
                return _multiYearIndicator;
            }
            private protected set
            {
                _multiYearIndicator = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Funds" />
        /// class.
        /// </summary>
        public Fund( )
            : base( )
        {
            _source = Source.Funds;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Fund"/>
        /// class.
        /// </summary>
        /// <param name="fundCode"> The fundCode. </param>
        [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
        public Fund( FundCode fundCode )
            : base( )
        {
            _source = Source.Funds;
            _record = new DataGenerator( _source, GetArgs( fundCode ) )?.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "FundsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _shortName = _record[ "ShortName" ].ToString( );
            _status = _record[ "Status" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _subLevelPrefix = _record[ "SubLevelPrefix" ].ToString( );
            _allocationTransferAgency = _record[ "AllocationTransferAgency" ].ToString( );
            _agencyIdentifier = _record[ "AgencyIdentifier" ].ToString( );
            _beginningPeriodOfAvailability = _record[ "BeginningPeriodOfAvailability" ].ToString( );
            _endingPeriodOfAvailability = _record[ "EndingPeriodOfAvailability" ].ToString( );
            _multiYearIndicator = _record[ "MultiYearIndicator" ].ToString( );
            _subAccount = _record[ "SubAccount" ].ToString( );
            _fundCategory = _record[ "FundCategory" ].ToString( );
            _appropriationCode = _record[ "AppropriationCode" ].ToString( );
            _subAppropriationCode = _record[ "SubAppropriationCode" ].ToString( );
            _fundGroup = _record[ "FundGroup" ].ToString( );
            _noYear = _record[ "NoYear" ].ToString( );
            _carryover = _record[ "Carryover" ].ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Fund"/>
        /// class.
        /// </summary>
        /// <param name="code"> The code. </param>
        public Fund( string code )
            : base( )
        {
            _source = Source.Funds;
            _record = new DataGenerator( _source, GetArgs( code ) )?.Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "FundsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _shortName = _record[ "ShortName" ].ToString( );
            _status = _record[ "Status" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _subLevelPrefix = _record[ "SubLevelPrefix" ].ToString( );
            _allocationTransferAgency = _record[ "AllocationTransferAgency" ].ToString( );
            _agencyIdentifier = _record[ "AgencyIdentifier" ].ToString( );
            _beginningPeriodOfAvailability = _record[ "BeginningPeriodOfAvailability" ].ToString( );
            _endingPeriodOfAvailability = _record[ "EndingPeriodOfAvailability" ].ToString( );
            _multiYearIndicator = _record[ "MultiYearIndicator" ].ToString( );
            _subAccount = _record[ "SubAccount" ].ToString( );
            _fundCategory = _record[ "FundCategory" ].ToString( );
            _appropriationCode = _record[ "AppropriationCode" ].ToString( );
            _subAppropriationCode = _record[ "SubAppropriationCode" ].ToString( );
            _fundGroup = _record[ "FundGroup" ].ToString( );
            _noYear = _record[ "NoYear" ].ToString( );
            _carryover = _record[ "Carryover" ].ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Fund"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Fund( IQuery query )
            : base( query )
        {
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _shortName = _record[ "ShortName" ].ToString( );
            _status = _record[ "Status" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _subLevelPrefix = _record[ "SubLevelPrefix" ].ToString( );
            _allocationTransferAgency = _record[ "AllocationTransferAgency" ].ToString( );
            _agencyIdentifier = _record[ "AgencyIdentifier" ].ToString( );
            _beginningPeriodOfAvailability = _record[ "BeginningPeriodOfAvailability" ].ToString( );
            _endingPeriodOfAvailability = _record[ "EndingPeriodOfAvailability" ].ToString( );
            _multiYearIndicator = _record[ "MultiYearIndicator" ].ToString( );
            _subAccount = _record[ "SubAccount" ].ToString( );
            _fundCategory = _record[ "FundCategory" ].ToString( );
            _appropriationCode = _record[ "AppropriationCode" ].ToString( );
            _subAppropriationCode = _record[ "SubAppropriationCode" ].ToString( );
            _fundGroup = _record[ "FundGroup" ].ToString( );
            _noYear = _record[ "NoYear" ].ToString( );
            _carryover = _record[ "Carryover" ].ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Fund"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The builder. </param>
        public Fund( IDataService builder )
            : base( builder )
        {
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _name = _record[ "Name" ].ToString( );
            _shortName = _record[ "ShortName" ].ToString( );
            _status = _record[ "Status" ].ToString( );
            _startDate = DateTime.Parse( _record[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( _record[ "EndDate" ].ToString( ) );
            _subLevelPrefix = _record[ "SubLevelPrefix" ].ToString( );
            _allocationTransferAgency = _record[ "AllocationTransferAgency" ].ToString( );
            _agencyIdentifier = _record[ "AgencyIdentifier" ].ToString( );
            _beginningPeriodOfAvailability = _record[ "BeginningPeriodOfAvailability" ].ToString( );
            _endingPeriodOfAvailability = _record[ "EndingPeriodOfAvailability" ].ToString( );
            _multiYearIndicator = _record[ "MultiYearIndicator" ].ToString( );
            _subAccount = _record[ "SubAccount" ].ToString( );
            _fundCategory = _record[ "FundCategory" ].ToString( );
            _appropriationCode = _record[ "AppropriationCode" ].ToString( );
            _subAppropriationCode = _record[ "SubAppropriationCode" ].ToString( );
            _fundGroup = _record[ "FundGroup" ].ToString( );
            _noYear = _record[ "NoYear" ].ToString( );
            _carryover = _record[ "Carryover" ].ToString( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Fund"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The Data. </param>
        public Fund( DataRow dataRow )
            : base( dataRow )
        {
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _code = dataRow[ "Code" ].ToString( );
            _name = dataRow[ "Name" ].ToString( );
            _shortName = dataRow[ "ShortName" ].ToString( );
            _status = dataRow[ "Status" ].ToString( );
            _startDate = DateTime.Parse( dataRow[ "StartDate" ].ToString( ) );
            _endDate = DateTime.Parse( dataRow[ "EndDate" ].ToString( ) );
            _subLevelPrefix = dataRow[ "SubLevelPrefix" ].ToString( );
            _allocationTransferAgency = dataRow[ "AllocationTransferAgency" ].ToString( );
            _agencyIdentifier = dataRow[ "AgencyIdentifier" ].ToString( );
            _beginningPeriodOfAvailability = dataRow[ "BeginningPeriodOfAvailability" ].ToString( );
            _endingPeriodOfAvailability = dataRow[ "EndingPeriodOfAvailability" ].ToString( );
            _multiYearIndicator = dataRow[ "MultiYearIndicator" ].ToString( );
            _subAccount = dataRow[ "SubAccount" ].ToString( );
            _fundCategory = dataRow[ "FundCategory" ].ToString( );
            _appropriationCode = dataRow[ "AppropriationCode" ].ToString( );
            _subAppropriationCode = dataRow[ "SubAppropriationCode" ].ToString( );
            _fundGroup = dataRow[ "FundGroup" ].ToString( );
            _noYear = dataRow[ "NoYear" ].ToString( );
            _carryover = dataRow[ "Carryover" ].ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Funds" />
        /// class.
        /// </summary>
        /// <param name="fund"> The fund. </param>
        public Fund( Fund fund )
        {
            _id = fund.ID;
            _bfy = fund.BFY;
            _efy = fund.EFY;
            _code = fund.Code;
            _name = fund.Name;
            _shortName = fund.ShortName;
            _status = fund.Status;
            _startDate = fund.StartDate;
            _endDate = fund.EndDate;
            _subLevelPrefix = fund.SubLevelPrefix;
            _allocationTransferAgency = fund.AllocationTransferAgency;
            _agencyIdentifier = fund.AgencyIdentifier;
            _beginningPeriodOfAvailability = fund.BeginningPeriodOfAvailability;
            _endingPeriodOfAvailability = fund.EndingPeriodOfAvailability;
            _multiYearIndicator = fund.MultiYearIndicator;
            _mainAccount = fund.MainAccount;
            _subAccount = fund.SubAccount;
            _fundCategory = fund.FundCategory;
            _appropriationCode = fund.AppropriationCode;
            _subAppropriationCode = fund.SubAppropriationCode;
            _fundGroup = fund.FundCategory;
            _noYear = fund.NoYear;
            _carryover = fund.Carryover;
            _treasuryAccountCode = fund.TreasuryAccountCode;
            _treasuryAccountName = fund.TreasuryAccountName;
            _budgetAccountCode = fund.BudgetAccountCode;
            _budgetAccountName = fund.BudgetAccountName;
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name="fundCode">The fund code.</param>
        /// <returns></returns>
        protected IDictionary<string, object> GetArgs( string fundCode )
        {
            if( !string.IsNullOrEmpty( fundCode )
                && fundCode.Length < 5 )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ "Code" ] = fundCode
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return new Dictionary<string, object>
                    {
                        [ "Name" ] = fundCode
                    };
                }
            }

            if( !string.IsNullOrEmpty( fundCode )
                && fundCode.Length > 5 )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ "Name" ] = fundCode
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name="fundCode">The fund code.</param>
        /// <returns></returns>
        protected IDictionary<string, object> GetArgs( FundCode fundCode )
        {
            try
            {
                return Enum.IsDefined( typeof( FundCode ), fundCode )
                    ? new Dictionary<string, object>
                    {
                        [ "Code" ] = fundCode.ToString( )
                    }
                    : default( Dictionary<string, object> );
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}