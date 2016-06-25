using Newtonsoft.Json;
using SharePost.Model;
using SharePost.View.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharePost.Helpers
{
    public static class CommonHelper
    {
        public static UserModel GetUserDetails()
        {
            if (string.IsNullOrWhiteSpace(Settings.UserDetails))
                return null;
            return JsonConvert.DeserializeObject<UserModel>(Settings.UserDetails);
        }

       

        public static void SetNavigationPage(Page page)
        {
            App.Current.MainPage = new NavigationPage(page);
        }

        public static void SetLoginPage()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new Login()));
        }
    }
}
