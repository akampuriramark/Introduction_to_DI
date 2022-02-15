namespace ConsoleApp
{
    // our ConsoleLogger class implements the IWriter interface
    internal class ConsoleLogger : IWriter
    {
        // we implement the Write method to log to console
        public void Write(string message)
        {
            Console.WriteLine($"ConsoleLogger.LogToConsole(message: \"{message}\")");
        }
    }
}
