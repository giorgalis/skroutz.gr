using skroutz.gr.Entities.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities.User
{
    public class Snapshot
    {
        public double price_min { get; set; }
        public double latest_price { get; set; }
        public double change_rate { get; set; }
        public bool from_threshold { get; set; }
    }

    public class Sku
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public string display_name { get; set; }
        public Images images { get; set; }
        public object click_url { get; set; }
        public bool @virtual { get; set; }
        public bool future { get; set; }
        public object first_product_shop_info { get; set; }
    }

    public enum NotificationType
    {
        generic,                // A generic type of notification
        price_drop,             // The price of an SKU favorited by the User has been reduced
        price_up,               // The price of an SKU favorited by the User has increased
        availability_true,      // An SKU favorited by the User is again available at a Shop
        sku_review,             // Review(s) have been published for an SKU favorited by the User
        expert_review,          // Review(s) have been published for an SKU favorited by the User
        guide,                  // A new shopping guide has been published
        sku_deletion,           // An SKU favorited by the User is no longer available in Skroutz
        sku_release,            // A "future" SKU has been released
        sku_comment,            // A new SKU comment has been published on a discussion the User is subscribed to
        sku_comment_reply,      // A new reply has been published on an SKU comment posted by the User
        sku_comment_mention,    // The User has been mentioned in an SKU comment
    }

    public class Notification
    {
        public int id { get; set; }
        public NotificationType etype { get; set; }
        public int eventable_id { get; set; }
        public string eventable_type { get; set; }
        public string eventable_name { get; set; }
        public string eventable_url { get; set; }
        public object event_text { get; set; }
        public Snapshot snapshot { get; set; }
        public bool is_viewed { get; set; }
        public bool aggregated { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Sku sku { get; set; }
        public string category_name { get; set; }
    }

    public class UserNotifications
    {
        public List<Notification> notifications { get; set; }
        public Meta meta { get; set; }
    }
}
