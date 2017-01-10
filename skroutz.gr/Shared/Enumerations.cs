namespace skroutz.gr.Shared
{
        /// <summary>
        /// Order by asceding or desceding
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
        /// Order by name or popularity
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
