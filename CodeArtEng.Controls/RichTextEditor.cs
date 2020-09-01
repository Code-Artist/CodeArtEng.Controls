using Cyotek.Windows.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Rich Text Editor Control
    /// </summary>
    public partial class RichTextEditor : UserControl
    {
        private readonly Color ButtonONColor = Color.FromArgb(152, 188, 224);
        private readonly Color ButtonOFFColor = Color.FromKnownColor(KnownColor.Control);
        private const string _DefaultFont = "Arial, 10pt";

        /// <summary>
        /// Rich Text
        /// </summary>
        [Browsable(true)]
        public new string Text
        {
            get => TextBox.Text;
            set => TextBox.Text = value;
        }

        /// <summary>
        /// Text with rich text format (RTF) codes.
        /// </summary>
        [Browsable(false)]
        [Bindable(true)]
        public string RichText
        {
            get => TextBox.Rtf;
            set => TextBox.Rtf = value;
        }

        /// <summary>
        /// Default Font
        /// </summary>
        [Browsable(true)]
        [Bindable(true)]
        [DefaultValue(typeof(Font), _DefaultFont)]
        public new Font Font
        {
            get => TextBox.Font;
            set { TextBox.Font = value; UpdateToolPanel(); }
        }

        /// <summary>
        /// Show / Hide Tools Panel
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Show / Hide Tools Panel")]
        public bool ShowToolsPanel { get => ToolsPanel.Visible; set => ToolsPanel.Visible = value; }

        /// <summary>
        /// Controls whether the text can be changed or not.
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Controls whether the text can be changed or not.")]
        public bool ReadOnly { get => TextBox.ReadOnly; set => TextBox.ReadOnly = value; }

        /// <summary>
        /// Background color of text box.
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Background color of text box.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Color), "Window")]
        public new Color BackColor { get => TextBox.BackColor; set => TextBox.BackColor = value; }

        /// <summary>
        /// Background color of tools panel.
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Background color of tools panel.")]
        public Color ToolsPanelBackColor { get => ToolsPanel.BackColor; set => ToolsPanel.BackColor = value; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RichTextEditor()
        {
            InitializeComponent();
            CbFonts.Items.AddRange(FontFamily.Families.Skip(1).Select(x => x.Name).ToArray());
            CbFontSize.Items.AddRange(new object[] { 8, 9, 10, 11, 12, 14, 15, 18, 20, 22, 24, 26, 28 });
            Font = (Font)new FontConverter().ConvertFromString(_DefaultFont);
            UpdateToolPanel();
        }
        private void UpdateToolPanel()
        {
            if (TextBox.SelectionFont == null) return;

            FontStyle style = TextBox.SelectionFont.Style;
            BtBold.BackColor = style.HasFlag(FontStyle.Bold) ? ButtonONColor : ButtonOFFColor;
            BtItalic.BackColor = style.HasFlag(FontStyle.Italic) ? ButtonONColor : ButtonOFFColor;
            BtUnderline.BackColor = style.HasFlag(FontStyle.Underline) ? ButtonONColor : ButtonOFFColor;

            CbFonts.SelectedIndex = CbFonts.Items.IndexOf(TextBox.SelectionFont.Name);
            //Round to nearest integer
            int fontIndex = CbFontSize.Items.IndexOf(Math.Round(TextBox.SelectionFont.Size));
            if (fontIndex == -1) CbFontSize.Text = Math.Round(TextBox.SelectionFont.Size).ToString();
            else CbFontSize.SelectedIndex = fontIndex;

            BtAlignLeft.BackColor = TextBox.SelectionAlignment == HorizontalAlignment.Left ? ButtonONColor : ButtonOFFColor;
            BtAlignCenter.BackColor = TextBox.SelectionAlignment == HorizontalAlignment.Center ? ButtonONColor : ButtonOFFColor;
            BtAlignRight.BackColor = TextBox.SelectionAlignment == HorizontalAlignment.Right ? ButtonONColor : ButtonOFFColor;
        }

        #region [ TextBox Events ]

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if ((e.Modifiers & Keys.Control) == Keys.Control)
            {
                if (e.KeyCode == Keys.B) ToggleSelectionBold();
                else if (e.KeyCode == Keys.I) ToggleSelectionItalic();
                else if (e.KeyCode == Keys.U) ToggleSelectionUnderline();
                else e.SuppressKeyPress = false;
            }
            else e.SuppressKeyPress = false;
        }

        private void TextBox_SelectionChanged(object sender, EventArgs e)
        {
            UpdateToolPanel();
        }

        private void TextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            LinkClicked(this, e.LinkText);
        }

        /// <summary>
        /// When user click on link, launch with default action. Override function to modify.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="linkText"></param>
        public virtual void LinkClicked(object sender, string linkText) { Process.Start(linkText); }

        #endregion

        #region [ Font Style ]

        private void ToggleSelectionBold()
        {
            TextBox.SelectionFont = new Font(TextBox.Font, TextBox.SelectionFont.Style ^ FontStyle.Bold);
            UpdateToolPanel();
        }

        private void ToggleSelectionItalic()
        {
            TextBox.SelectionFont = new Font(TextBox.Font, TextBox.SelectionFont.Style ^ FontStyle.Italic);
            UpdateToolPanel();
        }

        private void ToggleSelectionUnderline()
        {
            TextBox.SelectionFont = new Font(TextBox.Font, TextBox.SelectionFont.Style ^ FontStyle.Underline);
            UpdateToolPanel();
        }

        private void BtBold_Click(object sender, EventArgs e)
        {
            ToggleSelectionBold();
        }

        private void BtItalic_Click(object sender, EventArgs e)
        {
            ToggleSelectionItalic();
        }

        private void BtUnderline_Click(object sender, EventArgs e)
        {
            ToggleSelectionUnderline();
        }

        private void CbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox.SelectionFont = new Font(FontFamily.Families.FirstOrDefault(x => x.Name == CbFonts.Text),
                TextBox.SelectionFont.Size,
                TextBox.SelectionFont.Style);
        }

        private void CbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbFontSize.SelectedIndex == -1) return;
            UpdateFontSize(Convert.ToInt16(CbFontSize.Text));
        }

        private void CbFontSize_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                int size = Convert.ToInt16(CbFontSize.Text);
                if (size > 409) throw new ArgumentException();
                UpdateFontSize(size);
            }
            catch
            {
                MessageBox.Show("Font size must between 1 to 409 points!", "Font Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFontSize(int size)
        {
            TextBox.SelectionFont = new Font(TextBox.SelectionFont.FontFamily, size, TextBox.SelectionFont.Style);
        }

        #endregion

        #region [ Font Color ]

        private void BtFontColor_Click(object sender, EventArgs e)
        {
            using (ColorPickerDialog dialog = new ColorPickerDialog())
            {
                dialog.Color = TextBox.SelectionColor;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TextBox.SelectionColor = dialog.Color;
                }
            }
        }

        private void BtBrushColor_Click(object sender, EventArgs e)
        {
            using (ColorPickerDialog dialog = new ColorPickerDialog())
            {
                dialog.Color = TextBox.SelectionBackColor;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TextBox.SelectionBackColor = dialog.Color;
                }
            }
        }

        #endregion

        #region [ Indent and Bullet Controls ]

        private const int IndentStep = 16;
        private const int HangingIndent = 20;

        private void BtBullet_Click(object sender, EventArgs e)
        {
            TextBox.SelectionBullet = !TextBox.SelectionBullet;
            TextBox.SelectionIndent = IndentStep;
            TextBox.SelectionHangingIndent = HangingIndent;
        }

        private void BtIncreaseIndent_Click(object sender, EventArgs e)
        {
            TextBox.SelectionIndent += IndentStep;
        }

        private void BtDecreaseIndent_Click(object sender, EventArgs e)
        {
            int minIndent = TextBox.SelectionBullet ? IndentStep : 0;
            TextBox.SelectionIndent = Math.Max(minIndent, TextBox.SelectionIndent - IndentStep);
        }

        #endregion

        #region [ Text Alignment ]

        private void BtAlignLeft_Click(object sender, EventArgs e)
        {
            TextBox.SelectionAlignment = HorizontalAlignment.Left;
            UpdateToolPanel();
        }

        private void BtAlignCenter_Click(object sender, EventArgs e)
        {
            TextBox.SelectionAlignment = HorizontalAlignment.Center;
            UpdateToolPanel();
        }

        private void BtAlignRight_Click(object sender, EventArgs e)
        {
            TextBox.SelectionAlignment = HorizontalAlignment.Right;
            UpdateToolPanel();
        }

        #endregion

        #region [ Editing ]
        private void BtCut_Click(object sender, EventArgs e)
        {
            TextBox.Cut();
        }

        private void BtCopy_Click(object sender, EventArgs e)
        {
            TextBox.Copy();
        }
        private void BtPaste_Click(object sender, EventArgs e)
        {
            TextBox.Paste();
        }
        #endregion

        /// <summary>
        /// Return RTF Text without paragraph symbol.
        /// </summary>
        /// <returns></returns>
        public string GetRtfText()
        {
            int tStart = TextBox.SelectionStart;
            int tLength = TextBox.SelectionLength;
            try
            {
                TextBox.Select(0, TextBox.Text.Length);
                return TextBox.SelectedRtf;
            }
            finally
            {
                TextBox.SelectionStart = tStart;
                TextBox.SelectionLength = tLength;
            }
        }

        /// <summary>
        /// Append text to rich text box without breaking existing formatting. 
        /// Auto detect input text is normal string or RTF.
        /// </summary>
        /// <param name="inputs"></param>
        public void Append(params string[] inputs)
        {
            foreach (string input in inputs)
            {
                TextBox.Select(TextBox.Text.Length, 0);
                if (input.StartsWith(@"{\rtf"))
                    TextBox.SelectedRtf = input;
                else
                    TextBox.SelectedText = input;
            }
            TextBox.Select(TextBox.Text.Length, 0);
        }

    }
}
