using Newtonsoft.Json;
using skroutz.gr.Entities;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides a method for retrieving available flags.
    /// </summary>
    /// <remarks>A Flag is used to mark user provided content as requiring attention/moderation.</remarks>
    public class Flag : Request
    {
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="skroutzRequest">The access token provided by the OAuth2.0 protocol</param>
        public Flag(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
            _skroutzRequest.SBuilder = new StringBuilder();
        }

        /// <summary>
        /// Retrieve all flags
        /// </summary>
        /// <returns>Task&lt;Flags&gt;.</returns>
        /// <see href="https://developer.skroutz.gr/api/v3/flag/#retrieve-all-flags" />
        public Task<Flags> RetrieveAllFlags()
        {
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"flags");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Flags>(t.Result.ToString()));
        }
    }
}
