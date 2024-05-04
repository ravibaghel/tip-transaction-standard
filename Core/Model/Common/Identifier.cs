using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Identifies ids and system source association
    /// </summary>
    public class Identifier
    {
        /// <summary>
        /// Identifier from the buyer or seller that indicates the id assignment 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Identifier from the buyer or seller that indicates the id assignment  version 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Optional identifier indicating the id of the system source providing the the id
        /// </summary>
        public string SrcId { get; set; }
        /// <summary>
        /// Name of the system source that is providing the id 
        /// </summary>
        public string SrcName { get; set; }
    }
}
