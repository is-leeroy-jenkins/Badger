﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="ViewModel.cs" company="Terry D. Eppler">
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
//   ViewModel.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

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
    public class ViewModel : ObservableCollection<IView>
    {
        /// <summary>
        /// The count
        /// </summary>
        private protected int _count;

        /// <summary>
        /// The current
        /// </summary>
        private protected DataRow _current;

        /// <summary>
        /// The data
        /// </summary>
        private protected ObservableCollection<DataRow> _rows;

        /// <summary>
        /// The data
        /// </summary>
        private protected ObservableCollection<IView> _data;

        /// <summary>
        /// The views
        /// </summary>
        private protected BindingList<IView> _views;

        /// <summary>
        /// The data
        /// </summary>
        private protected BindingList<DataRow> _items;

        /// <summary>
        /// The table name
        /// </summary>
        private protected string _tableName;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.View" /> class.
        /// </summary>
        public ViewModel( )
            : base( )
        {
            _data = new ObservableCollection<IView>( );
            _views = new BindingList<IView>( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="name">The category.</param>
        /// <param name="value">The value.</param>
        public virtual void Add( int index, string name, double value = 0.0 )
        {
            try
            {
                ThrowIf.Null( name, nameof( name ) );
                var _view = new View( index, name, value );
                Items.Add( _view );
                _data.Add( _view );
                _views.Add( _view );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        public virtual new void Add( IView view )
        {
            try
            {
                ThrowIf.Null( view.Name, nameof( view.Name ) );
                var _view = new View( view );
                Items.Add( _view );
                _views.Add( _view );
                _data.Add( _view );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        public virtual new void Remove( IView view )
        {
            try
            {
                if( Items.Contains( view ) )
                {
                    var _index = Items.IndexOf( view );
                    Items.RemoveAt( _index );
                    _views.Remove( view );
                    _data.RemoveAt( _index );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Cycles this instance.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IEnumerator<IView> IterItems( )
        {
            foreach( var _item in Items )
            {
                yield return _item;
            }
        }

        /// <summary>
        /// Creates the views.
        /// </summary>
        /// <returns></returns>
        private protected BindingList<IView> CreateViewList( )
        {
            try
            {
                if( _data != null )
                {
                    foreach( var _view in _data )
                    {
                        _views.Add( _view );
                    }

                    return ( _views?.Any( ) == true )
                        ? _views
                        : default( BindingList<IView> );
                }

                return default( BindingList<IView> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( BindingList<IView> );
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