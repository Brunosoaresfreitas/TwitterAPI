﻿using MediatR;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;

namespace Twitter.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly ITweetRepository _tweetRepository;
        public CreateCommentCommandHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var tweet = await _tweetRepository.GetByIdAsync(request.IdTweet);

            tweet.Comments.Add(new Comment(request.IdTweet, request.TweetComment));
            tweet.TweetComment();

            await _tweetRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
