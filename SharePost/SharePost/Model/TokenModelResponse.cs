using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Model
{
    public class TokenModelResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }


        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty(".issued")]
        public string IssuedAt { get; set; }

        [JsonProperty(".expires")]
        public DateTimeOffset? ExpiresAt
        {
            get
            {
                return DateTimeOffset.Now.AddMinutes(this.ExpiresIn);
            }

        }

    }
}
