using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Common.CQRS.Internal;

internal class QueryDispatcher<TQuery, TResponse> : IQueryDispatcher<TResponse> where TQuery : IQuery<TResponse>
{
    public Task<TResponse> Handle(
        IQuery<TResponse> query,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken)
    {
        return serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>().Handle((TQuery)query, cancellationToken);
    }
}

internal class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> Dispatch<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var queryType = query.GetType();

        var handler = (IQueryDispatcher<TResponse>)(Activator.CreateInstance(typeof(QueryDispatcher<,>).MakeGenericType(queryType, typeof(TResponse)))
                                             ?? throw new InvalidOperationException($"Could not create a QueryDispatcher type for {queryType}"));

        return handler.Handle(query, _serviceProvider, cancellationToken);
    }
}
