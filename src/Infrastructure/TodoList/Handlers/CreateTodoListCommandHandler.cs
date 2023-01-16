using CleanArchitecture.Application.Common.CQRS;
using CleanArchitecture.Application.TodoList.Command.CreateTodoList;

namespace CleanArchitecture.Infrastructure.TodoList.Handlers;
internal class CreateTodoListCommandHandler : ICommandHandler<CreateTodoListCommand, int>
{
    public CreateTodoListCommandHandler() { }

    public Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Creating list: {request.Title ?? "Untitled"}");

        return Task.FromResult(0);
    }
}
