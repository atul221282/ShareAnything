﻿using SharePost.Helpers;
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
using SharePost.Factory;
using Newtonsoft.Json.Linq;

namespace SharePost.ViewModel.Account
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        private string _password;

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

        /// <summary>
        /// Logins this instance.
        /// </summary>
        public async void Login()
        {
            using (HttpClient client = new HttpClient())
            {
                var url = ShareAnythingConstants.ExpenseTrackerAPI + "api/Account/Login";
                var result = await client.PostStringAsync<object>(url,
                    new { EmailAddress = this.UserName, Password = this.Password });

                if (result.IsSuccessStatusCode)
                {
                    SetMainPage(new MainPage());
                    JToken token = JObject.Parse(await result.Content.ReadAsStringAsync());
                    string accessToken = (string)token.SelectToken("access_token");
                    string refreshToken = (string)token.SelectToken("refresh_token");
                    var userData = await SetTokenAndUserDetails(accessToken);
                    //set token setting and user detail setting
                }

            }
        }


    }
}
