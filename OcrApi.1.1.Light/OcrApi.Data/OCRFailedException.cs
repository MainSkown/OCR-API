using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApi.Data
{
    public class OCRFailedException : Exception
    {
        public OCRFailedException() { }
        public OCRFailedException(string message) : base(message) { }
        public OCRFailedException(string message, Exception inner) : base(message, inner) { }        
    }
}
