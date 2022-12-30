using MediatR;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.LikeTweet
{
    public class LikeTweetCommandHandler : IRequestHandler<LikeTweetCommand, Unit>
    {
        private readonly ITweetRepository _tweetRepository;

        public LikeTweetCommandHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<Unit> Handle(LikeTweetCommand request, CancellationToken cancellationToken)
        {
            var tweet = await _tweetRepository.GetByIdAsync(request.Id);

            tweet.Like();
            await _tweetRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
