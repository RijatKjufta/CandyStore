using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Controllers
{
    public class CoffeTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
