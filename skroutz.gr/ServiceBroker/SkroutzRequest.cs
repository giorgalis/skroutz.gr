namespace skroutz.gr.ServiceBroker
{
    public enum Method
    {
        GET,
        POST
    }

    public class SkroutzRequest
    {
        public const string Domain = "https://www.skroutz.gr/";
        public const string ApiEndPoint = "https://api.skroutz.gr/";
        public string ApiVersion { get; set; } = "3.0";

        public string AccessToken { get; set; }


        private string _tokenType;

        public string TokenType
        {
            get { return _tokenType; }
            set { _tokenType = ToTitleCase(value.ToLower()); }
        }

        public string Path { get; set; }

        public Method Method { get; set; } = Method.GET;

        public string Postdata { get; set; }

        string ToTitleCase(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string[] textArray = s.Split(' ');

            for (int i = 0; i < textArray.Length; i++)
            {
                switch (textArray[i].Length)
                {
                    case 1:
                        break;
                    default:
                        textArray[i] = char.ToUpper(textArray[i][0]) + textArray[i].Substring(1);
                        break;
                }
            }

            return string.Join(" ", textArray);
        }
    }

 
}
