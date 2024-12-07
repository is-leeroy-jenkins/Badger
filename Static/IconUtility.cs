// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="IconUtility.cs" company="Terry D. Eppler">
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
//   IconUtility.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Drawing.Imaging;
    using static System.Drawing.Icon;
    using static System.Runtime.InteropServices.UnmanagedType;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public static class IconUtility
    {
        /// <summary>
        /// Gets the file icon.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static MemoryStream GetFileIcon( string name, IconSize size )
        {
            var _icon = IconFromExtension( name.GetAfter( "." ), size );
            using( _icon )
            {
                using var _bmp = _icon.ToBitmap( );
                var _ms = new MemoryStream( );
                _bmp.Save( _ms, ImageFormat.Png );
                _ms.Seek( 0, SeekOrigin.Begin );
                return _ms;
            }
        }

        /// <summary>
        /// Extracts the ex.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="largeIcons">The large icons.</param>
        /// <param name="smallIcons">The small icons.</param>
        /// <param name="firstIconIndex">First index of the icon.</param>
        /// <param name="iconCount">The icon count.</param>
        /// <exception cref="UnableToExtractIconsException"></exception>
        public static void ExtractEx( string fileName, List<Icon> largeIcons, List<Icon> smallIcons,
            int firstIconIndex, int iconCount )
        {
            IntPtr[ ] _smallIconsPtrs = null;
            IntPtr[ ] _largeIconsPtrs = null;
            if( smallIcons != null )
            {
                _smallIconsPtrs = new IntPtr[ iconCount ];
            }

            if( largeIcons != null )
            {
                _largeIconsPtrs = new IntPtr[ iconCount ];
            }

            var _apiResult = ExtractIconEx( fileName, firstIconIndex, _largeIconsPtrs,
                _smallIconsPtrs, iconCount );

            if( _apiResult != iconCount )
            {
                throw new UnableToExtractIconsException( fileName, firstIconIndex, iconCount );
            }

            if( smallIcons != null )
            {
                smallIcons.Clear( );
                foreach( var _actualIconPtr in _smallIconsPtrs )
                {
                    smallIcons.Add( FromHandle( _actualIconPtr ) );
                }
            }

            if( largeIcons != null )
            {
                largeIcons.Clear( );
                foreach( var _actualIconPtr in _largeIconsPtrs )
                {
                    largeIcons.Add( FromHandle( _actualIconPtr ) );
                }
            }
        }

        /// <summary>
        /// Extracts the ex.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="size">The size.</param>
        /// <param name="firstIconIndex">First index of the icon.</param>
        /// <param name="iconCount">The icon count.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">size</exception>
        public static List<Icon> ExtractEx( string fileName, IconSize size, int firstIconIndex,
            int iconCount )
        {
            var _iconList = new List<Icon>( );
            switch( size )
            {
                case IconSize.Large:
                {
                    ExtractEx( fileName, _iconList, null, firstIconIndex,
                        iconCount );

                    break;
                }
                case IconSize.Small:
                {
                    ExtractEx( fileName, null, _iconList, firstIconIndex,
                        iconCount );

                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException( "size" );
                }
            }

            return _iconList;
        }

        /// <summary>
        /// Extracts the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="largeIcons">The large icons.</param>
        /// <param name="smallIcons">The small icons.</param>
        public static void Extract( string fileName, List<Icon> largeIcons, List<Icon> smallIcons )
        {
            var _iconCount = GetIconsCountInFile( fileName );
            ExtractEx( fileName, largeIcons, smallIcons, 0,
                _iconCount );
        }

        /// <summary>
        /// Extracts the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static List<Icon> Extract( string fileName, IconSize size )
        {
            var _iconCount = GetIconsCountInFile( fileName );
            return ExtractEx( fileName, size, 0, _iconCount );
        }

        /// <summary>
        /// Extracts the one.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="index">The index.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        /// <exception cref="IconNotFoundException"></exception>
        public static Icon ExtractOne( string fileName, int index, IconSize size )
        {
            try
            {
                var _iconList = ExtractEx( fileName, size, index, 1 );
                return _iconList[ 0 ];
            }
            catch( UnableToExtractIconsException )
            {
                throw new IconNotFoundException( fileName, index );
            }
        }

        /// <summary>
        /// Extracts the one.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="index">The index.</param>
        /// <param name="largeIcon">The large icon.</param>
        /// <param name="smallIcon">The small icon.</param>
        /// <exception cref="IconNotFoundException"></exception>
        public static void ExtractOne( string fileName, int index, out Icon largeIcon,
            out Icon smallIcon )
        {
            var _smallIconList = new List<Icon>( );
            var _largeIconList = new List<Icon>( );
            try
            {
                ExtractEx( fileName, _largeIconList, _smallIconList, index,
                    1 );

                largeIcon = _largeIconList[ 0 ];
                smallIcon = _smallIconList[ 0 ];
            }
            catch( UnableToExtractIconsException )
            {
                throw new IconNotFoundException( fileName, index );
            }
        }

        /// <summary>
        /// Icons from extension.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static Icon IconFromExtension( string extension, IconSize size )
        {
            // Add the '.' to the extension if needed
            if( extension[ 0 ] != '.' )
            {
                extension = '.' + extension;
            }

            extension = extension.ToLower( );

            //opens the registry for the wanted key.
            var _root = Registry.ClassesRoot;
            var _extensionKey = _root.OpenSubKey( extension );
            _extensionKey.GetValueNames( );
            var _applicationKey = _root.OpenSubKey( _extensionKey.GetValue( "" ).ToString( ) );

            //gets the name of the file that have the icon.
            var _iconLocation =
                _applicationKey.OpenSubKey( "DefaultIcon" ).GetValue( "" ).ToString( );

            var _iconPath = _iconLocation.Split( ',' );
            _iconPath[ 1 ] ??= "0";
            IntPtr[ ] _large = new IntPtr[ 1 ], _small = new IntPtr[ 1 ];

            //extracts the icon from the file.
            ExtractIconEx( _iconPath[ 0 ], Convert.ToInt16( _iconPath[ 1 ] ), _large, _small,
                1 );

            return size == IconSize.Large
                ? FromHandle( _large[ 0 ] )
                : FromHandle( _small[ 0 ] );
        }

        /// <summary>
        /// Parse strings in registry who contains the name of the icon and
        /// the index of the icon an return both parts.
        /// </summary>
        /// <param name="regString">The full string in the form "path,index" as found in registry.</param>
        /// <param name="fileName">The "path" part of the string.</param>
        /// <param name="index">The "index" part of the string.</param>
        /// <exception cref="ArgumentNullException">regString</exception>
        /// <exception cref="ArgumentException">The string should not be empty. - regString</exception>
        public static void ExtractInformationFromRegistryString( string regString,
            out string fileName, out int index )
        {
            if( regString == null )
            {
                throw new ArgumentNullException( "regString" );
            }

            if( regString.Length == 0 )
            {
                throw new ArgumentException( "The string should not be empty.", "regString" );
            }

            index = 0;
            var _strArr = regString.Replace( "\"", "" ).Split( ',' );
            fileName = _strArr[ 0 ].Trim( );
            if( _strArr.Length > 1 )
            {
                int.TryParse( _strArr[ 1 ].Trim( ), out index );
            }
        }

        /// <summary>
        /// Creates an array of handles to large or small icons extracted from
        /// the specified executable file, dynamic-link library (DLL), or icon
        /// file.
        /// </summary>
        /// <param name="lpszFile">Name of an executable file, DLL, or icon file from which icons will
        /// be extracted.</param>
        /// <param name="nIconIndex"><para>
        /// Specifies the zero-based index of the first icon to extract. For
        /// example, if this value is zero, the function extracts the first
        /// icon in the specified file.
        /// </para>
        /// <para>
        /// If this value is �1 and <paramref name="phiconLarge" /> and
        /// <paramref name="phiconSmall" /> are both NULL, the function returns
        /// the total number of icons in the specified file. If the file is an
        /// executable file or DLL, the return value is the number of
        /// RT_GROUP_ICON resources. If the file is an .ico file, the return
        /// value is 1.
        /// </para>
        /// <para>
        /// Windows 95/98/Me, Windows NT 4.0 and later: If this value is a
        /// negative number and either <paramref name="phiconLarge" /> or
        /// <paramref name="phiconSmall" /> is not NULL, the function begins by
        /// extracting the icon whose resource identifier is equal to the
        /// absolute value of <paramref name="nIconIndex" />. For example, use -3
        /// to extract the icon whose resource identifier is 3.
        /// </para></param>
        /// <param name="phIconLarge">An array of icon handles that receives handles to the large icons
        /// extracted from the file. If this parameter is NULL, no large icons
        /// are extracted from the file.</param>
        /// <param name="phIconSmall">An array of icon handles that receives handles to the small icons
        /// extracted from the file. If this parameter is NULL, no small icons
        /// are extracted from the file.</param>
        /// <param name="nIcons">Specifies the number of icons to extract from the file.</param>
        /// <returns>
        /// If the <paramref name="nIconIndex" /> parameter is -1, the
        /// <paramref name="phIconLarge" /> parameter is NULL, and the
        /// <paramref name="phiconSmall" /> parameter is NULL, then the return
        /// value is the number of icons contained in the specified file.
        /// Otherwise, the return value is the number of icons successfully
        /// extracted from the file.
        /// </returns>
        [ DllImport( "Shell32", CharSet = CharSet.Auto ) ]
        private static extern int ExtractIconEx( [ MarshalAs( LPTStr ) ] string lpszFile,
            int nIconIndex, IntPtr[ ] phIconLarge, IntPtr[ ] phIconSmall,
            int nIcons );

        /// <summary>
        /// Get the number of icons in the specified file.
        /// </summary>
        /// <param name="fileName">Full path of the file to look for.</param>
        /// <returns></returns>
        private static int GetIconsCountInFile( string fileName )
        {
            return ExtractIconEx( fileName, -1, null, null,
                0 );
        }
    }
}