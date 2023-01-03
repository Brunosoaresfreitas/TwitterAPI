using MediatR;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.DeleteTweet
{
    public class DeleteTweetCommandHandler : IRequestHandler<DeleteTweetCommand, Unit>
    {
        private readonly ITweetRepository _tweetRepository;

        public DeleteTweetCommandHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<Unit> Handle(DeleteTweetCommand request, CancellationToken cancellationToken)
        {
            var tweet = await _tweetRepository.GetByIdAsync(request.Id);

            if (tweet == null)
            {
                throw new NullReferenceException("O id do tweet informado não existe!");
            }

            await _tweetRepository.DeleteTweetAsync(tweet);
            await _tweetRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
