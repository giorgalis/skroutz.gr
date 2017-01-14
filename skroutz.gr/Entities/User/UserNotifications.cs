// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-06-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-10-2017
// ***********************************************************************
// <copyright file="UserNotifications.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Model.User
{
    /// <summary>
    /// Class Snapshot.
    /// </summary>
    public class Snapshot
    {
        /// <summary>
        /// Gets or sets the price minimum.
        /// </summary>
        /// <value>The price minimum.</value>
        public double price_min { get; set; }
        /// <summary>
        /// Gets or sets the latest price.
        /// </summary>
        /// <value>The latest price.</value>
        public double latest_price { get; set; }
        /// <summary>
        /// Gets or sets the change rate.
        /// </summary>
        /// <value>The change rate.</value>
        public double change_rate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [from threshold].
        /// </summary>
        /// <value><c>true</c> if [from threshold]; otherwise, <c>false</c>.</value>
        public bool from_threshold { get; set; }
    }

    /// <summary>
    /// Class Sku.
    /// </summary>
    public class Sku
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        public int category_id { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string display_name { get; set; }
        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public Images images { get; set; }
        /// <summary>
        /// Gets or sets the click URL.
        /// </summary>
        /// <value>The click URL.</value>
        public object click_url { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Sku"/> is virtual.
        /// </summary>
        /// <value><c>true</c> if virtual; otherwise, <c>false</c>.</value>
        public bool @virtual { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Sku"/> is future.
        /// </summary>
        /// <value><c>true</c> if future; otherwise, <c>false</c>.</value>
        public bool future { get; set; }
        /// <summary>
        /// Gets or sets the first product shop information.
        /// </summary>
        /// <value>The first product shop information.</value>
        public object first_product_shop_info { get; set; }
    }

    /// <summary>
    /// Enum NotificationType
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// The generic
        /// </summary>
        generic,                // A generic type of notification
        /// <summary>
        /// The price drop
        /// </summary>
        price_drop,             // The price of an SKU favorited by the User has been reduced
        /// <summary>
        /// The price up
        /// </summary>
        price_up,               // The price of an SKU favorited by the User has increased
        /// <summary>
        /// The availability true
        /// </summary>
        availability_true,      // An SKU favorited by the User is again available at a Shop
        /// <summary>
        /// The sku review
        /// </summary>
        sku_review,             // Review(s) have been published for an SKU favorited by the User
        /// <summary>
        /// The expert review
        /// </summary>
        expert_review,          // Review(s) have been published for an SKU favorited by the User
        /// <summary>
        /// The guide
        /// </summary>
        guide,                  // A new shopping guide has been published
        /// <summary>
        /// The sku deletion
        /// </summary>
        sku_deletion,           // An SKU favorited by the User is no longer available in Skroutz
        /// <summary>
        /// The sku release
        /// </summary>
        sku_release,            // A "future" SKU has been released
        /// <summary>
        /// The sku comment
        /// </summary>
        sku_comment,            // A new SKU comment has been published on a discussion the User is subscribed to
        /// <summary>
        /// The sku comment reply
        /// </summary>
        sku_comment_reply,      // A new reply has been published on an SKU comment posted by the User
        /// <summary>
        /// The sku comment mention
        /// </summary>
        sku_comment_mention,    // The User has been mentioned in an SKU comment
    }

    /// <summary>
    /// Class Notification.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the etype.
        /// </summary>
        /// <value>The etype.</value>
        public NotificationType etype { get; set; }
        /// <summary>
        /// Gets or sets the eventable identifier.
        /// </summary>
        /// <value>The eventable identifier.</value>
        public int eventable_id { get; set; }
        /// <summary>
        /// Gets or sets the type of the eventable.
        /// </summary>
        /// <value>The type of the eventable.</value>
        public string eventable_type { get; set; }
        /// <summary>
        /// Gets or sets the name of the eventable.
        /// </summary>
        /// <value>The name of the eventable.</value>
        public string eventable_name { get; set; }
        /// <summary>
        /// Gets or sets the eventable URL.
        /// </summary>
        /// <value>The eventable URL.</value>
        public string eventable_url { get; set; }
        /// <summary>
        /// Gets or sets the event text.
        /// </summary>
        /// <value>The event text.</value>
        public object event_text { get; set; }
        /// <summary>
        /// Gets or sets the snapshot.
        /// </summary>
        /// <value>The snapshot.</value>
        public Snapshot snapshot { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is viewed.
        /// </summary>
        /// <value><c>true</c> if this instance is viewed; otherwise, <c>false</c>.</value>
        public bool is_viewed { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Notification"/> is aggregated.
        /// </summary>
        /// <value><c>true</c> if aggregated; otherwise, <c>false</c>.</value>
        public bool aggregated { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public string created_at { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        public string updated_at { get; set; }
        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        /// <value>The sku.</value>
        public Sku sku { get; set; }
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>The name of the category.</value>
        public string category_name { get; set; }
    }

    /// <summary>
    /// Class UserNotifications.
    /// </summary>
    public class UserNotifications
    {
        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>The notifications.</value>
        public List<Notification> notifications { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public Meta meta { get; set; }
    }
}
