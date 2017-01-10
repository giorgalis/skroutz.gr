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