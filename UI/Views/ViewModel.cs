// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 06-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        06-28-2024
// ******************************************************************************************
// <copyright file="ViewModel.cs" company="Terry D. Eppler">
//    Badger is a federal budget, accounting, and finance application for EPA analysts in WPF and
//    written in C#.
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
//   ViewModel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;

    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "WrongIndentSize" ) ]
    public class ViewModel : ObservableCollection<View>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.View" /> class.
        /// </summary>
        public ViewModel( )
        {
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void Add( string name, double value = 0.0 )
        {
            try
            {
                ThrowIf.Null( name, nameof( name ) );
                var _view = new View( name, value );
                Items.Add( _view );
            }
            catch( Exception _ex )
            { 
                Fail( _ex );
            }
        }

        /// <summary>
        /// Adds the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        public new void Add( View view )
        {
            try
            {
                ThrowIf.Null( view.Name, nameof( view.Name ) );
                var _view = new View( view );
                Items.Add( _view );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Removes the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        public new void Remove( View view )
        {
            try
            {
                if( Items.Contains( view ) )
                {
                    var _index = Items.IndexOf( view );
                    Items.RemoveAt( _index );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Cycles this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<View> Cycle( )
        {
            foreach( var _item in Items )
            {
                yield return _item;
            }
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