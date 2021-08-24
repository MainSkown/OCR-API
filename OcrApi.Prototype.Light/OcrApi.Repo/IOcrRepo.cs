using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApi.Repo
{
    public interface IOcrRepo
    {
        Task<IEnumerable<ReadResult>> ReadApiUrl(string Url);
        Task<IEnumerable<string>> ReadApiFile(Stream file);
    }
}
