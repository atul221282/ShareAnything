using SharePost.Helpers;
using SharePost.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {

        private List<Post> _posts;


        public MainPageViewModel()
        {
            this.Posts = new List<Post>();
            var posts = CreatePopsts();
            this.Posts = posts;
            if (string.IsNullOrEmpty(Settings.GeneralSettings))
                this.Name = "Atul";
            else
            {
                var sdsds = Name;
            }

        }
        public string Name
        {
            get
            {
                return Settings.GeneralSettings;
            }
            set
            {
                if (Settings.GeneralSettings == value)
                    return;
                Settings.GeneralSettings = value;
                OnPropertyChanged();
            }
        }


        public List<Post> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                if (_posts != null)
                    OnPropertyChanged();
            }
        }


        private static List<Post> CreatePopsts()
        {
            var posts = new List<Post>();
            for (int i = 0; i < 100; i++)
            {
                posts.Add(new Post { Name = Guid.NewGuid().ToString() });
            }
            return posts;
        }

    }
}
