using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Models.Repositories
{
    public class PlaceZpRepositories : IPlaceZpRepositories
    {
        private readonly ObjCountryDBContext _context;
        public PlaceZpRepositories(ObjCountryDBContext context)
        {
            _context = context;
        }
        public IEnumerable<PlaceZp> GetPlacesZp(int? placeid)
        {
            if (placeid == null || placeid == 0)
            {
                return _context.PlacesZp.ToList();
            }
            else
            {
                return _context.PlacesZp.Where(place => place.Id == placeid).ToList();
            }

        }
        public void AddPlaceZp(PlaceZp placezp)
        {
            _context.PlacesZp.Add(placezp);
            _context.SaveChanges();
        }

        public void RemovePlaceZp(int placeid)
        {
            if (placeid != 0)
            {
                _context.PlacesZp.Remove(_context.PlacesZp.First(place => place.Id == placeid));
                _context.SaveChanges();
            }
        }
    }
}
