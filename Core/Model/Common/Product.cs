using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Product category information
    /// </summary>
    public struct Product
    {
        /// <summary>
        /// Array of identifier objects used to identify the product id and its source system
        /// </summary>
        public List<Identifier> ProductIds { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// External product reference name
        /// </summary>
        public string ProductReference { get; set; }
    }
}
