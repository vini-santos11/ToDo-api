using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Commands;
using ToDo.Domain.Commands.ToDo;
using ToDo.Domain.Entities;
using ToDo.Domain.Handlers;
using ToDo.Domain.Repositories;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("v1/todos")]
public class ToDoController : ControllerBase
{

    [Route("")]
    [HttpGet]
    public IEnumerable<ToDoItem> GetAll([FromServices] IToDoRepository repository)
    {
        return repository.GetAll("marcusvinicius");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<ToDoItem> GetAllDone([FromServices] IToDoRepository repository)
    {
        return repository.GetAllDone("marcusvinicius");
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<ToDoItem> GetAllUnDone([FromServices] IToDoRepository repository)
    {
        return repository.GetAllUndone("marcusvinicius");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<ToDoItem> GetAllDoneToday([FromServices] IToDoRepository repository)
    {
        return repository.GetByPeriod("marcusvinicius", DateTime.Now.Date, true);
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<ToDoItem> GetAllUndoneToday([FromServices] IToDoRepository repository)
    {
        return repository.GetByPeriod("marcusvinicius", DateTime.Now.Date, false);
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<ToDoItem> GetAllDoneTomorrow([FromServices] IToDoRepository repository)
    {
        return repository.GetByPeriod("marcusvinicius", DateTime.Now.Date.AddDays(1), true);
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<ToDoItem> GetAllUndoneTomorrow([FromServices] IToDoRepository repository)
    {
        return repository.GetByPeriod("marcusvinicius", DateTime.Now.Date.AddDays(1), false);
    }

    [Route("{id}")]
    [HttpGet]
    public ToDoItem GetAllUnDone([FromRoute] Guid id, [FromServices] IToDoRepository repository)
    {
        return repository.GetById(id, "marcusvinicius");
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create([FromBody] CreateToDoCommand command, [FromServices] ToDoHandler handler)
    {
        command.User = "marcusvinicius";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update([FromBody] UpdateToDoCommand command, [FromServices] ToDoHandler handler)
    {
        command.User = "marcusvinicius";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone([FromBody] MarkToDoAsDoneCommand command, [FromServices] ToDoHandler handler)
    {
        command.User = "marcusvinicius";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone([FromBody] MarkToDoAsUndoneCommand command, [FromServices] ToDoHandler handler)
    {
        command.User = "marcusvinicius";
        return (GenericCommandResult)handler.Handle(command);
    }
}

