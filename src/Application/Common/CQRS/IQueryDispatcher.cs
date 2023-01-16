namespace CleanArchitecture.Application.Common.CQRS;

public interface IQueryDispatcher
{
    /// <summary>
    /// Asynchronously send a query to a handler.
    /// </summary>
    /// <typeparam name="TResponse">The response type<./typeparam>
    /// <param name="query">The query object.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>A task that represents the dispatch operation. The task result contains the handler response.</returns>
    Task<TResponse> Dispatch<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}

internal interface IQueryDispatcher<TResponse>
{
    Task<TResponse> Handle(IQuery<TResponse> query, IServiceProvider serviceProvider, CancellationToken cancellationToken);
}