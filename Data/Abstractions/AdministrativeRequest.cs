// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="AdministrativeRequest.cs" company="Terry D. Eppler">
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
//   AdministrativeRequest.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.DataUnit"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public abstract class AdministrativeRequest : DataUnit
    {
        /// <summary>
        /// The analyst
        /// </summary>
        private protected string _analyst;

        /// <summary>
        /// The rpio code
        /// </summary>
        private protected string _rpioCode;

        /// <summary>
        /// The document title
        /// </summary>
        private protected string _documentTitle;

        /// <summary>
        /// The amount
        /// </summary>
        private protected double _amount;

        /// <summary>
        /// The fund code
        /// </summary>
        private protected string _fundCode;

        /// <summary>
        /// The bfy
        /// </summary>
        private protected string _bfy;

        /// <summary>
        /// The status
        /// </summary>
        private protected string _status;

        /// <summary>
        /// The duration
        /// </summary>
        private protected double _duration;

        /// <summary>
        /// The processed date
        /// </summary>
        private protected DateTime _processedDate;

        /// <summary>
        /// The last activity date
        /// </summary>
        private protected DateTime _lastActivityDate;

        /// <summary>
        /// The in system
        /// </summary>
        private protected bool _inSystem;

        /// <summary>
        /// The request type
        /// </summary>
        private protected string _requestType;

        /// <summary>
        /// The comments
        /// </summary>
        private protected string _comments;

        /// <summary>
        /// The type code
        /// </summary>
        private protected string _typeCode;

        /// <summary>
        /// The decision
        /// </summary>
        private protected string _decision;

        /// <summary>
        /// Gets or sets the analyst.
        /// </summary>
        /// <value>
        /// The analyst.
        /// </value>
        public string Analyst
        {
            get
            {
                return _analyst;
            }
            private protected set
            {
                if( _analyst != value )
                {
                    _analyst = value;
                    OnPropertyChanged( nameof( Analyst ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the rpio code.
        /// </summary>
        /// <value>
        /// The rpio code.
        /// </value>
        public virtual string RpioCode
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
        /// Gets or sets the document title.
        /// </summary>
        /// <value>
        /// The document title.
        /// </value>
        public virtual string DocumentTitle
        {
            get
            {
                return _documentTitle;
            }
            private protected set
            {
                if( _documentTitle != value )
                {
                    _documentTitle = value;
                    OnPropertyChanged( nameof( DocumentTitle ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public virtual double Amount
        {
            get
            {
                return _amount;
            }
            private protected set
            {
                if( _amount != value )
                {
                    _amount = value;
                    OnPropertyChanged( nameof( Amount ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        public virtual string FundCode
        {
            get
            {
                return _fundCode;
            }
            private protected set
            {
                if( _fundCode != value )
                {
                    _fundCode = value;
                    OnPropertyChanged( nameof( FundCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        public virtual string BFY
        {
            get
            {
                return _bfy;
            }
            private protected set
            {
                if( _bfy != value )
                {
                    _bfy = value;
                    OnPropertyChanged( nameof( BFY ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public virtual string Status
        {
            get
            {
                return _status;
            }
            private protected set
            {
                if( _status != value )
                {
                    _status = value;
                    OnPropertyChanged( nameof( Status ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the original action date.
        /// </summary>
        /// <value>
        /// The original action date.
        /// </value>
        public virtual DateTime ProcessedDate
        {
            get
            {
                return _processedDate;
            }
            private protected set
            {
                if( _processedDate != value )
                {
                    _processedDate = value;
                    OnPropertyChanged( nameof( ProcessedDate ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the last action date.
        /// </summary>
        /// <value>
        /// The last action date.
        /// </value>
        public virtual DateTime LastActivityDate
        {
            get
            {
                return _lastActivityDate;
            }
            private protected set
            {
                if( _lastActivityDate != value )
                {
                    _lastActivityDate = value;
                    OnPropertyChanged( nameof( LastActivityDate ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public virtual double Duration
        {
            get
            {
                return _duration;
            }
            private protected set
            {
                if( _duration != value )
                {
                    _duration = value;
                    OnPropertyChanged( nameof( Duration ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the budget formulation system.
        /// </summary>
        /// <value>
        /// The budget formulation system.
        /// </value>
        public virtual bool InSystem
        {
            get
            {
                return _inSystem;
            }
            private protected set
            {
                if( _inSystem != value )
                {
                    _inSystem = value;
                    OnPropertyChanged( nameof( InSystem ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public virtual string Comments
        {
            get
            {
                return _comments;
            }
            private protected set
            {
                if( _comments != value )
                {
                    _comments = value;
                    OnPropertyChanged( nameof( Comments ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the request.
        /// </summary>
        /// <value>
        /// The type of the request.
        /// </value>
        public virtual string RequestType
        {
            get
            {
                return _requestType;
            }
            private protected set
            {
                if( _requestType != value )
                {
                    _requestType = value;
                    OnPropertyChanged( nameof( RequestType ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the type code.
        /// </summary>
        /// <value>
        /// The type code.
        /// </value>
        public virtual string TypeCode
        {
            get
            {
                return _typeCode;
            }
            private protected set
            {
                if( _typeCode != value )
                {
                    _typeCode = value;
                    OnPropertyChanged( nameof( TypeCode ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the decision.
        /// </summary>
        /// <value>
        /// The decision.
        /// </value>
        public virtual string Decision
        {
            get
            {
                return _decision;
            }
            private protected set
            {
                if( _decision != value )
                {
                    _decision = value;
                    OnPropertyChanged( nameof( Decision ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AdministrativeRequest" /> class.
        /// </summary>
        protected AdministrativeRequest( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AdministrativeRequest" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected AdministrativeRequest( IQuery query )
            : base( query )
        {
            _source = query.Source;
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AdministrativeRequest" /> class.
        /// </summary>
        /// <param name="dataBuilder">The query.</param>
        protected AdministrativeRequest( IDataService dataBuilder )
            : base( dataBuilder )
        {
            _source = dataBuilder.Source;
            _record = dataBuilder.Record;
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AdministrativeRequest" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected AdministrativeRequest( DataRow dataRow )
            : base( dataRow )
        {
            _source = Source.AdministrativeRequests;
            _record = dataRow;
            _map = _record.ToDictionary( );
        }
    }
}