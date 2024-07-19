// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-18-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-18-2024
// ******************************************************************************************
// <copyright file="ViewModel.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporitng application
//    for EPA Analysts.
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
    public class ViewModel : ObservableCollection<View>
    {
        /// <summary>
        /// The data
        /// </summary>
        private protected ObservableCollection<View> _data;

        /// <summary>
        /// The measure
        /// </summary>
        private protected string _measure;

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public ObservableCollection<View> Data
        {
            get
            {
                return _data;
            }
            private protected set
            {
                _data = value;
            }
        }

        /// <summary>
        /// Gets the number of elements actually contained in the
        /// <see cref="T:System.Collections.ObjectModel.Collection`1" />.
        /// </summary>
        public new int Count
        {
            get
            {
                return Items.Count;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.View" /> class.
        /// </summary>
        public ViewModel( )
            : base( )
        {
            _data = new ObservableCollection<View>( );
        }

        public void Add( int index, string category, double value = 0 )
        {
            try
            {
                ThrowIf.Null( category, nameof( category ) );
                var _view = new View( index, category, "Amount", value );
                Items.Add( _view );
                _data.Add( _view );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name = "index" > </param>
        /// <param name="category">The name.</param>
        /// <param name = "measure" > </param>
        /// <param name="value">The value.</param>
        public void Add( int index, string category, string measure, double value = 0.0 )
        {
            try
            {
                ThrowIf.Null( category, nameof( category ) );
                var _view = new View( index, category, measure, value );
                Items.Add( _view );
                _data.Add( _view );
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
                ThrowIf.Null( view.Category, nameof( view.Category ) );
                var _view = new View( view );
                Items.Add( _view );
                _data.Add( _view );
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
                    _data.RemoveAt( _index );
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
        public IEnumerator<View> IterItems( )
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