﻿using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    /// <summary>
    /// A Flag is used to mark user provided content as requiring attention/moderation.
    /// </summary>
    public class Flag : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        public Flag(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        public Flag(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Retrieve all flags
        /// </summary>
        /// <see cref="https://developer.skroutz.gr/api/v3/flag/#retrieve-all-flags"/>
        public Task<Entities.Flags.Flags> RetrieveAllFlags()
        {
            _builder.Clear();
            _builder.Append($"flags");
            _builder.Append($"?oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Flags.Flags>(t.Result.ToString()));
        }
    }
}