using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace winOsManagement
{
    public partial class LaunchProcessForm : Form
    {
        public LaunchProcessForm()
        {
            InitializeComponent();
            this.Text = "Launch a process";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userProcess = usrProcess.Text.Trim();
            if (!string.IsNullOrEmpty(userProcess))
            {
                Process existingProcess = FindProcess(userProcess);
                if (existingProcess == null)
                {
                    MessageBox.Show("Process is already running!");
                    bringProcessToFront(existingProcess);
                }
                else
                {
                    try
                    {
                        Process.Start(userProcess);
                        MessageBox.Show("Process " + userProcess + " started!");
                    }catch (Exception ex)
                    {
                        MessageBox.Show("Cannot start process: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a valid process Name!");
            }
        }
        private Process FindProcess(string processName)
        {
            return Process.GetProcessesByName(processName).FirstOrDefault();
        }

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWind);
        private void bringProcessToFront(Process process)
        {
            IntPtr handle = process.MainWindowHandle;
            if (handle != IntPtr.Zero)
            {
                SetForegroundWindow(handle);
            }
        }
    }
}
