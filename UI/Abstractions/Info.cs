// ******************************************************************************************
//     Assembly:                Baby
//     Author:                  Terry D. Eppler
//     Created:                 09-10-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-10-2024
// ******************************************************************************************
// <copyright file="Info.cs" company="Terry D. Eppler">
// 
//     Baby is a light-weight, full-featured, web-browser built with .NET 6 and is written
//     in C#.  The baby browser is designed for budget execution and data analysis.
//     A tool for EPA analysts and a component that can be used for general browsing.
// 
//     Copyright ©  2020 Terry D. Eppler
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
//   Info.cs
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
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantJumpStatement" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "OutParameterValueIsAlwaysDiscarded.Global" ) ]
    public abstract class Info : INotifyPropertyChanged
    {
        /// <summary>
        /// The data row
        /// </summary>
        private protected int _index;

        /// <summary>
        /// The measure
        /// </summary>
        private protected string _name;

        /// <summary>
        /// The value
        /// </summary>
        private protected object _value;

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                if( _value != value )
                {
                    _value = value;
                    OnPropertyChanged( nameof( Value ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                if( _index != value )
                {
                    _index = value;
                    OnPropertyChanged( nameof( Index ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if( _name != value )
                {
                    _name = value;
                    OnPropertyChanged( nameof( Name ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        protected Info( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="name">The name.</param>
        protected Info( int index, string name )
        {
            _index = index;
            _name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        protected Info( Info info )
        {
            _index = info.Index;
            _name = info.Name;
        }

        /// <inheritdoc />
        /// <summary>
        /// Deconstructs the specified identifier.
        /// </summary>
        /// <param name="index">The identifier.</param>
        /// <param name="name">The x.</param>
        public virtual void Deconstruct( out double index, out string name )
        {
            index = _index;
            name = _name;
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

        /// <inheritdoc />
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" />
        /// that represents this instance.
        /// </returns>
        public override string ToString( )
        {
            return string.IsNullOrEmpty( _name )
                ? _name
                : string.Empty;
        }

        /// <summary>
        /// Fails the specified _ex.
        /// </summary>
        /// <param name="_ex">The _ex.</param>
        private protected void Fail( Exception _ex )
        {
            var _error = new ErrorWindow( _ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}