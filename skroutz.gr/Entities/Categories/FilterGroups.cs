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
        public List<Base.FilterGroup> filter_groups { get; set; }
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

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("hint")]
        public string Hint { get; set; }

        [JsonProperty("combined")]
        public bool Combined { get; set; }

        [JsonProperty("filter_type")]
        public FilterTypes FilterType { get; set; }
    }
}
