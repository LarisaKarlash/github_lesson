using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Models.Repositories
{
    public interface IPlaceZpRepositories
    {
        IEnumerable<PlaceZp> GetPlacesZp(int? placeid);
        void AddPlaceZp(PlaceZp placezp);
        void RemovePlaceZp(int placeid);
    }
}
