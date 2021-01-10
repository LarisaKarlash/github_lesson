using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjDistrict.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();

        void CreateCountry();

        void DeleteCountry(int id);
    }
}
