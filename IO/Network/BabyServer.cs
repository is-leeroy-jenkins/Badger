namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    ///
    /// </summary>
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public abstract class BabyServer
    {
        /// <summary>
        /// The locked object
        /// </summary>
        private protected object _path;

        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The bytes
        /// </summary>
        private protected int _count;

        /// <summary>
        /// The port
        /// </summary>
        private protected int _port;

        /// <summary>
        /// The data
        /// </summary>
        private protected byte[ ] _data;

        /// <summary>
        /// The message
        /// </summary>
        private protected string _message;

        /// <summary>
        /// The socket
        /// </summary>
        private protected Socket _socket;

        /// <summary>
        /// The ip address
        /// </summary>
        private protected IPAddress _ipAddress;

        /// <summary>
        /// The ip end point
        /// </summary>
        private protected IPEndPoint _ipEndPoint;

        /// <summary>
        /// The is connected
        /// </summary>
        private protected bool _connected;

        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
        /// </value>
        public bool IsBusy
        {
            get
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        return _busy;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        return _busy;
                    }
                }
            }
        }

        /// <summary>
        /// Pings the network.
        /// </summary>
        /// <param name="ipAddress">
        /// The host name or address.
        /// </param>
        /// <returns>
        /// bool
        /// </returns>
        private protected bool PingNetwork( string ipAddress )
        {
            bool _status = false;
            try
            {
                ThrowIf.Null( ipAddress, nameof( ipAddress ) );
                using var _ping = new Ping( );
                var _buffer = Encoding.ASCII.GetBytes( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
                var _timeout = 5000; // 5 sec
                var _reply = _ping.Send( ipAddress, _timeout, _buffer );
                if( _reply != null )
                {
                    _status = _reply.Status == IPStatus.Success;
                }
            }
            catch( Exception _ex )
            {
                _status = false;
                Fail( _ex );
            }

            return _status;
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        private protected void SendNotification( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _notify = new Notification( message );
                _notify.Show( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private protected void BeginInit( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private protected void EndInit( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
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
