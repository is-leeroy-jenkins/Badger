﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 05-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-28-2024
// ******************************************************************************************
// <copyright file="MetroDataGrid.cs" company="Terry D. Eppler">
//    Badger is a data analysis and reporting tool for EPA analysts.
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
//   MetroDataGrid.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Media;
    using Syncfusion.UI.Xaml.Grid;

    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class MetroDataGrid : SfDataGrid
    {
        /// <summary>
        /// The back color
        /// </summary>
        private protected Color _backColor = new Color( )
        {
            A = 255,
            R = 45,
            G = 45,
            B = 45
        };

        /// <summary>
        /// The back hover color
        /// </summary>
        private protected Color _backHover = new Color( )
        {
            A = 255,
            R = 17,
            G = 53,
            B = 84
        };

        /// <summary>
        /// The fore color
        /// </summary>
        private protected Color _foreColor = new Color( )
        {
            A = 255,
            R = 222,
            G = 222,
            B = 222
        };

        /// <summary>
        /// The fore hover color
        /// </summary>
        private protected Color _foreHover = new Color( )
        {
            A = 255,
            R = 255,
            G = 255,
            B = 255
        };

        /// <summary>
        /// The border color
        /// </summary>
        private Color _borderColor = new Color( )
        {
            A = 255,
            R = 0,
            G = 120,
            B = 212
        };

        /// <summary>
        /// The border hover color
        /// </summary>
        private readonly Color _borderHover = new Color( )
        {
            A = 255,
            R = 50,
            G = 93,
            B = 129
        }; 

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.DataGrid" /> class.
        /// </summary>
        public MetroDataGrid( )
            : base( )
        {
            // Control Properties
            SetResourceReference( StyleProperty, typeof( SfDataGrid ) );
            FontFamily = new FontFamily( "Segoe UI" );
            FontSize = 12;
            AllowEditing = true;
            AllowSorting = true;
            AllowDraggingColumns = true;
            AllowResizingColumns = true;
            AllowDeleting = true;
            AllowRowHoverHighlighting = true;
            AllowResizingColumns = true;
            AllowGrouping = true;
            AllowDrop = true;
            AllowDraggingRows = true;
            AllowCollectionView = true;
            AutoGenerateColumnsMode = AutoGenerateColumnsMode.ResetAll;
            AutoGenerateColumns = true;
            AutoExpandGroups = true;
            ShowGroupDropArea = true;
            SelectionMode = GridSelectionMode.Single;
            ShowColumnWhenGrouped = true;
            Background = new SolidColorBrush( _backColor );
            BorderBrush = new SolidColorBrush( _backColor );
            Foreground = new SolidColorBrush( _foreColor );
            CurrentCellBorderBrush = new SolidColorBrush( _borderHover );
            GroupRowSelectionBrush = new SolidColorBrush( Colors.SteelBlue );
            RowSelectionBrush = new SolidColorBrush( Colors.SteelBlue );
            RowHoverHighlightingBrush = new SolidColorBrush( _backHover );
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