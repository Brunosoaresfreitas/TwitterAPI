using MediatR;

namespace Twitter.Application.Commands.CreateTweet
{
    public class CreateTweetCommand : IRequest<int>
    {
        public int IdUser { get; set; }
        public string Description { get; set; }
    }
}
