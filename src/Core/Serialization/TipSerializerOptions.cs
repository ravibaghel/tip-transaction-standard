using System.Text.Json;

namespace Tip.TransactionStandard.Serialization;

public static class TipSerializerOptions
{
    public static JsonSerializerOptions CreateJson()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
        };

        options.Converters.Add(new EnumMemberJsonConverterFactory());
        options.Converters.Add(new FlexibleStringJsonConverter());
        options.Converters.Add(new DynamicOrDateJsonConverter());
        return options;
    }
}
