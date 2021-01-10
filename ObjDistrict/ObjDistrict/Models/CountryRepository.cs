using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjDistrict.Models
{
    public class CountryRepository :ICountryRepository
    {
        private ObjDistrictDbContext _dbContext { get; }
        public CountryRepository(ObjDistrictDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _dbContext.Countries;
        }
        public void CreateCountry()
        {
            Country country = new Country();
            country.Name = "France";
            country.Population = 35000000;
            country.SickCount =   1500000;
            country.DeadCount = 50000;
            country.RecoveredCount = 13000000;
            country.Vaccine = true;

            _dbContext.Countries.Add(country);

            _dbContext.SaveChanges();
        }

        public void DeleteCountry(int id)
        {
            _dbContext.Countries.Remove(_dbContext.Countries.First(country => country.Id == id));
            _dbContext.SaveChanges();
        }
    }
   
}
