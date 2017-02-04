﻿using Newtonsoft.Json;
using skroutz.gr.Exceptions;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Class Request.
    /// </summary>
    public class Request : RateLimit
    {
        
        internal Task<string> PostWebResultAsync(string path)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Path.Combine(SkroutzRequest.DomainEndPoint, path));
            req.Method = "POST";
            return GetResponse(req);
        }

        internal Task<string> GetWebResultAsync(SkroutzRequest skroutzRequest)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Path.Combine(skroutzRequest.ApiEndPoint, skroutzRequest.Path));
            req.Method = skroutzRequest.Method.ToString();
            req.Accept = $"application/vnd.skroutz+json; version={skroutzRequest.ApiVersion}";
            req.Headers["Authorization"] = $"{skroutzRequest.AuthResponse.TokenType} {skroutzRequest.AuthResponse.AccessToken}";

            return GetResponse(req);
        }

        internal async Task<string> GetResponse(HttpWebRequest req)
        {
            string content = string.Empty;
            HttpStatusCode code = HttpStatusCode.OK;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync())
                {
                    int result = 0;
                    if (int.TryParse(response.Headers["X-RateLimit-Limit"], out result)) base.Limit = result;
                    if (int.TryParse(response.Headers["X-RateLimit-Remaining"], out result)) base.Remaining = result;
                    if (int.TryParse(response.Headers["X-RateLimit-Reset"], out result)) base.Reset = result;

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

                    SkroutzError error = null;
                    if (!string.IsNullOrEmpty(content))
                        error = JsonConvert.DeserializeObject<SkroutzError>(content);

                    throw new SkroutzException(ex, code, content, error);
                }
            }

            return content;
        }
    }
}