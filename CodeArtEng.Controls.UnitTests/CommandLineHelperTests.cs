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
            Assert.That(cmdLine.GetArgumentsName(), Is.EqualTo(new string[] { "Source" }));
        }

        [Test]
        public void GetSwitchesName()
        {
            Assert.That(cmdLine.GetSwitchesName(), Is.EqualTo(new string[] { "/AD", "/MIN", "/DELAY" }));
        }


        [Test]
        public void SetDescription_Constructor()
        {
            string desc = DateTime.Now.ToString();
            CommandLineHelper cmdLine2 = new CommandLineHelper(desc);
            Assert.That(cmdLine2.Description, Is.EqualTo(desc));
        }

        [Test]
        public void SetDescription_Property()
        {
            string desc = DateTime.Now.ToString();
            cmdLine.Description = desc;
            Assert.That(cmdLine.Description, Is.EqualTo(desc));
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
            Assert.That(cmdLine.IsSwitchSet("/NotExist"), Is.EqualTo(false));
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
            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("C:\\Temp"));
        }

        [Test]
        public void SetSwitch()
        {
            cmdLine.SetSwitch("/MIN");
            Assert.That(cmdLine.IsSwitchSet("/MIN"), Is.True);
        }

        [Test]
        public void SetSwitchValue()
        {
            cmdLine.SetSwitch("/DELAY", "200");
            Assert.That(cmdLine.IsSwitchSet("/DeLaY"), Is.True);
            Assert.That(cmdLine.GetSwitchValue("/Delay"), Is.EqualTo("200"));
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
            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("SourcePath"));
            Assert.That(cmdLine.IsSwitchSet("/AD"), Is.True);
            Assert.That(cmdLine.IsSwitchSet("/min"), Is.False);
            Assert.That(cmdLine.IsSwitchSet("/Delay"), Is.False);
            Assert.That(cmdLine.GetSwitchValue("/delay", "NoDelay"), Is.EqualTo("NoDelay"));
            Assert.That(status, Is.True);
        }

        [Test]
        public void ParseCommandLine_SwitchNotSet()
        {
            cmdLine.ParseCommandLine(("SourcePath").Split(' '));
            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("SourcePath"));
            Assert.That(cmdLine.IsSwitchSet("/AD"), Is.False);
            Assert.That(cmdLine.IsSwitchSet("/MIN"), Is.False);
        }

        [Test]
        public void ParseCommandLine_SetInvalidSwitch()
        {
            cmdLine.ParseCommandLine(("SourcePath /ADS").Split(' '));
            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("SourcePath"));
            Assert.That(cmdLine.IsSwitchSet("/AD"), Is.False);
            Assert.That(cmdLine.IsSwitchSet("/MIN"), Is.False);
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
            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("SourcePath"));
            Assert.That(cmdLine.GetSwitchValue("/Delay", "-1"), Is.EqualTo("100"));
        }

        [Test]
        public void ParseCommandLine_SetSwitchWithoutValue()
        {
            cmdLine.ParseCommandLine(("SourcePath /delay").Split(' '));
            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("SourcePath"));
            Assert.That(cmdLine.GetSwitchValue("/Delay", "-1"), Is.EqualTo("-1"));
        }

        [Test]
        public void ParseCommandLine_SetValueToBooleanSwitch()
        {
            cmdLine.ParseCommandLine(("SourcePath /min:100").Split(' '));
            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("SourcePath"));
            Assert.That(cmdLine.GetSwitchValue("/min", "NotValid"), Is.EqualTo("NotValid"));
        }

        [Test]
        public void ParseCommandLine_NoMandatoryArgument()
        {
            cmdLine = new CommandLineHelper("Testing");
            Assert.That(cmdLine.ParseCommandLine(("/A /BC").Split(' ')), Is.True);
        }

        [Test]
        public void ParseCommandLine_TooMuchArguments()
        {
            cmdLine.ParseCommandLine(("SourcePath DestPath /X /delay:5555 /XY /TEST").Split(' '));
            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("SourcePath"));
            Assert.That(cmdLine.GetSwitchValue("/Delay", "-1"), Is.EqualTo("5555"));
        }

        [Test]
        public void ParseCommandLine_EmptyCommand()
        {
            Assert.That(cmdLine.ParseCommandLine(new string[] { }), Is.False);
        }

        [Test]
        public void ParseCommandLine_EnvArgs()
        {
            //NUnit Command Line is not empty by default
            Assert.That(cmdLine.ParseCommandLine(), Is.True);
        }

        [Test]
        public void Reset()
        {
            cmdLine.SetArgument("Source", "Test Value");
            cmdLine.SetSwitch("/MIN");

            Assert.That(cmdLine.GetArgumentValue("Source"), Is.EqualTo("Test Value"));
            Assert.That(cmdLine.IsSwitchSet("/MIN"), Is.True);

            cmdLine.Reset();

            Assert.That(cmdLine.GetArgumentValue("Source"), Is.Empty);
            Assert.That(cmdLine.IsSwitchSet("/MIN"), Is.False);
        }

        [Test]
        public void SetSwitchValueWithColumn()
        {
            CommandLineHelper cmd = new CommandLineHelper("File");
            cmd.AddSwitch("/log", "Log File.", "logFile");
            cmd.SetSwitch("/log", "C:\\Temp\\Output.txt");

            Assert.That(cmd.GetSwitchValue("/log"), Is.EqualTo("C:\\Temp\\Output.txt"));
        }

        [Test]
        public void ParseCommandLineFileName()
        {
            CommandLineHelper cmd = new CommandLineHelper("File");
            cmd.AddSwitch("/log", "Log File.", "logFile");
            cmd.ParseCommandLine(("/log:C:\\Temp\\Output.txt").Split(' '));
            Assert.That(cmd.GetSwitchValue("/log"), Is.EqualTo("C:\\Temp\\Output.txt"));
        }

    }
}
