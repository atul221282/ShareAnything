using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ShareAnything
{
    [Activity(Label = "ShareAnything", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15),
                BaseAddress = new Uri("http://192.168.0.8/ShareAnything.API/api/")


            };

            button.Click += (o, e) =>
            {
                try
                {
                    var result = client.GetStringAsync(@"sharepost/GetPostTransport?latitude=-34.810755792578&longitude=138.681245423409").Result;
                    button.Text = $"{count++} clicks";
                }
                catch (Exception ex)
                {
                    button.Text = ex.InnerException.Message;
                }
            };
        }

    }
}

