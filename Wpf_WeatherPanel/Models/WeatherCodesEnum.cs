using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_WeatherPanel.Models
{
    public enum WeatherCodes
    {
        ClearDay, // Ясный день (солнечно)
        ClearNight, // Ясная ночь (луна и звёзды)
        Shower, // Ливень (кратковременный дождь)
        Wind, // Ветрено (анимация ветра)
        Cloudly, // Облачно (лёгкие облака)
        Overcast, // Пасмурно (плотная облачность)
        PartyCloudlyDay, // Переменная облачность (день, солнце и облака)
        PartyCloudlyNight, // Переменная облачность (ночь, луна и облака)
        Fog, // Туман (размытые очертания)
        Drizzle,// Морось (мелкий дождь)
        Rain, // Дождь (умеренные осадки)
        SlightSnowfall, // Слабый снегопад (редкие снежинки)
        ModerateSnowfall, // Умеренный снегопад (заметные осадки)
        HardSnowfall, // Сильный снегопад (плотный снег)
        FreezingDrizzle, // Ледяной дождь (дождь с обледенением)
        Thunderstorm // Гроза (молнии и дождь)
    }
}
