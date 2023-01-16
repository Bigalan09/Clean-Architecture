namespace CleanArchitecture.Application.Common.CQRS;

public interface ICommandDispatcher
{
    /// <summary>
    /// Asynchronously send a command to a handler.
    /// </summary>
    /// <typeparam name="TResponse">The response type<./typeparam>
    /// <param name="command">The command object.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>A task that represents the dispatch operation. The task result contains the handler response.</returns>
    Task<TResponse> Dispatch<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
}

internal interface ICommandDispatcher<TResponse>
{
    Task<TResponse> Handle(ICommand<TResponse> command, IServiceProvider serviceProvider, CancellationToken cancellationToken);
}