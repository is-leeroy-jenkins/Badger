// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="PivotViewModel.cs" company="Terry D. Eppler">
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
//   PivotViewModel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.ComponentModel.INotifyPropertyChanged" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public class PivotViewModel : ViewModel
    {
        /// <summary>
        /// The field header
        /// </summary>
        private protected string _fieldHeader;

        /// <summary>
        /// The mapping field name
        /// </summary>
        private protected string _mappingFieldName;

        /// <summary>
        /// The total header
        /// </summary>
        private protected string _totalHeader;

        /// <inheritdoc />
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        protected override event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the field header.
        /// </summary>
        /// <value>
        /// The field header.
        /// </value>
        public string FieldHeader
        {
            get
            {
                return _fieldHeader;
            }
            set
            {
                if( _fieldHeader != value )
                {
                    _fieldHeader = value;
                    OnPropertyChanged( nameof( FieldHeader ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the mappig field.
        /// </summary>
        /// <value>
        /// The name of the mappig field.
        /// </value>
        public string MappigFieldName
        {
            get
            {
                return _mappingFieldName;
            }
            set
            {
                if( _fieldHeader != value )
                {
                }
            }
        }

        /// <summary>
        /// Gets or sets the total header.
        /// </summary>
        /// <value>
        /// The total header.
        /// </value>
        public string TotalHeader
        {
            get
            {
                return _totalHeader;
            }
            set
            {
                if( _totalHeader != value )
                {
                    _totalHeader = value;
                    OnPropertyChanged( nameof( TotalHeader ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.PivotModel" /> class.
        /// </summary>
        public PivotViewModel( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Badger.PivotModel" /> class.
        /// </summary>
        /// <param name="fieldHeader">The field header.</param>
        /// <param name="mappingFieldName">Name of the mapping field.</param>
        /// <param name="totalHeader">The total header.</param>
        public PivotViewModel( string fieldHeader, string mappingFieldName, string totalHeader )
        {
            _fieldHeader = fieldHeader;
            _mappingFieldName = mappingFieldName;
            _totalHeader = totalHeader;
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged( [ CallerMemberName ] string propertyName = null )
        {
            var _handler = PropertyChanged;
            _handler?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}