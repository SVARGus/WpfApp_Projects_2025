using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Models
{
    public class MonthWeather
    {
        public string Mounth { get; set; } // Название месяца или сезона
        public double MinTemp { get; set; } // Минимальная температура
        public double MaxTemp { get; set; } // Максимальная температура
        public string Precipitation { get; set; } // Уровень осадков
        public string Description { get; set; } // Краткое описание погоды
    }
}
