namespace Enigma.Presentation.API
{
    using System;
    using System.Linq;
    using System.Diagnostics;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Hosting.WindowsServices;
    using Microsoft.AspNetCore.Server.Kestrel.Core;

    using NLog;
    using NLog.Web;
    using Microsoft.Extensions.Logging;
    using LogLevel = Microsoft.Extensions.Logging.LogLevel;
   
    using static Infrastructure.Configuration.ConfigurationManager;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                .ConfigureNLog(AppStart.NLogConfigurationFile)
                .GetCurrentClassLogger();

            try
            {
                var isService = 
                    !Debugger.IsAttached && !args.Contains(Args.RunAsConsoleArgument);

                logger.Info(
                    $"Application will start as {(isService ? "Service" : "Console Application")}");

                BuildAndRunApplication(
                    args.Where(argument => !argument.Equals(Args.RunAsConsoleArgument)).ToArray(), 
                    isService);
            }
            catch (Exception exception)
            {
                logger.Error(
                    exception, "Execution stopped because of exception");

                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        private static void BuildAndRunApplication(string[] args, bool isService)
        {
            var webHostBuilder = CreateWebHostBuilder(args).Build();

            if (isService)
            {
                webHostBuilder.RunAsService();
            }
            else
            {
                webHostBuilder.Run();
            }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(ConfigureLogging)
                .UseNLog();
        }

        private static void ConfigureKestrel(KestrelServerOptions options)
        {
            options.Limits.MaxConcurrentConnections = null;
            options.Limits.MinRequestBodyDataRate = null;
            options.Limits.MinResponseDataRate = null;
        }

        private static void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
        }
    }
}
