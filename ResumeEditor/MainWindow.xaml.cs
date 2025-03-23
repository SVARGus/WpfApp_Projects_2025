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
using ResumeEditor.Models;
using WPF_Examen_21_03_2025.Views;

namespace ResumeEditor
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
        private void Button_Click_ResumeForm(object sender, RoutedEventArgs e)
        {
            UserWorker userWorker = new UserWorker();
            Button clickedButton = sender as Button;
            switch(clickedButton.Name)
            {
                case "BtForm1":
                    userWorker.NumberForm = 1;
                    break;
                case "BtForm2":
                    userWorker.NumberForm = 2;
                    break;
                case "BtForm3":
                    userWorker.NumberForm = 3;
                    break;
                case "BtForm4":
                    userWorker.NumberForm = 4;
                    break;
                case "BtForm5":
                    userWorker.NumberForm = 5;
                    break;
                case "BtForm6":
                    userWorker.NumberForm = 6;
                    break;
            }
            ResumeDateEntryOne resumeDateEntryOne = new ResumeDateEntryOne(userWorker);
            resumeDateEntryOne.Show();
            this.Close();
        }
    }
}
