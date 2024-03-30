using Baghel.TIP.Core.Model.LogTimes;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Baghel.TIP.Core.Model.Common
{
    public abstract class ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Error Error { get; set; }

        public virtual ModelBase FromJSON(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<SellerLogTimes>(json, options);
        }

        public virtual string ToJSON()
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            serializeOptions.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Serialize(this, serializeOptions);
        }

    }
}