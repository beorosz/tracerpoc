using Microsoft.Extensions.DependencyInjection;

namespace FodyTestDotnetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var myClass = serviceProvider.GetService<TestClass>();
            myClass.SomeMethod();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(TestClass));
            serviceCollection.AddLogging(builder => builder.AddLog4Net("log4net.config"));
        }
    }
}
