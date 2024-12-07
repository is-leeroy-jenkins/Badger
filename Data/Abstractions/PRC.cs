// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="PRC.cs" company="Terry D. Eppler">
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
//   PRC.cs
// </summary>
// ******************************************************************************************

using System;

namespace Badger
{
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.BudgetUnit" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public abstract class PRC : BudgetAccount
    {
        /// <summary>
        /// The budget level
        /// </summary>
        private protected string _budgetLevel;

        /// <summary>
        /// The rpio code
        /// </summary>
        private protected string _rpioCode;

        /// <summary>
        /// The rpio name
        /// </summary>
        private protected string _rpioName;

        /// <summary>
        /// The ah code
        /// </summary>
        private protected string _ahCode;

        /// <summary>
        /// The ah name
        /// </summary>
        private protected string _ahName;

        /// <summary>
        /// The org code
        /// </summary>
        private protected string _orgCode;

        /// <summary>
        /// The org name
        /// </summary>
        private protected string _orgName;

        /// <summary>
        /// The account code
        /// </summary>
        private protected string _accountCode;

        /// <summary>
        /// The boc code
        /// </summary>
        private protected string _bocCode;

        /// <summary>
        /// The boc name
        /// </summary>
        private protected string _bocName;

        /// <summary>
        /// The rc code
        /// </summary>
        private protected string _rcCode;

        /// <summary>
        /// The rc name
        /// </summary>
        private protected string _rcName;

        /// <summary>
        /// The program area code
        /// </summary>
        private protected string _programAreaCode;

        /// <summary>
        /// The program area name
        /// </summary>
        private protected string _programAreaName;

        /// <summary>
        /// Gets or sets the budget level.
        /// </summary>
        /// <value>
        /// The budget level.
        /// </value>
        public string BudgetLevel
        {
            get
            {
                return _budgetLevel;
            }
            private protected set
            {
                if( _budgetLevel != value )
                {
                    _budgetLevel = value;
                    OnPropertyChanged( nameof( BudgetLevel ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the rpio code.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        public string RpioCode
        {
            get
            {
                return _rpioCode;
            }
            private protected set
            {
                if( _rpioCode != value )
                {
                    _rpioCode = value;
                    OnPropertyChanged( nameof( RpioCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the rpio.
        /// </summary>
        /// <value>
        /// The name of the rpio.
        /// </value>
        public string RpioName
        {
            get
            {
                return _rpioName;
            }
            private protected set
            {
                if( _budgetLevel != value )
                {
                    _budgetLevel = value;
                    OnPropertyChanged( nameof( BudgetLevel ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the ah code.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        public string AhCode
        {
            get
            {
                return _ahCode;
            }
            private protected set
            {
                if( _ahCode != value )
                {
                    _ahCode = value;
                    OnPropertyChanged( nameof( AhCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the ah.
        /// </summary>
        /// <value>
        /// The name of the ah.
        /// </value>
        public string AhName
        {
            get
            {
                return _ahName;
            }
            private protected set
            {
                if( _ahName != value )
                {
                    _ahName = value;
                    OnPropertyChanged( nameof( AhName ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        public string OrgCode
        {
            get
            {
                return _orgCode;
            }
            private protected set
            {
                if( _budgetLevel != value )
                {
                    _budgetLevel = value;
                    OnPropertyChanged( nameof( BudgetLevel ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the org.
        /// </summary>
        /// <value>
        /// The name of the org.
        /// </value>
        public string OrgName
        {
            get
            {
                return _orgName;
            }
            private protected set
            {
                if( _orgName != value )
                {
                    _orgName = value;
                    OnPropertyChanged( nameof( OrgName ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public string AccountCode
        {
            get
            {
                return _accountCode;
            }
            private protected set
            {
                if( _accountCode != value )
                {
                    _accountCode = value;
                    OnPropertyChanged( nameof( AccountCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        public string BocCode
        {
            get
            {
                return _bocCode;
            }
            private protected set
            {
                if( _bocCode != value )
                {
                    _bocCode = value;
                    OnPropertyChanged( nameof( BocCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the boc.
        /// </summary>
        /// <value>
        /// The name of the boc.
        /// </value>
        public string BocName
        {
            get
            {
                return _bocName;
            }
            private protected set
            {
                if( _bocName != value )
                {
                    _bocName = value;
                    OnPropertyChanged( nameof( BocName ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        public string RcCode
        {
            get
            {
                return _rcCode;
            }
            private protected set
            {
                if( _rcCode != value )
                {
                    _rcCode = value;
                    OnPropertyChanged( nameof( RcCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the rc.
        /// </summary>
        /// <value>
        /// The name of the rc.
        /// </value>
        public string RcName
        {
            get
            {
                return _rcName;
            }
            private protected set
            {
                if( _rcName != value )
                {
                    _rcName = value;
                    OnPropertyChanged( nameof( RcName ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        public string ProgramAreaCode
        {
            get
            {
                return _programAreaCode;
            }
            private protected set
            {
                if( _programAreaCode != value )
                {
                    _programAreaCode = value;
                    OnPropertyChanged( nameof( ProgramAreaCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the program area.
        /// </summary>
        /// <value>
        /// The name of the program area.
        /// </value>
        public string ProgramAreaName
        {
            get
            {
                return _programAreaName;
            }
            private protected set
            {
                if( _programAreaName != value )
                {
                    _programAreaName = value;
                    OnPropertyChanged( nameof( BudgetLevel ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.PRC" /> class.
        /// </summary>
        protected PRC( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.PRC" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected PRC( IQuery query )
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
        /// <see cref="T:Badger.PRC" /> class.
        /// </summary>
        /// <param name="builder">The data builder.</param>
        protected PRC( IDataService builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
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
        /// Initializes a new instance of the <see cref="T:Badger.PRC" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected PRC( DataRow dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
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

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.PRC" /> class.
        /// </summary>
        /// <param name="map">The map.</param>
        protected PRC( IDictionary<string, object> map )
        {
            _record = new DataGenerator( _source, map )?.Record;
            _map = _record.ToDictionary( );
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
    }
}