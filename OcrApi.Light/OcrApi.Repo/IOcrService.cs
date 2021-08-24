using Microsoft.AspNetCore.Http;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApi.Repo
{
    public interface IOcrService
    {
        Task<IEnumerable<ReadResult>> ReadApiUrl(string Url);
        Task<IEnumerable<ReadResult>> ReadApiFile(IFormFile Image);
    }
}
