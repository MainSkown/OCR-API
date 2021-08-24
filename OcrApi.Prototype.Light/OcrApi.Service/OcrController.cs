using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using OcrApi.Data;
using OcrApi.Repo;

namespace OcrApi.Service
{
    [Route("ocr/api")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        private readonly IOcrRepo _repo;

        public OcrController(IOcrRepo repo)
        {            
            _repo = repo;
        }
        /*
        //For testing
        [HttpGet]
        public ActionResult<string> TestTask()
        {            
            return "Test";
        }
        */

        [HttpGet("url")]
        public async Task<ActionResult<IEnumerable<ReadResult>>> ReadApiUrl (UrlClass urlClass)
        {            
            var list = await _repo.ReadApiUrl(urlClass.url);
            return list.ToList();
        } 
        
    }
}
