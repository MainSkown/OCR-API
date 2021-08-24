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
    public class OcrRepo : IOcrRepo
    {
        private readonly IComputerVisionClient _client;
        private const int numberofCharsInOperationId = 36;

        public OcrRepo(IComputerVisionClient client) 
        {
            _client = client;
        }

        public Task<IEnumerable<string>> ReadApiFile(Stream file)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReadResult>> ReadApiUrl(string url)
        {
            var textHeaders = await _client.ReadAsync(url);

            string operationLocation = textHeaders.OperationLocation;
            string operationId = operationLocation.Substring(operationLocation.Length - numberofCharsInOperationId);

            ReadOperationResult results;

            do
            {
                results = await _client.GetReadResultAsync(Guid.Parse(operationId));
            } while (results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted);

            if(results.Status == OperationStatusCodes.Failed)
            {
                throw new OCRNotSucceededException();
            }

            var textUrlFileResults = results.AnalyzeResult.ReadResults;

            List<ReadResult> textList = new List<ReadResult>();            

            textUrlFileResults.ToList().ForEach(item => textList.Add(item));

            return textList;
        }
    }
}
