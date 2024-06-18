// ******************************************************************************************
//     Assembly:             Badger
//     Author:                  Terry D. Eppler
//     Created:                 04-20-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        04-20-2024
// ******************************************************************************************
// <copyright file="Terry Eppler" company="Terry D. Eppler">
//    Badger is a small Federal Budget, Finance, and Accounting data management
//    application for analysts with the US Environmental Protection Agency (US EPA).
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
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   BudgetAccount.cs
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
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    public abstract class BudgetAccount : BudgetUnit
    {
        /// <summary>
        /// The goal code
        /// </summary>
        private protected string _goalCode;
        
        /// <summary>
        /// The goal name
        /// </summary>
        private protected string _goalName;
        
        /// <summary>
        /// The objective code
        /// </summary>
        private protected string _objectiveCode;
        
        /// <summary>
        /// The objective name
        /// </summary>
        private protected string _objectiveName;

        /// <summary>
        /// The NPM code
        /// </summary>
        private protected string _npmCode;

        /// <summary>
        /// The NPM name
        /// </summary>
        private protected string _npmName;

        /// <summary>
        /// The program project code
        /// </summary>
        private protected string _programProjectCode;

        /// <summary>
        /// The program project name
        /// </summary>
        private protected string _programProjectName;

        /// <summary>
        /// The activity coede
        /// </summary>
        private protected string _activityCode;

        /// <summary>
        /// The activity name
        /// </summary>
        private protected string _activityName;

        /// <summary>
        /// Gets or sets the activity code.
        /// </summary>
        /// <value>
        /// The activity code.
        /// </value>
        public string ActivityCode
        {
            get
            {
                return _activityCode;
            }
            private protected set
            {
                _activityCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        /// <value>
        /// The name of the activity.
        /// </value>
        public string ActivityName
        {
            get
            {
                return _activityName;
            }
            private protected set
            {
                _activityName = value;
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
        /// Gets or sets the name of the NPM.
        /// </summary>
        /// <value>
        /// The name of the NPM.
        /// </value>
        public string NpmName
        {
            get
            {
                return _npmName;
            }
            private protected set
            {
                _npmName = value;
            }
        }

        /// <summary>
        /// Gets or sets the goal code.
        /// </summary>
        /// <value>
        /// The goal code.
        /// </value>
        public string GoalCode
        {
            get
            {
                return _goalCode;
            }
            private protected set
            {
                _goalCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the goal.
        /// </summary>
        /// <value>
        /// The name of the goal.
        /// </value>
        public string GoalName
        {
            get
            {
                return _goalName;
            }
            private protected set
            {
                _goalName = value;
            }
        }

        /// <summary>
        /// Gets or sets the objective code.
        /// </summary>
        /// <value>
        /// The objective code.
        /// </value>
        public string ObjectiveCode
        {
            get
            {
                return _objectiveCode;
            }
            private protected set
            {
                _objectiveCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the objective.
        /// </summary>
        /// <value>
        /// The name of the objective.
        /// </value>
        public string ObjectiveName
        {
            get
            {
                return _objectiveName;
            }
            private protected set
            {
                _objectiveName = value;
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

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.BudgetAccount" /> class.
        /// </summary>
        protected BudgetAccount( ) 
            : base( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetAccount"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <inheritdoc />
        protected BudgetAccount( IQuery query ) 
            : base( query )
        {
            _source = query.Source;
            _record = new DataGenerator( query ).Record;
            _goalCode = _record[ "GoalCode" ].ToString( );
            _goalName = _record[ "GoalName" ].ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ].ToString( );
            _objectiveName = _record[ "ObjectiveName" ].ToString( );
            _npmCode = _record[ "NpmCode" ].ToString( );
            _npmName = _record[ "NpmName" ].ToString( );
            _programProjectCode = _record[ "ProgramProjectCode" ].ToString( );
            _programProjectName = _record[ "ProgramProjectName" ].ToString( );
            _activityCode = _record[ "ActivityCode" ].ToString( );
            _activityName = _record[ "ActivityName" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetAccount"/> class.
        /// </summary>
        /// <param name="dataBuilder">The query.</param>
        /// <inheritdoc />
        protected BudgetAccount( IDataModel dataBuilder ) 
            : base( dataBuilder )
        {
            _source = dataBuilder.Source;
            _record = dataBuilder.Record;
            _goalCode = _record[ "GoalCode" ].ToString( );
            _goalName = _record[ "GoalName" ].ToString( );
            _objectiveCode = _record[ "ObjectiveCode" ].ToString( );
            _objectiveName = _record[ "ObjectiveName" ].ToString( );
            _npmCode = _record[ "NpmCode" ].ToString( );
            _npmName = _record[ "NpmName" ].ToString( );
            _programProjectCode = _record[ "ProgramProjectCode" ].ToString( );
            _programProjectName = _record[ "ProgramProjectName" ].ToString( );
            _activityCode = _record[ "ActivityCode" ].ToString( );
            _activityName = _record[ "ActivityName" ].ToString( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetAccount"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <inheritdoc />
        protected BudgetAccount( DataRow dataRow ) 
            : base( dataRow )
        {
            _record = dataRow;
            _goalCode = dataRow[ "GoalCode" ].ToString( );
            _goalName = dataRow[ "GoalName" ].ToString( );
            _objectiveCode = dataRow[ "ObjectiveCode" ].ToString( );
            _objectiveName = dataRow[ "ObjectiveName" ].ToString( );
            _npmCode = dataRow[ "NpmCode" ].ToString( );
            _npmName = dataRow[ "NpmName" ].ToString( );
            _programProjectCode = dataRow[ "ProgramProjectCode" ].ToString( );
            _programProjectName = dataRow[ "ProgramProjectName" ].ToString( );
            _activityCode = dataRow[ "ActivityCode" ].ToString( );
            _activityName = dataRow[ "ActivityName" ].ToString( );
        }
    }
}