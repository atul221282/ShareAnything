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
            boxViewColor.Color = Device.OnPlatform(Color.Blue, Color.Green, Color.Red);
        }
    }
}
