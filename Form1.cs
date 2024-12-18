﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winOsManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "DashBoard";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Files fileForm = new Files();
            fileForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Processes processesForm = new Processes();
            processesForm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeviceManagementForm deviceManagementForm = new DeviceManagementForm();
            deviceManagementForm.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ipcForm ipcform = new ipcForm();
            ipcform.ShowDialog();
            this.Show();
        }
    }
}
