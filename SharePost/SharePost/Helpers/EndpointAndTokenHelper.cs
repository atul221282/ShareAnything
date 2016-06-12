using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Helpers
{
    public static class EndpointAndTokenHelper
    {
        /// <summary>
        /// Sets the tokens and set AccessToken and RefreshToken settings
        /// </summary>
        /// <param name="tokenResponse">The token response.</param>
        public static void SetTokens(string tokenResponse)
        {
            JToken token = JObject.Parse(tokenResponse);
            string accessToken = (string)token.SelectToken("access_token");
            string refreshToken = (string)token.SelectToken("refresh_token");
            Settings.AccessToken = accessToken;
            Settings.RefreskToken = refreshToken;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async static Task<JObject> CallUserInfoEndpoint(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(ShareAnythingConstants.IdSrvUserInfo);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                Settings.UserDetails = json;
                return JObject.Parse(json); //.ToString();

            }
            else
            {
                Settings.UserDetails = string.Empty;
                return null;
            }
        }

    }
}
