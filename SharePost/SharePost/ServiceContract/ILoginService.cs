using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.ServiceContract
{
    public interface ILoginService
    {
        Task LoginAsync(string userName, string password);
    }
}
