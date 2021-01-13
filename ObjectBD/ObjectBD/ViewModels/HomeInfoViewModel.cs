using ObjectBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.ViewModels
{
    public class HomeInfoViewModel
    {
        public IEnumerable<Human> Humans;

        public IEnumerable<Country> Countries;

    }
}
