using MediatR;

namespace Twitter.Application.Commands.UpdateTweet
{
    public class UpdateTweetCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
  