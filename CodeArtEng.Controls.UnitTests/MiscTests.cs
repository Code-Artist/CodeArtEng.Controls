using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Assert.AreEqual(false, WindowsTheme.SystemUsesLightTheme());
        }

        [Test]
        public void WindowsTheme_TransparecnyEnabled()
        {
            Assert.AreEqual(false, WindowsTheme.TransparencyEnabled()); 
        }

        [Test]
        public void WindowsTheme_AccentColour()
        {
            Color color = Color.FromArgb(0, 120, 212);
            Assert.AreEqual(color, WindowsTheme.AccentColour());
        }

        [Test]
        public void ApplicationTheme_Light()
        {
            Assert.AreEqual(true, new ApplicationTheme() { Mode = ApplicationThemeMode.Light }.IsLightTheme());
        }

        [Test]
        public void ApplicationTheme_Dark()
        {
            Assert.AreEqual(false, new ApplicationTheme() { Mode = ApplicationThemeMode.Dark }.IsLightTheme());
        }

        [Test]
        public void ApplicationTheme_SystemDefinedDark()
        {
            Assert.AreEqual(false, new ApplicationTheme() { Mode = ApplicationThemeMode.SystemDefined }.IsLightTheme());
        }

    }
}
