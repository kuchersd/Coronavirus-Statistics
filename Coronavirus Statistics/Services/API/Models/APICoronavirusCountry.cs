using System;
using System.Collections.Generic;
using System.Text;

namespace Coronavirus_Statistics.Services.API.Models
{
    public class APICoronavirusCountry
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public APICoronavirusCountryInfo CountryInfo { get; set; }
    }
}
