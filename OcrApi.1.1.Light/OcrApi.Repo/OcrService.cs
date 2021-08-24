using Microsoft.AspNetCore.Http;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
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
    public class OcrService : IOcrService
    {
        private readonly IComputerVisionClient _client;
        private const int numberofCharsInOperationId = 36;

        public OcrService(IComputerVisionClient client)
        {
            _client = client;
        }

        public async Task<OcrTextClass> ReadApiUrl(string url)
        {
            var textHeaders = await _client.ReadAsync(url);

            return await ReadApi(textHeaders.OperationLocation);
        }

        public async Task<OcrTextClass> ReadApiFile(IFormFile Image)
        {
            var file = Path.GetTempFileName();
            var fileInfo = new FileInfo(file);
            fileInfo.Attributes = FileAttributes.Temporary;

            using (Stream fileStream = new FileStream(file, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            var textHeaders = await _client.ReadInStreamAsync(File.OpenRead(file));

            fileInfo.Delete();

            return await ReadApi(textHeaders.OperationLocation);
        }

        private async Task<OcrTextClass> ReadApi(string operationLocation)
        {
            if (operationLocation == null || operationLocation == "")
            {
                throw new OCRFailedException();
            }

            string operationId = operationLocation.Substring(operationLocation.Length - numberofCharsInOperationId);

            ReadOperationResult results;

            do
            {
                results = await _client.GetReadResultAsync(Guid.Parse(operationId));
            } while (results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted);

            if (results.Status == OperationStatusCodes.Failed)
            {
                throw new OCRFailedException();
            }

            var TextResult = results.AnalyzeResult.ReadResults;
            var TextClass = new OcrTextClass();
            var TextList = new List<string>();

            foreach(var page in TextResult)
            {
                foreach(var line in page.Lines)
                {
                    TextList.Add(line.Text);
                    //Console.WriteLine(line.Text);
                }
            }

            TextClass.Text = TextList.ToArray();

            return TextClass;
        }
    }
}
