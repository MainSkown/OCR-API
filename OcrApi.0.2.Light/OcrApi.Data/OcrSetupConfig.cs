using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OcrApi.Data
{
    public class OcrSetupConfig
    {
        [JsonPropertyName("Key")]
        public string key { get; set; }
        [JsonPropertyName("Endpoint")]
        public string endpoint { get; set; }
    }
}
