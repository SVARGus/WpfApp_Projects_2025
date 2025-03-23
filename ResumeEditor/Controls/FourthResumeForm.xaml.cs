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

namespace ResumeEditor.Controls
{
    /// <summary>
    /// Логика взаимодействия для FourthResumeForm.xaml
    /// </summary>
    public partial class FourthResumeForm : UserControl
    {
        public UserWorker worker = new UserWorker
        {
            // Личные данные
            DesiredPosition = "Software Developer",
            FirstName = "Иван",
            SecondName = "Иванов",
            Age = "36",
            BirthDay = new DateTime(1990, 5, 15),
            CityResidence = "Москва",
            Photo = "/Resources/Image/Тестовое фото.png",

            // Контакты
            Phone = "+7 (999) 123-45-67",
            Email = "ivan.ivanov@example.com",

            // Последний опыт работы
            PositionWork = "Junior Developer",
            CompanyWork = "ООО Ромашка",
            GettingStartWork = new DateTime(2018, 6, 1),
            EndWork = new DateTime(2023, 5, 31),
            DescriptionLastWork = "Разработка и поддержка веб-приложений.",

            // Образование
            BasicEducation = "Высшее",
            EducationInstitution = "Московский государственный университет",
            Faculty = "Факультет вычислительной математики и кибернетики",
            Specialitu = "Прикладная математика и информатика",
            EndEducation = new DateTime(2017, 6, 30),

            // Дополнительные поля
            AboutMe = "Увлекаюсь программированием, изучаю новые технологии и frameworks."
        };
        public FourthResumeForm()
        {
            this.DataContext = worker;
            InitializeComponent();
        }
    }
}
