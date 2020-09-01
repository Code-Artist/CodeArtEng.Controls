using NUnit.Framework;
using System;

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
        public void GetArgumentsName()
        {
            Assert.AreEqual(new string[] { "Source" }, cmdLine.GetArgumentsName());
        }

        [Test]
        public void GetSwitchesName()
        {
            Assert.AreEqual(new string[] { "/AD", "/MIN", "/DELAY" }, cmdLine.GetSwitchesName());
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

        [Test]
        public void AddArgument_Duplicate_Exception()
        {
            string argName = "Arg1";
            cmdLine.AddArgument(argName, "Argument 1");
            Assert.Throws<Exception>(() => { cmdLine.AddArgument(argName, "Argument 1"); });
        }

        [Test]
        public void AddSwitches_Duplicate_Exception()
        {
            string argName = "/S";
            cmdLine.AddSwitch(argName, "Switches 1");
            Assert.Throws<ArgumentException>(() => { cmdLine.AddSwitch(argName, "Switches 1"); });
        }


        [Test]
        public void IsSwitchSet_InvalidSwitch()
        {
            Assert.AreEqual(false, cmdLine.IsSwitchSet("/NotExist"));
        }

        [Test]
        public void GetArgumentValue_Invalid()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                cmdLine.GetArgumentValue("Unknown");
            });
        }

        [Test]
        public void SetArgument()
        {
            cmdLine.SetArgument("Source", "C:\\Temp");
            Assert.AreEqual("C:\\Temp", cmdLine.GetArgumentValue("Source"));
        }

        [Test]
        public void SetSwitch()
        {
            cmdLine.SetSwitch("/MIN");
            Assert.IsTrue(cmdLine.IsSwitchSet("/MIN"));
        }

        [Test]
        public void SetSwitchValue()
        {
            cmdLine.SetSwitch("/DELAY", "200");
            Assert.IsTrue(cmdLine.IsSwitchSet("/DeLaY"));
            Assert.AreEqual("200", cmdLine.GetSwitchValue("/Delay"));
        }

        [Test]
        public void SetArgument_InvalidArgument()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                cmdLine.SetArgument("DUMMY", "TEST");
            });
        }

        [Test]
        public void SetSwitch_InvalidSwitch()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                cmdLine.SetSwitch("/NOTEXIST");
            });
        }


        [Test]
        public void ParseCommandLine()
        {
            bool status = cmdLine.ParseCommandLine(("SourcePath /AD").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.IsTrue(cmdLine.IsSwitchSet("/AD"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/min"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/Delay"));
            Assert.AreEqual("NoDelay", cmdLine.GetSwitchValue("/delay", "NoDelay"));
            Assert.IsTrue(status);
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

        [Test]
        public void ParseCommandLine_MissingMandatoryArg_Exception()
        {
            Assert.Throws<Exception>(() =>
            {
                cmdLine.ParseCommandLine(("/AD /MIN").Split(' '));
            });
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
            Assert.IsTrue(cmdLine.ParseCommandLine(("/A /BC").Split(' ')));
        }

        [Test]
        public void ParseCommandLine_TooMuchArguments()
        {
            cmdLine.ParseCommandLine(("SourcePath DestPath /X /delay:5555 /XY /TEST").Split(' '));
            Assert.AreEqual("SourcePath", cmdLine.GetArgumentValue("Source"));
            Assert.AreEqual("5555", cmdLine.GetSwitchValue("/Delay", "-1"));
        }

        [Test]
        public void ParseCommandLine_EmptyCommand()
        {
            Assert.IsFalse(cmdLine.ParseCommandLine(new string[] { }));
        }

        [Test]
        public void ParseCommandLine_EnvArgs()
        {
            //NUnit Command Line is not empty by default
            Assert.IsTrue(cmdLine.ParseCommandLine());
        }

        [Test]
        public void Reset()
        {
            cmdLine.SetArgument("Source", "Test Value");
            cmdLine.SetSwitch("/MIN");

            Assert.AreEqual("Test Value", cmdLine.GetArgumentValue("Source"));
            Assert.IsTrue(cmdLine.IsSwitchSet("/MIN"));

            cmdLine.Reset();

            Assert.IsEmpty(cmdLine.GetArgumentValue("Source"));
            Assert.IsFalse(cmdLine.IsSwitchSet("/MIN"));
        }

        [Test]
        public void SetSwitchValueWithColumn()
        {
            CommandLineHelper cmd = new CommandLineHelper("File");
            cmd.AddSwitch("/log", "Log File.", "logFile");
            cmd.SetSwitch("/log", "C:\\Temp\\Output.txt");

            Assert.AreEqual("C:\\Temp\\Output.txt", cmd.GetSwitchValue("/log"));
        }

        [Test]
        public void ParseCommandLineFileName()
        {
            CommandLineHelper cmd = new CommandLineHelper("File");
            cmd.AddSwitch("/log", "Log File.", "logFile");
            cmd.ParseCommandLine(("/log:C:\\Temp\\Output.txt").Split(' '));
            Assert.AreEqual("C:\\Temp\\Output.txt", cmd.GetSwitchValue("/log"));
        }

    }
}
