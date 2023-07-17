using ToDo.Domain.Entities;
using ToDo.Domain.Queries;

namespace ToDo.Tests.QueryTests;

[TestClass]
public class ToDoQueryTests
{
    private List<ToDoItem> _items;

    public ToDoQueryTests()
    {
        _items = new List<ToDoItem>();
        _items.Add(new ToDoItem("Tarefa 1", DateTime.Now, "usuarioA"));
        _items.Add(new ToDoItem("Tarefa 2", DateTime.Now, "marcusvinicius"));
        _items.Add(new ToDoItem("Tarefa 3", DateTime.Now, "marcusvinicius"));
        _items.Add(new ToDoItem("Tarefa 4", DateTime.Now, "usuarioA"));
    }

    [TestMethod]
    public void ReturnToDosOnlyFromUser()
    {
        var result = _items.AsQueryable().Where(ToDoQueries.GetAll("marcusvinicius"));
        Assert.AreEqual(2, result.Count());
    }
}