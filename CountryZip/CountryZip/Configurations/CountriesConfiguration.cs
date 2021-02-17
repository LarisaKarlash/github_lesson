using Newtonsoft.Json;
using System.Collections.Generic;

namespace CountryZip.Configurations
{
    public class CountriesConfiguration
    {
        [JsonProperty("post code")]
        public string postCode { get; set; }
        public string country { get; set; }

        [JsonProperty("country abbreviation")]
        public string countryAbbreviation { get; set; }

        public List<places> places { get; set; }

    }
    public class places
    {
        [JsonProperty("place name")]
        public string placeName { get; set; }
        public string longitude { get; set; }
        public string state { get; set; }

        [JsonProperty("state abbreviation")]
        public string stateAbbreviation { get; set; }
        public string latitude { get; set; }
    }
}
