using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Helpers
{
    public class ShareAnythingConstants
    {
        public const string host = "http://192.168.0.10/";
        //public const string host = "http://172.17.69.125/";
        public const string ExpenseTrackerAPI = host + "ShareAnything.API/";

        public const string ExpenseTrackerClientBaseUrl = host + "ShareAnything/";
        public const string ShareAnythingHomeUrl = "/ShareAnything";
        public const string ExpenseTrackerClient = host + "ShareAnything/Post/Index";
        public const string ExpenseTrackerClientLogoutUri = host + "ShareAnything/";

        //public const string ExpenseTrackerMobile = "ms-app://s-1-15-2-467734538-4209884262-1311024127-1211083007-3894294004-443087774-3929518054/";
        public const string ExpenseTrackerMobile = "app://webview/";

        public const string IdSrvIssuerBaseUri = host + "ShareAnything.IdSrv/";
        public const string IdSrvIssuerUri = "http://expensetrackeridsrv/embedded";

        public const string IdSrv = host + "ShareAnything.IdSrv/identity";
        public const string IdSrvToken = IdSrv + "/connect/token";
        public const string IdSrvAuthorize = IdSrv + "/connect/authorize";
        public const string IdSrvUserInfo = IdSrv + "/connect/userinfo";

        public const string resourceOwnerCredFlowClientId = "nativeclient";
        public const string resourceOwnerCredFlowSecret = "secret";
    }
}
