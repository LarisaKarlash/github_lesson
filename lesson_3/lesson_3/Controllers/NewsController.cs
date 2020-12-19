using lesson_3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson_3.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
