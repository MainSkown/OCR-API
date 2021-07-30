using System.Text.Json.Serialization;

namespace OcrApi.Data
{
    public class UrlClass
    {
        [JsonPropertyName("url")]
        public string url { get; set; }
    }
}
