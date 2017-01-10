using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Model.User
{
    public class Favorite
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("have_it")]
        public bool HaveIt { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("user_notes")]
        public object UserNotes { get; set; }

        [JsonProperty("sku_id")]
        public int SkuId { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("get_absolute_threshold")]
        public string GetAbsoluteThreshold { get; set; }
    }

    public class Favorites
    {
        public List<Favorite> favorites { get; set; }
        public Meta meta { get; set; }
    }
}
