using Newtonsoft.Json;
using skroutz.gr.Entities.User;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides method for accessing User's profile.
    /// </summary>
    public class UserProfile : Request
    {
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile" /> class
        /// </summary>
        /// <param name="skroutzRequest">Instance of the SkroutzRequest class</param>
        public UserProfile(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
        }

        /// <summary>
        /// Retrieve the profile of the authenticated user
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/user/#retrieve-the-profile-of-the-authenticated-user"/>
        public Task<User> RetrieveProfileOfAuthenticatedUser()
        {
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append("user");

            _skroutzRequest.Method = HttpMethod.GET;

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<User>(t.Result.ToString()));
        }
    }
}
