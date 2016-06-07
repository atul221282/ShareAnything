using SharePost.Views.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SharePost.Views.Account
{
    public partial class Login
    {

        public Login()
        {
            InitializeComponent();

            //NavigateUser(this);
        }

        /// <summary>
        /// Navigates the user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        async private void NavigateUser(Login login)
        {
            if (Device.OS == TargetPlatform.Android)
                Application.Current.MainPage = new NavigationPage(new MainPage());
            else
            {
                await Navigation.PushAsync(new NavigationPage(new MainPage()));
                Navigation.RemovePage(this);
            }
            //
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
        ///
        /// <summary>
        /// Called when [clicked_btn register].
        /// </summary>
        /// <param name="sender">The sedner.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnRegister(object sender, EventArgs events)
        {
            await Navigation.PushAsync(new Register(), true);
        }

        /// <summary>
        /// Called when [clicked_btn posts].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnPosts(object sender, EventArgs events)
        {
            await Navigation.PushAsync(new List(), true);
        }

        protected override void OnAppearing()
        {
            NavigateUser(this);
        }
    }
}
