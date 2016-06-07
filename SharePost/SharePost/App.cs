using SharePost.Base;
using SharePost.Factory;
using SharePost.Views;
using SharePost.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SharePost
{
    public class App : Application
    {
        public App()
        {
            ////if user is logged in then redirect to post screen
            //if (Device.Idiom == TargetIdiom.Phone)
            //{
            //    // The root page of your application
            MainPage = new  Login();
                //new NavigationPage(RenderViewFactory.GetPage<ContentPage>());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new MainPage());
            //}

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
