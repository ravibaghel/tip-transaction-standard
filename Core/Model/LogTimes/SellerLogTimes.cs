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
using Baghel.TIP.Core.Utils;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Baghel.TIP.Core.Model.LogTimes
{
    /// <summary>
    /// Allows the seller to send to the buyer the log times information. No Request from buyer is required.
    /// </summary>
    public class SellerLogTimes : Common.Model,IFormat<SellerLogTimes>
    {
        
        private readonly IValidate<SellerLogTimes> validate;

        public SellerLogTimes()
        {
            this.validate = Factory.CreateValidation();
        }
        public SellerLogTimes(IValidate<SellerLogTimes> validate)
        {
            this.validate = validate;
        }
        public TransactionHeader TransactionHeader { get; set; }
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

        public SellerLogTimes FromJSON(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<SellerLogTimes>(json, options);
        }

        public string ToJSON()
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            serializeOptions.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Serialize(this, serializeOptions);
        }

        public virtual void Validate()
        {
            validate.Validate(this);
        }
    }
}
