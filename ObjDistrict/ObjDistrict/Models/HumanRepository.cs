using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjDistrict.Models
{
    public class HumanRepository : IHumanRepository
    {
        private ObjDistrictDbContext _districtDbContext { get; }
        public HumanRepository(ObjDistrictDbContext districtDbContext)
        {
            _districtDbContext = districtDbContext;
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _districtDbContext.Humans;
        }
        public string GetDistrict(int idhuman)
        {
            string name;
            name = _districtDbContext.Humans.First(human => human.Id == idhuman).District.Name;
            return name;
        }

    }
}
