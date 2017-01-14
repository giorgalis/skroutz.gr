﻿// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-08-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-11-2017
// ***********************************************************************
// <copyright file="Flag.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using skroutz.gr.Entities;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    /// <summary>
    /// Provides method for retrieving flags.
    /// </summary>
    /// <remarks>A Flag is used to mark user provided content as requiring attention/moderation.</remarks>
    /// <seealso cref="skroutz.gr.Request" />
    public class Flag : Request
    {
        /// <summary>
        /// The builder
        /// </summary>
        private readonly StringBuilder _builder;
        /// <summary>
        /// The access token
        /// </summary>
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the Flag class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Flag(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the Flag class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Flag(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Retrieve all flags
        /// </summary>
        /// <returns>Task&lt;Flags&gt;.</returns>
        /// <see href="https://developer.skroutz.gr/api/v3/flag/#retrieve-all-flags" />
        public Task<Flags> RetrieveAllFlags()
        {
            _builder.Clear();
            _builder.Append($"flags?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Flags>(t.Result.ToString()));
        }
    }
}
