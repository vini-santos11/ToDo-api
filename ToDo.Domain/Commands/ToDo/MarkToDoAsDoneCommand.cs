using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Interfaces;

namespace ToDo.Domain.Commands.ToDo;

public class MarkToDoAsDoneCommand : Notifiable<Notification>, ICommand
{
    public MarkToDoAsDoneCommand() { }

    public MarkToDoAsDoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<MarkToDoAsDoneCommand>()
            .Requires()
            .IsGreaterThan(User, 6, "User", "User invalid!")
        );
    }
}