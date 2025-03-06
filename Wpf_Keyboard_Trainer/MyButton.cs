using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_Keyboard_Trainer
{
    public class MyButton
    {
        public string BigValue { get; set; }
        public string SmallValue { get; set; }
        public Color Color { get; set; }
        public TextBlock TextBlock { get; set; }
        public Border Border { get; set; }
        public MyButton(Border border)
        {
            Border = border;
            TextBlock = border.Child as TextBlock;
            Color = (border.Background as SolidColorBrush).Color;
            if (char.IsLetter(TextBlock.Text[0]) && TextBlock.Text.Length == 1)
            {
                SmallValue = TextBlock.Text;
                BigValue = SmallValue.ToUpper();
            }
            else
            {
                SmallValue = TextBlock.Text;
                switch (SmallValue)
                {
                    case "`":
                        BigValue = "~";
                        break;
                    case "1":
                        BigValue = "!";
                        break;
                    case "2":
                        BigValue = "@";
                        break;
                    case "3":
                        BigValue = "#";
                        break;
                    case "4":
                        BigValue = "$";
                        break;
                    case "5":
                        BigValue = "%";
                        break;
                    case "6":
                        BigValue = "^";
                        break;
                    case "7":
                        BigValue = "&";
                        break;
                    case "8":
                        BigValue = "*";
                        break;
                    case "9":
                        BigValue = "(";
                        break;
                    case "0":
                        BigValue = ")";
                        break;
                    case "-":
                        BigValue = "_";
                        break;
                    case "=":
                        BigValue = "+";
                        break;
                    case "[":
                        BigValue = "{";
                        break;
                    case "]":
                        BigValue = "}";
                        break;
                    case "\\":
                        BigValue = "|";
                        break;
                    case ";":
                        BigValue = ":";
                        break;
                    case "'":
                        BigValue = "\"";
                        break;
                    case ",":
                        BigValue = "<";
                        break;
                    case ".":
                        BigValue = ">";
                        break;
                    case "/":
                        BigValue = "?";
                        break;
                    default:
                        BigValue = SmallValue;
                        break;

                }
            }
        }
    }
}
