using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TouristGuide.Models
{
    public class TouristSpot
    {
        public string Name { get; set; } // Название туристической точки (например это может быть Улица, или отдельное здание
        // Позже добавить поле с данными геолокации
        public List<string> PhotoUrsl { get; set; } // Ссылка на фотографию в интернете
        public List<Image> Photos { get; set; } // Фотографии
        public List<string> VideoUrls { get; set; } // Ссылки на видео в интеренет
        public string Description { get; set; } // Общее описание туристической точки
        public List<string> InterestingFacts { get; set; } // список интересных фактов
        public string LocalCuisine { get; set; } // описание местной кухни
        public Location Location { get; set; } // ссылка на локацию
        public List<string> Attractions { get; set; } // список достопримечательностей
        public List<string> Dangers { get; set; } // список опасностей и предосторожносте
        public string PriceInfo { get; set; } // Цены на проживание и питание
        public string AdditionalData { get; set; } // Прочие данные
    }
}
