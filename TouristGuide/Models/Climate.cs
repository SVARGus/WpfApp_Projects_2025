using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Models
{
    public class Climate
    {
        public Dictionary<string, MonthWeather> WeatherByMonth { get; set; } = new Dictionary<string, MonthWeather>();
    }
}
