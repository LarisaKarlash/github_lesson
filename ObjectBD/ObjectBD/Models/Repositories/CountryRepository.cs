using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Models
{
    public class CountryRepository : ICountryRepository
    {
        private ObjectBDDBContext _context { get;  }
        public CountryRepository(ObjectBDDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries;
        }

        public IEnumerable<Country> GetCountry(int? id)
        {
            if (id == null)
            {
                return _context.Countries.ToList();
            }
            else
            {
                return _context.Countries.Where(country => country.Id == id).ToList();
            }
        }
        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void RemoveCountry(int countryid)
        {
            _context.Countries.Remove(_context.Countries.First(country => country.Id == countryid));
            _context.SaveChanges();
        }

    }
}
