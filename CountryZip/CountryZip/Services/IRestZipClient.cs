using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Services
{
    public interface IRestZipClient
    {
        public byte[] GetFileCountries();
        public byte[] GetFileCountriesCache(string nameHttp);
    }
}
