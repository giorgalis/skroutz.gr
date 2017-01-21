using Newtonsoft.Json;
using skroutz.gr.Entities;
using skroutz.gr.Shared;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for accesing Manufacturer's data.
    /// </summary>
    public class Manufacturer : Request
    {
        /// <summary>
        /// The builder
        /// </summary>
        private readonly StringBuilder _builder;
        /// <summary>
        /// The access token
        /// </summary>
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manufacturer" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Manufacturer(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Manufacturer" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Manufacturer(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }


        /// <summary>
        /// List manufacturers
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Manufacturers&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/manufacturer/#list-manufacturers" />
        public Task<Manufacturers> ListManufacturers(int page = 1, int per = 25, params Expression<Func<Entities.Base.Manufacturer, object>>[] sparseFields)
        {
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append("manufacturers?");
            _builder.Append($"oauth_token={_accessToken}");
            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");


            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Manufacturers>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single manufacturer
        /// </summary>
        /// <param name="manufacturerId">Unique Identifier of the manufacturer</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;RootManufacturer&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="manufacturerId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/manufacturer/#retrieve-a-single-manufacturer" />
        public Task<RootManufacturer> RetrieveSingleManufacturer(int manufacturerId, params Expression<Func<Entities.Base.Manufacturer, object>>[] sparseFields)
        {
            if (manufacturerId <= 0) throw new ArgumentOutOfRangeException(nameof(manufacturerId));

            _builder.Clear();
            _builder.Append($"manufacturers/{manufacturerId}?");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootManufacturer>(t.Result.ToString()));
        }


        /// <summary>
        /// Retrieve a manufacturer's categories
        /// </summary>
        /// <param name="manufacturerId">Unique identifier of the manufacturer</param>
        /// <param name="orderBy">Order by name or popularity</param>
        /// <param name="orderDir">Order by ascending or descending</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Categories&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="manufacturerId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/manufacturer/#retrieve-a-manufacturers-categories" />
        public Task<Categories> RetrieveManufacturerCategories(int manufacturerId, OrderByNamePop? orderBy = OrderByNamePop.popularity, OrderDir? orderDir = OrderDir.desc, int page = 1, int per = 25, params Expression<Func<Entities.Base.Category, object>>[] sparseFields)
        {
            if (manufacturerId <= 0) throw new ArgumentOutOfRangeException(nameof(manufacturerId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append($"manufacturers/{manufacturerId}/categories?");

            if (orderBy.HasValue)
                _builder.Append($"&order_by={orderBy}");

            if (orderDir.HasValue)
                _builder.Append($"&order_dir={orderDir}");

            _builder.Append($"&oauth_token={_accessToken}");

            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Categories>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a manufacturer's SKUs
        /// </summary>
        /// <param name="manufacturerId">Unique identifier of the manufacturer</param>
        /// <param name="orderBy">Order by name or popularity</param>
        /// <param name="orderDir">Order by ascending or descending</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;SKUs&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="manufacturerId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/manufacturer/#retrieve-a-manufacturers-skus" />
        public Task<SKUs> RetrieveManufacturerSKUs(int manufacturerId, OrderByPrcPop? orderBy = OrderByPrcPop.popularity, OrderDir? orderDir = OrderDir.desc, int page = 1, int per = 25, params Expression<Func<Entities.Base.SKU, object>>[] sparseFields)
        {
            if (manufacturerId <= 0) throw new ArgumentOutOfRangeException(nameof(manufacturerId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append($"manufacturers/{manufacturerId}/skus?");

            if (orderBy.HasValue)
                _builder.Append($"&order_by={orderBy}");

            if (orderDir.HasValue)
                _builder.Append($"&order_dir={orderDir}");

            _builder.Append($"&oauth_token={_accessToken}");

            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<SKUs>(t.Result.ToString()));
        }
    }
}
