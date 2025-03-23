using ResumeEditor;
using ResumeEditor.Models;
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
using System.Windows.Shapes;

namespace WPF_Examen_21_03_2025.Views
{
    /// <summary>
    /// Логика взаимодействия для ResumeDateEntryOne.xaml
    /// </summary>
    public partial class ResumeDateEntryOne : Window
    {
        UserWorker worker = new UserWorker();
        public ResumeDateEntryOne(UserWorker userWorker)
        {
            InitializeComponent();
            if (userWorker != null)
            {
                worker = userWorker;
            }
            this.DataContext = worker;
        }

        private void Button_ClickBack(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_ClickLater(object sender, RoutedEventArgs e)
        {
            ResumeDateEntryTwo resumeDateEntryTwo = new ResumeDateEntryTwo(worker);
            resumeDateEntryTwo.Show();
            this.Close();
        }
    }
}
