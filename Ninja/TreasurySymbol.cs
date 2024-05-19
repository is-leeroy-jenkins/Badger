// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="TreasurySymbol.cs" company="Terry D. Eppler">
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
//   TreasurySymbol.cs
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
    /// <seealso cref="T:Badger.Fund" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    public class TreasurySymbol : Fund
    {
        /// <summary>
        /// The short key
        /// </summary>
        private string _shortKey;

        /// <summary>
        /// The availability type
        /// </summary>
        private string _availabilityType;

        /// <summary>
        /// The agency treasury symbol
        /// </summary>
        private string _agencyTreasurySymbol;

        /// <summary>
        /// The lapsed
        /// </summary>
        private bool _lapsed;

        /// <summary>
        /// The use cancelled year spending accounts
        /// </summary>
        private bool _useCancelledYearSpendingAccounts;

        /// <summary>
        /// The prevent new use
        /// </summary>
        private bool _preventNewUse;

        /// <summary>
        /// The in use
        /// </summary>
        private bool _inUse;

        /// <summary>
        /// Gets or sets the short key.
        /// </summary>
        /// <value>
        /// The short key.
        /// </value>
        public string ShortKey
        {
            get
            {
                return _shortKey;
            }
            private set
            {
                _shortKey = value;
            }
        }

        /// <summary>
        /// Gets the type of the availability.
        /// </summary>
        /// <value>
        /// The type of the availability.
        /// </value>
        public string AvailabilityType
        {
            get
            {
                return _availabilityType;
            }
            private set
            {
                _availabilityType = value;
            }
        }

        /// <summary>
        /// Gets or sets the agency treasury symbol.
        /// </summary>
        /// <value>
        /// The agency treasury symbol.
        /// </value>
        public string AgencyTreasurySymbol
        {
            get
            {
                return _agencyTreasurySymbol;
            }
            private set
            {
                _agencyTreasurySymbol = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the lapsed.
        /// </summary>
        /// <value>
        /// The lapsed.
        /// </value>
        public bool Lapsed
        {
            get
            {
                return _lapsed;
            }
            private set
            {
                _lapsed = value;
            }
        }

        /// <summary>
        /// Gets or sets the use cancelled year spending accounts.
        /// </summary>
        /// <value>
        /// The use cancelled year spending accounts.
        /// </value>
        public bool UseCancelledYearSpendingAccounts
        {
            get
            {
                return _useCancelledYearSpendingAccounts;
            }
            private set
            {
                _useCancelledYearSpendingAccounts = value;
            }
        }

        /// <summary>
        /// Gets or sets the in use.
        /// </summary>
        /// <value>
        /// The in use.
        /// </value>
        public bool InUse
        {
            get
            {
                return _inUse;
            }
            private set
            {
                _inUse = value;
            }
        }

        /// <summary>
        /// Gets or sets the prevent new use.
        /// </summary>
        /// <value>
        /// The prevent new use.
        /// </value>
        public bool PreventNewUse
        {
            get
            {
                return _preventNewUse;
            }
            private set
            {
                _preventNewUse = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.TreasurySymbol" /> class.
        /// </summary>
        public TreasurySymbol( ) 
            : base( )
        {
            _source = Source.TreasurySymbols;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TreasurySymbol"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        public TreasurySymbol( IQuery query ) 
            : base( query )
        {
            _record = new DataBuilder( query ).Record;
            _map = _record.ToDictionary( );
            _id = int.Parse( _record[ "TreasurySymbolsId" ].ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _status = _record[ "Status" ].ToString( );
            _allocationTransferAgency = _record[ "AllocationTransferAgency" ].ToString( );
            _agencyIdentifier = _record[ "AgencyIdentifier" ].ToString( );
            _beginningPeriodOfAvailability = _record[ "BeginningPeriodOfAvailability" ].ToString( );
            _endingPeriodOfAvailability = _record[ "EndingPeriodOfAvailability" ].ToString( );
            _preventNewUse = bool.Parse( _record[ "PreventNerwUse" ].ToString( ) );
            _inUse = bool.Parse( _record[ "InUse" ].ToString( ) );
            _useCancelledYearSpendingAccounts = 
                bool.Parse( _record[ "UseCancelledYearSpendingAccounts" ].ToString( ) );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TreasurySymbol"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <inheritdoc />
        public TreasurySymbol( IDataModel builder ) 
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _bfy = _record[ "BFY" ].ToString( );
            _efy = _record[ "EFY" ].ToString( );
            _status = _record[ "Status" ].ToString( );
            _allocationTransferAgency = _record[ "AllocationTransferAgency" ].ToString( );
            _agencyIdentifier = _record[ "AgencyIdentifier" ].ToString( );
            _beginningPeriodOfAvailability = _record[ "BeginningPeriodOfAvailability" ].ToString( );
            _endingPeriodOfAvailability = _record[ "EndingPeriodOfAvailability" ].ToString( );
            _preventNewUse = bool.Parse( _record[ "PreventNerwUse" ].ToString( ) );
            _inUse = bool.Parse( _record[ "InUse" ].ToString( ) );
            _useCancelledYearSpendingAccounts =
                bool.Parse( _record[ "UseCancelledYearSpendingAccounts" ].ToString( ) );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TreasurySymbol"/> class.
        /// </summary>
        /// <param name="dataRow">The Data.</param>
        /// <inheritdoc />
        public TreasurySymbol( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _bfy = dataRow[ "BFY" ].ToString( );
            _efy = dataRow[ "EFY" ].ToString( );
            _status = dataRow[ "Status" ].ToString( );
            _allocationTransferAgency = dataRow[ "AllocationTransferAgency" ].ToString( );
            _agencyIdentifier = dataRow[ "AgencyIdentifier" ].ToString( );
            _preventNewUse = bool.Parse( dataRow[ "PreventNerwUse" ].ToString( ) );
            _inUse = bool.Parse( dataRow[ "InUse" ].ToString( ) );
            _useCancelledYearSpendingAccounts =
                bool.Parse( dataRow[ "UseCancelledYearSpendingAccounts" ].ToString( ) );
        }
    }
}