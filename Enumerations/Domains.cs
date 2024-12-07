// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 12-07-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        12-07-2024
// ******************************************************************************************
// <copyright file="Domains.cs" company="Terry D. Eppler">
//    Badger is a budget execution & data analysis tool for federal budget analysts
//     with the EPA based on WPF, Net 6, and is written in C#.
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
//   Domains.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public enum Domains
    {
        /// <summary>
        /// "https://www.google.com/search?q=site:www.epa.gov "
        /// </summary>
        EPA,

        /// <summary>
        /// "https://www.google.com/search?q=site:data.gov "
        /// </summary>
        DATA,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.gpo.gov "
        /// </summary>
        GPO,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.govinfo.gov "
        /// </summary>
        USGI,

        /// <summary>
        /// "https://www.google.com/search?q=site:crsreports.congress.gov "
        /// </summary>
        CRS,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.loc.gov "
        /// </summary>
        LOC,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.whitehouse.gov "
        /// </summary>
        OMB,

        /// <summary>
        /// "https://www.google.com/search?q=site:fiscal.treasury.gov "
        /// </summary>
        UST,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.nasa.gov "
        /// </summary>
        NASA,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.noaa.gov "
        /// </summary>
        NOAA,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.doi.gov "
        /// </summary>
        DOI,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.nps.gov "
        /// </summary>
        NPS,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.gsa.gov "
        /// </summary>
        GSA,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.archives.gov "
        /// </summary>
        NARA,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.commerce.gov "
        /// </summary>
        DOC,

        /// <summary>
        /// The HHS "https://www.google.com/search?q=site:www.hhs.gov "
        /// </summary>
        HHS,

        /// <summary>
        /// The NRC "https://www.google.com/search?q=site:www.nrc.gov "
        /// </summary>
        NRC,

        /// <summary>
        /// The doe  "https://www.google.com/search?q=site:www.energy.gov "
        /// </summary>
        DOE,

        /// <summary>
        /// The NSF https://www.google.com/search?q=site:www.nsf.gov "
        /// </summary>
        NSF,

        /// <summary>
        /// The usda  "https://www.google.com/search?q=site:www.usda.gov "
        /// </summary>
        USDA,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.csb.gov "
        /// </summary>
        CSB,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.irs.gov "
        /// </summary>
        IRS,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.fda.gov "
        /// </summary>
        FDA,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.cdc.gov "
        /// </summary>
        CDC,

        /// <summary>
        /// "https://www.google.com/search?q=site:usace.army.mil "
        /// </summary>
        ACE,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.dhs.gov "
        /// </summary>
        DHS,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.defense.gov "
        /// </summary>
        DOD,

        /// <summary>
        /// "https://www.google.com/search?q=site:usno.navy.mil "
        /// </summary>
        USNO,

        /// <summary>
        /// "https://www.google.com/search?q=site:www.weather.gov "
        /// </summary>
        NWS
    }
}