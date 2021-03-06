﻿using SharePost.View.Account;
using SharePost.View.Post;
using SharePost.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Plugin.Geolocator.Abstractions;
using SharePost.Helpers;
using System.Diagnostics;

namespace SharePost.View
{

    public partial class MainPage : ContentPage
    {
        private Position position;
        MainPageViewModel vm;

        public MainPage()
        {
            vm = new MainPageViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        public MainPage(Position position) : this()
        {
            this.position = position;
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
        //protected override bool OnBackButtonPressed()
        //{
        //    if (Device.OS == TargetPlatform.Android)
        //    {
        //        return !(Navigation.NavigationStack.Count > 1);
        //    }
        //    return base.OnBackButtonPressed();
        //}

        /// <summary>
        /// Called when [clicked_btn posts].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void OnClicked_btnPosts(object sender, EventArgs events)
        {
            await Navigation.PushAsync(new PostList(), true);
        }

        /// <summary>
        /// Handles the OnItemTapped event of the postList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void postList_OnItemTapped(object sender, EventArgs events)
        {
            await Navigation.PushAsync(new Detail("asasas"), true);
        }

        /// <summary>
        /// Handles the OnClicked event of the btnGetPost control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        async protected void btnGetPost_OnClicked(object sender, EventArgs events)
        {
            LoadPostsByPosition(position);
        }

        /// <summary>
        /// Loads the posts by position.
        /// </summary>
        /// <param name="position">The position.</param>
        async private void LoadPostsByPosition(Position position)
        {
            vm.IsLoading = true;
            try
            {
                var result = await vm.GetPosts(position.Longitude, position.Latitude);
                vm.PostText = EndpointAndTokenHelper.GetTokenResponse()?.RefreshToken +
                    EndpointAndTokenHelper.GetTokenResponse()?.ExpiresAt.ToString();
            }
            catch (Exception ex)
            {
                vm.IsLoading = false;
                await DisplayAlert("Alert", ex.Message, "Ok");
                vm.ClearAllSettings();
                CommonHelper.SetLoginPage();
            }
        }

        async protected override void OnAppearing()
        {
            LoadPostsByPosition(this.position);
        }

    }
}
