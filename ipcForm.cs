using System;
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
    public partial class ipcForm : Form
    {
        public ipcForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SocketIPCForm socketForm = new SocketIPCForm();
            socketForm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PipeDemoForm pdf = new PipeDemoForm();
            pdf.ShowDialog();
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Hide();
        }
    }
}
