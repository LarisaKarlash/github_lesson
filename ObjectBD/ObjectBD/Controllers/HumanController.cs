using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObjectBD.Models;
using ObjectBD.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Controllers 
{
    public class HumanController : Controller
    {
        private IHumanRepository _humanRepository { get;  }
        private ICountryRepository _countryRepository { get; }
        public HumanController(IHumanRepository humanRepository, ICountryRepository countryRepository)
        {
            _humanRepository = humanRepository;
            _countryRepository = countryRepository;
        }

        // Сделаем Index для модели HomeIndexViewModel
        public IActionResult Index(int? humanid)
        {
            IEnumerable<HomeIndexViewModel> humans;

            if (humanid == null)
            {
                humans = _humanRepository.GetAllHumans().Select(human => new HomeIndexViewModel 
                {
                    Id = human.Id,
                    FirstName = human.FirstName, 
                    LastName=human.LastName,
                    Age = human.Age,
                    //Country = human.Country.Name,
                    //CountryId = human.Country.Id
                }).ToList();

                // Доформировываем Country, CountryId
                int CountryId;
                foreach (var hum in humans)
                {
                    CountryId = (int)_humanRepository.GetAllHumans().First(human => human.Id == hum.Id).CountryId;
                    hum.CountryId = CountryId;
                    hum.Country = _countryRepository.GetAllCountries().First(country => country.Id == hum.CountryId).Name;
                }
            }
            else
            {
                humans = _humanRepository.GetAllHumans().Where(human => human.Id == humanid).Select(human => new HomeIndexViewModel
                {
                    Id = human.Id,
                    FirstName = human.FirstName,
                    LastName = human.LastName,
                    Age = human.Age,
                    //Country = human.Country.Name,
                    //CountryId = human.Country.Id
                }).ToList();

                // Доформировываем Country, CountryId
                int CountryId;
                foreach (var hum in humans)
                {
                    CountryId = (int)_humanRepository.GetAllHumans().First(human => human.Id == hum.Id).CountryId;
                    hum.CountryId = CountryId;
                    hum.Country = _countryRepository.GetAllCountries().First(country => country.Id == hum.CountryId).Name;
                }

            }

            return View(humans);
        }

        // Добавление человека
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Human human)
        {
            if (ModelState.IsValid)
            { 
            _humanRepository.AddHuman(human);
            }

            return View();
        }
       
        // Удаление человека
        public IActionResult Delete(int humanid)
        {
            try
            {
                _humanRepository.RemoveHuman(humanid);
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            ViewData["Humans"] = _humanRepository.GetAllHumans().ToList();

            return View("IndexViewData");
        }

        /*
        * выводить страны
        * через объект country
        */
        public IActionResult Country(int? countryid) //(string? countryname)
        {
            IEnumerable<Country> countries;

            if (countryid == null)
            {
                countries = _countryRepository.GetAllCountries().ToList();
            }
            else
            {
                //countries = _countryRepository.GetAllCountries().Where(country => country.Name.ToUpper() == countryname.ToUpper()).ToList();
                countries = _countryRepository.GetAllCountries().Where(country => country.Id == countryid).ToList();
            }

            return View(countries);
        }

        // Добавление страны
        [HttpGet]
        public IActionResult CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCountry(Country country)
        {
            _countryRepository.AddCountry(country);
            return View();
        }

        // Удаление страны
        public IActionResult DeleteCountry(int countryid)
        {
            try
            {
                _countryRepository.RemoveCountry(countryid);
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            IEnumerable<Country> countries;
            countries = _countryRepository.GetAllCountries().ToList();

            return View("Country",countries);
        }


        /*
         * выводить всех человеков, если параметр id равен нулю, 
         * в обратном случае выводить человека Id которого равен значению параметра id.
         * через ViewModel
        public IActionResult Index(int? id)
        {
            HomeInfoViewModels homeInfoViewModels = new HomeInfoViewModels();

            if (id == null )
                homeInfoViewModels.Humans = _humanRepository.GetAllHumans().ToList();
            else
                homeInfoViewModels.Humans = _humanRepository.GetAllHumans().Where(human => human.Id == id).ToList();

            return View(homeInfoViewModels);

        }
        */

        public IActionResult UpdHuman(int id, string lastname)
        {
            try
            {
                _humanRepository.ModifyHuman(id, lastname);
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            ViewData["Humans"] = _humanRepository.GetAllHumans().ToList();

            return View("IndexViewData");
        }

        public IActionResult AddHuman()
        {
            try
            {
                _humanRepository.CreateHuman();
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            ViewData["Humans"] = _humanRepository.GetAllHumans().ToList();

            return View("IndexViewData");
        }
        public IActionResult DelKillHuman()
        {
            try
            {
                _humanRepository.KillHuman();
            }
            catch (Exception e)
            {
                return (BadRequest(e));
            }

            ViewData["Humans"] = _humanRepository.GetAllHumans().ToList();

            return View("IndexViewData");
        }

        //Выведем страну по id одного человека
        /*  public IActionResult Country(string name) //(int humanid)
          {
              // чтобы подтянуть страну к human надо использовать Include - загрузка сразу Eagy Loading
              //ViewData["CountryName"] = _context.Humans.Include(human=>human.Country).First(human => human.Id == humanid).Country.Name;

              // без include - это Lazy Loading. Надо подключить библиотеку ..Proxies- закгрука когда понадобится
              //Подключили его приконнекте к БД
              //ViewData["CountryName"] = _humanRepository.GetAllHumans().First(human => human.Id == humanid).Country.Name;

              // выведем всех человеков из страны
              ViewData["CountryHumans"] = _humanRepository.Countries.First(country => country.Name.ToUpper() == name.ToUpper()).Humans.ToList();

              return View();
          }
          */

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
