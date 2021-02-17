using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Models.Repositories
{
    public interface ICountryZpRepositories
    {
        IEnumerable<CountryZp> GetCountriesZp(int? countryzid);
        void AddCountryZp(CountryZp countryzp);
        void RemoveCountryZp(int countryzid);
    }
}
