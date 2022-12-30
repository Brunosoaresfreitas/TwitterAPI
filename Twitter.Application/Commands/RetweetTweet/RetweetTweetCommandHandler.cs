using MediatR;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.RetweetTweet
{
    public class RetweetTweetCommandHandler : IRequestHandler<RetweetTweetCommand, Unit>
    {
        private readonly ITweetRepository _tweetRepository;

        public RetweetTweetCommandHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<Unit> Handle(RetweetTweetCommand request, CancellationToken cancellationToken)
        {
            var tweet = await _tweetRepository.GetByIdAsync(request.Id);

            tweet.Retweet();

            await _tweetRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
