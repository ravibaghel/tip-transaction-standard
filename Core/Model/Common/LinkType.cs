using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Linking of matching or related commercials 
    /// </summary>
    public struct LinkTypeModel
    {
        /// <summary>
        /// Indicates the link constraint between two or more units (spots)
        /// </summary>
        public LinkTypeEnum LinkType { get; set; }
        /// <summary>
        /// Unique number to communicate the association of two or more units within a link type
        /// </summary>
        public int? LinkNum { get; set; }
        /// <summary>
        /// Airing sequential order for the units linked together such as A or B, etc. 
        /// </summary>
        public int? LinkSeq { get; set; }
    }
}
