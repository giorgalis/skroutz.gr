using skroutz.gr.Entities.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities.Category
{
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
