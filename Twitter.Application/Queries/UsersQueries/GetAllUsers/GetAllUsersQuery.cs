using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Core.Entities;

namespace Twitter.Application.Queries.UsersQueries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
    }
}
