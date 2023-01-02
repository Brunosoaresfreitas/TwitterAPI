namespace Twitter.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string name, string email, int age)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
    }
}
