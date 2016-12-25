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
    /// TextBox control with hint.
    /// </summary>
    public class HintedTextBox : TextBox, ISupportInitialize
    {
        bool componentInitialized = false;

        public void BeginInit()
        {
            componentInitialized = false;
        }

        public void EndInit()
        {
            componentInitialized = true;
            UpdateTextBox();
        }

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

        private Color hintForeColor = Color.FromKnownColor(KnownColor.Gray);

        /// <summary>
        /// Hint Text
        /// </summary>
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

        [DefaultValue('\0')]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public new char PasswordChar
        {
            get { return PasswordChar; }
            set { passwordChar = value; UpdateTextBox(); }
        }
        private char passwordChar = '\0';

        [Browsable(true)]
        [Description("Text Color")]
        public new Color ForeColor
        {
            get { return textColor; }
            set { textColor = value;  UpdateTextBox(); }
        }
        private Color textColor;

        protected override void OnTextChanged(EventArgs e)
        {
            if (updating) return;
            Text = base.Text;
            base.OnTextChanged(e); //Trigger event after update Text property.
            UpdateTextBox();
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

    }
}
