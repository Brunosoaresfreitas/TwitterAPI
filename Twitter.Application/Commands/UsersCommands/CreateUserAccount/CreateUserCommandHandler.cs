using MediatR;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;
using Twitter.Core.Services;

namespace Twitter.Application.Commands.UsersCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.Name, request.Email, passwordHash, request.BirthDate);

            await _userRepository.CreateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return user.Id;
        }
    }
}
