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

            double x0 = 2.0; // x-координата центра окружности
            double y0 = 0.0; // y-координата центра окружности
            double R = 3.0; // радиус окружности
            double distance = -2.0; // расстояние от оси Y к вертикальной прямой
            try
            {
                R = double.Parse(this.textBox1.Text);
                x0 = double.Parse(this.textBox2.Text);
                y0 = double.Parse(this.textBox3.Text);
                distance = double.Parse(this.textBox4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Не правильный формат данных");
                return;
            }


            if (this.comboBox1.Text.Equals("Горизонтальная"))
            {
                // Вычисляем площадь большого сегмента`
                double areaByFormula = CalculateCircleSegmentArea(R, x0, y0, distance, LineType.Horizontal);
                this.label6.Text = "По формуле: " + areaByFormula;
                double areaByMonteCarlo = this.CalculateCircleSegmentAreaMonteCarlo(R, x0, y0, distance, LineType.Horizontal);
                this.label7.Text = "По методу: " + areaByMonteCarlo;

                DatabaseHelper.AddResult(x0, y0, R, distance, "Горизонтальная", int.Parse(this.textBox5.Text), areaByFormula, areaByMonteCarlo);


            }
            else
            {
                // Вычисляем площадь большого сегмента`
                double areaByFormula = CalculateCircleSegmentArea(R, x0, y0, distance, LineType.Vertical);
                this.label6.Text = "По формуле: " + areaByFormula;
                double areaByMonteCarlo = this.CalculateCircleSegmentAreaMonteCarlo(R, x0, y0, distance, LineType.Vertical);
                this.label7.Text = "По методу: " + areaByMonteCarlo;
                DatabaseHelper.AddResult(x0, y0, R, distance, "Вертикальная", int.Parse(this.textBox5.Text), areaByFormula, areaByMonteCarlo);

            }

            // Вычисляем площадь методом Монте-Карло
            //MessageBox.Show($"Площадь большого сегмента (методом Монте-Карло): {areaByMonteCarlo}");

            pictureBox1.Invalidate();

        }


        private static double CalculateCircleSegmentArea(double R, double x0, double y0, double distance, LineType lineType)
        {
            double areaCircle = Math.PI * R * R;

            if (lineType == LineType.Vertical)
            {
                double xLine = distance;

                // Проверка, пересекает ли прямая круг или полностью находится справа
                if (xLine >= x0 + R || xLine <= x0 - R)
                {
                    return areaCircle; // весь круг
                }
                else
                {
                    // Используем формулу для площади сегмента
                    // Предполагаем, что areaCircle уже вычислена
                    double segmentHeight = Math.Sqrt(R * R - Math.Pow(xLine - x0, 2));
                    double leftArea = areaCircle - (R * R * Math.Acos((xLine - x0) / R)) + (xLine - x0) * segmentHeight;

                    // Теперь вычисляем площадь большого сегмента
                    double rightArea = areaCircle - leftArea; // Площадь большого сегмента

                    if (rightArea >= leftArea)
                    {
                        return rightArea;
                    }

                    return leftArea; // Возвращаем площадь большого сегмента

                }
            }
            else if (lineType == LineType.Horizontal)
            {
                double yLine = distance;

                // Проверка, пересекает ли прямая круг или полностью находится выше
                if (yLine >= y0 + R || yLine <= y0 - R)
                {
                    return areaCircle; // весь круг
                }
                else
                {
                    // Используем формулу для площади сегмента
                    // Предполагаем, что areaCircle уже вычислена
                    if (yLine >= y0 + R)
                    {
                        return 0; // Линия полностью выше круга
                    }
                    else if (yLine <= y0 - R)
                    {
                        return areaCircle; // Линия полностью ниже круга
                    }

                    // Вычисляем высоту сегмента
                    double segmentHeight = Math.Sqrt(R * R - Math.Pow(yLine - y0, 2));

                    // Площадь малого сегмента (левый)
                    double leftArea = areaCircle - (R * R * Math.Acos((yLine - y0) / R)) + (yLine - y0) * segmentHeight;

                    // Площадь большого сегмента (правый)
                    double rightArea = areaCircle - leftArea;

                    // Возвращаем большую площадь
                    return Math.Max(leftArea, rightArea);
                }
            }

            return 0; // В этом месте обработан только вертикальный и горизонтальный случай
        }

        // Метод для вычисления площади большого сегмента методом Монте-Карло
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
                    MessageBox.Show("Слишком длинное число");
                    return 0.0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный формат данных");
                return 0.0;
            }

            Random rand = new Random();

            // Определяем границы прямоугольника, который содержит круг
            double minX = x0 - R;
            double maxX = x0 + R;
            double minY = y0 - R;
            double maxY = y0 + R;

            for (int i = 0; i < totalPoints; i++)
            {
                // Генерация случайной точки (x, y) в пределах границ
                double x = minX + rand.NextDouble() * (maxX - minX); // Генерируем случайное значение x
                double y = minY + rand.NextDouble() * (maxY - minY); // Генерируем случайное значение y

                // Проверка на попадание точки внутрь круга
                bool inCircle = Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2) <= R * R;

                // Проверка на попадание относительно линии в зависимости от типа
                bool aboveLine = (lineType == LineType.Vertical) ? (x >= distance) : (y >= distance);

                // Проверьте, чтобы обе проверки истинны
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

            // Площадь ограничивающего прямоугольника: (2 * R) * (2 * R)
            double rectangleArea = (2 * R) * (2 * R);

            // Площадь сегмента
            if (rightArea >= leftArea)
            {
                return (double)rightArea / totalPoints * rectangleArea;
            }
            return (double)leftArea / totalPoints * rectangleArea;
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            double x0 = 2.0; // x-координата центра окружности
            double y0 = 0.0; // y-координата центра окружности
            double R = 3.0; // радиус окружности
            double distance = -2.0; // расстояние от оси Y к вертикальной прямой
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

            if (this.comboBox1.Text.Equals("Горизонтальная"))
            {
                DrawCircleAndLine(e.Graphics, R, x0, y0, distance, LineType.Horizontal);
            }
            else
            {
                DrawCircleAndLine(e.Graphics, R, x0, y0, distance, LineType.Vertical);
            }

            // Добавляем отрисовку точек Монте-Карло, если они есть
            DrawMonteCarloPoints(e.Graphics, R, x0, y0, distance);
        }

        // Новый метод для отрисовки точек Монте-Карло
        private void DrawMonteCarloPoints(Graphics g, double R, double x0, double y0, double distance)
        {
            const float format = 40;
            int totalPoints = 1000; // Можно уменьшить количество точек для визуализации

            try
            {
                totalPoints = int.Parse(this.textBox5.Text);
                if (totalPoints > 10000) totalPoints = 10000; // Ограничиваем для производительности
            }
            catch { }

            Random rand = new Random();
            double minX = x0 - R;
            double maxX = x0 + R;
            double minY = y0 - R;
            double maxY = y0 + R;

            // Определяем, какая сторона больше (левая/правая или верхняя/нижняя)
            bool isHorizontal = this.comboBox1.Text.Equals("Горизонтальная");
            double areaLeft = 0, areaRight = 0;

            for (int i = 0; i < totalPoints; i++)
            {
                double x = minX + rand.NextDouble() * (maxX - minX);
                double y = minY + rand.NextDouble() * (maxY - minY);

                bool inCircle = Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2) <= R * R;
                bool onBigSide = isHorizontal ? (y >= distance) : (x >= distance);

                // Координаты для отрисовки
                float drawX = (float)(x * format) + (pictureBox1.Width / 2);
                float drawY = (pictureBox1.Height / 2) - (float)(y * format);

                if (inCircle)
                {
                    // Подсчет точек для определения большей стороны
                    if (onBigSide) areaRight++;
                    else areaLeft++;

                    // Точки на большей стороне - красные, на меньшей - зеленые
                    Brush pointBrush = (areaRight > areaLeft && onBigSide) ||
                                     (areaLeft > areaRight && !onBigSide)
                                     ? Brushes.Red : Brushes.Green;

                    g.FillEllipse(pointBrush, drawX - 2, drawY - 2, 4, 4);
                }
                else
                {
                    // Точки вне круга - серые
                    g.FillEllipse(Brushes.LightGray, drawX - 2, drawY - 2, 4, 4);
                }
            }
        }

        // Обновленный метод DrawCircleAndLine
        private void DrawCircleAndLine(Graphics g, double R, double x0, double y0, double distance, LineType lineType)
        {
            const float format = 40;

            // Рисуем сетку
            DrawGrid(g, pictureBox1.ClientSize);

            // Рисуем оси координат
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

            // Рисуем линию
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

            // Рисуем вертикальные линии сетки
            for (int x = 0; x < size.Width; x += 20)
            {
                g.DrawLine(gridPen, x, 0, x, size.Height);
            }
            // Рисуем горизонтальные линии сетки
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
