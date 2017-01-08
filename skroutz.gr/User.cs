using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    public class User : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        public User(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        public User(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        #region "User Profile"

        /// <summary>
        /// Retrieve the profile of the authenticated user
        /// </summary>
        /// <see cref="https://developer.skroutz.gr/api/v3/user/#retrieve-the-profile-of-the-authenticated-user"/>
        public Task<Entities.User.User> RetrieveProfileOfAuthenticatedUser()
        {
            _builder.Clear();
            _builder.Append("user");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.User.User>(t.Result.ToString()));
        }

        #endregion

        #region "User Favorites"

        /// <summary>
        /// List favorite lists
        /// </summary>
        /// <see cref="https://developer.skroutz.gr/api/v3/favorites/#list-favorite-lists"/>
        public Task<Entities.User.UserFavorites> ListFavoriteLists()
        {
            _builder.Clear();
            _builder.Append("favorite_lists");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.User.UserFavorites>(t.Result.ToString()));
        }

        /// <summary>
        /// Create a favorite_list
        /// </summary>
        /// <see cref="Http://developer.skroutz.gr/api/v3/favorites/#create-a-favoritelist"/>
        public void CreateFavoriteList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Destroy a favorite_list
        /// </summary>
        /// <see cref="https://developer.skroutz.gr/api/v3/favorites/#destroy-a-favoritelist"/>
        public void DestroyFavoriteList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List favorites
        /// </summary>
        /// <see cref="https://developer.skroutz.gr/api/v3/favorites/#list-favorites"/>
        public Task<Entities.User.Favorites> ListFavorites()
        {
            _builder.Clear();
            _builder.Append("favorites");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.User.Favorites>(t.Result.ToString()));
        }

        /// <summary>
        /// List favorites belonging to list
        /// </summary>
        /// <param name="listId">Unique identifier of the list</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/favorites/#list-favorites-belonging-to-list"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when listId is less than or equal to 0</exception>
        public Task<Entities.User.Favorites> ListFavoritesBelongingToList(int listId)
        {
            if (listId <= 0) throw new ArgumentOutOfRangeException(nameof(listId));

            _builder.Clear();
            _builder.Append($"favorite_lists/{listId}/favorites");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.User.Favorites>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single favorite
        /// </summary>
        /// <param name="favoriteId">Unique identifier of the Favorite</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/favorites/#retrieve-a-single-favorite"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when favoriteId is less than or equal to 0</exception>
        public Task<Entities.User.Favorite> RetrieveSingleFavorite(int favoriteId)
        {
            if (favoriteId <= 0) throw new ArgumentOutOfRangeException(nameof(favoriteId));

            _builder.Clear();
            _builder.Append($"favorites/{favoriteId}");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.User.Favorite>(t.Result.ToString()));
        }

        /// <summary>
        /// Create a new favorite
        /// <see cref="https://developer.skroutz.gr/api/v3/favorites/#create-a-new-favorite"/>
        /// </summary>
        public void CreateNewFavorite()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Destroy a favorite
        /// <see cref="https://developer.skroutz.gr/api/v3/favorites/#destroy-a-favorite"/>
        /// </summary>
        public void DestroyFavorite()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a favorite
        /// <see cref="https://developer.skroutz.gr/api/v3/favorites/#update-a-favorite"/>
        /// </summary>
        public void UpdateFavorite()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "User Notification"

        /// <summary>
        /// List notifications
        /// </summary>
        /// <see cref="https://developer.skroutz.gr/api/v3/notifications/#list-notifications"/>
        public Task<Entities.User.UserNotifications> ListNotifications()
        {
            _builder.Clear();
            _builder.Append("notifications");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.User.UserNotifications>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single notification
        /// </summary>
        /// <param name="notificationId"></param>
        /// <see cref="https://developer.skroutz.gr/api/v3/notifications/#retrieve-a-single-notification"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when notificationId is less than or equal to 0</exception>
        public Task<Entities.User.Notification> RetrieveSingleNotification(int notificationId)
        {
            if (notificationId <= 0) throw new ArgumentOutOfRangeException(nameof(notificationId));

            _builder.Clear();
            _builder.Append($"notifications/{notificationId}");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.User.Notification>(t.Result.ToString()));
        }

        /// <summary>
        /// Mark notifications as viewed
        /// <see cref="https://developer.skroutz.gr/api/v3/notifications/#mark-notifications-as-viewed"/>
        /// </summary>
        public void MarkNotificationsAsViewed()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
