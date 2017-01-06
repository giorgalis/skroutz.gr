namespace skroutz.gr.Entities.User
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public sex sex { get; set; }
        public string avatar { get; set; }
        public type type { get; set; }
    }

    public enum sex
    {
        male,
        female,
        @null
    }

    public enum type
    {
        skroutz,
        open_id,
        twitter,
        facebook,
        google
    }

    public class UserProfile
    {
        public User user { get; set; }
    }
}
