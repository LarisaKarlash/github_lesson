using Microsoft.AspNetCore.Mvc;
using ObjectBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Controllers
{
    public class HumanRepController : Controller
    {
        public IHumanRepository _humanRepository { get; }
        public HumanRepController(IHumanRepository humanRepository)
        {
            _humanRepository = humanRepository;
        }

        public IActionResult Index(int id)
        {

            /*RemoveRange Human*/
            //_humanRepository.KillHuman();

            /*AddRange Human*/
            //_humanRepository.CreateHuman();

            /*меняет фамилию для id=7*/
            if (id == 7)
                _humanRepository.ModifyHuman(id);

            /*
             * выводить всех человеков, если параметр id равен нулю - GetAllHumans(), 
             * в обратном случае выводить человека Id которого равен значению параметра id - GetHuman(id)
             */
            if (id==0)
               ViewData["HumanRep"] = _humanRepository.GetAllHumans().ToList();
            else
               ViewData["HumanRep"] = _humanRepository.GetHuman(id).ToList();

            return View();
        }


    }
}
