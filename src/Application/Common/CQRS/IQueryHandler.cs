namespace CleanArchitecture.Application.Common.CQRS;
public interface IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}
