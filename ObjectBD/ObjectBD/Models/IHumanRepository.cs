using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Models
{
    public interface IHumanRepository
    {
        IEnumerable<Human> GetAllHumans();

        IEnumerable<Human> GetHuman(int id);

        void ModifyHuman(int id);

        //void KillHuman();

        //void CreateHuman();
        
        
    }
}
