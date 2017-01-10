using skroutz.gr.Model.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Models
{
    public class FilterGroups
    {
        public List<Base.FilterGroup> filter_groups { get; set; }
        public Meta meta { get; set; }
    }
}

namespace Base
{
    public enum FilterTypes
    {
        Price = 0,
        Keyword,
        Spec,
        SyncedSpec,
        CustomRange,
        Sizes
    }
    public class FilterGroup
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public int category_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string hint { get; set; }
        public bool combined { get; set; }
        public FilterTypes filter_type { get; set; }
    }
}
