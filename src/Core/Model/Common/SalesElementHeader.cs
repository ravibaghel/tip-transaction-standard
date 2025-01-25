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
    public class SalesElementHeader
    {
        private string _mediaOutletId;
        private string _salesElementName;
        private string _salesElementId;
        private SalesElementType _salesElementType;
        /// <summary>
        /// mediaOutletId associated with the SalesElement 
        /// </summary>
        public string MediaOutletId
        {
            get { return _mediaOutletId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("MediaOutletId cannot be null or empty.");
                }
                _mediaOutletId = value;
            }
        }
        /// <summary>
        /// SalesElement name; this may be a program, daypart name or another type of sales element 
        /// </summary>
        public string SalesElementName
        {
            get { return _salesElementName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("SalesElementName cannot be null or empty.");
                }
                _salesElementName = value;
            }
        }
        /// <summary>
        /// SaleElement identifier 
        /// </summary>
        public string SalesElementId
        {
            get { return _salesElementId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("SalesElementId cannot be null or empty.");
                }
                _salesElementId = value;
            }
        }
        /// <summary>
        /// Indicates the type of SalesElement
        /// </summary>
        public SalesElementType SalesElementType
        {
            get { return _salesElementType; }
            set
            {
                if (!Enum.IsDefined(typeof(SalesElementType), value))
                {
                    throw new ArgumentException("Invalid SalesElementType.");
                }
                _salesElementType = value;
            }
        }

    }
}
