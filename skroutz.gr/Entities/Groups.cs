using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class Groups.
    /// </summary>
    /// <seealso cref="Base.Group"/>
    /// <seealso cref="Base.GroupSpecification"/>
    public class Groups
    {
        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>The groups.</value>
        public List<Base.Group> groups { get; set; }
        /// <summary>
        /// Gets or sets the specifications.
        /// </summary>
        /// <value>The specifications.</value>
        [JsonProperty("specifications")]
        public List<Base.GroupSpecification> Specifications { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class Group.
    /// </summary>
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
