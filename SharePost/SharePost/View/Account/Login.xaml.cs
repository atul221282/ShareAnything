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
using SharePost.Extension;
using Xamarin.Forms;
using Plugin.DeviceInfo;

namespace SharePost.View.Account
{
    public partial class Login
    {
        LoginViewModel vm;
        public Login()
        {
            vm = new LoginViewModel();
            vm.UserName = "atul221282@gmail.com";
            vm.Password = "123456";
            InitializeComponent();
            BindingContext = vm;

            //Settings.AccessToken = "";
            //Settings.RefreskToken = "";
            //Settings.UserDetails = "";
            //Settings.TokenExpiresAt = null;

        }

        /// <summary>
        /// Navigates the user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <exception cref="System.NotImplementedException"></exception>


        /// <summary>
        /// Called when [clicked_btn login].
        /// </summary>
        /// <param name="sender">The sedner.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnLogin(object sender, EventArgs events)
        {
            try
            {
                var pp = CrossDeviceInfo.Current;
                //var locator = CrossGeolocator.Current;
                //locator.DesiredAccuracy = 50;
                //var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                //Debug.WriteLine("Position Status: {0}", position.Timestamp);
                //Debug.WriteLine("Position Latitude: {0}", position.Latitude);
                //Debug.WriteLine("Position Longitude: {0}", position.Longitude);
                vm.Login();
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
            //Check token expiry time also
            if (vm.IsUserLoggedIn && !CommonHelper.HasTokenExpired())
                CommonHelper.SetMainPage(new MainPage());
        }


    }
}
