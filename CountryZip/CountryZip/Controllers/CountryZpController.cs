using CountryZip.Models;
using CountryZip.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Controllers
{
    public class CountryZpController : Controller
    {
        public readonly ICountryZpRepositories _countryZp;
        public CountryZpController(ICountryZpRepositories countryZp)
        {
            _countryZp = countryZp;
        }
        // Чтение данных
        public IActionResult Index(int? countryzid)
        {
            int _countryzid = 0;
            if (countryzid != null)
            {
                _countryzid = (int)countryzid;
            }

            return View("Index", ViewIndex(_countryzid));
        }

        //Добавление данных
       [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CountryZp countryz)
        {
            if (ModelState.IsValid)
            {
                _countryZp.AddCountryZp(countryz);
                return View("Index", ViewIndex(0));
            }
            else
            { 
                return View();
            }

        }

        // Удаление данных
        public IActionResult Delete(int countryzid)
        {
            try
            {
                _countryZp.RemoveCountryZp(countryzid);
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            return View("Index", ViewIndex(0));
        }

        // Подготовка списка для View
        public IEnumerable<CountryZp> ViewIndex(int countryzid)
        {
            return _countryZp.GetCountriesZp(countryzid).ToList();
        }
    }
}
