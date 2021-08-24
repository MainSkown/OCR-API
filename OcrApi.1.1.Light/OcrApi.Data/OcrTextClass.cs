using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OcrApi.Data
{
    [JsonArray]
    public class OcrTextClass
    {
        public IEnumerable<string> Text { get; set; }
    }
}
