using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Groups
    /// </summary>
    public class Groups
    {
        public List<Base.Group> groups { get; set; }
        public List<Base.GroupSpecification> specifications { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    public class Group
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }
    }

    /// <summary>
    /// GroupSpecification
    /// </summary>
    public class GroupSpecification
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Values
        /// </summary>
        [JsonProperty("values")]
        public List<object> Values { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// GroupId
        /// </summary>
        [JsonProperty("group_id")]
        public int GroupId { get; set; }
    }
}
