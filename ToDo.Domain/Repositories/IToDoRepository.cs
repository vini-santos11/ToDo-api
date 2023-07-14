using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface IToDoRepository
    {
        ToDoItem GetById(Guid id, string user);
        void Create(ToDoItem toDoItem);
        void Update(ToDoItem toDoItem);
    }
}