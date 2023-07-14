using ToDo.Domain.Commands;
using ToDo.Domain.Commands.ToDo;
using ToDo.Domain.Handlers;
using ToDo.Tests.Repositories;

namespace ToDo.Tests.HandlerTests;

[TestClass]
public class CreateToDoHandlerTests
{
    private readonly CreateToDoCommand _invalidCommand = new CreateToDoCommand("", "", DateTime.Now);
    private readonly CreateToDoCommand _validCommand = new CreateToDoCommand("Título da tarefa", "Marcus Vinícius", DateTime.Now);
    private readonly ToDoHandler _handler = new ToDoHandler(new FakeToDoRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    [TestMethod]
    public void InvalidCreateHandler()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(_result.Success, false);
    }

    [TestMethod]
    public void ValidCreateHandler()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(_result.Success, true);
    }
}