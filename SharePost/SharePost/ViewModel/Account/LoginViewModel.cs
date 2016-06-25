using SharePost.Helpers;
using SharePost.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SharePost.Extension;
using Xamarin.Forms;
using SharePost.View;
using Newtonsoft.Json.Linq;
using Plugin.DeviceInfo;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace SharePost.ViewModel.Account
{
    public class LoginViewModel : BaseViewModel
    {
        #region "Property"
        private string _userName;
        private string _password;
        private Position _position;

        public Position Position
        {
            get { return _position; }
            set { _position = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private bool _isNotLoading;

        public bool IsNotLoading
        {
            get { return !IsLoading; }
        }

        #endregion

        /// <summary>
        /// Logins this instance.
        /// </summary>
        public async void Login()
        {
            this.IsLoading = true;
            using (HttpClient client = SharePostClient.GetClient(false))
            {
                var url = ShareAnythingConstants.ExpenseTrackerAPI + "api/Account/Login";
                var result = await client.PostStringAsync<object>(url,
                    new { EmailAddress = this.UserName, Password = this.Password });

                if (result.IsSuccessStatusCode)
                {
                    EndpointAndTokenHelper.SetToken(await result.Content.ReadAsStringAsync());
                    var userDetails = await EndpointAndTokenHelper
                        .CallUserInfoEndpoint(EndpointAndTokenHelper.GetTokenResponse().AccessToken);
                    
                }
            }
            this.IsLoading = false;
        }


    }
}
