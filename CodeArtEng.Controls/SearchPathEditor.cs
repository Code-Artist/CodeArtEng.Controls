using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Collections.Generic;
using System.Windows.Forms;

public class SearchPathsEditor : UITypeEditor
{
    private IWindowsFormsEditorService _editorService;

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
        return UITypeEditorEditStyle.Modal;
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
        if (provider != null)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
        }

        if (_editorService != null)
        {
            List<string> searchPaths = value as List<string>;

            using (Form form = new Form() { FormBorderStyle = FormBorderStyle.SizableToolWindow })
            {
                form.Text = "Edit Search Paths";
                ListBox listBox = new ListBox { Dock = DockStyle.Fill, SelectionMode = SelectionMode.MultiExtended };
                foreach (string path in searchPaths)
                {
                    listBox.Items.Add(path);
                }
                form.Controls.Add(listBox);

                Button addButton = new Button { Text = "Add", Dock = DockStyle.Bottom };
                addButton.Click += (sender, args) =>
                {
                    using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                    {
                        DialogResult result = folderDialog.ShowDialog();
                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                        {
                            listBox.Items.Add(folderDialog.SelectedPath);
                        }
                    }
                };
                form.Controls.Add(addButton);

                Button deleteButton = new Button { Text = "Delete", Dock = DockStyle.Bottom };
                deleteButton.Click += (sender, args) =>
                {
                    if (listBox.SelectedItem != null)
                    {
                        listBox.Items.Remove(listBox.SelectedItem);
                        if (listBox.Items.Count > 0) listBox.SelectedIndex = 0;
                    }
                };
                form.Controls.Add(deleteButton);

                Button okButton = new Button { Text = "OK", Dock = DockStyle.Bottom };
                okButton.Click += (sender, args) => form.DialogResult = DialogResult.OK;
                form.Controls.Add(okButton);

                form.Controls.Add(new StatusStrip());

                if (_editorService.ShowDialog(form) == DialogResult.OK)
                {
                    searchPaths.Clear();
                    foreach (string path in listBox.Items)
                    {
                        searchPaths.Add(path);
                    }
                }
            }
        }

        return value;
    }
}
