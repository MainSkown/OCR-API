using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcrApi.Web
{
    public static class SetupOcr
    {
        public static void SetupAzureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            IComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(configuration.GetSection("Key").Value))
            { Endpoint = configuration.GetSection("Endpoint").Value };
            services.AddSingleton(client);
        }
    }
}
