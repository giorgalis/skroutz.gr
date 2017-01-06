﻿using skroutz.gr.Entities.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    public class FavoriteList
    {
        public int id { get; set; }
        public string name { get; set; }
        public object category_id { get; set; }
    }

    public class FavoriteLists
    {
        public List<FavoriteList> favorite_lists { get; set; }
        public Meta meta { get; set; }
    }
}
