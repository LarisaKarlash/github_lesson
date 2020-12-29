using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObjectBD.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Controllers 
{
    public class HumanController : Controller
    {
        public ObjectBDDBContext _context { get;  }
        public HumanController(ObjectBDDBContext context)
        {
            _context = context;
        }

        /*
         * выводить всех человеков, если параметр id равен нулю, 
         * в обратном случае выводить человека Id которого равен значению параметра id.
         */

        public IActionResult Index(int id)
        {
            if (id == 0 )
              ViewData["Humans"] = _context.Humans.ToList();
            else
              ViewData["Humans"] = _context.Humans.Where(human => human.Id == id).ToList();

            return View();
        }

        //Выведем все
        //public IActionResult Index()
        //{
        //    ViewData["Humans"] = _context.Humans.ToList();
        //    return View();
        //}

        //Выведем страну по id одного человека
        public IActionResult Country(string name) //(int humanid)
        {
            // чтобы подтянуть страну к human надо использовать Include - загрузка сразу Eagy Loading
            //ViewData["CountryName"] = _context.Humans.Include(human=>human.Country).First(human => human.Id == humanid).Country.Name;

            // без include - это Lazy Loading. Надо подключить библиотеку ..Proxies- закгрука когда понадобится
            //Подключили его приконнекте к БД
            //ViewData["CountryName"] = _context.Humans.First(human => human.Id == humanid).Country.Name;

            /*
             * выведем всех человеков из страны
             */
            ViewData["CountryHumans"] = _context.Countries.First(country => country.Name.ToUpper() == name.ToUpper()).Humans.ToList();

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
