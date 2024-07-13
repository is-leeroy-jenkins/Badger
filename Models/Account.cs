// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-13-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-13-2024
// ******************************************************************************************
// <copyright file="Account.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application
//    for the US Environmental Protection Agency (US EPA).
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
//    You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   Account.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    /// <seealso cref="T:Badger.PRC" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameterInConstructor" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class Account : PRC
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Account"/>
        /// class.
        /// </summary>
        public Account( )
            : base( )
        {
            _source = Source.Accounts;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Account"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public Account( IQuery query )
            : base( query )
        {
            _source = query.Source;
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( _record[ "AccountsId" ]?.ToString( ) );
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
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Account"/>
        /// class.
        /// </summary>
        /// <param name="builder"> The data builder. </param>
        public Account( IDataModel builder )
            : base( builder )
        {
            _source = Source.Accounts;
            _record = builder.Record;
            _id = int.Parse( _record[ "AccountsId" ]?.ToString( ) );
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
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Account"/>
        /// class.
        /// </summary>
        /// <param name="dataRow"> The data row. </param>
        public Account( DataRow dataRow )
            : base( dataRow )
        {
            _source = Source.Accounts;
            _record = dataRow;
            _id = int.Parse( dataRow[ "AccountsId" ]?.ToString( ) );
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
            _map = dataRow?.ToDictionary( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Account"/>
        /// class.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        public Account( string code )
            : base( )
        {
            _record = new DataGenerator( Source, GetArgs( code ) )?.Record;
            _id = int.Parse( _record[ "AccountsId" ]?.ToString( ) );
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
            _map = _record?.ToDictionary( );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Account"/>
        /// class.
        /// </summary>
        /// <param name="account"> The account. </param>
        public Account( Account account )
            : base( )
        {
            _id = account.ID;
            _goalCode = account.GoalCode;
            _goalName = account.GoalName;
            _objectiveCode = account.ObjectiveCode;
            _objectiveName = account.ObjectiveName;
            _npmCode = account.NpmCode;
            _npmName = account.NpmName;
            _programProjectCode = account.ProgramProjectCode;
            _programProjectName = account.ProgramProjectName;
            _activityCode = account.ActivityCode;
            _activityName = account.ActivityName;
            _map = account.Map;
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>
        /// </returns>
        public Account GetAccount( )
        {
            try
            {
                return (Account)MemberwiseClone( );
            }
            catch( Exception ex )
            {
                Account.Fail( ex );
                return default( Account );
            }
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns> </returns>
        private protected IDictionary<string, object> GetArgs( string code )
        {
            try
            {
                ThrowIf.Null( code, nameof( code ) );
                return new Dictionary<string, object>
                {
                    [ "Code" ] = code
                };
            }
            catch( Exception ex )
            {
                Account.Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}