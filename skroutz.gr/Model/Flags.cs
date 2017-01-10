﻿using System.Collections.Generic;

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
        /// <summary>
        /// A codename for the flag. To be supplied as parameter upon flagging.
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// A human readable extended reason description.
        /// </summary>
        public string description { get; set; }
    }
}
