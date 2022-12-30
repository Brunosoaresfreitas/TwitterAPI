using MediatR;

namespace Twitter.Application.Commands.CreateTweet
{
    public class CreateTweetCommand : IRequest<int>
    {
        public string Description { get; set; }
    }
}
