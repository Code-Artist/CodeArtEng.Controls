using System;
using System.Windows.Forms;

namespace ToolStripMruListDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripMruList1.RecentFileList = Properties.Settings.Default.MRUList.Split(';');
        }

        private static int ID = 0;
        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMruList1.AddRecentFileToMruList("C:\\Test_" + ID.ToString() + ".txt");
            ID++;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MRUList = string.Join(";", toolStripMruList1.RecentFileList);
            Properties.Settings.Default.Save();
        }

        private void toolStripMruList1_RecentFileClicked(object sender, CodeArtEng.Controls.RecentFileClickedEventArgs e)
        {
            MessageBox.Show("File " + e.FileName + " clicked.");
        }
    }
}
