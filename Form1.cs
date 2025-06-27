namespace UPv1
{
    public partial class Form1 : Form
    {


        public enum LineType
        {
            Vertical,
            Horizontal
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper.InitializeDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double x0 = 2.0; // x-���������� ������ ����������
            double y0 = 0.0; // y-���������� ������ ����������
            double R = 3.0; // ������ ����������
            double distance = -2.0; // ���������� �� ��� Y � ������������ ������
            try
            {
                R = double.Parse(this.textBox1.Text);
                x0 = double.Parse(this.textBox2.Text);
                y0 = double.Parse(this.textBox3.Text);
                distance = double.Parse(this.textBox4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("�� ���������� ������ ������");
                return;
            }


            if (this.comboBox1.Text.Equals("��������������"))
            {
                // ��������� ������� �������� ��������`
                double areaByFormula = CalculateCircleSegmentArea(R, x0, y0, distance, LineType.Horizontal);
                this.label6.Text = "�� �������: " + areaByFormula;
                double areaByMonteCarlo = this.CalculateCircleSegmentAreaMonteCarlo(R, x0, y0, distance, LineType.Horizontal);
                this.label7.Text = "�� ������: " + areaByMonteCarlo;

                DatabaseHelper.AddResult(x0, y0, R, distance, "��������������", int.Parse(this.textBox5.Text), areaByFormula, areaByMonteCarlo);


            }
            else
            {
                // ��������� ������� �������� ��������`
                double areaByFormula = CalculateCircleSegmentArea(R, x0, y0, distance, LineType.Vertical);
                this.label6.Text = "�� �������: " + areaByFormula;
                double areaByMonteCarlo = this.CalculateCircleSegmentAreaMonteCarlo(R, x0, y0, distance, LineType.Vertical);
                this.label7.Text = "�� ������: " + areaByMonteCarlo;
                DatabaseHelper.AddResult(x0, y0, R, distance, "������������", int.Parse(this.textBox5.Text), areaByFormula, areaByMonteCarlo);

            }

            // ��������� ������� ������� �����-�����
            //MessageBox.Show($"������� �������� �������� (������� �����-�����): {areaByMonteCarlo}");

            pictureBox1.Invalidate();

        }


        private static double CalculateCircleSegmentArea(double R, double x0, double y0, double distance, LineType lineType)
        {
            double areaCircle = Math.PI * R * R;

            if (lineType == LineType.Vertical)
            {
                double xLine = distance;

                // ��������, ���������� �� ������ ���� ��� ��������� ��������� ������
                if (xLine >= x0 + R || xLine <= x0 - R)
                {
                    return areaCircle; // ���� ����
                }
                else
                {
                    // ���������� ������� ��� ������� ��������
                    // ������������, ��� areaCircle ��� ���������
                    double segmentHeight = Math.Sqrt(R * R - Math.Pow(xLine - x0, 2));
                    double leftArea = areaCircle - (R * R * Math.Acos((xLine - x0) / R)) + (xLine - x0) * segmentHeight;

                    // ������ ��������� ������� �������� ��������
                    double rightArea = areaCircle - leftArea; // ������� �������� ��������

                    if (rightArea >= leftArea)
                    {
                        return rightArea;
                    }

                    return leftArea; // ���������� ������� �������� ��������

                }
            }
            else if (lineType == LineType.Horizontal)
            {
                double yLine = distance;

                // ��������, ���������� �� ������ ���� ��� ��������� ��������� ����
                if (yLine >= y0 + R || yLine <= y0 - R)
                {
                    return areaCircle; // ���� ����
                }
                else
                {
                    // ���������� ������� ��� ������� ��������
                    // ������������, ��� areaCircle ��� ���������
                    if (yLine >= y0 + R)
                    {
                        return 0; // ����� ��������� ���� �����
                    }
                    else if (yLine <= y0 - R)
                    {
                        return areaCircle; // ����� ��������� ���� �����
                    }

                    // ��������� ������ ��������
                    double segmentHeight = Math.Sqrt(R * R - Math.Pow(yLine - y0, 2));

                    // ������� ������ �������� (�����)
                    double leftArea = areaCircle - (R * R * Math.Acos((yLine - y0) / R)) + (yLine - y0) * segmentHeight;

                    // ������� �������� �������� (������)
                    double rightArea = areaCircle - leftArea;

                    // ���������� ������� �������
                    return Math.Max(leftArea, rightArea);
                }
            }

            return 0; // � ���� ����� ��������� ������ ������������ � �������������� ������
        }

        // ����� ��� ���������� ������� �������� �������� ������� �����-�����
        private double CalculateCircleSegmentAreaMonteCarlo(double R, double x0, double y0, double distance, LineType lineType)
        {
            int leftArea = 0;
            int rightArea = 0;
            int totalPoints = 100000;

            try
            {
                totalPoints = int.Parse(this.textBox5.Text);
                if (totalPoints > 10000000)
                {
                    MessageBox.Show("������� ������� �����");
                    return 0.0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("�������� ������ ������");
                return 0.0;
            }

            Random rand = new Random();

            // ���������� ������� ��������������, ������� �������� ����
            double minX = x0 - R;
            double maxX = x0 + R;
            double minY = y0 - R;
            double maxY = y0 + R;

            for (int i = 0; i < totalPoints; i++)
            {
                // ��������� ��������� ����� (x, y) � �������� ������
                double x = minX + rand.NextDouble() * (maxX - minX); // ���������� ��������� �������� x
                double y = minY + rand.NextDouble() * (maxY - minY); // ���������� ��������� �������� y

                // �������� �� ��������� ����� ������ �����
                bool inCircle = Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2) <= R * R;

                // �������� �� ��������� ������������ ����� � ����������� �� ����
                bool aboveLine = (lineType == LineType.Vertical) ? (x >= distance) : (y >= distance);

                // ���������, ����� ��� �������� �������
                if (inCircle && aboveLine)
                {
                    rightArea++;
                }

                aboveLine = (lineType == LineType.Vertical) ? (x < distance) : (y < distance);

                if (inCircle && aboveLine)
                {
                    leftArea++;
                }
            }

            // ������� ��������������� ��������������: (2 * R) * (2 * R)
            double rectangleArea = (2 * R) * (2 * R);

            // ������� ��������
            if (rightArea >= leftArea)
            {
                return (double)rightArea / totalPoints * rectangleArea;
            }
            return (double)leftArea / totalPoints * rectangleArea;
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            double x0 = 2.0; // x-���������� ������ ����������
            double y0 = 0.0; // y-���������� ������ ����������
            double R = 3.0; // ������ ����������
            double distance = -2.0; // ���������� �� ��� Y � ������������ ������
            try
            {
                R = double.Parse(this.textBox1.Text);
                x0 = double.Parse(this.textBox2.Text);
                y0 = double.Parse(this.textBox3.Text);
                distance = double.Parse(this.textBox4.Text);
            }
            catch (Exception)
            {
                x0 = 2.0;
                y0 = 0.0;
                R = 3.0;
                distance = -2.0;
            }

            if (this.comboBox1.Text.Equals("��������������"))
            {
                DrawCircleAndLine(e.Graphics, R, x0, y0, distance, LineType.Horizontal);
            }
            else
            {
                DrawCircleAndLine(e.Graphics, R, x0, y0, distance, LineType.Vertical);
            }

            // ��������� ��������� ����� �����-�����, ���� ��� ����
            DrawMonteCarloPoints(e.Graphics, R, x0, y0, distance);
        }

        // ����� ����� ��� ��������� ����� �����-�����
        private void DrawMonteCarloPoints(Graphics g, double R, double x0, double y0, double distance)
        {
            const float format = 40;
            int totalPoints = 1000; // ����� ��������� ���������� ����� ��� ������������

            try
            {
                totalPoints = int.Parse(this.textBox5.Text);
                if (totalPoints > 10000) totalPoints = 10000; // ������������ ��� ������������������
            }
            catch { }

            Random rand = new Random();
            double minX = x0 - R;
            double maxX = x0 + R;
            double minY = y0 - R;
            double maxY = y0 + R;

            // ����������, ����� ������� ������ (�����/������ ��� �������/������)
            bool isHorizontal = this.comboBox1.Text.Equals("��������������");
            double areaLeft = 0, areaRight = 0;

            for (int i = 0; i < totalPoints; i++)
            {
                double x = minX + rand.NextDouble() * (maxX - minX);
                double y = minY + rand.NextDouble() * (maxY - minY);

                bool inCircle = Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2) <= R * R;
                bool onBigSide = isHorizontal ? (y >= distance) : (x >= distance);

                // ���������� ��� ���������
                float drawX = (float)(x * format) + (pictureBox1.Width / 2);
                float drawY = (pictureBox1.Height / 2) - (float)(y * format);

                if (inCircle)
                {
                    // ������� ����� ��� ����������� ������� �������
                    if (onBigSide) areaRight++;
                    else areaLeft++;

                    // ����� �� ������� ������� - �������, �� ������� - �������
                    Brush pointBrush = (areaRight > areaLeft && onBigSide) ||
                                     (areaLeft > areaRight && !onBigSide)
                                     ? Brushes.Red : Brushes.Green;

                    g.FillEllipse(pointBrush, drawX - 2, drawY - 2, 4, 4);
                }
                else
                {
                    // ����� ��� ����� - �����
                    g.FillEllipse(Brushes.LightGray, drawX - 2, drawY - 2, 4, 4);
                }
            }
        }

        // ����������� ����� DrawCircleAndLine
        private void DrawCircleAndLine(Graphics g, double R, double x0, double y0, double distance, LineType lineType)
        {
            const float format = 40;

            // ������ �����
            DrawGrid(g, pictureBox1.ClientSize);

            // ������ ��� ���������
            g.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            g.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);

            float startX = (float)(x0 * format);
            float startY = (float)(y0 * format);
            float diameter = (float)(2 * R);
            g.DrawEllipse(Pens.Blue,
                ((pictureBox1.Width / 2) - diameter * format / 2) + startX,
                ((pictureBox1.Height / 2) - diameter * format / 2) - startY,
                diameter * format,
                diameter * format);

            // ������ �����
            if (lineType == LineType.Horizontal)
            {
                float lineY = (pictureBox1.Height / 2) - (float)(distance * format);
                g.DrawLine(Pens.Red, 0, lineY, pictureBox1.Width, lineY);
            }
            else
            {
                float lineX = (pictureBox1.Width / 2) + (float)(distance * format);
                g.DrawLine(Pens.Red, lineX, 0, lineX, pictureBox1.Height);
            }
        }

        private void DrawGrid(Graphics g, Size size)
        {
            Pen gridPen = new Pen(Color.LightGray);

            // ������ ������������ ����� �����
            for (int x = 0; x < size.Width; x += 20)
            {
                g.DrawLine(gridPen, x, 0, x, size.Height);
            }
            // ������ �������������� ����� �����
            for (int y = 0; y < size.Height; y += 20)
            {
                g.DrawLine(gridPen, 0, y, size.Width, y);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();

        }
    }
}
