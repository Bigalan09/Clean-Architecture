namespace CleanArchitecture.Application.Common.CQRS;

public interface ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}
