using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_WeatherPanel.Models
{
    public class WeatherDay
    {
        public DateTime Date { get; set; } // Текущая дата
        public string WeekDay { set; get; } // День недели
        public string Location { set; get; } // Название локации
        public double MaxTemperature { set; get; } // Максимальная температура
        public double MinTemperature { set; get; } // минимальная температура
        public double DayTemperature { set; get; } // Дневная температура
        public double NightTemperature { set; get; } // ночная температура
        public string ConditionWeather { set; get; } // Обозначение погоды (облачно, осадки, солнечно), можно по идее вынести в Enum
        public double WindSpeed { set; get; } // Скорость ветра
        public double WindGust { set; get; } // Порывы ветра
        public int WindDirection { set; get; } // направление ветра (градусы)
        public string WindCardinal { set; get; } // Направление ветра (WE, SW, W и т.д.), можно сделать через enum
        public double Humidity { set; get; } // Влажность в %
        public double Pressure { set; get; } // Атмосферное давление
        public List<HourlyForecastModel> DayWeather {set; get;} // Лист почасовой разбивки погоды
    }
}
