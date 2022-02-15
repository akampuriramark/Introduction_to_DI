using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    // let's make our class implement the IHostedService interface.
    internal class Worker: IHostedService
    {
        // To implement the interface, we need to implement the StartAsync and StopAsync methods ad defined by the interface
        // These are called to start and stop service execution respectively.

        // we in this case create a property of the IWriter class that we are going to use to log to the console
        private readonly IWriter _consoleLogger;

        // we define a constructor of the Worker class that gets the ConsoleLogger object from the DI container.
        // this in short is what is called Injection
        public Worker(IWriter consoleLogger)
        {
            // we set our readonly property to the object from the DI container
            _consoleLogger = consoleLogger;
        }

        // Let's now edit the ExecuteTaskA and ExecuteTaskB methods so that they now use
        // the Write method implemented in the ConsoleLogger

        // method that is called to perform an action A
        public void ExecuteTaskA()
        {
            // log the start time of task A to console
            _consoleLogger.Write($"Task A started at {DateTime.Now}");
        }
        // method that is called to perform an action B
        public void ExecuteTaskB()
        {
            // log the start time of task B to console
            _consoleLogger.Write($"Task B started at {DateTime.Now}");
        }

        // Finally, we are going to call our ExecuteTaskA and ExecuteTaskB methods in our new StartAsync and StopAsync respectively.
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // run a task that executes Task A
            return Task.Run(ExecuteTaskA);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // run a task that executes Task B
            return Task.Run(ExecuteTaskB); 
        }
    }
}
