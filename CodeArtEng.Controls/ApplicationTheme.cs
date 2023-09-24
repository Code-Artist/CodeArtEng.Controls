using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArtEng.Controls
{
    public enum ApplicationThemeMode
    {
        SystemDefined,
        Light,
        Dark
    }

    /// <summary>
    /// Define theme for application
    /// </summary>
    public class ApplicationTheme
    {
        public ApplicationThemeMode Mode { get; set; } = ApplicationThemeMode.SystemDefined;

        public bool IsLightTheme()
        {
            switch (Mode)
            {
                case ApplicationThemeMode.Light:
                    return true;
                case ApplicationThemeMode.Dark:
                    return false;

                default:
                case ApplicationThemeMode.SystemDefined:
                    return WindowsTheme.SystemUsesLightTheme();
            }
        }
    }
}
