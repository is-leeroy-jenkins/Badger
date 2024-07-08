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
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Media;
    using Syncfusion.UI.Xaml.Charts;

    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "MergeConditionalExpression" ) ]
    public class MetroAreaChart : SfChart3D
    {
        /// <summary>
        /// The theme
        /// </summary>
        private protected readonly DarkPalette _theme = new DarkPalette( );

        /// <summary>
        /// The model palette
        /// </summary>
        private protected ChartColorModel _colorModel;

        /// <summary>
        /// Gets the model palette.
        /// </summary>
        /// <value>
        /// The model palette.
        /// </value>
        public ChartColorModel ModelPalette
        {
            get
            {
                return _colorModel;
            }
            private protected set
            {
                _colorModel = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.MetroAreaChart" /> class.
        /// </summary>
        public MetroAreaChart( )
            : base( )
        {
            // Control Properties
            SetResourceReference( StyleProperty, typeof( SfChart3D ) );
            Width = 800;
            Height = 454;
            FontFamily = new FontFamily( "Segoe UI" );
            FontSize = 12;
            EnableRotation = true;
            Depth = 250;
            EnableSegmentSelection = true;
            EnableSeriesSelection = true;
            EnableRotation = true;
            PerspectiveAngle = 100;
            SideBySideSeriesPlacement = true;
            PerspectiveAngle = 100;
            Padding = new Thickness( 1 );
            BorderThickness = new Thickness( 1 );
            Background = _theme.BackColor;
            RightWallBrush = _theme.WallColor;
            LeftWallBrush = _theme.WallColor;
            BackWallBrush = _theme.WallColor;
            TopWallBrush = _theme.WallColor;
            BottomWallBrush = _theme.BlackColor;
            BorderBrush = _theme.BorderColor;
            Foreground = _theme.ForeColor;
            Header = "Area Chart";
            PrimaryAxis = CreateCategoricalAxis( );
            SecondaryAxis = CreateNumericalAxis( );
        }

        /// <summary>
        /// Creates the categorical axis3 d.
        /// </summary>
        /// <returns>
        /// </returns>
        private CategoryAxis3D CreateCategoricalAxis( )
        {
            try
            {
                var _categoricalAxis = new CategoryAxis3D
                {
                    FontSize = 10,
                    ShowOrigin = true,
                    Header = "X-Axis",
                    Interval = 1,
                    Name = "Category",
                    Foreground = _theme.BorderColor,
                    ShowGridLines = true
                };

                return ( _categoricalAxis != null )
                    ? _categoricalAxis
                    : default( CategoryAxis3D );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( CategoryAxis3D );
            }
        }

        /// <summary>
        /// Creates the numerical axis.
        /// </summary>
        /// <returns>
        /// NumericalAxis3D 
        /// </returns>
        private NumericalAxis3D CreateNumericalAxis( )
        {
            try
            {
                var _numericalAxis = new NumericalAxis3D
                {
                    FontSize = 10,
                    ShowOrigin = true,
                    Header = "Y-Axis",
                    Name = "Values",
                    Foreground = _theme.BorderColor,
                    ShowGridLines = true
                };

                return _numericalAxis;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( NumericalAxis3D );
            }
        }

        /// <summary>
        /// Creates the color model.
        /// </summary>
        /// <returns>
        /// ChartColorModel
        /// </returns>
        private protected ChartColorModel CreateColorModel( )
        {
            try
            {
                var _model = new ChartColorModel( );
                _model.CustomBrushes.Add( _theme.HoverColor );
                _model.CustomBrushes.Add( _theme.GrayColor );
                _model.CustomBrushes.Add( _theme.YellowColor );
                _model.CustomBrushes.Add( _theme.RedColor );
                _model.CustomBrushes.Add( _theme.KhakiColor );
                _model.CustomBrushes.Add( _theme.GreenColor );
                _model.CustomBrushes.Add( _theme.LightBlueColor );
                return ( _model.CustomBrushes.Count > 0 )
                    ? _model
                    : default( ChartColorModel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ChartColorModel );
            }
        }

        /// <summary>
        /// Creates the adornment.
        /// </summary>
        /// <returns></returns>
        private ChartAdornmentInfo3D CreateAdornment( )
        {
            try
            {
                var _adornment = new ChartAdornmentInfo3D
                {
                    ShowLabel = true,
                    ShowMarker = true,
                    ShowConnectorLine = true,
                    FontSize = 10,
                    AdornmentsPosition = AdornmentsPosition.Top,
                    LabelPosition = AdornmentsLabelPosition.Outer,
                    UseSeriesPalette = false,
                    BorderThickness = new Thickness( 1 ),
                    HighlightOnSelection = true,
                    ConnectorRotationAngle = 45,
                    Symbol = ChartSymbol.Diamond,
                    SymbolInterior = _theme.HoverColor,
                    SymbolHeight = 8,
                    BorderBrush = _theme.BorderColor,
                    Foreground = _theme.LightBlueColor,
                    Background = _theme.BlackColor
                };

                return _adornment;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ChartAdornmentInfo3D );
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
