using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using TouristGuide.Models;

namespace TouristGuide
{
    public class Continent
    {
        public string Name { get; set; } // Название континента
        public string Description { get; set; } // Короткое описание о континенте
        public string MapPhotoUrl { get; set; } // Ссылка на отображение карты континента
        public string MapPhoto { get; set; } // адресс карты материка в проекте
        public List<Country> Countries { get; set; } = new List<Country>(); // Список стран на континенте
    }
}
