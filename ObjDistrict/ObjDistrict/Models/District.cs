using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjDistrict.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

    }
}
