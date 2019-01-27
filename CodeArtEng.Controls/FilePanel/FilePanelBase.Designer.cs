namespace CodeArtEng.Controls
{
    partial class FilePanelBase
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
            this.textbox = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Padding = new System.Windows.Forms.Padding(7, 5, 0, 0);
            this.label.Size = new System.Drawing.Size(45, 22);
            this.label.TabIndex = 0;
            this.label.Text = "label";
            // 
            // textbox
            // 
            this.textbox.AllowDrop = true;
            this.textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox.Location = new System.Drawing.Point(45, 0);
            this.textbox.Margin = new System.Windows.Forms.Padding(4);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(352, 22);
            this.textbox.TabIndex = 1;
            this.textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.textbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.textbox_DragDrop);
            this.textbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.textbox_DragEnter);
            // 
            // btBrowse
            // 
            this.btBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btBrowse.Location = new System.Drawing.Point(397, 0);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btBrowse.MaximumSize = new System.Drawing.Size(31, 25);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(31, 25);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // FilePanelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.label);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FilePanelBase";
            this.Size = new System.Drawing.Size(428, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;

        /// <summary>
        /// File Panel Browse button
        /// </summary>
        protected System.Windows.Forms.Button btBrowse;
        /// <summary>
        /// File Panel path text box.
        /// </summary>
        protected System.Windows.Forms.TextBox textbox;
    }
}
