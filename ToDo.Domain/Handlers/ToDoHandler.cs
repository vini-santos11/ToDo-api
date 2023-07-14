using Flunt.Notifications;
using ToDo.Domain.Commands;
using ToDo.Domain.Commands.Interfaces;
using ToDo.Domain.Commands.ToDo;
using ToDo.Domain.Entities;
using ToDo.Domain.Handlers.Contracts;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Handlers;

public class ToDoHandler :
    Notifiable<Notification>,
    IHandler<CreateToDoCommand>,
    IHandler<UpdateToDoCommand>,
    IHandler<MarkToDoAsDoneCommand>,
    IHandler<MarkToDoAsUndoneCommand>
{
    private readonly IToDoRepository _repository;
    public ToDoHandler(IToDoRepository repository)
    {
        _repository = repository;
    }
    public ICommandResult Handle(CreateToDoCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        // Gera o ToDoItem
        var toDoItem = new ToDoItem(command.Title, command.Date, command.User);

        // Salva no banco
        _repository.Create(toDoItem);

        // Retorna o Resultado
        return new GenericCommandResult(true, "Tarefa salva!", toDoItem);
    }

    public ICommandResult Handle(UpdateToDoCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        // REcupear a tarefa (ToDoItem)
        var todo = _repository.GetById(command.Id, command.User);

        // Altera o título
        todo.UpdateTitle(command.Title);

        // Salva no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva!", todo);
    }

    public ICommandResult Handle(MarkToDoAsDoneCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        // REcupear a tarefa (ToDoItem)
        var todo = _repository.GetById(command.Id, command.User);

        // Marca como feito
        todo.MarkAsDone();

        // Salva no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva!", todo);
    }

    public ICommandResult Handle(MarkToDoAsUndoneCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        // REcupear a tarefa (ToDoItem)
        var todo = _repository.GetById(command.Id, command.User);

        // Marca como não feito
        todo.MarkAsUndone();

        // Salva no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva!", todo);
    }
}