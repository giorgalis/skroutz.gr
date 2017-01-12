using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.Entities
{
    public class SKUReviewFlag
    {
        public int id { get; set; }
        public int flaggable_id { get; set; }
        public string flaggable_type { get; set; }
        public int user_id { get; set; }
        public string reason { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
