using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeEditor.Models
{
    public class UserWorker
    {
        public UserWorker()
        {
        }

        public UserWorker(string desiredPosition, string firstName, string secondName, string age, DateTime birthDay, string cityResidence, string photo, 
            string phone, string email, 
            string positionWork, string companyWork, DateTime gettingStartWork, DateTime endWork, string descriptionLastWork, 
            string basicEducation, string educationInstitution, string faculty, string specialitu, DateTime endEducation, 
            string aboutMe)
        {
            DesiredPosition = desiredPosition;
            FirstName = firstName;
            SecondName = secondName;
            Age = Age;
            BirthDay = birthDay;
            CityResidence = cityResidence;
            Photo = photo;

            Phone = phone;
            Email = email;

            PositionWork = positionWork;
            CompanyWork = companyWork;
            GettingStartWork = gettingStartWork;
            EndWork = endWork;
            DescriptionLastWork = descriptionLastWork;

            BasicEducation = basicEducation;
            EducationInstitution = educationInstitution;
            Faculty = faculty;
            Specialitu = specialitu;
            EndEducation = endEducation;

            AboutMe = aboutMe;
        }

        // Личные данные
        public string DesiredPosition { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Age { get; set; }
        public DateTime BirthDay { get; set; }
        public string CityResidence { get; set; }
        public string Photo { get; set; }
        
        // Контакты
        public string Phone { get; set; }

        public string Email { get; set; }

        // Последний опыт работы (позже вывести в отдельный класс, а сдесь хранить лист прошлых мест работы)
        public string PositionWork { get; set; }
        public string CompanyWork { get; set; }
        public DateTime GettingStartWork { get; set; }
        public DateTime EndWork { get; set; }
        public string DescriptionLastWork { get; set; }
        
        // Оброзование (позже вывести в отдельный класс, а сдесь хранить лист оброзовательных учреждений)
        public string BasicEducation { get; set; }
        public string EducationInstitution { get; set; }
        public string Faculty { get; set; }
        public string Specialitu { get; set; }
        public DateTime EndEducation { get; set; }

        // Дополнительные поля
        public string AboutMe { get; set; }

        public int NumberForm { get; set; } // Номер выбранной моедели
    }
}
