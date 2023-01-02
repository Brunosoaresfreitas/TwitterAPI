using MediatR;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.UsersCommands.UpdateUserAccount
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);

            user.Update(request.Name, request.Email, request.BirthDate);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
