using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// TextBox control with hint.
    /// </summary>
    public class HintedTextBox : TextBox, ISupportInitialize
    {
        bool componentInitialized = false;

        #region [ ISupportInitialize Interface ]

        /// <summary>
        /// Signal the object that initialization is starting.
        /// </summary>
        public void BeginInit()
        {
            componentInitialized = false;
        }

        /// <summary>
        /// Signal the object that initialization is completed.
        /// </summary>
        public void EndInit()
        {
            componentInitialized = true;
            UpdateTextBox();
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public HintedTextBox() : base()
        {
            MouseClick += OnMouseClick;
            GotFocus += OnGotFocus;
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            SelectAll();
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            SelectAll();
        }

        private readonly Color hintForeColor = Color.FromKnownColor(KnownColor.Gray);

        /// <summary>
        /// Hint Text
        /// </summary>
        [Category("Appearance")]
        [Browsable(true)]
        [Description("Hint Text")]
        [Bindable(true)]
        public string Hint
        {
            get { return hint; }
            set { hint = value; UpdateTextBox(); }
        }
        private string hint;

        /// <summary>
        /// Input Text for TextBox
        /// </summary>
        [Browsable(true)]
        [Bindable(true)]
        [Description("Input Text")]
        public new string Text
        {
            get { return text; }
            set { text = value; UpdateTextBox(); }
        }
        private string text;

        /// <summary>
        /// Define character to mask a password text.
        /// Property is overridable by UseSystemPassword.
        /// </summary>
        [DefaultValue('\0')]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Define character to mask a password text. Property is overridable by UseSystemPassword")]
        public new char PasswordChar
        {
            get { return PasswordChar; }
            set { passwordChar = value; UpdateTextBox(); }
        }
        private char passwordChar = '\0';

        /// <summary>
        /// Text Color.
        /// </summary>
        [Browsable(true)]
        [Description("Text Color")]
        public new Color ForeColor
        {
            get { return textColor; }
            set { textColor = value; UpdateTextBox(); }
        }
        private Color textColor;

        /// <summary>
        /// Update text box when text changed.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            if (updating) return;
            Text = base.Text;
            base.OnTextChanged(e); //Trigger event after update Text property.
            UpdateTextBox();
        }

        /// <summary>
        /// TextBox Key Down event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control) ControlPressed = true;
            if (e.KeyCode == Keys.Delete)
            {
                if (base.Text == Hint)
                {
                    e.Handled = true;
                    return;
                }
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raise the Control.KeyUp Event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!e.Control) ControlPressed = false;
        }

        private bool ControlPressed = false;

        /// <summary>
        /// TextBox Key Press event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (ControlPressed) { base.OnKeyPress(e); return; }
            if ((base.Text == Hint))
            {
                e.Handled = true;
                if (e.KeyChar == (char)8) return;   //Delete Key
                if (e.KeyChar == (char)27) return;  //ESC Key
                text = e.KeyChar.ToString();
                UpdateTextBox();
                SelectionStart = text.Length;
                return;
            }
            base.OnKeyPress(e);
        }

        private bool updating = false;
        private void UpdateTextBox()
        {
            if (updating) return; //Prevent nested event especially when Text property changed.
            if (!componentInitialized) return; //Prevent overwrite to base property during component initialization.
            if (IsInDesignMode(this)) return; //Do not update component in design mode.

            updating = true;
            if (!string.IsNullOrEmpty(text))
            {
                base.ForeColor = textColor;
                base.PasswordChar = passwordChar;
                base.Text = text;
            }
            else if (!string.IsNullOrEmpty(hint))
            {
                base.ForeColor = hintForeColor;
                base.PasswordChar = '\0';
                base.Text = hint;
            }
            updating = false;
        }

        private static bool IsInDesignMode(IComponent component)
        {
            bool ret = false;
            if (null != component)
            {
                ISite site = component.Site;
                if (null != site)
                {
                    ret = site.DesignMode;
                }
                else if (component is System.Windows.Forms.Control)
                {
                    IComponent parent = ((System.Windows.Forms.Control)component).Parent;
                    ret = IsInDesignMode(parent);
                }
            }
            return ret;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HintedTextBox
            // 
            this.ResumeLayout(false);

        }
    }
}
