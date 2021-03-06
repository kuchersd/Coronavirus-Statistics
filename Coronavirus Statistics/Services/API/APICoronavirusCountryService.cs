using Coronavirus_Statistics.Models;
using Coronavirus_Statistics.Services.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coronavirus_Statistics.Services.API
{
    public class APICoronavirusCountryService : ICoronavirusCountryService
    {
        public async Task<IEnumerable<CoronavirusCountry>> GetTopCases(int amountOfCountries)
        {
            using(HttpClient client = new HttpClient())
            {
                string requestUri = "https://corona.lmao.ninja/v3/covid-19/countries?sort=cases";

                HttpResponseMessage apiResponse =  await client.GetAsync(requestUri);

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                // Make it readable.
                List<APICoronavirusCountry> apiCountries = JsonSerializer.Deserialize<List<APICoronavirusCountry>>(jsonResponse, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiCountries.Take(amountOfCountries).Select(apiCountry => new CoronavirusCountry()
                {
                    CountryName = apiCountry.Country,
                    CaseCount = apiCountry.Cases,
                    FlagUri = apiCountry.CountryInfo.Flag
                });

            }
        }
    }
}
