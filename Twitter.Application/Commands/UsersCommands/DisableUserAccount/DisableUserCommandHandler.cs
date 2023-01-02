using MediatR;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.UsersCommands.DisableUserAccount
{
    public class DisableUserCommandHandler : IRequestHandler<DisableUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DisableUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DisableUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);

            user.Disable();

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
