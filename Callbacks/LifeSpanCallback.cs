// ******************************************************************************************
//     Assembly:                Baby
//     Author:                  Terry D. Eppler
//     Created:                 09-09-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-09-2024
// ******************************************************************************************
// <copyright file="LifeSpanCallback.cs" company="Terry D. Eppler">
//     Baby is a light-weight, full-featured, web-browser built with .NET 6 and is written
//     in C#.  The baby browser is designed for budget execution and data analysis.
//     A tool for EPA analysts and a component that can be used for general browsing.
// 
//     Copyright ©  2020 Terry D. Eppler
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
//   LifeSpanCallback.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using CefSharp;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CefSharp.ILifeSpanHandler" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public class LifeSpanCallback : ILifeSpanHandler
    {
        /// <summary>
        /// The browser
        /// </summary>
        private readonly WebBrowser _webBrowser;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="LifeSpanCallback"/> class.
        /// </summary>
        /// <param name="form">The form.</param>
        public LifeSpanCallback( WebBrowser form )
        {
            _webBrowser = form;
        }

        /// <summary>
        /// Does the close.
        /// </summary>
        /// <param name="browserControl">
        /// The browser control.
        /// </param>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <returns></returns>
        public bool DoClose( IWebBrowser browserControl, IBrowser browser )
        {
            return false;
        }

        /// <summary>
        /// Called when [after created].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        public void OnAfterCreated( IWebBrowser browserControl, IBrowser browser )
        {
        }

        /// <summary>
        /// Called when [before close].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        public void OnBeforeClose( IWebBrowser browserControl, IBrowser browser )
        {
        }

        /// <summary>
        /// Called when [before popup].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="frame">The frame.</param>
        /// <param name="targetUrl">The target URL.</param>
        /// <param name="targetFrameName">Name of the target frame.</param>
        /// <param name="targetDisposition">The target disposition.</param>
        /// <param name="userGesture">if set to <c>true</c> [user gesture].</param>
        /// <param name="popupFeatures">The popup features.</param>
        /// <param name="windowInfo">The window information.</param>
        /// <param name="browserSettings">The browser settings.</param>
        /// <param name="noJavascriptAccess">if set to <c>true</c> [no javascript access].</param>
        /// <param name="newBrowser">The new browser.</param>
        /// <returns></returns>
        public bool OnBeforePopup( IWebBrowser browserControl, IBrowser browser, IFrame frame,
            string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition,
            bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo,
            IBrowserSettings browserSettings, ref bool noJavascriptAccess,
            out IWebBrowser newBrowser )
        {
            newBrowser = null;
            //_webBrowser.AddNewBrowserTab( targetUrl );
            return true;
        }
    }
}