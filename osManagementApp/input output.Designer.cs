namespace osManagementApp
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(button4);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 392;
            splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(98, 50);
            button2.Name = "button2";
            button2.Size = new Size(265, 48);
            button2.TabIndex = 0;
            button2.Text = "Enable device";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(98, 122);
            button3.Name = "button3";
            button3.Size = new Size(265, 48);
            button3.TabIndex = 1;
            button3.Text = "List devices";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(98, 191);
            button4.Name = "button4";
            button4.Size = new Size(265, 53);
            button4.TabIndex = 2;
            button4.Text = "Disable device";
            button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(12, 155);
            label1.Name = "label1";
            label1.Size = new Size(337, 89);
            label1.TabIndex = 1;
            label1.Text = "Input / Output statement";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(259, 405);
            button1.Name = "button1";
            button1.Size = new Size(133, 33);
            button1.TabIndex = 3;
            button1.Text = "Back To Home";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form4";
            Text = "Form4";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Label label1;
        private Button button1;
    }
}