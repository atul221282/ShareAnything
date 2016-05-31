using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SharePost.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            enEmail.Focus();
        }

        /// <summary>
        /// Called when [clicked_btn login].
        /// </summary>
        /// <param name="sedner">The sedner.</param>
        /// <param name="events">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnClicked_btnLogin(object sedner, EventArgs events)
        {
            //make http call
        }
    }
}
