// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-21-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-21-2024
// ******************************************************************************************
// <copyright file="DateTimes.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  2024  Terry D. Eppler
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   DateTimes.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "ConvertToPrimaryConstructor" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public struct DateTimes
    {
        /// <summary>
        /// The start
        /// </summary>
        private DateTime _startDate;

        /// <summary>
        /// The end
        /// </summary>
        private DateTime _endDate;

        /// <summary>
        /// The delta
        /// </summary>
        private readonly TimeSpan _delta;

        /// <summary>
        /// The step
        /// </summary>
        private readonly int _step;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimes"/> struct.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="step">The step.</param>
        public DateTimes( DateTime startDate, DateTime endDate, int step = 1 )
        {
            _startDate = startDate;
            _endDate = endDate;
            _delta = endDate - startDate;
            _step = step;
        }

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public DateTime Start
        {
            get
            {
                return _startDate;
            }
            private set
            {
                _startDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public DateTime End
        {
            get
            {
                return _endDate;
            }
            private set
            {
                _endDate = value;
            }
        }

        /// <summary>
        /// Gets the delta.
        /// </summary>
        /// <value>
        /// The delta.
        /// </value>
        public TimeSpan Delta
        {
            get
            {
                return _delta;
            }
        }

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        public int Step
        {
            get
            {
                return _step;
            }
        }
    }
}