using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Core.Repositories;

namespace Twitter.Application.Queries.UsersQueries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();

            if (users == null)
            {
                throw new NullReferenceException("Não existem usuários cadastrados!");
            }

            var userViewModel = users
                .Select(u => new UserViewModel(u.Id, u.Name, u.Email, u.Age))
                .ToList();

            return userViewModel;
        }
    }
}
