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

        //public void KillHuman()
        //{
        //    var human = new List<Human> {
        //        new Human { Id = 1, FirstName = "Obi-wan", LastName = "Kenobi", Age = 38, IsSick = false, Gender = "Male", CountryId = 1 },
        //        new Human { Id = 2, FirstName = "Sanwise", LastName = "Gamgee", Age = 54, IsSick = false, Gender = "Male", CountryId = 1 },
        //        new Human { Id = 3, FirstName = "Hose", LastName = "Rodriges", Age = 30, IsSick = true, Gender = "Male", CountryId = 3 },
        //        new Human { Id = 4, FirstName = "Consuela", LastName = "Tridana", Age = 43, IsSick = false, Gender = "Female", CountryId = 3 },
        //        new Human { Id = 5, FirstName = "Ana", LastName = "Cormelia", Age = 25, IsSick = true, Gender = "Female", CountryId = 3 },
        //        new Human { Id = 6, FirstName = "Thomas", LastName = "Edison", Age = 84, IsSick = true, Gender = "Male", CountryId = 1 },
        //        new Human { Id = 7, FirstName = "Mikle", LastName = "Smitt", Age = 56, IsSick = true, Gender = "Male", CountryId = 4 }
        //    };

        //    _context.RemoveRange(human);
        //    _context.SaveChanges();
        //}

        //public void CreateHuman()
        //{
        //    var human = new List<Human> {
        //        new Human { Id = 1, FirstName = "Obi-wan", LastName = "Kenobi", Age = 38, IsSick = false, Gender = "Male", CountryId = 1 },
        //        new Human { Id = 2, FirstName = "Sanwise", LastName = "Gamgee", Age = 54, IsSick = false, Gender = "Male", CountryId = 1 },
        //        new Human { Id = 3, FirstName = "Hose", LastName = "Rodriges", Age = 30, IsSick = true, Gender = "Male", CountryId = 3 },
        //        new Human { Id = 4, FirstName = "Consuela", LastName = "Tridana", Age = 43, IsSick = false, Gender = "Female", CountryId = 3 },
        //        new Human { Id = 5, FirstName = "Ana", LastName = "Cormelia", Age = 25, IsSick = true, Gender = "Female", CountryId = 3 },
        //        new Human { Id = 6, FirstName = "Thomas", LastName = "Edison", Age = 84, IsSick = true, Gender = "Male", CountryId = 1 },
        //        new Human { Id = 7, FirstName = "Mikle", LastName = "Smitt", Age = 56, IsSick = true, Gender = "Male", CountryId = 4 }
        //    };

            //_context.Database.OpenConnection();
            //try
            //{
            //    object p = _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Human ON");
            //    _context.SaveChanges();
            //    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Human OFF");
            //}
            //finally
            //{
            //    _context.Database.CloseConnection();
            //}

            //_context.AddRange(human);
            //_context.SaveChanges();
       // }

        public void ModifyHuman(int id)
        {
            
           var p_human = _context.Humans.Where(human => human.Id == id).FirstOrDefault();

            p_human.LastName = "Tomson";          
            _context.SaveChanges();
        }
      

    }
}
