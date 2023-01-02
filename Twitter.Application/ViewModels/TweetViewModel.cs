using Twitter.Core.Entities;

namespace Twitter.Application.ViewModels
{
    public class TweetViewModel
    {
        public TweetViewModel(int id, int idUser, string description, int likes, int retweets, int tweetComments)
        {
            Id = id;
            IdUser = idUser;
            Description = description;
            Likes = likes;
            Retweets = retweets;
            TweetComments = tweetComments;
            Comments = new List<Comment>();
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public string Description { get; private set; }
        public int Likes { get; private set; }
        public int Retweets { get; private set; }
        public int TweetComments { get; private set; }
        public List<Comment> Comments { get; private set; }
    }
}
