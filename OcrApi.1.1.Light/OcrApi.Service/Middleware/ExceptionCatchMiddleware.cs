using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;
using OcrApi.Data;

namespace GithubApi.Service.Middleware
{
    public class ExceptionCatchMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionCatchMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                ErrorResponse(ex, httpContext);
            }
        }

        async void ErrorResponse(Exception ex, HttpContext httpContext)
        {
            string message;
            int statusCode;
            _logger.Error($"Error occured at: {ex.Message}, type: {ex}");
            Console.WriteLine($"Error occured at: {ex.Message}, type: {ex}");

            switch (ex)
            {
                case HttpRequestException:
                    message = "Couldn't find user";
                    //It's possible to change message by adding a function that will change it acording to statusCode
                    statusCode = (int)((HttpRequestException)ex).StatusCode;
                    break;

                case OCRFailedException:
                    message = "OCR couldn't succsed operation";
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;

                case ArgumentNullException:
                    message = "Image can't be null";
                    statusCode = StatusCodes.Status400BadRequest;
                    break;


                default:
                    message = "Internal Server Error";
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(message);
        }

    }
}
