using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Interfaces;

namespace ToDo.Domain.Commands.ToDo;

public class MarkToDoAsUndoneCommand : Notifiable<Notification>, ICommand
{
    public MarkToDoAsUndoneCommand() { }

    public MarkToDoAsUndoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<MarkToDoAsUndoneCommand>()
            .Requires()
            .IsGreaterThan(User, 6, "User", "User invalid!")
        );
    }
}