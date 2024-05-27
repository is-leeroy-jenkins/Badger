// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
//
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        ${CurrentDate.Month}-${CurrentDate.Day}-${CurrentDate.Year}
// ******************************************************************************************
// <copyright file="${File.FileName}" company="Terry D. Eppler">
    //    This is a Federal Budget, Finance, and Accounting application
    //    for the US Environmental Protection Agency (US EPA).
    //    Copyright ©  ${CurrentDate.Year}  Terry Eppler
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
    //   ${File.FileName}
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <inheritdoc />
/// <summary>
/// </summary>
/// <seealso cref="T:System.Windows.Controls.ListBox" />
[ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
[ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
[ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
public class MetroListBox : ListBox
{
/// <summary>
    /// The back color brush
/// </summary>
private protected SolidColorBrush _backColorBrush;

/// <summary>
    /// The border color brush
/// </summary>
private protected SolidColorBrush _borderColorBrush;

/// <summary>
    /// The fore color brush
/// </summary>
private protected SolidColorBrush _foreColorBrush;

/// <summary>
    /// The back hover brush
/// </summary>
private protected SolidColorBrush _backHoverBrush;

/// <summary>
    /// The border hover brush
/// </summary>
private protected SolidColorBrush _borderHoverBrush;

/// <summary>
    /// The fore hover brush
/// </summary>
private protected SolidColorBrush _foreHoverBrush;

/// <summary>
    /// The back color
/// </summary>
private protected Color _backColor = new Color( )
{
A = 255,
R = 20,
G = 20,
B = 20
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
R = 106,
G = 189,
B = 252
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
private protected Color _borderColor = new Color( )
{
A = 255,
R = 0,
G = 120,
B = 212
};

/// <summary>
    /// The border hover color
/// </summary>
private protected Color _borderHover = new Color( )
{
A = 255,
R = 106,
G = 189,
B = 252
};

/// <summary>
    /// The tiles
/// </summary>
private protected IList<MetroTile> _tiles;

    /// <summary>
        /// The path
    /// </summary>
    private protected object _path;

    /// <summary>
        /// The busy
    /// </summary>
    private protected bool _busy;

    /// <summary>
        /// The time
    /// </summary>
    private protected int _time;

    /// <summary>
        /// The seconds
    /// </summary>
    private protected int _seconds;

    /// <summary>
        /// The update status
    /// </summary>
    private protected Action _statusUpdate;

    /// <summary>
        /// Gets a value indicating whether this instance is busy.
    /// </summary>
    /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
    /// </value>
    public bool IsBusy
    {
    get
    {
    if( _path == null )
    {
    _path = new object( );
    lock( _path )
    {
    return _busy;
    }
    }
    else
    {
    lock( _path )
    {
    return _busy;
    }
    }
    }
    }

    /// <inheritdoc />
    /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MetroListBox" /> class.
    /// </summary>
    public MetroListBox( )
    : base( )
    {
    // Basic Properties
    Width = 220;
    Height = 400;
    FontFamily = new FontFamily( "Segoe UI" );
    FontSize = 12d;
    Margin = new Thickness( 1 );
    BorderThickness = new Thickness( 1 );
    HorizontalAlignment = HorizontalAlignment.Stretch;
    VerticalAlignment = VerticalAlignment.Stretch;
    Background = new SolidColorBrush( _backColor );
    Foreground = new SolidColorBrush( _foreColor );
    BorderBrush = new SolidColorBrush( _borderColor );

    // Event Wiring
    MouseEnter += OnItemMouseEnter;
    MouseLeave += OnItemMouseLeave;
    }

    /// <summary>
        /// Called when [item mouse enter].
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/>
    /// instance containing the event data.</param>
    private protected void OnItemMouseEnter( object sender, EventArgs e )
    {
    try
    {
    if( sender is ListBoxItem _item )
    {
    _item.Foreground = new SolidColorBrush( _foreHover );
    _item.Background = new SolidColorBrush( _backHover );
    _item.BorderBrush = new SolidColorBrush( _borderHover );
    }
    }
    catch( Exception _ex )
    {
    Fail( _ex );
    }
    }

    /// <summary>
        /// Called when [item mouse leave].
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/>
    /// instance containing the event data.</param>
    private protected void OnItemMouseLeave( object sender, EventArgs e )
    {
    try
    {
    if( sender is ListBoxItem _item )
    {
    _item.Foreground = new SolidColorBrush( _foreColor );
    _item.Background = new SolidColorBrush( _backColor );
    _item.BorderBrush = new SolidColorBrush( _borderColor );
    }
    }
    catch( Exception _ex )
    {
    Fail( _ex );
    }
    }

    /// <summary>
        /// Fails the specified ex.
    /// </summary>
    /// <param name="ex">The ex.</param>
    private protected void Fail( Exception ex )
    {
    var _error = new ErrorDialog( ex );
    _error?.SetText( );
    _error?.ShowDialog( );
    }
    }
    }
