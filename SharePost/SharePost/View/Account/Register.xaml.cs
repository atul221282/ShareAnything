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
        public Register()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return Device.OnPlatform<bool>(false, false, false);
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
    }
}
