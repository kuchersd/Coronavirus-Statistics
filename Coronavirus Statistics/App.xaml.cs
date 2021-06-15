using Coronavirus_Statistics.Services.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Coronavirus_Statistics
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            APICoronavirusCountryService countryService = new APICoronavirusCountryService();

            var result = await countryService.GetTopCases(10);

            base.OnStartup(e);
        }
    }
}
