using ResumeEditor;
using ResumeEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для ResumeDateEntryTwo.xaml
    /// </summary>
    public partial class ResumeDateEntryTwo : Window
    {
        private UserWorker worker = new UserWorker();
        public ResumeDateEntryTwo(UserWorker userWorker)
        {
            worker = userWorker;
            this.DataContext = worker;
            InitializeComponent();
        }
        private void Button_ClickBack(object sender, RoutedEventArgs e)
        {
            ResumeDateEntryOne resumeDateEntryOne = new ResumeDateEntryOne(worker);
            resumeDateEntryOne.Show();
            this.Close();
        }

        private void Button_ClickLater(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = new TextBox[]
            {
                CompanyWork,
                PositionWork,
                DescriptionLastWork
            };

            if (textBoxes.Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
            {
                MessageBox.Show("Заполните все поля перед продолжением!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            ResumeDateEntryThree resumeDateEntryThree = new ResumeDateEntryThree(worker);
            resumeDateEntryThree.Show();
            this.Close();
        }

        private void Button_Click_NewResume(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
