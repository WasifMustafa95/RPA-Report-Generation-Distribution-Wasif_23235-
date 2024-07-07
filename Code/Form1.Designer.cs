namespace ReportGenerationRPA
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            richTextBox1 = new RichTextBox();
            checkBox4 = new CheckBox();
            checkBox6 = new CheckBox();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            label3 = new Label();
            richTextBox2 = new RichTextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(243, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(414, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(243, 81);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(414, 27);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 31);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 2;
            label1.Text = "Link";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 84);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 3;
            label2.Text = "Search by Name";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(60, 208);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(236, 24);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Checking the file in Downloads";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(60, 277);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(171, 24);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Downloading the file";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(60, 348);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(253, 24);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "Searching inside the file by Name";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(379, 154);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(534, 376);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(60, 415);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(183, 24);
            checkBox4.TabIndex = 8;
            checkBox4.Text = "Saving the file in Azure";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(60, 483);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(167, 24);
            checkBox6.TabIndex = 10;
            checkBox6.Text = "Connecting Power Bi";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(718, 58);
            button1.Name = "button1";
            button1.Size = new Size(119, 56);
            button1.TabIndex = 12;
            button1.Text = "Go";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(60, 130);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(236, 42);
            progressBar1.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(60, 612);
            label3.Name = "label3";
            label3.Size = new Size(331, 32);
            label3.TabIndex = 14;
            label3.Text = "Azure blob file generated link";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(426, 605);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(487, 53);
            richTextBox2.TabIndex = 15;
            richTextBox2.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 742);
            Controls.Add(richTextBox2);
            Controls.Add(label3);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(checkBox6);
            Controls.Add(checkBox4);
            Controls.Add(richTextBox1);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private RichTextBox richTextBox1;
        private CheckBox checkBox4;
        private CheckBox checkBox6;
        private Button button1;
        private ProgressBar progressBar1;
        private Label label3;
        private RichTextBox richTextBox2;
    }
}
