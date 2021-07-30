using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OcrApi.Data;
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
            var config = new OcrSetupConfig();
            configuration.Bind("OcrData", config);

            IComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(config.key))
            { Endpoint = config.endpoint };
            services.AddSingleton(client);
        }
    }
}
