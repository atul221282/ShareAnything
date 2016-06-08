using SharePost.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SharePost.ViewModel.BaseViewModel" />
    public class MainPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private List<Post> _posts;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
            CreatePosts(this.Posts);
        }



        public List<Post> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Posts"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CreatePosts(List<Post> posts)
        {
            if (posts == null)
                posts = new List<Post>();

            posts.Add(new Post { Title = "Atul" });
        }
    }
}
