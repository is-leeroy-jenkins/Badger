// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="BudgetAccount.cs" company="Terry D. Eppler">
//    Badger is budget execution and data analysis tool for EPA Analysts
//    based on WPF, NET6.0, and is written in C-Sharp.
// 
//     Copyright ©  2020, 2022, 2204 Terry D. Eppler
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
    using ControlzEx.Standard;

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
                if(_activityCode != value)
                {
                    _activityCode = value;
                    OnPropertyChanged(nameof(ActivityCode));
                }
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
                if( _activityName != value )
                {
                    _activityName = value;
                    OnPropertyChanged( nameof( ActivityName ) );
                }
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
                if( _npmCode != value )
                {
                    _npmCode = value;
                    OnPropertyChanged( nameof( NpmCode ) );
                }
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
                if( _npmName != value )
                {
                    _npmName = value;
                    OnPropertyChanged( nameof( NpmName ) );
                }
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
                if( _goalCode != value )
                {
                    _goalCode = value;
                    OnPropertyChanged( nameof( GoalCode ) );
                }
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
                if(_goalName != value)
                {
                    _goalName = value;
                    OnPropertyChanged(nameof(GoalName));
                }
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
                if(_objectiveCode != value)
                {
                    _objectiveCode = value;
                    OnPropertyChanged(nameof(ObjectiveCode));
                }
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
                if(_objectiveName != value)
                {
                    _objectiveName = value;
                    OnPropertyChanged(nameof(ObjectiveName));
                }
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
                if(_programProjectCode != value)
                {
                    _programProjectCode = value;
                    OnPropertyChanged(nameof(ProgramProjectCode));
                }
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
                if( _programProjectName != value )
                {
                    _programProjectName = value;
                    OnPropertyChanged( nameof( ProgramProjectName ) );
                }
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
        protected BudgetAccount( IDataService dataBuilder )
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