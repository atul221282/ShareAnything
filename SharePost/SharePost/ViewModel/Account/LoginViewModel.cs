using SharePost.Helpers;
using SharePost.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.ViewModel.Account
{
    public class LoginViewModel : BaseViewModel
    {
        private User _user;

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is user logged in.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is user logged in; otherwise, <c>false</c>.
        /// </value>
        public bool IsUserLoggedIn
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Settings.RefreskToken) && !string.IsNullOrWhiteSpace(Settings.UserDetails);
            }
           
        }


    }
}
