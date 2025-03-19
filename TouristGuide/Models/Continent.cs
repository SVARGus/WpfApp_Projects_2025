using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Models;

namespace TouristGuide
{
    public class Continent
    {
        public string Name { get; set; } // Название континента
        public string Description { get; set; } // Короткое описание о континенте
        public string MapPhotoUrl { get; set; } // Ссылка на отображение карты континента
        public List<Country> Countries { get; set; } // Список стран на континенте
    }
}
