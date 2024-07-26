// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
//
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
// ******************************************************************************************
// <copyright file="${File.FileName}" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  ${CurrentDate.Year}  Terry D. Eppler
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
//   ${File.FileName}
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [SuppressMessage( "ReSharper", "UnusedType.Global" )]
    [SuppressMessage( "ReSharper", "RedundantJumpStatement" )]
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" )]
    [SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" )]
    [SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" )]
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    [SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" )]
    [SuppressMessage( "ReSharper", "MemberCanBeInternal" )]
    [SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" )]
    [SuppressMessage( "ReSharper", "ConvertToAutoProperty" )]
    public abstract class ViewBase : ObservableCollection<IModel>, IViewModel
    {
        /// <summary>
        /// The data
        /// </summary>
        private protected ObservableCollection<IModel> _data;

        /// <summary>
        /// The views
        /// </summary>
        private protected BindingList<IModel> _views;

        /// <summary>
        /// The columns
        /// </summary>
        private protected IList<string> _fields;

        /// <summary>
        /// The columns
        /// </summary>
        private protected IList<string> _numerics;

        /// <summary>
        /// The measure
        /// </summary>
        private protected string _measure;

        /// <summary>
        /// The items
        /// </summary>
        private IList<IModel> _items;

        /// <inheritdoc />
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public ObservableCollection<IModel> Data
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

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the views.
        /// </summary>
        /// <value>
        /// The views.
        /// </value>
        public BindingList<IModel> Views
        {
            get
            {
                return _views;
            }
            set
            {
                _views = value;
            }
        }

        /// <inheritdoc />
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
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public new IList<IModel> Items
        {
            get
            {
                return _items;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="dimension">The category.</param>
        /// <param name="measure"> </param>
        /// <param name="value">The value.</param>
        public abstract void Add( int index, string dimension, string measure, double value );

        /// <inheritdoc />
        /// <summary>
        /// Adds the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        public abstract new void Add( IModel view );

        /// <inheritdoc />
        /// <summary>
        /// Removes the specified view.
        /// </summary>
        /// <param name="view">The view.</param>
        public abstract new void Remove( IModel view );

        /// <inheritdoc />
        /// <summary>
        /// Cycles this instance.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator<IModel> IterItems( )
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
        public virtual BindingList<IModel> CreateViewList( )
        {
            try
            {
                if( _data != null )
                {
                    _views = new BindingList<IModel>( );
                    foreach( var _view in _data )
                    {
                        _views.Add( _view );
                    }

                    return ( _views?.Any( ) == true )
                        ? _views
                        : default( BindingList<IModel> );
                }

                return default( BindingList<IModel> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( BindingList<IModel> );
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