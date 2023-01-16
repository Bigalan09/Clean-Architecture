using CleanArchitecture.Application.Common.CQRS;
using CleanArchitecture.Application.Common.CQRS.Internal;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICommandDispatcher, CommandDispatcher>()
            .AddScoped<IQueryDispatcher, QueryDispatcher>();

        return services;
    }
}