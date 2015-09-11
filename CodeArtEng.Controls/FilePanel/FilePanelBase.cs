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
        public override string Text { get { return label.Text; } set { label.Text = value; } }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            EventHandler eventHandler = TextChanged;
            if (eventHandler != null) eventHandler(this, null);
        }
    }
}
