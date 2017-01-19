using skroutz.gr.Entities.Base;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class Search.
    /// </summary>
    /// <seealso cref="skroutz.gr.Entities.Base.Category" />
    public class Search : Base.Category
    {
        /// <summary>
        /// Gets or sets the match count.
        /// </summary>
        /// <value>The match count.</value>
        public int match_count { get; set; }

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
        public Search category { get; set; }
        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public Manufacturer manufacturer { get; set; }
        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        /// <value>The sku.</value>
        public SKU sku { get; set; }
        /// <summary>
        /// Gets or sets the shop.
        /// </summary>
        /// <value>The shop.</value>
        public RootShop shop { get; set; }
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
        public string token { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Drop"/> is dropped.
        /// </summary>
        /// <value><c>true</c> if dropped; otherwise, <c>false</c>.</value>
        public bool dropped { get; set; }
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
        public string term { get; set; }
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public int count { get; set; }
        /// <summary>
        /// Gets or sets the drop.
        /// </summary>
        /// <value>The drop.</value>
        public List<Drop> drop { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Alternative"/> is important.
        /// </summary>
        /// <value><c>true</c> if important; otherwise, <c>false</c>.</value>
        public bool important { get; set; }
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
        public List<Alternative> alternatives { get; set; }
        /// <summary>
        /// Gets or sets the strong matches.
        /// </summary>
        /// <value>The strong matches.</value>
        public StrongMatches strong_matches { get; set; }
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
        public List<Search> categories { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public SearchMeta meta { get; set; }
    }
}
