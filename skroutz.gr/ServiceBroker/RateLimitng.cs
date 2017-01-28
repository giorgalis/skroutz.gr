using skroutz.gr.Shared;
using System;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides info about Rate Limits.
    /// </summary>
    /// <remarks>You can make up to a certain amount of requests for each OAuth token associated with your application.</remarks>
    public class RateLimiting
    {
        /// <summary>
        /// The maximum number of requests that the consumer is permitted to make per minute.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        public int Remaining { get; set; }

        private long reset;

        /// <summary>
        /// The time at which the current rate limit window resets in <see href="https://en.wikipedia.org/wiki/Unix_time">UTC epoch seconds</see>.
        /// </summary>
        /// <value>The UTC epoch seconds.</value>
        public long Reset
        {
            get { return reset; }
            set
            {
                reset = value;
                ResetInDateTime = value.UnixTimeToDateTime();
            }
        }


        /// <summary>
        /// Gets or sets the reset in UTC date time.
        /// </summary>
        /// <value>The reset in UTC date time.</value>
        public DateTime ResetInDateTime { get; set; }
    }
}
