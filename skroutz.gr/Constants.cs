namespace skroutz.gr
{
    public class Constants
    {

        public static readonly string Domain = $"http://api.skroutz.gr/";
        public const string ApiVersion = "3.0";

        /// <summary>
        /// Order by asceding or desceding
        /// </summary>
        public enum OrderDir
        {
            /// <summary>
            /// Asceding
            /// </summary>
            asc,
            /// <summary>
            /// Descending
            /// </summary>
            desc
        }
    }
}
