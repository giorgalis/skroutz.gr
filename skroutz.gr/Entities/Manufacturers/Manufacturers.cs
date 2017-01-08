using skroutz.gr.Entities.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities.Manufacturers
{

    /// <summary>
    /// Order by price, popularity or rating
    /// </summary>
    public enum OrderBy
    {
        /// <summary>
        /// Name
        /// </summary>
        name,
        /// <summary>
        /// Popularity
        /// </summary>
        popularity,
    }

    public class Manufacturer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
    }

    public class Manufacturers
    {
        public List<Manufacturer> manufacturers { get; set; }
        public Meta meta { get; set; }
    }
}
