using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_WeatherPanel.Models
{
    public class HourlyForecastModel
    {
        public DateTime Time { get; set; }
        public float Temperature { get; set; }
        public float ApparentTemperature { get; set; }
        public float RelativeHumidity { get; set; }
        public float SurfasePressure { get; set; }
        public float WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public WeatherCodes Weather { get; set; } // что за WeatherCodes???
    }
}
