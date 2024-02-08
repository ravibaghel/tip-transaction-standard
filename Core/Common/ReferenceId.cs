using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Common
{
    /// <summary>
    /// Reference details for RFP, Proposal, Order and Invoice 
    /// </summary>
    public struct ReferenceIdentifier
    {
        /// <summary>
        /// Name associated with the organization that is supplying the ids and version information
        /// </summary>
        public string ReferenceSourceName { get; set; }
        /// <summary>
        /// ID associated with the organization sending the information
        /// </summary>
        public string ReferenceSourceId { get; set; }
        /// <summary>
        /// Reference source look up such as a URI to lookup information about the reference source name
        /// </summary>
        public string ReferenceSourceLookup { get; set; }
        /// <summary>
        /// Indicates the type of data that is being provided
        /// </summary>
        public ReferenceType ReferenceType { get; set; }
        /// <summary>
        /// Indicates the number or string ID associated with the reference type
        /// </summary>
        public string ReferenceId { get; set; }
        /// <summary>
        /// Version number associated with the reference id; this is used to track to track changes
        /// </summary>
        public string ReferenceVersionId { get; set; }
        /// <summary>
        /// Free form name used to further identify the type of entity such as the name associated to the RFP, Order, Proposal, or other types of references
        /// </summary>
        public string ReferenceName { get; set; }

    }
}
