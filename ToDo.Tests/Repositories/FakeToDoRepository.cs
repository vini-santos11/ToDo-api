using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.Tests.Repositories;

public class FakeToDoRepository : IToDoRepository
{
    public void Create(ToDoItem toDoItem)
    { }

    public IEnumerable<ToDoItem> GetAll(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ToDoItem> GetAllDone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ToDoItem> GetAllUndone(string user)
    {
        throw new NotImplementedException();
    }

    public ToDoItem GetById(Guid id, string user)
    {
        return new ToDoItem("Título da tarefa", DateTime.Now, "Marcus Vinícius");
    }

    public IEnumerable<ToDoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        throw new NotImplementedException();
    }

    public void Update(ToDoItem toDoItem)
    { }
}