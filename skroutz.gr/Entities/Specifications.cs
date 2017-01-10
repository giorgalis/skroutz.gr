﻿using System.Collections.Generic;

namespace skroutz.gr.Model.Categories
{
    public class Specification
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<object> values { get; set; }
        public int order { get; set; }
        public string unit { get; set; }
    }

    public class Specifications
    {
        public List<Specification> specifications { get; set; }
    }
}