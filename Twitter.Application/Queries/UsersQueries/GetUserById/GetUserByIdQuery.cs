using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Core.Entities;

namespace Twitter.Application.Queries.UsersQueries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
