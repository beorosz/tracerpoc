using Microsoft.Extensions.Logging;

namespace FodyTestDotnetCore
{
    public class TestClass
    {
        private readonly ILogger<TestClass> logger;

        public TestClass(ILogger<TestClass> logger)
        {
            this.logger = logger;
        }

        public void SomeMethod()
        {
            logger.Log(LogLevel.Information, "hello");
            System.Console.WriteLine("Hello from SomeMethod!");
        }
    }
}
