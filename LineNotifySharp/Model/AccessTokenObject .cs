using Newtonsoft.Json;
using System;

namespace LineNotifySharp.Model
{
    class AccessTokenObject
    {
        public AccessTokenObject(string accessToken)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
