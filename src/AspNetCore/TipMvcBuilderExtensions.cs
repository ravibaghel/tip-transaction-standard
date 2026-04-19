using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Tip.TransactionStandard.Serialization;

namespace Tip.TransactionStandard.AspNetCore;

public static class TipMvcBuilderExtensions
{
    public static IMvcBuilder AddTipTransactionStandard(this IMvcBuilder builder)
    {
        builder.AddXmlSerializerFormatters();
        builder.Services.Configure<JsonOptions>(options =>
        {
            var serializerOptions = TipSerializerOptions.CreateJson();
            options.JsonSerializerOptions.PropertyNamingPolicy = serializerOptions.PropertyNamingPolicy;
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = serializerOptions.PropertyNameCaseInsensitive;
            options.JsonSerializerOptions.WriteIndented = serializerOptions.WriteIndented;
            options.JsonSerializerOptions.Converters.Clear();

            foreach (var converter in serializerOptions.Converters)
            {
                options.JsonSerializerOptions.Converters.Add(converter);
            }
        });

        return builder;
    }
}
