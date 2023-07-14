using ToDo.Domain.Commands.Interfaces;

namespace ToDo.Domain.Handlers.Contracts;
public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}
