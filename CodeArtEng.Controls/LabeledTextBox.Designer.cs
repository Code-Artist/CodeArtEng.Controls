namespace CodeArtEng.Controls
{
    partial class LabeledTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.chkBox = new System.Windows.Forms.CheckBox();
            this.textbox = new CodeArtEng.Controls.HintedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textbox)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(15, 0);
            this.label.Name = "label";
            this.label.Padding = new System.Windows.Forms.Padding(2, 4, 0, 0);
            this.label.Size = new System.Drawing.Size(31, 17);
            this.label.TabIndex = 0;
            this.label.Text = "label";
            // 
            // chkBox
            // 
            this.chkBox.AutoSize = true;
            this.chkBox.Checked = true;
            this.chkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkBox.Location = new System.Drawing.Point(0, 0);
            this.chkBox.Name = "chkBox";
            this.chkBox.Size = new System.Drawing.Size(15, 20);
            this.chkBox.TabIndex = 2;
            this.chkBox.UseVisualStyleBackColor = true;
            this.chkBox.Visible = false;
            this.chkBox.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
            // 
            // textbox
            // 
            this.textbox.AllowDrop = true;
            this.textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox.Hint = null;
            this.textbox.Location = new System.Drawing.Point(46, 0);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(275, 20);
            this.textbox.TabIndex = 1;
            this.textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.textbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.textbox_DragDrop);
            this.textbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.textbox_DragEnter);
            // 
            // LabeledTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.chkBox);
            this.Name = "LabeledTextBox";
            this.Size = new System.Drawing.Size(321, 20);
            ((System.ComponentModel.ISupportInitialize)(this.textbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private CodeArtEng.Controls.HintedTextBox textbox;
        private System.Windows.Forms.CheckBox chkBox;
    }
}
