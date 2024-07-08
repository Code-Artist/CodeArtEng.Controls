using CodeArtEng.Controls;
using System;
using System.IO;
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

            InitWebLauncher();
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

        private void openFilePanel1_SelectedFileChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Selected File Changed: " + openFilePanel1.SelectedFile);
        }

        private void folderBrowsePanel1_SelectedPathChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Selected Path Changed: " + folderBrowsePanel1.SelectedPath);
        }

        private void hintedTextBox1_TextChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Hinted Text Changed: " + hintedTextBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hintedTextBox1.Text = "Test String";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            resizableUserControl1.BeginResize();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            resizableUserControl1.EndResize();
        }

        #region [ Web Launcher Tests ]

        private WebLauncher WebLauncher;
        private const string WebLaunchCommand = "Launch Command: Operation Initiated";
        private string WebLauncherSettings = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "WebLauncher.txt");

        private void InitWebLauncher()
        {
            string passPhrase = string.Empty;
            if (File.Exists(WebLauncherSettings)) TxtWebLaunchPassPhrase.Text = passPhrase = File.ReadAllText(WebLauncherSettings);
            WebLauncher = new WebLauncher(TxtWebLaunchURLName.Text, Application.ExecutablePath, passPhrase);
        }

        private void BtUpdateWebLauncher_Click(object sender, EventArgs e)
        {
            File.WriteAllText(WebLauncherSettings, TxtWebLaunchPassPhrase.Text);
            InitWebLauncher();
        }

        private void BtWebLaunchRegisterURL_Click(object sender, EventArgs e)
        {
            WebLauncher.RegisterURLProtocol();
        }

        private void BtWebLaunchGenerateHTML_Click(object sender, EventArgs e)
        {
            string htmlCode = WebLauncher.GenerateLaunchLink("Launch Local Application", WebLaunchCommand);
            File.WriteAllText("WebLaunch.html", htmlCode);
            Process.Start("WebLaunch.html");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                Trace.WriteLine("Input Argument: " + args[1]);
                string command = WebLauncher.DecodeUrlCommand(args[1]);
                Trace.WriteLine("URL Command: " + command);

                if (!string.IsNullOrEmpty(command))
                {
                    if (command.Equals(WebLaunchCommand)) { MessageBox.Show("Web Launch command success!"); }
                    else MessageBox.Show("URL Command mismatched, received: " + command);
                }
            }
        }

        #endregion

    }

    public class PropertyGridTest
    {
        [Editor(typeof(TimePickerEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(DateTimeConverter2))]
        public DateTime TimePicker_DateTime { get; set; }
    }

}
