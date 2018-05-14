using System;

namespace skroutz.gr.Shared
{
    /// <summary>
    /// Class ExtentionMethods.
    /// </summary>
    public static class ExtentionMethods
    {
        /// <summary>
        /// Converts the Unix time to standard date time.
        /// </summary>
        /// <param name="unixTime">The unix time to convert.</param>
        /// <returns><see cref="DateTime"/>.</returns>
        public static DateTime UnixTimeToDateTime(this long unixTime)
        {
            var timeInTicks = unixTime * TimeSpan.TicksPerSecond;
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(timeInTicks);
        }

        /// <summary>
        /// Converts the specified string to title case.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>System.String.</returns>
        public static string ToTitleCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) 
                return s;

            string[] textArray = s.Split(' ');

            for (int i = 0; i < textArray.Length; i++)
            {
                switch (textArray[i].Length)
                {
                    case 1:
                        break;
                    default:
                        textArray[i] = char.ToUpper(textArray[i][0]) + textArray[i].Substring(1);
                        break;
                }
            }

            return string.Join(" ", textArray);
        }
    }
}
