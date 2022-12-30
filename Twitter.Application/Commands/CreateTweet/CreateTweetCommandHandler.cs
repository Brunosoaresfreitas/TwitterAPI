using MediatR;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.CreateTweet
{
    public class CreateTweetCommandHandler : IRequestHandler<CreateTweetCommand, int>
    {
        private readonly ITweetRepository _tweetRepository;

        public CreateTweetCommandHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<int> Handle(CreateTweetCommand request, CancellationToken cancellationToken)
        {
            var tweet = new Tweet(request.Description);

            await _tweetRepository.CreateTweetAsync(tweet);
            await _tweetRepository.SaveChangesAsync();

            return tweet.Id;
        }
    }
}
