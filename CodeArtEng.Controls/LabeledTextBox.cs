using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// File and folder selection panel base.
    /// </summary>
    public partial class LabeledTextBox : UserControl
    {
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
        /// Constructor
        /// </summary>
        public LabeledTextBox()
        {
            InitializeComponent();
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
            get { return textbox.Text; }
            set { textbox.Text = value; }
        }

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
        [Category("Layout")]
        public bool LabelAutoSize
        {
            get { return label.AutoSize; }
            set { label.AutoSize = value; }
        }

        /// <summary>
        /// Width of label control
        /// </summary>
        [Category("Layout")]
        public int LabelWidth
        {
            get { return label.Width; }
            set { label.Width = value; }
        }

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

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged?.Invoke(this, null);
        }
    }
}
