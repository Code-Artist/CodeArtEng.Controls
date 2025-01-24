namespace CodeArtEng.ControlsTest
{
    partial class Test2
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hintedTextBox1 = new CodeArtEng.Controls.HintedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.hintedTextBox2 = new CodeArtEng.Controls.HintedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.hintedTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hintedTextBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // hintedTextBox1
            // 
            this.hintedTextBox1.Hint = "Hint";
            this.hintedTextBox1.Location = new System.Drawing.Point(59, 29);
            this.hintedTextBox1.Name = "hintedTextBox1";
            this.hintedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.hintedTextBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // hintedTextBox2
            // 
            this.hintedTextBox2.Hint = "";
            this.hintedTextBox2.Location = new System.Drawing.Point(59, 3);
            this.hintedTextBox2.Name = "hintedTextBox2";
            this.hintedTextBox2.Size = new System.Drawing.Size(100, 20);
            this.hintedTextBox2.TabIndex = 4;
            // 
            // Test2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hintedTextBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hintedTextBox1);
            this.Name = "Test2";
            this.Text = "Test2";
            ((System.ComponentModel.ISupportInitialize)(this.hintedTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hintedTextBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.HintedTextBox hintedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private Controls.HintedTextBox hintedTextBox2;
    }
}