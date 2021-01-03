using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ObjectBD.Models
{
    public class HumanRepository : IHumanRepository
    {
        public ObjectBDDBContext _context { get; }
        public HumanRepository(ObjectBDDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans;
        }
        public IEnumerable<Human> GetHuman(int id)
        {
            return _context.Humans.Where(human=>human.Id ==id).ToList();
        }

        public void KillHuman()
        {
           _context.Humans.RemoveRange(_context.Humans.Where(human => human.Id != 0));

           _context.SaveChanges();
        }

        public void CreateHuman()
        {
         
          var human = new List<Human> {
                new Human { FirstName = "Obi-wan", LastName = "Kenobi", Age = 38, IsSick = false, Gender = "Male", CountryId = 1 },
                new Human { FirstName = "Sanwise", LastName = "Gamgee", Age = 54, IsSick = false, Gender = "Male", CountryId = 1 },
                new Human { FirstName = "Hose", LastName = "Rodriges", Age = 30, IsSick = true, Gender = "Male", CountryId = 3 },
                new Human { FirstName = "Consuela", LastName = "Tridana", Age = 43, IsSick = false, Gender = "Female", CountryId = 3 },
                new Human { FirstName = "Ana", LastName = "Cormelia", Age = 25, IsSick = true, Gender = "Female", CountryId = 3 },
                new Human { FirstName = "Thomas", LastName = "Edison", Age = 84, IsSick = true, Gender = "Male", CountryId = 1 },
                new Human { FirstName = "Mikle", LastName = "Smitt", Age = 56, IsSick = true, Gender = "Male", CountryId = 4 }
            };            

            _context.Humans.AddRange(human);         

            _context.SaveChanges();
        }
        public void ModifyHuman(int id)
        {
            
           var p_human = _context.Humans.Where(human => human.Id == id).FirstOrDefault();

            p_human.LastName = "Tomson";          
            _context.SaveChanges();
        }
        public void DeleteHuman(int id)
        {
            _context.Humans.Remove(_context.Humans.First(human=>human.Id==id));
            _context.SaveChanges();
        }

    }
}
