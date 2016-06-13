using Newtonsoft.Json.Linq;
using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using SharePost.Helpers;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharePost.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

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
                return !string.IsNullOrWhiteSpace(Settings.RefreskToken)
                    && !string.IsNullOrWhiteSpace(Settings.UserDetails)
                    && !string.IsNullOrWhiteSpace(Settings.AccessToken);
            }

        }

        public bool HasTokenExpred
        {
            get
            {
                return DateTimeOffset.Now > Settings.TokenExpiresAt || !Settings.TokenExpiresAt.HasValue;
            }
        }

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

        /// <summary>
        /// Sets the main page.
        /// </summary>
        /// <param name="page">The page.</param>
        public virtual void SetMainPage(Page page)
        {
            App.Current.MainPage = new NavigationPage(page);
        }


        #region "OnProperty"
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;



        #region INotifyPropertyChanged implementation      

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="name">The name.</param>
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));
        }

        #endregion
        #endregion

    }
}