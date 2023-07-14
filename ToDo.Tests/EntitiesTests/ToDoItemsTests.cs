using ToDo.Domain.Entities;

namespace ToDo.Tests.EntitiesTests;

[TestClass]
public class ToDoItemsTests
{
    private readonly ToDoItem _todo = new ToDoItem("Título da tarefa", DateTime.Now, "Marcus Vinícius");
    [TestMethod]
    public void UndoneItem()
    {
        Assert.AreEqual(_todo.Done, false);
    }
}