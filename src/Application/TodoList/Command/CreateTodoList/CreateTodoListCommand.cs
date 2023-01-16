using CleanArchitecture.Application.Common.CQRS;

namespace CleanArchitecture.Application.TodoList.Command.CreateTodoList;
public class CreateTodoListCommand : ICommand<int>
{
    public string? Title { get; set; }
}
