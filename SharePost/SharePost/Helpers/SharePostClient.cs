using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace SharePost.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class SharePostClient
    {

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="authorize">if set to <c>true</c> [authorize].</param>
        /// <param name="requestedVersion">The requested version.</param>
        /// <returns></returns>
        public static HttpClient GetClient(bool authorize = true, string requestedVersion = null)
        {
            if (authorize == true)
                CheckAndPossiblyRefreshToken();

            HttpClient client = new HttpClient();
            var tokenResponse = EndpointAndTokenHelper.GetTokenResponse();
            var token = tokenResponse?.AccessToken;
            if (token != null && authorize == true)
            {
                client.SetBearerToken(token);
            }

            client.BaseAddress = new Uri(ShareAnythingConstants.ExpenseTrackerAPI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (requestedVersion != null)
            {
                // through a custom request header
                //client.DefaultRequestHeaders.Add("api-version", requestedVersion);
                // through content negotiation
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.expensetrackerapi.v"
                        + requestedVersion + "+json"));
            }
            return client;
        }

        private static void CheckAndPossiblyRefreshToken()
        {
            // check if the access token hasn't expired.
            if (EndpointAndTokenHelper.HasTokenExpired())
            {
                // expired.  Get a new one.
                var tokenEndpointClient = new OAuth2Client(
                    new Uri(ShareAnythingConstants.IdSrvToken),
                    GlobalConstants.resourceOwnerCredFlowClientId,
                    GlobalConstants.resourceOwnerCredFlowSecret);
                try
                {
                    var tokenEndpointResponse = tokenEndpointClient
                        .RequestRefreshTokenAsync(EndpointAndTokenHelper.GetTokenResponse().RefreshToken).Result;
                    if (!tokenEndpointResponse.IsError)
                    {
                        // replace the claims with the new values - this means creating a 
                        // new identity!                              
                        var result = tokenEndpointResponse as TokenResponse;
                        EndpointAndTokenHelper.SetToken(result);
                    }
                    else
                    {
                        // log, ...
                        throw new Exception("An error has occurred while refreshing token");
                    }
                }
                catch (Exception ex)
                {
                    var ff = ex;
                }
                
            }

        }
    }
}
