using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Advertising brand information
    /// </summary>
    public struct Brand
    {
        /// <summary>
        /// Array of identifier objects used to identify the brand id and its source system 
        /// </summary>
        public List<Identifier> BrandIds { get; set; }
        /// <summary>
        /// Brand Name
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// External brand reference name
        /// </summary>
        public string BrandReference { get; set; }
    }
}
