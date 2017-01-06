using Newtonsoft.Json;
using skroutz.gr.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    class Category : Request
    {
        private readonly StringBuilder _builder;

        public Category(StringBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Lists all categories
        /// </summary>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#list-all-categories"/>
        /// <returns></returns>
        public Task<IEnumerable<Category>> ListAllCategories()
        {
            _builder.Clear();
            _builder.Append("categories");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Category>>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category to return</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#retrieve-a-single-category"/>
        /// <returns></returns>
        public Task<Category> RetrieveSingleCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Category>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve the parent of a category
        /// </summary>
        /// <param name="categoryId"></param>
        /// /// <see cref="https://developer.skroutz.gr/api/v3/category/#retrieve-a-single-category"/>
        /// <returns></returns>
        public Task<Category> RetrieveTheParentOfCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/parent");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Category>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve the root category
        /// </summary>
        /// <returns></returns>
        public Task<Category> RetrieveTheRootCategory()
        {
            _builder.Clear();
            _builder.Append("categories/root");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Category>(t.Result.ToString()));
        }

        /// <summary>
        /// List the children categories of a category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Category>> ListChildrenCategoriesOfCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/children");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Category>>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's specifications
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="group"></param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-specifications"/>
        /// <returns></returns>
        public Task<IEnumerable<Specification>> ListCategorysSpecifications(int categoryId, bool group = false)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/specifications");

            if (group)
                _builder.Append("?include=group");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Specification>>(t.Result.ToString()));
        }

        /// <summary>
        /// List a category's manufacturers
        /// </summary>
        /// <param name="categoryId"></param>
        /// <see cref="https://developer.skroutz.gr/api/v3/category/#list-a-categorys-manufacturers"/>
        /// <returns></returns>
        public Task<IEnumerable<Manufacturer>> ListCategorysManufactures(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/manufacturers");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<IEnumerable<Manufacturer>>(t.Result.ToString()));
        }

    }
}
