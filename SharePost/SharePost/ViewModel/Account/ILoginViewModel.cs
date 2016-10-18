using Plugin.Geolocator.Abstractions;
using System.Threading.Tasks;

namespace SharePost.ViewModel.Account
{
    public interface ILoginViewModel
    {
        Position Position { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsNotLoading { get; set; }
        Task Login();
    }
}