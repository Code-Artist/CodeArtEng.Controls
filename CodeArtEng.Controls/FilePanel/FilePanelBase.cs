using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// File and folder selection panel base.
    /// </summary>
    [ToolboxItem(false)]
    public partial class FilePanelBase : UserControl
    {
        /// <summary>
        /// Event raised when text changed.
        /// </summary>
        [Browsable(true)]
        public new event EventHandler TextChanged;

        /// <summary>
        /// Internal callback when textbox value changed
        /// </summary>
        protected Action ValueChangedCallback;

        /// <summary>
        /// Constructor
        /// </summary>
        public FilePanelBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Text associated with the control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [DefaultValue("label")]
        public override string Text
        {
            get { return label.Text; }
            set
            {
                label.Text = value;
                label.Visible = (!string.IsNullOrEmpty(label.Text));
            }
        }

        /// <summary>
        /// Control whether the content can be changed or not
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return textbox.ReadOnly; }
            set
            {
                textbox.ReadOnly = value;
                btBrowse.Enabled = !value;
            }
        }

        /// <summary>
        /// Auto Resize Label
        /// </summary>
        [Category("Layout")]
        [DefaultValue(true)]
        public bool LabelAutoSize
        {
            get { return label.AutoSize; }
            set { label.AutoSize = value; }
        }

        /// <summary>
        /// Width of label control
        /// </summary>
        [Category("Layout")]
        [DefaultValue(30)]
        public int LabelWidth
        {
            get { return label.Width; }
            set { label.Width = value; }
        }


        private void textbox_TextChanged(object sender, EventArgs e)
        {
            ValueChangedCallback?.Invoke();
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
    }
}
