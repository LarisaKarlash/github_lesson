using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Models.Repositories
{
    public interface ICountryNsiRepositories
    {
        IEnumerable<CountryNsi> GetCountriesNsi(int? countrynid);
        void AddCountryNsi(CountryNsi countrynsi);
        void RemoveCountryNsi(int countrynid);
    }
}
