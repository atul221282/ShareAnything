using SharePost.Views.Account;
using SharePost.Views.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SharePost.Views
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetPage();

        }
        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// Use it when user closing application but check form to make sure that form is dirty 
        /// </summary>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override bool OnBackButtonPressed()
        {
            if (Device.OS == TargetPlatform.Android)
            {
                return !(Navigation.NavigationStack.Count > 1);
            }
            return base.OnBackButtonPressed();
        }

        /// <summary>
        /// Sets the page.
        /// </summary>
        async public void SetPage()
        {
            var stack = Navigation.NavigationStack;
        }

        async protected void OnAppearing_cpMain(object sender, EventArgs events)
        {

        }

    }
}
