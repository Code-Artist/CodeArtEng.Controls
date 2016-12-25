using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Supported state for <see cref="StatusLabel"/>
    /// </summary>
    public enum StatusLabelState
    {
        /// <summary>
        /// State with Green Color
        /// </summary>
        Green = 0,
        /// <summary>
        /// State with Yellow Color
        /// </summary>
        Yellow = 1,
        /// <summary>
        /// State with Red Color
        /// </summary>
        Red = 2,
        /// <summary>
        /// State with Grey Color
        /// </summary>
        Grey =3
    }

    /// <summary>
    /// Label with status indicator/
    /// <seealso cref="StatusLabelState"/>
    /// </summary>
    public partial class StatusLabel : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StatusLabel()
        {
            InitializeComponent();
            State = StatusLabelState.Grey;
        }

        /// <summary>
        /// The text associated with the control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get
            {
                return lbTitle.Text;
            }

            set
            {
                lbTitle.Text = value;
            }
        }

        private StatusLabelState labelState;

        /// <summary>
        /// Get or set the status image.
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Get or Set the status image.")]
        [DefaultValue(StatusLabelState.Grey)]
        public StatusLabelState State
        {
            get
            {
                return labelState;
            }

            set
            {
                labelState = value;
                switch(labelState)
                {
                    case StatusLabelState.Green:
                        imgStatus.Image = Properties.Resources.GreenDot;
                        break;

                    case StatusLabelState.Yellow:
                        imgStatus.Image = Properties.Resources.YellowDot;
                        break;

                    case StatusLabelState.Red:
                        imgStatus.Image = Properties.Resources.RedDot;
                        break;

                    default:
                        imgStatus.Image = Properties.Resources.GreyDot;
                        break;

                }
            }
        }
    }
}
