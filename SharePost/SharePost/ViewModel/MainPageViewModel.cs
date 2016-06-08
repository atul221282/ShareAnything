using SharePost.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.ViewModel
{
    public class MainPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Post> _posts;


        public MainPageViewModel()
        {
            this.Posts = new List<Post>();
            var posts = CreatePopsts();
            this.Posts = posts;
        }


        public List<Post> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                if (_posts != null)
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Posts"));
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
