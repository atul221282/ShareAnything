using SharePost.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Ioc;

namespace SharePost.Infrastructure
{
    public class ConfigViewModel
    {
        private readonly SimpleContainer container;

        public ConfigViewModel(SimpleContainer container)
        {
            this.container = container;
            SetUpDependency();
        }

        private void SetUpDependency()
        {
            container.Register<ILoginViewModel>(typeof(LoginViewModel));
        }
    }
}
