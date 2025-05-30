﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-30-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-30-2024
// ******************************************************************************************
// <copyright file="Decimals.cs" company="Terry D. Eppler">
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
//   Decimals.cs
// </summary>
// ******************************************************************************************
namespace Badger
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics.CodeAnalysis;
	using System.Runtime.CompilerServices;

	/// <inheritdoc />
	/// <summary>
	/// </summary>
	[ SuppressMessage( "ReSharper", "ConvertToPrimaryConstructor" ) ]
	[ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
	[ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
	[ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
	[ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWithPrivateSetter" ) ]
	public struct Decimals 
	{
		/// <summary>
		/// The start
		/// </summary>
		private decimal _start;

		/// <summary>
		/// The end
		/// </summary>
		private decimal _end;

		/// <summary>
		/// The delta
		/// </summary>
		private decimal _delta;

		/// <summary>
		/// The step
		/// </summary>
		private decimal _step;

		/// <summary>
		/// Initializes a new instance of the <see cref="Decimals"/> struct.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <param name="step">The step.</param>
		public Decimals( decimal start, decimal end, decimal step = 1 )
		{
			_start = start;
			_end = end;
			_delta = end - start;
			_step = 1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Decimals"/> struct.
		/// </summary>
		/// <param name="decimals">The decimals.</param>
		public Decimals( Decimals decimals )
		{
			_start = decimals.Start;
			_end = decimals.End;
			_delta = decimals.Delta;
			_step = decimals.Step;
		}

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Decimals"/> struct.
		/// </summary>
		/// <param name="tuple">
		/// he tuple.
		/// </param>
		public Decimals( (decimal start, decimal end) tuple )
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
		public decimal Start
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
		public decimal End
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
		public decimal Delta
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
		public decimal Step
		{
			get
			{
				return _start;
			}
		}
	}
}