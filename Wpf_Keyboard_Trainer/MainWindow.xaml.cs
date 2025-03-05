using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Wpf_Keyboard_Trainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch _stopwatch; // время потраченное на ввод текста
        int failureInputText = 0; // подсчет ошибок при вводе текста
        public MainWindow()
        {
            InitializeComponent();
            _stopwatch = new Stopwatch();
        }

        private void SliderDifficulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider select = sender as Slider;
            if(select != null)
            {
                ValueDifficulty.Text = select.Value.ToString();
            }
        }

        private string GenerateMixedCaseString(int length) // Генератор строки для ввода в верхнем и нижнем регистре
        {
            const string chars = "`1234567890-=qwertyuiop[]\asdfghjkl;'zxcvbnm,./";
            const string charsMix = "`1234567890-=qwertyuiop[]\asdfghjkl;'zxcvbnm,./QWERTYUIOPASDFGHJKLZXCVBNM";
            Random random = new Random();
            if(CaseSensetive.IsChecked == true) // Если нужно учитывать регистр
            {
                return new string(Enumerable.Repeat(charsMix, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            }
            else
            {
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            }
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            InputText.Text = string.Empty;
            InputText.IsEnabled = true;
            btStart.IsEnabled = false;
            btStop.IsEnabled = true;
            TextValue.Text = GenerateMixedCaseString(int.Parse(ValueDifficulty.Text));
            _stopwatch.Start();
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Stop();

            InputText.IsEnabled = false;
            btStart.IsEnabled = true;
            btStop.IsEnabled = false;
            TimeSpan elapsetTime = _stopwatch.Elapsed;
            double speed = (double.Parse(ValueDifficulty.Text) / elapsetTime.TotalSeconds) * 60;
            CountSpeed.Text = speed.ToString("F2");
        }
    }
}
