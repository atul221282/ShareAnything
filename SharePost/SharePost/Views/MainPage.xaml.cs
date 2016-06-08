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
        /// Called when [clicked_btn posts].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnPosts(object sender, EventArgs events)
        {
            await Navigation.PushAsync(new PostList(), true);
        }

    }
}
