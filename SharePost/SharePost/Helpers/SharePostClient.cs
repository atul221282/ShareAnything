using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class SharePostClient
    {
        
        ///// <summary>
        ///// Gets the client.
        ///// </summary>
        ///// <param name="authorize">if set to <c>true</c> [authorize].</param>
        ///// <param name="requestedVersion">The requested version.</param>
        ///// <returns></returns>
        //public static HttpClient GetClient(bool authorize = true, string requestedVersion = null)
        //{
        //    if (authorize == true)
        //        CheckAndPossiblyRefreshToken((HttpContext.Current.User.Identity as ClaimsIdentity));
        //}

        //private static void CheckAndPossiblyRefreshToken(ClaimsIdentity id)
        //{
        //    // check if the access token hasn't expired.
        //    if (DateTime.Now.ToLocalTime() >=
        //         (DateTime.Parse(id.FindFirst("expires_at").Value)))
        //    {
        //        // expired.  Get a new one.
        //        var tokenEndpointClient = new OAuth2Client(
        //            new Uri(ShareAnythingConstants.IdSrvToken), 
        //            GlobalConstants.resourceOwnerCredFlowClientId, 
        //            GlobalConstants.resourceOwnerCredFlowSecret);

        //        var tokenEndpointResponse =
        //             tokenEndpointClient
        //            .RequestRefreshTokenAsync(id.FindFirst("refresh_token").Value).Result;

        //        if (!tokenEndpointResponse.IsError)
        //        {
        //            // replace the claims with the new values - this means creating a 
        //            // new identity!                              
        //            var result = from claim in id.Claims
        //                         where claim.Type != "access_token" && claim.Type != "refresh_token" &&
        //                               claim.Type != "expires_at"
        //                         select claim;

        //            var claims = result.ToList();

        //            claims.Add(new Claim("access_token", tokenEndpointResponse.AccessToken));
        //            claims.Add(new Claim("expires_at",
        //                         DateTime.Now.AddSeconds(tokenEndpointResponse.ExpiresIn)
        //                         .ToLocalTime().ToString()));
        //            claims.Add(new Claim("refresh_token", tokenEndpointResponse.RefreshToken));

        //            var newIdentity = new ClaimsIdentity(claims, "Cookies");
        //            var wrapper = new HttpRequestWrapper(HttpContext.Current.Request);
        //            wrapper.GetOwinContext().Authentication.SignIn(newIdentity);
        //        }
        //        else
        //        {
        //            // log, ...
        //            throw new Exception("An error has occurred while refreshing token");
        //        }
        //    }

        //}
    }
}
