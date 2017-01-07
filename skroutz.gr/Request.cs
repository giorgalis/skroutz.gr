using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace skroutz.gr
{
    public class Request
    {
        private const string ApiVersion = "3.0";
        private static readonly string Domain = $"http://api.skroutz.gr/";
        public async Task<string> GetWebResultAsync(string value)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Domain + value);
            req.Method = "GET";
            req.Accept = $"application/vnd.skroutz+json; version={ApiVersion}";

            string content = null;
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

            //Here you have now content and code.

            return content;
        }
    }
}