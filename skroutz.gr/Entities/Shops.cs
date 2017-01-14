// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-14-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-14-2017
// ***********************************************************************
// <copyright file="Shops.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{

    /// <summary>
    /// Class RootShop.
    /// </summary>
    public class RootShop
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        [JsonProperty("link")]
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        /// <summary>
        /// Gets or sets the thumbshot URL.
        /// </summary>
        /// <value>The thumbshot URL.</value>
        [JsonProperty("thumbshot_url")]
        public string ThumbshotUrl { get; set; }
        /// <summary>
        /// Gets or sets the reviews count.
        /// </summary>
        /// <value>The reviews count.</value>
        [JsonProperty("reviews_count")]
        public int ReviewsCount { get; set; }
        /// <summary>
        /// Gets or sets the latest reviews count.
        /// </summary>
        /// <value>The latest reviews count.</value>
        [JsonProperty("latest_reviews_count")]
        public int LatestReviewsCount { get; set; }
        /// <summary>
        /// Gets or sets the review score.
        /// </summary>
        /// <value>The review score.</value>
        [JsonProperty("review_score")]
        public double ReviewScore { get; set; }
        /// <summary>
        /// Gets or sets the payment methods.
        /// </summary>
        /// <value>The payment methods.</value>
        [JsonProperty("payment_methods")]
        public Base.PaymentMethods PaymentMethods { get; set; }
        /// <summary>
        /// Gets or sets the shipping.
        /// </summary>
        /// <value>The shipping.</value>
        [JsonProperty("shipping")]
        public Base.Shipping Shipping { get; set; }
        /// <summary>
        /// Gets or sets the web URI.
        /// </summary>
        /// <value>The web URI.</value>
        [JsonProperty("web_uri")]
        public string WebUri { get; set; }
        /// <summary>
        /// Gets or sets the extra information.
        /// </summary>
        /// <value>The extra information.</value>
        [JsonProperty("extra_info")]
        public Base.ExtraInfo ExtraInfo { get; set; }
        /// <summary>
        /// Gets or sets the top positive reasons.
        /// </summary>
        /// <value>The top positive reasons.</value>
        [JsonProperty("top_positive_reasons")]
        public List<string> TopPositiveReasons { get; set; }
    }
    /// <summary>
    /// Class Shops.
    /// </summary>
    public class Shops
    {
        /// <summary>
        /// Gets or sets the shops.
        /// </summary>
        /// <value>The shops.</value>
        public List<RootShop> shops { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public Meta meta { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class ExtraInfo.
    /// </summary>
    public class ExtraInfo
    {
        /// <summary>
        /// Gets or sets the time on platform.
        /// </summary>
        /// <value>The time on platform.</value>
        [JsonProperty("time_on_platform")]
        public string TimeOnPlatform { get; set; }
        /// <summary>
        /// Gets or sets the orders per week.
        /// </summary>
        /// <value>The orders per week.</value>
        [JsonProperty("orders_per_week")]
        public string OrdersPerWeek { get; set; }
    }

    /// <summary>
    /// Class PaymentMethods.
    /// </summary>
    public class PaymentMethods
    {
        /// <summary>
        /// Gets or sets a value indicating whether <see cref="PaymentMethods" /> is credit card.
        /// </summary>
        /// <value><c>true</c> if [credit card]; otherwise, <c>false</c>.</value>
        [JsonProperty("credit_card")]
        public bool CreditCard { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaymentMethods" /> is paypal.
        /// </summary>
        /// <value><c>true</c> if paypal; otherwise, <c>false</c>.</value>
        [JsonProperty("paypal")]
        public bool Paypal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaymentMethods" /> is bank.
        /// </summary>
        /// <value><c>true</c> if bank; otherwise, <c>false</c>.</value>
        [JsonProperty("bank")]
        public bool Bank { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaymentMethods" /> is spot cash.
        /// </summary>
        /// <value><c>true</c> if [spot cash]; otherwise, <c>false</c>.</value>
        [JsonProperty("spot_cash")]
        public bool SpotCash { get; set; }
        /// <summary>
        /// Gets or sets the installments.
        /// </summary>
        /// <value>The installments.</value>
        [JsonProperty("installments")]
        public string Installments { get; set; }
    }

    /// <summary>
    /// Class Shipping.
    /// </summary>
    public class Shipping
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Shipping" /> is free.
        /// </summary>
        /// <value><c>true</c> if free; otherwise, <c>false</c>.</value>
        public bool free { get; set; }
        /// <summary>
        /// Gets or sets the free from.
        /// </summary>
        /// <value>The free from.</value>
        public object free_from { get; set; }
        /// <summary>
        /// Gets or sets the free from information.
        /// </summary>
        /// <value>The free from information.</value>
        public string free_from_info { get; set; }
        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>The minimum price.</value>
        public string min_price { get; set; }
    }
}