using CountryZip.Models;
using CountryZip.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Controllers
{
    public class PlaceZpController : Controller
    {
        public readonly IPlaceZpRepositories _placeZp;
        public PlaceZpController(IPlaceZpRepositories placeZp)
        {
            _placeZp = placeZp;
        }
        // Чтение данных
        public IActionResult Index(int? placeid)
        {
            int _placeid = 0;
            if (placeid != null)
            {
                _placeid = (int)placeid;
            }

            return View("Index", ViewIndex(_placeid));
        }

        //Добавление данных
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PlaceZp placez)
        {
            if (ModelState.IsValid)
            {
                _placeZp.AddPlaceZp(placez);
                return View("Index", ViewIndex(0));
            }
            else
            {
                return View();
            }
        }

        // Удаление данных
        public IActionResult Delete(int placeid)
        {
            try
            {
                _placeZp.RemovePlaceZp(placeid);
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            return View("Index", ViewIndex(0));
        }

        // Подготовка списка для View
        public IEnumerable<PlaceZp> ViewIndex(int placeid)
        {
            return _placeZp.GetPlacesZp(placeid).ToList();
        }
    }
}
