namespace CodeArtEng.Controls
{
    partial class StatusLabel
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.imgStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Location = new System.Drawing.Point(16, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Padding = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.lbTitle.Size = new System.Drawing.Size(134, 16);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "<Title>";
            // 
            // imgStatus
            // 
            this.imgStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.imgStatus.Image = global::CodeArtEng.Controls.Properties.Resources.GreenDot;
            this.imgStatus.Location = new System.Drawing.Point(0, 0);
            this.imgStatus.Name = "imgStatus";
            this.imgStatus.Size = new System.Drawing.Size(16, 16);
            this.imgStatus.TabIndex = 0;
            this.imgStatus.TabStop = false;
            // 
            // StatusLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.imgStatus);
            this.MaximumSize = new System.Drawing.Size(999, 16);
            this.MinimumSize = new System.Drawing.Size(0, 16);
            this.Name = "StatusLabel";
            this.Size = new System.Drawing.Size(150, 16);
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgStatus;
        private System.Windows.Forms.Label lbTitle;
    }
}
