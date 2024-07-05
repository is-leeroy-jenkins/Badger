// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="FiscalYear.cs" company="Terry D. Eppler">
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
//   FiscalYear.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.CalendarYears" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public abstract class FiscalYear : CalendarYear
    {
        /// <summary>
        /// The bfy
        /// </summary>
        private protected string _bfy;

        /// <summary>
        /// The efy
        /// </summary>
        private protected string _efy;

        /// <summary>
        /// The first year
        /// </summary>
        private protected string _firstYear;

        /// <summary>
        /// The last year
        /// </summary>
        private protected string _lastYear;

        /// <summary>
        /// The expiring year
        /// </summary>
        private protected string _expiringYear;

        /// <summary>
        /// The input year
        /// </summary>
        private protected string _inputYear;

        /// <summary>
        /// The start date
        /// </summary>
        private protected DateTime _startDate;

        /// <summary>
        /// The end date
        /// </summary>
        private protected DateTime _endDate;

        /// <summary>
        /// The cancellation date
        /// </summary>
        private protected DateTime _cancellationDate;

        /// <summary>
        /// The expiration date
        /// </summary>
        private protected DateTime _expirationDate;

        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        public string BFY
        {
            get
            {
                return _bfy;
            }
            private protected set
            {
                _bfy = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the efy.
        /// </summary>
        /// <value>
        /// The efy.
        /// </value>
        public string EFY
        {
            get
            {
                return _efy;
            }
            private protected set
            {
                _efy = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the first year.
        /// </summary>
        /// <value>
        /// The first year.
        /// </value>
        public string FirstYear
        {
            get
            {
                return _firstYear;
            }
            private protected set
            {
                _firstYear = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the last year.
        /// </summary>
        /// <value>
        /// The last year.
        /// </value>
        public string LastYear
        {
            get
            {
                return _lastYear;
            }
            private protected set
            {
                _lastYear = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the expiring year.
        /// </summary>
        /// <value>
        /// The expiring year.
        /// </value>
        public string ExpiringYear
        {
            get
            {
                return _expiringYear;
            }
            private protected set
            {
                _expiringYear = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the input year.
        /// </summary>
        /// <value>
        /// The input year.
        /// </value>
        public string InputYear
        {
            get
            {
                return _inputYear;
            }
            private protected set
            {
                _inputYear = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            private protected set
            {
                _startDate = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            private protected set
            {
                _endDate = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the cancellation date.
        /// </summary>
        /// <value>
        /// The cancellation date.
        /// </value>
        public DateTime CancellationDate
        {
            get
            {
                return _cancellationDate;
            }
            private protected set
            {
                _cancellationDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
            private protected set
            {
                _expirationDate = value;
            }
        }

        /// <summary>
        /// Determines whether this instance is current.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is current; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsCurrent( )
        {
            try
            {
                return BFY == CurrentYear.ToString( );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( bool );
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name="bfy">The bfy.</param>
        /// <returns></returns>
        private protected IDictionary<string, object> SetArgs
            ( string bfy )
        {
            if( !string.IsNullOrEmpty( bfy )
               && ( bfy.Length == 4 )
               && ( int.Parse( bfy ) > 2018 )
               && ( int.Parse( bfy ) < 2040 ) )
            {
                try
                {
                    return new Dictionary<string, object> 
                    {
                        [ "BFY" ] = bfy
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
        /// Initializes a new instance of the
        /// <see cref="FiscalYear"/> class.
        /// </summary>
        /// <inheritdoc />
        protected FiscalYear( ) 
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FiscalYear"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        protected FiscalYear( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FiscalYear"/> class.
        /// </summary>
        /// <param name="builder"></param>
        /// <inheritdoc />
        protected FiscalYear( IDataModel builder )
            : base( builder )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="FiscalYear"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <inheritdoc />
        protected FiscalYear( DataRow dataRow )
            : base( dataRow )
        {
        }
    }
}