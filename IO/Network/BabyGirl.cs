﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 01-07-2025
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        01-07-2025
// ******************************************************************************************
// <copyright file="BabyGirl.cs" company="Terry D. Eppler">
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
//   BabyGirl.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "ConvertConstructorToMemberInitializers" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "TooWideLocalVariableScope" ) ]
    public class BabyGirl : ServerBase
    {
        /// <summary>
        /// Gets or sets the bytes.
        /// </summary>
        /// <value>
        /// The bytes.
        /// </value>
        public int Count
        {
            get
            {
                return _count;
            }
            private set
            {
                _count = value;
            }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public override int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the buffer.
        /// </summary>
        /// <value>
        /// The buffer.
        /// </value>
        public override byte[ ] Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public override string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public override Socket Socket
        {
            get
            {
                return _socket;
            }
            set
            {
                _socket = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the local.
        /// </summary>
        /// <value>
        /// The local.
        /// </value>
        public override IPAddress Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        /// <summary>
        /// Gets or sets the local.
        /// </summary>
        /// <value>
        /// The local.
        /// </value>
        public override IPEndPoint EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyGirl"/> class.
        /// </summary>
        public BabyGirl( )
        {
            _entry = new object( );
            _count = 1024;
            _port = 5000;
            _data = new byte[ Count ];
            _address = IPAddress.Any;
            _endPoint = new IPEndPoint( _address, Port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _connected = false;
            _busy = false;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyGirl"/> class.
        /// </summary>
        /// <param name="address">The ip address.</param>
        /// <param name="port">The port.</param>
        /// <param name="size"> </param>
        public BabyGirl( IPAddress address, int port = 5000, int size = 1024 )
        {
            _count = size;
            _port = port;
            _data = new byte[ size ];
            _address = address;
            _endPoint = new IPEndPoint( address, port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _connected = false;
            _busy = false;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyGirl"/> class.
        /// </summary>
        /// <param name="address">The ip address.</param>
        /// <param name="port">The port number.</param>
        /// <param name="size">Size of the buffer.</param>
        public BabyGirl( string address, int port = 5000, int size = 1024 )
        {
            _count = size;
            _port = port;
            _data = new byte[ size ];
            _address = IPAddress.Parse( address );
            _endPoint = new IPEndPoint( _address, port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _connected = false;
            _busy = false;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyGirl"/> class.
        /// </summary>
        /// <param name="girl">The client.</param>
        public BabyGirl( BabyGirl girl )
        {
            _count = girl.Count;
            _port = girl.Port;
            _data = girl.Data;
            _address = girl.Address;
            _endPoint = girl.EndPoint;
            _socket = girl.Socket;
            _busy = girl.IsBusy;
        }

        /// <summary>
        /// Connects this instance.
        /// </summary>
        public void Start( )
        {
            try
            {
                var _received = 0;
                _socket.Bind( _endPoint );
                _socket.Listen( 10 );
                _message = "Welcome to the Baby Server!";
                SendNotification( _message );
                _data = Encoding.ASCII.GetBytes( _message );
                _socket.Send( _data, _data.Length, SocketFlags.None );
                while( true )
                {
                    var _client = _socket.Accept( );
                    _data = new byte[ _count ];
                    _received = _client.Receive( _data, _count, SocketFlags.None );
                    if( _received == 0 )
                    {
                        break;
                    }

                    _message = Encoding.ASCII.GetString( _data );
                    SendNotification( _message );
                }
            }
            catch( Exception ex )
            {
                _socket?.Dispose( );
                Fail( ex );
            }
        }

        /// <summary>
        /// Deconstructs the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="port">The port.</param>
        /// <param name="data">The data.</param>
        /// <param name="address">The ip address.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="socket">The socket.</param>
        /// <param name="message">The message.</param>
        public void Deconstruct( out int bytes, out int port, out byte[ ] data,
            out IPAddress address, out IPEndPoint endPoint, out Socket socket,
            out string message )
        {
            bytes = _count;
            port = _port;
            data = _data;
            address = _address;
            endPoint = _endPoint;
            socket = _socket;
            message = _message;
        }
    }
}