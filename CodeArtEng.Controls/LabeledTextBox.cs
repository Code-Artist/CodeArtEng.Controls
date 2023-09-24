using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// File and folder selection panel base.
    /// </summary>
    public partial class LabeledTextBox : UserControl
    {
        private readonly int textBoxLeftMargin, textBoxRightMargin;
        private Control ptrActiveControl;

        /// <summary>
        /// Event raised when text changed.
        /// </summary>
        [Browsable(true)]
        [Description("Occurs when value of text box changed.")]
        public new event EventHandler TextChanged;

        /// <summary>
        /// Event raised when check box is checked / unchecked.
        /// </summary>
        [Browsable(true)]
        [Description("Occurs when the Check property is changed.")]
        public event EventHandler CheckedChanged;

        /// <summary>
        /// Event raised when dropdown selected index had been changed.
        /// </summary>
        [Browsable(true)]
        [Description("Occurs when dropdown selected index had been changed.")]
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        public LabeledTextBox()
        {
            InitializeComponent();
            //Left Margin was not calculated correctly - Used fix value for now.
            textBoxLeftMargin = 0;
            textBoxRightMargin = 2;
            label.SizeChanged += Label_SizeChanged;

            comboBox.Location = textbox.Location;
            comboBox.Left = textbox.Left;
            comboBox.Top = textbox.Top;
            comboBox.Anchor = textbox.Anchor;
            comboBox.Visible = false;
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Hint to text box
        /// </summary>
        [Category("Appearance")]
        [Browsable(true)]
        [Description("Hint Text")]
        [Bindable(true)]
        public string Hint
        {
            get { return textbox.Hint; }
            set { textbox.Hint = value; }
        }

        /// <summary>
        /// Text associated with the control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get { return IsDropDownList ? comboBox.Text : textbox.Text; }
            set
            {
                if (IsDropDownList)
                {
                    int index = comboBox.Items.IndexOf(value);
                    if (index != -1) comboBox.SelectedIndex = index;
                }
                else
                    textbox.Text = value;
            }
        }

        /// <summary>
        /// Label text alignment
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(ContentAlignment.TopLeft)]
        public ContentAlignment LabelTextAlign { get => label.TextAlign; set => label.TextAlign = value; }

        /// <summary>
        /// Label Text
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        public string LabelText
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        /// <summary>
        /// Auto Resize Label 
        /// </summary>
        [Category("Appearance")]
        public bool LabelAutoSize
        {
            get { return label.AutoSize; }
            set { label.AutoSize = value; }
        }

        /// <summary>
        /// Width of label control
        /// </summary>
        [Category("Appearance")]
        public int LabelWidth
        {
            get { return label.Width; }
            set { label.Width = value; }
        }

        [Category("Appearance")]
        [Description("Return current textbox / combobox width.")]
        public int TextBoxWidth => comboBox.Visible ? comboBox.Width : textbox.Width;

        /// <summary>
        /// Show or hide check box
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool ShowCheckBox
        {
            get { return chkBox.Visible; }
            set
            {
                chkBox.Visible = value;
                if (value == false) chkBox.Checked = true;
                RecalculateTextBoxSize();
            }
        }

        /// <summary>
        /// Set state for check box. Always true if ShowCheckBox set to false.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool Checked
        {
            get { return chkBox.Checked; }
            set { chkBox.Checked = chkBox.Visible ? value : true; }
        }

        /// <summary>
        /// Set Text Box Readonly flag, no effect for Drop down box.
        /// </summary>
        [Category("Behavior")]
        public bool ReadOnly
        {
            get => textbox.ReadOnly;
            set
            {
                textbox.ReadOnly = value;

                //Workaround to ensure correct back color set based on ReadOnly status.
                textbox.BackColor = textbox.ReadOnly ? Color.FromKnownColor(KnownColor.Control) :
                    Color.FromKnownColor(KnownColor.Window);
            }
        }

        /// <summary>
        /// Specify maximum input character for Text Box.
        /// </summary>
        [Category("Behavior")]
        public int TextBoxMaxLength { get => textbox.MaxLength; set => textbox.MaxLength = value; }

        /// <summary>
        /// Foreground Color of Text Box.
        /// </summary>
        [Category("Appearance")]
        public Color TextBoxForeColor { get => textbox.ForeColor; set => textbox.ForeColor = value; }

        /// <summary>
        /// Background Color of Text Box.
        /// </summary>
        [Category("Appearance")]
        public Color TextBoxBackColor { get => textbox.BackColor; set => textbox.BackColor = value; }

        private bool isDropDownList = false;

        /// <summary>
        /// Define if control is drop down list instead of text box.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool IsDropDownList
        {
            get { return isDropDownList; }
            set
            {
                isDropDownList = value;
                textbox.Visible = !isDropDownList;
                comboBox.Visible = isDropDownList;
                ptrActiveControl = isDropDownList ? comboBox as Control : textbox;
            }
        }

        /// <summary>
        /// Define items in drop down list.
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        public string[] DropDownListItems
        {
            get
            {
                string[] result = new string[comboBox.Items.Count];
                comboBox.Items.CopyTo(result, 0);
                return result;
            }
            set
            {
                comboBox.Items.AddRange(value);
                if (comboBox.Items.Count != 0) comboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Item selected index for Drop Down Box
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(0)]
        public int DropDownListSelectedIndex
        {
            get
            {
                if (IsDropDownList) return comboBox.SelectedIndex;
                else return -1;
            }
            set
            {
                comboBox.SelectedIndex = value;
            }
        }


        private void textbox_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, null);
        }

        private void textbox_DragDrop(object sender, DragEventArgs e)
        {
            string data = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            textbox.Text = data;
        }

        private void textbox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                if (ValidateDropData(((string[])e.Data.GetData(DataFormats.FileDrop))[0]))
                    e.Effect = DragDropEffects.Link;
            }
        }

        internal virtual bool ValidateDropData(string filePath) { return true; }

        private void LabeledTextBox_VisibleChanged(object sender, EventArgs e)
        {
            RecalculateTextBoxSize();
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e); //Forward event to parent class
        }

        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e); //Forward event to parent class
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, null);
        }

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged?.Invoke(this, null);
            textbox.Enabled = chkBox.Checked;
            comboBox.Enabled = chkBox.Checked;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(sender, e);
        }

        private void Label_SizeChanged(object sender, EventArgs e)
        {
            RecalculateTextBoxSize();
        }

        private void LabeledTextBox_SizeChanged(object sender, EventArgs e)
        {
            RecalculateTextBoxSize();
        }

        private void RecalculateTextBoxSize()
        {
            SuspendLayout();
            comboBox.Left = textbox.Left = label.Left + label.Width + textBoxLeftMargin;
            comboBox.Width = textbox.Width = this.Width - textbox.Left - textBoxRightMargin;
            ResumeLayout();
        }

    }
}
