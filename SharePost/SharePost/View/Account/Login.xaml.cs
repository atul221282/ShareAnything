using SharePost.Helpers;
using SharePost.View.Post;
using SharePost.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //make http call
            await DisplayAlert("Clicked",
                string.Format("Email Address is : {0} and Password is :{1}", enEmail.Text, enPassword.Text),
                "OK");
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
