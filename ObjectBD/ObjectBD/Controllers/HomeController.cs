using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ObjectBD.Models;
using ObjectBD.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHumanRepository _humanRepository { get; set; }
        private ICountryRepository _countryRepository { get; set; }

        public HomeController(ILogger<HomeController> logger, 
                              IHumanRepository humanRepository,
                              ICountryRepository countryRepository)
        {
            _logger = logger;
            _humanRepository = humanRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Создаем модель HomeInfoViewModels, которая объединяет Human и Country
        public IActionResult Info()
        {
            IEnumerable<Human> humans = _humanRepository.GetAllHumans() ;

            IEnumerable<Country> countries = _countryRepository.GetAllCountries();

            return View(new HomeInfoViewModel {Humans= humans, Countries= countries });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
