using NUnit.Framework;
using System.Drawing;

namespace CodeArtEng.Controls.UnitTests
{
    [TestFixture]
    public class MiscTests
    {
        [Test]
        public void WindowSTheme_IsDarkTheme()
        {
                        Assert.That(WindowsTheme.SystemUsesLightTheme(),Is.EqualTo(false));
        }

        [Test]
        public void WindowsTheme_TransparecnyEnabled()
        {
                        Assert.That(WindowsTheme.TransparencyEnabled(),Is.EqualTo(false)); 
        }

        [Test]
        public void WindowsTheme_AccentColour()
        {
            Color color = Color.FromArgb(0, 120, 212);
                        Assert.That(WindowsTheme.AccentColour(),Is.EqualTo(color));
        }

        [Test]
        public void ApplicationTheme_Light()
        {
                        Assert.That(new ApplicationTheme() { Mode = ApplicationThemeMode.Light }.IsLightTheme(),Is.EqualTo(true));
        }

        [Test]
        public void ApplicationTheme_Dark()
        {
                        Assert.That(new ApplicationTheme() { Mode = ApplicationThemeMode.Dark }.IsLightTheme(),Is.EqualTo(false));
        }

        [Test]
        public void ApplicationTheme_SystemDefinedDark()
        {
                        Assert.That(new ApplicationTheme() { Mode = ApplicationThemeMode.SystemDefined }.IsLightTheme(),Is.EqualTo(false));
        }

    }
}
