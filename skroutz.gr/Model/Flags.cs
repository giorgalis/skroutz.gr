using System.Collections.Generic;

namespace skroutz.gr.Models
{
    public class Flags
    {
        public List<Base.Flag> flags { get; set; }
    }
}

namespace Base
{
    public class Flag
    {
        public string reason { get; set; }
        public string description { get; set; }
    }
}
