

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class InputData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputData"/> class.
        /// </summary>
        public InputData( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputData"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <param name="category">The category.</param>
        /// <param name="label">The label.</param>
        public InputData( string text, float number, string category, int label )
        {
            Text = text;
            Number = number;
            Category = category;
            Label = label;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public float Number { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public int Label { get; set; }
    }
}
