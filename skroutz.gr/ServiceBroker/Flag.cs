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
        /// <summary>
        /// The builder
        /// </summary>
        private readonly StringBuilder _builder;
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="skroutzRequest">The access token provided by the OAuth2.0 protocol</param>
        public Flag(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="skroutzRequest">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Flag(SkroutzRequest skroutzRequest, StringBuilder stringBuilder)
        {
            _skroutzRequest = skroutzRequest;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Retrieve all flags
        /// </summary>
        /// <returns>Task&lt;Flags&gt;.</returns>
        /// <see href="https://developer.skroutz.gr/api/v3/flag/#retrieve-all-flags" />
        public Task<Flags> RetrieveAllFlags()
        {
            _builder.Clear();
            _builder.Append($"flags");

            _skroutzRequest.Path = _builder.ToString();

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Flags>(t.Result.ToString()));
        }
    }
}
