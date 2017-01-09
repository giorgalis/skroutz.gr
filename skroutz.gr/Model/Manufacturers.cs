using skroutz.gr.Model.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Models
{
    public class RootManufacturer
    {
        public Base.Manufacturer manufacturer { get; set; }
    }

    public class Manufacturers
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

        public List<Base.Manufacturer> manufacturers { get; set; }
        public Meta meta { get; set; }
    }
}

namespace Base
{
    public class Manufacturer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
    }
}