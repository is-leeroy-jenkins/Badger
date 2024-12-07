// ******************************************************************************************
//     Assembly:                Baby
//     Author:                  Terry D. Eppler
//     Created:                 09-09-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-09-2024
// ******************************************************************************************
// <copyright file="RequestCallback.cs" company="Terry D. Eppler">
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
//   RequestCallback.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using CefSharp;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CefSharp.IRequestHandler" />
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class RequestCallback : IRequestHandler
    {
        /// <summary>
        /// The browser
        /// </summary>
        private readonly WebBrowser _webBrowser;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="RequestCallback"/> class.
        /// </summary>
        /// <param name="form">The form.</param>
        public RequestCallback( WebBrowser form )
        {
            _webBrowser = form;
        }

        /// <summary>
        /// Gets the authentication credentials.
        /// </summary>
        /// <param name="chromiumWebBrowser">The chromium WebBrowser.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="originUrl">The origin URL.</param>
        /// <param name="isProxy">if set to <c>true</c> [is proxy].</param>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="realm">The realm.</param>
        /// <param name="scheme">The scheme.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public bool GetAuthCredentials( IWebBrowser chromiumWebBrowser, IBrowser browser,
            string originUrl, bool isProxy, string host,
            int port, string realm, string scheme,
            IAuthCallback callback )
        {
            return false;
        }

        /// <summary>
        /// Called when [before browse].
        /// </summary>
        /// <param name="chromiumWebBrowser">The chromium WebBrowser.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="frame">The frame.</param>
        /// <param name="request">The request.</param>
        /// <param name="userGesture">if set to <c>true</c> [user gesture].</param>
        /// <param name="isRedirect">if set to <c>true</c> [is redirect].</param>
        /// <returns></returns>
        public bool OnBeforeBrowse( IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame,
            IRequest request, bool userGesture, bool isRedirect )
        {
            return false;
        }

        /// <summary>
        /// Called when [certificate error].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="requestUrl">The request URL.</param>
        /// <param name="sslInfo">The SSL information.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public bool OnCertificateError( IWebBrowser browserControl, IBrowser browser,
            CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo,
            IRequestCallback callback )
        {
            return true;
        }

        /// <summary>
        /// Called when [open URL from tab].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="frame">The frame.</param>
        /// <param name="targetUrl">The target URL.</param>
        /// <param name="targetDisposition">The target disposition.</param>
        /// <param name="userGesture">if set to <c>true</c> [user gesture].</param>
        /// <returns></returns>
        public bool OnOpenUrlFromTab( IWebBrowser browserControl, IBrowser browser, IFrame frame,
            string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture )
        {
            return false;
        }

        /// <summary>
        /// Called when [plugin crashed].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="pluginPath">The plugin path.</param>
        public void OnPluginCrashed( IWebBrowser browserControl, IBrowser browser,
            string pluginPath )
        {
        }

        /// <summary>
        /// Called when [quota request].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="originUrl">The origin URL.</param>
        /// <param name="newSize">The new size.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public bool OnQuotaRequest( IWebBrowser browserControl, IBrowser browser, string originUrl,
            long newSize, IRequestCallback callback )
        {
            callback.Continue( true );
            return true;
        }

        /// <summary>
        /// Called when [render process terminated].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="status">The status.</param>
        public void OnRenderProcessTerminated( IWebBrowser browserControl, IBrowser browser,
            CefTerminationStatus status )
        {
            var _message = "NOT YET IMPLEMENTED!";
            SendMessage( _message );
        }

        /// <summary>
        /// Called when [render view ready].
        /// </summary>
        /// <param name="browserControl">The browser control.</param>
        /// <param name="browser">The browser.</param>
        public void OnRenderViewReady( IWebBrowser browserControl, IBrowser browser )
        {
            var _message = "NOT YET IMPLEMENTED!";
            SendMessage( _message );
        }

        /// <summary>
        /// Called when [render process terminated].
        /// </summary>
        /// <param name="chromiumWebBrowser">The chromium WebBrowser.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="status">The status.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        public void OnRenderProcessTerminated( IWebBrowser chromiumWebBrowser, IBrowser browser,
            CefTerminationStatus status, int errorCode, string errorMessage )
        {
            var _message = "NOT YET IMPLEMENTED!";
            SendMessage( _message );
        }

        /// <summary>
        /// Gets the resource request handler.
        /// </summary>
        /// <param name="chromiumWebBrowser">The chromium WebBrowser.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="frame">The frame.</param>
        /// <param name="request">The request.</param>
        /// <param name="isNavigation">if set to <c>true</c> [is navigation].</param>
        /// <param name="isDownload">if set to <c>true</c> [is download].</param>
        /// <param name="requestInitiator">The request initiator.</param>
        /// <param name="disableDefaultHandling">if set to <c>true</c> [disable default handling].</param>
        /// <returns></returns>
        public IResourceRequestHandler GetResourceRequestHandler( IWebBrowser chromiumWebBrowser,
            IBrowser browser, IFrame frame, IRequest request,
            bool isNavigation, bool isDownload, string requestInitiator,
            ref bool disableDefaultHandling )
        {
            var _rh = new ResourceRequestCallback( _webBrowser );
            return _rh;
        }

        /// <summary>
        /// Called when [select client certificate].
        /// </summary>
        /// <param name="chromiumWebBrowser">The chromium WebBrowser.</param>
        /// <param name="browser">The browser.</param>
        /// <param name="isProxy">if set to <c>true</c> [is proxy].</param>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="certificates">The certificates.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public bool OnSelectClientCertificate( IWebBrowser chromiumWebBrowser, IBrowser browser,
            bool isProxy, string host, int port,
            X509Certificate2Collection certificates, ISelectClientCertificateCallback callback )
        {
            return false;
        }

        /// <summary>
        /// Called when [document available in main frame].
        /// </summary>
        /// <param name="chromiumWebBrowser">The chromium WebBrowser.</param>
        /// <param name="browser">The browser.</param>
        public void OnDocumentAvailableInMainFrame( IWebBrowser chromiumWebBrowser,
            IBrowser browser )
        {
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void SendMessage( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _splashMessage = new SplashMessage( message );
                _splashMessage.Show( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        private void SendNotification( )
        {
            try
            {
                var _message = "THIS IS NOT YET IMPLEMENTED!";
                var _notify = new Notification( _message );
                _notify.Show( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}