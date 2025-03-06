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
        private int failureInputText = 0; // подсчет ошибок при вводе текста
        private bool isCapsLock = false; // Флаг нажатия CapsLock

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
            InputText.Focusable = true;
            InputText.Focus();
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
                if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
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
                string newText = "";
                switch (e.Key)
                {
                    case Key.Space:
                        newText = " ";
                        break;
                    case Key.Back: // Обработка удаления последнего символа
                        RemoveLastCharacter(InputText); // Метод удаления последнего символа
                        CompareTexts(); // Метод Обновления сравнения
                        break;
                    case Key.RightShift:
                    case Key.LeftShift:
                        ButtonUp();
                        break;
                    case Key.CapsLock:
                        ToggleCapsLock(); // Метод индикации нажатия CapsLock
                        break;
                    case Key.Tab:
                    case Key.LeftCtrl:
                    case Key.RightCtrl:
                    case Key.LeftAlt:
                    case Key.RightAlt:
                    case Key.Enter:
                        button.Border.Background = Brushes.Red;
                        return;
                    default:
                        newText = button.TextBlock.Text;
                        break;
                }
                if(!string.IsNullOrEmpty(newText))
                {
                    InsertTextAtCaret(InputText, newText); // Метод вставки символа в строку
                    CompareTexts(); // Метод Обновления сравнения
                }
                button.Border.Background = Brushes.Red;
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
                        {
                            switch (myButton.SmallValue)
                            {
                                case "Shift":
                                    if (ButtonDictionary.ContainsKey("LeftShift"))
                                        ButtonDictionary.Add("RightShift", myButton);
                                    else
                                        ButtonDictionary.Add("LeftShift", myButton);
                                    break;
                                case "CapsLock":
                                    ButtonDictionary.Add("CapsLock", myButton);
                                    break;
                                case "Backspace":
                                    ButtonDictionary.Add("Back", myButton);
                                    break;
                                case "Enter":
                                    ButtonDictionary.Add("Enter", myButton);
                                    break;
                                case "Alt":
                                    if (ButtonDictionary.ContainsKey("LeftAlt"))
                                        ButtonDictionary.Add("RightAlt", myButton);
                                    else
                                        ButtonDictionary.Add("LeftAlt", myButton);
                                    break;
                                case "Ctrl":
                                    if (ButtonDictionary.ContainsKey("LeftCtrl"))
                                        ButtonDictionary.Add("RightCtrl", myButton);
                                    else
                                        ButtonDictionary.Add("LeftCtrl", myButton);
                                    break;
                                case "Win":
                                    if (ButtonDictionary.ContainsKey("LeftWin"))
                                        ButtonDictionary.Add("RightWin", myButton);
                                    else
                                        ButtonDictionary.Add("LeftWin", myButton);
                                    break;
                                case "Tab":
                                    ButtonDictionary.Add("Tab", myButton);
                                    break;
                                case "Space":
                                    ButtonDictionary.Add("Space", myButton);
                                    break;
                                default:
                                    //ButtonDictionary.Add(myButton.SmallValue, myButton);
                                    break;
                            }
                        }    
                    }
                }
                else
                {
                    ButtonDictionary.Add("Space", new MyButton(line as Border));
                }
            }
        }

        private void ToggleCapsLock()
        {
            isCapsLock = !isCapsLock;
            foreach (var key in ButtonDictionary.Keys)
            {
                var myButton = ButtonDictionary[key];
                myButton.TextBlock.Text = isCapsLock ? myButton.BigValue : myButton.SmallValue;
            }
        }

        private void InsertTextAtCaret(RichTextBox richTextBox, string text) // Метод вставки символа в строку
        {
            if (string.IsNullOrEmpty(text))
                return;
            TextPointer caretPosition = richTextBox.CaretPosition;
            richTextBox.CaretPosition.InsertTextInRun(text);
            richTextBox.CaretPosition = richTextBox.CaretPosition.GetPositionAtOffset(text.Length, LogicalDirection.Forward);
        }

        private void RemoveLastCharacter(RichTextBox richTextBox) // Удаление последнего символа
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            string currentText = textRange.Text;

            if (!string.IsNullOrEmpty(currentText))
            {
                richTextBox.Document.Blocks.Clear();
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(currentText.Substring(0, currentText.Length - 1))));
            }
        }

        private void CompareTexts() // Окрашивание текста при сравнении
        {
            string expectedText = new TextRange(TextValue.Document.ContentStart, TextValue.Document.ContentEnd).Text.Trim();
            string userText = new TextRange(InputText.Document.ContentStart, InputText.Document.ContentEnd).Text.Trim();

            ResetFormatting(InputText);
            ResetFormatting(TextValue);

            int minLength = Math.Min(expectedText.Length, userText.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (expectedText[i] == userText[i])
                {
                    HighlightCharacterAtOffset(InputText, i, Colors.LightGreen);
                    HighlightCharacterAtOffset(TextValue, i, Colors.LightGreen);
                }
                else
                {
                    HighlightCharacterAtOffset(InputText, i, Colors.LightCoral);
                    HighlightCharacterAtOffset(TextValue, i, Colors.LightCoral);
                }
            }
        }

        private void HighlightCharacterAtOffset(RichTextBox rtb, int offset, Color highlightColor) // Окрашивание конкретного символа
        {
            TextPointer start = rtb.Document.ContentStart.GetPositionAtOffset(offset, LogicalDirection.Forward);
            if (start != null)
            {
                TextPointer end = start.GetPositionAtOffset(1, LogicalDirection.Forward);
                if (end != null)
                {
                    TextRange charRange = new TextRange(start, end);
                    charRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(highlightColor));
                }
            }
        }

        private void ResetFormatting(RichTextBox rtb) // сброс окрашивания
        {
            new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd)
                .ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Transparent);
        }
    }
}
