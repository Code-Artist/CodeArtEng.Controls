using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CodeArtEng.Controls
{
    internal class RegistryHelper
    {

        /// <summary>
        /// Open Registry Key with write access, auto create if key not exists.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static RegistryKey OpenRegistryKey(string key)
        {
            RegistryKey parent = null;
            RegistryKey regSubKey;

            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("Registry key not defined!");
            string[] subKeys = key.Split('\\');
            string parentString = subKeys.First().ToUpper();

            if ((parentString == "HKCU") || (parentString == "HKEY_CURRENT_USER")) parent = Registry.CurrentUser;
            else if ((parentString == "HKLM") || (parentString == "HKEY_LOCAL_MACHINE")) parent = Registry.LocalMachine;
            else if ((parentString == "HKCR") || (parentString == "HKEY_CLASSES_ROOT")) parent = Registry.ClassesRoot;

            if (parent == null) throw new FormatException("Unknown / Unsupported registry key format!");

            foreach (string subKey in subKeys.Skip(1))
            {
                if (string.IsNullOrEmpty(subKey)) continue;
                regSubKey = parent.OpenSubKey(subKey, true);
                if (regSubKey == null)
                {
                    regSubKey = parent.CreateSubKey(subKey);
                }
                parent = regSubKey;
            }
            return parent;
        }

        /// <summary>
        /// Open Registry Key with read only access, does not create sub keys if not exist.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static RegistryKey OpenRegistryKeyReadOnly(string key)
        {
            RegistryKey parent = null;

            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("Registry key not defined!");
            string[] subKeys = key.Split('\\');
            string parentString = subKeys.First().ToUpper();

            if ((parentString == "HKCU") || (parentString == "HKEY_CURRENT_USER")) parent = Registry.CurrentUser;
            else if ((parentString == "HKLM") || (parentString == "HKEY_LOCAL_MACHINE")) parent = Registry.LocalMachine;
            else if ((parentString == "HKCR") || (parentString == "HKEY_CLASSES_ROOT")) parent = Registry.ClassesRoot;

            if (parent == null) throw new FormatException("Unknown / Unsupported registry key format!");

            return parent.OpenSubKey(string.Join("\\", subKeys.Skip(1)));
        }

        internal static void WriteKey(string key, string name, string data)
        {
            WriteKey(key, new RegistryValue(name, data));
        }

        internal static void WriteKey(string key, params RegistryValue[] values)
        {
            using (RegistryKey regKey = OpenRegistryKey(key))
            {
                foreach (RegistryValue v in values)
                {
                    if (v.ValueKind == RegistryValueKind.DWord)
                        regKey.SetValue(v.Name, v.DWordValue, RegistryValueKind.DWord);
                    else
                        regKey.SetValue(v.Name, v.Value);
                }
            }
        }

        internal static void VerifyKey(string key, params RegistryValue[] values)
        {
            using (RegistryKey regKey = OpenRegistryKey(key))
            {
                foreach (RegistryValue v in values)
                {
                    if (!regKey.GetValueNames().Contains(v.Name)) throw new Exception("Registry key not exists: " + key + "\\" + v.Name);
                    if (v.ValueKind == RegistryValueKind.DWord)
                    {
                        int value = Convert.ToInt32(regKey.GetValue(v.Name));
                        if (v.DWordValue != value)
                            throw new Exception("Key value mismatched: " + key + "\\" + v.Name);
                    }
                    else
                    {
                        string regValue = regKey.GetValue(v.Name).ToString();
                        //Trace.WriteLine("Reg Read back value = " + regValue);
                        if (!v.Value.Equals(regValue))
                            throw new Exception("Key value mismatched: " + key + "\\" + v.Name);
                    }
                }
            }
        }
    }


    /// <summary>
    /// Registry value helper class, convert value to corresponding data type
    /// </summary>
    internal class RegistryValue
    {
        public RegistryValue(string name, string value) { Name = name; Value = value; }

        public RegistryValue(string name, int value)
        {
            Name = name;
            DWordValue = value;
            ValueKind = RegistryValueKind.DWord;
        }
        public string Name { get; private set; }
        public string Value { get; private set; }
        public int DWordValue { get; private set; }

        public RegistryValueKind ValueKind { get; private set; } = RegistryValueKind.String;
    }

}
