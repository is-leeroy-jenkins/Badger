// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-01-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-01-2024
// ******************************************************************************************
// <copyright file="MetroDataGrid.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts
//    based on WPF, NET6.0, and written in C-Sharp.
// 
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
//   MetroDataGrid.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using Syncfusion.UI.Xaml.Grid;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Input;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Syncfusion.UI.Xaml.Grid.SfDataGrid" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class MetroDataGrid : SfDataGrid
    {
        /// <summary>
        /// The theme
        /// </summary>
        private protected readonly DarkMode _theme = new DarkMode( );

        private protected Window _schemaWindow;

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
            FontFamily = _theme.FontFamily;
            FontSize = _theme.FontSize;
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
            Background = _theme.BackColor;
            BorderBrush = _theme.BorderColor;
            Foreground = _theme.ForeColor;
            CurrentCellBorderBrush = _theme.LightBlueColor;
            GroupRowSelectionBrush = _theme.SteelBlueColor;
            RowSelectionBrush = _theme.SteelBlueColor;
            RowHoverHighlightingBrush = _theme.SteelBlueColor;

            // Control Event Wiring
            MouseRightButtonDown += OnMouseRightClick;
            MouseLeftButtonDown += OnMouseLeftClick;
        }

        /// <summary>
        /// Called when [column right clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private protected void OnMouseRightClick( object sender, MouseButtonEventArgs e )
        {
            try
            {
                if( sender is MetroDataGrid _grid 
                    && !_grid.CurrentCellInfo.IsDataRowCell )
                {
                    var _schema = new SchemaWindow( this );
                    _schema.Show( );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Called when [cell left clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private protected void OnMouseLeftClick( object sender, RoutedEventArgs e )
        {
            try
            {
                if( sender is MetroDataGrid _grid
                    && _grid.CurrentCellInfo.IsDataRowCell )
                {
                    var _type = _grid.CurrentCellInfo.Column.ColumnMemberType.ToString( );
                    switch( _type )
                    {
                        case "float":
                        case "double":
                        case "decimal":
                        {
                            var _calculator = new CalculatorWindow( );
                            _calculator.Show( );
                            break;
                        }
                        case "DateTime":
                        {
                            break;
                        }
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
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