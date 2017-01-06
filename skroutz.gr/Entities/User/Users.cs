namespace skroutz.gr.Entities.User
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string sex { get; set; }
        public string avatar { get; set; }
        public string type { get; set; }
    }

    public class UserProfile
    {
        public User user { get; set; }
    }
}
