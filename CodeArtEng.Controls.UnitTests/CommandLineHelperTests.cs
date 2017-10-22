using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeArtEng.Controls.UnitTests
{
    [TestFixture]
    class CommandLineHelperTests
    {
        private CommandLineHelper cmdLine;


        [SetUp]
        public void Setup()
        {
            cmdLine = new CommandLineHelper("");
            cmdLine.AddArgument("Source", "Source Path");
            cmdLine.AddSwitch("/AD", "Option AD");
            cmdLine.AddSwitch("/MIN", "Set To Min");
            cmdLine.AddSwitch("/Delay", "delay time in ms", "time");
        }

        [Test]
        public void SetDescription_Constructor()
        {
            string desc = DateTime.Now.ToString();
            CommandLineHelper cmdLine2 = new CommandLineHelper(desc);
            Assert.AreEqual(desc, cmdLine2.Description);
        }

        [Test]
        public void SetDescription_Property()
        {
            string desc = DateTime.Now.ToString();
            cmdLine.Description = desc;
            Assert.AreEqual(desc, cmdLine.Description);
        }

        [Test]
        public void AddArgument()
        {
            string argName = "Arg1";
            cmdLine.AddArgument(argName, "Argument 1");
        }

        [Test, ExpectedException(typeof (Exception))]
        public void AddArgument_Duplicate_Exception()
        {
            string argName = "Arg1";
            cmdLine.AddArgument(argName, "Argument 1");
            cmdLine.AddArgument(argName, "Argument 1");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void AddSwitches_Duplicate_Exception()
        {
            string argName = "/S";
            cmdLine.AddSwitch(argName, "Switches 1");
            cmdLine.AddSwitch(argName, "Switches 1");
        }


        [Test]
        public void IsSwitchSet_InvalidSwitch()
        {
            Assert.AreEqual(false, cmdLine.IsSwitchSet("/NotExist"));
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void GetArgumentValue_Invalid()
        {
            cmdLine.GetArgumentValue("Unknown");
        }

        [Test]
        public void ParseCommandLine()
        {
            cmdLine.ParseCommandLine(("SourcePath /AD").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.IsTrue(cmdLine.IsSwitchSet("/AD"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/min"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/Delay"));
            Assert.AreEqual("NoDelay", cmdLine.GetSwitchValue("/delay", "NoDelay"));
        }

        [Test]
        public void ParseCommandLine_SwitchNotSet()
        {
            cmdLine.ParseCommandLine(("SourcePath").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/AD"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/MIN"));
        }

        [Test]
        public void ParseCommandLine_SetInvalidSwitch()
        {
            cmdLine.ParseCommandLine(("SourcePath /ADS").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/AD"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/MIN"));
        }

        [Test, ExpectedException(typeof(Exception))]
        public void ParseCommandLine_MissingMandatoryArg_Exception()
        {
            cmdLine.ParseCommandLine(("/AD /MIN").Split(' '));
        }

        [Test]
        public void ParseCommandLine_SetSwitchWithValue()
        {
            cmdLine.ParseCommandLine(("SourcePath /delay:100").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.AreEqual("100", cmdLine.GetSwitchValue("/Delay", "-1"));
        }

        [Test]
        public void ParseCommandLine_SetSwitchWithoutValue()
        {
            cmdLine.ParseCommandLine(("SourcePath /delay").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.AreEqual("-1", cmdLine.GetSwitchValue("/Delay", "-1"));
        }

        [Test]
        public void ParseCommandLine_SetValueToBooleanSwitch()
        {
            cmdLine.ParseCommandLine(("SourcePath /min:100").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.AreEqual("NotValid", cmdLine.GetSwitchValue("/min", "NotValid"));
        }

        [Test]
        public void ParseCommandLine_NoMandatoryArgument()
        {
            cmdLine = new CommandLineHelper("Testing");
            cmdLine.ParseCommandLine(("/A /BC").Split(' '));
        }

        [Test]
        public void ParseCommandLine_TooMuchArguments()
        {
            cmdLine.ParseCommandLine(("SourcePath DestPath /X /delay:5555 /XY /TEST").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.AreEqual("5555", cmdLine.GetSwitchValue("/Delay", "-1"));
        }

    }
}
