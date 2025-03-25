using ResumeEditor;
using ResumeEditor.Controls;
using ResumeEditor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WPF_Examen_21_03_2025.Views
{
    /// <summary>
    /// Логика взаимодействия для ResumeDateEntryFinal.xaml
    /// </summary>
    public partial class ResumeDateEntryFinal : Window
    {
        private UserWorker worker = new UserWorker();
        public ResumeDateEntryFinal(UserWorker userWorker)
        {
            worker = userWorker;
            //this.DataContext = worker;
            InitializeComponent();
            switch(worker.NumberForm)
            {
                case 1:
                    SelectForm.Children.Add(new FirstResumeForm() { DataContext = worker });
                    break;
                case 2:
                    SelectForm.Children.Add(new SecondResumeForm() { DataContext = worker });
                    break;
                case 3:
                    SelectForm.Children.Add(new ThirdResumeForm() { DataContext = worker });
                    break;
                case 4:
                    SelectForm.Children.Add(new FourthResumeForm() { DataContext = worker });
                    break;
                case 5:
                    SelectForm.Children.Add(new FifthResumeForm() { DataContext = worker });
                    break;
                case 6:
                    SelectForm.Children.Add(new SixthResumeForm() { DataContext = worker });
                    break;
            }
        }

        private void Button_Click_NewResume(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_ClickBack(object sender, RoutedEventArgs e)
        {
            ResumeDateEntryFour resumeDateEntryFour = new ResumeDateEntryFour(worker);
            resumeDateEntryFour.Show();
            this.Close();
        }

        private void Button_Click_SaveResume(object sender, RoutedEventArgs e)
        {
            try
            {
                string json = JsonSerializer.Serialize(worker, new JsonSerializerOptions { WriteIndented = true });

                string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Resumes");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, $"{worker.FirstName}_{worker.SecondName}_Resume.json");
                File.WriteAllText(filePath, json);

                MessageBox.Show($"Резюме сохранено в {filePath}", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения резюме: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
