using Newtonsoft.Json;
using skroutz.gr.Entities.Base;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// <para>The main response type is a collection of Categories.</para>
    /// <para>There may be alternate suggestion queries provided in the <c>alternatives</c> key of the meta object.</para>
    /// <para>Any of those alternatives with the flag important set to true, are a hint for the client to perform a search with the alternative query instead.</para>
    /// <para>There may also exist matches of different resources under the key <c>strong_matches</c>.</para>
    /// <para>Currently there may be up-to one of each of the following resources in <see cref="StrongMatches"/>:
    /// <list type="bullet">
    /// <item>
    /// <description><see cref="Category"/></description>
    /// </item>
    /// <item>
    /// <description><see cref="SKU"/></description>
    /// </item>
    /// <item>
    /// <description><see cref="Manufacturer"/></description>
    /// </item>
    /// <item>
    /// <description><see cref="RootShop"/></description>
    /// </item>
    /// </list></para>
    /// </summary>
    /// <seealso cref="Category" />
    public class Search : Category
    {
        /// <summary>
        /// Gets or sets the match count.
        /// </summary>
        /// <value>The match count.</value>
        [JsonProperty("match_count")]
        public int MatchCount { get; set; }

    }

    /// <summary>
    /// Class StrongMatches.
    /// </summary>
    public class StrongMatches
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        [JsonProperty("category")]
        public Search Category { get; set; }
        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        [JsonProperty("manufacturer")]
        public Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        /// <value>The sku.</value>
        [JsonProperty("sku")]
        public SKU Sku { get; set; }
        /// <summary>
        /// Gets or sets the shop.
        /// </summary>
        /// <value>The shop.</value>
        [JsonProperty("shop")]
        public RootShop Shop { get; set; }
    }

    /// <summary>
    /// Class Drop.
    /// </summary>
    public class Drop
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonProperty("token")]
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Drop"/> is dropped.
        /// </summary>
        /// <value><c>true</c> if dropped; otherwise, <c>false</c>.</value>
        [JsonProperty("dropped")]
        public bool Dropped { get; set; }
    }

    /// <summary>
    /// Class Alternative.
    /// </summary>
    public class Alternative
    {
        /// <summary>
        /// Gets or sets the term.
        /// </summary>
        /// <value>The term.</value>
        [JsonProperty("term")]
        public string Term { get; set; }
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        [JsonProperty("count")]
        public int Count { get; set; }
        /// <summary>
        /// Gets or sets the drop.
        /// </summary>
        /// <value>The drop.</value>
        [JsonProperty("drop")]
        public List<Drop> Drop { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Alternative"/> is important.
        /// </summary>
        /// <value><c>true</c> if important; otherwise, <c>false</c>.</value>
        [JsonProperty("important")]
        public bool Important { get; set; }
    }

    /// <summary>
    /// Class SearchMeta.
    /// </summary>
    /// <seealso cref="skroutz.gr.Shared.Meta" />
    public class SearchMeta : Meta
    {
        /// <summary>
        /// Gets or sets the q.
        /// </summary>
        /// <value>The q.</value>
        public string q { get; set; }
        /// <summary>
        /// Gets or sets the alternatives.
        /// </summary>
        /// <value>The alternatives.</value>
        [JsonProperty("alternatives")]
        public List<Alternative> Alternatives { get; set; }
        /// <summary>
        /// Gets or sets the strong matches.
        /// </summary>
        /// <value>The strong matches.</value>
        [JsonProperty("strong_matches")]
        public StrongMatches StrongMatches { get; set; }
    }

    /// <summary>
    /// Class RootSearch.
    /// </summary>
    public class RootSearch
    {
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public List<Search> Categories { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        [JsonProperty("meta")]
        public SearchMeta Meta { get; set; }
    }
}
