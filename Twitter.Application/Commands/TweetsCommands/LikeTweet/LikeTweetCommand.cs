using MediatR;

namespace Twitter.Application.Commands.LikeTweet
{
    public class LikeTweetCommand : IRequest<Unit>
    {
        public LikeTweetCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
