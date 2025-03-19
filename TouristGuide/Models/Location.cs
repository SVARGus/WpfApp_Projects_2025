using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TouristGuide.Models
{
    public class Location
    {
        public string Name { get; set; } // название региона (города, области)
        public string TimeZone { get; set; } // часовой пояс (например UTC+3)
        public Climate Climate { get; set; } // Климатические данные
        public List<string> PhotoUrls { get; set; } // Ссылка на фотографию в интернете
        public List<Image> Photos { get; set; } // Фотографии
        public Country Country { get; set; } // ссылка на страну
    }
}
