// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 05-30-2024
//
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-30-2024
// ******************************************************************************************
// <copyright file="MetroDropDown.cs" company="Terry D. Eppler">
    //    This is a Federal Budget, Finance, and Accounting application
    //    for the US Environmental Protection Agency (US EPA).
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
    //   MetroDropDown.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.Tools.Controls;

[ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
[ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
[ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
[ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
[ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
[ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
[ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
[ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
public class MetroDropDown : DropDownButtonAdv
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
R = 45,
G = 45,
B = 45
};

/// <summary>
    /// The fore color
/// </summary>
private protected Color _foreColor = new Color( )
{
A = 255,
R = 255,
G = 255,
B = 255
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

/// <inheritdoc />
/// <summary>
    /// Initializes a new instance of the
    /// <see cref="T:Badger.ComboBox" /> class.
/// </summary>
public MetroDropDown( )
: base( )
{
// Basic Properties
Width = 200;
Height = 35;
FontFamily = new FontFamily( "Segoe UI" );
FontSize = 12;
Padding = new Thickness( 1 );
BorderThickness = new Thickness( 0 );
HorizontalAlignment = HorizontalAlignment.Stretch;
VerticalAlignment = VerticalAlignment.Stretch;
HorizontalContentAlignment = HorizontalAlignment.Left;
VerticalContentAlignment = VerticalAlignment.Center;
Background = new SolidColorBrush( _backColor );
Foreground = new SolidColorBrush( _foreColor );
BorderBrush = new SolidColorBrush( _backColor );
}

/// <summary>
    /// Fails the specified ex.
/// </summary>
/// <param name="ex">The ex.</param>
private protected void Fail( Exception ex )
{
var _error = new ErrorWindow( ex );
_error?.SetText( );
_error?.ShowDialog( );
}
}
}