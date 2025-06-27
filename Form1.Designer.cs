namespace UPv1
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
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            pictureBox1 = new PictureBox();
            textBox5 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button2 = new Button();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(333, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(46, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(100, 53);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(46, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(217, 53);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(46, 27);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(627, 53);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(46, 27);
            textBox4.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(980, 52);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(290, 56);
            label1.Name = "label1";
            label1.Size = new Size(18, 20);
            label1.TabIndex = 5;
            label1.Text = "R";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 56);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 6;
            label2.Text = "x0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(174, 56);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 7;
            label3.Text = "y0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(584, 56);
            label4.Name = "label4";
            label4.Size = new Size(18, 20);
            label4.TabIndex = 8;
            label4.Text = "C";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Вертикальная", "Горизонтальная" });
            comboBox1.Location = new Point(407, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(277, 131);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(797, 539);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(790, 53);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(700, 56);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 12;
            label5.Text = "Точность";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 131);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 13;
            label6.Text = "По формуле:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(47, 168);
            label7.Name = "label7";
            label7.Size = new Size(85, 20);
            label7.TabIndex = 14;
            label7.Text = "По методу:";
            // 
            // button2
            // 
            button2.Location = new Point(47, 229);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 15;
            button2.Text = "Статистика";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripLabel2, toolStripProgressBar1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1144, 25);
            toolStrip1.TabIndex = 16;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(53, 22);
            toolStripLabel1.Text = "Выйти";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(67, 22);
            toolStripLabel2.Text = "Справка";
            toolStripLabel2.Click += toolStripLabel2_Click;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 22);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 722);
            Controls.Add(toolStrip1);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(pictureBox1);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private PictureBox pictureBox1;
        private TextBox textBox5;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button2;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}
