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
        public string Key { get; set; }

        public string Endpoint { get; set; }
    }
}
