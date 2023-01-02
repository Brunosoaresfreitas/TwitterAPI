using MediatR;

namespace Twitter.Application.Commands.UsersCommands.DisableUserAccount
{
    public class DisableUserCommand : IRequest<Unit>
    {
        public DisableUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
