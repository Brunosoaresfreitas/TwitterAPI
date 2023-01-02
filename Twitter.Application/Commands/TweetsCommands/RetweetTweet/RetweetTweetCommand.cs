using MediatR;

namespace Twitter.Application.Commands.RetweetTweet
{
    public class RetweetTweetCommand : IRequest<Unit>
    {
        public RetweetTweetCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
