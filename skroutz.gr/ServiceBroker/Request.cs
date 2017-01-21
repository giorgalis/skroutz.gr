using Newtonsoft.Json;
using skroutz.gr.Exceptions;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{

    /// <summary>
    /// Class Request.
    /// </summary>
    public class Request : RateLimiting
    {
        private const string Domain = "https://www.skroutz.gr/";
        private const string ApiEndPoint = "http://api.skroutz.gr/";

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        public Request()
        {
        
        }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>The API version.</value>
        public string ApiVersion { get; set; } = "3.0";
        internal async Task<string> PostWebResultAsync(string value)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Path.Combine(Domain, value));
            req.Method = "POST";
            return await GetResponse(req);
        }

        internal async Task<string> GetWebResultAsync(string value)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Path.Combine(ApiEndPoint, value));
            req.Method = "GET";
            req.Accept = $"application/vnd.skroutz+json; version={ApiVersion}";
            
            return await GetResponse(req);
        }

        internal async Task<string> GetResponse(HttpWebRequest req)
        {
            string content = string.Empty;
            HttpStatusCode code = HttpStatusCode.OK;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync())
                {
                    if (req.Method == "GET")
                    {
                        int result = 0;
                        if (int.TryParse(response.Headers["X-RateLimit-Limit"], out result)) Limit = result;
                        if (int.TryParse(response.Headers["X-RateLimit-Remaining"], out result)) Remaining = result;
                        if (int.TryParse(response.Headers["X-RateLimit-Reset"], out result)) Reset = result;
                    }

                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        content = await sr.ReadToEndAsync();

                    code = response.StatusCode;
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        content = sr.ReadToEnd();

                  
                    code = response.StatusCode;

                    Error error = null;
                    if(!string.IsNullOrEmpty(content))
                        error = JsonConvert.DeserializeObject<Error>(content);

                    throw new SkroutzException(ex, code, content, error);
                }
            }

            return content;
        }
    }
}