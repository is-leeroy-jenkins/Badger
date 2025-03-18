// ******************************************************************************************
//     Assembly:                Baby
//     Author:                  Terry D. Eppler
//     Created:                 09-09-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-09-2024
// ******************************************************************************************
// <copyright file="DownloadCallback.cs" company="Terry D. Eppler">
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
//   DownloadCallback.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using CefSharp;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary> </summary>
    /// <seealso cref="CefSharp.IDownloadHandler"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "ExpressionIsAlwaysNull" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class DownloadCallback : IDownloadHandler
    {
        /// <summary>
        /// The browser
        /// </summary>
        private readonly WebBrowser _webBrowser;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DownloadCallback"/>
        /// class.
        /// </summary>
        /// <param name="form"> The form. </param>
        public DownloadCallback( WebBrowser form )
        {
            _webBrowser = form;
        }

        /// <summary> Determines whether this instance can download the specified chromium WebBrowser. </summary>
        /// <param name="chromiumWebBrowser"> The chromium WebBrowser. </param>
        /// <param name="browser"> The browser. </param>
        /// <param name="url"> The URL. </param>
        /// <param name="requestMethod"> The request method. </param>
        /// <returns>
        /// <c> true </c>
        /// if this instance can download the specified chromium WebBrowser; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        public bool CanDownload( IWebBrowser chromiumWebBrowser, IBrowser browser, string url,
            string requestMethod )
        {
            return true;
        }

        /// <summary> Called when [before download]. </summary>
        /// <param name="webBrowser"> The web browser. </param>
        /// <param name="browser"> The browser. </param>
        /// <param name="item"> The item. </param>
        /// <param name="callback"> The callback. </param>
        public bool OnBeforeDownload( IWebBrowser webBrowser, IBrowser browser, DownloadItem item,
                                      IBeforeDownloadCallback callback )
        {
            if( !callback.IsDisposed )
            {
                using( callback )
                {
                    _webBrowser.UpdateDownloadItem( item );
                    var _path = _webBrowser.GetDownloadPath( item );
                    if( _path == null )
                    {
                        callback.Continue( _path, false );
                        return true;
                    }
                    else
                    {
                        callback.Continue(_path, true);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary> Called when [download updated]. </summary>
        /// <param name="webBrowser"> The web browser. </param>
        /// <param name="browser"> The browser. </param>
        /// <param name="downloadItem"> The download item. </param>
        /// <param name="callback"> The callback. </param>
        public void OnDownloadUpdated( IWebBrowser webBrowser, IBrowser browser,
                                       DownloadItem downloadItem, IDownloadItemCallback callback )
        {
            _webBrowser.UpdateDownloadItem( downloadItem );
            if( downloadItem.IsInProgress
                && _webBrowser.CancelRequests.Contains( downloadItem.Id ) )
            {
                callback.Cancel( );
            }
        }
    }
}