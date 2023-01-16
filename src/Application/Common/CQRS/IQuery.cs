namespace CleanArchitecture.Application.Common.CQRS;
public interface IBaseQuery { }

public interface IQuery<out TResponse> : IBaseQuery { }