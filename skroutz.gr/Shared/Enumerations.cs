namespace skroutz.gr.Shared
{
        /// <summary>
        /// Order by Asceding or Desceding
        /// </summary>
        public enum OrderDir
        {
            /// <summary>
            /// Asceding
            /// </summary>
            asc,
            /// <summary>
            /// Descending
            /// </summary>
            desc
        }

        /// <summary>
        /// Order by Name or Popularity
        /// </summary>
        public enum OrderByNamePop
        {
            /// <summary>
            /// Name
            /// </summary>
            name,
            /// <summary>
            /// Popularity
            /// </summary>
            popularity,
        }

    /// <summary>
    /// Order by Price or Popularity
    /// </summary>
        public enum OrderByPrcPop
        {
            /// <summary>
            /// Price
            /// </summary>
            price,
            /// <summary>
            /// Popularity
            /// </summary>
            popularity,
        }

    /// <summary>
    /// Order by Price or Popularity or Rating
    /// </summary>
        public enum OrderByPrcPopRating
        {
            /// <summary>
            /// Price including VAT
            /// </summary>
            pricevat,
            /// <summary>
            /// Popularity
            /// </summary>
            popularity,
            /// <summary>
            /// Rating
            /// </summary>
            rating
        }
}
