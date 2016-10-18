using Ninject.Modules;
using SharePost.Contracts;
using SharePost.Helpers;
using SharePost.Service;
using SharePost.Service.Comon;
using SharePost.ServiceContract;
using SharePost.ServiceContract.Common;
using SharePost.ViewModel.Account;
using System;
using XLabs.Ioc;
using Ninject;

namespace SharePost.Infrastructure
{
    public class Config : NinjectModule
    {
        

        public override void Load()
        {
            Bind<ILoginService>().To<LoginService>();
            Bind<ILoginViewModel>().To<LoginViewModel>();
        }
    }
}
