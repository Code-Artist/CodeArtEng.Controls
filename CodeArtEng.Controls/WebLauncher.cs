using CodeArtEng.Security;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Launch local application from web URL from webpage or email.
    /// </summary>
    public class WebLauncher
    {
        //This method make use of a custorm URL protocol register under HKCR.
        //Administrator rights required to register URL name.

        /// <summary>
        /// Target name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Target application path
        /// </summary>
        public string AppPath { get; private set; }
        /// <summary>
        /// Pass phrase for command encryption purpose
        /// </summary>
        public string PassPhrase { get; private set; }

        private AesEncryptor AES;

        private const string URLHeader = "CodeArtEng Web Launcher: ";

        /// <summary>
        /// Initiate launcher object.
        /// </summary>
        /// <param name="name">Target name</param>
        /// <param name="appPath">Target application path</param>
        /// <param name="arguments"></param>
        /// <exception cref="ArgumentException"></exception>
        public WebLauncher(string name, string appPath, string passPhrase = null)
        {
            Name = name;
            AppPath = appPath;

            if (!string.IsNullOrEmpty(passPhrase))
            {
                AES = new AesEncryptor();
                PassPhrase = passPhrase;
            }
        }

        /// <summary>
        /// Register application for email launcher. Required Administrator rights to execute.
        /// </summary>
        public void RegisterURLProtocol()
        {
            if (!Utility.IsAdministrator()) throw new AccessViolationException("Administrator rights required!");

            string regKey = @"HKCR\" + Name;

            //Check for similar existing key exists to prevent overwrite system defined keys.
            //Only overwrite keys created by WebLauncher class.
            RegistryKey ptrKey = RegistryHelper.OpenRegistryKeyReadOnly(regKey);
            if (ptrKey != null)
            {
                string keyValue = ptrKey.GetValue("")?.ToString();
                if (!keyValue.StartsWith(URLHeader))
                    throw new InvalidOperationException($"Unable to register URL Protocol {Name}, key conflicts!");

            }
            RegistryHelper.WriteKey(regKey, "", URLHeader + Name);
            RegistryHelper.WriteKey(regKey, "URL Protocol", "");

            string command = $"\"{AppPath}\" \"%1\"";
            regKey += @"\shell\open\command";
            RegistryHelper.WriteKey(regKey, "", command);
        }

        /// <summary>
        /// Genrate application launch link.
        /// </summary>
        /// <param name="displayText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string GenerateLaunchLink(string displayText, string urlCommand)
        {
            if (string.IsNullOrEmpty(displayText)) throw new ArgumentNullException("displayText");
            if (string.IsNullOrEmpty(urlCommand)) throw new ArgumentNullException("urlCommand");

            urlCommand = EncodeUrlCommand(urlCommand);
            string url = $"<a href=\"{Name}://{urlCommand}\">{displayText}</a>";
            return url;
        }

        private string EncodeUrlCommand(string command)
        {
            if (AES != null)
            {
                command = AES.EncryptText(command, PassPhrase);
            }
            else
            {
                //Non encrypted text, replace character to HTML format
                command = command.Replace("\\", "/").Replace(" ", "%20");
            }
            return command;
        }

        /// <summary>
        /// Decode input URL Command from URL Protocol. Return empty string if command is not valid URL command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string DecodeUrlCommand(string command)
        {
            string nameHeader = Name + "://";
            if (!command.StartsWith(Name, StringComparison.InvariantCultureIgnoreCase))
                return string.Empty;

            command = command.Substring(nameHeader.Length);
            if (AES != null)
            {
                command = AES.DecryptText(command, PassPhrase);
            }
            else
            {
                //Non ecrypted text, replace HTML character to window char.
                command = command.Replace("%20", " ");
            }
            return command.TrimEnd('/');
        }
    }
}
