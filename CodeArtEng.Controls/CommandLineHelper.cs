using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Command Line Argument
    /// </summary>
    public class CommandLineArgument
    {
        /// <summary>
        /// Argument Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Short description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Argument value parsed from command line.
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }

    /// <summary>
    /// Optional Switches and Arguments
    /// </summary>
    public class CommandLineSwitch
    {
        /// <summary>
        /// Short description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Optional variable for switch.
        /// </summary>
        public string VariableName { get; set; }
        /// <summary>
        /// Set to true if switch defined in command line.
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Switch value parsed from command line.
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// Utility Class to define and parse Command Line Arguments
    /// </summary>
    public class CommandLineHelper
    {
        /// <summary>
        /// Description of Application.
        /// </summary>
        public string Description { get; set; }

        private int ArgMaxLength = 2;
        private List<CommandLineArgument> Arguments = new List<CommandLineArgument>();
        private Dictionary<string, CommandLineSwitch> Switches = new Dictionary<string, CommandLineSwitch>();

        /// <summary>
        /// Return list of registered command line arguments.
        /// </summary>
        /// <returns></returns>
        public IList<CommandLineArgument> GetArguments(){ return Arguments.AsReadOnly(); }
        /// <summary>
        /// Return list of registered switches
        /// </summary>
        /// <returns></returns>
        public ReadOnlyDictionary<string, CommandLineSwitch> GetSwitches() { return new ReadOnlyDictionary<string, CommandLineSwitch>(Switches); }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="description"></param>
        public CommandLineHelper(string description) { Description = description; }

        /// <summary>
        /// Register a mandatory argument to command line.
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <param name="description">Short description</param>
        public void AddArgument(string name, string description)
        {
            if (Find(Arguments, name) != null) throw new Exception("Failed to add argument [" + name + "], already exists!");

            CommandLineArgument arg = new CommandLineArgument() { Name = name, Description = description };
            Arguments.Add(arg);
            ArgMaxLength = Math.Max(ArgMaxLength, name.Length);
        }

        /// <summary>
        /// Register an optional switch or argument to command line which prefix with '/'.
        /// </summary>
        /// <param name="name">Optional argument / switch name. Case insensitive</param>
        /// <param name="description">Short description for key</param>
        /// <param name="variableName">Optional variable name</param>
        /// <exception cref="FormatException">Switch name does not prefix with '/'</exception>
        /// <exception cref="ArgumentException">Switch already defined.</exception>
        public void AddSwitch(string name, string description, string variableName = "")
        {
            if (!name.StartsWith("/")) throw new FormatException("Switch name must prefix with '/'!");
            if (Switches.Keys.Contains(name.ToUpper()))
                throw new ArgumentException("Failed to add switch [" + name + "], already exists!");
            if (!string.IsNullOrEmpty(variableName)) ArgMaxLength = Math.Max(variableName.Length + 3, ArgMaxLength);
            Switches.Add(name.ToUpper(), new CommandLineSwitch() { Description = description, VariableName = variableName });
        }

        /// <summary>
        /// Print usage screen
        /// </summary>
        public void PrintHelp()
        {
            string tFormat = "  {0,-" + ArgMaxLength.ToString() + "}   {1}";

            Console.WriteLine(Description);
            Console.WriteLine("");
            string APPNAME = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

            //Print USAGE
            Console.Write(APPNAME);
            foreach (CommandLineArgument arg in Arguments)
                Console.Write(" " + arg.Name);

            foreach (KeyValuePair<string, CommandLineSwitch> sw in Switches)
            {
                Console.Write(" [" + sw.Key);
                if (!string.IsNullOrEmpty(sw.Value.VariableName))
                    Console.Write(":" + sw.Value.VariableName);
                Console.Write("]");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //Print Argument + Description
            foreach (CommandLineArgument arg in Arguments)
                Console.WriteLine(tFormat, arg.Name, arg.Description);
            Console.WriteLine("");

            //Print Switches + Description
            if (Switches.Count > 0)
            {
                Console.WriteLine("SWITCHES");
                foreach (KeyValuePair<string, CommandLineSwitch> sw in Switches)
                {
                    string s = sw.Key;
                    if (!string.IsNullOrEmpty(sw.Value.VariableName)) s += ":" + sw.Value.VariableName;
                    Console.WriteLine(tFormat, s, sw.Value.Description);
                }
                Console.WriteLine("");
            }

            //Print Examples if Any
        }

        /// <summary>
        /// Parse command line input from environment arguments
        /// </summary>
        /// <returns></returns>
        public void ParseCommandLine()
        {
            //ToDo: Test Cases for ParseCommandLine() test.
            try
            {
                List<string> arguments = new List<string>();
                arguments.AddRange(Environment.GetCommandLineArgs().Skip(1));

                if (arguments.FirstOrDefault(t => t == "/?") != null)
                {
                    PrintHelp();
                    Environment.Exit(-1);
                }
                ParseCommandLine(arguments.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message + "\n");
                PrintHelp();
                Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Parse command line from arguments array
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public void ParseCommandLine(string[] arguments)
        {
            int x;

            //Consume mandatory arguments
            for (x = 0; x < Arguments.Count(); x++)
            {
                if (arguments[x].StartsWith("/"))
                {
                    //We don't expect optional argument here until mandatory arguments are filled up.
                    throw new Exception("Missing argument " + Arguments[x].Name + "\n");
                }
                Arguments[x].Value = arguments[x];
            }

            //Consume Optional Argumnets
            for (; x < arguments.Count(); x++)
            {
                if (arguments[x].StartsWith("/"))
                {
                    //Split semicolumn
                    if (arguments[x].Contains(":"))
                    {
                        string[] var = arguments[x].Split(':');
                        CommandLineSwitch sw = Switches[var[0].ToUpper()];
                        sw.Enabled = true;
                        sw.Value = var[1];
                    }
                    else
                    {
                        if (Switches.ContainsKey(arguments[x].ToUpper()))
                        {
                            Switches[arguments[x].ToUpper()].Enabled = true;
                        }
                    }
                }
                else continue;
            }
        }

        private CommandLineArgument Find(List<CommandLineArgument> source, string name)
        {
            return source.FirstOrDefault(x => string.Compare(x.Name, name, true) == 0);
        }

        /// <summary>
        /// Retreive value for defined argument
        /// </summary>
        /// <param name="name">Argument name, non case sensitive</param>
        /// <returns>Value in string</returns>
        /// <exception cref="ArgumentNullException">Argument not defined.</exception>
        public string GetArgumentValue(string name)
        {
            CommandLineArgument a = Find(Arguments, name);
            if (a == null) throw new ArgumentNullException("Undefined argument: " + name);
            return a.Value;
        }

        /// <summary>
        /// Check if an optional switch is set
        /// </summary>
        /// <param name="name">Switch name, non case sensitive</param>
        /// <returns>true / false. Retun false if key is not defined.</returns>
        public bool IsSwitchSet(string name)
        {
            if (Switches.ContainsKey(name.ToUpper()))
            {
                return Switches[name.ToUpper()].Enabled;
            }
            return false;
        }

        /// <summary>
        /// Retrieve value associated with defined switch.
        /// </summary>
        /// <param name="name">Switch name, non case sensitive</param>
        /// <param name="defaultValue"> (OPTIONAL) Default value if switch is not defined, empty string by default.</param>
        /// <returns>value</returns>
        public string GetSwitchValue(string name, string defaultValue = "")
        {
            string swName = name.ToUpper();
            if (Switches.ContainsKey(swName))
            {
                CommandLineSwitch sw = Switches[swName];
                if(!string.IsNullOrEmpty(sw.VariableName))
                {
                    if (!string.IsNullOrEmpty(sw.Value))
                        return sw.Value;
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// Generate command line string using value and switches state set.
        /// </summary>
        /// <returns></returns>
        public string BuildCommandLine()
        {
            string result = string.Empty;

            foreach (CommandLineArgument a in Arguments)
            {
                if (string.IsNullOrEmpty(a.Value))
                    result += "[" + a.Name + "] "; //Add Place Holder
                else
                    result += a.Value + " ";
            }

            foreach (KeyValuePair<string, CommandLineSwitch> s in Switches)
            {
                if (s.Value.Enabled)
                {
                    result += s.Key;
                    if (!string.IsNullOrEmpty(s.Value.VariableName))
                    {
                        result += ":";
                        if (string.IsNullOrEmpty(s.Value.Value))
                            result += "[" + s.Value.VariableName + "]"; //Add Place Holder
                        else
                            result += s.Value.Value;
                    }
                    result += " ";
                }
            }
            return result.TrimEnd();
        }

        /// <summary>
        /// Show Command Line Builder Dialog (WinForm)
        /// </summary>
        /// <returns></returns>
        public System.Windows.Forms.DialogResult ShowDialog()
        {
            using (CommandLineBuilderDialog dlg = new CommandLineBuilderDialog(this))
            {
                return dlg.ShowDialog();
            }
        }

    }
}
