using Microsoft.AspNetCore.Mvc;
using ObjDistrict.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjDistrict.Controllers
{
    public class CountryController : Controller
    {
        public ICountryRepository _country { get;  }
        public CountryController(ICountryRepository country)
        {
            _country = country;
        }
        public IActionResult Index()
        {
            ViewData["Countries"] = _country.GetAllCountries().ToList();
            return View();
        }
        public IActionResult AddCountry()
        {
            try
            {
                _country.CreateCountry();
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            ViewData["Countries"] = _country.GetAllCountries().ToList();

            return View("Index");
        }
        public IActionResult DelCountry(int id)
        {
            try
            {
                _country.DeleteCountry(id);
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            ViewData["Countries"] = _country.GetAllCountries().ToList();

            return View("Index");
        }
    }
}
