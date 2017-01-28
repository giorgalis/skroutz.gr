using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class PriceHistory.
    /// </summary>
    /// <seealso cref="Base.History"/>
    public class PriceHistory
    {
        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>The history.</value>
        [JsonProperty("history")]
        public Base.History History { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class Average.
    /// </summary>
    public class Average
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        [JsonProperty("date")]
        public string Date { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]
        public double Price { get; set; }
    }

    /// <summary>
    /// Class Lowest.
    /// </summary>
    public class Lowest
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the name of the shop.
        /// </summary>
        /// <value>The name of the shop.</value>
        [JsonProperty("shop_name")]
        public string ShopName { get; set; }
    }

    /// <summary>
    /// Class History.
    /// </summary>
    public class History
    {
        /// <summary>
        /// Gets or sets the average.
        /// </summary>
        /// <value>The average.</value>
        [JsonProperty("average")]
        public List<Average> Average { get; set; }

        /// <summary>
        /// Gets or sets the lowest.
        /// </summary>
        /// <value>The lowest.</value>
        [JsonProperty("lowest")]
        public List<Lowest> Lowest { get; set; }
    }
}
