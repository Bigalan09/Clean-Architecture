namespace CleanArchitecture.Application.Common.CQRS;
public interface IBaseCommand { }

public interface ICommand<out TResponse> : IBaseCommand { }
