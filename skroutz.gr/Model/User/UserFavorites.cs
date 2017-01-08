using skroutz.gr.Model.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Model.User
{
    public class FavoriteList
    {
        public int id { get; set; }
        public string name { get; set; }
        public object category_id { get; set; }
    }

    public class UserFavorites
    {
        public List<FavoriteList> favorite_lists { get; set; }
        public Meta meta { get; set; }
    }
}
