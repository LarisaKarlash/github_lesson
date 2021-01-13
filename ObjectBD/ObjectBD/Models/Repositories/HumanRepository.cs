using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ObjectBD.Models
{
    public class HumanRepository : IHumanRepository
    {
        private ObjectBDDBContext _context { get; }
        public HumanRepository(ObjectBDDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans;
        }
        public IEnumerable<Human> GetHuman(int? id)
        {
            return _context.Humans.Where(human=>human.Id ==id).ToList();
        }

        public void AddHuman(Human human)
        {
            _context.Humans.Add(human);
            _context.SaveChanges();
        }
        public void RemoveHuman(int humanid)
        {
            _context.Humans.Remove(_context.Humans.First(human => human.Id == humanid));
            _context.SaveChanges();
        }

        public void KillHuman()
        {
           _context.Humans.RemoveRange(_context.Humans.Where(human => human.Id != 0));
           _context.SaveChanges();
        }

        public void CreateHuman()
        {

            Human human = new Human() { FirstName = "Mikle", LastName = "Smitt", Age = 56, IsSick = true, Gender = "Male", CountryId = 4 };

            _context.Humans.Add(human);         
            _context.SaveChanges();
        }
        public void ModifyHuman(int id, string lastname)
        {
            
           var p_human = _context.Humans.Where(human => human.Id == id).FirstOrDefault();

            p_human.LastName = lastname;          
            _context.SaveChanges();
        }

    }
}
