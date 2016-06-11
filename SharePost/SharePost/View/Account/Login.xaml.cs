using Plugin.Geolocator;
using SharePost.Helpers;
using SharePost.View.Post;
using SharePost.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SharePost.View.Account
{
    public partial class Login
    {
        LoginViewModel vm;
        public Login()
        {
            vm = new LoginViewModel();
            InitializeComponent();
            BindingContext = vm;
        }

        /// <summary>
        /// Navigates the user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void NavigateUser(Login login)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        /// <summary>
        /// Called when [clicked_btn login].
        /// </summary>
        /// <param name="sender">The sedner.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnLogin(object sender, EventArgs events)
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                Debug.WriteLine("Position Status: {0}", position.Timestamp);
                Debug.WriteLine("Position Latitude: {0}", position.Latitude);
                Debug.WriteLine("Position Longitude: {0}", position.Longitude);
                using (HttpClient client = new HttpClient())
                {
                    var url =string.Format("http://192.168.0.7/ShareAnything.API/api/SharePost/GetPostTransport?longitude={0}&latitude={1}", 138.6802453, -34.81003);
                    var result = await
                        client
                        .GetStringAsync(url);
                    var pp = result.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }



            //Device.OnPlatform(iOS: IosAction, Android: AndroidAction, WinPhone: WindoeAction);
            //Device.OnPlatform(iOS: () => { });
        }

        /// <summary>
        /// Called when [clicked_btn register].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnRegister(object sender, EventArgs events)
        {
            var register = new NavigationPage(new Register());
            await Navigation.PushModalAsync(register);
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            if (vm.IsUserLoggedIn)
                NavigateUser(this);
        }


    }
}
