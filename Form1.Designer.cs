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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkSlateBlue;
            textBox1.ForeColor = Color.Gold;
            textBox1.Location = new Point(375, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(51, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.DarkSlateBlue;
            textBox2.ForeColor = Color.Gold;
            textBox2.Location = new Point(112, 50);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(51, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.DarkSlateBlue;
            textBox3.ForeColor = Color.Gold;
            textBox3.Location = new Point(245, 50);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(51, 27);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.DarkSlateBlue;
            textBox4.ForeColor = Color.Gold;
            textBox4.Location = new Point(705, 50);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(51, 27);
            textBox4.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSlateBlue;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = Color.Gold;
            button1.Location = new Point(1102, 50);
            button1.Name = "button1";
            button1.Size = new Size(106, 28);
            button1.TabIndex = 4;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(326, 54);
            label1.Name = "label1";
            label1.Size = new Size(20, 19);
            label1.TabIndex = 5;
            label1.Text = "R";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 54);
            label2.Name = "label2";
            label2.Size = new Size(26, 19);
            label2.TabIndex = 6;
            label2.Text = "x0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(196, 54);
            label3.Name = "label3";
            label3.Size = new Size(26, 19);
            label3.TabIndex = 7;
            label3.Text = "y0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(657, 54);
            label4.Name = "label4";
            label4.Size = new Size(20, 19);
            label4.TabIndex = 8;
            label4.Text = "C";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.DarkSlateBlue;
            comboBox1.ForeColor = Color.Gold;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Вертикальная", "Горизонтальная" });
            comboBox1.Location = new Point(457, 50);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(169, 27);
            comboBox1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(312, 124);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(897, 512);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.DarkSlateBlue;
            textBox5.ForeColor = Color.Gold;
            textBox5.Location = new Point(889, 50);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(141, 27);
            textBox5.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(788, 54);
            label5.Name = "label5";
            label5.Size = new Size(75, 19);
            label5.TabIndex = 12;
            label5.Text = "Точность";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 124);
            label6.Name = "label6";
            label6.Size = new Size(101, 19);
            label6.TabIndex = 13;
            label6.Text = "По формуле:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(52, 159);
            label7.Name = "label7";
            label7.Size = new Size(91, 19);
            label7.TabIndex = 14;
            label7.Text = "По методу:";
            // 
            // button2
            // 
            button2.BackColor = Color.DarkSlateBlue;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.ForeColor = Color.Gold;
            button2.Location = new Point(52, 218);
            button2.Name = "button2";
            button2.Size = new Size(106, 28);
            button2.TabIndex = 15;
            button2.Text = "Статистика";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.DarkSlateBlue;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripLabel2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(1287, 25);
            toolStrip1.TabIndex = 16;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.ActiveLinkColor = Color.White;
            toolStripLabel1.ForeColor = Color.Gold;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(53, 22);
            toolStripLabel1.Text = "Выйти";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.ActiveLinkColor = Color.White;
            toolStripLabel2.ForeColor = Color.Gold;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(67, 22);
            toolStripLabel2.Text = "Справка";
            toolStripLabel2.Click += toolStripLabel2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(1287, 687);
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
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = Color.DarkSlateBlue;
            HelpButton = true;
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
    }
}
