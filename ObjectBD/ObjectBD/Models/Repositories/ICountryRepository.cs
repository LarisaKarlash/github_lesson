using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();

        IEnumerable<Country> GetCountry(int? id);

        void AddCountry(Country country);

        void RemoveCountry(int countryid);
    }
}
