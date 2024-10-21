// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-30-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-30-2024
// ******************************************************************************************
// <copyright file="Integers.cs" company="Terry D. Eppler">
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
//   Integers.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
	using System;
	using System.Diagnostics.CodeAnalysis;

	/// <inheritdoc />
	/// <summary>
	/// </summary>
	[ SuppressMessage( "ReSharper", "ConvertToPrimaryConstructor" ) ]
	[ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
	[ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
	[ SuppressMessage( "ReSharper", "NotAccessedField.Local" ) ]
	[ SuppressMessage( "ReSharper", "UnusedMember.Global" ) ]
	[ SuppressMessage( "ReSharper", "ArrangeAccessorOwnerBody" ) ]
	[ SuppressMessage( "ReSharper", "UnusedMember.Local" ) ]
	public struct Integers 
	{
		/// <summary>
		/// The start
		/// </summary>
		private int _start;

		/// <summary>
		/// The end
		/// </summary>
		private int _end;

		/// <summary>
		/// The delta
		/// </summary>
		private int _delta;

		/// <summary>
		/// The step
		/// </summary>
		private int _step;

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Integers"/> struct.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <param name="step">The step.</param>
		public Integers( int start, int end, int step = 1 )
		{
			_start = start;
			_end = end;
			_delta = end - start;
			_step = 1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Decimals"/> struct.
		/// </summary>
		/// <param name="integers">The decimals.</param>
		public Integers( Integers integers)
		{
			_start = integers.Start;
			_end = integers.End;
			_delta = integers.Delta;
			_step = integers.Step;
		}

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Integers"/> struct.
		/// </summary>
		/// <param name="tuple">
		/// he tuple.
		/// </param>
		public Integers( ( int start, int end ) tuple )
		{
			_start = tuple.start;
			_end = tuple.end;
			_delta = _start - _end;
			_step = 1;
		}

		/// <summary>
		/// Gets or sets the start.
		/// </summary>
		/// <value>
		/// The start.
		/// </value>
		public int Start
		{
			get
			{
				return _start;
			}
			private set
			{
				_start = value;
			}
		}

		/// <summary>
		/// Gets or sets the end.
		/// </summary>
		/// <value>
		/// The end.
		/// </value>
		public int End
		{
			get
			{
				return _end;
			}
			private set
			{
				_end = value;
			}
		}

		/// <summary>
		/// Gets the delta.
		/// </summary>
		/// <value>
		/// The delta.
		/// </value>
		public int Delta
		{
			get
			{
				return _start;
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
				return _start;
			}
		}
	}
}