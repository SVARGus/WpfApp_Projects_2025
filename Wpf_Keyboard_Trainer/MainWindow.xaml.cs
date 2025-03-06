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
    
    public partial class MainWindow : Window
    {
        Dictionary<string, MyButton> ButtonDictionary = new Dictionary<string, MyButton>();
        private Stopwatch _stopwatch; // время потраченное на ввод текста
        int failureInputText = 0; // подсчет ошибок при вводе текста
        public MainWindow()
        {
            InitializeComponent();
            _stopwatch = new Stopwatch();
            CreatDictionary();
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
            const string chars = "`1234567890-=qwertyuiop[]asdfghjkl;'zxcvbnm,./ \\";
            const string charsMix = "`1234567890-=qwertyuiop[]asdfghjkl;'zxcvbnm,./QWERTYUIOPASDFGHJKLZXCVBNM~!@#$%^&*()_+{}:\"|?>< \\";
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
            InputText.Document.Blocks.Clear();
            //InputText.IsEnabled = true;
            btStart.IsEnabled = false;
            btStop.IsEnabled = true;
            string str = GenerateMixedCaseString(int.Parse(ValueDifficulty.Text));
            TextValue.Document.Blocks.Clear();
            TextValue.Document.Blocks.Add(new Paragraph(new Run(str)));
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

        private void VvodText_KeyUp(object sender, KeyEventArgs e)
        {
            if (ButtonDictionary.TryGetValue(e.Key.ToString(), out var button))
            {
                button.Border.Background = new SolidColorBrush(button.Color);
                if (e.Key == Key.LeftShift)
                {
                    ButtonDown();
                }
            }
        }
        private void ButtonDown()
        {
            foreach (var key in ButtonDictionary.Keys)
            {
                var myBotton = ButtonDictionary[key];
                myBotton.TextBlock.Text = myBotton.SmallValue;
            }
        }

        private void VvodText_KeyDown(object sender, KeyEventArgs e)
        {
            if (ButtonDictionary.TryGetValue(e.Key.ToString(), out var button))
            {
                switch (e.Key)
                {
                    case Key.Space:
                        InputText.Text += " "; // Исправить
                        break;
                    case Key.LeftShift:
                        ButtonUp();
                        break;
                    default:
                        InputText.Text += button.TextBlock.Text; // Исправить
                        break;
                }
                button.Border.Background = Brushes.LightGray;
            }
        }
        private void ButtonUp()
        {
            foreach (var key in ButtonDictionary.Keys)
            {
                var myBotton = ButtonDictionary[key];
                myBotton.TextBlock.Text = myBotton.BigValue;
            }
        }
        private void CreatDictionary()
        {
            foreach (var line in MainStackPanel.Children)
            {
                if (line is StackPanel)
                {
                    foreach (var linerOrderObject in (line as StackPanel).Children)
                    {
                        var myButton = new MyButton(linerOrderObject as Border);
                        if (char.IsDigit(myButton.SmallValue[0]))
                        {
                            ButtonDictionary.Add("D" + myButton.SmallValue, myButton);
                        }
                        else if (myButton.SmallValue.Length == 1)
                        {
                            ButtonDictionary.Add(myButton.BigValue, myButton);
                        }
                        else
                            ButtonDictionary.Add("LeftShift", myButton); // переделать
                    }
                }
                else
                {
                    ButtonDictionary.Add("Space", new MyButton(line as Border));
                }
            }
        }
    }
}
