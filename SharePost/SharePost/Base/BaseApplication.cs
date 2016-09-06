using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharePost.Base
{
    public class BaseApplication : Application
    {
        public bool DoBack
        {
            get
            {
                var mainPage = MainPage as NavigationPage;
                if (mainPage != null)
                {
                    return mainPage.Navigation.NavigationStack.Count > 1;
                }
                return true;
            }
        }

    }
}
