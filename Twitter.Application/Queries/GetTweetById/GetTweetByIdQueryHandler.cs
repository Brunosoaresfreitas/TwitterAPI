using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;

namespace Twitter.Application.Queries.GetTweetById
{
    public class GetTweetByIdQueryHandler : IRequestHandler<GetTweetByIdQuery, Tweet>
    {
        private readonly ITweetRepository _tweetRepository;

        public GetTweetByIdQueryHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<Tweet> Handle(GetTweetByIdQuery request, CancellationToken cancellationToken)
        {
            var tweet = await _tweetRepository.GetByIdAsync(request.Id);

            return tweet;
        }
    }
}
