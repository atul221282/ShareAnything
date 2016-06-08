﻿using SharePost.Base;
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
    public class App : BaseApplication
    {
        public App()
        {
            MainPage = new Login();
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
