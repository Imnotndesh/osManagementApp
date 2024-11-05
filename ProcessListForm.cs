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

namespace winOsManagement
{
    public partial class ProcessListForm : Form
    {
        private ListView processListView;
        private Button pauseProcessButton;
        private Button terminateProcessButton;
        private Button resumeProcessButton;
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool DebugActiveProcess(int dwProcessID);
        public ProcessListForm()
        {
            InitializeComponent();
            this.Text = "Running Processes";
            this.Size = new System.Drawing.Size(600, 400);

            processListView = new ListView();
            processListView.Dock = DockStyle.Top;
            processListView.View = View.Details;
            processListView.FullRowSelect = true;
            processListView.Height = 300;



            processListView.Columns.Add("Process Name", 200);
            processListView.Columns.Add("Process ID", 100);
            processListView.Columns.Add("Memory Usage (Kb)", 150);
            processListView.Columns.Add("Start Time", 150);


            pauseProcessButton = new Button();
            pauseProcessButton.Text = "Pause";
            pauseProcessButton.Location = new System.Drawing.Point(10, 320);
            pauseProcessButton.Click += PauseProcessButton_Click;

            terminateProcessButton = new Button();
            terminateProcessButton.Text = "Terminate";
            terminateProcessButton.Location = new System.Drawing.Point(100, 320);
            terminateProcessButton.Click += TerminateProcessButton_Click;

            resumeProcessButton = new Button();
            resumeProcessButton.Text = "Resume";
            resumeProcessButton.Location = new System.Drawing.Point(190, 320);
            resumeProcessButton.Click += ResumeProcessButton_Click;

            populateProcessList();
            Controls.Add(processListView);
            Controls.Add(pauseProcessButton);
            Controls.Add(terminateProcessButton);
            Controls.Add(resumeProcessButton);
        }
        private void populateProcessList()
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    try
                    {
                        string processName = process.ProcessName;
                        int processID = process.Id;
                        long memUsage = process.WorkingSet64 / 1024;
                        string startTime = process.StartTime.ToString();

                        ListViewItem item = new ListViewItem(processName);
                        item.SubItems.Add(processID.ToString());
                        item.SubItems.Add(memUsage.ToString());
                        item.SubItems.Add(startTime);
                        processListView.Items.Add(item);
                    }catch (Exception)
                    {

                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error fetching process list: " + ex.Message);
            }
        }
        private void ResumeProcessButton_Click(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count > 0)
            {
                int processID = int.Parse(processListView.SelectedItems[0].SubItems[1].Text);
                // TODO: add check if PID exists kwanza
                try
                {
                    Process process = Process.GetProcessById(processID);
                    ResumeProcess(process);
                    MessageBox.Show("Process resumed: " + process.ProcessName);
                }catch (Exception ex)
                {
                    MessageBox.Show("Unable to resume process: " + ex.Message);
                }
            }
        }

        private void TerminateProcessButton_Click(object sender, EventArgs e)
        {
            if(processListView.SelectedItems.Count > 0)
            {
                int processID = int.Parse(processListView.SelectedItems[0].SubItems[1].Text);
                // TODO: add check if PID exists kwanza

                try
                {
                    Process process = Process.GetProcessById(processID);
                    process.Kill();
                    MessageBox.Show("Process terminated: " + process.ProcessName);
                    processListView.Items.Clear();
                    populateProcessList();
                }catch (Exception ex)
                {
                    MessageBox.Show("Unable to terminate process: " + ex.Message);
                }
            }
        }

        private void PauseProcessButton_Click(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count > 0)
            {
                int processID = int.Parse(processListView.SelectedItems[0].SubItems[1].Text);
                // TODO: add check if PID exists kwanza
                try
                {
                    Process process = Process.GetProcessById(processID);
                    SuspendProcess(process);
                    MessageBox.Show("Process " + process.ProcessName + " paused!");
                }catch (Exception ex)
                {
                    MessageBox.Show("Unable to pause process: " + ex.Message);
                }
            }
        }
        private void SuspendProcess(Process process)
        {
            if (!DebugActiveProcess(process.Id))
            {
                throw new InvalidOperationException("Cannot suspend the process.");
            }
        }

        // Import kernel functions
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool DebugActiveProcessStop(int dwProcessID);

        private void ResumeProcess(Process process)
        {
            if (!DebugActiveProcessStop(process.Id))
            {
                throw new InvalidOperationException("Cannot resume the process.");
            }
        }
    }
}
