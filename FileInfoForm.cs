using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace winOsManagement
{
    public partial class FileInfoForm : Form
    {
        private ListView fileInfoListView;
        public FileInfoForm(string filePath)
        {
            InitializeComponent();
            this.Text = "File Information";
            this.Size = new System.Drawing.Size(400, 300);
            fileInfoListView = new ListView();
            fileInfoListView.Dock = DockStyle.Fill;
            fileInfoListView.View = View.Details;
            fileInfoListView.Columns.Add("Property", 150);
            fileInfoListView.Columns.Add("Value", 200);
            AddFileInfo(filePath);
            Controls.Add(fileInfoListView);
        }
        private void AddFileInfo(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            fileInfoListView.Items.Add(new ListViewItem(new[] { "File Name", fileInfo.Name }));
            fileInfoListView.Items.Add(new ListViewItem(new[] { "File Path", fileInfo.FullName }));
            fileInfoListView.Items.Add(new ListViewItem(new[] { "File Size", fileInfo.Length.ToString() }));
            fileInfoListView.Items.Add(new ListViewItem(new[] { "Creation Time", fileInfo.CreationTime.ToString() }));
            fileInfoListView.Items.Add(new ListViewItem(new[] { "Last Access Time", fileInfo.LastAccessTime.ToString() }));
            fileInfoListView.Items.Add(new ListViewItem(new[] { "Is Read Only", fileInfo.IsReadOnly.ToString() }));
        }
    }
}
