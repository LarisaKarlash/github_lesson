using CountryZip.ViewModels;
using System;

namespace CountryZip.Helpers
{
    public class FileHelper
    {
        public static string nameHttp;
        public static string Get_RestClientCountries(CountriesViewModel countries)
        {
            string rep = "https://api.zippopotam.us/";

            if (countries.Code != null & countries.Range != null)
            {
                nameHttp = rep + countries.Code + "/" + countries.Range;
            }
            else
            {
                nameHttp = rep + "us/90210";
            }

            return nameHttp;
        }

        public static string Get_CacheKeyCountries()
        {
            return $"file_{DateTime.UtcNow:yyyy_MM_dd}";
        }
        public static string Get_CacheKeyCountriesCache(string code)
        {
            return $"{code}file_{DateTime.UtcNow:yyyy_MM_dd}";
        }

        public static string Get_FileTypeCountries()
        {
            return "application/json";
        }

    }
}
