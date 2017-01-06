using skroutz.gr.Entities.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities.Shop
{
    public class Location
    {
        public int id { get; set; }
        public bool headquarter { get; set; }
        public List<string> phones { get; set; }
        public bool pickup_point { get; set; }
        public bool store { get; set; }
        public string full_address { get; set; }
        public string format { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string info { get; set; }
    }

    public class Locations
    {
        public List<Location> locations { get; set; }
        public Meta meta { get; set; }
    }

}
