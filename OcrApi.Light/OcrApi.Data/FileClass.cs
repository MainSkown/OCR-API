using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace OcrApi.Data
{
    public class FileClass
    {
        [JsonPropertyName("Image")]
        public IFormFile Image { get; set; }
    }
}
