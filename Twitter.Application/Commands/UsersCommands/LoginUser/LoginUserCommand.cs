using MediatR;
using Twitter.Application.ViewModels;

namespace Twitter.Application.Commands.UsersCommands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
