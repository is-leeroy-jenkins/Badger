// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="KeyboardCallback.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
// 
//    Copyright ©  2020-2024 Terry D. Eppler
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
//   KeyboardCallback.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using CefSharp;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using MahApps.Metro.Controls;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CefSharp.IKeyboardHandler" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    public class KeyboardCallback : IKeyboardHandler
    {
        /// <summary>
        /// My form
        /// </summary>
        private WebBrowser _webBrowser;

        /// <summary>
        /// The hot keys
        /// </summary>
        public static List<BrowserHotKey> Hotkeys = new List<BrowserHotKey>( );

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="KeyboardCallback"/> class.
        /// </summary>
        /// <param name="form">The form.</param>
        public KeyboardCallback( WebBrowser form )
        {
            _webBrowser = form;
        }

        /// <summary>
        /// Adds the hot key.
        /// </summary>
        /// <param name="form">
        /// The form.
        /// </param>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="ctrl">
        /// if set to <c>true</c> [control].
        /// </param>
        /// <param name="shift">
        /// if set to <c>true</c> [shift].
        /// </param>
        /// <param name="alt">
        /// if set to <c>true</c> [alt].
        /// </param>
        public static void AddHotKey( Window form, Action function, Keys key,
            bool ctrl = false, bool shift = false, bool alt = false )
        {
            NetUtility.AddHotKey( form, function, ctrl, shift,
                alt );

            Hotkeys.Add( new BrowserHotKey( function, key, ctrl, shift,
                alt ) );
        }

        /// <summary>
        /// Summary:
        ///     Called before a keyboard event is sent to the renderer. Return true if the event
        ///     was handled or false otherwise. If the event will be handled in
        ///     CefSharp.IKeyboardHandler.OnKeyEvent(CefSharp.IWebBrowser,CefSharp.IBrowser,CefSharp.KeyType,
        ///     System.Int32,System.Int32,CefSharp.CefEventFlags,System.Boolean)
        ///     as a keyboard shortcut set isKeyboardShortcut to true and return false.
        ///
        /// Parameters:
        ///   chromiumWebBrowser:
        ///     the ChromiumWebBrowser control
        ///  
        ///   browser:
        ///     The browser instance.
        ///
        ///   type:
        ///     Whether this was a key up/down/raw/etc...
        ///
        ///   windowsKeyCode:
        ///     The Windows key code for the key event. This value is used by the DOM specification.
        ///     Sometimes it comes directly from the event (i.e. on Windows) and sometimes it's
        ///     determined using a mapping function. See WebCore/platform/chromium/KeyboardCodes.h
        ///     for the list of values.
        ///
        ///   nativeKeyCode:
        ///     The native key code. On Windows this appears to be in the format of WM_KEYDOWN/WM_KEYUP/etc...
        ///     lParam data.
        ///
        ///   modifiers:
        ///     What other modifier keys are currently down: Shift/Control/Alt/OS X Command/etc...
        ///
        ///   isSystemKey:
        ///     Indicates whether the event is considered a "system key"
        ///     event (see http://msdn.microsoft.com/en-us/library/ms646286(VS.85).aspx
        ///     for details).
        ///
        ///   isKeyboardShortcut:
        ///     See the summary for an explanation of when to set this to true.
        ///
        /// Returns:
        ///     Returns true if the event was handled or false otherwise.
        /// 
        /// </summary>
        /// <param name="browserControl"></param>
        /// <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="windowsKeyCode"></param>
        /// <param name="nativeKeyCode"></param>
        /// <param name="modifiers"></param>
        /// <param name="isSystemKey"></param>
        /// <param name="isKeyboardShortcut"></param>
        /// <returns></returns>
        public bool OnPreKeyEvent( IWebBrowser browserControl, IBrowser browser, KeyType type,
            int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers,
            bool isSystemKey, ref bool isKeyboardShortcut )
        {
            return false;
        }

        /// <summary>      
        /// Summary:
        ///     Called after the renderer and JavaScript in the page has had a chance to handle
        ///     the event. Return true if the keyboard event was handled or false otherwise.
        ///
        /// Parameters:
        ///   chromiumWebBrowser:
        ///     the ChromiumWebBrowser control
        ///
        ///   browser:
        ///     The browser instance.
        ///
        ///   type:
        ///     Whether this was a key up/down/raw/etc...
        ///
        ///   windowsKeyCode:
        ///     The Windows key code for the key event. This value is used by the DOM specification.
        ///     Sometimes it comes directly from the event (i.e. on Windows) and sometimes it's
        ///     determined using a mapping function. See WebCore/platform/chromium/KeyboardCodes.h
        ///     for the list of values.
        ///
        ///   nativeKeyCode:
        ///     The native key code. On Windows this appears to be in the format of WM_KEYDOWN/WM_KEYUP/etc...
        ///     lParam data.
        ///
        ///   modifiers:
        ///     What other modifier keys are currently down: Shift/Control/Alt/OS X Command/etc...
        ///
        ///   isSystemKey:
        ///     Indicates whether the event is considered a "system key" event
        ///     (see http://msdn.microsoft.com/en-us/library/ms646286(VS.85).aspx
        ///     for details).
        ///
        /// Returns:
        ///     Return true if the keyboard event was handled or false otherwise.
        /// </summary>
        /// <param name="browserControl"></param>
        /// <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="windowsKeyCode"></param>
        /// <param name="nativeKeyCode"></param>
        /// <param name="modifiers"></param>
        /// <param name="isSystemKey"></param>
        /// <returns></returns>
        public bool OnKeyEvent( IWebBrowser browserControl, IBrowser browser, KeyType type,
            int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers,
            bool isSystemKey )
        {
            if( type == KeyType.RawKeyDown )
            {
                var _mod = ( int )modifiers;
                var _ctrlDown = _mod.IsBitMaskOn( ( int )CefEventFlags.ControlDown );
                var _shiftDown = _mod.IsBitMaskOn( ( int )CefEventFlags.ShiftDown );
                var _altDown = _mod.IsBitMaskOn( ( int )CefEventFlags.AltDown );
                foreach( var _key in Hotkeys )
                {
                    if( _key.KeyCode == windowsKeyCode )
                    {
                        if( _key.Ctrl == _ctrlDown
                            && _key.Shift == _shiftDown
                            && _key.Alt == _altDown )
                        {
                            _webBrowser.BeginInvoke( delegate
                            {
                                _key.Callback( );
                            } );
                        }
                    }
                }

                //Debug.WriteLine(String.Format("OnKeyEvent: KeyType: {0} 0x{1:X} Modifiers: {2}", type, windowsKeyCode, modifiers));
            }

            return false;
        }
    }
}