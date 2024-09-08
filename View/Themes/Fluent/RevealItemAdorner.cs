// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 09-08-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-08-2024
// ******************************************************************************************
// <copyright file="RevealItemAdorner.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts
//    that is based on WPF, NET6.0, and written in C-Sharp.
// 
//     Copyright ©  2020, 2022, 2204 Terry D. Eppler
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
//   RevealItemAdorner.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// Helper adorner class to handle reveal item hover and pressed animation for UI element.
    /// </summary>
    /// <<exclude/>
    [ EditorBrowsable( EditorBrowsableState.Never ) ]
    [ Browsable( false ) ]
    public class RevealItemAdorner : Adorner
    {
        /// <summary>
        /// Gets or sets the reveal item.
        /// </summary>
        /// <value>
        /// The reveal item.
        /// </value>
        public RevealItem RevealItem
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RevealItemAdorner"/> class.
        /// </summary>
        /// <param name="adornedElement">The adorned element.</param>
        /// <param name="revealElement">The reveal element.</param>
        public RevealItemAdorner( UIElement adornedElement, RevealItem revealElement )
            : base( adornedElement )
        {
            RevealItem = revealElement;
            IsHitTestVisible = false;
            adornedElement.PreviewMouseMove += AdornedElement_PreviewMouseMove;
            adornedElement.PreviewMouseDown += AdornedElement_PreviewMouseDown;
            adornedElement.MouseLeave += AdornedElement_MouseLeave;
        }

        private void AdornedElement_MouseLeave( object sender, MouseEventArgs e )
        {
            RevealItem.IsMouseOver = false;
        }

        private void AdornedElement_PreviewMouseDown( object sender, MouseEventArgs e )
        {
            RevealItem.Position = e.GetPosition( sender as IInputElement );
            RevealItem.StartPressedRevealAnimation( );
        }

        private void AdornedElement_PreviewMouseMove( object sender, MouseEventArgs e )
        {
            if( e.LeftButton != MouseButtonState.Pressed )
            {
                RevealItem.IsPressed = false;
            }
            else
            {
                RevealItem.IsPressed = true;
            }

            RevealItem.IsMouseOver = true;
            RevealItem.Position = e.GetPosition( sender as IInputElement );
        }

        protected override Size ArrangeOverride( Size finalSize )
        {
            double x = 0;
            double y = 0;
            RevealItem.Arrange( new Rect( x, y, AdornedElement.RenderSize.Width,
                AdornedElement.RenderSize.Height ) );

            RevealItem.UpdateRevealBorderSize( AdornedElement.RenderSize.Width );
            return finalSize;
        }

        /// <<exclude/>
        public void Dispose( )
        {
            AdornedElement.PreviewMouseMove -= AdornedElement_PreviewMouseMove;
            AdornedElement.PreviewMouseDown -= AdornedElement_PreviewMouseDown;
            AdornedElement.MouseLeave -= AdornedElement_MouseLeave;
        }

        protected override int VisualChildrenCount { get { return 1; } }

        protected override Visual GetVisualChild( int index ) { return RevealItem; }
    }
}