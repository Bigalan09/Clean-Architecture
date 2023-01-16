using CleanArchitecture.ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var services = new ServiceCollection();
var builder = services
    .AddScoped<Startup>()
    .AddApplicationServices()
    .AddInfrastructureServices(configuration)
    .BuildServiceProvider();

var startup =
    builder.GetRequiredService<Startup>();

await startup.RunAsync();

Console.WriteLine("\n\nPress any key to continue...");
Console.ReadKey();