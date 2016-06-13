// Helpers/Settings.cs
using System;
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
                return AppSettings.GetValueOrDefault<string>(SettingConstants.skUserDetailsKey, SettingConstants.skUserDetailsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingConstants.skUserDetailsKey, value);
            }
        }

        /// <summary>
        /// Gets or sets the token response.
        /// </summary>
        /// <value>
        /// The token response.
        /// </value>
        public static string TokenResponse
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingConstants.skTokenResponse, 
                    SettingConstants.skTokenResponseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingConstants.skTokenResponse, value);
            }
        }

        /// <summary>
        /// Gets or sets the token response.
        /// </summary>
        /// <value>
        /// The token response.
        /// </value>
        public static DateTime? ExpiresAt
        {
            get
            {
                return AppSettings.GetValueOrDefault<DateTime?>(SettingConstants.skExpiresAt, 
                    SettingConstants.skExpiresAtDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<DateTime?>(SettingConstants.skExpiresAt, value);
            }
        }

    }
}