// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-27-2024
// ******************************************************************************************
// <copyright file="AllowanceHolder.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  2024  Terry D. Eppler
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   AllowanceHolder.cs
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
    /// Generally, an organized private protected set of activities directed toward a common purpose or goal that an agency
    /// undertakes or proposes to carry out its responsibilities. Because the term has many uses in
    /// practice, it does not have a well-defined, standard meaning in the legislative process. It is used
    /// to describe an agency’s mission, functions, activities, services, projects, and processes. An
    /// Allowance Holder is also an element within a budget account. For annually appropriated accounts,
    /// the Office of Management and Budget (OMB) and agencies identify PPAs by reference to committee
    /// reports and budget justifications; for permanent appropriations, OMB and agencies identify
    /// Allowance Holders by the program and financing schedules that the President provides in the
    /// “Detailed Budget Estimates” in the budget submission for the relevant fiscal year. Program activity
    /// structures are intended to provide a meaningful representation of the operations financed by a
    /// specific budget account—usually by project, activity, or organization. 31 U.S.C. 1514 provides that
    /// agency allotments will be established at the highest practical level. At the EPA, OMB apportions
    /// the appropriated funds to the EPA OB Director as the agency’s single Allowance Holder. Note there
    /// is a separate allotment for every appropriation (Treasury account symbol) for every fiscal year.
    /// The OB Director retains the original signed apportionment documents on behalf of the agency. This
    /// is the agency’s formal designation regarding “Administrative Subdivisions of Funds.” The agency
    /// does not have sub-allotments. The one restriction on the agency’s allotment is that it cannot
    /// exceed the amount of the apportionment. At the Regional level, Allowance Holder's further divide
    /// the Agency's funding with the Regional Administrator being identified as the primary regional
    /// Allowance Holder.
    /// </summary>
    /// <seealso cref="T:Badger.ISource" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameterInConstructor" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class AllowanceHolder : DataUnit
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AllowanceHolder" />
        /// class.
        /// </summary>
        public AllowanceHolder( )
            : base( )
        {
            _source = Source.AllowanceHolders;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AllowanceHolders" />
        /// class.
        /// </summary>
        /// <param name="dataBuilder"> The dataBuilder. </param>
        public AllowanceHolder( DataGenerator dataBuilder )
            : base( dataBuilder )
        {
            _record = dataBuilder.Record;
            _id = int.Parse( _record[ "AllowanceHoldersId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AllowanceHolders" />
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public AllowanceHolder( IQuery query )
            : base( query )
        {
            _record = new DataGenerator( query )?.Record;
            _id = int.Parse( _record[ "AllowanceHoldersId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AllowanceHolders" />
        /// class.
        /// </summary>
        /// <param name="data"> The Data. </param>
        public AllowanceHolder( DataRow data )
            : base( data )
        {
            _record = data;
            _id = int.Parse( data[ "AllowanceHoldersId" ].ToString( ) ?? "0" );
            _name = data[ "Name" ].ToString( );
            _code = data[ "Code" ].ToString( );
            _map = data.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AllowanceHolders" />
        /// class.
        /// </summary>
        /// <param name="ahCode"> The ahcode. </param>
        public AllowanceHolder( string ahCode )
            : base( )
        {
            _record = new DataGenerator( Source, SetArgs( ahCode ) )?.Record;
            _id = int.Parse( _record[ "AllowanceHoldersId" ].ToString( ) ?? "0" );
            _name = _record[ "Name" ].ToString( );
            _code = _record[ "Code" ].ToString( );
            _map = _record.ToDictionary( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.AllowanceHolder" />
        /// class.
        /// </summary>
        /// <param name="allowanceHolder"> The allowance holder. </param>
        public AllowanceHolder( AllowanceHolder allowanceHolder )
            : base( )
        {
            _id = allowanceHolder.ID;
            _name = allowanceHolder.Name;
            _code = allowanceHolder.Code;
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns> </returns>
        private IDictionary<string, object> SetArgs( string code )
        {
            if( !string.IsNullOrEmpty( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.AhCode}" ] = code
                    };
                }
                catch( Exception ex )
                {
                    AllowanceHolder.Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }
    }
}