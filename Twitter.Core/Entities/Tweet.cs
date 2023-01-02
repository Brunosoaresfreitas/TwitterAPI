namespace Twitter.Core.Entities
{
    public class Tweet : BaseEntity
    {
        public Tweet(int idUser, string description)
        {
            IdUser = idUser;
            Description = description;
            PostedAt = DateTime.Now;
            Likes = 0;
            Retweets = 0;
            TweetComments = 0;

            Comments = new List<Comment>();
        }

        public string Description { get; private set; }
        public DateTime PostedAt { get; private set; }
        public int Likes { get; private set; }
        public int Retweets { get; private set; }
        public int TweetComments { get; private set; }

        public int IdUser { get; private set; }
        public User User { get; private set; }
        public List<Comment> Comments { get; private set; }

        public void UpdateTweet(string description)
        {
            Description = description;
        }

        public void Like()
        {
            Likes += 1;
        }

        public void Retweet()
        {
            Retweets += 1;
        }

        public void TweetComment()
        {
            TweetComments += 1;
        }
    }
}
