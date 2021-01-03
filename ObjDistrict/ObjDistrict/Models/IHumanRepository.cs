using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjDistrict.Models
{
    public interface IHumanRepository
    {
      IEnumerable<Human> GetAllHumans();
     string GetDistrict(int idhuman);

    }
}
