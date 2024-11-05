namespace osManagementApp
{
    partial class Form3
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
            Starting = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
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
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button5);
            splitContainer1.Panel2.Controls.Add(button4);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(Starting);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 440;
            splitContainer1.TabIndex = 0;
            // 
            // Starting
            // 
            Starting.Location = new Point(75, 12);
            Starting.Name = "Starting";
            Starting.Size = new Size(229, 39);
            Starting.TabIndex = 0;
            Starting.Text = "Starting";
            Starting.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(75, 75);
            button3.Name = "button3";
            button3.Size = new Size(229, 34);
            button3.TabIndex = 1;
            button3.Text = "Pausing";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(75, 136);
            button4.Name = "button4";
            button4.Size = new Size(229, 40);
            button4.TabIndex = 2;
            button4.Text = "Stoping";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(75, 207);
            button5.Name = "button5";
            button5.Size = new Size(229, 35);
            button5.TabIndex = 3;
            button5.Text = "Terminate";
            button5.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(75, 276);
            button2.Name = "button2";
            button2.Size = new Size(229, 27);
            button2.TabIndex = 1;
            button2.Text = "Viewing";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(205, 403);
            button1.Name = "button1";
            button1.Size = new Size(135, 35);
            button1.TabIndex = 4;
            button1.Text = "Back to home";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(30, 162);
            label1.Name = "label1";
            label1.Size = new Size(384, 81);
            label1.TabIndex = 0;
            label1.Text = "Process Management";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form3";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button Starting;
        private Button button2;
        private Label label1;
        private Button button1;
    }
}