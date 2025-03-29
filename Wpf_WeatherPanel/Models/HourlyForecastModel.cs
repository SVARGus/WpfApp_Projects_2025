using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_WeatherPanel.Models
{
    public class HourlyForecastModel
    {
        public DateTime Time { get; set; } // Час
        public float Temperature { get; set; } // Температура
        public float ApparentTemperature { get; set; } // Как ощущается температура
        public float RelativeHumidity { get; set; } // Относительная влажность
        public float SurfasePressure { get; set; } // Атмосферное давление
        public float WindSpeed { get; set; } // Скорость ветра
        public int WindDirection { get; set; } // Направление ветра (градусы)
        public string WindCardinal { set; get; } // Направление ветра (WE, SW, W и т.д.), можно сделать через enum
        public WeatherCodes Weather { get; set; } // Код погоды
    }
}
