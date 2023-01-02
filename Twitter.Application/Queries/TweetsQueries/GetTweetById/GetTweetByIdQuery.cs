using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Core.Entities;

namespace Twitter.Application.Queries.GetTweetById
{
    public class GetTweetByIdQuery : IRequest<Tweet>
    {
        public GetTweetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
