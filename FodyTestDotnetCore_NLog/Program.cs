using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace FodyTestDotnetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();            
            ConfigureServicesWithNLog(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var myClass = serviceProvider.GetService<TestClass>();
            myClass.SomeMethod();
        }
        
        private static void ConfigureServicesWithNLog(ServiceCollection serviceCollection)
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

            NLog.LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

            serviceCollection.AddSingleton(typeof(TestClass));
            serviceCollection.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog(config);
            });
        }
    }
}
