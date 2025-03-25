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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResumeEditor.Controls
{
    /// <summary>
    /// Логика взаимодействия для FirstResumeForm.xaml
    /// </summary>
    public partial class FirstResumeForm : UserControl
    {
        public UserWorker userWorker = new UserWorker() // тестовые данные
        {
            DesiredPosition = "Software Developer",
            FirstName = "Иван",
            SecondName = "Иванов",
            Age = "34",
            //BirthDay = new DateTime(1990, 5, 15),
            CityResidence = "Москва",
            Photo = "/Resources/Image/Тестовое фото.png",
            Phone = "+7 (999) 123-45-67",
            Email = "ivan.ivanov@example.com",
            PositionWork = "Junior Developer",
            CompanyWork = "ООО Ромашка",
            GettingStartWork = new DateTime(2018, 6, 1),
            EndWork = new DateTime(2023, 5, 31),
            DescriptionLastWork = "Разработка и поддержка веб-приложений.",
            BasicEducation = "Высшее",
            EducationInstitution = "Московский государственный университет",
            Faculty = "Факультет вычислительной математики и кибернетики",
            Specialitu = "Прикладная математика и информатика",
            EndEducation = new DateTime(2017, 6, 30),
            AboutMe = "Увлекаюсь программированием, изучаю новые технологии и frameworks."
        };
        public FirstResumeForm()
        {
            this.DataContext = userWorker;
            InitializeComponent();
            if (DataContext == null)
            {
                throw new Exception("DataContext не установлен.");
            }
        }
    }
}
