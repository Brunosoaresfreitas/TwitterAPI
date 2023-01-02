using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Core.Entities;

namespace Twitter.Application.Queries.GetAllTweets
{
    public class GetAllTweetsQuery : IRequest<List<TweetViewModel>>
    {
    }
}
