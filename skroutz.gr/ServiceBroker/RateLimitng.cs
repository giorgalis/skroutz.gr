using System;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides info about Rate Limiting requests.
    /// </summary>
    /// <remarks>You can make up to a certain amount of requests for each OAuth token associated with your application.</remarks>
    public class RateLimiting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimiting"/> class.
        /// </summary>
        public RateLimiting()
        {
        
        }
        /// <summary>
        /// The maximum number of requests that the consumer is permitted to make per minute.
        /// </summary>
        public int Limit { get; set; }


        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        public int Remaining { get; set; }

        private int reset;

        /// <summary>
        /// The time at which the current rate limit window resets in UTC epoch seconds.
        /// </summary>
        /// <value>The UTC epoch seconds.</value>
        public int Reset
        {
            get { return reset; }
            set
            {
                reset = value;
                ResetInDateTime = UnixTimeToDateTime(value);
            }
        }

        /// <summary>
        /// Gets or sets the reset in UTC date time.
        /// </summary>
        /// <value>The reset in UTC date time.</value>
        public DateTime ResetInDateTime { get; set; }

        private DateTime UnixTimeToDateTime(long unixTime)
        {
            var timeInTicks = unixTime * TimeSpan.TicksPerSecond;
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(timeInTicks);
        }
    }
}
