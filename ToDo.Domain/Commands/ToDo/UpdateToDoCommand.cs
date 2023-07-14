using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Interfaces;

namespace ToDo.Domain.Commands.ToDo
{
    public class UpdateToDoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateToDoCommand() { }

        public UpdateToDoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
            new Contract<UpdateToDoCommand>()
            .Requires()
            .IsGreaterThan(Title, 3, "Title", "Title should have at least 3 chars!")
            .IsGreaterThan(User, 6, "User", "User invalid!")
        );
        }
    }
}