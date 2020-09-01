using CodeArtEng.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;

namespace CodeArtEng.ControlsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fileExplorer1.AttachToMyComputer();
            fileExplorer1.FileDoubleClicked += new EventHandler<FileExplorerEventArgs>(fileExplorer1_FileDoubleClicked);
            //fileExplorer1.FolderSelect = true;
            propertyGrid1.SelectedObject = new PropertyGridTest();

            quickAccessList1.SearchPaths.Add("D:\\CKMAI_Documents\\Programming\\ClassLibraryNET\\CodeArtEng\\CodeArtEng.Controls\\CodeArtEng.Controls");
            quickAccessList1.SearchPaths.Add("D:/CKMAI_Documents/Programming/ClassLibraryNET/CodeArtEng/CodeArtEng.Controls/CodeArtEng.ControlsTest");
            quickAccessList1.SearchPaths.Add("NotExist");
            quickAccessList1.FileFilter = "*.cs";
            quickAccessList1.UpdateList();
            quickAccessList1.ItemClicked += QuickAccessList1_ItemClicked;

            //            richTextEditor1.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sapien faucibus et molestie ac feugiat sed lectus vestibulum mattis. Nunc sed augue lacus viverra vitae congue. Ultrices vitae auctor eu augue ut lectus. Sit amet massa vitae tortor condimentum lacinia quis vel eros. Sit amet consectetur adipiscing elit duis. Venenatis urna cursus eget nunc scelerisque viverra mauris in. Nibh venenatis cras sed felis eget velit. Tortor posuere ac ut consequat semper viverra nam libero. Integer malesuada nunc vel risus commodo viverra. Sagittis vitae et leo duis ut diam. Massa eget egestas purus viverra accumsan.

            //Elit eget gravida cum sociis natoque penatibus. Nam at lectus urna duis convallis convallis tellus. Phasellus vestibulum lorem sed risus ultricies tristique nulla aliquet. Commodo viverra maecenas accumsan lacus vel facilisis. Euismod in pellentesque massa placerat duis ultricies. Tellus integer feugiat scelerisque varius morbi. Laoreet id donec ultrices tincidunt. Duis ultricies lacus sed turpis tincidunt id aliquet risus. Pharetra et ultrices neque ornare aenean euismod elementum nisi quis. Feugiat sed lectus vestibulum mattis. Tellus id interdum velit laoreet id. Et molestie ac feugiat sed lectus. Egestas pretium aenean pharetra magna ac placerat. Leo urna molestie at elementum eu facilisis sed odio. Molestie ac feugiat sed lectus. Pulvinar sapien et ligula ullamcorper malesuada proin libero nunc. Sagittis id consectetur purus ut faucibus pulvinar. Fermentum et sollicitudin ac orci phasellus egestas tellus.

            //Quam id leo in vitae turpis massa sed elementum tempus. Vel fringilla est ullamcorper eget nulla. A diam maecenas sed enim ut sem viverra aliquet eget. Porta nibh venenatis cras sed felis. At lectus urna duis convallis convallis tellus id interdum. Eu consequat ac felis donec et odio pellentesque. Non nisi est sit amet facilisis magna etiam tempor orci. Interdum posuere lorem ipsum dolor sit amet. Ac turpis egestas integer eget. Penatibus et magnis dis parturient. Nulla porttitor massa id neque aliquam vestibulum. Ac turpis egestas integer eget aliquet nibh praesent tristique magna. Tincidunt ornare massa eget egestas purus viverra accumsan in. Placerat in egestas erat imperdiet sed. Vitae justo eget magna fermentum iaculis eu non diam phasellus. Amet luctus venenatis lectus magna fringilla urna porttitor rhoncus. Purus sit amet volutpat consequat. Porta nibh venenatis cras sed felis eget. Mollis nunc sed id semper risus in hendrerit gravida.

            //Proin sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Mauris vitae ultricies leo integer malesuada. Arcu risus quis varius quam quisque. Fermentum et sollicitudin ac orci phasellus. Pharetra pharetra massa massa ultricies mi quis. Lorem ipsum dolor sit amet consectetur adipiscing elit pellentesque habitant. In metus vulputate eu scelerisque felis imperdiet proin fermentum. Volutpat odio facilisis mauris sit amet. Fusce ut placerat orci nulla pellentesque dignissim enim. Sapien faucibus et molestie ac feugiat sed lectus vestibulum mattis. Mattis pellentesque id nibh tortor id aliquet. Feugiat vivamus at augue eget arcu dictum.

            //Enim nec dui nunc mattis enim ut. Aliquet nibh praesent tristique magna sit amet. Placerat duis ultricies lacus sed turpis tincidunt id aliquet risus. Sit amet consectetur adipiscing elit. Non sodales neque sodales ut etiam. Risus ultricies tristique nulla aliquet enim tortor. Elementum nibh tellus molestie nunc non blandit massa enim nec. Malesuada nunc vel risus commodo viverra maecenas accumsan. Non diam phasellus vestibulum lorem sed risus ultricies tristique nulla. Ut ornare lectus sit amet est placerat in egestas erat. Maecenas accumsan lacus vel facilisis volutpat est velit egestas dui. Sit amet venenatis urna cursus eget nunc. Sed sed risus pretium quam vulputate dignissim. Dolor magna eget est lorem ipsum dolor sit amet consectetur. Sit amet cursus sit amet dictum sit amet justo. Nunc sed augue lacus viverra vitae congue eu. Sed euismod nisi porta lorem mollis aliquam ut porttitor. In ornare quam viverra orci sagittis eu volutpat odio. Posuere morbi leo urna molestie at.";

        }

        private void QuickAccessList1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Debug.WriteLine("Item Clicked: " + e.ClickedItem.Tag.ToString());
            Process.Start(e.ClickedItem.Tag.ToString());
        }

        void fileExplorer1_FileDoubleClicked(object sender, Controls.FileExplorerEventArgs e)
        {
            Debug.WriteLine("File double clicked.");
            Debug.WriteLine("Files:");
            string[] files = fileExplorer1.SelectedFiles();
            foreach (string ptrFile in files) Debug.WriteLine(ptrFile);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static int ID = 0;
        private void addRecentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMruList1.AddRecentFileToMruList("C:\\Test_" + ID.ToString() + ".txt");
            ID++;
        }

        private void toolStripMruList1_RecentFileClicked(object sender, Controls.RecentFileClickedEventArgs e)
        {
            MessageBox.Show(e.FileName + " clicked.");
        }

        private void openFilePanel1_TextChanged(object sender, EventArgs e)
        {
            Trace.WriteLine("Text Changed: " + openFilePanel1.SelectedFile);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            multiLineButton1.Enabled = !multiLineButton1.Enabled;
        }

        private void badge1_Click(object sender, EventArgs e)
        {
        }

        private void multiLineButton2_Click(object sender, EventArgs e)
        {
            multiLineButton2.Image = Properties.Resources.CAELogoSmall;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Text :" + hintedTextBox1.Text;
        }

        private void btCmdLineDialog1_Click(object sender, EventArgs e)
        {
            CommandLineHelper cmdLine = new CommandLineHelper("Command Line Test 1");
            cmdLine.AddArgument("Source Path", "Source Folder Path");
            cmdLine.AddArgument("Dest Path", "Target Folder Path");
            cmdLine.AddSwitch("/MIN", "Minimize Windows");
            cmdLine.AddSwitch("/D", "Dummy");
            cmdLine.AddSwitch("/T", "Delay (ms)", "t");
            cmdLine.AddSwitch("/N", "Counter", "n");
            cmdLine.AddSwitch("/X", "Multi Choice Options", new string[] { "Choice1", "Choice2", "LastChoice" });

            cmdLine.SetArgument("Source Path", "C:\\Temp");
            cmdLine.SetArgument("Dest Path", "D:\\My Documents");
            cmdLine.SetSwitch("/D");
            cmdLine.PrintHelp();
            if (cmdLine.ShowDialog() == DialogResult.OK)
            {
                //Do Something if necessary
            }
        }

        private void labeledTextBox1_Enter(object sender, EventArgs e)
        {
            Trace.WriteLine("Entered label textbox.");
        }

        private void labeledTextBox1_Leave(object sender, EventArgs e)
        {
            Trace.WriteLine("Leaved label textbox.");
        }

        private void btCmdMacroEditor_Click(object sender, EventArgs e)
        {
            using (CommandMacroEditor editor = new CommandMacroEditor("Edit Form Testing..."))
            {
                editor.Command = "Command line...";
                editor.AddMacroPair("CMD1", "Command Value 1");
                editor.AddMacroPair("CMD2", "Command Value 2");
                editor.AddMacroPair("CMD3", "Command Value 3");
                editor.ShowDialog();

                Trace.WriteLine("Command: " + editor.Command);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbTextBox3.LabelAutoSize = true;
            lbTextBox3.LabelText = "Testing123";
            label2.Text = lbTextBox3.Text;
        }

        private void labeledTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                MessageBox.Show("Enter Pressed");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            labeledTextBox4.ReadOnly = !labeledTextBox4.ReadOnly;
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtMergeRichText_Click(object sender, EventArgs e)
        {
            string rtfText = RtfA.GetRtfText();
            RtfMerged.Append(RtfA.GetRtfText(), RtfB.GetRtfText());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Selected Folder: " + fileExplorer1.SelectedFolder);
            Debug.WriteLine("Selected Files: " + string.Join("\n", fileExplorer1.SelectedFiles()));
        }

        private void BtSetInitialFolder_Click(object sender, EventArgs e)
        {
            fileExplorer1.SetSelectedFolder(TxtInitialFolder.Text);
        }
    }

    public class PropertyGridTest
    {
        [Editor(typeof(TimePickerEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(DateTimeConverter2))]
        public DateTime TimePicker_DateTime { get; set; }
    }

}
