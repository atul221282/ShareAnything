// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SharePost.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        /// <summary>
        /// Gets or sets the general settings.
        /// </summary>
        /// <value>
        /// The general settings.
        /// </value>
        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingConstants.SettingsKey, SettingConstants.SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingConstants.SettingsKey, value);
            }
        }

        /// <summary>
        /// Gets or sets the user details.
        /// Details like UserId and UserName(aka email),
        /// Formatted Name and
        /// User Image.
        /// </summary>
        /// <value>
        /// The user details.
        /// </value>
        public static string UserDetails
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingConstants.skUserDetailsKey,SettingConstants.skUserDetailsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingConstants.skUserDetailsKey, value);
            }
        }

        /// <summary>
        /// Gets or sets the refresk token.
        /// </summary>
        /// <value>
        /// The refresk token.
        /// </value>
        public static string RefreskToken
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingConstants.skRefreshToken, SettingConstants.skRefreshTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingConstants.skRefreshToken, value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingConstants.skAccessToken, SettingConstants.skAccessTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingConstants.skAccessToken, value);
            }
        }
    }
}