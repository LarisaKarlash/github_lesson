using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Models
{
    public interface IHumanRepository
    {
        IEnumerable<Human> GetAllHumans();      

        IEnumerable<Human> GetHuman(int? id);

        void AddHuman(Human human);

        void RemoveHuman(int humanid);

        void ModifyHuman(int id, string lastname);

        void KillHuman();

        void CreateHuman();


    }
}
