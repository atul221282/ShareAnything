using SharePost.View;
using SharePost.View.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharePost.Factory
{
    public static class RenderViewFactory
    {
        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetPage<T>() where T : class
        {
            return new Login() as T;
        }
    }
}
