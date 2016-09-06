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
using SharePost.Contracts;
using XLabs.Ioc;
using SharePost.ServiceContract;

namespace SharePost.View.Account
{
    public partial class Login
    {
        private LoginViewModel ViewModel;
        private static string UserName = "atul221282@gmail.com";
        private static string Password = "123456";
        public Login()
        {
            ViewModel = new LoginViewModel(Resolver.Resolve<ILoginService>());
            SetCredentials();
            InitializeComponent();
            BindingContext = ViewModel;
            //vm.ClearAllSettings();
        }

        private void SetCredentials()
        {
            ViewModel.UserName = UserName;
            ViewModel.Password = Password;
        }


        /// <summary>
        /// Called when [clicked_btn login].
        /// </summary>
        /// <param name="sender">The sedner.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnLoginAsync(object sender, EventArgs events)
        {
            try
            {
                await ViewModel.Login();
                var position = await ViewModel.GetLocation();
                CommonHelper.SetNavigationPage(new MainPage(position));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
        }

        protected void OnClicked_btnClear(object sender, EventArgs events) => ViewModel.ClearAllSettings();

        /// <summary>
        /// Called when [clicked_btn register].
        /// </summary>
        /// <param name="sender">The sender from event</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnRegisterAsync(object sender, EventArgs events)
        {
            var isregi = Resolver.IsRegistered<IGeoLocation>();
            var register = new NavigationPage(new Register(Resolver.Resolve<IGeoLocation>()));
            await Navigation.PushModalAsync(register);
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        async protected override void OnAppearing()
        {
            //Check token expiry time also
            if (ViewModel.IsUserLoggedIn)
            {
                ViewModel.IsLoading = true;
                var position = await ViewModel.GetLocation();
                ViewModel.IsLoading = false;
                CommonHelper.SetNavigationPage(new MainPage(position));
            }
            else
                ViewModel.ClearAllSettings();
        }

    }
}
