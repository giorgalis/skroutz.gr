using System.Collections.Generic;

namespace skroutz.gr.Entities.Category
{
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
    }

    public class GroupSpecification 
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<object> values { get; set; }
        public int order { get; set; }
        public int group_id { get; set; }
    }

    public class Groups
    {
        public List<Group> groups { get; set; }
        public List<GroupSpecification> specifications { get; set; }
    }
}
