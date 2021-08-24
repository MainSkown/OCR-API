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
        public async Task<ActionResult<OcrTextClass>> ReadApiUrl ([FromForm] UrlClass urlClass)
        {      
            if(urlClass.Url == null)
            {
                throw new ArgumentNullException();
            }

            return await _service.ReadApiUrl(urlClass.Url);            
        } 
        
        [HttpGet("file")]        
        public async Task<ActionResult<OcrTextClass>> ReadApiFile (IFormFile Image)
        {
            if(Image == null)
            {
                throw new ArgumentNullException();
            }           
            
            return await _service.ReadApiFile(Image);           
        }        
    }
}
