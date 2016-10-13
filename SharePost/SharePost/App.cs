using SharePost.Base;
using SharePost.Contracts;
using SharePost.Service;
using SharePost.ServiceContract;
using SharePost.View;
using SharePost.View.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XLabs.Ioc;

namespace SharePost
{
    public class App : BaseApplication
    {
        public App()
        {
            //https://www.nuget.org/packages?q=xlabs.ioc
            //https://github.com/XLabs/Xamarin-Forms-Labs/wiki/IOC
            var container = new SimpleContainer();
            container.Register<IGeoLocation>(typeof(GeoLocation));

            container.Register<ILoginService>(typeof(LoginService));

            Resolver.SetResolver(container.GetResolver());
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
