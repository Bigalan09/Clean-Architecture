using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.CQRS;
using CleanArchitecture.Application.TodoList.Command.CreateTodoList;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Infrastructure.TodoList.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<IDateTime, DateTimeService>();

        services.AddScoped<ICommandHandler<CreateTodoListCommand, int>, CreateTodoListCommandHandler>();

        return services;
    }
}