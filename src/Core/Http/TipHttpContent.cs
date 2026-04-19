using System.Net.Http.Headers;
using System.Text;
using Tip.TransactionStandard.Serialization;

namespace Tip.TransactionStandard.Http;

public static class TipHttpContent
{
    public const string JsonMediaType = "application/json";
    public const string XmlMediaType = "application/xml";

    public static StringContent CreateJson<T>(T value)
    {
        var payload = TipPayloadSerializer.SerializeJson(value);
        return new StringContent(payload, Encoding.UTF8, JsonMediaType);
    }

    public static StringContent CreateXml<T>(T value)
    {
        var payload = TipPayloadSerializer.SerializeXml(value);
        return new StringContent(payload, Encoding.UTF8, XmlMediaType);
    }

    public static async Task<T> ReadAsync<T>(HttpContent content, CancellationToken cancellationToken = default)
    {
        var payload = await content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var mediaType = content.Headers.ContentType?.MediaType;

        return string.Equals(mediaType, XmlMediaType, StringComparison.OrdinalIgnoreCase)
            || string.Equals(mediaType, "text/xml", StringComparison.OrdinalIgnoreCase)
            ? TipPayloadSerializer.DeserializeXml<T>(payload)
            : TipPayloadSerializer.DeserializeJson<T>(payload);
    }

    public static void AcceptJson(HttpRequestHeaders headers) =>
        headers.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));

    public static void AcceptXml(HttpRequestHeaders headers) =>
        headers.Accept.Add(new MediaTypeWithQualityHeaderValue(XmlMediaType));
}
