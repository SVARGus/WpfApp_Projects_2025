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

        private void FontSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider select = sender as Slider;
            if(select != null && FontSizeValue != null)
            {
                FontSizeValue.Text = select.Value.ToString();
                testTextTB.FontSize = select.Value;
            }
        }

        private void ARGBColorTextSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider select = sender as Slider;
            if (select != null)
            {
                if (select.Name == "ARGBaColorTextSlider" && ARGBaColorTextValue != null)
                {
                    ARGBaColorTextValue.Text = select.Value.ToString();
                }
                else if(select.Name == "ARGBrColorTextSlider" && ARGBrColorTextValue != null)
                {
                    ARGBrColorTextValue.Text = select.Value.ToString();
                }
                else if (select.Name == "ARGBgColorTextSlider" && ARGBgColorTextValue != null)
                {
                    ARGBgColorTextValue.Text = select.Value.ToString();
                }
                else if (select.Name == "ARGBbColorTextSlider" && ARGBbColorTextValue != null)
                {
                    ARGBbColorTextValue.Text = select.Value.ToString();
                }
            }
            UpdateForeground();
        }

        private void UpdateForeground()
        {
            byte a = (byte)ARGBaColorTextSlider.Value;
            byte r = (byte)ARGBrColorTextSlider.Value;
            byte g = (byte)ARGBgColorTextSlider.Value;
            byte b = (byte)ARGBbColorTextSlider.Value;
            Color fontColor = Color.FromArgb(a, r, g, b);
            testTextTB.Foreground = new SolidColorBrush(fontColor);
        }

        private void Button_Click_FontFamily(object sender, RoutedEventArgs e)
        {
            Button select = sender as Button;
            if(select != null)
            {
                testTextTB.FontFamily = new FontFamily(select.Content.ToString());
            }
        }

        private void Button_Click_FontWeight(object sender, RoutedEventArgs e)
        {
            Button select = sender as Button;
            if (select != null)
            {
                testTextTB.FontWeight = select.FontWeight;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string backgroundColor = ((BackgroundComboBox.SelectedItem as Grid).Children[0] as Label).Background.ToString();
            SetColorTextSlider(backgroundColor);
        }

        private void setARGB_Click(object sender, RoutedEventArgs e)
        {
            SetColorTextSlider(selectARGB.Text);
        }
        private void SetColorTextSlider(string backgroundColor)
        {
            if(!string.IsNullOrEmpty(backgroundColor) && backgroundColor.StartsWith("#") && backgroundColor.Length == 9)
            {
                try
                {
                    string hexColor = backgroundColor.Substring(1);
                    byte a = Convert.ToByte(hexColor.Substring(0, 2), 16);
                    byte r = Convert.ToByte(hexColor.Substring(2, 2), 16);
                    byte g = Convert.ToByte(hexColor.Substring(4, 2), 16);
                    byte b = Convert.ToByte(hexColor.Substring(6, 2), 16);
                    Color newBackgroundColor = Color.FromArgb(a, r, g, b);
                    testText.Background = new SolidColorBrush(newBackgroundColor);
                    selectARGB.Text = testText.Background.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при парсинге цвета: {ex.Message}");
                }
            }
            // Можно добавить парсинг других форматов: RGB кодировка (#RRGGBB), строка является именованным цветом, RGB в формате строки (rgb(255, 0, 0))
            // Но в рамках учебного проекта другие форматы будут опущены
            else
            {
                MessageBox.Show("Не корректный формат цвета");
            }
        }
    }
}
