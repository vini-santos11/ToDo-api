using ToDo.Domain.Commands;
using ToDo.Domain.Commands.ToDo;
using ToDo.Domain.Handlers;
using ToDo.Tests.Repositories;

namespace ToDo.Tests.HandlerTests;

[TestClass]
public class UpdateToDoHandlerTests
{
    private readonly UpdateToDoCommand _invalidCommand = new UpdateToDoCommand(Guid.NewGuid(), "", "");
    private readonly UpdateToDoCommand _validCommand = new UpdateToDoCommand(Guid.NewGuid(), "Título da tarefa", "Marcus Vinícius");
    private readonly ToDoHandler _handler = new ToDoHandler(new FakeToDoRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    [TestMethod]
    public void InvalidUdateHandler()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(_result.Success, false);
    }

    [TestMethod]
    public void ValidUpdateHandler()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(_result.Success, true);
    }
}