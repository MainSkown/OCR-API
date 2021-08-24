using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcrApi.Web
{
    public static class RegisterServices
    {
        public static void SetupLogger(this IServiceCollection services, string logPath)
        {
            if(logPath == null || logPath == "")
            {
                logPath = "Logs/log.txt";
            }

            Log.Logger = new LoggerConfiguration().WriteTo.File(logPath, rollingInterval: RollingInterval.Day).CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}
