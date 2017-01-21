using Newtonsoft.Json;
using skroutz.gr.Entities;
using skroutz.gr.Entities.User;
using skroutz.gr.Shared;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for accesing Category's data including root category, children categories, category's specifications, reviews and other.
    /// </summary>
    /// <remarks>
    /// Categories are organized in a tree-like structure.
    /// An SKU always belongs to a leaf (ending) category.
    /// Leaf categories have <see cref="Entities.Base.Category.ChildrenCount"/> equal to 0.
    /// </remarks>
    /// <seealso cref="RootCategory"/>
    /// <seealso cref="Categories"/>
    public class Category : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Category(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Category(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Lists all categories.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Categories&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-all-categories" />
        public Task<Categories> ListAllCategories(int page = 1, int per = 25, params Expression<Func<Entities.Base.Category, object>>[] sparseFields)
        {
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append("categories?");
            _builder.Append($"oauth_token={_accessToken}");
            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Categories>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single category.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;RootCategory&gt;</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#retrieve-a-single-category" />
        public Task<RootCategory> RetrieveSingleCategory(int categoryId, params Expression<Func<Entities.Base.Category, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}?");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootCategory>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve the parent of a category.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;RootCategory&gt;</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#retrieve-a-single-category" />
        public Task<RootCategory> RetrieveTheParentOfCategory(int categoryId, params Expression<Func<Entities.Base.Category, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/parent?");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootCategory>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve the root category.
        /// </summary>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;RootCategory&gt;</returns>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#retrieve-the-root-category" />
        public Task<RootCategory> RetrieveTheRootCategory(params Expression<Func<Entities.Base.Category, object>>[] sparseFields)
        {
            _builder.Clear();
            _builder.Append("categories/root?");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootCategory>(t.Result.ToString()));
        }

        /// <summary>
        /// List the children categories of a category.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Categories&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-the-children-categories-of-a-category" />
        public Task<Categories> ListChildrenCategoriesOfCategory(int categoryId, int page = 1, int per = 25, params Expression<Func<Entities.Base.Category, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/children?");
            _builder.Append($"oauth_token={_accessToken}");
            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Categories>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's specifications.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Specifications&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-specifications" />
        public Task<Specifications> ListCategorysSpecifications(int categoryId, int page = 1, int per = 25, params Expression<Func<Entities.Base.Specification, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/specifications?");
            _builder.Append($"oauth_token={_accessToken}");
            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Specifications>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's specifications.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Groups&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-specifications" />
        public Task<Groups> ListCategorysSpecificationsGroup(int categoryId, int page = 1, int per = 25, params Expression<Func<Entities.Base.Group, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/specifications?");
            _builder.Append("include=group");
            _builder.Append($"&oauth_token={_accessToken}");
            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Groups>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's manufacturers.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="orderBy">Order by name or popularity</param>
        /// <param name="orderDir">Order by ascending or descending</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Manufacturers&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-manufacturers" />
        public Task<Manufacturers> ListCategorysManufactures(int categoryId, OrderByNamePop? orderBy = OrderByNamePop.popularity, OrderDir? orderDir = OrderDir.desc, int page = 1, int per = 25, params Expression<Func<Entities.Base.Manufacturer, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/manufacturers?");

            if (orderBy.HasValue)
                _builder.Append($"&order_by={orderBy}");

            if (orderDir.HasValue)
                _builder.Append($"&order_dir={orderDir}");

            _builder.Append($"&oauth_token={_accessToken}");
            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Manufacturers>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's favorites.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Favorites&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-favorites" />
        /// <remarks>Requires user token with the 'favorites' permission.</remarks>
        public Task<Favorites> ListCategorysFavorites(int categoryId, int page = 1, int per = 25, params Expression<Func<Favorite, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/favorites?");
            _builder.Append($"oauth_token={_accessToken}");
            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Favorites>(t.Result.ToString()));
        }
    }
}
