using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_WeatherPanel.Models;

namespace Wpf_WeatherPanel.Services
{
    public static class WeatherDataManager
    {
        private static List<WeatherDay> _weatherData;
        private static YandexWeatherService _weatherService;
        private static bool _userRealApi = false; // Флаг использования реального API, пока в форме теста будет false, после подключения яндекс API нужно будет протестировать

        public static void Initialize(string apiKey = null) // в тестовом режиме ключ не передается
        {
            _userRealApi = !string.IsNullOrEmpty(apiKey); // Проверка на наличие ключа
            if (_userRealApi)
            {
                _weatherService = new YandexWeatherService(apiKey);
            }
            else
            {
                GenerateTestData();
            }
        }

        private static void GenerateTestData() // генерация тестовых данных за 7 дней
        {
            _weatherData = new List<WeatherDay>();
            var rand = new Random();
            var startDate = DateTime.Today;

            for (int i = 0; i < 7; ++i)
            {
                var date = startDate.AddDays(i);
                var hourlyForecasts = GenerateHourlyForecasts(date, rand);

                int direction = rand.Next(0, 360);
                _weatherData.Add(new WeatherDay
                {
                    Date = date,
                    WeekDay = date.ToString("dddd"),
                    Location = "Test Location",
                    MaxTemperature = rand.Next(15, 25),
                    MinTemperature = rand.Next(5, 15),
                    DayTemperature = rand.Next(10, 20),
                    NightTemperature = rand.Next(0, 10),
                    ConditionWeather = GetRandomCondition(rand),
                    WindSpeed = rand.Next(1, 10),
                    WindGust = rand.Next(5, 15),
                    WindDirection = direction,
                    WindCardinal = DegreesToCardinal(direction),
                    Humidity = rand.Next(30, 90),
                    Pressure = rand.Next(720, 780),
                    DayWeather = hourlyForecasts
                });
            }
        }

        private static List<HourlyForecastModel> GenerateHourlyForecasts(DateTime date, Random rand) // Генерация тестовых данных по часам за день
        {
            var forecasts = new List<HourlyForecastModel>();
            for(int hour = 0; hour < 24; ++hour)
            {
                int direction = rand.Next(0, 360);
                forecasts.Add(new HourlyForecastModel
                {
                    Time = date.AddHours(hour),
                    Temperature = rand.Next(5, 25),
                    ApparentTemperature = rand.Next(0, 20),
                    RelativeHumidity = rand.Next(40, 95),
                    SurfasePressure = rand.Next(720, 780),
                    WindSpeed = rand.Next(1, 10),
                    WindDirection = direction,
                    WindCardinal = DegreesToCardinal(direction),
                    Weather = (WeatherCodes)rand.Next(0, 16)
                });
            }
            return forecasts;
        }

        private static string GetRandomCondition(Random rand) // Генерация погодных условия
        {
            var conditions = new[] { "ясно", "облачно", "пасмурно", "дождь", "снег", "гроза" };
            return conditions[rand.Next(conditions.Length)];
        }

        private static string DegreesToCardinal(int degree) // Определение стороны света исходя из данных 
        {
            string[] directions = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
            int index = (int)Math.Round(degree / 45.0) % 8;
            return directions[index];
        }

    }
}
