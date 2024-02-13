using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Sales element header information
    /// </summary>
    public struct SalesElementHeader
    {
        /// <summary>
        /// mediaOutletId associated with the SalesElement 
        /// </summary>
        public string MediaOutletId { get; set; }
        /// <summary>
        /// SalesElement name; this may be a program, daypart name or another type of sales element 
        /// </summary>
        public string SalesElementName { get; set; }
        /// <summary>
        /// SaleElement identifier 
        /// </summary>
        public string SalesElementId { get; set; }
        /// <summary>
        /// Indicates the type of SalesElement
        /// </summary>
        public string SalesElementType { get; set; }

    }
}
