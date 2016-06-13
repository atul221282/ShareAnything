using SharePost.Helpers;
using SharePost.Model;
using SharePost.Model.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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

        async public void GetPosts(double longitude, double latitude)
        {
            using (HttpClient client = SharePostClient.GetClient(true))
            {
                var result = await client.GetStringAsync(string.Format("api/sharepost/GetPostTransport?longitude={0}&latitude={1}", longitude, latitude));
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
