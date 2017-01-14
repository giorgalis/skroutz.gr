using Newtonsoft.Json;
using skroutz.gr.Model.User;
using skroutz.gr.Entities;
using skroutz.gr.Shared;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    /// <summary>
    /// Categories are organized in a tree-like structure.
    /// An SKU always belongs to a leaf (ending) category.
    /// Leaf categories have <see cref="Entities.Base.Category.ChildrenCount"/> equal to 0.
    /// </summary>
    public class Category : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the Category class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Category(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the Category class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Category(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Lists all categories
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-all-categories"/>
        public Task<Categories> ListAllCategories()
        {
            _builder.Clear();
            _builder.Append("categories?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Categories>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#retrieve-a-single-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to 0</exception>
        public Task<RootCategory> RetrieveSingleCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootCategory>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve the parent of a category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#retrieve-a-single-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to 0</exception>
        public Task<RootCategory> RetrieveTheParentOfCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/parent?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootCategory>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve the root category
        /// </summary>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#retrieve-the-root-category"/>
        public Task<RootCategory> RetrieveTheRootCategory()
        {
            _builder.Clear();
            _builder.Append("categories/root?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootCategory>(t.Result.ToString()));
        }

        /// <summary>
        /// List the children categories of a category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-the-children-categories-of-a-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to 0</exception>
        public Task<Categories> ListChildrenCategoriesOfCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/children?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Categories>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's specifications
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-specifications"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to 0</exception>
        public Task<Specifications> ListCategorysSpecifications(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/specifications?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Specifications>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's specifications
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-specifications"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to 0</exception>
        public Task<Groups> ListCategorysSpecificationsGroup(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/specifications?");
            _builder.Append("include=group");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Groups>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's manufacturers
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="orderBy">Order by name or popularity</param>
        /// <param name="orderDir">Order by ascending or descending</param>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-manufacturers"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to 0</exception>
        public Task<Manufacturers> ListCategorysManufactures(int categoryId, OrderByNamePop? orderBy = OrderByNamePop.popularity, OrderDir? orderDir = OrderDir.desc)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/manufacturers?");

            if (orderBy.HasValue)
                _builder.Append($"&order_by={orderBy}");

            if (orderDir.HasValue)
                _builder.Append($"&order_dir={orderDir}");

            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Manufacturers>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's favorites
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-favorites"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to 0</exception>
        /// <remarks>Requires user token with the 'favorites' permission.</remarks>
        public Task<Favorites> ListCategorysFavorites(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/favorites?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Favorites>(t.Result.ToString()));
        }
    }
}
