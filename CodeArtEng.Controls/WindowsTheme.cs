using System;
using System.Drawing;
using Microsoft.Win32;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Windows Theme Settings.
    /// </summary>
    public static class WindowsTheme
    {
        /// <summary>
        /// Return system theme settings. true = light, false = dark.
        /// </summary>
        /// <returns></returns>
        public static bool SystemUsesLightTheme()
        {
            using (RegistryKey key = OpenThemePersonalizeKey())
                return Convert.ToBoolean(key.GetValue("AppUseLightTheme"));
        }

        /// <summary>
        /// Return true if system transparency is enabled.
        /// </summary>
        /// <returns></returns>
        public static bool TransparencyEnabled()
        {
            using (RegistryKey key = OpenThemePersonalizeKey())
                return Convert.ToBoolean(key.GetValue("EnableTransparency"));
        }

        /// <summary>
        /// Return current selected Accent Color.
        /// </summary>
        /// <returns></returns>
        public static Color AccentColour()
        {
            using (RegistryKey key = RegistryHelper.OpenRegistryKey(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\History\Colors"))
            {
                int colorRegValue = (int)key.GetValue("ColorHistory0");
                int red = colorRegValue & 0xFF;
                colorRegValue >>= 8;
                int green = colorRegValue & 0xFF;   
                colorRegValue >>= 8;
                int blue = colorRegValue & 0xFF;    
                return Color.FromArgb(red, green, blue);
            }
        }

        private static RegistryKey OpenThemePersonalizeKey()
        {
            return RegistryHelper.OpenRegistryKey(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
        }
    }
}
