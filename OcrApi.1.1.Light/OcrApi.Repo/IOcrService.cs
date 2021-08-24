using Microsoft.AspNetCore.Http;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using OcrApi.Data;
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
        Task<OcrTextClass> ReadApiUrl(string Url);
        Task<OcrTextClass> ReadApiFile(IFormFile Image);
    }
}
