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
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class Shops.
    /// </summary>
    public class Shops
    {
        /// <summary>
        /// Gets or sets the shops.
        /// </summary>
        /// <value>The shops.</value>
        public List<Shop> shops { get; set; }
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
    /// Class Shop.
    /// </summary>
    public class RootShop
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public string link { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string phone { get; set; }
        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string image_url { get; set; }
        /// <summary>
        /// Gets or sets the thumbshot URL.
        /// </summary>
        /// <value>The thumbshot URL.</value>
        public string thumbshot_url { get; set; }
        /// <summary>
        /// Gets or sets the reviews count.
        /// </summary>
        /// <value>The reviews count.</value>
        public int reviews_count { get; set; }
        /// <summary>
        /// Gets or sets the latest reviews count.
        /// </summary>
        /// <value>The latest reviews count.</value>
        public int latest_reviews_count { get; set; }
        /// <summary>
        /// Gets or sets the review score.
        /// </summary>
        /// <value>The review score.</value>
        public double review_score { get; set; }
        /// <summary>
        /// Gets or sets the payment methods.
        /// </summary>
        /// <value>The payment methods.</value>
        public PaymentMethods payment_methods { get; set; }
        /// <summary>
        /// Gets or sets the shipping.
        /// </summary>
        /// <value>The shipping.</value>
        public Shipping shipping { get; set; }
        /// <summary>
        /// Gets or sets the web URI.
        /// </summary>
        /// <value>The web URI.</value>
        public string web_uri { get; set; }
        /// <summary>
        /// Gets or sets the extra information.
        /// </summary>
        /// <value>The extra information.</value>
        public ExtraInfo extra_info { get; set; }
        /// <summary>
        /// Gets or sets the top positive reasons.
        /// </summary>
        /// <value>The top positive reasons.</value>
        public List<string> top_positive_reasons { get; set; }
    }

    /// <summary>
    /// Class ExtraInfo.
    /// </summary>
    public class ExtraInfo
    {
        /// <summary>
        /// Gets or sets the time on platform.
        /// </summary>
        /// <value>The time on platform.</value>
        public string time_on_platform { get; set; }
        /// <summary>
        /// Gets or sets the orders per week.
        /// </summary>
        /// <value>The orders per week.</value>
        public string orders_per_week { get; set; }
    }

    /// <summary>
    /// Class PaymentMethods.
    /// </summary>
    public class PaymentMethods
    {
        /// <summary>
        /// Gets or sets a value indicating whether [credit card].
        /// </summary>
        /// <value><c>true</c> if [credit card]; otherwise, <c>false</c>.</value>
        public bool credit_card { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaymentMethods" /> is paypal.
        /// </summary>
        /// <value><c>true</c> if paypal; otherwise, <c>false</c>.</value>
        public bool paypal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaymentMethods" /> is bank.
        /// </summary>
        /// <value><c>true</c> if bank; otherwise, <c>false</c>.</value>
        public bool bank { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [spot cash].
        /// </summary>
        /// <value><c>true</c> if [spot cash]; otherwise, <c>false</c>.</value>
        public bool spot_cash { get; set; }
        /// <summary>
        /// Gets or sets the installments.
        /// </summary>
        /// <value>The installments.</value>
        public string installments { get; set; }
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