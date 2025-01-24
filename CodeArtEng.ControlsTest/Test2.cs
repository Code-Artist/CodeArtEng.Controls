using System;
using System.Windows.Forms;

namespace CodeArtEng.ControlsTest
{
    public partial class Test2 : Form
    {
        public Test2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = hintedTextBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hintedTextBox1.Text = string.Empty;
            hintedTextBox2.Text = string.Empty;
        }
    }
}
