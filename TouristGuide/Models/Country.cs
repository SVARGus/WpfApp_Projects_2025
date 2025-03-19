using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TouristGuide.Models
{
    public class Country
    {
        public string Name { get; set; } // Название страны
        public string Currency { get; set; } // Название валюты
        public string FlagPhotoUrl { get; set; } // Ссылка на фотографию Флага
        public string FlagPhoto { get; set; } // Сам флаг (пока не определился что лучше использовать: URL ссылку или на само фото в проекте
        public string GeneralInfo { get; set; } // Общая информация о стране
        public List<Location> Locations { get; set; } = new List<Location>(); // Список локаций, городов, штатов, областей и других крупных субъектов страны
        public List<Continent> Continents { get; set; } = new List<Continent>(); // Ссылка на континетнт, в некоторых случаях страна может находиться одновременно на двух континентах и для этого требуется лист
    }
}
