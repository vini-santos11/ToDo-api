using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Queries;

public static class ToDoQueries
{
    public static Expression<Func<ToDoItem, bool>> GetAll(string user)
    {
        return x => x.User == user;
    }

    public static Expression<Func<ToDoItem, bool>> GetAllUndone(string user)
    {
        return x => x.User == user && x.Done == false;
    }

    public static Expression<Func<ToDoItem, bool>> GetAllDone(string user)
    {
        return x => x.User == user && x.Done;
    }

    public static Expression<Func<ToDoItem, bool>> GetById(Guid id, string user)
    {
        return x => x.Id == id && x.User == user;
    }

    public static Expression<Func<ToDoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
    {
        return x =>
            x.User == user &&
            x.Done == done &&
            x.Date.Date == date.Date;
    }
}