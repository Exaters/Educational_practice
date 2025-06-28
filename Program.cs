using Education_Practice;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Education_practice
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            SplashScreen splash = new SplashScreen();
            splash.Show();
            Application.DoEvents(); // ��������� ����
            Thread.Sleep(3000); // ��� 3 �������
            splash.Close();

            Application.Run(new MainWindow());
        }
    }
}