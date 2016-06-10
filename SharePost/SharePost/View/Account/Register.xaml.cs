using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SharePost.View.Account
{
    public partial class Register : ContentPage
    {
        private bool isTablet = false;
        public Register()
        {
            if (Device.Idiom != TargetIdiom.Phone)
                isTablet = true;
            InitializeComponent();
            btnHome.IsVisible = isTablet;
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
            NavigationPage.SetHasNavigationBar(this, Device.OnPlatform<bool>(true, false, true));
        }

        /// <summary>
        /// Handles the Clicked event of the btnHome control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void btnHome_Clicked(Object sender, EventArgs events)
        {
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}
