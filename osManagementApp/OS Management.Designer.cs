namespace osManagementApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            splitContainer1 = new SplitContainer();
            label2 = new Label();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(splitContainer1);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 426);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Size = new Size(776, 424);
            splitContainer1.SplitterDistance = 438;
            splitContainer1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(14, 141);
            label2.Name = "label2";
            label2.Size = new Size(402, 85);
            label2.TabIndex = 0;
            label2.Text = "OS management Dashboard";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.Location = new Point(39, 229);
            button3.Name = "button3";
            button3.Size = new Size(267, 48);
            button3.TabIndex = 3;
            button3.Text = "Input / Output Management";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(39, 42);
            button1.Name = "button1";
            button1.Size = new Size(267, 51);
            button1.TabIndex = 1;
            button1.Text = "File Management";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(39, 141);
            button2.Name = "button2";
            button2.Size = new Size(267, 49);
            button2.TabIndex = 2;
            button2.Text = "Process Management";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private SplitContainer splitContainer1;
        private Label label2;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}
