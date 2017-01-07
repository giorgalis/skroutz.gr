using System.Collections.Generic;

namespace skroutz.gr
{

    public class Error
    {
        public string code { get; set; }
        public List<string> messages { get; set; }
    }

    public class Errors
    {
        public List<Error> errors { get; set; }
    }

}
