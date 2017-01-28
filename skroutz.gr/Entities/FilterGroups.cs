using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class FilterGroups.
    /// </summary>
    /// <seealso cref="Base.FilterGroup"/>
    /// <seealso cref="Shared.Meta"/>
    public class FilterGroups
    {
        /// <summary>
        /// Filter Groups
        /// </summary>
        /// <value>The filter groups.</value>
        public List<Base.FilterGroup> filter_groups { get; set; }

        /// <summary>
        /// Meta
        /// </summary>
        /// <value>The meta.</value>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Enum FilterTypes
    /// </summary>
    public enum FilterTypes
    {
        /// <summary>
        /// The price
        /// </summary>
        Price = 0,
        /// <summary>
        /// The keyword
        /// </summary>
        Keyword,
        /// <summary>
        /// The spec
        /// </summary>
        Spec,
        /// <summary>
        /// The synced spec
        /// </summary>
        SyncedSpec,
        /// <summary>
        /// The custom range
        /// </summary>
        CustomRange,
        /// <summary>
        /// The sizes
        /// </summary>
        Sizes
    }

    /// <summary>
    /// Filter Group
    /// </summary>
    public class FilterGroup
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        /// <value>The category identifier.</value>
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// UpdatedAt
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Hint
        /// </summary>
        /// <value>The hint.</value>
        [JsonProperty("hint")]
        public string Hint { get; set; }

        /// <summary>
        /// Combined
        /// </summary>
        /// <value><c>true</c> if combined; otherwise, <c>false</c>.</value>
        [JsonProperty("combined")]
        public bool Combined { get; set; }

        /// <summary>
        /// FilterType
        /// </summary>
        /// <value>The type of the filter.</value>
        [JsonProperty("filter_type")]
        public FilterTypes FilterType { get; set; }
    }
}
