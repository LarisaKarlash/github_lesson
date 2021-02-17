using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Models.Repositories
{
    public class CountryNsiRepositories : ICountryNsiRepositories
    {
        private readonly ObjCountryDBContext _context;
        public CountryNsiRepositories(ObjCountryDBContext context)
        {
            _context = context;
        }
        public IEnumerable<CountryNsi> GetCountriesNsi(int? countrynid)
        {
            if (countrynid == null || countrynid == 0)
            {
                return _context.CountriesNsi.ToList();
            }
            else
            {
                return _context.CountriesNsi.Where(country => country.Id == countrynid).ToList();
            }

        }
        public void AddCountryNsi(CountryNsi countrynsi)
        {
            _context.CountriesNsi.Add(countrynsi);
            _context.SaveChanges();
        }

        public void RemoveCountryNsi(int countrynid)
        {
            if (countrynid !=0)
            {
                _context.CountriesNsi.Remove(_context.CountriesNsi.First(country => country.Id == countrynid));
                _context.SaveChanges();
            }
        }

    }
}
