using MediatR;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.UpdateTweet
{
    public class UpdateTweetCommandHandler : IRequestHandler<UpdateTweetCommand, Unit>
    {
        private readonly ITweetRepository _tweetRepository;

        public UpdateTweetCommandHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<Unit> Handle(UpdateTweetCommand request, CancellationToken cancellationToken)
        {
            var tweet = await _tweetRepository.GetByIdAsync(request.Id);

            tweet.UpdateTweet(request.Description);

            await _tweetRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
