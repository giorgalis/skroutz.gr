using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Filter Groups
    /// </summary>
    public class FilterGroups
    {
        /// <summary>
        /// Filter Groups
        /// </summary>
        public List<Base.FilterGroup> filter_groups { get; set; }

        /// <summary>
        /// Meta
        /// </summary>
        public Meta meta { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Filter Group
    /// </summary>
    public class FilterGroup
    {
        public enum FilterTypes
        {
            Price = 0,
            Keyword,
            Spec,
            SyncedSpec,
            CustomRange,
            Sizes
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// UpdatedAt
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Hint
        /// </summary>
        [JsonProperty("hint")]
        public string Hint { get; set; }

        /// <summary>
        /// Combined
        /// </summary>
        [JsonProperty("combined")]
        public bool Combined { get; set; }

        /// <summary>
        /// FilterType
        /// </summary>
        [JsonProperty("filter_type")]
        public FilterTypes FilterType { get; set; }
    }
}
