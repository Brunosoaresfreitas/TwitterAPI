using MediatR;
using Twitter.Core.Entities;

namespace Twitter.Application.Queries.UsersQueries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
