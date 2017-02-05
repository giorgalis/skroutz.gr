using Newtonsoft.Json;
using skroutz.gr.Entities.User;
using System;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for accessing, editing and deleting Users favorites.
    /// </summary>
    public class UserFavorites : Request
    {
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserFavorites" /> class
        /// </summary>
        /// <param name="skroutzRequest">Instance of the SkroutzRequest class</param>
        public UserFavorites(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
        }

        /// <summary>
        /// List favorite lists
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#list-favorite-lists"/>
        public Task<UserFavorites> ListFavoriteLists()
        {
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append("favorite_lists");

            _skroutzRequest.Method = HttpMethod.GET;

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<UserFavorites>(t.Result.ToString()));
        }

        /// <summary>
        /// Create a favorite_list
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="favoriteListName" /> is null or empty.</exception>
        /// <see href="Https://developer.skroutz.gr/api/v3/favorites/#create-a-favoritelist" />
        public Task<UserFavorites> CreateFavoriteList(string favoriteListName)
        {
            if (string.IsNullOrEmpty(favoriteListName)) throw new ArgumentNullException(nameof(favoriteListName));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"favorite_lists?favorite_list[name]={favoriteListName}");

            _skroutzRequest.Method = HttpMethod.POST;

            return PostWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                   JsonConvert.DeserializeObject<UserFavorites>(t.Result.ToString()));
        }

        /// <summary>
        /// Destroy a favorite_list
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="favoriteListId"/> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#destroy-a-favoritelist" />
        public void DestroyFavoriteList(int favoriteListId)
        {
            if (favoriteListId <= 0) throw new ArgumentOutOfRangeException(nameof(favoriteListId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"favorite_lists/{favoriteListId}");

            _skroutzRequest.Method = HttpMethod.DELETE;

            PostWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                   JsonConvert.DeserializeObject<UserFavorites>(t.Result.ToString()));
        }

        /// <summary>
        /// List favorites
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#list-favorites"/>
        public Task<Favorites> ListFavorites()
        {
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append("favorites");

            _skroutzRequest.Method = HttpMethod.GET;

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

            _skroutzRequest.Method = HttpMethod.GET;

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

            _skroutzRequest.Method = HttpMethod.GET;

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Favorite>(t.Result.ToString()));
        }

        /// <summary>
        /// Create a new favorite
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#create-a-new-favorite" />
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuID"/> is less than or equal to 0.</exception>
        public Task<Favorite> CreateNewFavorite(int skuID)
        {
            if (skuID <= 0) throw new ArgumentOutOfRangeException(nameof(skuID));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"favorites?favorite[sku_id]={skuID}");

            _skroutzRequest.Method = HttpMethod.POST;

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Favorite>(t.Result.ToString()));
        }

        /// <summary>
        /// Destroy a favorite
        /// <see href="https://developer.skroutz.gr/api/v3/favorites/#destroy-a-favorite" />
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="favoriteId"/> is less than or equal to 0.</exception>
        /// <remarks>The response status is 204 and with an empty response body when resource is destroyed. Status code is 404 when the resource does not exist.</remarks>
        public void DestroyFavorite(int favoriteId)
        {
            if (favoriteId <= 0) throw new ArgumentOutOfRangeException(nameof(favoriteId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"favorites/{favoriteId}");

            _skroutzRequest.Method = HttpMethod.DELETE;

            PostWebResultAsync(_skroutzRequest);
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
    }
}
