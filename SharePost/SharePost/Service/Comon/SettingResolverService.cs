using SharePost.ServiceContract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharePost.Service.Comon
{
    public class SettingResolverService : ISettingResolverService
    {
        public bool IsAndroid => Device.OS == TargetPlatform.Android;

        public bool IsDesktop => Device.Idiom == TargetIdiom.Desktop
            && Device.Idiom != TargetIdiom.Unsupported;

        public bool IsIOS => Device.OS == TargetPlatform.iOS;

        public bool IsOtherPhone => Device.OS == TargetPlatform.Other;

        public bool IsPhone => Device.Idiom == TargetIdiom.Phone
            && Device.Idiom != TargetIdiom.Unsupported;

        public bool IsTablet => Device.Idiom == TargetIdiom.Tablet
            && Device.Idiom != TargetIdiom.Unsupported;

        public bool IsWindows => Device.OS == TargetPlatform.Windows;

        public bool IsWindowsPhone => Device.OS == TargetPlatform.WinPhone;
    }
}
