﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class Flags.
    /// </summary>
    /// <seealso cref="Base.Flag"/>
    public class Flags
    {
        /// <summary>
        /// Flags
        /// </summary>
        public List<Base.Flag> flags { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class Flag.
    /// </summary>
    public class Flag
    {
        /// <summary>
        /// A codename for the flag. To be supplied as parameter upon flagging.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
        /// <summary>
        /// A human readable extended reason description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
