using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#if NET472
using WK.Libraries.BetterFolderBrowserNS;
#endif

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Command line editor with macro insertion capability.
    /// </summary>
    public partial class CommandMacroEditor : Form
    {
        /// <summary>
        /// String added before macro label.
        /// </summary>
        [Category("Settings")]
        [Description("String added before macro label.")]
        [DefaultValue("<")]
        public string MacroPrefix { get; set; } = "<";
        /// <summary>
        /// String added after macro label.
        /// </summary>
        [Category("Settings")]
        [Description("String added after macro label.")]
        [DefaultValue(">")]
        public string MacroPostfix { get; set; } = ">";

        /// <summary>
        /// Input Command
        /// </summary>
        [Category("Settings")]
        [Description("Input Command.")]
        public string Command { get; set; }

        /// <summary>
        /// Constructor. Initiate new instance
        /// </summary>
        public CommandMacroEditor(string formTitle)
        {
            InitializeComponent();
            Text = formTitle;
        }

        private readonly Dictionary<string, string> MacroPair = new Dictionary<string, string>();

        /// <summary>
        /// Add Macro Key Value Pair
        /// </summary>
        /// <param name="macroName"></param>
        /// <param name="value"></param>
        public void AddMacroPair(string macroName, string value)
        {
            MacroPair.Add(macroName, value);
        }

        /// <summary>
        /// Raise the Form.Shown event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            TxtCommand.Text = Command;
            MacroGridView.Rows.Clear();
            foreach (KeyValuePair<string, string> ptrPair in MacroPair)
            {
                DataGridViewRow ptrRow = new DataGridViewRow();
                ptrRow.Cells.Add(new DataGridViewTextBoxCell() { Value = ptrPair.Key });
                ptrRow.Cells.Add(new DataGridViewTextBoxCell() { Value = ptrPair.Value });
                MacroGridView.Rows.Add(ptrRow);
            }
            base.OnShown(e);
        }

        private void MacroGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            InsertMacro();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Command = TxtCommand.Text;
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            InsertMacro();
        }

        private void InsertMacro()
        {
            if (MacroGridView.SelectedRows.Count == 0) return;

            int startPos = TxtCommand.SelectionStart;
            string text = TxtCommand.Text;

            if (TxtCommand.SelectionLength > 0) text = text.Remove(startPos, TxtCommand.SelectionLength);
            DataGridViewRow ptrRow = MacroGridView.Rows[MacroGridView.SelectedRows[0].Index];
            string macroText = MacroPrefix + ptrRow.Cells[0].Value + MacroPostfix;

            TxtCommand.Text = text.Insert(startPos, macroText);
            TxtCommand.SelectionStart = startPos + macroText.Length;
            TxtCommand.Focus();
        }

        private void InsertText(string inputText)
        {
            int startPos = TxtCommand.SelectionStart;
            string text = TxtCommand.Text;

            if (TxtCommand.SelectionLength > 0) text = text.Remove(startPos, TxtCommand.SelectionLength);
            TxtCommand.Text = text.Insert(startPos, inputText);
            TxtCommand.SelectionStart = startPos + inputText.Length;
            TxtCommand.Focus();
        }

        private void MacroGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                InsertMacro();
            }
        }

        private void btAddFolder_Click(object sender, EventArgs e)
        {
#if NET472
            using (BetterFolderBrowser dialog = new BetterFolderBrowser())
            {
                dialog.Title = "Select Folders...";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    InsertText(FormatFilePath(dialog.SelectedFolder));
                }
            }
#else
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                InsertText(FormatFilePath(folderBrowserDialog1.SelectedPath));
            }
#endif
        }

        private void btAddFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                InsertText(FormatFilePath(openFileDialog1.FileName));
            }
        }

        private string FormatFilePath(string input)
        {
            if (input.Contains(" ")) return "\"" + input + "\"";
            return input;
        }
    }
}
