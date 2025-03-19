using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Services
{
    public class MainWindowViewModel
    {
        public List<Continent> Continents { get; set; }

        public MainWindowViewModel()
        {
            Continents = DataManager.GetContinents();
        }
    }
}
