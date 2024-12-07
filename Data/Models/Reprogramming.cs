// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="Reprogramming.cs" company="Terry D. Eppler">
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
//   Reprogramming.cs
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
    /// <seealso cref="T:Badger.Transfer" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    public class Reprogramming : Transfer
    {
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
                _budgetLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the document prefix.
        /// </summary>
        /// <value>
        /// The document prefix.
        /// </value>
        public string DocPrefix
        {
            get
            {
                return _docPrefix;
            }
            private protected set
            {
                _docPrefix = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        public string DocType
        {
            get
            {
                return _docType;
            }
            private protected set
            {
                _docType = value;
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
                _rpioCode = value;
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
                _rpioName = value;
            }
        }

        /// <summary>
        /// Gets or sets the reprogramming number.
        /// </summary>
        /// <value>
        /// The reprogramming number.
        /// </value>
        public string ReprogrammingNumber
        {
            get
            {
                return _resourceType;
            }
            private protected set
            {
                _reprogrammingNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the control number.
        /// </summary>
        /// <value>
        /// The control number.
        /// </value>
        public string ControlNumber
        {
            get
            {
                return _controlNumber;
            }
            private protected set
            {
                _controlNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the processed date.
        /// </summary>
        /// <value>
        /// The processed date.
        /// </value>
        public DateTime ProcessedDate
        {
            get
            {
                return _processedDate;
            }
            private protected set
            {
                _processedDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the quarter.
        /// </summary>
        /// <value>
        /// The quarter.
        /// </value>
        public string Quarter
        {
            get
            {
                return _quarter;
            }
            private protected set
            {
                _quarter = value;
            }
        }

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        /// <value>
        /// The line.
        /// </value>
        public string Line
        {
            get
            {
                return _line;
            }
            private protected set
            {
                _line = value;
            }
        }

        /// <summary>
        /// Gets or sets the subline.
        /// </summary>
        /// <value>
        /// The subline.
        /// </value>
        public string Subline
        {
            get
            {
                return _subline;
            }
            private protected set
            {
                _subline = value;
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
                _ahCode = value;
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
                _ahName = value;
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
                _orgCode = value;
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
                _orgName = value;
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
                _rcCode = value;
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
                _rcName = value;
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
                _accountCode = value;
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
                _programAreaCode = value;
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
                return _programProjectName;
            }
            private protected set
            {
                _programAreaName = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the program project.
        /// </summary>
        /// <value>
        /// The name of the program project.
        /// </value>
        public string ProgramProjectName
        {
            get
            {
                return _programProjectName;
            }
            private protected set
            {
                _programProjectName = value;
            }
        }

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        public string ProgramProjectCode
        {
            get
            {
                return _programProjectCode;
            }
            private protected set
            {
                _programProjectCode = value;
            }
        }

        /// <summary>
        /// Gets or sets from to.
        /// </summary>
        /// <value>
        /// From to.
        /// </value>
        public string FromTo
        {
            get
            {
                return _fromTo;
            }
            private protected set
            {
                _fromTo = value;
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
                _bocCode = value;
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
                _bocName = value;
            }
        }

        /// <summary>
        /// Gets or sets the NPM code.
        /// </summary>
        /// <value>
        /// The NPM code.
        /// </value>
        public string NpmCode
        {
            get
            {
                return _npmCode;
            }
            private protected set
            {
                _npmCode = value;
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
            private protected set
            {
                _amount = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        /// <value>
        /// The type of the resource.
        /// </value>
        public string ResourceType
        {
            get
            {
                return _resourceType;
            }
            private protected set
            {
                _resourceType = value;
            }
        }

        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        /// <value>
        /// The purpose.
        /// </value>
        public string Purpose
        {
            get
            {
                return _purpose;
            }
            private protected set
            {
                _purpose = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Reprogrammings" /> class.
        /// </summary>
        public Reprogramming( )
            : base( )
        {
            _source = Source.Transfers;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Reprogrammings" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public Reprogramming( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _id = int.Parse( _record[ "TransfersId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
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
            _programProjectCode = _record[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = _record[ "ProgramProjectName" ]?.ToString( );
            _fromTo = _record[ "FromTo" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0" );
            _resourceType = _record[ "ResourceType" ]?.ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ]?.ToString( ) );
            _quarter = _record[ "Quarter" ]?.ToString( );
            _reprogrammingNumber = _record[ "ReprogrammingNumber" ]?.ToString( );
            _controlNumber = _record[ "ControlNumber" ]?.ToString( );
            _line = _record[ "Line" ]?.ToString( );
            _subline = _record[ "Subline" ]?.ToString( );
            _purpose = _record[ "Purpose" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Reprogrammings" /> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public Reprogramming( DataGenerator builder )
            : base( builder )
        {
            _record = builder.Record;
            _id = int.Parse( _record[ "TransfersId" ]?.ToString( ) ?? "0" );
            _bfy = _record[ "BFY" ]?.ToString( );
            _efy = _record[ "EFY" ]?.ToString( );
            _fundCode = _record[ "FundCode" ]?.ToString( );
            _fundName = _record[ "FundName" ]?.ToString( );
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
            _programProjectCode = _record[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = _record[ "ProgramProjectName" ]?.ToString( );
            _fromTo = _record[ "FromTo" ]?.ToString( );
            _amount = double.Parse( _record[ "Amount" ]?.ToString( ) ?? "0" );
            _resourceType = _record[ "ResourceType" ]?.ToString( );
            _processedDate = DateTime.Parse( _record[ "ProcessedDate" ]?.ToString( ) );
            _quarter = _record[ "Quarter" ]?.ToString( );
            _reprogrammingNumber = _record[ "ReprogrammingNumber" ]?.ToString( );
            _controlNumber = _record[ "ControlNumber" ]?.ToString( );
            _line = _record[ "Line" ]?.ToString( );
            _subline = _record[ "Subline" ]?.ToString( );
            _purpose = _record[ "Purpose" ]?.ToString( );
            _bocCode = _record[ "BocCode" ]?.ToString( );
            _bocName = _record[ "BocName" ]?.ToString( );
            _programAreaCode = _record[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = _record[ "ProgramAreaName" ]?.ToString( );
            _npmCode = _record[ "NpmCode" ]?.ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Reprogramming" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public Reprogramming( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = int.Parse( dataRow[ "TransfersId" ]?.ToString( ) ?? "0" );
            _bfy = dataRow[ "BFY" ]?.ToString( );
            _efy = dataRow[ "EFY" ]?.ToString( );
            _fundCode = dataRow[ "FundCode" ]?.ToString( );
            _fundName = dataRow[ "FundName" ]?.ToString( );
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
            _programProjectCode = dataRow[ "ProgramProjectCode" ]?.ToString( );
            _programProjectName = dataRow[ "ProgramProjectName" ]?.ToString( );
            _fromTo = dataRow[ "FromTo" ]?.ToString( );
            _amount = double.Parse( dataRow[ "Amount" ]?.ToString( ) ?? "0" );
            _resourceType = dataRow[ "ResourceType" ]?.ToString( );
            _processedDate = DateTime.Parse( dataRow[ "ProcessedDate" ]?.ToString( ) );
            _quarter = dataRow[ "Quarter" ]?.ToString( );
            _reprogrammingNumber = dataRow[ "ReprogrammingNumber" ]?.ToString( );
            _controlNumber = dataRow[ "ControlNumber" ]?.ToString( );
            _line = dataRow[ "Line" ]?.ToString( );
            _subline = dataRow[ "Subline" ]?.ToString( );
            _purpose = dataRow[ "Purpose" ]?.ToString( );
            _bocCode = dataRow[ "BocCode" ]?.ToString( );
            _bocName = dataRow[ "BocName" ]?.ToString( );
            _programAreaCode = dataRow[ "ProgramAreaCode" ]?.ToString( );
            _programAreaName = dataRow[ "ProgramAreaName" ]?.ToString( );
            _npmCode = dataRow[ "NpmCode" ]?.ToString( );
            _purpose = dataRow[ "Purpose" ].ToString( );
            _map = dataRow.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Reprogrammings" /> class.
        /// </summary>
        /// <param name="reprogramming">The reprogramming.</param>
        public Reprogramming( Reprogramming reprogramming )
        {
            ID = reprogramming.ID;
            BFY = reprogramming.BFY;
            FundCode = reprogramming.FundCode;
            FundName = reprogramming.FundName;
            BudgetLevel = reprogramming.BudgetLevel;
            RpioCode = reprogramming.RpioCode;
            RpioName = reprogramming.RpioName;
            AhCode = reprogramming.AhCode;
            AhName = reprogramming.AhName;
            OrgCode = reprogramming.OrgCode;
            OrgName = reprogramming.OrgName;
            AccountCode = reprogramming.AccountCode;
            ProgramProjectCode = reprogramming.ProgramAreaCode;
            ProgramProjectName = reprogramming.ProgramProjectName;
            ProgramAreaCode = reprogramming.ProgramAreaCode;
            ProgramAreaName = reprogramming.ProgramAreaName;
            FromTo = reprogramming.FromTo;
            Amount = reprogramming.Amount;
            ResourceType = reprogramming.ResourceType;
            ProcessedDate = reprogramming.ProcessedDate;
            Quarter = reprogramming.Quarter;
            ReprogrammingNumber = reprogramming.ReprogrammingNumber;
            ControlNumber = reprogramming.ControlNumber;
            Line = reprogramming.Line;
            Subline = reprogramming.Subline;
            Purpose = reprogramming.Purpose;
            BocCode = reprogramming.BocCode;
            BocName = reprogramming.BocName;
            NpmCode = reprogramming.NpmCode;
        }
    }
}