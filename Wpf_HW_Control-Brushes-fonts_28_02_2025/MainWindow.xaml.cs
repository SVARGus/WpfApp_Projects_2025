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

namespace Wpf_HW_Control_Brushes_fonts_28_02_2025
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ARGB_Slider_ValueChanged_Background(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider select = sender as Slider;
            if(select != null)
            {
                if (select.Name == "ARGBaSlider" && ARGBaValue != null)
                {
                    ARGBaValue.Text = select.Value.ToString();
                }
                else if(select.Name == "ARGBrSlider" && ARGBrValue != null)
                {
                    ARGBrValue.Text = select.Value.ToString();
                }
                else if (select.Name == "ARGBgSlider" && ARGBgValue != null)
                {
                    ARGBgValue.Text = select.Value.ToString();
                }
                else if (select.Name == "ARGBbSlider" && ARGBbValue != null)
                {
                    ARGBbValue.Text = select.Value.ToString();
                }
            }
            UpdateBackgroundColor();
        }
        private void UpdateBackgroundColor() // Обновление цвета фона после изменений
        {
            byte a = (byte)ARGBaSlider.Value;
            byte r = (byte)ARGBrSlider.Value;
            byte g = (byte)ARGBgSlider.Value;
            byte b = (byte)ARGBbSlider.Value;
            Color backgroundColor = Color.FromArgb(a, r, g, b);
            testText.Background = new SolidColorBrush(backgroundColor);
            selectARGB.Text = testText.Background.ToString();
        }
    }
}
