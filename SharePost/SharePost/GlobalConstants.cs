using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost
{
    /// <summary>
    /// 
    /// </summary>
    public static class GlobalConstants
    {
        public const string resourceOwnerCredFlowClientId = "nativeclient";
        public const string resourceOwnerCredFlowSecret = "secret";
    }

    public static class SettingConstants
    {
        #region Setting Constants

        public const string SettingsKey = "settings_key";
        public static readonly string SettingsDefault = string.Empty;

        public const string skUserDetailsKey = "skUserDetailsKey";
        public static readonly string skUserDetailsDefault = string.Empty;

        public const string skRefreshToken = "skRefreshToken";
        public static readonly string skRefreshTokenDefault = string.Empty;

        public const string skAccessToken = "skAccessToken";
        public static readonly string skAccessTokenDefault = string.Empty;

        public const string skTokenExpiresAt = "skTokenExpiresAt";
        public static readonly DateTimeOffset? skTokenExpiresAtDefault = null;

        public static readonly string skTokenResponseDefault = string.Empty;
        public const string skTokenResponse = "skTokenResponse";
        
        public const string skExpiresAt= "skExpiresAt";
        internal static readonly DateTimeOffset? skExpiresAtDefault = null;



        #endregion
    }
}
