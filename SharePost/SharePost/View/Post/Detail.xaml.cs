using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SharePost.View.Post
{
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
        }
        public Detail(string name)
        {
            var pp = name;
            InitializeComponent();
        }
    }
}
