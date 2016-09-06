using SharePost.Contracts;
using SharePost.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Ioc;

namespace SharePost.View.Account
{
    public partial class Register : ContentPage
    {
        private RegisterViewModel ViewModel;
        private IGeoLocation Location;
        public Register(IGeoLocation location)
        {
            Location = location;
            var loc = Location.GetLocation();
            ViewModel = new RegisterViewModel();
            InitializeComponent();
            BindingContext = ViewModel;
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior 
        /// immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {

            base.OnAppearing();
            //NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasNavigationBar(this,
                Device.OnPlatform<bool>(true, false, true));
        }

        /// <summary>
        /// Handles the Clicked event of the btnHome control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnHome_Clicked(object sender, EventArgs events)
            => App.Current.MainPage = new NavigationPage(new Login());
    }
}
