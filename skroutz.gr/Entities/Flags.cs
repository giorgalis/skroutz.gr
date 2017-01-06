using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    public class Flag
    {
        public string reason { get; set; }
        public string description { get; set; }
    }

    public class Flags
    {
        public List<Flag> flags { get; set; }
    }
}
