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
    public class MediaOutlet
    {
        private List<Identifier> _mediaOutletIds;
        private string _mediaOutletName;
        private string _mediaOutletType;
        /// <summary>
        /// Array of identifier objects used to identify the mediaOutletId and its source system
        /// </summary>
        public List<Identifier> MediaOutletIds
        {
            get { return _mediaOutletIds; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("MediaOutletIds cannot be null or empty.");
                }
                _mediaOutletIds = value;
            }
        }
        /// <summary>
        /// Station, network name or entity associated to mediaOutletId
        /// </summary>
        public string MediaOutletName
        {
            get { return _mediaOutletName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("MediaOutletName cannot be null or empty.");
                }
                _mediaOutletName = value;
            }
        }
        /// <summary>
        /// Indicates the type of media; for example Local TV, Diginet TV, National Cable TV, Local Cable TV, Video Streaming Service, Satellite, Website, App, Audio Streaming Service, Radio Station, Unwired, Parent 
        /// </summary>
        public string MediaOutletType
        {
            get { return _mediaOutletType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("MediaOutletType cannot be null or empty.");
                }
                _mediaOutletType = value;
            }
        }
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
