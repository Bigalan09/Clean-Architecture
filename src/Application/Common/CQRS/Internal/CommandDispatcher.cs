using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Common.CQRS.Internal;

internal class CommandDispatcher<TCommand, TResponse> : ICommandDispatcher<TResponse> where TCommand : ICommand<TResponse>
{
    public Task<TResponse> Handle(
        ICommand<TResponse> command,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken)
    {
        return serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResponse>>().Handle((TCommand)command, cancellationToken);
    }
}

internal class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> Dispatch<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var commandType = command.GetType();

        var handler = (ICommandDispatcher<TResponse>)(Activator.CreateInstance(typeof(CommandDispatcher<,>).MakeGenericType(commandType, typeof(TResponse)))
                                             ?? throw new InvalidOperationException($"Could not create a CommandDispatcher type for {commandType}"));

        return handler.Handle(command, _serviceProvider, cancellationToken);
    }
}
