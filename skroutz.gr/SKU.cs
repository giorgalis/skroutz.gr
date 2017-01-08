﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    /// <summary>
    /// A SKU (Stock Keeping Unit) is an aggregation of products.
    /// </summary>
    public class SKU : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        public enum order_by
        {
            pricevat,
            popularity,
            rating
        }

        public enum order_dir
        {
            asc,
            desc
        }

        public SKU(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        public SKU(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// List SKUs of specific category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="orderBy">Order by price, popularity or rating</param>
        /// <param name="orderDir">Order ascending or descending</param>
        /// <param name="searchKeyword">The keyword to search by</param>
        /// <param name="manufacturerIds">The ids of the manufacturers of the SKUs</param>
        /// <param name="filterIds">The ids of the filters to be applied on the SKUs</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/sku/#list-skus-of-specific-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        /// <remarks>The default order_by value may differ across categories but in most cases it's pricevat.</remarks>
        public Task<Entities.SKUs.SKUs> ListSKUsOfSpecificCategory(int categoryId, order_by orderBy = order_by.pricevat, order_dir orderDir = order_dir.asc, string searchKeyword = null, IList<int> manufacturerIds = null, IList<int> filterIds = null)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/skus");
            _builder.Append($"?order_by={orderBy}");
            _builder.Append($"&order_dir={orderDir}");
            _builder.Append($"&oauth_token={_accessToken}");

            if(!string.IsNullOrEmpty(searchKeyword))
                _builder.Append($"&q={searchKeyword}");

            if (manufacturerIds != null)
                _builder.Append($"&manufacturer_ids[]={string.Join("&manufacturer_ids[]=", manufacturerIds.Select(s => s.ToString()))}");

            if (filterIds != null)
                _builder.Append($"&filter_ids[]={string.Join("&filter_ids[]=", filterIds.Select(s => s.ToString()))}");
            
            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.SKUs.SKUs>(t.Result.ToString()));
        }
    }
}
