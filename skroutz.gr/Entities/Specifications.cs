using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class Specifications.
    /// </summary>
    public class Specifications
    {
        /// <summary>
        /// Gets or sets the specifications.
        /// </summary>
        /// <value>The specifications.</value>
        public List<Base.Specification> specifications { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class Specification.
    /// </summary>
    public class Specification
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>The values.</value>
        [JsonProperty("values")]
        public List<object> Values { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
