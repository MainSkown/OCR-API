using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApi.Data
{
    public class OCRNotSucceededException : Exception
    {
        public OCRNotSucceededException() { }
        public OCRNotSucceededException(string message) : base(message) { }
        public OCRNotSucceededException(string message, Exception inner) : base(message, inner) { }        
    }
}
