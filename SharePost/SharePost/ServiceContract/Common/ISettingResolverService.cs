using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.ServiceContract.Common
{
    public interface ISettingResolverService
    {
        bool IsTablet { get; }

        bool IsPhone { get; }

        bool IsDesktop { get; }

        bool IsWindows { get; }

        bool IsIOS { get; }

        bool IsAndroid { get; }

        bool IsWindowsPhone { get; }

        bool IsOtherPhone { get; }
    }
}
