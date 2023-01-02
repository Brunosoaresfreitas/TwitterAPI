using MediatR;

namespace Twitter.Application.Commands.DeleteTweet
{
    public class DeleteTweetCommand : IRequest<Unit>
    {
        public DeleteTweetCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
