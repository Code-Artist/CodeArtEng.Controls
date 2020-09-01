namespace CodeArtEng.Controls
{
    partial class RichTextEditor
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
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.ToolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtBold = new System.Windows.Forms.Button();
            this.BtItalic = new System.Windows.Forms.Button();
            this.BtUnderline = new System.Windows.Forms.Button();
            this.CbFonts = new System.Windows.Forms.ComboBox();
            this.CbFontSize = new System.Windows.Forms.ComboBox();
            this.BtFontColor = new System.Windows.Forms.Button();
            this.BtBrushColor = new System.Windows.Forms.Button();
            this.BtBullet = new System.Windows.Forms.Button();
            this.BtIncreaseIndent = new System.Windows.Forms.Button();
            this.BtDecreaseIndent = new System.Windows.Forms.Button();
            this.BtAlignLeft = new System.Windows.Forms.Button();
            this.BtAlignCenter = new System.Windows.Forms.Button();
            this.BtAlignRight = new System.Windows.Forms.Button();
            this.BtCut = new System.Windows.Forms.Button();
            this.BtCopy = new System.Windows.Forms.Button();
            this.BtPaste = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ToolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.HideSelection = false;
            this.TextBox.Location = new System.Drawing.Point(0, 31);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(676, 314);
            this.TextBox.TabIndex = 0;
            this.TextBox.Text = "";
            this.TextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TextBox_LinkClicked);
            this.TextBox.SelectionChanged += new System.EventHandler(this.TextBox_SelectionChanged);
            this.TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.AutoSize = true;
            this.ToolsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ToolsPanel.Controls.Add(this.BtBold);
            this.ToolsPanel.Controls.Add(this.BtItalic);
            this.ToolsPanel.Controls.Add(this.BtUnderline);
            this.ToolsPanel.Controls.Add(this.CbFonts);
            this.ToolsPanel.Controls.Add(this.CbFontSize);
            this.ToolsPanel.Controls.Add(this.BtFontColor);
            this.ToolsPanel.Controls.Add(this.BtBrushColor);
            this.ToolsPanel.Controls.Add(this.BtBullet);
            this.ToolsPanel.Controls.Add(this.BtIncreaseIndent);
            this.ToolsPanel.Controls.Add(this.BtDecreaseIndent);
            this.ToolsPanel.Controls.Add(this.BtAlignLeft);
            this.ToolsPanel.Controls.Add(this.BtAlignCenter);
            this.ToolsPanel.Controls.Add(this.BtAlignRight);
            this.ToolsPanel.Controls.Add(this.BtCut);
            this.ToolsPanel.Controls.Add(this.BtCopy);
            this.ToolsPanel.Controls.Add(this.BtPaste);
            this.ToolsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolsPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Padding = new System.Windows.Forms.Padding(3);
            this.ToolsPanel.Size = new System.Drawing.Size(676, 31);
            this.ToolsPanel.TabIndex = 1;
            // 
            // BtBold
            // 
            this.BtBold.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtBold.Location = new System.Drawing.Point(3, 3);
            this.BtBold.Margin = new System.Windows.Forms.Padding(0);
            this.BtBold.Name = "BtBold";
            this.BtBold.Size = new System.Drawing.Size(25, 25);
            this.BtBold.TabIndex = 0;
            this.BtBold.Text = "B";
            this.BtBold.UseVisualStyleBackColor = true;
            this.BtBold.Click += new System.EventHandler(this.BtBold_Click);
            // 
            // BtItalic
            // 
            this.BtItalic.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtItalic.Location = new System.Drawing.Point(28, 3);
            this.BtItalic.Margin = new System.Windows.Forms.Padding(0);
            this.BtItalic.Name = "BtItalic";
            this.BtItalic.Size = new System.Drawing.Size(25, 25);
            this.BtItalic.TabIndex = 1;
            this.BtItalic.Text = "I";
            this.BtItalic.UseVisualStyleBackColor = true;
            this.BtItalic.Click += new System.EventHandler(this.BtItalic_Click);
            // 
            // BtUnderline
            // 
            this.BtUnderline.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtUnderline.Location = new System.Drawing.Point(53, 3);
            this.BtUnderline.Margin = new System.Windows.Forms.Padding(0);
            this.BtUnderline.Name = "BtUnderline";
            this.BtUnderline.Size = new System.Drawing.Size(25, 25);
            this.BtUnderline.TabIndex = 2;
            this.BtUnderline.Text = "U";
            this.BtUnderline.UseVisualStyleBackColor = true;
            this.BtUnderline.Click += new System.EventHandler(this.BtUnderline_Click);
            // 
            // CbFonts
            // 
            this.CbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFonts.FormattingEnabled = true;
            this.CbFonts.Location = new System.Drawing.Point(81, 5);
            this.CbFonts.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.CbFonts.Name = "CbFonts";
            this.CbFonts.Size = new System.Drawing.Size(134, 21);
            this.CbFonts.TabIndex = 3;
            this.CbFonts.SelectedIndexChanged += new System.EventHandler(this.CbFonts_SelectedIndexChanged);
            // 
            // CbFontSize
            // 
            this.CbFontSize.FormattingEnabled = true;
            this.CbFontSize.Location = new System.Drawing.Point(217, 5);
            this.CbFontSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.CbFontSize.Name = "CbFontSize";
            this.CbFontSize.Size = new System.Drawing.Size(49, 21);
            this.CbFontSize.TabIndex = 4;
            this.CbFontSize.Text = "9.99";
            this.CbFontSize.SelectedIndexChanged += new System.EventHandler(this.CbFontSize_SelectedIndexChanged);
            this.CbFontSize.TextUpdate += new System.EventHandler(this.CbFontSize_TextUpdate);
            // 
            // BtFontColor
            // 
            this.BtFontColor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtFontColor.Location = new System.Drawing.Point(268, 3);
            this.BtFontColor.Margin = new System.Windows.Forms.Padding(0);
            this.BtFontColor.Name = "BtFontColor";
            this.BtFontColor.Size = new System.Drawing.Size(25, 25);
            this.BtFontColor.TabIndex = 5;
            this.BtFontColor.Text = "A";
            this.BtFontColor.UseVisualStyleBackColor = true;
            this.BtFontColor.Click += new System.EventHandler(this.BtFontColor_Click);
            // 
            // BtBrushColor
            // 
            this.BtBrushColor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtBrushColor.Image = global::CodeArtEng.Controls.Properties.Resources.Paint;
            this.BtBrushColor.Location = new System.Drawing.Point(293, 3);
            this.BtBrushColor.Margin = new System.Windows.Forms.Padding(0);
            this.BtBrushColor.Name = "BtBrushColor";
            this.BtBrushColor.Size = new System.Drawing.Size(25, 25);
            this.BtBrushColor.TabIndex = 6;
            this.BtBrushColor.UseVisualStyleBackColor = true;
            this.BtBrushColor.Click += new System.EventHandler(this.BtBrushColor_Click);
            // 
            // BtBullet
            // 
            this.BtBullet.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtBullet.Image = global::CodeArtEng.Controls.Properties.Resources.Bullet;
            this.BtBullet.Location = new System.Drawing.Point(324, 3);
            this.BtBullet.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.BtBullet.Name = "BtBullet";
            this.BtBullet.Size = new System.Drawing.Size(25, 25);
            this.BtBullet.TabIndex = 7;
            this.BtBullet.UseVisualStyleBackColor = true;
            this.BtBullet.Click += new System.EventHandler(this.BtBullet_Click);
            // 
            // BtIncreaseIndent
            // 
            this.BtIncreaseIndent.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtIncreaseIndent.Image = global::CodeArtEng.Controls.Properties.Resources.IncreaseIndent;
            this.BtIncreaseIndent.Location = new System.Drawing.Point(349, 3);
            this.BtIncreaseIndent.Margin = new System.Windows.Forms.Padding(0);
            this.BtIncreaseIndent.Name = "BtIncreaseIndent";
            this.BtIncreaseIndent.Size = new System.Drawing.Size(25, 25);
            this.BtIncreaseIndent.TabIndex = 8;
            this.BtIncreaseIndent.UseVisualStyleBackColor = true;
            this.BtIncreaseIndent.Click += new System.EventHandler(this.BtIncreaseIndent_Click);
            // 
            // BtDecreaseIndent
            // 
            this.BtDecreaseIndent.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtDecreaseIndent.Image = global::CodeArtEng.Controls.Properties.Resources.DecreaseIndent;
            this.BtDecreaseIndent.Location = new System.Drawing.Point(374, 3);
            this.BtDecreaseIndent.Margin = new System.Windows.Forms.Padding(0);
            this.BtDecreaseIndent.Name = "BtDecreaseIndent";
            this.BtDecreaseIndent.Size = new System.Drawing.Size(25, 25);
            this.BtDecreaseIndent.TabIndex = 9;
            this.BtDecreaseIndent.UseVisualStyleBackColor = true;
            this.BtDecreaseIndent.Click += new System.EventHandler(this.BtDecreaseIndent_Click);
            // 
            // BtAlignLeft
            // 
            this.BtAlignLeft.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAlignLeft.Image = global::CodeArtEng.Controls.Properties.Resources.LeftAlign;
            this.BtAlignLeft.Location = new System.Drawing.Point(405, 3);
            this.BtAlignLeft.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.BtAlignLeft.Name = "BtAlignLeft";
            this.BtAlignLeft.Size = new System.Drawing.Size(25, 25);
            this.BtAlignLeft.TabIndex = 10;
            this.BtAlignLeft.UseVisualStyleBackColor = true;
            this.BtAlignLeft.Click += new System.EventHandler(this.BtAlignLeft_Click);
            // 
            // BtAlignCenter
            // 
            this.BtAlignCenter.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAlignCenter.Image = global::CodeArtEng.Controls.Properties.Resources.CenterAlign;
            this.BtAlignCenter.Location = new System.Drawing.Point(430, 3);
            this.BtAlignCenter.Margin = new System.Windows.Forms.Padding(0);
            this.BtAlignCenter.Name = "BtAlignCenter";
            this.BtAlignCenter.Size = new System.Drawing.Size(25, 25);
            this.BtAlignCenter.TabIndex = 11;
            this.BtAlignCenter.UseVisualStyleBackColor = true;
            this.BtAlignCenter.Click += new System.EventHandler(this.BtAlignCenter_Click);
            // 
            // BtAlignRight
            // 
            this.BtAlignRight.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAlignRight.Image = global::CodeArtEng.Controls.Properties.Resources.RightAlign;
            this.BtAlignRight.Location = new System.Drawing.Point(455, 3);
            this.BtAlignRight.Margin = new System.Windows.Forms.Padding(0);
            this.BtAlignRight.Name = "BtAlignRight";
            this.BtAlignRight.Size = new System.Drawing.Size(25, 25);
            this.BtAlignRight.TabIndex = 12;
            this.BtAlignRight.UseVisualStyleBackColor = true;
            this.BtAlignRight.Click += new System.EventHandler(this.BtAlignRight_Click);
            // 
            // BtCut
            // 
            this.BtCut.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCut.Image = global::CodeArtEng.Controls.Properties.Resources.CutHS;
            this.BtCut.Location = new System.Drawing.Point(486, 3);
            this.BtCut.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.BtCut.Name = "BtCut";
            this.BtCut.Size = new System.Drawing.Size(25, 25);
            this.BtCut.TabIndex = 13;
            this.BtCut.UseVisualStyleBackColor = true;
            this.BtCut.Click += new System.EventHandler(this.BtCut_Click);
            // 
            // BtCopy
            // 
            this.BtCopy.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCopy.Image = global::CodeArtEng.Controls.Properties.Resources.CopyHS;
            this.BtCopy.Location = new System.Drawing.Point(511, 3);
            this.BtCopy.Margin = new System.Windows.Forms.Padding(0);
            this.BtCopy.Name = "BtCopy";
            this.BtCopy.Size = new System.Drawing.Size(25, 25);
            this.BtCopy.TabIndex = 14;
            this.BtCopy.UseVisualStyleBackColor = true;
            this.BtCopy.Click += new System.EventHandler(this.BtCopy_Click);
            // 
            // BtPaste
            // 
            this.BtPaste.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtPaste.Image = global::CodeArtEng.Controls.Properties.Resources.PasteHS;
            this.BtPaste.Location = new System.Drawing.Point(536, 3);
            this.BtPaste.Margin = new System.Windows.Forms.Padding(0);
            this.BtPaste.Name = "BtPaste";
            this.BtPaste.Size = new System.Drawing.Size(25, 25);
            this.BtPaste.TabIndex = 15;
            this.BtPaste.UseVisualStyleBackColor = true;
            this.BtPaste.Click += new System.EventHandler(this.BtPaste_Click);
            // 
            // RichTextEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.ToolsPanel);
            this.Name = "RichTextEditor";
            this.Size = new System.Drawing.Size(676, 345);
            this.ToolsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.FlowLayoutPanel ToolsPanel;
        private System.Windows.Forms.Button BtBold;
        private System.Windows.Forms.Button BtItalic;
        private System.Windows.Forms.Button BtUnderline;
        private System.Windows.Forms.ComboBox CbFonts;
        private System.Windows.Forms.ComboBox CbFontSize;
        private System.Windows.Forms.Button BtFontColor;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button BtBrushColor;
        private System.Windows.Forms.Button BtBullet;
        private System.Windows.Forms.Button BtIncreaseIndent;
        private System.Windows.Forms.Button BtDecreaseIndent;
        private System.Windows.Forms.Button BtAlignLeft;
        private System.Windows.Forms.Button BtAlignCenter;
        private System.Windows.Forms.Button BtAlignRight;
        private System.Windows.Forms.Button BtCut;
        private System.Windows.Forms.Button BtCopy;
        private System.Windows.Forms.Button BtPaste;
    }
}
