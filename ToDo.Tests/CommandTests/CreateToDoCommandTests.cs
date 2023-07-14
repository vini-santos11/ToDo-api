using ToDo.Domain.Commands.ToDo;

namespace ToDo.Tests.CommandTests;

[TestClass]
public class CreateToDoCommandTests
{
    private readonly CreateToDoCommand _invalidCommand = new CreateToDoCommand("", "", DateTime.Now);
    private readonly CreateToDoCommand _validCommand = new CreateToDoCommand("Título da tarefa", "Marcus Vinícius", DateTime.Now);

    public CreateToDoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void InvalidCommand()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void ValidCommand()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}