// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-10-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-10-2023
// ******************************************************************************************
// <copyright file="Amount.cs" company="Terry D. Eppler">
//    Badger is a Federal Budget, Finance, and Accounting application
//    for the US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
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
//    Contact at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   Amount.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeModifiersOrder" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    public class Amount
    {
        /// <summary>
        /// Gets or sets the _initial.
        /// </summary>
        /// <value>
        /// The _initial.
        /// </value>
        private double _initial;

        /// <summary>
        /// Gets or sets the _delta.
        /// </summary>
        /// <value>
        /// The _delta.
        /// </value>
        private double _delta;

        /// <summary>
        /// Gets or sets the _value.
        /// </summary>
        /// <value>
        /// The _value.
        /// </value>
        private double _value;

        /// <summary>
        /// Gets or sets the numeric.
        /// </summary>
        /// <value>
        /// The numeric.
        /// </value>
        private string _numeric;

        /// <summary>
        /// Gets or sets the initial.
        /// </summary>
        /// <value>
        /// The initial.
        /// </value>
        public double Initial
        {
            get
            {
                return _initial;
            }
            private protected set
            {
                _initial = value;
            }
        }

        /// <summary>
        /// Gets or sets the delta.
        /// </summary>
        /// <value>
        /// The delta.
        /// </value>
        public double Delta
        {
            get
            {
                return _delta;
            }
            private protected set
            {
                _delta = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value
        {
            get
            {
                return _value;
            }
            private protected set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Gets or sets the numeric.
        /// </summary>
        /// <value>
        /// The numeric.
        /// </value>
        public string Numeric
        {
            get
            {
                return _numeric;
            }
            private protected set
            {
                _numeric = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amount"/> class.
        /// </summary>
        public Amount( )
        {
            Numeric = "Amount";
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Amount" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Amount( double value = 0.0 )
            : this( )
        {
            Value = value;
            Delta = Initial - Value;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Amount" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Amount( decimal value = 0 )
            : this( )
        {
            Value = (double)value;
            Delta = Initial - Value;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Amount" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Amount( float value = 0 )
            : this( )
        {
            Value = value;
            Delta = Initial - Value;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amount"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="numeric">The numeric.</param>
        public Amount( DataRow dataRow, string numeric )
        {
            Numeric = numeric;
            Value = double.Parse( dataRow[ numeric ].ToString( ) ?? "0.0" );
            Delta = Initial - Value;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Amount"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public Amount( Amount amount )
        {
            Numeric = amount.Numeric;
            Value = amount.Value;
            Delta = 0.0;
        }

        /// <summary>
        /// Increases the specified increment.
        /// </summary>
        /// <param name="increment">The increment.</param>
        public void Increase( int increment )
        {
            try
            {
                Delta = increment;
                Value += increment;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Decreases the specified decrement.
        /// </summary>
        /// <param name="decrement">The decrement.</param>
        public void Decrease( int decrement )
        {
            try
            {
                Delta = decrement;
                Value -= decrement;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }

        /// <summary>
        /// Determines whether the specified amount is equal.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns>
        ///   <c>true</c> if the specified amount is equal;
        ///   otherwise,
        /// <c>false</c>.
        /// </returns>
        public bool IsEqual( IAmount amount )
        {
            if( amount != null )
            {
                try
                {
                    return ( ( amount?.Value == Value )
                        && ( amount?.Numeric?.Equals( Numeric ) == true ) );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified first is equal.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        ///   <c>true</c> if the specified first is equal; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsEqual( IAmount first, IAmount second )
        {
            if( ( first != null )
               && ( second != null ) )
            {
                try
                {
                    return ( ( first?.Numeric == second?.Numeric )
                        && ( first.Value == second.Value ) );
                }
                catch( Exception _ex )
                {
                    Fail( _ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Called when [changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        public void OnChanged( object sender, EventArgs e )
        {
            try
            {
                var _message = new MessageWindow( "Not Yet Implemented" );
                _message.Show( );
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