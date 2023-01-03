using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;

namespace Twitter.Application.Queries.UsersQueries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);

            if (user == null)
            {
                throw new NullReferenceException("O id do usuário informado não existe!");
            }

            var userViewModel = new UserViewModel(user.Id, user.Name, user.Email, user.Age);

            return userViewModel;
        }
    }
}
