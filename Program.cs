using ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    // we then create a main method which initialises our DI container
    static Task Main(string[] args) =>
        CreateHostBuilder(args).Build().RunAsync();

    static IHostBuilder CreateHostBuilder(string[] args) =>
        // let's build our dependency injection container
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(
            (_, services) =>
             // we add the Worker class as a hosted service
             services.AddHostedService<Worker>()
                     // we then add the IWriter interface as a scoped service
                     .AddScoped<IWriter, ConsoleLogger>()
            );
}