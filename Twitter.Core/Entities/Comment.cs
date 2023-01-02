namespace Twitter.Core.Entities
{
    public class Comment : BaseEntity
    {
        public Comment(int idTweet, int userId, string tweetComment)
        {
            IdTweet = idTweet;
            UserId = userId;
            TweetComment = tweetComment;
            Likes = 0;
            Retweets = 0;
            TweetComments = 0;
            CommentedAt = DateTime.Now;
        }

        public int IdTweet { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public string TweetComment { get; private set; }
        public int Likes { get; private set; }
        public int Retweets { get; private set; }
        public int TweetComments { get; private set; }
        public DateTime CommentedAt { get; private set; }

    }
}
