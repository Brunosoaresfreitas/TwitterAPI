using MediatR;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.UsersCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Password, request.BirthDate);

            await _userRepository.CreateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return user.Id;
        }
    }
}
