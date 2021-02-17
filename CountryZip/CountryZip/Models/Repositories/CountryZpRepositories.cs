using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Models.Repositories
{
    public class CountryZpRepositories : ICountryZpRepositories
    {
        private readonly ObjCountryDBContext _context;
        public CountryZpRepositories(ObjCountryDBContext context)
        {
            _context = context;
        }
        public IEnumerable<CountryZp> GetCountriesZp(int? countryzid)
        {
            if (countryzid == null || countryzid == 0)
            {
                return _context.CountriesZp.ToList();
            }
            else
            {
                return _context.CountriesZp.Where(country => country.Id == countryzid).ToList();
            }

        }
        public void AddCountryZp(CountryZp countryzp)
        {
            _context.CountriesZp.Add(countryzp);
            _context.SaveChanges();
        }

        public void RemoveCountryZp(int countryzid)
        {
            if (countryzid != 0)
            {
                _context.CountriesZp.Remove(_context.CountriesZp.First(country => country.Id == countryzid));
                _context.SaveChanges();
            }
        }

    }
}
