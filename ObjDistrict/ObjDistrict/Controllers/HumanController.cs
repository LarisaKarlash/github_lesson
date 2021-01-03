using Microsoft.AspNetCore.Mvc;
using ObjDistrict.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjDistrict.Controllers
{
    public class HumanController : Controller
    {
        public IHumanRepository _humanRepository { get; set; }
        public HumanController(IHumanRepository humanRepository)
        {
            _humanRepository = humanRepository;
        }

        public IActionResult Index()
        {
            ViewData["Humans"] = _humanRepository.GetAllHumans().ToList();
            return View();
        }

        [Route("DistrictName/{idhuman:int:range(1,6)}")]
        public IActionResult DistrictName(int idhuman)
        {
            string name;
            name = _humanRepository.GetDistrict(idhuman);
            ViewData["District"] = name;

            return View();
        }
    }
}
