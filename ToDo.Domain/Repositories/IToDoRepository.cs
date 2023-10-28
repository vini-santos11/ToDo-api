using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoItem> GetAll(string user);
        IEnumerable<ToDoItem> GetAllDone(string user);
        IEnumerable<ToDoItem> GetAllUndone(string user);
        IEnumerable<ToDoItem> GetByPeriod(string user, DateTime date, bool done);
        ToDoItem GetById(Guid id, string user);
        void Create(ToDoItem toDoItem);
        void Update(ToDoItem toDoItem);
    }
}