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

        private List<PostModel> _posts;


        public MainPageViewModel()
        {
            this.Posts = new List<PostModel>();
            var posts = CreatePopsts();
            this.Posts = posts;
            

        }


        public List<PostModel> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                if (_posts != null)
                    OnPropertyChanged();
            }
        }


        private static List<PostModel> CreatePopsts()
        {
            var posts = new List<PostModel>();
            for (int i = 0; i < 100; i++)
            {
                posts.Add(new PostModel { Name = Guid.NewGuid().ToString() });
            }
            return posts;
        }

    }
}
