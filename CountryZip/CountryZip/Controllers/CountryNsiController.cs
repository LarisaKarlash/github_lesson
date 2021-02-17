using CountryZip.Models;
using CountryZip.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Controllers
{
    public class CountryNsiController : Controller
    {
        public readonly ICountryNsiRepositories _countryNsi;
        public CountryNsiController(ICountryNsiRepositories countryNsi )
        {
            _countryNsi = countryNsi;
        }
        // Чтение данных
        public IActionResult Index(int? countrynid)
        {
            int _countrynid = 0;
            if (countrynid != null)
            {
                _countrynid = (int)countrynid;
            }

            return View("Index", ViewIndex(_countrynid));
        }

        // Добавление данных
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CountryNsi countryn)
        {
            if (ModelState.IsValid)
            {
                _countryNsi.AddCountryNsi(countryn);
                return View("Index", ViewIndex(0));
            }
            else 
            {
                return View();
            }

        }

        // Удаление данных
        public IActionResult Delete(int countrynid)
        {
            try
            {
                _countryNsi.RemoveCountryNsi(countrynid);
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            return View("Index", ViewIndex(0));
        }

        // Подготовка списка для View
        public IEnumerable<CountryNsi> ViewIndex(int countrynid)
        {
             return _countryNsi.GetCountriesNsi(countrynid).ToList();
        }
    }
}
