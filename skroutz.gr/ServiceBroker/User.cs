using Newtonsoft.Json;
using skroutz.gr.Authorization;
using skroutz.gr.Entities.User;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for accessing Users profile, favorites, notifications and other.
    /// </summary>
    public class User : Request
    {
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="skroutzRequest">The access token provided by the OAuth2.0 protocol</param>
        public User(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
            _skroutzRequest.SBuilder = new StringBuilder();
        }

        #region "User Profile"

        /// <summary>
        /// Retrieve the profile of the authenticated user
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/user/#retrieve-the-profile-of-the-authenticated-user"/>
        public Task<Entities.User.User> RetrieveProfileOfAuthenticatedUser()
        {
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append("user");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.User.User>(t.Result.ToString()));
        }

        #endregion

        #region "User Favorites"

        /// <summary>
        /// List favorite lists
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#list-favorite-lists"/>
        public Task<UserFavorites> ListFavoriteLists()
        {
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append("favorite_lists");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<UserFavorites>(t.Result.ToString()));
        }

        /// <summary>
        /// Create a favorite_list
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <see href="Https://developer.skroutz.gr/api/v3/favorites/#create-a-favoritelist" />
        public void CreateFavoriteList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Destroy a favorite_list
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#destroy-a-favoritelist" />
        public void DestroyFavoriteList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List favorites
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#list-favorites"/>
        public Task<Favorites> ListFavorites()
        {
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append("favorites");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Favorites>(t.Result.ToString()));
        }

        /// <summary>
        /// List favorites belonging to list
        /// </summary>
        /// <param name="listId">Unique identifier of the list</param>
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#list-favorites-belonging-to-list"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="listId"/> is less than or equal to 0.</exception>
        public Task<Favorites> ListFavoritesBelongingToList(int listId)
        {
            if (listId <= 0) throw new ArgumentOutOfRangeException(nameof(listId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"favorite_lists/{listId}/favorites");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Favorites>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single favorite
        /// </summary>
        /// <param name="favoriteId">Unique identifier of the Favorite</param>
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#retrieve-a-single-favorite"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="favoriteId"/> is less than or equal to 0.</exception>
        public Task<Favorite> RetrieveSingleFavorite(int favoriteId)
        {
            if (favoriteId <= 0) throw new ArgumentOutOfRangeException(nameof(favoriteId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"favorites/{favoriteId}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Favorite>(t.Result.ToString()));
        }

        /// <summary>
        /// Create a new favorite
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#create-a-new-favorite" />
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateNewFavorite()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Destroy a favorite
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#destroy-a-favorite" />
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void DestroyFavorite()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a favorite
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#update-a-favorite" />
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateFavorite()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "User Notification"

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

        #endregion

    }
}
