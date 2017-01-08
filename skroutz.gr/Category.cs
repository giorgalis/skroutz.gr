using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    /// <summary>
    /// Categories are organized in a tree-like structure.
    /// An SKU always belongs to a leaf(ending) category.
    ///Leaf categories have children_count equal to 0.
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
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#list-all-categories"/>
        public Task<IEnumerable<Entities.Categories.Category>> ListAllCategories()
        {
            _builder.Clear();
            _builder.Append("categories");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Entities.Categories.Category>>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#retrieve-a-single-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        public Task<Entities.Categories.Category> RetrieveSingleCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Categories.Category>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve the parent of a category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#retrieve-a-single-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        public Task<Entities.Categories.Category> RetrieveTheParentOfCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/parent");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Categories.Category>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve the root category
        /// </summary>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#retrieve-the-root-category"/>
        public Task<Entities.Categories.Category> RetrieveTheRootCategory()
        {
            _builder.Clear();
            _builder.Append("categories/root");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Categories.Category>(t.Result.ToString()));
        }

        /// <summary>
        /// List the children categories of a category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#list-the-children-categories-of-a-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        public Task<IEnumerable<Entities.Categories.Category>> ListChildrenCategoriesOfCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/children");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Entities.Categories.Category>>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's specifications
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="group"></param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-specifications"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        public Task<IEnumerable<Entities.Categories.Specification>> ListCategorysSpecifications(int categoryId, bool group = false)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/specifications");
            _builder.Append($"?oauth_token={_accessToken}");

            if (group)
                _builder.Append("&include=group");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Entities.Categories.Specification>>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's manufacturers
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-manufacturers"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        public Task<IEnumerable<Entities.Manufacturers.Manufacturer>> ListCategorysManufactures(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/manufacturers");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Entities.Manufacturers.Manufacturer>>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's favorites
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-favorites"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        /// <remarks>Requires user token with the 'favorites' permission.</remarks>
        public Task<IEnumerable<Entities.User.Favorite>> ListCategorysFavorites(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/favorites");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Entities.User.Favorite>>(t.Result.ToString()));
        }
    }
}
