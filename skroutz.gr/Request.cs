using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace skroutz.gr
{

    /// <summary>
    /// Class Request.
    /// </summary>
    public class Request
    {
        private const string Domain = "https://www.skroutz.gr/";
        private const string ApiEndPoint = "http://api.skroutz.gr/";
        private const string ApiVersion = "3.0";

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
                    throw new SkroutzException(code, content);
                }
            }

            return content;
        }
    }
}