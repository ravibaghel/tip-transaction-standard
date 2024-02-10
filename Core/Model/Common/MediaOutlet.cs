using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Linear broadcast television or non-linear sell-side service
    /// </summary>
    public struct MediaOutlet
    {
        /// <summary>
        /// Array of identifier objects used to identify the mediaOutletId and its source system
        /// </summary>
        public List<Identifier> MediaOutletIds { get; set; }
        /// <summary>
        /// Station, network name or entity associated to mediaOutletId
        /// </summary>
        public string MediaOutletName { get; set; }
        /// <summary>
        /// Indicates the type of media; for example Local TV, Diginet TV, National Cable TV, Local Cable TV, Video Streaming Service, Satellite, Website, App, Audio Streaming Service, Radio Station, Unwired, Parent 
        /// </summary>
        public string MediaoutletType { get; set; }
        /// <summary>
        /// Station or network station identification (Channel)
        /// </summary>
        public string MediaOutletChannel { get; set; }
        /// <summary>
        /// Media market name such as the DMA or region 
        /// </summary>
        public string MediaOutletMarketName { get; set; }
        /// <summary>
        /// External mediaoutlet reference name 
        /// </summary>
        public string MediaoutletReference { get; set; }
    }
}
