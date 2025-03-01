using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Class_work_p2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> resultTest = new List<int>() { 0, 0, 0, 0, 0 };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton select = (RadioButton)sender;
            if(select.Content.ToString() == "Лосяш")
            {
                resultTest[0] = 1;
            }
            else
            {
                resultTest[0] = 0;
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            RadioButton select = (RadioButton)sender;
            if (select.Content.ToString() == "Крош")
            {
                resultTest[1] = 1;
            }
            else
            {
                resultTest[1] = 0;
            }
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            RadioButton select = (RadioButton)sender;
            if (select.Content.ToString() == "Копатыч")
            {
                resultTest[2] = 1;
            }
            else
            {
                resultTest[2] = 0;
            }
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            RadioButton select = (RadioButton)sender;
            if (select.Content.ToString() == "Нюша")
            {
                resultTest[3] = 1;
            }
            else
            {
                resultTest[3] = 0;
            }
        }
        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            RadioButton select = (RadioButton)sender;
            if (select.Content.ToString() == "Совунья")
            {
                resultTest[4] = 1;
            }
            else
            {
                resultTest[4] = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = resultTest.Sum();
            string messageTest;
            if (result > 0 && result < 3)
                messageTest = "Новичек";
            else if (result > 2 && result < 5)
                messageTest = "Знаток";
            else if (result == 5)
                messageTest = "Эксперт";
            else
                messageTest = "Error";
            MessageBox.Show(messageTest);
        }
    }
}
