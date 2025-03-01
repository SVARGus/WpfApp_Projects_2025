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
using System.Linq.Expressions;

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

        private void Button_Click_Num(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Viewbox viewbox = button.Content as Viewbox;
            TextBlock textBlock = viewbox.Child as TextBlock;
            string number = textBlock.Text;
            AddNum(number);
        }

        private void ButtonFloat_Click(object sender, RoutedEventArgs e)
        {
            // необходимо реализовать плавающий знак и защиту от двойной точки
        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
            Result();
            mathExpression.Text = string.Empty;
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            AddOperator("+");        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            AddOperator("-");
        }

        private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
        {
            AddOperator("*");
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            AddOperator("/");
        }

        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            string str = mathExpression.Text;
            char lastChar = str.Length > 0 ? str[str.Length - 1] : '\0';
            if (lastChar == '.')
            {
                mathExpression.Text = str.Remove(str.Length - 1);
            }
            // Если последний символ — цифра, добавляем " /"
            else if (char.IsDigit(lastChar))
            {
                mathExpression.Text = str.Remove(str.Length - 1);
            }
            str = mathExpression.Text;
            lastChar = str.Length > 0 ? str[str.Length - 1] : '\0';
            if (lastChar != '+' && lastChar != '-' && lastChar != '/' && lastChar != '*')
                Result();
            else
                result.Text = "0";
            if(str.Length == 0)
                result.Text = "0";
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            mathExpression.Text = string.Empty;
            result.Text = "0";
        }

        private void ButtonClearEntry_Click(object sender, RoutedEventArgs e)
        {
            string str = mathExpression.Text;
            if(string.IsNullOrEmpty(str))
            {
                result.Text = "0";
                return;
            }
            string pattern = @"\d+(\.\d+)?$";
            Match match = Regex.Match(str, pattern);

            if (match.Success)
            {
                str = str.Remove(match.Index, match.Length);
                str = str.TrimEnd();
                if(str.Length > 0)
                {
                    char lastChar = str[str.Length - 1];
                    if (lastChar == '+' || lastChar == '-' || lastChar == '/' || lastChar == '*')
                        str = str.Remove(str.Length - 1).TrimEnd();
                }
                mathExpression.Text = str;
            }
            Result();
        }
        private void Result() // Вычисление суммы
        {
            DataTable dt = new DataTable();
            var res = dt.Compute(mathExpression.Text, "");
            result.Text = res.ToString();
        }
        private void AddOperator(string operatorSymbol)
        {
            string str = mathExpression.Text;
            if (string.IsNullOrEmpty(str))
            {
                mathExpression.Text = "0" + operatorSymbol;
                return;
            }
            char lastChar = str.Length > 0 ? str[str.Length - 1] : '\0';
            if (lastChar == '+' || lastChar == '-' || lastChar == '/' || lastChar == '*')
                mathExpression.Text = str.Remove(str.Length - 1) + operatorSymbol;
            else if (lastChar == '.')
                mathExpression.Text = str.Remove(str.Length - 1) + operatorSymbol;
            else if (char.IsDigit(lastChar))
                mathExpression.Text += operatorSymbol;
        }
        private void AddNum(string operatorNum)
        {
            try
            {
                string str = mathExpression.Text;
                mathExpression.Text += operatorNum;
                Result();
            }
            catch
            {
                result.Text = "0";
            }
        }
    }
}
