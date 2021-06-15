using Coronavirus_Statistics.Models;
using Coronavirus_Statistics.Services;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronavirus_Statistics.ViewModels
{
    public class CoronavirusCountriesChartViewModel
    {
        private const int AMOUNT_OF_COUNTRIES = 10;
        private readonly ICoronavirusCountryService _coronavirusCountryService;

        public ChartValues<int> CoronavirusCountryCaseCounts { get; set; } 

        public string[] CoronavirusCountryNames { get; set; }

        public CoronavirusCountriesChartViewModel(ICoronavirusCountryService coronavirusCountryService)
        {
            _coronavirusCountryService = coronavirusCountryService;

            Load();
        }

        // Factory method.
        public static CoronavirusCountriesChartViewModel LoadViewModel(ICoronavirusCountryService coronavirusCountryService, Action<Task> onLoaded = null)
        {
            CoronavirusCountriesChartViewModel viewModel = new CoronavirusCountriesChartViewModel(coronavirusCountryService);

            viewModel.Load().ContinueWith(t => onLoaded?.Invoke(t));

            return viewModel;
        }

        public async Task Load()
        {
            IEnumerable<CoronavirusCountry> countries = await _coronavirusCountryService.GetTopCases(10);

            CoronavirusCountryCaseCounts = new ChartValues<int>(countries.Select(c => c.CaseCount));
            CoronavirusCountryNames = countries.Select(c => c.CountryName).ToArray();
        }
    }
}
