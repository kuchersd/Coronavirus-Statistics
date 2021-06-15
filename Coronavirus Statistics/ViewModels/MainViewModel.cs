using Coronavirus_Statistics.Services;
using Coronavirus_Statistics.Services.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coronavirus_Statistics.ViewModels
{
    public class MainViewModel
    {
        public CoronavirusCountriesChartViewModel CoronavirusCountriesChartViewModel { get; set; }

        public MainViewModel()
        {
            ICoronavirusCountryService coronavirusCountryService = new APICoronavirusCountryService();
            CoronavirusCountriesChartViewModel = CoronavirusCountriesChartViewModel.LoadViewModel(coronavirusCountryService);
        }
    }
}
