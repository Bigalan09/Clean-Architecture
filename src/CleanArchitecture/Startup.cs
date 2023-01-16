using CleanArchitecture.Application.Common.CQRS;
using CleanArchitecture.Application.TodoList.Command.CreateTodoList;

namespace CleanArchitecture.ConsoleApp;
internal class Startup
{
    private readonly ICommandDispatcher _commandDispatcher;

    public Startup(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    public async Task RunAsync(params string[] args)
    {
        Console.WriteLine("Hello World!");
        await _commandDispatcher.Dispatch(new CreateTodoListCommand() { Title = "My List" });
    }
}
