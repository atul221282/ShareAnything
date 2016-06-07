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

        /// <summary>
        /// Gets a value indicating whether [do back].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [do back]; otherwise, <c>false</c>.
        /// </value>
        public bool DoBack
        {
            get
            {
                NavigationPage mainPage = MainPage as NavigationPage;
                if (mainPage != null)
                {
                    return mainPage.Navigation.NavigationStack.Count > 1;
                }
                return true;
            }
        }
    }
}
