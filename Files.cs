using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace winOsManagement
{
    public partial class Files : Form
    {
        public Files()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using  (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Enter a file name to save:";
                saveFileDialog.Filter = "All Files (*.*) |*.*| Text Files (*.txt)|*.txt";
                saveFileDialog.DefaultExt = "txt";

                DialogResult dialog = saveFileDialog.ShowDialog();
                if (dialog == DialogResult.OK)
                {
                    string filepath = saveFileDialog.FileName;
                    try
                    {
                        using (FileStream fs = File.Create(filepath)) { }
                        Console.WriteLine("Blank File created at: " + filepath);
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Error creating file: "+ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("No filename was provided.");
                }
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to Delete";
                openFileDialog.Filter = "All files (*.*)|*.*";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filepath = openFileDialog.FileName;
                    try
                    {
                        DialogResult deleteResult = MessageBox.Show("Are you sure you want to delete this file?", "Confirm Delete", MessageBoxButtons.YesNo);
                        if(deleteResult == DialogResult.Yes)
                        {
                            if (File.Exists(filepath))
                            {
                                File.Delete(filepath);
                                Console.WriteLine("File deleted Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("File does not exist");
                            }
                        }
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("No file was selected.");
                }
            }
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file";
                openFileDialog.Filter = "All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = openFileDialog.FileName;
                    FileInfoForm fileinfoform = new FileInfoForm(filepath);
                    fileinfoform.ShowDialog();
                }
            }
         
        }
    }
}
