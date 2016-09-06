using SharePost.Extension;
using SharePost.Helpers;
using SharePost.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Service
{
    public class LoginService : ILoginService
    {
        public async Task LoginAsync(string userName, string password)
        {
            using (HttpClient client = SharePostClient.GetClient(authorize: false))
            {
                var url = ShareAnythingConstants.ExpenseTrackerAPI + "api/Account/Login";
                var result = await client.PostStringAsync<object>(url,
                    new { EmailAddress = userName, Password = password });

                if (result.IsSuccessStatusCode)
                {
                    EndpointAndTokenHelper.SetToken(await result.Content.ReadAsStringAsync());
                    var userDetails = await EndpointAndTokenHelper
                        .CallUserInfoEndpoint(EndpointAndTokenHelper.GetTokenResponse().AccessToken);

                }
            }
        }
    }
}
