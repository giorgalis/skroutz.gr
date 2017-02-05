using Newtonsoft.Json;
using skroutz.gr.Entities.User;
using System;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    ///  Provides methods for accessing User's notifications. Notifications are events (price changes of favorite products, subscribed discussion messages, etc).
    /// </summary>
    /// <remarks>To access any of the User Notification endpoints, an access_token containing the notifications permission is required.</remarks>
    public class UserNotifications : Request
    {
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotifications" /> class
        /// </summary>
        /// <param name="skroutzRequest">Instance of the SkroutzRequest class</param>
        public UserNotifications(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
        }

        /// <summary>
        /// List notifications
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/notifications/#list-notifications"/>
        public Task<UserNotifications> ListNotifications()
        {
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append("notifications");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<UserNotifications>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single notification
        /// </summary>
        /// <param name="notificationId"></param>
        /// <see href="https://developer.skroutz.gr/api/v3/notifications/#retrieve-a-single-notification"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="notificationId"/> is less than or equal to 0.</exception>
        public Task<Notification> RetrieveSingleNotification(int notificationId)
        {
            if (notificationId <= 0) throw new ArgumentOutOfRangeException(nameof(notificationId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"notifications/{notificationId}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Notification>(t.Result.ToString()));
        }

        /// <summary>
        /// Mark notifications as viewed
        /// <see href="https://developer.skroutz.gr/api/v3/notifications/#mark-notifications-as-viewed" />
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void MarkNotificationsAsViewed()
        {
            throw new NotImplementedException();
        }

    }
}
