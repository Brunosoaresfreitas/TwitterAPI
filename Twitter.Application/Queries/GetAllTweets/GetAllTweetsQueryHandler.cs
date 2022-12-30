using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Core.Repositories;

namespace Twitter.Application.Queries.GetAllTweets
{
    public class GetAllTweetsQueryHandler : IRequestHandler<GetAllTweetsQuery, List<TweetViewModel>>
    {
        private readonly ITweetRepository _tweetRepository;

        public GetAllTweetsQueryHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<List<TweetViewModel>> Handle(GetAllTweetsQuery request, CancellationToken cancellationToken)
        {
            var tweets = await _tweetRepository.GetAllAsync();

            var tweetsViewModel = tweets
                .Select(t => new TweetViewModel(t.Id, t.Description, t.Likes, t.Retweets, t.TweetComments))
                .ToList();

            return tweetsViewModel;
        }
    }
}
