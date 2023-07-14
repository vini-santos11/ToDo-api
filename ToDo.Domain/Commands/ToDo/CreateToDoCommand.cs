using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Interfaces;

namespace ToDo.Domain.Commands.ToDo;

public class CreateToDoCommand : Notifiable<Notification>, ICommand
{
    public CreateToDoCommand() { }

    public CreateToDoCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }

    public string Title { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<CreateToDoCommand>()
            .Requires()
            .IsGreaterThan(Title, 3, "Title", "Title should have at least 3 chars!")
            .IsGreaterThan(User, 6, "User", "User invalid!")
        );
    }
}