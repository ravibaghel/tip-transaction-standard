using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;

namespace Tip.TransactionStandard.Serialization;

public static class TipPayloadSerializer
{
    public static string SerializeJson<T>(T value, JsonSerializerOptions? options = null) =>
        JsonSerializer.Serialize(value, options ?? TipSerializerOptions.CreateJson());

    public static T DeserializeJson<T>(string payload, JsonSerializerOptions? options = null) =>
        JsonSerializer.Deserialize<T>(payload, options ?? TipSerializerOptions.CreateJson())
        ?? throw new InvalidOperationException($"Unable to deserialize JSON payload into {typeof(T).Name}.");

    public static string SerializeXml<T>(T value)
    {
        var serializer = new XmlSerializer(typeof(T));
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, TipXml.Namespace);
        namespaces.Add("i", TipXml.XmlSchemaInstanceNamespace);
        using var stream = new Utf8StringWriter();
        serializer.Serialize(stream, value, namespaces);
        return stream.ToString();
    }

    public static T DeserializeXml<T>(string payload)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(payload);
        return (T)(serializer.Deserialize(reader)
            ?? throw new InvalidOperationException($"Unable to deserialize XML payload into {typeof(T).Name}."));
    }

    private sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
