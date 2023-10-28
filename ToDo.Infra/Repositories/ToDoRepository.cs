using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Queries;
using ToDo.Domain.Repositories;
using ToDo.Infra.Contexts;

namespace ToDo.Infra.Repositories;

public class ToDoRepository : IToDoRepository
{
    private readonly DataContext _context;
    public ToDoRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(ToDoItem toDoItem)
    {
        _context.Todos.Add(toDoItem);
        _context.SaveChanges();
    }

    public IEnumerable<ToDoItem> GetAll(string user)
    {
        return _context.Todos.AsNoTracking().Where(ToDoQueries.GetAll(user)).OrderBy(x => x.Date);
    }

    public IEnumerable<ToDoItem> GetAllDone(string user)
    {
        return _context.Todos.AsNoTracking().Where(ToDoQueries.GetAllDone(user)).OrderBy(x => x.Date);
    }

    public IEnumerable<ToDoItem> GetAllUndone(string user)
    {
        return _context.Todos.AsNoTracking().Where(ToDoQueries.GetAllUndone(user)).OrderBy(x => x.Date);
    }

    public ToDoItem GetById(Guid id, string user)
    {
        return _context.Todos.FirstOrDefault(ToDoQueries.GetById(id, user));
    }

    public IEnumerable<ToDoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        return _context.Todos.AsNoTracking().Where(ToDoQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Date);
    }

    public void Update(ToDoItem toDoItem)
    {
        _context.Entry(toDoItem).State = EntityState.Modified;
        _context.SaveChanges();
    }
}