// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="DataRuleDescription.cs" company="Terry D. Eppler">
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
//   DataRuleDescription.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    /// <seealso cref="T:Badger.DataUnit" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class DataRuleDescription : DataUnit
    {
        /// <summary>
        /// The schedule
        /// </summary>
        private string _schedule;

        /// <summary>
        /// The line number
        /// </summary>
        private string _lineNumber;

        /// <summary>
        /// The rule number
        /// </summary>
        private string _ruleNumber;

        /// <summary>
        /// The rule description
        /// </summary>
        private string _ruleDescription;

        /// <summary>
        /// The schedule order
        /// </summary>
        private string _scheduleOrder;

        /// <summary>
        /// Gets or sets the schedule.
        /// </summary>
        /// <value>
        /// The schedule.
        /// </value>
        public string Schedule
        {
            get
            {
                return _schedule;
            }
            private protected set
            {
                _schedule = value;
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
                return _lineNumber;
            }
            private protected set
            {
                _lineNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the rule number.
        /// </summary>
        /// <value>
        /// The rule number.
        /// </value>
        public string RuleNumber
        {
            get
            {
                return _ruleNumber;
            }
            private protected set
            {
                _ruleNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the rule description.
        /// </summary>
        /// <value>
        /// The rule description.
        /// </value>
        public string RuleDescription
        {
            get
            {
                return _ruleDescription;
            }
            private protected set
            {
                _ruleDescription = value;
            }
        }

        /// <summary>
        /// Gets or sets the schedule order.
        /// </summary>
        /// <value>
        /// The schedule order.
        /// </value>
        public string ScheduleOrder
        {
            get
            {
                return _scheduleOrder;
            }
            private protected set
            {
                _scheduleOrder = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DataRuleDescription" />
        /// class.
        /// </summary>
        public DataRuleDescription( )
            : base( )
        {
            _source = Source.DataRuleDescriptions;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DataRuleDescription" />
        /// class.
        /// </summary>
        /// <param name="query">The query.</param>
        public DataRuleDescription( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query ).Record;
            _map = _record.ToDictionary( );
            _schedule = _record[ "Schedule" ]?.ToString( );
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _ruleNumber = _record[ "RuleNumber" ]?.ToString( );
            _scheduleOrder = _record[ "ScheduleOrder" ]?.ToString( );
            _ruleDescription = _record[ "RuleDescription" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DataRuleDescription" />
        /// class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public DataRuleDescription( IDataService builder )
            : base( builder )
        {
            _record = builder.Record;
            _map = _record.ToDictionary( );
            _schedule = _record[ "Schedule" ]?.ToString( );
            _lineNumber = _record[ "LineNumber" ]?.ToString( );
            _ruleNumber = _record[ "RuleNumber" ]?.ToString( );
            _scheduleOrder = _record[ "ScheduleOrder" ]?.ToString( );
            _ruleDescription = _record[ "RuleDescription" ]?.ToString( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DataRuleDescription" />
        /// class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public DataRuleDescription( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _map = dataRow.ToDictionary( );
            _schedule = dataRow[ "Schedule" ]?.ToString( );
            _lineNumber = dataRow[ "LineNumber" ]?.ToString( );
            _ruleNumber = dataRow[ "RuleNumber" ]?.ToString( );
            _scheduleOrder = dataRow[ "ScheduleOrder" ]?.ToString( );
            _ruleDescription = dataRow[ "RuleDescription" ]?.ToString( );
        }
    }
}