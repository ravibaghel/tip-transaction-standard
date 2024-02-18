using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Validations;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Baghel.TIP.Core.Model.LogTimes
{
    /// <summary>
    /// Allows the seller to send to the buyer the log times information. No Request from buyer is required.
    /// </summary>
    public class SellerLogTimes : Common.Model
    {
        
        private readonly IValidate<Model.Common.Model> validate;

        public SellerLogTimes()
        {
            
        }
        public SellerLogTimes(IValidate<Model.Common.Model> validate)
        {
            this.validate = validate;
        }
      
        /// <summary>
        /// String that indicates additional information the seller can send to the buyer
        /// </summary>
        public string ExternalComment { get; set; }
        /// <summary>
        /// Array of MediaOutlet objects  
        /// </summary>
        public List<MediaOutlet> MediaOutlets { get; set; }
        /// <summary>
        /// Units listed in the API units can be defined by the system that is creating the API. 
        /// </summary>
        public List<Unit> Units { get; set; }

        public virtual void Validate()
        {
            validate.Validate(this);
        }
    }
}
