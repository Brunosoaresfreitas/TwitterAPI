using MediatR;

namespace Twitter.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public CreateCommentCommand(int idTweet)
        {
            IdTweet = idTweet;
        }

        public int IdTweet { get; private set; }
        public string TweetComment { get;  set; }
    }
}
