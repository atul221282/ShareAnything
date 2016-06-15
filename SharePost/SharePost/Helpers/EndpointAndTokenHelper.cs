using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharePost.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace SharePost.Helpers
{
    public static class EndpointAndTokenHelper
    {
        /// <summary>
        /// Sets the tokens and set AccessToken and RefreshToken settings
        /// </summary>
        /// <param name="tokenResponse">The token response.</param>
        public static void SetToken(string tokenResponse)
        {
            JToken token = JObject.Parse(tokenResponse);
            TokenModelResponse model = new TokenModelResponse
            {
                AccessToken = (string)token.SelectToken("access_token"),
                ExpiresIn = (int)token.SelectToken("expires_in"),
                RefreshToken = (string)token.SelectToken("refresh_token"),
                TokenType = (string)token.SelectToken("token_type"),
                Username = CommonHelper.GetUserDetails()?.Name,
                IssuedAt = DateTime.UtcNow.ToString(),
                ExpiresAt = DateTime.UtcNow.AddMinutes((int)token.SelectToken("expires_in")).ToString()
            };
            Settings.TokenResponse = JsonConvert.SerializeObject(model);
        }

        public static void SetToken(TokenResponse response)
        {
            TokenModelResponse model = new TokenModelResponse
            {
                AccessToken = response.AccessToken,
                ExpiresIn = (int)response.ExpiresIn,
                RefreshToken = response.RefreshToken,
                TokenType = response.TokenType,
                Username = CommonHelper.GetUserDetails()?.Name,
                IssuedAt = DateTime.UtcNow.ToString(),
                ExpiresAt = DateTime.UtcNow.AddMinutes(response.ExpiresIn).ToString()
            };
            Settings.TokenResponse = JsonConvert.SerializeObject(model);
        }

        public static TokenModelResponse GetTokenResponse()
        {
            if (string.IsNullOrWhiteSpace(Settings.TokenResponse))
                return null;
            return JsonConvert.DeserializeObject<TokenModelResponse>(Settings.TokenResponse);
        }
        public static bool HasTokenExpired()
        {
            TokenModelResponse model = GetTokenResponse();
            DateTime expiringTime = DateTime.Parse(model.ExpiresAt);
            return model == null || DateTime.UtcNow > expiringTime || (expiringTime == DateTime.MinValue);
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
