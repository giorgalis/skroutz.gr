using System;

namespace skroutz.gr.Shared
{
    /// <summary>
    /// Class ExtentionMethods.
    /// </summary>
    public static class ExtentionMethods
    {
        /// <summary>
        /// Unixes the time to date time.
        /// </summary>
        /// <param name="unixTime">The unix time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime UnixTimeToDateTime(this long unixTime)
        {
            var timeInTicks = unixTime * TimeSpan.TicksPerSecond;
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(timeInTicks);
        }

        /// <summary>
        /// To the title case.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string ToTitleCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

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
