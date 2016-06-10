using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharePost.ViewModel.Account
{
    public class RegisterViewModel : BaseViewModel
    {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is tablet.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is tablet; otherwise, <c>false</c>.
        /// </value>
        public bool IsTablet
        {
            get
            {
                if (Device.Idiom != TargetIdiom.Phone)
                    return true;
                else
                    return false;
            }

        }

    }
}
