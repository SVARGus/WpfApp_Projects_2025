using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Wpf_Calculator
{
    /// <summary>
    /// Логика взаимодействия для CalculatorWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        public CalculatorWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFloat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            if(Regex.IsMatch(mathExpression.Text, @"[\+\-\*/]"))
            {
                string result = mathExpression.Text.Remove(mathExpression.Text.Length - 1) + "/";
                mathExpression.Text = result;
            }
        }

        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            mathExpression.Text = string.Empty;
            result.Text = "0";
        }

        private void ButtonClearEntry_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Result() // Вычисление суммы
        {
            DataTable dt = new DataTable();
            var res = dt.Compute(mathExpression.Text, "");
            result.Text = res.ToString();
        }
    }
}
