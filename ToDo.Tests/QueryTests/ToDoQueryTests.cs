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
        _items.Add(new ToDoItem("Tarefa 2", DateTime.Now.AddDays(2), "marcusvinicius"));
        _items.Add(new ToDoItem("Tarefa 3", DateTime.Now, "marcusvinicius"));
        _items.Add(new ToDoItem("Tarefa 4", DateTime.Now, "usuarioA"));
    }

    [TestMethod]
    public void ReturnToDosOnlyFromUser()
    {
        var result = _items.AsQueryable().Where(ToDoQueries.GetAll("marcusvinicius"));
        Assert.AreEqual(2, result.Count());
    }

    public void ReturnToDosFromToday()
    {
        var result = _items.AsQueryable().Where(ToDoQueries.GetByPeriod("marcusvinicius", DateTime.Now.Date, false));
        Assert.AreEqual(2, result.Count());
    }

    public void ReturnUndoneToDos()
    {
        var result = _items.AsQueryable().Where(ToDoQueries.GetAllUndone("marcusvinicius"));
        Assert.AreEqual(2, result.Count());
    }

    public void ReturnDoneToDos()
    {
        var result = _items.AsQueryable().Where(ToDoQueries.GetAllDone("marcusvinicius"));
        Assert.AreEqual(0, result.Count());
    }
}
