using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
        [DefaultValue("Path")]
        public override string Text
        {
            get { return label.Text; }
            set
            {
                label.Text = value;
                label.Visible = (!string.IsNullOrEmpty(label.Text));
            }
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            EventHandler eventHandler = TextChanged;
            if (eventHandler != null) eventHandler(this, null);
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
