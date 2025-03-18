// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-23-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-23-2025
// ******************************************************************************************
// <copyright file="DomainSystem.cs" company="Terry D. Eppler">
//    Badger is a small and simple windows (wpf) application for interacting with the OpenAI API
//    that's developed in C-Sharp under the MIT license.C#.
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
//   DomainSystem.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class DomainSystem
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DomainSystem"/> class.
        /// </summary>
        public DomainSystem( )
        {
        }

        /// <summary>
        /// Gets the IP addresses associated with a host name.
        /// </summary>
        public List<IPAddress> GetHostAddresses( string hostName )
        {
            try
            {
                ThrowIf.Empty( hostName, nameof( hostName ) );
                var _ipAddresses = Dns.GetHostAddresses( hostName );
                return _ipAddresses.ToList( );
            }
            catch( Exception ex )
            {
                var _message = $"Failed to resolve IP addresses for {hostName}.";
                throw new InvalidOperationException( _message, ex );
            }
        }

        /// <summary>
        /// Gets the host name for the given IP address.
        /// </summary>
        public string GetHostName( IPAddress ipAddress )
        {
            try
            {
                return Dns.GetHostEntry( ipAddress ).HostName;
            }
            catch( Exception ex )
            {
                var _message = $"Failed to resolve host name for {ipAddress}.";
                throw new InvalidOperationException( _message, ex );
            }
        }

        /// <summary>
        /// Gets the local machine's IP address.
        /// </summary>
        public IPAddress GetLocalAddress( )
        {
            try
            {
                return Dns.GetHostAddresses( Dns.GetHostName( ) )?.FirstOrDefault( );
            }
            catch( Exception ex )
            {
                var _message = "Failed to retrieve the local IP address.";
                throw new InvalidOperationException( _message, ex );
            }
        }

        /// <summary>
        /// Gets the fully qualified domain name (FQDN) of the local machine.
        /// </summary>
        public string GetLocalHostName( )
        {
            try
            {
                return Dns.GetHostName( );
            }
            catch( Exception ex )
            {
                var _message = "Failed to retrieve the local host name.";
                throw new InvalidOperationException( _message, ex );
            }
        }

        /// <summary>
        /// Pings a host name or IP address to check reachability.
        /// </summary>
        public bool CanReachHost( string host )
        {
            try
            {
                ThrowIf.Empty( host, nameof( host ) );
                var _ipAddresses = GetHostAddresses( host );
                return _ipAddresses.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Performs a reverse DNS lookup to find all alias names for a given IP address.
        /// </summary>
        public List<string> GetAliases( IPAddress ipAddress )
        {
            try
            {
                var _hostEntry = Dns.GetHostEntry( ipAddress );
                return _hostEntry.Aliases.ToList( );
            }
            catch( Exception ex )
            {
                var _message = $"Failed to resolve aliases for {ipAddress}.";
                throw new InvalidOperationException( _message, ex );
            }
        }

        /// <summary>
        /// Validates if a given string is a valid host name.
        /// </summary>
        public bool IsValidHostName( string hostName )
        {
            if( string.IsNullOrWhiteSpace( hostName ) )
            {
                return false;
            }

            try
            {
                // Attempt to resolve to ensure validity
                Dns.GetHostEntry( hostName );
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates if a given string is a valid IP address.
        /// </summary>
        public bool IsValidIpAddress( string ipAddress )
        {
            return IPAddress.TryParse( ipAddress, out var _ );
        }

        /// <summary>
        /// Resolves both IP addresses and aliases for a given host name.
        /// </summary>
        public (List<IPAddress> IpAddresses, List<string> Aliases) ResolveHost( string hostName )
        {
            try
            {
                var _hostEntry = Dns.GetHostEntry( hostName );
                var _ipAddresses = _hostEntry.AddressList.ToList( );
                var _aliases = _hostEntry.Aliases.ToList( );
                return ( _ipAddresses, _aliases );
            }
            catch( Exception ex )
            {
                var _message = $"Failed to resolve host {hostName}.";
                throw new InvalidOperationException( _message, ex );
            }
        }
    }
}