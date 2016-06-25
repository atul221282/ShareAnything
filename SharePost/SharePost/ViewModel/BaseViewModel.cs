using Newtonsoft.Json.Linq;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SharePost.Helpers;
using SharePost.Model;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Newtonsoft.Json;

namespace SharePost.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        private bool _isLoading = false;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has location found.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has location found; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading == value)
                    return;
                _isLoading = value;
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
                TokenModelResponse model = EndpointAndTokenHelper.GetTokenResponse();
                return !string.IsNullOrWhiteSpace(model?.RefreshToken)
                    && !string.IsNullOrWhiteSpace(model?.AccessToken);
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

        async public virtual Task<Position> GetLocation()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            return position;
        }


        async public virtual Task<T> HandleApiResponse<T>(HttpResponseMessage response) where T : class
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = JObject.Parse(await response.Content.ReadAsStringAsync());
                var errorMessages = content["ExceptionMessage"] != null ? content["ExceptionMessage"].ToString().Split('|').ToArray() : null;
                //request.CreateResponse<string[]>(HttpStatusCode.InternalServerError, errorMessages, new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
                if (errorMessages != null)
                {
                    foreach (string error in errorMessages)
                    {
                        int i = 0;
                        //ModelState.AddModelError(string.Empty, error);
                        i++;
                    }
                }
                throw new HttpRequestException(string.Join(",", errorMessages));
            }
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public virtual void ClearAllSettings()
        {
            Settings.ExpiresAt = DateTime.MinValue;
            Settings.TokenResponse = string.Empty;
            Settings.UserDetails = string.Empty;
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