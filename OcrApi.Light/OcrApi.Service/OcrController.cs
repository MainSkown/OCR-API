using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using OcrApi.Data;
using OcrApi.Repo;

namespace OcrApi.Service
{
    [Route("ocr")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        private readonly IOcrService _service;

        public OcrController(IOcrService service)
        {            
            _service = service;
        }       

        [HttpGet("url")]
        public async Task<ActionResult<IEnumerable<ReadResult>>> ReadApiUrl ([FromForm] UrlClass urlClass)
        {            
            var list = await _service.ReadApiUrl(urlClass.url);

            //.ToList() needs to be here, otherwise throws error
            return list.ToList();
        } 
        
        [HttpGet("file")]        
        public async Task<ActionResult<IEnumerable<ReadResult>>> ReadApiFile (IFormFile Image)
        {
            if(Image == null)
            {
                throw new ArgumentNullException();
            }           
            
            var list = await _service.ReadApiFile(Image);

            return list.ToList();
        }        
    }
}
