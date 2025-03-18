
namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class SignalData : PropertyChangedBase
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SignalData"/> class.
        /// </summary>
        public SignalData( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalData"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="label">The label.</param>
        public SignalData( double[ ] values, string label = null )
        {
            Values = values;
            Label = label;
        }

        /// <summary>
        /// Gets or sets the names.
        /// </summary>
        /// <value>
        /// The names.
        /// </value>
        public double[] Values { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }
    }
}
