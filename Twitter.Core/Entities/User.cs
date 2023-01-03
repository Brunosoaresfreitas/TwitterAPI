using Twitter.Core.Enums;

namespace Twitter.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password, DateTime birthDate)
        {
            Name = name;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Age = DateTime.Now.Year - birthDate.Year;

            Role = "User";

            CreatedAt = DateTime.Now;
            Status = StatusEnum.Active;
            
            UserTweets = new List<Tweet>();
            UserComments = new List<Comment>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int Age { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public StatusEnum Status { get; private set; }
        public List<Tweet> UserTweets { get; private set; }
        public List<Comment> UserComments { get; private set; }
        

        public void Update(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public void Disable()
        {
            if (Status == StatusEnum.Active)
            {
                Status = StatusEnum.Disabled;
            }
        }
    }
}
