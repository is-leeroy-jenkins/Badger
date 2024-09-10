

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.View" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class PivotView : View
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PivotView"/> class.
        /// </summary>
        /// <inheritdoc />
        public PivotView( )
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public PivotView( int index, string name, object value )
            : base( index, name, value )
        {
        }
    }
}
