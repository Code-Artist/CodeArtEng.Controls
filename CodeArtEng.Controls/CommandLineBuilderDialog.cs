using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    internal partial class CommandLineBuilderDialog : Form
    {
        private CommandLineHelper Helper { get; set; }

        public CommandLineBuilderDialog(CommandLineHelper helper)
        {
            InitializeComponent();
            Helper = helper;
            Text = Application.ProductName + " - " + Text;
        }

        private void btCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(txtCommandOutput.Text);
            MessageBox.Show("Command Copied.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btCreateShortcut_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Shortcut (*.lnk)|*.lnk";
                saveFileDialog1.FileName = Application.ProductName + " Shortcut";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    CreateWindowShortcut(saveFileDialog1.FileName, System.Reflection.Assembly.GetExecutingAssembly().Location,
                            Application.ExecutablePath, Helper.BuildCommandLine());
                    MessageBox.Show("Shortcut Created.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private static void CreateWindowShortcut(string shortcutPath, string iconLocation, string targetPath, string argument)
        {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                if (!shortcutPath.ToLower().EndsWith(".lnk")) shortcutPath += ".lnk";
                var lnk = shell.CreateShortcut(shortcutPath);
                try
                {
                    lnk.TargetPath = targetPath;
                    lnk.Arguments = argument;
                    lnk.IconLocation = iconLocation;
                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
        }

        private void btCreateBatchFile_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Batch File (*.bat)|*.bat";
                saveFileDialog1.FileName = Application.ProductName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string startCmd = "start \"" + Application.ProductName + "\" \"" + Application.ExecutablePath + "\" " + Helper.BuildCommandLine();
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, startCmd);
                    MessageBox.Show("Batch File Created.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void CommandLineBuilderDialog_Shown(object sender, EventArgs e)
        {
            optionsPanel.Controls.Clear();

            int maxLabelWidth = 0;
            foreach (CommandLineArgument a in Helper.GetArguments())
            {
                LabeledTextBox argTextBox = new LabeledTextBox();
                argTextBox.Text = a.Value;
                argTextBox.LabelText = a.Name;
                argTextBox.Tag = a;
                argTextBox.TextChanged += ArgTextBox_TextChanged;
                argTextBox.Hint = a.Description;
                optionsPanel.Controls.Add(argTextBox);
                argTextBox.Width = optionsPanel.Width - 20 - argTextBox.Margin.Left;
                maxLabelWidth = Math.Max(maxLabelWidth, argTextBox.LabelWidth);
            }

            foreach (Control c in optionsPanel.Controls)
            {
                LabeledTextBox t = c as LabeledTextBox;
                if (t == null) continue;
                t.LabelAutoSize = false;
                t.LabelWidth = maxLabelWidth;
            }

            maxLabelWidth = 0;
            foreach (KeyValuePair<string, CommandLineSwitch> sw in Helper.GetSwitches())
            {
                if (!string.IsNullOrEmpty(sw.Value.VariableName))
                {
                    LabeledTextBox argTextBox = new LabeledTextBox();
                    argTextBox.ShowCheckBox = true;
                    argTextBox.Checked = sw.Value.Enabled;
                    argTextBox.Text = sw.Value.Value;
                    argTextBox.LabelText = sw.Key;
                    argTextBox.Tag = sw.Value;
                    argTextBox.TextChanged += ArgTextBox_TextChanged;
                    argTextBox.CheckedChanged += ArgTextBox_CheckedChanged;
                    argTextBox.Hint = sw.Value.Description;
                    argTextBox.Margin = new Padding(0) { Left = 15, Top = 3, Bottom = 3 };
                    argTextBox.LabelAutoSize = true;
                    optionsPanel.Controls.Add(argTextBox);
                    argTextBox.Width = optionsPanel.Width - 20 - argTextBox.Margin.Left;
                    maxLabelWidth = Math.Max(maxLabelWidth, argTextBox.LabelWidth);
                }
                else
                {

                    CheckBox chkBox = new CheckBox();
                    chkBox.Text = sw.Key + "  (" + sw.Value.Description + ")";
                    chkBox.AutoSize = true;
                    chkBox.Checked = sw.Value.Enabled;
                    chkBox.Tag = sw.Value;
                    chkBox.CheckedChanged += ChkBox_CheckedChanged;
                    chkBox.Margin = new Padding(0) { Left = 15, Top = 3, Bottom = 3 };
                    chkBox.Width = optionsPanel.Width - 20 - chkBox.Margin.Left;
                    optionsPanel.Controls.Add(chkBox);
                }
            }

            foreach (Control c in optionsPanel.Controls)
            {
                LabeledTextBox t = c as LabeledTextBox;
                if (t == null) continue;
                if (t.Tag.GetType() == typeof(CommandLineSwitch))
                {
                    t.LabelAutoSize = false;
                    t.LabelWidth = maxLabelWidth;
                }
            }
        }

        private void ArgTextBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCommandLineSwitch(sender);
            UpdateCommandLine();
        }

        private void ChkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = sender as CheckBox;
            CommandLineSwitch sw = chkBox?.Tag as CommandLineSwitch;
            if (sw == null) return;
            sw.Enabled = chkBox.Checked;
            UpdateCommandLine();
        }

        private void ArgTextBox_TextChanged(object sender, EventArgs e)
        {
            LabeledTextBox textBox = sender as LabeledTextBox;
            if (textBox == null) return;
            if (textBox.Tag.GetType() == typeof(CommandLineArgument))
            {
                CommandLineArgument arg = textBox.Tag as CommandLineArgument;
                arg.Value = textBox.Text;
            }
            else if (textBox.Tag.GetType() == typeof(CommandLineSwitch))
            {
                UpdateCommandLineSwitch(textBox);
            }
            UpdateCommandLine();
        }

        private void UpdateCommandLineSwitch(object sender)
        {
            LabeledTextBox textBox = sender as LabeledTextBox;
            CommandLineSwitch arg = textBox.Tag as CommandLineSwitch;
            arg.Enabled = textBox.Checked;
            arg.Value = arg.Enabled ? textBox.Text : string.Empty;
        }

        private void UpdateCommandLine() { txtCommandOutput.Text = Helper.BuildCommandLine(); }
    }
}
