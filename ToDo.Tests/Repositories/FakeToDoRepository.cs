using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.Tests.Repositories;

public class FakeToDoRepository : IToDoRepository
{
    public void Create(ToDoItem toDoItem)
    { }

    public ToDoItem GetById(Guid id, string user)
    {
        return new ToDoItem("Título da tarefa", DateTime.Now, "Marcus Vinícius");
    }

    public void Update(ToDoItem toDoItem)
    { }
}