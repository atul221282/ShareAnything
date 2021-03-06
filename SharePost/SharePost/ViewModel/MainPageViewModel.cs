﻿using SharePost.Helpers;
using SharePost.Model;
using SharePost.Model.Post;
using SharePost.View.Account;
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
        private string _postText;

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

        public string PostText
        {
            get { return _postText; }
            set
            {
                _postText = value; OnPropertyChanged();
            }
        }


        async public Task<string> GetPosts(double longitude, double latitude)
        {
            using (HttpClient client = SharePostClient.GetClient(true))
            {
                var result = client.GetAsync(string.Format("api/sharepost/GetPostTransport?longitude={0}&latitude={1}", longitude, latitude)).Result;
                var mm = await HandleApiResponse<HttpResponseMessage>(result);
                return "";
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
